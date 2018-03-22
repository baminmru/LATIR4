
    Option Explicit On
    
    Imports System
    Imports System.Data
    Imports System.XML
Imports System.Data.Common
    
    Namespace Document
    
    Public MustInherit Class DocRow_Base
        Inherits All_Base


        Private m_Application As Doc_Base
        Private m_Parent As DocCollection_Base
        Private m_Brief As String
        Private m_SecureStyleID As Guid
        Private m_RowRetrived As Boolean = False
        Private m_Changed As Boolean = False
        Private m_Deleted As Boolean = False
        Private m_RetriveTime As Date
        Private m_ChangeTime As Date
        Private m_AccessTime As Date
        Private m_IsLocked As LATIR2.Session.LockStyle
        Private LastCheckTime As Date

        'Public Overridable Function Value(ByVal Index As Object) As Object
        '    Return DBNull.Value
        'End Function
        'Public Overridable Sub SetValue(ByVal Index As Object, ByVal mValue As Object)

        'End Sub

        Public Overridable Property Value(ByVal Index As Object) As Object
            Get
                Return (Nothing)
            End Get
            Set(value As Object)

            End Set
        End Property

        Public Overridable ReadOnly Property Count() As Long
            Get
                Return 0
            End Get
        End Property

        Public Overridable Function FieldNameByID(ByVal Index As Long) As String
            Return String.Empty
        End Function

        Public Overridable ReadOnly Property CountOfParts() As Long
            Get
                Return 0
            End Get
        End Property

        Public ReadOnly Property Deleted() As Boolean
            Get
                Return m_Deleted
            End Get
        End Property
        Public Property Changed() As Boolean
            Get
                Return m_Changed
            End Get
            Set(ByVal Value As Boolean)
                m_Changed = Value
            End Set
        End Property

        Public Property SecureStyleID() As Guid
            Get
                Return m_SecureStyleID
            End Get
            Set(ByVal Value As Guid)
                m_SecureStyleID = Value
            End Set

        End Property

        Public Function PartName() As String
            Return Parent.ChildPartName()
        End Function
        Protected Friend Sub CloseParents()
            m_Application = Nothing
            m_Parent = Nothing
        End Sub
        Public Property RowRetrived() As Boolean
            Get
                Return m_RowRetrived
            End Get
            Set(ByVal Value As Boolean)
                m_RowRetrived = Value
            End Set

        End Property

        Public Property RetriveTime() As Date
            Get
                Return m_RetriveTime
            End Get
            Set(ByVal Value As Date)
                m_RetriveTime = Value
            End Set

        End Property

        Public Property ChangeTime() As Date
            Get
                Return m_ChangeTime
            End Get
            Set(ByVal Value As Date)
                m_ChangeTime = Value
            End Set
        End Property
        Public Property AccessTime() As Date
            Get
                Return m_AccessTime
            End Get
            Set(ByVal newAccessTime As Date)
                m_AccessTime = newAccessTime
                If m_AccessTime <= m_RetriveTime Then m_AccessTime = m_RetriveTime.AddSeconds(1)
            End Set
        End Property


        Public Function Save() As Boolean
            LoadFromDatabase()
            If Not CanChange Then Return False
            Dim nv As New LATIR2.NamedValues
            Pack(nv)
            Try
                If Me.Parent.IsTree Then


                    Dim tmpParent As All_Base
                    tmpParent = Me
                    While tmpParent.Parent.Parent.GetType.Name = Me.GetType.Name
                        tmpParent = tmpParent.Parent.Parent
                    End While

                    If Not Application.Session.SaveRow2(PartName, ID, tmpParent.Parent.Parent.ID, nv, Application.ID) Then
                        Return False
                    End If

                Else
                    If Not Application.Session.SaveRow2(PartName, ID, Me.Parent.Parent.ID, nv, Application.ID) Then
                        Return False
                    End If
                End If

                Changed = False
                Return True

            Catch ex As System.Exception
                'Throw ex
            End Try
        End Function
        Public Function Delete() As Boolean
            Dim OK As Boolean
            Try
                If Not CanChange Then Return False
                OK = Application.Session.DeleteRow2(PartName, ID, Application.ID)
                Changed = False
                Dispose()
                Return OK
            Catch ex As System.Exception
                Throw ex
            End Try
        End Function
        Public Sub Secure(ByVal SecurityStyleID As Guid)
            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues
            Try

                nv.Add("ROWID", ID, Application.Session.GetProvider.ID2DbType(), Application.Session.GetProvider.ID2Size())
                nv.Add("SECURITYSTYLEID", SecurityStyleID, Application.Session.GetProvider.ID2DbType(), Application.Session.GetProvider.ID2Size())

                Application.Session.Exec(PartName() & "_SINIT", nv)
                nv = Nothing
                m_SecureStyleID = SecurityStyleID
                Exit Sub
            Catch ex As System.Exception
                nv = Nothing
                Throw ex
            End Try
        End Sub
        Public Sub Propagate()
            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues
            Try
                nv.Add("ROWID", ID, Application.Session.GetProvider.ID2DbType(), Application.Session.GetProvider.ID2Size())

                Application.Session.Exec(PartName() & "_PROPAGATE", nv)
                nv = Nothing
                Exit Sub
            Catch ex As System.Exception
                nv = Nothing
                Throw ex
            End Try
        End Sub

        Public Sub Refresh()
            RowRetrived = False
            m_Brief = ""
        End Sub
        Public Sub LoadFromDatabase()
            Try
                If ID.Equals(System.Guid.Empty) Then Exit Sub
                Dim rs As DataTable
                If Not RowRetrived Then
                    CleanFields()
                    rs = Application.Session.GetRow(PartName, Parent.FieldList, ID)
                    If Not rs Is Nothing Then
                        If rs.Rows.Count > 0 Then
                            Unpack(rs.Rows(0))
                            m_SecureStyleID = New Guid(rs.Rows(0)("SecurityStyleID").ToString)
                        End If
                        RowRetrived = True
                        RetriveTime = Now

                    End If

                    'MLF
                    If Application.Session.Language <> "" Then
                        rs = Application.Session.GetRow(PartName() + "_" + Application.Session.Language, Parent.FieldList, ID)
                        If Not rs Is Nothing Then
                            If rs.Rows.Count > 0 Then
                                Unpack(rs.Rows(0))
                            End If
                        End If
                    End If
                    'E_MLF

                End If
            Catch
            End Try
        End Sub

        Private inFindObject As Boolean
        Public Function FindObject(ByVal Table As String, ByVal InstID As String) As Object
            Dim m_FindObject As Object = Nothing

            If Table = "" Then Return Nothing
            If InstID = "" Then Return Nothing
            If InstID = System.Guid.Empty.ToString Then Return Nothing
            'If inFindObject Then Return Nothing
            'inFindObject = True
            If Table.ToLower() = PartName().ToLower() Then
                If (New System.Guid(InstID)).Equals(ID) Then
                    m_FindObject = Me
                End If
            End If
            If m_FindObject Is Nothing Then
                Return FindInside(Table, InstID)
            End If
            'inFindObject = False
            Return m_FindObject
            m_FindObject = Nothing

        End Function
        Public Sub Compact()
            If Not Changed Then
                CleanFields()
                RowRetrived = False
            End If

        End Sub



        Public Sub XMLLoad(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)
            Try

                If LoadMode <> 2 Then
                    If Not node.Attributes.GetNamedItem("ID") Is Nothing Then
                        m_ID = New System.Guid(node.Attributes.GetNamedItem("ID").Value)
                    End If
                End If
                m_Deleted = CBool(node.Attributes.GetNamedItem("Deleted").Value)
                m_IsLocked = CType(node.Attributes.GetNamedItem("IsLocked").Value, Session.LockStyle)
                If m_IsLocked > 2 Then m_IsLocked = 0
                m_RetriveTime = System.DateTime.MinValue
                m_RetriveTime = m_RetriveTime.AddTicks(CLng(node.Attributes.GetNamedItem("RetriveTime").Value))
                m_ChangeTime = System.DateTime.MinValue
                m_ChangeTime = m_ChangeTime.AddTicks(CLng(node.Attributes.GetNamedItem("ChangeTime").Value))
                m_AccessTime = System.DateTime.MinValue
                m_AccessTime = m_AccessTime.AddTicks(CLng(node.Attributes.GetNamedItem("AccessTime").Value))

                XMLUnpack(node, LoadMode)

                If Not node.Attributes.GetNamedItem("SecureStyleID") Is Nothing Then
                    Dim tmpguid As System.Guid
                    tmpguid = New System.Guid(node.Attributes.GetNamedItem("SecureStyleID").Value)
                    If Not tmpguid.Equals(System.Guid.Empty) Then
                        Secure(tmpguid)
                    End If
                End If



                m_Changed = True
                m_RowRetrived = True
                m_Brief = ""

                Exit Sub
            Catch ex As System.Exception
            End Try
        End Sub


        Public Sub XMLSave(ByVal node As XmlElement, ByVal Xdom As System.Xml.XmlDocument)
            Try

                LoadFromDatabase()
                node.SetAttribute("ID", m_ID.ToString())
                node.SetAttribute("Deleted", CStr(m_Deleted))
                node.SetAttribute("IsLocked", CStr(m_IsLocked))
                If m_RetriveTime = System.DateTime.MinValue Then m_RetriveTime = New Date(1899, 12, 30) ' new Date(1899, 12, 30)
                node.SetAttribute("RetriveTime", CStr(m_RetriveTime.Ticks))
                If m_ChangeTime = System.DateTime.MinValue Then m_ChangeTime = New Date(1899, 12, 30) ' new Date(1899, 12, 30)
                node.SetAttribute("ChangeTime", CStr(m_ChangeTime.Ticks))
                If m_AccessTime = System.DateTime.MinValue Then m_AccessTime = New Date(1899, 12, 30) ' new Date(1899, 12, 30)
                node.SetAttribute("AccessTime", CStr(m_AccessTime.Ticks))

                node.SetAttribute("SecureStyleID", SecureStyleID.ToString())
                XLMPack(node, Xdom)
            Catch
            End Try
        End Sub

        ' может ли быть изменено
        Public Overrides ReadOnly Property CanChange() As Boolean
            Get
                Dim test As Boolean
                If Not Parent Is Nothing Then
                    test = Parent.CanChange
                End If
                If Not test Then
                    test = (IsLocked < LATIR2.Session.LockStyle.ExternalLockSession)
                End If
                Return test
            End Get

        End Property




        ' User has locked record
        Public Property IsLocked() As LATIR2.Session.LockStyle
            Get
                If m_IsLocked <> LATIR2.Session.LockStyle.LockSession And m_IsLocked <> LATIR2.Session.LockStyle.LockPermanent Then CheckLock()
                Return m_IsLocked
            End Get
            Set(ByVal Value As LATIR2.Session.LockStyle)
                m_IsLocked = Value
            End Set
        End Property


        Private Sub CheckLock()
            If Now < LastCheckTime.AddSeconds(10) Then Exit Sub
            Dim nv As LATIR2.NamedValues, LockType As Long
            nv = New LATIR2.NamedValues
            nv.Add("ROWID", ID, Application.Session.GetProvider.ID2DbType(), Application.Session.GetProvider.ID2Size())
            nv.Add("IsLocked", LockType, DbType.Int16, ParameterDirection.Output)
            Try
                Application.Session.Exec(PartName() & "_ISLOCKED", nv)
                m_IsLocked = CType(nv.Item("ISLocked").Value, Session.LockStyle)
                nv = Nothing
                LastCheckTime = Now
            Catch
            End Try
        End Sub
        Public Function LockResource(Optional ByVal Permanent As Boolean = False) As Boolean
            Dim OK As Boolean
            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues
            nv.Add("ROWID", ID, Application.Session.GetProvider.ID2DbType(), Application.Session.GetProvider.ID2Size())
            Try
                If Not Permanent Then
                    nv.Add("LOCKMODE", 1, DbType.Int16)
                Else
                    nv.Add("LOCKMODE", 2, DbType.Int16)
                End If
                OK = Application.Session.Exec(PartName() & "_LOCK", nv)
                If OK Then
                    If Permanent Then m_IsLocked = LATIR2.Session.LockStyle.LockPermanent Else m_IsLocked = LATIR2.Session.LockStyle.LockSession
                Else
                    m_IsLocked = LATIR2.Session.LockStyle.NoLock
                End If
            Catch ex As System.Exception
                nv = Nothing
            End Try
        End Function
        Public Function UnLockResource() As Boolean
            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues
            nv.Add("ROWID", ID, Application.Session.GetProvider.ID2DbType(), Application.Session.GetProvider.ID2Size())
            Try
                Application.Session.Exec(PartName() & "_UNLOCK", nv)

                m_IsLocked = LATIR2.Session.LockStyle.NoLock
                Return True
            Catch ex As System.Exception
                nv = Nothing
                Return False
            End Try
        End Function
        Public Function CanLock() As Boolean
            Dim nv As LATIR2.NamedValues, notLocked As Long
            nv = New LATIR2.NamedValues
            nv.Add("ROWID", ID, Application.Session.GetProvider.ID2DbType(), Application.Session.GetProvider.ID2Size())
            nv.Add("LockMode", notLocked, DbType.Int16, ParameterDirection.InputOutput)
            notLocked = 0
            Try
                Application.Session.Exec(PartName() & "_HCL", nv)
                If Int16.Parse(nv.Item("LockMode").Value.ToString) = 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch

                nv = Nothing
                Return False
            End Try
        End Function
        Public MustOverride Sub BatchUpdate()
        Friend Sub LoadAll()
            LoadFromDatabase()
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Property Parent() As DocCollection_Base
            Get
                Return m_Parent
            End Get
            Set(ByVal Value As DocCollection_Base)
                If m_Parent Is Nothing Then
                    m_Parent = Value
                End If
            End Set
        End Property

        Public Overrides Property Application() As Doc_Base
            Get
                Return m_Application
            End Get
            Set(ByVal Value As Doc_Base)
                If m_Application Is Nothing Then
                    m_Application = Value
                End If
            End Set
        End Property

        Public ReadOnly Property ActualBrief() As String
            Get
                Application.Session.GetBrief(PartName, ID, m_Brief)
                Return m_Brief
            End Get
        End Property
        Public ReadOnly Property Brief() As String
            Get
                If (m_Brief = String.Empty) Then
                    Application.Session.GetBrief(PartName, ID, m_Brief)
                End If
                Return m_Brief
            End Get
        End Property

       
        Public Overrides Function ToString() As String
            Dim dynStr As System.Text.StringBuilder = New System.Text.StringBuilder(Me.GetType().Name)
            dynStr.Append(":")
            dynStr.Append("  ID=")
            dynStr.Append(Me.m_ID)
            dynStr.Append("  Brief=")
            dynStr.Append(Me.m_Brief)
            Return dynStr.ToString()
        End Function

        Public MustOverride Function FindInside(ByVal StrID As String, ByVal InstID As String) As Document.DocRow_Base
        Public MustOverride Sub Unpack(ByVal row As DataRow)
        Public MustOverride Sub Pack(ByVal nv As LATIR2.NamedValues)
        Public MustOverride Sub CleanFields()
        Public MustOverride Sub FillDataTable(ByRef DestDataTable As DataTable)
        Protected MustOverride Sub XMLUnpack(ByVal node As XmlNode, Optional ByVal LoadMode As Integer = 0)
        Protected MustOverride Sub XLMPack(ByVal node As XmlElement, ByVal Xdom As System.Xml.XmlDocument)
        Public Overridable Function GetDocCollection_Base(ByVal Index As Long) As LATIR2.Document.DocCollection_Base
            Return Nothing
        End Function


    End Class
    End Namespace