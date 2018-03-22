Public Class frmSetUnique

    Private objectTypes As Hashtable
    Private Sub frmSetUnique_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim dt As System.Data.DataTable
        Dim oID As System.Guid
        Dim i As Long
        dt = Manager.Session.GetRowsExDT("INSTANCE", Manager.Session.GetProvider.InstanceFieldList, "", "", "OBJTYPE='MTZMetaModel'", "")

        objectTypes = New Hashtable

        oID = New Guid(dt.Rows(0)("INSTANCEID").ToString())
        model = CType(Manager.GetInstanceObject(oID), MTZMetaModel.MTZMetaModel.Application)
        model.OBJECTTYPE.Sort = "Name"
        For i = 1 To model.OBJECTTYPE.Count
            objectTypes.Add(model.OBJECTTYPE.Item(i).Name, model.OBJECTTYPE.Item(i))
            chkTypes.Items.Add(model.OBJECTTYPE.Item(i).Name, False)
        Next
    End Sub

    Private Sub cmdMakeUniq_Click(sender As System.Object, e As System.EventArgs) Handles cmdMakeUniq.Click
      
        If (chkTypes.CheckedItems.Count > 0) Then
            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim TypeID As String
            Dim ObjType As MTZMetaModel.MTZMetaModel.OBJECTTYPE

            For j = 0 To chkTypes.CheckedItems.Count - 1
                ObjType = objectTypes.Item(chkTypes.CheckedItems().Item(j))
                TypeID = ObjType.ID.ToString()

                Dim dt As DataTable
                dt = Manager.Session.GetData("select name from part where name like'" + txtPart.Text + "'")
                For i = 0 To dt.Rows.Count - 1
                    For k = 1 To ObjType.PART.Count
                        If ObjType.PART.Item(k).Name = dt.Rows(i)("Name") Then
                            MakeUniqueFor(ObjType.PART.Item(k))
                            Exit For
                        End If
                    Next
                Next

            Next

        Else
            MsgBox("Укажите тип объекта")
        End If
    
    End Sub

    Private Sub MakeUniqueFor(ByRef p As MTZMetaModel.MTZMetaModel.PART)
        Dim i As Integer
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim uc As MTZMetaModel.MTZMetaModel.UNIQUECONSTRAINT
        Dim cf As MTZMetaModel.MTZMetaModel.CONSTRAINTFIELD

        For i = 1 To p.FIELD.Count
            fld = p.FIELD.Item(i)
            If fld.Name.ToLower = txtFld.Text.ToLower Then
                uc = p.UNIQUECONSTRAINT.Add()

                uc.Name = "UC_ " + p.Name + "_" + fld.Name
                uc.TheComment = "Уникальность для " + p.Caption + "." + fld.Caption
                txtOut.Text = uc.Name & vbCrLf & txtOut.Text
                uc.PerParent = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                uc.Save()
                cf = uc.CONSTRAINTFIELD.Add()
                cf.TheField = fld
                cf.Save()
                Exit For
            End If
        Next


    End Sub

End Class