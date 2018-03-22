Imports System.IO
Imports System.Text

Public Class frmJDL
    Private Sub frmJDL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim i As Integer
        Dim ti As tmpInst
        model.OBJECTTYPE.Sort = "Name"
        For i = 1 To model.OBJECTTYPE.Count
            ti = New tmpInst()
            ti.ID = model.OBJECTTYPE.Item(i).ID
            ti.Name = model.OBJECTTYPE.Item(i).the_Comment
            ti.ObjType = model.OBJECTTYPE.Item(i).Name
            chkObjType.Items.Add(ti, False)
        Next

        textBoxOutPutFolder.Text = GetSetting("L2BUILDER", "EXTJS2MYSQL_" & Manager.Site, "JDLPATH", "c:\")
    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click
        folderBrowserDialogProjectOutput.SelectedPath = textBoxOutPutFolder.Text
        folderBrowserDialogProjectOutput.ShowDialog()
        textBoxOutPutFolder.Text = folderBrowserDialogProjectOutput.SelectedPath
        If Not textBoxOutPutFolder.Text.EndsWith("\") Then
            textBoxOutPutFolder.Text += "\"
            SaveSetting("L2BUILDER", "EXTJS2MYSQL_" & Manager.Site, "JDLPATH", textBoxOutPutFolder.Text)
        End If
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        Dim i As Integer
        For i = 0 To chkObjType.Items.Count - 1
            chkObjType.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub cmdClearAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearAll.Click
        Dim i As Integer
        For i = 0 To chkObjType.Items.Count - 1
            chkObjType.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub cmdGen_Click(sender As Object, e As EventArgs) Handles cmdGen.Click
        Dim i As Integer
        Dim ti As tmpInst
        Dim sw As StringBuilder

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        Dim om As MTZMetaModel.MTZMetaModel.OBJECTMODE




        Me.Text = "Generating stores"
        Application.DoEvents()
        sw = New StringBuilder


        Dim eidx As Integer
        Dim ei As MTZMetaModel.MTZMetaModel.ENUMITEM
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        For i = 1 To model.FIELDTYPE.Count
            ft = model.FIELDTYPE.Item(i)
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                sw.Append(vbCrLf & "enum " & ft.Name.ToLower & " {")
                For eidx = 1 To ft.ENUMITEM.Count
                    If (i > 1) Then
                        sw.Append(",")
                    End If

                    ei = ft.ENUMITEM.Item(eidx)
                    sw.Append(vbCrLf & vbTab & ei.Name)
                Next
                sw.Append(vbCrLf & "}")
            End If

        Next
        sw.Append(vbCrLf)

        For i = 0 To chkObjType.CheckedItems.Count - 1

            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)


            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sw.Append(PartMake_GenStores(ot.PART))

            Application.DoEvents()
        Next



        Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\", "entity.jdl.jh", False)

        MsgBox("OK")
    End Sub


    Private Function PartMake_GenStores(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim P1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer


        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & PartMake_Store(P))

            sw.Append(PartMake_GenStores(P.PART))

        Next
        Return sw.ToString()

    End Function

    Private Function PartMake_Store(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Try

            Dim fld As MTZMetaModel.MTZMetaModel.FIELD
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

            Dim i As Integer


            Dim isroot As Boolean = False
            If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
                isroot = True
            End If





            sw.Append(vbCrLf & "entity " & P.Name.ToLower() & " {")


            'sw.Append(vbCrLf & vbTab & P.Name.ToLower() & "id = models.CharField(max_length=38)")
            'If isroot Then
            '    sw.Append(vbCrLf & vbTab & "instanceid = models.CharField(max_length=38)")
            'Else
            '    sw.Append(vbCrLf & vbTab & "parentid = models.CharField(max_length=38)")
            'End If

            'If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            '    sw.Append(vbCrLf & vbTab & "parentrowid = models.CharField(max_length=38)")
            'End If

            Dim bf As MTZMetaModel.MTZMetaModel.FIELD
            bf = Nothing
            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)

                If fld.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    If bf Is Nothing Then
                        bf = fld
                    End If

                End If
                ft = fld.FieldType

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                        If ft.Name.ToLower = "file" Then
                            sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.FileField(verbose_name='" & fld.Caption & "')")
                        Else
                            If fld.DataSize > 0 Then
                                sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "= models.CharField(max_length=" & fld.DataSize.ToString() & " ,verbose_name='" & fld.Caption & "')")
                            Else
                                sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "= models.CharField(max_length=255,verbose_name='" & fld.Caption & "')")
                            End If

                        End If

                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                        If ft.Name.ToLower = "date" Then
                            sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.DateField(verbose_name='" & fld.Caption & "')")
                        ElseIf ft.Name.ToLower = "time" Then
                            sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.TimeField(verbose_name='" & fld.Caption & "')")
                        ElseIf ft.Name.ToLower = "datetime" Then
                            sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.TimeField(verbose_name='" & fld.Caption & "')")
                        ElseIf ft.Name.ToLower = "birthday" Then
                            sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.DateField(verbose_name='" & fld.Caption & "')")
                        End If
                    End If

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then

                        sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.DecimalField(max_digits=12, decimal_places=2,verbose_name='" & fld.Caption & "')")

                    End If
                End If


                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                    sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.IntegerField(verbose_name='" & fld.Caption & "')")


                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                    sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.IntegerField(choices=enum_" & ft.Name.ToLower & ",verbose_name='" & fld.Caption & "')")

                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                    Dim refp As MTZMetaModel.MTZMetaModel.PART
                    refp = fld.RefToPart
                    sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.ForeignKey('" & refp.Name.ToLower() & "',verbose_name='" & fld.Caption & "')")


                End If
            Next
            If Not bf Is Nothing Then
                sw.Append(vbCrLf & vbTab & "def __unicode__(self):")
                sw.Append(vbCrLf & vbTab & vbTab & "return self." & bf.Name.ToLower())
            End If

        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
            ' Stop
        End Try

        Return sw.ToString()

    End Function



    Private Sub Tool_WriteFile(ByVal s As String, ByVal path As String, ByVal fname As String, Optional ByVal Capitalize As Boolean = False)
        Dim p As String
        p = path
        If Not p.EndsWith("\") Then
            p += "\"
        End If
        Dim di As DirectoryInfo
        di = New DirectoryInfo(p)

        If Not di.Exists Then
            di.Create()
        End If
        If Capitalize Then
            File.WriteAllText(p & (fname), s, System.Text.Encoding.UTF8)
        Else
            File.WriteAllText(p & fname, s, System.Text.Encoding.UTF8)
        End If

        Dim jsc As Yahoo.Yui.Compressor.JavaScriptCompressor

        If fname.Contains(".js") Then
            Try
                jsc = New Yahoo.Yui.Compressor.JavaScriptCompressor
                s = jsc.Compress(s)
                p += "comp\"

                di = New DirectoryInfo(p)

                If Not di.Exists Then
                    di.Create()
                End If
                If Capitalize Then
                    File.WriteAllText(p & (fname), s, System.Text.Encoding.UTF8)
                Else
                    File.WriteAllText(p & fname, s, System.Text.Encoding.UTF8)
                End If

            Catch ex As Exception

            End Try

        End If

    End Sub
End Class