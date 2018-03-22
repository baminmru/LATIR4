Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmSaveTool
	Inherits System.Windows.Forms.Form
	'UPGRADE_NOTE: TypeName was upgraded to TypeName_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public TypeName_Renamed As String
	'UPGRADE_NOTE: site was upgraded to site_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public site_Renamed As String
	Public OK As Boolean
	Public ID As String
	Public Brief As String
	Private inst As Collection
	Private types As Collection
	
	'UPGRADE_WARNING: Event cmbType.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbType.SelectedIndexChanged
		Dim i As Integer
        Dim rs As DataTable
        On Error Resume Next
        inst = New Collection
        Dim tt, o As tmpInst
        tt = types.Item(VB6.GetItemData(cmbType, cmbType.SelectedIndex))
        rs = Manager.Session.GetRowsEx("INSTANCE", "", "", " ObjType='" & tt.ObjType & "'", "order by name")
        i = 0
        lstObj.Items.Clear()
        For i = 0 To rs.Rows.Count - 1
            On Error Resume Next
            o = New tmpInst
            o.ID = rs.Rows(i)("InstanceID")
            o.Name = rs.Rows(i)("Name")
            o.ObjType = rs.Rows(i)("ObjType")

            o.LockUserID = rs.Rows(i)("LockUserID") & ""
            inst.Add(o)

            If o.LockUserID <> "" Then
                lstObj.Items.Add("(заблокирован) " & o.Name)

            Else
                lstObj.Items.Add(o.Name)
            End If

            'UPGRADE_ISSUE: ListBox property lstObj.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
            VB6.SetItemData(lstObj, i, i + 1)
        Next

        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rs = Nothing
        '  If tt.IsSingle = -1 And lstObj.ListCount > 0 Then
        '    cmdCreate.Enabled = False
        '  Else
        '    cmdCreate.Enabled = True
        '  End If
    End Sub







    Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
        On Error Resume Next
        Dim i As Integer
        Dim item As LATIR.Document.Doc_Base
        Dim fn As String
        If txtPath.Text = "" Then
            MsgBox("«адайте каталог дл€ сохранени€")
            Exit Sub
        End If

        Dim xdom As System.XML.XMLDocument
        For i = 0 To lstObj.Items.Count - 1
            If lstObj.GetItemChecked(i) Then

                item = Manager.GetInstanceObject(inst.Item(VB6.GetItemData(lstObj, i)).ID)
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
        Dim n, tn As String

        rs = Manager.Session.GetRowsEx("OBJECTTYPE", , , , "order by Name")

        Dim o As tmpInst
        types = New Collection
        'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        i = 0
        For i = 0 To rs.Rows.Count - 1
            o = New tmpInst
            o.Name = rs.Rows(i)("the_comment")
            o.ObjType = rs.Rows(i)("Name")
            o.IsSingle = rs.Rows(i)("IsSingleInstance")
            types.Add(o)
            cmbType.Items.Add(New VB6.ListBoxItem(o.ObjType & " (" & o.Name & ")", i + 1))
        Next

        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rs = Nothing

        If cmbType.Items.Count > 0 Then
            cmbType.SelectedIndex = 0
            'cmbType_Click
        End If

    End Sub
	
	
	Private Sub cmdPath_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPath.Click
        Dim path As String = ""

        If cdlgfolder.ShowDialog() = Windows.Forms.DialogResult.OK Then
            path = cdlgfolder.SelectedPath
        End If


        If (path <> "") Then
            txtPath.Text = path & "\"
        End If
	End Sub
End Class