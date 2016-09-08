Option Explicit On

Imports System
Imports System.Data
Imports System.xml
Imports System.Data.Common
Imports LATIR2.Utils

Namespace Document
    Public MustInherit Class DocCollection_Base
        Implements IDisposable


        Private mCol As Collection
        Private m_Application As Doc_Base
        Private m_Parent As All_Base
        Private m_Filter As String
        Private m_IsLocked As LATIR2.Session.LockStyle
        Private LastCheckTime As Date
        Private m_LastLang As String
        Private _sort As String
        Private SortDV As DataView

        Public Sub New()
            MyBase.New()
            mCol = New Collection
        End Sub


        Protected MustOverride Function CreateDataTable() As DataTable
        Public MustOverride Function ChildPartName() As String
        Public Overridable Function IsTree() As Boolean
            Return False
        End Function
        Protected MustOverride Function NewItem() As DocRow_Base

        Protected mFieldList As String = "*"
        Public Overridable Function FieldList() As String
            Return mFieldList
        End Function



        Public Property Sort() As String
            Get
                Return _sort
            End Get
            Set(ByVal value As String)
                _sort = value
                ReSort()
            End Set
        End Property


        Private mInResort As Boolean = False

        Public Sub ReSort()
            If _sort = "" Then
                SortDV = Nothing
            Else
                If mInResort Then Exit Sub
                mInResort = True
                Dim tmpDT As DataTable = GetDataTable()
                Try

                    SortDV = tmpDT.DefaultView
                    SortDV.Sort = _sort
                Catch
                    SortDV = tmpDT.DefaultView
                End Try
                If SortDV.Count <> tmpDT.Rows.Count Then
                    SortDV = Nothing
                End If
                mInResort = False
            End If
        End Sub

        Public Function GetDataTable() As DataTable
            Dim dt As DataTable, i As Long
            dt = CreateDataTable()

            For i = 1 To Count
                CType(mCol.Item(i), LATIR2.Document.DocRow_Base).FillDataTable(dt)
            Next

            Return dt
        End Function


        Public Property Parent() As All_Base
            Get
                Return m_Parent
            End Get
            Set(ByVal Value As All_Base)
                m_Parent = Value
            End Set
        End Property

        Public Property Application() As Doc_Base
            Get
                Return m_Application
            End Get
            Set(ByVal Value As Doc_Base)
                m_Application = Value
            End Set
        End Property


        Public Property Filter() As String
            Get
                Return m_Filter
            End Get
            Set(ByVal Value As String)
                m_Filter = Value
                Refresh()
            End Set
        End Property

        Private Sub CloseParents()
            m_Application = Nothing
            m_Parent = Nothing
        End Sub


  

        Public Overridable Function Add(Optional ByVal ID As String = "") As DocRow_Base
            Dim LID As Guid
            Dim o As DocRow_Base
            If ID = "" Then
                LID = System.Guid.NewGuid
            Else
                LID = New Guid(ID)
            End If
            Try
                If mCol.Count > 0 Then
                    If Not mCol.Contains(ID2String(LID.ToString())) Then
                        o = NewItem()
                        o.ID = LID
                        o.Parent = Me
                        o.Application = Me.Application
                        Me.Application.AddToCash(ChildPartName() & ID2String(LID.ToString), o)

                        mCol.Add(o, ID2String(o.ID.ToString))
                        Return o
                    Else
                        Return CType(mCol.Item(ID2String(LID.ToString())), LATIR2.Document.DocRow_Base)

                    End If
                Else
                    o = NewItem()
                    o.ID = LID
                    o.Parent = Me
                    o.Application = Me.Application
                    Me.Application.AddToCash(ChildPartName() & ID2String(LID.ToString), o)

                    mCol.Add(o, ID2String(o.ID.ToString))
                    Return o
                End If

            Catch
                Return Nothing
            End Try
        End Function

        Public Function Item(ByVal ID As Object) As DocRow_Base
            Try


                If IsNumeric(ID) Then
                    If SortDV Is Nothing Then
                        Return CType(mCol.Item(ID), LATIR2.Document.DocRow_Base)
                    Else
                        If SortDV.Count <> mCol.Count Then
                            ReSort()
                        End If

                        Return CType(mCol.Item(ID2String(SortDV(CType(ID, Integer) - 1)("ID").ToString())), LATIR2.Document.DocRow_Base)
                    End If

                End If
                ID = ID2String(ID.ToString)
                If mCol.Contains(ID.ToString) Then
                    Return CType(mCol.Item(ID), LATIR2.Document.DocRow_Base)
                End If
            Catch
            End Try
            Return Nothing
        End Function

        Public Function FindObject(ByVal Table As String, ByVal InstID As String) As Object
            Dim m_FindObject As Object, i As Long
            Dim obj As DocRow_Base

           

            m_FindObject = Nothing
            If Table = "" Then Return Nothing
            If InstID = "" Then Return Nothing
            If InstID = System.Guid.Empty.ToString Then Return Nothing
            If Not Application.Session.IsDescendant(Table, ChildPartName) Then Return Nothing
            If Table.ToLower = ChildPartName().ToLower Then
                obj = Item(InstID)
                m_FindObject = obj
                If Not m_FindObject Is Nothing Then GoTo OK
            End If
            For i = 1 To mCol.Count
                obj = Item(i)
                m_FindObject = obj.FindObject(Table, InstID)
                If Not m_FindObject Is Nothing Then Exit For
            Next
OK:
            Return m_FindObject
            m_FindObject = Nothing
        End Function

        Public ReadOnly Property Count() As Long
            Get
                Return (mCol.Count)
            End Get
        End Property

        Public Sub Remove(ByVal vntIndexKey As Object)
            Try
                Dim obj As DocRow_Base

                If IsNumeric(vntIndexKey) Then
                    obj = CType(mCol.Item(vntIndexKey), DocRow_Base)
                Else
                    obj = CType(mCol.Item(ID2String(vntIndexKey.ToString)), DocRow_Base)
                End If
                'obj = CType(mCol.Item(vntIndexKey), DocRow_Base)
                Try
                    If Not Me.Application Is Nothing Then
                        Me.Application.RemoveFromCash(ChildPartName() & ID2String(obj.ID.ToString))
                    End If
                Catch ex As Exception

                End Try

                If IsNumeric(vntIndexKey) Then
                    mCol.Remove(CType(vntIndexKey, Integer))
                Else
                    mCol.Remove(ID2String(vntIndexKey.ToString))
                End If
            Catch
            End Try
        End Sub

        Public Function Update(ByVal vntIndexKey As Object) As Boolean
            Dim obj As DocRow_Base

            If IsNumeric(vntIndexKey) Then
                obj = CType(mCol.Item(vntIndexKey), DocRow_Base)
            Else
                obj = CType(mCol.Item(ID2String(vntIndexKey.ToString)), DocRow_Base)
            End If

            If Not obj Is Nothing Then
                Return obj.Save
            Else
                Return False
            End If
        End Function

        Public Function Delete(ByVal vntIndexKey As Object) As Boolean
            Try
                Dim obj As DocRow_Base

                If IsNumeric(vntIndexKey) Then
                    obj = CType(mCol.Item(vntIndexKey), DocRow_Base)
                Else
                    obj = CType(mCol.Item(ID2String(vntIndexKey.ToString)), DocRow_Base)
                End If

                If obj Is Nothing Then Return False
                If obj.Delete Then

                    If IsNumeric(vntIndexKey) Then
                        mCol.Remove(CType(vntIndexKey, Int16))
                    Else
                        mCol.Remove(ID2String(vntIndexKey.ToString))
                    End If
                    Return True
                End If

            Catch ex As system.Exception
                Throw ex
            End Try
            Return False
        End Function

        Public Sub Refresh()
            Dim mcol2 As Collection
            mcol2 = mCol
            mCol = Nothing
            mCol = New Collection
            Dim rs As DataTable
            Dim objrs2 As DataTable

            Dim o As DocRow_Base
            Dim tmpParent As All_Base
            Dim tID As Guid
            Dim SSID As Guid


            tmpParent = Parent
            If Not Parent.parent Is Nothing Then
                While tmpParent.Parent.ChildPartName = Me.ChildPartName
                    If Not tmpParent.Parent.Parent Is Nothing Then
                        tmpParent = tmpParent.Parent.Parent
                    Else
                        Exit While
                    End If
                    If tmpParent.Parent Is Nothing Then
                        Exit While
                    End If
                End While
            End If


            If Application.AutoLoadPart Then
                If Not Parent.Parent Is Nothing Then
                    If Parent.Parent.GetType().Name = Me.GetType.Name() Then
                        rs = Application.Session.GetRowsDT(ChildPartName, FieldList(), tmpParent.ID.ToString, Parent.ID.ToString, Filter)
                    Else
                        If Me.IsTree Then
                            rs = Application.Session.GetRowsDT(ChildPartName, FieldList(), tmpParent.ID.ToString, "null", Filter)
                        Else
                            rs = Application.Session.GetRowsDT(ChildPartName, FieldList(), tmpParent.ID.ToString, , Filter)
                        End If

                    End If
                Else
                    If Me.IsTree Then
                        rs = Application.Session.GetRowsDT(ChildPartName, FieldList(), tmpParent.ID.ToString, "null", Filter)
                    Else
                        rs = Application.Session.GetRowsDT(ChildPartName, FieldList(), tmpParent.ID.ToString, , Filter)
                    End If

                End If
            Else
                If Not Parent.Parent Is Nothing Then

                    If Parent.Parent.GetType().Name = Me.GetType.Name() Then
                        rs = Application.Session.GetIDsDT(ChildPartName, tmpParent.ID.ToString, Parent.ID.ToString, Filter)
                    Else
                        If Me.IsTree Then
                            rs = Application.Session.GetIDsDT(ChildPartName, tmpParent.ID.ToString(), "null", Filter)
                        Else
                            rs = Application.Session.GetIDsDT(ChildPartName, tmpParent.ID.ToString(), "", Filter)
                        End If
                    End If
                Else
                    If Me.IsTree Then

                        rs = Application.Session.GetIDsDT(ChildPartName, tmpParent.ID.ToString(), "null", Filter)
                    Else
                        rs = Application.Session.GetIDsDT(ChildPartName, tmpParent.ID.ToString(), "", Filter)
                    End If

                End If

            End If
            If mcol2 Is Nothing Then mcol2 = New Collection
            Dim idx As Integer
            If Not rs Is Nothing Then ' wrong database structure
                For idx = 0 To rs.Rows.Count - 1
                    'While rs.Read
                    If Application.AutoLoadPart Then
                        Try
                            tID = New System.Guid(rs.Rows(idx)(ChildPartName() & "ID").ToString())
                        Catch ex As Exception
                            ' lightweight reference 
                            tID = Utils.Int2GUID(Integer.Parse(rs.Rows(idx)(ChildPartName() & "ID").ToString()))
                        End Try

                    Else
                        Try
                            tID = New System.Guid(rs.Rows(idx)("ID").ToString())
                        Catch ex As Exception
                            tID = Utils.Int2GUID(Integer.Parse(rs.Rows(idx)("ID").ToString()))
                        End Try

                    End If
                    Try
                        If Not (rs.Rows(idx)("SecurityStyleID") Is DBNull.Value) Then
                            SSID = New System.Guid(rs.Rows(idx)("SecurityStyleID").ToString())
                        End If
                    Catch ex As Exception
                        SSID = Guid.Empty
                    End Try
                   
                    If Not mcol2.Contains(ID2String(tID.ToString)) Then
                        o = Add(ID2String(tID.ToString))
                        o.ID = tID
                        If Application.AutoLoadPart Then
                            o.Unpack(rs.Rows(idx))
                            'MLF'
                            m_LastLang = Application.Session.Language
                            If Application.Session.Language <> "" Then
                                objrs2 = Application.Session.GetData("select * from " + ChildPartName() + "_" + Application.Session.Language + " where " + ChildPartName() + "id=" + Utils.GUID2String(Application.Session, tID) + "")
                                If Not objrs2 Is Nothing Then
                                    If objrs2.Rows.Count > 0 Then
                                        o.Unpack(objrs2.Rows(0))
                                    End If
                                End If
                            End If
                            'E_MLF'
                        End If
                    Else
                        o = CType(mcol2.Item(ID2String(tID.ToString)), LATIR2.Document.DocRow_Base)
                        If Application.AutoLoadPart Then
                            o.CleanFields()
                            o.Unpack(rs.Rows(idx))
                            'MLF'
                            m_LastLang = Application.Session.Language
                            If Application.Session.Language <> "" Then
                                objrs2 = Application.Session.GetData("select * from " + ChildPartName() + "_" + Application.Session.Language + " where " + ChildPartName() + "id=" + Utils.GUID2String(Application.Session, tID) + "")
                                If Not objrs2 Is Nothing Then
                                    If objrs2.Rows.Count > 0 Then
                                        o.Unpack(objrs2.Rows(0))
                                    End If
                                End If
                            End If
                            'E_MLF'
                        End If
                        mCol.Add(o, ID2String(tID.ToString))
                        mcol2.Remove(ID2String(tID.ToString))
                    End If
                    'o.SecureStyleID = SSID

                    'End While
                Next
                'rs.Dispose()
                rs = Nothing

            End If ' rs is nothing
            For idx = 1 To mcol2.Count
                o = CType(mcol2.Item(idx), LATIR2.Document.DocRow_Base)
                o.Dispose()
            Next
            mcol2 = Nothing
        End Sub

        ' может ли быть изменено
        Public Function CanChange() As Boolean
            Dim test As Boolean
            If Not Parent Is Nothing Then
                test = Parent.CanChange
            End If
            If Not test Then
                test = (IsLocked < LATIR2.Session.LockStyle.ExternalLockSession)
            End If
            Return test
        End Function

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
            nv.Add("ROWID", Parent.ID, Application.Session.GetProvider.ID2DbType(), Application.Session.GetProvider.ID2Size())
            nv.Add("IsLocked", LockType, DbType.Int16, ParameterDirection.Output)
            Try
                Application.Session.Exec("PARTVIEW_ISLOCKED", nv)
                m_IsLocked = CType(nv.Item("ISLocked").Value, LATIR2.Session.LockStyle)
                nv = Nothing
                LastCheckTime = Now
            Catch
            End Try
        End Sub
        Public Function LockResource(Optional ByVal Permanent As Boolean = False) As Boolean
            Dim OK As Boolean
            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues
            nv.Add("ROWID", Parent.ID, Application.Session.GetProvider.ID2DbType(), Application.Session.GetProvider.ID2Size())
            Try
                If Not Permanent Then
                    nv.Add("LOCKMODE", 1, DbType.Int16)
                Else
                    nv.Add("LOCKMODE", 2, DbType.Int16)
                End If
                OK = Application.Session.Exec("PARTVIEW_LOCK", nv)
                If OK Then
                    If Permanent Then m_IsLocked = LATIR2.Session.LockStyle.LockPermanent Else m_IsLocked = LATIR2.Session.LockStyle.LockSession
                Else
                    m_IsLocked = LATIR2.Session.LockStyle.NoLock
                End If
                Return True
            Catch ex As system.Exception
                nv = Nothing
                Return False
            End Try
        End Function
        Public Function UnLockResource() As Boolean
            Dim nv As LATIR2.NamedValues
            nv = New LATIR2.NamedValues
            nv.Add("ROWID", Parent.ID, Application.Session.GetProvider.ID2DbType(), Application.Session.GetProvider.ID2Size())
            Try
                Application.Session.Exec("PARTVIEW_UNLOCK", nv)

                m_IsLocked = LATIR2.Session.LockStyle.NoLock
                Return True
            Catch ex As system.Exception
                nv = Nothing
                Return False
            End Try
        End Function
        Public Function CanLock() As Boolean
            Dim nv As LATIR2.NamedValues, notLocked As Long
            nv = New LATIR2.NamedValues
            nv.Add("ROWID", Parent.ID.ToString() + ChildPartName(), DbType.String)
            nv.Add("LockMode", notLocked, DbType.Int16, ParameterDirection.Output)
            notLocked = 0
            Try
                Application.Session.Exec("PARTVIEW_HCL", nv)
                If Int16.Parse(nv.Item("LockMode").Value.ToString) = 0 Then
                    Return True
                Else
                    Return False
                End If
                nv = Nothing
            Catch
                Return False
            End Try
        End Function
        Public Sub Dispose() Implements System.IDisposable.Dispose
            Try
                CloseParents()
                Dim i As Long
                Dim o As DocRow_Base
                Try
                    For i = 1 To Count
                        o = CType(mCol.Item(i), DocRow_Base)
                        o.Dispose()
                        o.CloseParents()
                    Next
                Catch ex As Exception

                End Try
               
                Try
                    While Count > 0
                        Remove(1)
                    End While
                Catch ex As Exception

                End Try
               
                SortDV = Nothing
            Catch ex As Exception

            End Try
           
        End Sub

        Public Sub XMLSave(ByRef ParentNode As XmlElement, ByVal Xdom As XmlDocument)
            Dim o As DocRow_Base
            Dim i As Long
            Dim pnode As XmlElement
            pnode = Xdom.CreateElement(ChildPartName() & "_COL")
            pnode.SetAttribute("IsLocked", CStr(m_IsLocked))

            Dim node As XmlElement
            ParentNode.AppendChild(pnode)
            For i = 1 To mCol.Count
                o = CType(mCol.Item(i), DocRow_Base)
                node = Xdom.CreateElement(ChildPartName())
                pnode.AppendChild(node)
                o.XMLSave(node, Xdom)
            Next
        End Sub


        Public Sub BatchUpdate()
            Try
                Dim i As Long
again:
                For i = 1 To Count
                    If Item(i) Is Nothing Then Exit For
                    If Item(i).Deleted Then
                        If Delete(i) Then GoTo again
                    Else
                        Item(i).BatchUpdate()
                    End If
                Next
            Catch ex As System.Exception
            End Try
        End Sub
        Public Sub XMLLoad(ByRef NodeList As XmlNodeList, Optional ByVal LoadMode As Integer = 0)
            Try

                Dim node As XmlElement
                Dim pnode As XmlElement
                pnode = CType(NodeList.Item(0), XmlElement) ' was - 1
                m_IsLocked = CType(pnode.Attributes.GetNamedItem("IsLocked").Value, Session.LockStyle)
                NodeList = pnode.SelectNodes(ChildPartName)
                Dim bufcol As Collection
                bufcol = Nothing
                If LoadMode = 1 Then
                    bufcol = New Collection
                End If
                Dim j As Integer
                For j = 0 To NodeList.Count - 1 'was - For j = 1 To NodeList.Count
                    node = CType(NodeList.Item(j), XmlElement)

                    ' append mode
                    If LoadMode = 0 Then
                        If Item(node.Attributes.GetNamedItem("ID").Value) Is Nothing Then
                            Add(node.Attributes.GetNamedItem("ID").Value).XMLLoad(node, LoadMode)
                        Else
                            Item(node.Attributes.GetNamedItem("ID").Value).XMLLoad(node, LoadMode)
                        End If
                    End If
                    ' replace mode
                    If LoadMode = 1 Then
                        If Item(node.Attributes.GetNamedItem("ID").Value) Is Nothing Then
                            Add(node.Attributes.GetNamedItem("ID").Value).XMLLoad(node, LoadMode)
                        Else
                            Item(node.Attributes.GetNamedItem("ID").Value).XMLLoad(node, LoadMode)
                        End If
                        bufcol.Add(Item(node.Attributes.GetNamedItem("ID").Value), node.Attributes.GetNamedItem("ID").Value)
                    End If
                    ' copy with new ID mode
                    If LoadMode = 2 Then
                        Add().XMLLoad(node, LoadMode)
                    End If
                Next
                ' remove extra items from collection
                If LoadMode = 1 Then
                    Dim i As Long
                    ' remove existing
removeAgain:
                    For i = 1 To Count
                        If bufcol.Item(Item(i).ID.ToString()) Is Nothing Then
                            Delete(Item(i).ID.ToString())
                            GoTo removeAgain
                        End If
                    Next
                    bufcol = Nothing
                End If
            Catch
            End Try
        End Sub

        Public Overridable ReadOnly Property CountOfParts() As Long
            Get
                Return 0
            End Get
        End Property

        Public Overridable Function GetDocCollection_Base(ByVal Index As Long) As DocCollection_Base
            Return Nothing
        End Function


    End Class
End Namespace