
Option Explicit On 

Imports System.Data
Imports System.xml
Imports System.io
Imports System.Data.Common
Imports System.Reflection
Imports System.Collections
Imports System.Collections.Generic



Public Class Manager
    Implements IDisposable

    Dim mOpenInstances As Dictionary(Of Guid, OpenInstance)
    Dim mR2O As Dictionary(Of Guid, R2OMap)
    Dim mSession As Session
    Dim mSite As String
    Dim mTempFiles As Collection
    Private m_CustomObjects As Dictionary(Of String, Object)
    Private mFinder As Object
    Private m_DllPath As String
    Private m_BD As Dictionary(Of String, BufferInfo)
    Dim mXmlFile As String
    Dim mErrorMessage As String = String.Empty

    Public Property ErrorMessage() As String
        Get
            Return mErrorMessage
        End Get
        Set(ByVal Value As String)
            mErrorMessage = Value
        End Set
    End Property


    Public Property Site() As String
        Get
            Return mSite
        End Get
        Set(ByVal Value As String)
            mSite = Value
        End Set
    End Property

    Public ReadOnly Property Session() As Session
        Get
            If mSession Is Nothing Then
                If mSite = "" Or mSite = String.Empty Then Return Nothing
                mSession = New Session
                mSession.XmlFile = XmlFile
                mSession.Site = mSite
                ErrorMessage = mSession.ErrorMessage
            End If
            Return mSession
        End Get
    End Property


    '--------------------------------------------------------------------------
    ' alias for useful functions
    Public Function GetData(ByVal Query As String) As DataTable
        Return Session.GetData(Query)
    End Function


    ' alias for useful functions
    Public Function Provider() As LATIR2.DBProvider
        Return Session.GetProvider
    End Function



    Public Function Base2ID(ByVal fieldName As String) As String
        Return Provider.ID2Base(fieldName)
    End Function

    Public Function Base2ID(ByVal fieldName As String, ByVal FieldAlias As String) As String
        Return Provider.ID2Base(fieldName, FieldAlias)
    End Function


    Public Function ID2Const(ByVal ID As Guid) As String
        Return Provider.ID2Const(ID)
    End Function


    Public Function ID2Param(ByVal ID As Guid) As Object
        Return Provider.ID2Param(ID)
    End Function

    Public Function Date2Const(ByVal D As Date) As String
        Return Provider.Date2Const(D)
    End Function


    Public Function DateFunc() As String
        Return Provider.DateFunc()
    End Function

    ' -----------------------------------------------------------------------

    Public Sub New()
        MyBase.New()
        mOpenInstances = New Dictionary(Of Guid, OpenInstance)
        mR2O = New Dictionary(Of Guid, R2OMap)
        m_CustomObjects = New Dictionary(Of String, Object)
    End Sub

    Protected Overrides Sub Finalize()
        Dispose()
        MyBase.Finalize()
    End Sub

    Public Sub Close()
        If Not mSession Is Nothing Then
            mSession.Close()
        End If
    End Sub

    Public ReadOnly Property Connected As Boolean
        Get
            If mSession Is Nothing Then Return False
            Return mSession.Connected
        End Get
    End Property

    Public ReadOnly Property Connection() As DbConnection
        Get
            Return mSession.Connection
        End Get
    End Property

    Public Sub Dispose() Implements System.IDisposable.Dispose

        Try

            KillTempFiles()
        Catch
        End Try
        'If Not mOpenInstances Is Nothing Then mOpenInstances.Dispose()
        mOpenInstances = Nothing
        'If Not mR2O Is Nothing Then mR2O.Dispose()
        mR2O = Nothing
        mSession = Nothing
     
    End Sub



    Public Function GetInstanceObject(ByVal InstanceiD As Guid) As Document.Doc_Base
      
        If (InstanceiD.Equals(Guid.Empty)) Then Return Nothing


        If Session Is Nothing Then
            Return Nothing

        End If

        If Not Session.Connected Then
            Return Nothing

        End If


        If Session.SessionID.Equals(System.Guid.Empty) Then
            Return Nothing

        End If

        ' kill broken object
        If mOpenInstances.ContainsKey(InstanceiD) Then
            If mOpenInstances.Item(InstanceiD).DOC Is Nothing Then
                mOpenInstances.Remove(InstanceiD)
            ElseIf mOpenInstances.Item(InstanceiD).DOC.Manager Is Nothing Then
                mOpenInstances.Remove(InstanceiD)
            End If
        End If


        Dim rs As DataTable
        Try

            If Not mOpenInstances.ContainsKey(InstanceiD) Then

                rs = Session.TheDataSource.ExecuteReader("select " + Session.GetProvider.InstanceFieldList + " from Instance where instanceid=" + Session.GetProvider.ID2Const(InstanceiD))
                If rs.Rows.Count > 0 Then
                    Dim oi As OpenInstance
                    oi = New OpenInstance
                    oi.ID = InstanceiD
                    mOpenInstances.Add(InstanceiD, oi)
                    With oi
                        .DOC = GetDoc(CStr(rs.Rows(0)("ObjType")), "")
                        .DOC.Manager = Me
                        .site = Site
                        .DOC.Name = rs.Rows(0)("Name").ToString & ""
                        Try
                            If Not (rs.Rows(0)("SecurityStyleID") Is DBNull.Value) Then
                                .DOC.SecureStyleID = New Guid(rs.Rows(0)("SecurityStyleID").ToString)
                            End If

                        Catch ex As Exception

                        End Try

                        .DOC.ID = InstanceiD
                    End With
                End If
                rs = Nothing
            End If
            Dim obj As OpenInstance = mOpenInstances.Item(InstanceiD)
            If (Not obj Is Nothing) Then
                Return obj.DOC
            End If

        Catch ex As System.Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Property XmlFile() As String
        Get
            If mXmlFile = "" Then
                mXmlFile = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\latir_sites.xml.zzz"
            End If
            Return mXmlFile
        End Get
        Set(ByVal Value As String)
            mXmlFile = Value
        End Set
    End Property

    Public Sub SaveDocumentToXML(ByVal xmlPath As String, ByVal doc As Document.Doc_Base)
        Dim x As New Xml.XmlDocument
        x.LoadXml("<" & doc.TypeName & "></" & doc.TypeName & ">")
        doc.XMLSave(CType(x.LastChild, XmlElement), x)
        x.Save(xmlPath)
    End Sub

    Protected Function GetDoc(ByVal name As String, Optional ByVal Root As String = "") As Document.Doc_Base

        Dim funcAssembly As Document.Doc_Base
        Dim asm As System.Reflection.Assembly
        funcAssembly = Nothing
        asm = Nothing
        Try
            If DllPath <> "" Then
                Try
                    asm = System.Reflection.Assembly.LoadFrom(DllPath + "\" & name & ".dll")
                Catch
                End Try
            End If
            If asm Is Nothing Then
                If Root <> "" Then
                    Try
                        asm = System.Reflection.Assembly.LoadFrom(Root + "\" & name & ".dll")
                    Catch
                    End Try
                End If
            End If
            If asm Is Nothing Then
                Dim FileName As String
                FileName = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\" & name & ".dll"
                Try
                    If (File.Exists(FileName)) Then
                        asm = System.Reflection.Assembly.LoadFrom(FileName)
                    End If
                Catch ex As System.Exception
                End Try
                If (asm Is Nothing) Then
                    Try
                        FileName = AppDomain.CurrentDomain.DynamicDirectory + "\" & name & ".dll"
                        If (File.Exists(FileName)) Then
                            asm = System.Reflection.Assembly.LoadFrom(FileName)
                        Else
                            Try
                                funcAssembly = CType(System.Activator.CreateInstance(name, name & "." & name & ".Application").Unwrap(), Document.Doc_Base)
                            Catch e2 As System.Exception
                                Dim i As Integer = 0
                                Return Nothing
                            End Try
                        End If
                    Catch e1 As System.Exception
                    End Try


                End If
            End If
            If (funcAssembly Is Nothing) AndAlso (Not asm Is Nothing) Then
                funcAssembly = CType(asm.CreateInstance(name & "." & name & ".Application", True), Document.Doc_Base)
            End If
        Catch
        End Try
        Return funcAssembly


    End Function

    Public Function DeleteInstanceByID(ByVal ID As System.Guid, Optional ByVal site As String = "") As Boolean
        FreeInstanceObject(ID)
        Return Session.DeleteInstance(ID)
    End Function

    Public Function DeleteInstance(ByVal Instance As Document.Doc_Base, Optional ByVal site As String = "") As Boolean
        FreeInstanceObject(Instance.ID)
        Return Session.DeleteInstance(Instance.ID)
    End Function

    Public Function NewInstance(ByVal InstanceiD As Guid, ByVal ObjType As String, ByVal Name As String, Optional ByVal site As String = "") As Document.Doc_Base
        Session.NewInstance(InstanceiD, ObjType.ToLower(), Name)
        Return GetInstanceObject(InstanceiD)
    End Function

    Public Function FindInstanceByRow(ByVal Table As String, ByVal RowID As Guid) As Document.Doc_Base
        Dim instid As Guid

        If RowID.Equals(System.Guid.Empty) Then Return Nothing
        'Dim nv As LATIR2.NamedValues
        'nv = New LATIR2.NamedValues
        'nv.Add("the_Table", Table, DbType.String)
        'nv.Add("RowID", Session.GetProvider.ID2Param(RowID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
        'nv.Add("InstanceID", Session.GetProvider.ID2Param(instid), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size(), ParameterDirection.InputOutput)
        'nv.Add("CURSESSION", Session.GetProvider.ID2Param(RowID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
        'Try
        '    Session.Exec("RowToInstance", nv)
        '    If Not IsDBNull(nv.Item("InstanceID").Value) Then
        '        instid = New Guid(nv.Item("InstanceID").Value.ToString)
        '        Return GetInstanceObject(instid)
        '    End If

        '    nv = Nothing

        'Catch ex As System.Exception
        '    Console.WriteLine(ex.Message)
        'End Try
        'Return Nothing

        Dim rpl As LATIR2.RowParentList
        Dim obj As Document.Doc_Base

        Dim i As Long

        rpl = Session.TheFinder.RowParents(Table, RowID)
        If rpl.Count > 0 Then
            For i = 1 To rpl.Count
                Debug.Print("RowParents: " + i.ToString + " ->   " + rpl.Item(i).PartName + "    " + rpl.Item(i).RowID.ToString)
            Next




            obj = GetInstanceObject(rpl.Item(1).RowID)
            If obj Is Nothing Then Return Nothing


        Else
            ' use old search style
            'Rowobj = FindObject(StrID, RowID.ToString())
            'If Rowobj Is Nothing Then
            '    obj = Manager.FindInstanceByRow(StrID, RowID)
            '    If obj Is Nothing Then Exit Function
            '    Rowobj = obj.FindObject(StrID, RowID)
            'End If
            obj = Nothing
        End If

        Return obj
    End Function

    Public Sub LockInstanceObject(ByVal InstanceiD As Guid)
        Try
            If Not mOpenInstances.Item(InstanceiD) Is Nothing Then
                mOpenInstances.Item(InstanceiD).Locked = True
            End If
        Catch
        End Try
    End Sub

    Public Sub UnLockInstanceObject(ByVal InstanceiD As Guid)
        Try
            If Not mOpenInstances.Item(InstanceiD) Is Nothing Then
                mOpenInstances.Item(InstanceiD).Locked = False
            End If
        Catch
        End Try
    End Sub

    Public Function FreeInstanceObject(ByVal InstanceID As Guid) As Boolean
        Try
            If mOpenInstances.Item(InstanceID) Is Nothing Then
                Return True
            Else
                If mOpenInstances.Item(InstanceID).DOC Is Nothing Then
                    mOpenInstances.Remove(InstanceID)
                    Return True
                Else

                    If mOpenInstances.Item(InstanceID).Locked = False Then
                        Try
                            mOpenInstances.Item(InstanceID).DOC.Dispose()

                        Catch ex As Exception

                        End Try
                        mOpenInstances.Item(InstanceID).DOC.Manager = Nothing

                        mOpenInstances.Item(InstanceID).DOC = Nothing
                        mOpenInstances.Remove(InstanceID)
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If

        Catch ex As System.Exception
        End Try
        Return False


    End Function


    Public Function GetInstanceObjectFromXML(ByVal XMLPath As String) As Object
        Dim xdom As XmlDocument
        xdom = New XmlDocument
        xdom.Load(XMLPath)
        Dim InstanceiD As Guid, TypeName As String
        Dim anode As XmlElement

        anode = CType(xdom.LastChild.FirstChild, XmlElement)
        TypeName = anode.Attributes.GetNamedItem("TYPENAME").Value
        InstanceiD = New System.Guid(anode.Attributes.GetNamedItem("ID").Value)

        If mOpenInstances.Item(InstanceiD) Is Nothing Then
            Try
                Dim oi As OpenInstance
                oi = New OpenInstance
                oi.ID = InstanceiD
                mOpenInstances.Add(InstanceiD, oi)
                With oi
                    .DOC = GetDoc(TypeName, "")
                    .DOC.Manager = Me
                    .site = ""
                    .DOC.ID = InstanceiD
                End With
            Catch
                xdom = Nothing
                Return Nothing
            End Try
        End If

        mOpenInstances.Item(InstanceiD).DOC.XMLLoad(xdom.LastChild, 1)
        xdom = Nothing
        Return mOpenInstances.Item(InstanceiD).DOC

    End Function


    Public Sub StoreTempFileData(ByVal Path As String, Optional ByVal PartName As String = "", Optional ByVal RowID As String = "")
        If mTempFiles Is Nothing Then
            mTempFiles = New Collection
        End If
        Dim temp As TempFileInfo
        temp = New TempFileInfo
        temp.PathToFile = Path
        temp.RowID = RowID
        temp.PartName = PartName
        mTempFiles.Add(temp)
    End Sub

    Private Sub KillTempFiles()
        If mTempFiles Is Nothing Then Exit Sub

        Dim temp As TempFileInfo
        Try
            For Each temp In mTempFiles
                Kill(temp.PathToFile)
            Next temp
            mTempFiles = Nothing
        Catch
        End Try
    End Sub

    Public Property DllPath() As String
        Get
            Return m_DllPath
        End Get
        Set(ByVal Value As String)
            m_DllPath = Value
        End Set
    End Property

    Private Function BufferData() As Dictionary(Of String, BufferInfo)
        If m_BD Is Nothing Then
            m_BD = New Dictionary(Of String, BufferInfo)
        End If
        Return m_BD
    End Function

    Public Sub SetBuffer(ByVal PartName As String, ByVal Data As String)
        Dim bi As BufferInfo = New BufferInfo
        bi.PartName = PartName
        bi.Data = Data
        BufferData.Add(PartName, bi)
    End Sub

    Public Function GetBuffer(ByVal PartName As String) As String
        Try
            Return BufferData.Item(PartName).Data
        Catch
            Return ""
        End Try
    End Function

    Public Sub ClearBuffer(ByVal PartName As String)
        BufferData.Remove(PartName)
    End Sub

    Public Sub AddToCash(ByVal RowID As Guid, ByVal ItemID As Guid)
        Try

            If Not mR2O.ContainsKey(RowID) Then
                Dim r2o As R2OMap
                r2o = New R2OMap
                r2o.ID = ItemID
                r2o.RowID = RowID
                mR2O.Add(RowID, r2o)
            End If
        Catch
        End Try

    End Sub


    Public Sub RemoveFromCash(ByVal RowID As Guid)
        Try
            If mR2O.ContainsKey(RowID) Then
                mR2O.Remove(RowID)
            End If
        Catch
        End Try

    End Sub

    Public Function GetRowCashedObject(ByVal RowID As Guid) As Guid
        Try
            If mR2O.ContainsKey(RowID) Then
                Return mR2O.Item(RowID).ID
            End If
        Catch
        End Try
        Return Guid.Empty
    End Function


    Public Function AddCustomObjects(ByRef obj As Object, ByVal Name As String) As Boolean
        Try

            m_CustomObjects.Add(Name, obj)
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Function GetCustomObjects(ByVal Name As String) As Object
        Try
            If m_CustomObjects.ContainsKey(Name) Then
                Return m_CustomObjects.Item(Name)
            End If

        Catch

        End Try
        Return Nothing
    End Function

    Public Function RemoveCustomObjects(ByVal Name As String) As Boolean
        Try
            If m_CustomObjects.ContainsKey(Name) Then
                Call m_CustomObjects.Remove(Name)
            End If
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Function GetDocStatusSupport(ByVal name As String, Optional ByVal Root As String = "") As Document.Doc_StatusSupport

        Dim funcAssembly As Document.Doc_StatusSupport
        Dim asm As System.Reflection.Assembly
        funcAssembly = Nothing
        asm = Nothing
        Try
            If DllPath <> "" Then
                Try
                    asm = System.Reflection.Assembly.LoadFrom(DllPath + "\" & name & ".statussupport.dll")
                Catch
                End Try
            End If
            If asm Is Nothing Then
                If Root <> "" Then
                    Try
                        asm = System.Reflection.Assembly.LoadFrom(Root + "\" & name & ".statussupport.dll")
                    Catch
                    End Try
                End If
            End If
            If asm Is Nothing Then
                Try
                    asm = System.Reflection.Assembly.LoadFrom(System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\" & name & ".statussupport.dll")
                Catch ex As System.Exception
                    'MsgBox(ex.Message)
                    Try
                        asm = System.Reflection.Assembly.LoadFrom(name & ".statussupport.dll")
                    Catch e1 As System.Exception
                        'MsgBox(e1.Message)
                        Try
                            funcAssembly = CType(System.Activator.CreateInstance(name, name & "." & name & "_statussupport").Unwrap(), Document.Doc_StatusSupport)
                        Catch e2 As System.Exception
                            Dim i As Integer = 0
                            Return Nothing
                        End Try

                    End Try
                End Try
            End If
            If (funcAssembly Is Nothing) Then
                funcAssembly = CType(asm.CreateInstance(name & "." & name & "_statussupport", True), Document.Doc_StatusSupport)
            End If
        Catch
        End Try
        Return funcAssembly


    End Function



End Class
