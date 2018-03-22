Option Strict Off
Option Explicit On
Friend Class frmMergeRowTool
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdDocToDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDocToDel.Click
        Dim ID As Guid
		Dim Brief As String
        Dim P As MTZMetaModel.MTZMetaModel.PART
        If txtPart.Tag = "" Then
            MsgBox("Необходимо выбрать раздел")
            Exit Sub
        End If
        P = model.FindRowObject("PART", txtPart.Tag)

        If guiManager.GetReferenceDialog(P.Name, "", Guid.Empty, ID, Brief) Then
            txtDocToDel.Tag = ID
            txtDocToDel.Text = Brief
        End If
    End Sub

    Private Sub cmdGo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGo.Click

        Command1.Enabled = False
        Command1.Visible = False

        Dim i As Integer
        Dim objToDel As Object
        Dim objNewDoc As Object
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        Dim P As MTZMetaModel.MTZMetaModel.PART

        If txtPart.Tag = "" Then
            MsgBox("Необходимо выбрать раздел")
            Exit Sub
        End If



        If txtDocToDel.Tag = "" Then
            MsgBox("Необходимо выбрать объект для замены")
            Exit Sub
        End If

        If txtNewDoc.Tag = "" Then
            MsgBox("Необходимо выбрать объект на который будут заменены ссылки")
            Exit Sub
        End If

        P = model.FindRowObject("PART", txtPart.Tag)

        objToDel = model.FindRowObject(P.Name, txtDocToDel.Tag)
        objNewDoc = model.FindRowObject(P.Name, txtNewDoc.Tag)

        pb.Minimum = 0
        pb.Value = 0
        pb.Maximum = model.OBJECTTYPE.Count
        pb.Visible = True

        For i = 1 To model.OBJECTTYPE.Count
            MergeRow(model.OBJECTTYPE.Item(i).PART, objToDel, objNewDoc, P)
            pb.Value = i
        Next

        If chkDel.CheckState = System.Windows.Forms.CheckState.Checked Then
            On Error GoTo bye
            'UPGRADE_WARNING: Couldn't resolve default property of object objToDel.Delete. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objToDel.Delete()
        End If
        pb.Visible = False
        txtOut.Visible = True
        Command1.Enabled = True
        Command1.Visible = True

        MsgBox("Замена ссылки завершена")
        Exit Sub
bye:
        MsgBox(Err.Description)
        pb.Visible = False
        Command1.Enabled = True
        Command1.Visible = True
    End Sub

    Private Sub cmdNewDoc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNewDoc.Click
        Dim ID As Guid
        Dim Brief As String
        Dim P As MTZMetaModel.MTZMetaModel.PART

        If txtPart.Tag = "" Then
            MsgBox("Необходимо выбрать раздел")
            Exit Sub
        End If

        P = model.FindRowObject("PART", txtPart.Tag)

        If guiManager.GetReferenceDialog(P.Name, "", Guid.Empty, ID, Brief) Then
            txtNewDoc.Tag = ID
            txtNewDoc.Text = Brief
        End If
    End Sub


    Private Sub MergeRow(ByRef pcol As MTZMetaModel.MTZMetaModel.PART_col, ByRef DelObj As Object, ByRef NewObj As Object, ByRef DocPart As MTZMetaModel.MTZMetaModel.PART)
        Dim i As Integer
        Dim j As Integer
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As String
        Dim ChangeIt As Boolean
        Dim UpdateToNull As Boolean
        For i = 1 To pcol.Count
            For j = 1 To pcol.item(i).Field.Count
                ChangeIt = False
                UpdateToNull = False
                fld = pcol.item(i).Field.item(j)
                ft = fld.FieldType
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        If fld.RefToPart Is DocPart Then
                            ChangeIt = True
                        End If
                    End If
                End If

                If UCase(ft.Name) = "ID" Then
                    ChangeIt = True
                End If
                If ChangeIt Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object DelObj.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object NewObj.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    s = "update " & pcol.item(i).Name & " set " & fld.Name & "='" & NewObj.ID & "' where " & fld.Name & "='" & DelObj.ID & "'"
                    On Error Resume Next
                    Manager.Session.GetData(s)
                    txtOut.Text = txtOut.Text & vbCrLf & s
                    If Err.Number > 0 Then
                        txtOut.Text = txtOut.Text & vbCrLf & "--ERROR>>" & Err.Description
                        Err.Clear()
                    End If
                End If
            Next
            MergeRow(pcol.item(i).PART, DelObj, NewObj, DocPart)
        Next
    End Sub
	
	Private Sub cmdPart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPart.Click
        Dim ID As Guid
		Dim Brief As String
        If guiManager.GetReferenceDialog("PART", "", Guid.Empty, ID, Brief) Then
            txtPart.Tag = ID
            txtPart.Text = Brief
        End If
	End Sub
End Class