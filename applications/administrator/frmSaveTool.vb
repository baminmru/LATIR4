Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmSaveTool
	Inherits System.Windows.Forms.Form
    Public TypeName_Renamed As String
    Public site_Renamed As String
	Public OK As Boolean
	Public ID As String
	Public Brief As String

	
	'UPGRADE_WARNING: Event cmbType.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbType.SelectedIndexChanged
		Dim i As Integer
        Dim rs As DataTable
        On Error Resume Next
        Dim tt As tmpInst, o As tmpInst
        tt = cmbType.Items(cmbType.SelectedIndex)
        rs = Manager.Session.GetRowsEx("INSTANCE", Manager.Session.GetProvider.InstanceFieldList, "", "", " ObjType='" & tt.ObjType & "'", "order by name")
        i = 0
        lstObj.Items.Clear()
        For i = 0 To rs.Rows.Count - 1
            On Error Resume Next
            o = New tmpInst
            o.ID = New Guid(rs.Rows(i)("InstanceID").ToString)
            o.Name = rs.Rows(i)("Name")
            o.ObjType = rs.Rows(i)("ObjType")
            lstObj.Items.Add(o)


        Next


        rs = Nothing
       
    End Sub







    Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
        On Error Resume Next
        Dim i As Integer
        Dim item As LATIR2.Document.Doc_Base
        Dim fn As String
        If txtPath.Text = "" Then
            MsgBox("Задайте каталог для сохранения")
            Exit Sub
        End If

        Dim xdom As System.Xml.XmlDocument
        Dim ti As tmpInst
        For i = 0 To lstObj.Items.Count - 1
            If lstObj.GetItemChecked(i) Then
                ti = lstObj.Items(i)
                item = Manager.GetInstanceObject(ti.ID)
                If Not item Is Nothing Then

                    If VB.Right(txtPath.Text, 1) = "\" Then
                        fn = txtPath.Text & item.ID.ToString() & ".xml"
                    Else
                        fn = txtPath.Text & "\" & item.ID.ToString() & ".xml"
                    End If

                    item.LockResource(True)
                    xdom = New System.Xml.XmlDocument
                    xdom.LoadXml("<root></root>")
                    item.XMLSave(xdom.LastChild, xdom)
                    xdom.Save(fn)
                    item.UnLockResource()
                    Manager.FreeInstanceObject(item.ID)
                End If
            End If
        Next

        cmbType_SelectedIndexChanged(cmbType, New System.EventArgs())

    End Sub

    Private Sub cmdSelAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelAll.Click
        Dim i As Integer
        For i = 0 To lstObj.Items.Count - 1
            lstObj.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub cmdUnselAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUnselAll.Click
        Dim i As Integer
        For i = 0 To lstObj.Items.Count - 1
            lstObj.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub frmSaveTool_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        lstObj.Items.Clear()
        Dim rs As DataTable
        Dim i As Object


        rs = model.OBJECTTYPE.GetDataTable()


        Dim o As tmpInst

        i = 0
        For i = 0 To rs.Rows.Count - 1
            o = New tmpInst
            o.Name = rs.Rows(i)("the_comment")
            o.ObjType = rs.Rows(i)("Name")
            o.IsSingle = rs.Rows(i)("IsSingleInstance_val")
            o.ID = New Guid(rs.Rows(i)("id").ToString)
            cmbType.Items.Add(o)
        Next


        rs = Nothing

        If cmbType.Items.Count > 0 Then
            cmbType.SelectedIndex = 0

        End If

        txtPath.Text = GetSetting("LATIR4", "ADMIN", "SAVEDOCPATH", "")

    End Sub
	
	
	Private Sub cmdPath_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPath.Click
        Dim path As String = ""

        If cdlgfolder.ShowDialog() = Windows.Forms.DialogResult.OK Then
            path = cdlgfolder.SelectedPath
        End If


        If (path <> "") Then
            txtPath.Text = path & "\"
        End If

        SaveSetting("LATIR4", "ADMIN", "SAVEDOCPATH", txtPath.Text)
    End Sub
End Class