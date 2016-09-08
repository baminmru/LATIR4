Imports LATIR2Framework
Public Class frmTest1
    Private P As MTZMetaModel.MTZMetaModel.PART
    Private Sub cmdPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPart.Click
        Dim ID As Guid
        Dim Brief As String = "" = ""
        If guiManager.GetReferenceDialog("PART", "", Guid.Empty, ID, Brief) Then
            txtPart.Tag = ID
            txtPart.Text = Brief
            If Not ID.Equals(Guid.Empty) Then
                P = model.FindRowObject("PART", txtPart.Tag)

            End If
        End If
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim i As Int32
        Dim fmax As Int32
        fmax = 0
        For i = 1 To P.FIELD.Count
            If fmax < P.FIELD.Item(i).Sequence Then
                fmax = P.FIELD.Item(i).Sequence
            End If
        Next

        For i = 1 To 6 * 15
            f = P.FIELD.Add()
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.Name = "M" + i.tostring() + "Value"
            f.Caption = f.Name
            f.FieldType = FieldTypeByName("Numeric")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()

            f = P.FIELD.Add()
            f.Name = "M" + i.ToString() + "Percent"
            f.Caption = f.Name
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.FieldType = FieldTypeByName("Numeric")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()

            f = P.FIELD.Add()
            f.Name = "M" + i.ToString() + "Fakt"
            f.Caption = f.Name
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.FieldType = FieldTypeByName("Numeric")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()

        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim i As Int32
        Dim fmax As Int32
        fmax = 0
        For i = 1 To P.FIELD.Count
            If fmax < P.FIELD.Item(i).Sequence Then
                fmax = P.FIELD.Item(i).Sequence
            End If
        Next

        For i = 1 To 6 * 15
            f = P.FIELD.Add()
            f.Name = "M" + i.ToString() + "Value"
            f.Caption = f.Name
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.FieldType = FieldTypeByName("Numeric")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()

            f = P.FIELD.Add()
            f.Name = "M" + i.ToString() + "Percent"
            f.Caption = f.Name
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.FieldType = FieldTypeByName("Numeric")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()

            f = P.FIELD.Add()
            f.Name = "M" + i.ToString() + "Shifted"
            f.Caption = f.Name
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.FieldType = FieldTypeByName("Numeric")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()

            f = P.FIELD.Add()
            f.Name = "M" + i.ToString() + "Fakt"
            f.Caption = f.Name
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.FieldType = FieldTypeByName("Numeric")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()

        Next
    End Sub

    Private Function FieldTypeByName(ByVal name As String) As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim i As Long
        For i = 1 To model.FIELDTYPE.Count
            ft = model.FIELDTYPE.Item(i)
            If ft.Name.ToUpper() = name.ToUpper() Then
                Return ft
            End If
        Next
        Return Nothing
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim i As Int32
        Dim fmax As Int32
        fmax = 0
        For i = 1 To P.FIELD.Count
            If fmax < P.FIELD.Item(i).Sequence Then
                fmax = P.FIELD.Item(i).Sequence
            End If
        Next

        For i = 1 To 6 * 15
            f = P.FIELD.Add()
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.Name = "M" + i.ToString() + "Value"
            f.Caption = f.Name
            f.FieldType = FieldTypeByName("Numeric")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()

            f = P.FIELD.Add()
            f.Name = "M" + i.ToString() + "Percent"
            f.Caption = f.Name
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.FieldType = FieldTypeByName("Numeric")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim i As Int32
        Dim fmax As Int32
        fmax = 0
        For i = 1 To P.FIELD.Count
            If fmax < P.FIELD.Item(i).Sequence Then
                fmax = P.FIELD.Item(i).Sequence
            End If
        Next

        For i = 1 To 6 * 15
            f = P.FIELD.Add()
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.Name = "M" + i.ToString() + "Value"
            f.Caption = f.Name
            f.FieldType = FieldTypeByName("Boolean")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim i As Int32
        Dim fmax As Int32
        fmax = 0
        For i = 1 To P.FIELD.Count
            If fmax < P.FIELD.Item(i).Sequence Then
                fmax = P.FIELD.Item(i).Sequence
            End If
        Next

        For i = 1 To 6 * 15
            f = P.FIELD.Add()
            f.Sequence = fmax + 1
            fmax = fmax + 1
            f.Name = "M" + i.ToString() + "Value"
            f.Caption = f.Name
            f.FieldType = FieldTypeByName("Numeric")
            f.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            f.Save()

        Next
    End Sub
End Class