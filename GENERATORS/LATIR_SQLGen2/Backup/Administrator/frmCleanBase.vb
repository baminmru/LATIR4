Option Strict Off
Option Explicit On
Friend Class frmCleanBaseTool
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdCleanBase_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCleanBase.Click
		Dim i As Integer
		If MsgBox("Внимание, все данные по отмеченным типам документов будут удалены!" & vbCrLf & "Удалить?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ВНИМАНИЕ") = MsgBoxResult.Yes Then
			For i = 0 To lstTypes.Items.Count - 1
				If lstTypes.GetItemChecked(i) Then
					TruncateType(model.objectType.item(VB6.GetItemData(lstTypes, i)))
				End If
			Next 
		End If
	End Sub
	
	Private Sub frmCleanBaseTool_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadTypes(False)
	End Sub
	Private Sub loadTypes(ByRef ObjOnly As Boolean)
		lstTypes.Items.Clear()
		If (ObjOnly) Then
			model.objectType.Sort = "Name"
		Else
			model.objectType.Sort = "Comment"
		End If
        Dim i As Integer
        Dim pn As String
        For i = 1 To model.OBJECTTYPE.Count

            With model.OBJECTTYPE.Item(i)
                pn = CType(.Package, MTZMetaModel.MTZMetaModel.MTZAPP).Name
                If (ObjOnly) Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object model.objectType.item(i).package.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstTypes.Items.Add(.Name & " (" & pn & "->" & .the_Comment & ")")
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object model.objectType.item().package.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstTypes.Items.Add(pn & "->" & .the_Comment)
                End If
                'UPGRADE_ISSUE: ListBox property lstTypes.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                VB6.SetItemData(lstTypes, i - 1, i)
            End With
        Next
	End Sub
	
	Private Sub cmdSelAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelAll.Click
		Dim i As Integer
		For i = 0 To lstTypes.Items.Count - 1
			lstTypes.SetItemChecked(i, True)
		Next 
	End Sub
	
	Private Sub cmdClearAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClearAll.Click
		Dim i As Integer
		For i = 0 To lstTypes.Items.Count - 1
			lstTypes.SetItemChecked(i, False)
		Next 
	End Sub
	
	
    Private Sub TruncateType(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        TruncatePart(ot.PART)
        On Error GoTo bye
        txtLog.Text = txtLog.Text & vbCrLf & "delete from instance where objtype='" & ot.Name & "'" & vbCrLf & "go"
        If chkNoExec.CheckState = System.Windows.Forms.CheckState.Unchecked Then
            Manager.Session.GetData("delete from instance where objtype='" & ot.Name & "'")
        End If
        Me.Text = "objtype='" & ot.Name & "'"
        System.Windows.Forms.Application.DoEvents()
        GoTo nxt
bye:
        txtLog.Text = txtLog.Text & vbCrLf & Err.Description
        Debug.Print(Err.Description)
        Resume nxt
nxt:
    End Sub


    Private Sub TruncatePart(ByRef pts As MTZMetaModel.MTZMetaModel.PART_col)
        Dim i As Integer
        For i = 1 To pts.Count
            TruncatePart(pts.Item(i).PART)

            On Error GoTo bye
            txtLog.Text = txtLog.Text & vbCrLf & "delete from " & pts.Item(i).Name & vbCrLf & "go"
            If chkNoExec.CheckState = System.Windows.Forms.CheckState.Unchecked Then
                Manager.Session.GetData("delete from " & pts.Item(i).Name)
            End If
            Me.Text = "delete from " & pts.Item(i).Name
            System.Windows.Forms.Application.DoEvents()
            GoTo nxt
bye:
            txtLog.Text = txtLog.Text & vbCrLf & Err.Description
            Debug.Print(Err.Description)
            Resume nxt
nxt:
        Next
    End Sub
End Class