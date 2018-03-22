Option Strict Off
Option Explicit On
Friend Class frmMergeObjTool
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdDocToDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDocToDel.Click
        Dim ID As Guid
        Dim Brief As String = ""

        If guiManager.GetObjectDialog("", "", ID, Brief) Then
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

        If txtDocToDel.Tag = "" Then
            MsgBox("Необходимо выбрать объект для замены")
            Exit Sub
        End If

        If txtNewDoc.Tag = "" Then
            MsgBox("Необходимо выбрать объект на который будут заменены ссылки")
            Exit Sub
        End If


        objToDel = Manager.GetInstanceObject(txtDocToDel.Tag)
        objNewDoc = Manager.GetInstanceObject(txtNewDoc.Tag)

        If objToDel.TypeName <> objNewDoc.TypeName Then
            If MsgBox("Объекты разного типа, продолжить ?", MsgBoxStyle.YesNo, "Внимание") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        For i = 1 To model.ObjectType.Count
            If UCase(model.ObjectType.item(i).Name) = UCase(objToDel.TypeName) Then
                ot = model.ObjectType.item(i)
                Exit For
            End If
        Next

        pb.Minimum = 0
        pb.Value = 0
        pb.Maximum = model.ObjectType.Count
        pb.Visible = True
        For i = 1 To model.ObjectType.Count
            MergeObj(model.ObjectType.item(i).PART, objToDel, objNewDoc, ot)
            pb.Value = i
        Next

        If chkDel.CheckState = System.Windows.Forms.CheckState.Checked Then
            On Error GoTo bye
            Manager.DeleteInstance(objToDel.ID)
        End If
        pb.Visible = False
        txtOut.Visible = True
        Command1.Enabled = True
        Command1.Visible = True
        Exit Sub
bye:
        MsgBox(Err.Description)
        pb.Visible = False
        Command1.Enabled = True
    End Sub

    Private Sub cmdNewDoc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNewDoc.Click
        Dim ID As Guid
        Dim Brief As String = "" = ""

        If guiManager.GetObjectDialog("", "", ID, Brief) Then
            txtNewDoc.Tag = ID
            txtNewDoc.Text = Brief
        End If
    End Sub


    Private Sub MergeObj(ByRef pcol As MTZMetaModel.MTZMetaModel.PART_col, ByRef DelObj As Object, ByRef NewObj As Object, ByRef DocOT As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Dim i As Integer
        Dim j As Integer
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As String
        Dim ChangeIt As Boolean
        Dim UpdateToNull As Boolean
        For i = 1 To pcol.Count
            For j = 1 To pcol.Item(i).FIELD.Count
                ChangeIt = False
                UpdateToNull = False
                fld = pcol.Item(i).FIELD.Item(j)
                ft = fld.FieldType
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        If fld.RefToType Is Nothing Then
                            ChangeIt = True
                        ElseIf fld.RefToType Is DocOT Then
                           If DelObj.TypeName <> NewObj.TypeName Then
                                ChangeIt = True
                                UpdateToNull = True
                            Else
                                ChangeIt = True
                            End If

                        End If
                    End If
                End If

                If UCase(ft.Name) = "ID" Then
                    ChangeIt = True
                End If
                If ChangeIt Then

                    If UpdateToNull Then
                         s = "update " & pcol.Item(i).Name & " set " & fld.Name & "=null where " & fld.Name & "='" & DelObj.ID & "'"
                    Else
                        s = "update " & pcol.Item(i).Name & " set " & fld.Name & "='" & NewObj.ID & "' where " & fld.Name & "='" & DelObj.ID & "'"
                    End If

                    On Error Resume Next
                    Manager.Session.GetData(s)
                    txtOut.Text = txtOut.Text & vbCrLf & s
                    If Err.Number > 0 Then
                        txtOut.Text = txtOut.Text & vbCrLf & "--ERROR>>" & Err.Description
                        Err.Clear()
                    End If
                    Debug.Print(s)
                End If
            Next
            MergeObj(pcol.Item(i).PART, DelObj, NewObj, DocOT)
        Next
    End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Hide()
	End Sub
End Class