
Option Explicit On
Imports System.Data
Imports System.IO
Imports System.Data.Common
Imports System.xml
Imports VB = Microsoft.VisualBasic
Imports LATIR2.Utils


Public Class Session
    'Description:
    'Главный интерфейс компонента


    Private Path As String
    Private mAlias As String
    Private mDataBaseName As String
    Private mUserName As String
    Private mServer As String
    Private mPassword As String
    Private mProvider As String

    Private mLoginTimeOut As Short
    Private msite As String
    Private Integrated As Boolean
    Private mConnectString As String
    Private mXmlFile As String
    Private m_Language As String
    Private _errorMessage As String = String.Empty



    'тип блокировки
    Public Enum LockStyle
        NoLock = 0 'нет блокировки
        LockSession = 1 ' временная блокировка
        LockPermanent = 2 'постоянная блокировка
        ExternalLockSession = 3 'чужая временная блокировка
        ExternalLockPermanent = 4 'чужая постоянная блокировка
    End Enum



    Private mvarMap As LATIR2.NamedValues
    Private mTheDataSource As TheDataSource 'local copy
    Private mFinder As Finder
    Public SymbolAt As String
    Public FuncPrefix As String
    Public ProcPrefix As String
    Public KernelPrefix As String
    Private mSessionID As Guid


    Public ReadOnly Property ErrorMessage() As String
        Get
            Return _errorMessage
        End Get
    End Property

    Private mLangLoaded As Boolean = False

    Public Property Language() As String
        Get
            Dim objrs As DataTable
            If Not mLangLoaded Then
                objrs = GetData("select Lang from the_session where the_Sessionid=" + GetProvider.ID2Const(SessionID))
                If Not objrs Is Nothing Then
                    If objrs.Rows.Count > 0 Then
                        If objrs.Rows(0).Item("Lang").ToString <> "" Then
                            m_Language = objrs.Rows(0).Item("Lang").ToString
                        End If
                        m_Language = ""
                    End If
                    m_Language = ""
                End If
                mLangLoaded = True
            End If
            Return m_Language
        End Get
        Set(ByVal Value As String)
            If m_Language <> Value Then
                m_Language = Value
                Call GetData("update the_session set Lang='" + m_Language + "' where the_Sessionid=" + GetProvider.ID2Const(SessionID))
            End If
        End Set
    End Property

    Public Property XmlFile() As String
        Get
            If mXmlFile = "" Then
                mXmlFile = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) & "\latir_sites.xml"
            End If
            Return mXmlFile
        End Get
        Set(ByVal Value As String)

            mXmlFile = Value
        End Set
    End Property


    Public ReadOnly Property ProviderType() As DBProvider.DBProviderType
        Get
            Return mTheDataSource.Provider.ProviderType()
        End Get
    End Property


    Property SessionID() As Guid
        Get
            Return mSessionID
        End Get
        Set(ByVal Value As Guid)
            mSessionID = Value
        End Set
    End Property

    ' класс,реализующий доступ к базе даных
    Friend ReadOnly Property TheDataSource() As TheDataSource
        Get
            Return mTheDataSource
        End Get
    End Property


    Public ReadOnly Property TheFinder() As Finder
        Get
            If mFinder Is Nothing Then
                mFinder = New Finder
                mFinder.Application = Me
            End If
            Return mFinder
        End Get
    End Property


    Public ReadOnly Property Connected() As Boolean
        Get
            If (mTheDataSource.Connection.State = ConnectionState.Open) Then
                Return Not SessionID.Equals(System.Guid.Empty)
            Else
                Return False
            End If
        End Get
    End Property

    Friend ReadOnly Property MAP() As LATIR2.NamedValues
        Get
            Return mvarMap
        End Get
    End Property


    Public Property Site() As String
        Get
            Return msite
        End Get
        Set(ByVal Value As String)
            msite = Value
            Try
                Dim xdom As XmlDocument
                Dim I As Integer
                xdom = New XmlDocument
                'If (XmlFile <> String.Empty) Then
                xdom.Load(XmlFile)


                For I = 0 To xdom.LastChild.ChildNodes.Count - 1
                    If UCase(xdom.LastChild.ChildNodes.Item(I).Attributes.GetNamedItem("Name").Value) = UCase(Value) Then
                        With xdom.LastChild.ChildNodes.Item(I).Attributes
                            mServer = .GetNamedItem("Server").Value
                            mDataBaseName = .GetNamedItem("DB").Value
                            mUserName = .GetNamedItem("USER").Value
                            mPassword = .GetNamedItem("PASSWORD").Value
                            mLoginTimeOut = CShort(.GetNamedItem("TIMEOUT").Value)
                            mProvider = .GetNamedItem("PROVIDER").Value
                            SymbolAt = .GetNamedItem("AT").Value
                            Integrated = CBool(.GetNamedItem("INTEGRATED").Value)
                            FuncPrefix = .GetNamedItem("FUNC").Value
                            ProcPrefix = .GetNamedItem("PROC").Value
                            KernelPrefix = .GetNamedItem("KERNEL").Value
                        End With
                        Exit For
                    End If
                Next
                xdom = Nothing


                ServerLogIn()



                LoadMap()


            Catch
            End Try

        End Set
    End Property

    Private Function GetProviderByName(ByVal name As String) As LATIR2.DBProvider
        Select Case UCase(name)
            Case "SQLOLEDB"
                Return New LATIR2.SQLDBProvider
            Case "MSDAORA.1", "MSDAORA", "ORACLE"
                Return New LATIR2.ORADBProvider
            Case "MYSQL"
                Return New LATIR2.MYSQLDBProvider
            Case Else
                Return New LATIR2.DBProvider
        End Select
    End Function

    ' login to database and init DataSource object
    Private Function ServerLogIn() As Boolean
        Try
            Dim p As LATIR2.DBProvider
            p = GetProviderByName(mProvider)
            mConnectString = p.BuildCN(mServer, mDataBaseName, mUserName, mPassword, CStr(mLoginTimeOut), mProvider, Integrated)
            mTheDataSource = New TheDataSource(mConnectString, p, Me)
            Return Connected
        Catch ex As System.Exception
            _errorMessage = ex.Message
            Return Connected
        End Try
    End Function

    Public Function GetProvider() As LATIR2.DBProvider
        Try
            Dim p As LATIR2.DBProvider
            p = GetProviderByName(mProvider)
            Return p
        Catch
            Return Nothing
        End Try

    End Function

    Public Sub New()
        MyBase.New()

        Path = System.Reflection.Assembly.GetExecutingAssembly.Location & ".xml"

    End Sub


    Protected Overrides Sub Finalize()
        mvarMap = Nothing
        mTheDataSource = Nothing
        mFinder = Nothing
        MyBase.Finalize()
    End Sub

    Public Function Login(ByVal UID As String, ByVal PWD As String) As Boolean
        Dim cursession As Guid
        Try

            If Not (mTheDataSource.Connection.State = ConnectionState.Open) Then
                Throw New System.Exception("Set valid site name before login")

            End If
            Dim p As System.Data.Common.DbCommand


            p = TheDataSource.CreateCommand("login", True)

            TheDataSource.AddParameter(p, "The_Session", GetProvider.ID2DbType, System.DBNull.Value, ParameterDirection.Output, GetProvider.ID2Size)

            If PWD <> "" Then
                TheDataSource.AddParameter(p, "PWD", DbType.String, PWD)
            Else
                TheDataSource.AddParameter(p, "PWD", DbType.String, DBNull.Value)
            End If
            TheDataSource.AddParameter(p, "USR", DbType.String, UID)
            Try

                p.ExecuteNonQuery()
                cursession = New System.Guid(TheDataSource.GetParameter(p, "The_Session").Value.ToString())
                If Not cursession.Equals(System.Guid.Empty) Then
                    SessionID = cursession

                    Return True
                End If
            Catch ex As System.Exception

                Return False
            End Try


        Catch
            Return False
        End Try
    End Function

    Public Function IntegratedLogin() As Boolean
        Dim cursession As Guid
        Try

            If Not (mTheDataSource.Connection.State = ConnectionState.Open) Then
                Throw New System.Exception("Session.IntegratedLogin: Set valid site name befor IntegratedLogin")

            End If

            Dim p As LATIR2.NamedValues



            p = New LATIR2.NamedValues

            p.Add("the_session", System.DBNull.Value, GetProvider.ID2DbType, GetProvider.ID2Size, ParameterDirection.Output)

            p.Add("USR", "")
            p.Add("PWD", "INTEGRATED")

            TheDataSource.ExecuteProc("Login", p)


            cursession = New Guid(p.Item("the_session").Value.ToString)

            If Not cursession.Equals(System.Guid.Empty) Then
                SessionID = cursession
                Return True
            End If

        Catch
            Return False
        End Try
    End Function

    'Закрытие сесии
    'Parameters:
    ' параметров нет
    'Returns:
    ' Boolean, семантика результата:
    '   true  -удача
    '   false -ошибка
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as Boolean
    '  variable = me.Logout()
    Public Function Logout() As Boolean
        Try
            Dim p As LATIR2.NamedValues
            Dim ok As Boolean
            p = New LATIR2.NamedValues
            p.Add("CURSESSION", GetProvider.ID2Param(SessionID), GetProvider.ID2DbType, GetProvider.ID2Size, ParameterDirection.Input)
            ok = TheDataSource.ExecuteProc("logout", p)
            If ok Then
                mSessionID = Guid.Empty
            End If
            Return ok
        Catch
        End Try
        Return False
    End Function

    Private Sub LoadMap()
        Try
            Dim rs As DataTable
            Dim s, mn As String, i As Integer
            If GetProvider.ProviderType <> DBProvider.DBProviderType.ORACLE Then
                rs = TheDataSource.ExecuteReader("select name,value thevalue,optiontype from sysoptions order by optiontype,name")
            Else
                rs = TheDataSource.ExecuteReader("select name,thevalue,optiontype from sysoptions order by optiontype,name")
            End If
            
        
            mvarMap = New LATIR2.NamedValues
            If rs Is Nothing Then Exit Sub
            For i = 0 To rs.Rows.Count - 1
                'Try
                s = CStr(rs.Rows(i)("thevalue"))
                '        Catch ex As Exception
                '    s = CStr(rs.Rows(i)("value"))
                'End Try


                mn = rs.Rows(i)("optiontype").ToString.ToUpper & "." & rs.Rows(i)("Name").ToString.ToUpper
                Try
                    mvarMap.Add(mn, s.ToUpper)
                Catch
                End Try

            Next
            rs.Dispose()
            rs = Nothing
        Catch ex As System.Exception
        End Try
    End Sub

    Public Function GetIDsDT(ByVal Table As String, Optional ByVal ParentID As String = "", Optional ByVal ParentRowID As String = "", Optional ByVal Filter_Renamed As String = "") As DataTable
        Dim rs As DataTable
        Dim qry As String
        ParentID = ID2String(ParentID)
        ParentRowID = ID2String(ParentRowID)

        If ParentID <> "" Then
            If HasParent(Table) Then
                qry = "select " + GetProvider.ID2Base(Table + "id", "ID") + ", ChangeStamp, SecurityStyleID from " & Table & " where ParentStructRowID=" + GetProvider.ID2Const(New Guid(ParentID))

            Else
                qry = "select " + GetProvider.ID2Base(Table + "id", "ID") + ", ChangeStamp, SecurityStyleID from " & Table & " where InstanceID=" + GetProvider.ID2Const(New Guid(ParentID))
            End If

            If LCase(ParentRowID) = "null" Then
                qry = qry & " and (ParentrowID is null or ParentrowID= " + GetProvider.ID2Const(Guid.Empty) + ")"
            ElseIf ParentRowID <> "" Then
                qry = qry & " and ParentrowID=" + GetProvider.ID2Const(New Guid(ParentRowID))
            End If

            If Filter_Renamed <> "" Then
                rs = TheDataSource.ExecuteSQL(qry & " and ( " & Filter_Renamed & ")")
            Else
                rs = TheDataSource.ExecuteSQL(qry)
            End If
            If rs Is Nothing Then Return Nothing
            Return rs

        Else
            qry = "select " + GetProvider.ID2Base(Table + "id", "ID") + ", ChangeStamp from " & Table

            If LCase(ParentRowID) = "null" Then
                qry = qry & " where (ParentrowID is null or ParentrowID= " + GetProvider.ID2Const(Guid.Empty) + ")"
            ElseIf ParentRowID <> "" Then
                qry = qry & " where ParentrowID=" + GetProvider.ID2Const(New Guid(ParentRowID))
            Else
                qry = qry & " where 1=1 "
            End If
            If Filter_Renamed <> "" Then
                rs = TheDataSource.ExecuteSQL(qry & " and ( " & Filter_Renamed & ")")
            Else
                rs = TheDataSource.ExecuteSQL(qry)
            End If
            If rs Is Nothing Then Return Nothing

            Return rs

        End If

    End Function

    Public Function GetRow(ByVal Table As String, ByVal FieldList As String, ByVal RowID As Guid) As DataTable
        If Not Connected Then
            Return Nothing
        End If
        Dim rs As DataTable

        rs = TheDataSource.ExecuteReader("select " + FieldList + " from " & Table & " where " & Table & "id=" + GetProvider.ID2Const(RowID))

        Return rs
   

    End Function

    Public Function GetRowDT(ByVal Table As String, ByVal RowID As Guid) As DataTable
        If Not Connected Then
            Return Nothing
        End If

        Dim rs As DataTable
        rs = TheDataSource.ExecuteSQL("select * from " & Table & " where " & Table & "id=" & GUID2String(Me, RowID) & "")
        Return rs

    End Function

    Public Function GetView(ByVal View As String, Optional ByVal Filter_Renamed As String = "", Optional ByVal SortEx As String = "") As DataTable
        Dim dc As System.Data.Common.DbCommand
        Dim QRY As String
        QRY = "select * from v_" & View & " "
        If Filter_Renamed <> "" Then
            QRY = QRY & "WHERE ( " & Filter_Renamed & ")"
        End If
        If SortEx <> "" Then
            QRY = QRY & " order by " & SortEx
        End If
        dc = TheDataSource.CreateCommand(QRY)
        Return TheDataSource.CreateDataTable(dc)
    End Function



    Public Function GetRows(ByVal Table As String, ByVal FieldList As String, Optional ByVal ParentID As String = "", Optional ByVal ParentRowID As String = "", Optional ByVal Filter_Renamed As String = "") As DataTable
        If Not Connected Then
            Return Nothing
        End If

        ParentID = ID2String(ParentID)
        ParentRowID = ID2String(ParentRowID)
        Dim rs As DataTable
        Dim qry As String

        If ParentID <> "" Then
            If HasParent(Table) Then
                qry = "select " & FieldList & " from " & Table & " where ParentStructRowID=" + GetProvider.ID2Const(New Guid(ParentID))
            Else
                qry = "select " & FieldList & " from " & Table & " where InstanceID=" + GetProvider.ID2Const(New Guid(ParentID))
            End If


            If LCase(ParentRowID) = "null" Then
                qry = qry & " and (ParentrowID is null or ParentrowID= " + GetProvider.ID2Const(Guid.Empty) + ")"

            ElseIf ParentRowID <> "" Then
                qry = qry & " and ParentrowID=" + GetProvider.ID2Const(New Guid(ParentRowID))
            End If
            If Filter_Renamed <> "" Then
                rs = TheDataSource.ExecuteReader(qry & " and ( " & Filter_Renamed & ")")
            Else
                rs = TheDataSource.ExecuteReader(qry)
            End If
            Return rs
        Else
            qry = "select " & FieldList & "  from " & Table

            If LCase(ParentRowID) = "null" Then
                qry = qry & " where (ParentrowID is null or ParentrowID= " + GetProvider.ID2Const(Guid.Empty) + ")"
            ElseIf ParentRowID <> "" Then
                qry = qry & " where ParentrowID=" + GetProvider.ID2Const(New Guid(ParentRowID))
            Else
                If Filter_Renamed <> "" Then qry = qry & " where 1=1 "
            End If
            If Filter_Renamed <> "" Then
                rs = TheDataSource.ExecuteReader(qry & " and ( " & Filter_Renamed & ")")
            Else
                rs = TheDataSource.ExecuteReader(qry)
            End If
            Return rs
        End If
    End Function

    Public Function GetRowsDT(ByVal Table As String, ByVal FieldList As String, Optional ByVal ParentID As String = "", Optional ByVal ParentRowID As String = "", Optional ByVal Filter_Renamed As String = "") As DataTable
        If Not Connected Then
            Return Nothing
        End If

        ParentRowID = ID2String(ParentRowID)
        ParentID = ID2String(ParentID)
        Dim rs As DataTable
        Dim qry As String

        If ParentID <> "" Then

            If HasParent(Table) Then
                qry = "select " & FieldList & " from " & Table & " where ParentStructRowID=" + GetProvider.ID2Const(New Guid(ParentID))
            Else
                qry = "select " & FieldList & " from " & Table & " where InstanceID=" + GetProvider.ID2Const(New Guid(ParentID))
            End If


            If LCase(ParentRowID) = "null" Then
                qry = qry & " and (ParentrowID is null or ParentrowID= " + GetProvider.ID2Const(Guid.Empty) + ")"

            ElseIf ParentRowID <> "" Then
                qry = qry & " and ParentrowID=" + GetProvider.ID2Const(New Guid(ParentRowID))
            End If
            If Filter_Renamed <> "" Then
                rs = TheDataSource.ExecuteSQL(qry & " and ( " & Filter_Renamed & ")")
            Else
                rs = TheDataSource.ExecuteSQL(qry)
            End If
            Return rs
        Else
            qry = "select " & FieldList & " from " & Table

            If LCase(ParentRowID) = "null" Then
                qry = qry & " where   (ParentrowID is null or ParentrowID= " + GetProvider.ID2Const(Guid.Empty) + ")"
            ElseIf ParentRowID <> "" Then
                qry = qry & " where ParentrowID=" + GetProvider.ID2Const(New Guid(ParentRowID))
            Else
                If Filter_Renamed <> "" Then qry = qry & " where 1=1 "
            End If
            If Filter_Renamed <> "" Then
                rs = TheDataSource.ExecuteSQL(qry & " and ( " & Filter_Renamed & ")")
            Else
                rs = TheDataSource.ExecuteSQL(qry)
            End If
           Return rs
        End If
    End Function


    Public Function GetRowsEx(ByVal Table As String, ByVal fieldlist As String, Optional ByVal ParentID As String = "", Optional ByVal ParentRowID As String = "", Optional ByVal Filter_Renamed As String = "", Optional ByVal SortOrder As String = "") As DataTable
        Dim rs As DataTable
        Dim qry As String
        If Not Connected Then
            Return Nothing
        End If

        ParentRowID = ID2String(ParentRowID)
        ParentID = ID2String(ParentID)

        If ParentID <> "" Then
            If HasParent(Table) Then
                qry = "select " & fieldlist & " from " & Table & " where ParentStructRowID=" + GetProvider.ID2Const(New Guid(ParentID))

            Else
                qry = "select " & fieldlist & " from " & Table & " where InstanceID=" + GetProvider.ID2Const(New Guid(ParentID))
            End If


            If LCase(ParentRowID) = "null" Then
                qry = qry & " and   (ParentrowID is null or ParentrowID= " + GetProvider.ID2Const(Guid.Empty) + ")"
            ElseIf ParentRowID <> "" Then
                qry = qry & " and ParentrowID=" + GetProvider.ID2Const(New Guid(ParentRowID.ToString))
            End If
            If Filter_Renamed <> "" Then
                rs = TheDataSource.ExecuteReader(qry & " and ( " & Filter_Renamed & ")" & " " & SortOrder)
            Else
                rs = TheDataSource.ExecuteReader(qry & " " & SortOrder)
            End If
            Return rs
        Else
            qry = "select " & fieldlist & " from " & Table
            If LCase(ParentRowID) = "null" Then
                qry = qry & " where (ParentrowID is null or ParentrowID= " + GetProvider.ID2Const(Guid.Empty) + ")"
            ElseIf ParentRowID <> "" Then
                qry = qry & " where ParentrowID=" + GetProvider.ID2Const(New Guid(ParentRowID.ToString))
            Else
                If Filter_Renamed <> "" Then qry = qry & " where 1=1 "
            End If
            If Filter_Renamed <> "" Then
                rs = TheDataSource.ExecuteReader(qry & " and ( " & Filter_Renamed & ")" & " " & SortOrder)
            Else
                rs = TheDataSource.ExecuteReader(qry & " " & SortOrder)
            End If
            Return rs
        End If
    End Function

    Public Function GetRowsExDT(ByVal Table As String, ByVal FieldList As String, Optional ByVal ParentID As String = "", Optional ByVal ParentRowID As String = "", Optional ByVal Filter_Renamed As String = "", Optional ByVal SortOrder As String = "") As DataTable
        Dim rs As DataTable
        Dim qry As String
        If Not Connected Then
            Return Nothing
        End If

        ParentRowID = ID2String(ParentRowID)
        ParentID = ID2String(ParentID)

        If ParentID <> "" Then
            If HasParent(Table) Then
                qry = "select " & FieldList & " from " & Table & " where ParentStructRowID=" + GetProvider.ID2Const(New Guid(ParentID))

            Else
                qry = "select " & FieldList & " from " & Table & " where InstanceID=" + GetProvider.ID2Const(New Guid(ParentID))
            End If


            If LCase(ParentRowID) = "null" Then
                qry = qry & " and (ParentrowID is null or ParentrowID= " + GetProvider.ID2Const(Guid.Empty) + ")"

            ElseIf ParentRowID <> "" Then

                qry = qry & " and ParentrowID=" + GetProvider.ID2Const(New Guid(ParentRowID.ToString))
            End If
            If Filter_Renamed <> "" Then
                rs = TheDataSource.ExecuteSQL(qry & " and ( " & Filter_Renamed & ")" & " " & SortOrder)
            Else
                rs = TheDataSource.ExecuteSQL(qry & " " & SortOrder)
            End If
            Return rs
        Else
            qry = "select " & FieldList & " from " & Table
            If LCase(ParentRowID) = "null" Then
                qry = qry & " where (ParentrowID is null or ParentrowID= " + GetProvider.ID2Const(Guid.Empty) + ")"
            ElseIf ParentRowID <> "" Then
                qry = qry & " where ParentrowID=" + GetProvider.ID2Const(New Guid(ParentRowID.ToString))
            Else
                If Filter_Renamed <> "" Then qry = qry & " where 1=1 "
            End If
            If Filter_Renamed <> "" Then
                rs = TheDataSource.ExecuteSQL(qry & " and ( " & Filter_Renamed & ")" & " " & SortOrder)
            Else
                rs = TheDataSource.ExecuteSQL(qry & " " & SortOrder)
            End If
            Return rs
        End If
    End Function


    Public Function DeleteRow(ByVal Table As String, ByVal RowID As Guid) As Boolean
        If Not Connected Then
            Return Nothing
        End If
        Dim nv As LATIR2.NamedValues
        nv = New LATIR2.NamedValues
        nv.Add(Table & "id", GetProvider.ID2Param(RowID), GetProvider.ID2DbType(), GetProvider.ID2Size())

        Dim realname As String
        If UCase(Table) = "INSTANCE" Then
            realname = Replace(KernelPrefix & Table, "%Type%", "")
            Return TheDataSource.ExecuteProc(realname & "_DELETE", nv)
        Else
            realname = Replace(ProcPrefix & Table, "%Type%", TableToType(Table))
            Return TheDataSource.ExecuteProc(realname & "_DELETE", nv)
        End If
    End Function

    Public Function DeleteRow2(ByVal Table As String, ByVal RowID As Guid, ByVal InstanceID As System.Guid) As Boolean
        If Not Connected Then
            Return Nothing
        End If
        Dim nv As LATIR2.NamedValues
        nv = New LATIR2.NamedValues

        nv.Add("CURSESSION", GetProvider.ID2Param(SessionID), GetProvider.ID2DbType(), GetProvider.ID2Size())


        nv.Add(Table & "id", GetProvider.ID2Param(RowID), GetProvider.ID2DbType(), GetProvider.ID2Size())
        nv.Add("INSTANCEID", GetProvider.ID2Param(InstanceID), GetProvider.ID2DbType(), GetProvider.ID2Size())

        Dim realname As String
        If UCase(Table) = "INSTANCE" Then
            realname = Replace(KernelPrefix & Table, "%Type%", "")
            Return TheDataSource.ExecuteProc(realname & "_DELETE", nv)
        Else
            realname = Replace(ProcPrefix & Table, "%Type%", TableToType(Table), , , vbTextCompare)
            Return TheDataSource.ExecuteProc(realname & "_DELETE", nv)
        End If
    End Function
    'Сохранить строку
    'Parameters:
    '[IN]   Table , тип параметра: String - раздел,
    '[IN]   RowID , тип параметра: String - идентификатор строки,
    '[IN]   ParentID , тип параметра: String - родительская строка (существенна пока только для добавления),
    '[IN]   Values , тип параметра: LATIR2.NamedValues  - коллекция значений полей
    'Returns:
    ' Boolean, семантика результата:
    '   true  -сохранено
    '   false -ошибка
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as Boolean
    ' variable = me.SaveRow(<параметры>)
    Public Function SaveRow(ByVal Table As String, ByVal RowID As Guid, ByVal ParentID As Guid, ByVal Values As LATIR2.NamedValues) As Boolean
        Dim nv As LATIR2.NamedValues
        Dim I As Integer
        nv = New LATIR2.NamedValues




        nv.Add("CURSESSION", GetProvider.ID2Param(SessionID), GetProvider.ID2DbType(), GetProvider.ID2Size())



        nv.Add(UCase(Table) & "ID", GetProvider.ID2Param(RowID), GetProvider.ID2DbType(), GetProvider.ID2Size())

        Dim mm As Object
        mm = MAP.Item("PARENT." & Table)

        If mm Is Nothing Then
            nv.Add("INSTANCEID", GetProvider.ID2Param(ParentID), GetProvider.ID2DbType(), GetProvider.ID2Size())
        Else
            nv.Add("PARENTSTRUCTROWID", GetProvider.ID2Param(ParentID), GetProvider.ID2DbType(), GetProvider.ID2Size())
        End If

        For I = 1 To Values.Count
            nv.Add(UCase(Values.Item(I).TheName), Values.Item(I).Value, Values.Item(I).DataType, Values.Item(I).Size)
        Next



        Dim realname As String
        If UCase(Table) = "INSTANCE" Then
            realname = Replace(KernelPrefix & Table, "%Type%", "")
            Return TheDataSource.ExecuteProc(realname & "_save", nv)
        Else
            realname = Replace(ProcPrefix & Table, "%Type%", TableToType(Table))
            Return TheDataSource.ExecuteProc(realname & "_save", nv)
        End If

    End Function


    Public Function SaveRow2(ByVal Table As String, ByVal RowID As Guid, ByVal ParentID As Guid, ByVal Values As LATIR2.NamedValues, ByVal InstanceID As System.Guid) As Boolean
        Dim nv As LATIR2.NamedValues
        Dim I As Integer
        nv = New LATIR2.NamedValues




        nv.Add("CURSESSION", GetProvider.ID2Param(SessionID), GetProvider.ID2DbType(), GetProvider.ID2Size())




        nv.Add(UCase(Table) & "ID", GetProvider.ID2Param(RowID), GetProvider.ID2DbType(), GetProvider.ID2Size())

        Dim mm As Object
        mm = MAP.Item("PARENT." & Table)
        nv.Add("INSTANCEID", GetProvider.ID2Param(InstanceID), GetProvider.ID2DbType(), GetProvider.ID2Size())
        If Not mm Is Nothing Then
            nv.Add("PARENTSTRUCTROWID", GetProvider.ID2Param(ParentID), GetProvider.ID2DbType(), GetProvider.ID2Size())
        End If

        For I = 1 To Values.Count
            nv.Add(UCase(Values.Item(I).TheName), Values.Item(I).Value, Values.Item(I).DataType)
        Next


        Dim realname As String
        If UCase(Table) = "INSTANCE" Then
            realname = Replace(KernelPrefix & Table, "%Type%", "", , , vbTextCompare)
        Else
            realname = Replace(ProcPrefix & Table, "%Type%", TableToType(Table), , , vbTextCompare)

        End If
        Return TheDataSource.ExecuteProc(realname & "_save", nv)
        nv = Nothing
    End Function

    'Исполнить метод
    'Parameters:
    '[IN]   Method , тип параметра: String - имя метода,
    '[IN]   Values , тип параметра: LATIR2.NamedValues  - список значений параметров
    'Returns:
    ' Boolean, семантика результата:
    '   true  -удача
    '   false -ошибка
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as Boolean
    ' variable = me.Exec(<параметры>)
    Public Function Exec(ByVal Method As String, ByVal Values As LATIR2.NamedValues) As Boolean

        Return TheDataSource.ExecuteProc(Method, Values)

    End Function

    'Является ли раздел разделом первого уровня
    'Parameters:
    '[IN]   Table , тип параметра: String  - имя раздела
    'Returns:
    ' Boolean, семантика результата:
    '   true  - не является
    '   false - является
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as Boolean
    ' variable = me.HasParent(<параметры>)
    Public Function HasParent(ByVal Table As String) As Boolean
        Try
            If MAP.Item("PARENT." & Table) Is Nothing Then
                Return False
            Else
                Return True
            End If
        Catch
            Return False
        End Try

    End Function

    'Создать объект
    'Parameters:
    '[IN]   InstanceID , тип параметра: String - идентификатор,
    '[IN]   ObjType , тип параметра: String - тип объекта,
    '[IN]   Name , тип параметра: String  - название
    'Returns:
    ' Boolean, семантика результата:
    '   true  - создан
    '   false - ошибка
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as Boolean
    ' variable = me.NewInstance(<параметры>)
    Public Function NewInstance(ByVal InstanceID As Guid, ByVal ObjType As String, ByVal Name As String) As Boolean
        Dim nv As LATIR2.NamedValues
        nv = New LATIR2.NamedValues
        nv.Add("CURSESSION", GetProvider.ID2Param(SessionID), GetProvider.ID2DbType(), GetProvider.ID2Size())
        nv.Add("InstanceID", GetProvider.ID2Param(InstanceID), GetProvider.ID2DbType(), GetProvider.ID2Size())
        nv.Add("ObjType", ObjType, DbType.String)
        nv.Add("Name", Name, DbType.String)
        Return TheDataSource.ExecuteProc(KernelPrefix & "Instance_SAVE", nv)
        nv = Nothing
    End Function

    'Удалить объект
    'Parameters:
    '[IN]   InstanceID , тип параметра: String  - идентификатор
    'Returns:
    ' Boolean, семантика результата:
    '   true  - удален
    '   false -ошибка
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as Boolean
    ' variable = me.DeleteInstance(<параметры>)
    Public Function DeleteInstance(ByVal InstanceID As Guid) As Boolean
        Dim nv As LATIR2.NamedValues
        nv = New LATIR2.NamedValues

        nv.Add("CURSESSION", GetProvider.ID2Param(SessionID), GetProvider.ID2DbType(), GetProvider.ID2Size())

        nv.Add("InstanceID", GetProvider.ID2Param(InstanceID), GetProvider.ID2DbType(), GetProvider.ID2Size())
        Try
            Return TheDataSource.ExecuteProc(KernelPrefix & "Instance_DELETE", nv)


        Catch
        End Try

        nv = Nothing
        Return False
    End Function


    Public Function GetData(ByVal Qry As String) As DataTable
        If Not Connected Then
            Return Nothing
        End If
        Dim rs As DataTable
        rs = TheDataSource.ExecuteSQL(Qry)
        If rs Is Nothing Then Return Nothing
        Return rs
    End Function

    'Получить краткое название
    'Parameters:
    '[IN]   Table,, тип параметра: Variant - таблица
    '[IN]   RowID , тип параметра: String - идентификатор строки,
    '[IN][OUT]   Brief , тип параметра: String  - результат
    'Returns:
    ' Boolean, семантика результата:
    '   true  -удача
    '   false -ошибка
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as Boolean
    ' variable = me.GetBrief(<параметры>)
    Public Function GetBrief(ByVal Table As String, ByVal RowID As Guid, ByRef Brief As String) As Boolean

        Dim nv As LATIR2.NamedValues
        'PMOD
        Brief = ""
        nv = New LATIR2.NamedValues
        Dim nvi As LATIR2.NamedValue


        nvi = nv.Add("CURSESSION", GetProvider.ID2Param(SessionID), GetProvider.ID2DbType(), GetProvider.ID2Size())


        Try

            nvi = nv.Add(UCase(Table) & "ID", GetProvider.ID2Param(RowID), GetProvider.ID2DbType(), GetProvider.ID2Size())

            nvi = nv.Add("BRIEF", Brief, DbType.String, 255, ParameterDirection.Output)



            Dim realname As String
            If UCase(Table) = "INSTANCE" Then
                realname = Replace(KernelPrefix & Table, "%Type%", "", , , vbTextCompare)
            Else
                realname = Replace(ProcPrefix & Table, "%Type%", TableToType(Table), , , vbTextCompare)
            End If
            Dim ok As Boolean
            ok = TheDataSource.ExecuteProc(realname & "_BRIEF", nv)

            Brief = nvi.Value.ToString

            nv = Nothing
            Return ok
        Catch ex As System.Exception
            Brief = ex.Message
        End Try
        Return False
    End Function

    'Проверить права на действие
    'Parameters:
    '[IN]   Resource , тип параметра: String - идентификатор стиля защиты,
    '[IN]   Verb , тип параметра: String  - действие
    'Returns:
    ' Boolean, семантика результата:
    '   true  -разрешено
    '   false -запрещено
    'See Also:
    '  Application
    '  CheckConnection
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as Boolean
    ' variable = me.CheckRight(<параметры>)
    Public Function CheckRight(ByVal Resource As String, ByVal Verb As String) As Boolean
        Dim p As LATIR2.NamedValues
        p = New LATIR2.NamedValues
        Dim access As Short

        p.Add("resource", Resource, DbType.String)
        p.Add("verb", Verb, DbType.String)
        p.Add("access", access, DbType.Int16)

        If TheDataSource.ExecuteProc("CheckVerbRight", p) Then
            Return CBool(CInt(p.Item("access").Value) <> 0)
        End If
        Return False
    End Function

    'Проверить потенциальную зависимость разделов
    'Parameters:
    '[IN]   ChildStructID , тип параметра: String - раздел который проверяем,
    '[IN]   CheckID , тип параметра: String  - с чем сравниваем
    'Returns:
    ' Boolean, семантика результата:
    '   true  - зависимый раздел
    '   false - нет зависимости
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as Boolean
    ' variable = me.IsDescendant(<параметры>)
    Public Function IsDescendant(ByVal ChildStructID As String, ByVal CheckID As String) As Boolean
        Dim tmp As String
        Try
            tmp = ChildStructID.ToUpper
            While tmp <> ""
                If CheckID.ToUpper = tmp.ToUpper Then
                    Return True

                End If
                If MAP.Item("PARENT." & tmp.ToUpper) Is Nothing Then
                    tmp = ""
                Else
                    tmp = CStr(MAP.Item("PARENT." & tmp.ToUpper).Value).ToUpper
                End If
            End While
            Return False
        Catch
            Return False
        End Try
    End Function

    'Проверка существования строки
    'Parameters:
    '[IN]   Table , тип параметра: String - раздел,
    '[IN]   RowID , тип параметра: String  - идентификатор строки
    'Returns:
    ' Boolean, семантика результата:
    '   true  - существует
    '   false - нет
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as Boolean
    ' variable = me.IsRowExists(<параметры>)
    Public Function IsRowExists(ByVal Table As String, ByVal RowID As Guid) As Boolean
        Dim rs As DataTable

        rs = TheDataSource.ExecuteReader("select 1 from " & Table & " where " & Table & "ID=" & GUID2String(Me, RowID) & "")
        If rs Is Nothing Then Return False
        If rs.Rows.Count = 0 Then Return False
        rs.Dispose()

        rs = Nothing
        Return (True)
      
    End Function

    'Получить имя типа по разделу
    'Parameters:
    '[IN]   Table , тип параметра: String  - имя раздела
    'Returns:
    '  значение типа String - имя типа
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TheFinder
    'Example:
    ' dim variable as String
    ' variable = me.TableToType(<параметры>)
    Public Function TableToType(ByVal Table As String) As String
        Dim s As String
        Try
            'UPGRADE_WARNING: Couldn't resolve default property of object MAP.Item().Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            s = CStr(MAP.Item("STRUCT_TYPE." & Table).Value)
            Return s
        Catch
            Return ""
        End Try

    End Function

    'Получить идентификатор текущего пользователя
    'Parameters:
    ' параметров нет
    'Returns:
    '  значение типа String
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetDefaultSecurityStyle
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    ' dim variable as String
    '  variable = me.GetSessionUserID()
    Public Function GetSessionUserID() As Guid
        Dim rs As DataTable

        If Not SessionID.Equals(System.Guid.Empty) Then
            rs = TheDataSource.ExecuteReader("select UsersID from The_Session where closed =0 and The_sessionID=" & GUID2String(Me, SessionID) & "")
            If rs Is Nothing Then Return System.Guid.Empty
            If rs.Rows.Count = 0 Then Return System.Guid.Empty
            Return New Guid(rs.Rows(0)("usersid").ToString)
   
        End If
        Return Guid.Empty
    End Function

    'Установить умолчательные права для типа
    'Parameters:
    '[IN]   TypeName , тип параметра: String - тип объекта,
    '[IN]   SecurityStyleid , тип параметра: String  - идентификатор стиля защиты
    'See Also:
    '  Application
    '  CheckConnection
    '  CheckRight
    '  Dispose
    '  Connected
    '  DeleteInstance
    '  DeleteRow
    '  Exec
    '  GetBrief
    '  GetIDs
    '  GetRow
    '  GetRows
    '  GetSessionUserID
    '  HasParent
    '  IntegratedLogin
    '  IsDescendant
    '  IsRowExists
    '  Logger
    '  Login
    '  Logout
    '  NewInstance
    '  Parent
    '  SaveRow
    '  sessionid
    '  SetOwner
    '  Site
    '  SymbolAt
    '  TableToType
    '  TheFinder
    'Example:
    '  call me.SetDefaultSecurityStyle(<параметры>)
    'UPGRADE_NOTE: TypeName was upgraded to TypeName_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Public Sub SetDefaultSecurityStyle(ByVal TypeName_Renamed As String, ByVal SecurityStyleid As String)
        Dim rs As DataTable
        Dim oldStyle As String
        Try
            If Not SessionID.Equals(System.Guid.Empty) Then

                rs = TheDataSource.ExecuteReader("select SecurityStyleID from typelist where name ='" & TypeName_Renamed & "'")
                If rs Is Nothing Then Exit Sub
                If rs.Rows.Count = 0 Then Exit Sub
                oldStyle = rs.Rows(0)("SecurityStyleid").ToString & ""
                rs.Dispose()
                rs = Nothing
                If CheckRight(oldStyle, "DEFAULT") Then
                    If SecurityStyleid = "" Then
                        TheDataSource.Execute("update typelist set SecurityStyleID = null  where name ='" & TypeName_Renamed & "'")
                    Else
                        TheDataSource.Execute("update typelist set SecurityStyleID ='" & SecurityStyleid & "'  where name ='" & TypeName_Renamed & "'")
                    End If
                Else
                    Throw New System.Exception("Нет прав на назначение стиля защиты для типа '" & TypeName_Renamed & "'")
                End If
            End If
            Exit Sub
        Catch ex As System.Exception
            Throw ex
        End Try
    End Sub

    Public Function SetOwner(ByVal InstanceID As Guid, ByVal OwnerTable As String, ByVal OwnerRowID As Guid) As Boolean
        Dim nv As LATIR2.NamedValues
        nv = New LATIR2.NamedValues


        nv.Add("CURSESSION", GetProvider.ID2Param(SessionID), GetProvider.ID2DbType(), GetProvider.ID2Size())


        nv.Add("instanceid", GetProvider.ID2Param(InstanceID), GetProvider.ID2DbType(), GetProvider.ID2Size())
        nv.Add("OwnerPartName", OwnerTable, DbType.String)
        nv.Add("OwnerRowID", GetProvider.ID2Param(OwnerRowID), GetProvider.ID2DbType(), GetProvider.ID2Size())
        Return TheDataSource.ExecuteProc(KernelPrefix & "INSTANCE_OWNER", nv)
    End Function

    Public Function GetServerTime() As Date
        Try
            Dim nv As LATIR2.NamedValues
            Dim nvi As LATIR2.NamedValue
            Dim dd As Date
            dd = System.DateTime.Now
            nv = New LATIR2.NamedValues
            nvi = nv.Add("ServerTime", dd, DbType.DateTime, ParameterDirection.Output)
            nvi.Size = 20


            If TheDataSource.ExecuteProcNoSession("GetServerTime", nv) Then
                dd = CDate(nv.Item("ServerTime").Value)
            Else
                dd = Now
            End If
            Return dd
        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

    Public Function GetPartViewAlias(ByVal TableName As String) As String
        Try
            Dim s As String = Nothing
            If (Not MAP.Item("DEFVIEW." & TableName) Is Nothing) Then
                s = CStr(MAP.Item("DEFVIEW." & TableName).Value)
            End If
            Return s

        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

    Public Function GetTypeViewAlias(ByVal TypeName As String) As String
        Try
            Dim s As String = Nothing
            If (Not MAP.Item("TDEFVIEW." & TypeName) Is Nothing) Then
                s = CStr(MAP.Item("TDEFVIEW." & TypeName).Value)
            End If
            Return s
        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

    Public Function SaveFileFromField(ByVal filepath As String, ByVal table As String, ByVal field As String, ByVal RowID As Guid) As Long
        Dim fs As FileStream                 ' Writes the BLOB to a file (*.bmp).
        Dim bw As BinaryWriter               ' Streams the binary data to the FileStream object.
        Dim bufferSize As Integer = 32000      ' The size of the BLOB buffer.
        Dim outbyte(bufferSize - 1) As Byte  ' The BLOB byte() buffer to be filled by GetBytes.
        Dim retval As Long                 ' The bytes returned from GetBytes.
        Dim startIndex As Long = 0           ' The starting position in the BLOB output.
        Dim cmd As System.Data.Common.DbCommand

        cmd = TheDataSource.CreateCommand("select " & field & " from " & table & " where " & table & "id='" & RowID.ToString() & "'")
        Dim myReader As System.Data.SqlClient.SqlDataReader = Nothing
        Try
            fs = New FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite)
        Catch
            Return 0
        End Try
        Try
            myReader = CType(cmd.ExecuteReader(CommandBehavior.SequentialAccess), SqlClient.SqlDataReader)
            Do While myReader.Read()

                bw = New BinaryWriter(fs)
                startIndex = 0
                retval = myReader.GetBytes(0, startIndex, outbyte, 0, bufferSize)
                Do While retval = bufferSize
                    bw.Write(outbyte)
                    bw.Flush()
                    startIndex += bufferSize
                    Try
                        retval = myReader.GetBytes(0, startIndex, outbyte, 0, bufferSize)
                    Catch ex As Exception
                        retval = 0
                    End Try
                Loop
                'bw.Write(outbyte, 0, retval - 1)
                bw.Write(outbyte, 0, CInt(retval))
                bw.Flush()
                bw.Close()
            Loop
        Catch

        Finally
            If (Not myReader Is Nothing) Then
                myReader.Dispose()
            End If
            If (Not cmd Is Nothing) Then
                cmd.Dispose()
            End If
        End Try

        Try
            fs.Close()
        Catch
        End Try
        Return retval
    End Function



   

    Public Sub LoadFileToField(ByVal filepath As String, ByVal table As String, ByVal field As String, ByVal RowID As Guid)


        If filepath <> "" Then
            Dim file As IO.FileStream
            Try
                Dim strSQL As String = _
                        "UPDATE " + table + " SET " + field + " = @Data WHERE " + table + "ID = @ID"
                Dim cmd As System.Data.Common.DbCommand
                cmd = TheDataSource.CreateCommand(strSQL)
                Dim aBytes() As Byte
                'cmd.Parameters("@ID").Value = RowID
                file = New IO.FileStream(filepath, IO.FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                ReDim aBytes(CInt(file.Length))
                file.Read(aBytes, 0, CInt(file.Length))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Data", SqlDbType.Image, CInt(file.Length)))
                cmd.Parameters("@Data").Value = aBytes
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ID", RowID))
                cmd.ExecuteNonQuery()
                file.Close()
            Catch ex As Exception
            Finally
            End Try
        Else
            Dim strSQL As String = _
                        "UPDATE " + table + " SET " + field + " = null WHERE " + table + "ID = @ID"
            Dim cmd As System.Data.Common.DbCommand
            cmd = TheDataSource.CreateCommand(strSQL)
            cmd.Parameters.Add(New SqlClient.SqlParameter("@ID", RowID))
            cmd.ExecuteNonQuery()
        End If

    End Sub


    Public Function GetProcName(ByVal Table As String) As String
        If UCase(Table) = "INSTANCE" Then
            Return Replace(KernelPrefix & Table, "%Type%", "", , , vbTextCompare)
        Else
            Return Replace(ProcPrefix & Table, "%Type%", TableToType(Table), , , vbTextCompare)
        End If
    End Function

    Public Function GetFuncName(ByVal Table As String) As String
        Return Replace(FuncPrefix & Table, "%Type%", TableToType(Table), , , vbTextCompare)
    End Function

    'PMOD
    Public Sub EraseLostNumbers()


        Dim nvs As NamedValues

        nvs = New NamedValues

        Try
            Call TheDataSource.ExecuteProc("ClearNumerators", nvs)
            Exit Sub
        Catch ex As System.Exception
            Throw ex
        End Try
    End Sub

#Region "NumSupport"
    Public Function ChangeNumber(ByVal Item As Document.DocRow_Base, ByRef NumField As String, ByVal NumeratorID As Guid, ByVal zoneTemplate As String, ByVal oldDate As Date, Optional ByVal oldORG As String = "", Optional ByRef newDate As Date = #12:00:00 AM#, Optional ByRef newOrg As String = "") As Object
        If FreeNumValue(Item, NumField, NumeratorID, zoneTemplate, oldDate, oldORG) Then
            Return GetNumValue(Item, NumField, NumeratorID, CDate(zoneTemplate), CStr(newDate), newOrg)
        End If
        Return False
    End Function

    Public Function FreeNumValue(ByVal Item As Document.DocRow_Base, ByRef NumField As String, ByVal NumeratorID As Guid, ByVal zoneTemplate As String, ByVal oldDate As Date, Optional ByVal oldORG As String = "") As Boolean
        Dim oldval As Double

        If Item Is Nothing Then Return False
        Try

            oldval = CDbl(CallByName(Item, NumField, CallType.Get))

            Dim nvs As NamedValues
            Dim n As Integer
            Dim prf As String
            Dim nvi As NamedValue
            If oldval > 0 Then
                nvs = New NamedValues
                nvi = nvs.Add("NumeratorID", GetProvider.ID2Param(NumeratorID), GetProvider.ID2DbType(), GetProvider.ID2Size())
                'nvi.ORACLE_GUID()
                prf = MakeItemNumString(Item, oldDate, zoneTemplate, oldORG)
                nvs.Add("the_Zone", prf)

                n = CInt(oldval)
                nvi = nvs.Add("num", n)
                nvi.DataType = DbType.Int32

                Call TheDataSource.ExecuteProcNoSession("EraseNumber", nvs)
                CallByName(Item, NumField, CallType.Let, 0)
                Item.Save()
            End If
            Return True
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    Public Function GetNumValue(ByRef Item As Document.DocRow_Base, ByVal NumField As String, ByVal NumeratorID As Guid, ByVal newDate As Date, ByVal zonetmplate As String, ByVal newOrg As String) As Object


        If Item Is Nothing Then
            Return False
        End If


        Dim nvs As NamedValues
        Dim n As Integer
        Dim prf As String

        nvs = New NamedValues
        Dim nvi As NamedValue
        prf = MakeItemNumString(Item, newDate, zonetmplate, newOrg)
        nvs.Add("the_Zone", prf)

        nvi = nvs.Add("NumeratorID", GetProvider.ID2Param(NumeratorID), GetProvider.ID2DbType(), GetProvider.ID2Size)

        n = 0
        nvi = nvs.Add("num", n)
        nvi.Direction = ParameterDirection.Output
        nvi.DataType = DbType.Int32
        nvi = nvs.Add("OwnerPartName", Item.PartName)

        nvi = nvs.Add("OwnerRowID", GetProvider.ID2Param(Item.ID), GetProvider.ID2DbType(), GetProvider.ID2Size)




        Try
            Call TheDataSource.ExecuteProcNoSession("GetFreeNumber", nvs)
            CallByName(Item, NumField, CallType.Let, nvs.Item("num").Value)
            Item.Save()

            Return True

        Catch ex As System.Exception
            Try
                Item.Application.Session.EraseLostNumbers()
            Catch ex1 As Exception

            End Try
            Return False
        End Try
    End Function

    Public Function MakeItemNumString(ByVal Item As Document.DocRow_Base, ByVal d As Date, ByVal template As String, ByVal org As String) As String
        Dim s As String
        Try
            s = MakeNumString(d, template, org)
            s = Replace(s, "%P", Utils.ID2String(Item.Parent.Parent.ID.ToString))
            s = Replace(s, "%A", Utils.ID2String(Item.Application.ID.ToString))
            Return s
        Catch ex As System.Exception

            Return ""
        End Try
    End Function

    Public Function MakeNumString(ByVal d As Date, ByVal template As String, ByVal org As String) As String
        Dim out As String
        Dim ST As String
        Dim SY As String
        Dim SQ As String
        Dim SM As String
        Dim SD As String

        SD = Right("0" & VB.Day(d), 2)
        SM = Right("0" & Month(d), 2)
        SY = Right("00" & Year(d), 2)
        ST = Right("0000" & Year(d), 4)
        SQ = CStr(1 + ((Month(d) - 1) \ 3))

        out = template
        out = Replace(out, "%D", SD)
        out = Replace(out, "%M", SM)
        out = Replace(out, "%Q", SQ)
        out = Replace(out, "%Y", SY)
        out = Replace(out, "%T", ST)
        out = Replace(out, "%O", org)

        Return out
    End Function
#End Region

End Class
