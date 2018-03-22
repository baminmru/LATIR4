Option Explicit On
Imports System.Data
Imports System.Xml
Imports System.Data.Common
Imports LATIR2.Utils
    
    Namespace Document
    
    Public MustInherit Class Doc_Base
        Inherits All_Base


        Private m_Manager As LATIR2.Manager
        Private findCash As Collection

        Private m_SecureStyleID As Guid
        Private m_StatusID As Guid
        Private m_Name As String
        Private m_workoffline As Boolean
        Private m_AutoLoadPart As Boolean
        Private m_IsLocked As LATIR2.Session.LockStyle

        Protected MustOverride Function MyTypeName() As String

        Public MustOverride Sub BatchUpdate()

        Public ReadOnly Property TypeName() As String
            Get
                Return MyTypeName()
            End Get
        End Property


        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal Value As String)
                m_Name = Value
            End Set
        End Property


        Public Property Manager() As LATIR2.Manager
            Get
                Return m_Manager
            End Get
            Set(ByVal m As LATIR2.Manager)
                If Not m_Manager Is Nothing Then Return
                m_Manager = m

            End Set
        End Property


        Public ReadOnly Property Session() As LATIR2.Session
            Get
                Return Manager.Session
            End Get
        End Property




        Public Property AutoLoadPart() As Boolean
            Get
                Return m_AutoLoadPart
            End Get
            Set(ByVal Value As Boolean)
                m_AutoLoadPart = Value
            End Set
        End Property





        Public Overrides Property Application() As Doc_Base
            Get
                Return Me
            End Get
            Set(value As Doc_Base)
                ' do nothing
            End Set
        End Property



        Public Sub AddToCash(ByVal key As String, ByVal Item As Object)
            Try
                If findCash Is Nothing Then findCash = New Collection
                If findCash.Contains(key) Then
                    If findCash.Item(key) Is Nothing Then
                        findCash.Remove(key)
                        findCash.Add(Item, key)
                    End If
                Else
                    findCash.Add(Item, key)
                End If
            Catch
            End Try
        End Sub

        Public Sub RemoveFromCash(ByVal key As String)
            Try
                If findCash Is Nothing Then Exit Sub
                If findCash.Contains(key) Then
                    findCash.Remove(key)
                End If
            Catch
            End Try
        End Sub
        Public Property SecureStyleID() As Guid
            Get
                Try
                    GetStatus()
                    Return m_SecureStyleID
                Catch
                End Try
            End Get
            Set(ByVal newid As Guid)
                Secure(newid)
                GetStatus()
            End Set

        End Property

        Public Property StatusID() As Guid
            Get
                Try

                    GetStatus()
                    Return m_StatusID
                Catch
                End Try
            End Get
            Set(ByVal newid As Guid)
                SetStatus(newid)
                GetStatus()
            End Set
        End Property

        Public ReadOnly Property StatusName() As String
            Get

                GetStatus()
                Dim rs As DataTable
                rs = Session.GetRowDT("OBJSTATUS", m_StatusID)
                If rs.Rows.Count > 0 Then
                    Return (rs.Rows(0)("Name").ToString())
                End If
                Return ""
            End Get
        End Property

    

        Public Function FindRowObject(ByVal StrID As String, ByVal RowID As Guid) As DocRow_Base
            Dim obj As Doc_Base
            Dim Rowobj As DocRow_Base = Nothing
            Dim i As Long
            Dim m_FindObject As DocRow_Base
            m_FindObject = Nothing

            If StrID = "" Then Return Nothing
            If RowID.Equals(System.Guid.Empty) Then Return Nothing
            If findCash Is Nothing Then
                findCash = New Collection
            End If
            Try
                m_FindObject = Nothing
                If findCash.Contains(StrID & ID2String(RowID.ToString())) Then
                    m_FindObject = CType(findCash.Item(StrID & ID2String(RowID.ToString())), LATIR2.Document.DocRow_Base)
                End If

                If Not m_FindObject Is Nothing Then
                    If m_FindObject.Application Is Nothing Then
                        m_FindObject = Nothing
                        findCash.Remove(StrID & ID2String(RowID.ToString()))
                    Else
                        Return m_FindObject

                    End If
                End If



                Dim cachedID As Guid
                cachedID = Manager.GetRowCashedObject(RowID)
                If Not cachedID.Equals(Guid.Empty) Then
                    If Not ID.Equals(cachedID) Then
                        obj = Manager.GetInstanceObject(cachedID)
                        Rowobj = obj.FindRowObject(StrID, RowID)
                    End If
                End If

                If Rowobj Is Nothing Then
                    Dim rpl As LATIR2.RowParentList
                    rpl = Session.TheFinder.RowParents(StrID, RowID)
                    If rpl.Count > 0 Then
                        For i = 1 To rpl.Count
                            Debug.Print("RowParents: " + i.ToString + " ->   " + rpl.Item(i).PartName + "    " + rpl.Item(i).RowID.ToString)
                        Next


                        If rpl.Item(1).RowID.Equals(ID) Then
                            Rowobj = Me.FindObject(rpl.Item(2).PartName, rpl.Item(2).RowID.ToString)
                            If Rowobj Is Nothing Then
                                Debug.Print("FindObject " + ID.ToString + " ->   " + rpl.Item(2).PartName + "    " + rpl.Item(2).RowID.ToString)
                            Else
                                For i = 3 To rpl.Count
                                    Rowobj = CType(Rowobj.FindObject(rpl.Item(i).PartName, rpl.Item(i).RowID.ToString), LATIR2.Document.DocRow_Base)
                                Next
                            End If


                            ' reference from another object
                        Else

                            obj = Manager.GetInstanceObject(rpl.Item(1).RowID)
                            If obj Is Nothing Then Return Nothing
                            Manager.AddToCash(RowID, obj.ID)
                            Rowobj = obj.FindRowObject(StrID, RowID)
                        End If

                    Else
                        ' use old search style
                        'Rowobj = FindObject(StrID, RowID.ToString())
                        'If Rowobj Is Nothing Then
                        '    obj = Manager.FindInstanceByRow(StrID, RowID)
                        '    If obj Is Nothing Then Exit Function
                        '    Rowobj = obj.FindObject(StrID, RowID)
                        'End If
                        Rowobj = Nothing
                    End If
                End If
            Catch
            End Try
            Return Rowobj
        End Function

        Protected MustOverride Function FindInCollections(ByVal Table As String, ByVal RowID As String) As DocRow_Base

        'Private inFindObject As Boolean
        Public Function FindObject(ByVal Table As String, ByVal RowID As String) As DocRow_Base
            Dim m_FindObject As DocRow_Base = Nothing

            RowID = ID2String(RowID)
            If Table = "" Then Return Nothing
            If RowID = "" Then Return Nothing
            If RowID = ID2String(System.Guid.Empty.ToString()) Then
                Return Nothing
            End If
            'If inFindObject Then Return Nothing
            'inFindObject = True
            If findCash Is Nothing Then
                findCash = New Collection
            End If
            Try
                If findCash.Contains(Table & ID2String(RowID)) Then
                    m_FindObject = CType(findCash.Item(Table & ID2String(RowID)), LATIR2.Document.DocRow_Base)
                Else
                    m_FindObject = Nothing
                End If
                If Not m_FindObject Is Nothing Then
                    If m_FindObject.Application Is Nothing Then
                        m_FindObject = Nothing
                        findCash.Remove(Table & ID2String(RowID))
                    End If
                End If
                If m_FindObject Is Nothing Then
                    m_FindObject = FindInCollections(Table, RowID)
                End If
                If Not m_FindObject Is Nothing Then
                    If Not findCash.Contains(Table & ID2String(RowID)) Then
                        findCash.Add(m_FindObject, Table & ID2String(RowID))
                    End If
                End If
            Catch
            End Try
            Return m_FindObject

        End Function


        Public Sub Secure(ByVal SecurityStyleID As Guid)
            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues
            nv.Add("CURSESSION", Session.GetProvider.ID2Param(Session.SessionID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("ROWID", Session.GetProvider.ID2Param(ID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("SECURITYSTYLEID", SecurityStyleID, Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            Try
                Session.Exec(Session.KernelPrefix & "INSTANCE_SINIT", nv)
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
            nv.Add("CURSESSION", Session.GetProvider.ID2Param(Session.SessionID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("ROWID", Session.GetProvider.ID2Param(ID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            Try
                Session.Exec(Session.KernelPrefix & "INSTANCE_PROPAGATE", nv)
                nv = Nothing
                Exit Sub
            Catch ex As System.Exception
                nv = Nothing
                Throw ex
            End Try
        End Sub
        Public Sub Save()
            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues
            nv.Add("CURSESSION", Session.GetProvider.ID2Param(Session.SessionID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("InstanceID", Session.GetProvider.ID2Param(ID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("ObjType", TypeName, DbType.String)
            nv.Add("Name", Name, DbType.String)
            Try
                Session.Exec(Session.KernelPrefix & "INSTANCE_SAVE", nv)
                nv = Nothing
                Exit Sub
            Catch ex As System.Exception
                nv = Nothing
                Throw ex
            End Try
        End Sub
        Private Sub SetStatus(ByVal StatusID As Guid)

            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues
            nv.Add("CURSESSION", Session.GetProvider.ID2Param(Session.SessionID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("InstanceID", Session.GetProvider.ID2Param(ID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("Statusid", Session.GetProvider.ID2Param(StatusID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            Try
                Session.Exec(Session.KernelPrefix & "INSTANCE_STATUS", nv)
                nv = Nothing
                Exit Sub
            Catch ex As System.Exception
                nv = Nothing
                Throw ex
            End Try
        End Sub
        Private Sub GetStatus()
            Dim rs As DataTable
            Try
                rs = Session.GetRow("INSTANCE", Session.GetProvider.InstanceFieldList, ID)
                If rs.Rows(0)("status").ToString() = "" Then
                    m_StatusID = System.Guid.Empty
                Else
                    m_StatusID = New System.Guid(rs.Rows(0)("status").ToString())
                End If
                Try
                    If rs.Rows(0)("SecurityStyleID") Is System.DBNull.Value Then
                        m_SecureStyleID = System.Guid.Empty
                    Else
                        m_SecureStyleID = New System.Guid(rs.Rows(0)("SecurityStyleID").ToString())
                    End If
                Catch ex As Exception

                End Try
              
                Exit Sub
            Catch ex As System.Exception
                Throw ex
            End Try
        End Sub

        Public Function Brief() As String
            Return Name
        End Function


        Public Overrides ReadOnly Property CanChange() As Boolean
            Get
                Dim test As Boolean
                test = True
                If Not Parent Is Nothing Then
                    test = Parent.CanChange
                End If
                If test Then
                    test = (IsLocked < LATIR2.Session.LockStyle.ExternalLockSession)
                End If
                Return test
            End Get

        End Property

        Public Property IsLocked() As LATIR2.Session.LockStyle
            Get
                If m_IsLocked <> LATIR2.Session.LockStyle.LockSession And m_IsLocked <> LATIR2.Session.LockStyle.LockPermanent Then CheckLock()
                Return m_IsLocked
            End Get
            Set(ByVal Value As LATIR2.Session.LockStyle)
                m_IsLocked = Value
            End Set

        End Property

        Private LastCheckTime As Date
        Private Sub CheckLock()
            If Now < LastCheckTime.AddSeconds(10) Then Exit Sub
            Dim nv As LATIR2.NamedValues, LockType As Long
            nv = New LATIR2.NamedValues
            nv.Add("CURSESSION", Session.GetProvider.ID2Param(Session.SessionID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("ROWID", Session.GetProvider.ID2Param(ID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("IsLocked", LockType, DbType.Int32, ParameterDirection.Output)
            Try
                Session.Exec(Session.KernelPrefix & "INSTANCE_ISLOCKED", nv)
                m_IsLocked = CType(Int16.Parse(nv.Item("ISLocked").Value.ToString), LATIR2.Session.LockStyle)
                nv = Nothing
                LastCheckTime = Now
            Catch
            End Try
        End Sub
        Public Function LockResource(Optional ByVal Permanent As Boolean = False) As Boolean

            Dim OK As Boolean
            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues

            nv.Add("CURSESSION", Session.GetProvider.ID2Param(Session.SessionID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("ROWID", Session.GetProvider.ID2Param(ID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            Try

                If Not Permanent Then
                    nv.Add("LOCKMODE", 1, DbType.Int16)
                Else
                    nv.Add("LOCKMODE", 2, DbType.Int16)
                End If
                OK = Session.Exec(Session.KernelPrefix & "INSTANCE_LOCK", nv)
                If OK Then
                    If Permanent Then m_IsLocked = LATIR2.Session.LockStyle.LockPermanent Else m_IsLocked = LATIR2.Session.LockStyle.LockSession
                Else
                    m_IsLocked = LATIR2.Session.LockStyle.NoLock
                End If
                Return (True)
            Catch ex As System.Exception
                nv = Nothing
                Return False
            End Try
        End Function
        Public Function UnLockResource() As Boolean
            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues
            nv.Add("CURSESSION", Session.GetProvider.ID2Param(Session.SessionID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("ROWID", Session.GetProvider.ID2Param(ID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            Try
                Session.Exec(Session.KernelPrefix & "INSTANCE_UNLOCK", nv)
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
            nv.Add("CURSESSION", Session.GetProvider.ID2Param(Session.SessionID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("INSTANCEID", Session.GetProvider.ID2Param(ID), Session.GetProvider.ID2DbType(), Session.GetProvider.ID2Size())
            nv.Add("LockMode", notLocked, DbType.Int16)
            notLocked = 0
            Try
                Session.Exec(Session.KernelPrefix & "INSTANCE_HCL", nv)
                If Int16.Parse(nv.Item("LockMode").Value.ToString) = 0 Then
                    Return True
                Else
                    Return False
                End If
                nv = Nothing
            Catch
            End Try
        End Function


        Public Sub XMLLoad(ByVal node As XmlNode, Optional ByVal LoadMode As Integer = 0)

            Dim anode As XmlElement

            Try
                If node.Name <> "APPLICATION" Then
                    anode = CType(node.FirstChild, XmlElement)
                Else
                    anode = CType(node, XmlElement)
                End If
                If TypeName <> anode.Attributes("TYPENAME").Value Then Exit Sub

                'MsgBox("ÈÑÏÐÀÂÈÒÜ ÇÀÃÐÓÇÊÓ ÁËÎÊÈÐÎÂÎÊ")
                'm_IsLocked = CType(Int16.Parse(anode.Attributes("IsLocked").Value), LATIR2.Session.LockStyle)
                'If m_IsLocked > 2 Then m_IsLocked = 0

                m_ID = New System.Guid(anode.Attributes("ID").Value)
                m_Name = anode.Attributes("NAME").Value
                If Not anode.Attributes("STATUS") Is Nothing Then

                    Dim tmpguid As System.Guid
                    tmpguid = New System.Guid(anode.Attributes("STATUS").Value)
                    If Not tmpguid.Equals(System.Guid.Empty) Then
                        SetStatus(tmpguid)
                    End If
                End If
                If Not anode.Attributes("SecureStyleID") Is Nothing Then
                    Dim tmpguid As System.Guid
                    tmpguid = New System.Guid(anode.Attributes("SecureStyleID").Value)

                    If Not tmpguid.Equals(System.Guid.Empty) Then
                        Secure(tmpguid)
                    End If
                End If
                XMLLoadCollections(anode, LoadMode)
            Catch
            End Try
        End Sub

        Protected MustOverride Sub XMLLoadCollections(ByVal node As XmlNode, Optional ByVal LoadMode As Integer = 0)

        Public Sub XMLSave(ByVal node As XmlElement, ByVal Xdom As XmlDocument)
            Dim anode As XmlElement
            Try
                anode = Xdom.CreateElement("APPLICATION")
                anode.SetAttribute("ID", m_ID.ToString)
                anode.SetAttribute("TYPENAME", TypeName)
                anode.SetAttribute("NAME", m_Name)
                'anode.SetAttribute("IsLocked", m_IsLocked.ToString())
                anode.SetAttribute("IsLocked", m_IsLocked.ToString())
                anode.SetAttribute("WorkOffline", "False")
                anode.SetAttribute("STATUS", StatusID.ToString())
                anode.SetAttribute("SecureStyleID", SecureStyleID.ToString())

                node.AppendChild(anode)
                XMLSaveCollections(anode, Xdom)
            Catch
            End Try
        End Sub

        Public MustOverride Sub XMLSaveCollections(ByVal node As XmlElement, ByVal Xdom As XmlDocument)

        Public Sub New()
            m_AutoLoadPart = True
        End Sub

        Public Overridable ReadOnly Property CountOfParts() As Long
            Get
                Return 0
            End Get
        End Property

        Public Overridable Function GetDocCollection_Base(ByVal Index As Long) As DocCollection_Base
            Return Nothing
        End Function


        Public Function AvailableStatusDT() As DataTable
            Dim dt As DataTable
            Dim dc As DataColumn
            dt = New DataTable
            dc = New DataColumn("ID", GetType(System.Guid))
            dt.Columns.Add(dc)
            dc = New DataColumn("NAME", GetType(System.String))
            dt.Columns.Add(dc)

            FillStatusDT(dt)
            Return dt


        End Function

        Protected Overridable Sub FillStatusDT(ByRef DT As DataTable)
            Dim tmpDT As DataTable, i As Int32, dr As DataRow
            tmpDT = Session.GetData("select  objecttype.name tname ,A.name fromST, A.objstatusid fromSTID, B.name ToSt, B.objstatusid ToSTID from objstatus A " & _
                " join objecttype on A.parentstructrowid=objecttype.objecttypeid" & _
                " join nextstate on A.objstatusid =nextstate.parentstructrowid" & _
                " join objstatus B on nextstate.TheState = B.objstatusid " & _
                " where objecttype.name='" & TypeName & "' and A.objstatusid='" & StatusID.ToString() & "'")

            For i = 0 To tmpDT.Rows.Count - 1
                dr = DT.NewRow
                dr("ID") = tmpDT.Rows(i)("ToSTID")
                dr("NAME") = tmpDT.Rows(i)("ToST")
                DT.Rows.Add(dr)
            Next
        End Sub

        Public Function HasStatuses() As Boolean
            Dim tmpDT As DataTable
            tmpDT = Session.GetData("select  objecttype.name tname ,A.name , A.objstatusid  from objstatus A " & _
            " join objecttype on A.parentstructrowid=objecttype.objecttypeid  where objecttype.name='" & TypeName & "'")
            Return (tmpDT.Rows.Count > 0)
        End Function

        Public Function StatusList() As System.Data.DataTable
            Dim tmpDT As DataTable
            Try
                tmpDT = Session.GetData("select objstatus.* from objstatus join objecttype on objstatus.parentstructrowid=objecttype.objecttypeid  where objecttype.name='" & TypeName & "'")
            Catch ex As Exception
                tmpDT = Nothing
            End Try
            Return tmpDT
        End Function

        Public Overrides Sub Dispose()

        End Sub

        Public Overrides Property Parent As DocCollection_Base
            Get
                Return Nothing
            End Get
            Set(value As DocCollection_Base)

            End Set
        End Property
    End Class
    End Namespace