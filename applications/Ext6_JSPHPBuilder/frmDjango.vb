Imports System.Text
Imports System.IO

Public Class frmDjango
    Private Sub frmDjango_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim ti As tmpInst
        model.OBJECTTYPE.Sort = "the_Comment"
        For i = 1 To model.OBJECTTYPE.Count
            With model.OBJECTTYPE.Item(i)
                ti = New tmpInst
                ti.ObjType = CType(.Package, MTZMetaModel.MTZMetaModel.MTZAPP).Name
                ti.Name = .the_Comment
                ti.ID = .ID
                chkObjType.Items.Add(ti)
            End With
        Next
        textBoxOutPutFolder.Text = GetSetting("L2BUILDER", "DJANGO_" & Manager.Site, "PATH", "")

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

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        folderBrowserDialogProjectOutput.SelectedPath = textBoxOutPutFolder.Text
        folderBrowserDialogProjectOutput.ShowDialog()
        textBoxOutPutFolder.Text = folderBrowserDialogProjectOutput.SelectedPath
        If Not textBoxOutPutFolder.Text.EndsWith("\") Then
            textBoxOutPutFolder.Text += "\"
            SaveSetting("L2BUILDER", "DJANGO_" & Manager.Site, "PATH", textBoxOutPutFolder.Text)
        End If
    End Sub

    Private Sub cmdGen_Click(sender As Object, e As EventArgs) Handles cmdGen.Click
        Dim i As Integer
        Dim ti As tmpInst
        Dim sw As StringBuilder

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        Dim om As MTZMetaModel.MTZMetaModel.OBJECTMODE


        pb.Minimum = 0
        pb.Maximum = chkObjType.CheckedItems.Count
        pb.Value = 0
        pb.Visible = True

        Me.Text = "Generating stores"
        Application.DoEvents()
        sw = New StringBuilder
        sw.Append("from django.db import models" & vbCrLf)
        sw.Append("from django.utils.translation import ugettext_lazy as _" & vbCrLf)

        Dim eidx As Integer
        Dim ei As MTZMetaModel.MTZMetaModel.ENUMITEM
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        For i = 1 To model.FIELDTYPE.Count
            ft = model.FIELDTYPE.Item(i)
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                sw.Append(vbCrLf & "enum_" & ft.Name.ToLower & "=(")
                For eidx = 1 To ft.ENUMITEM.Count
                    ei = ft.ENUMITEM.Item(eidx)
                    sw.Append(vbCrLf & vbTab & "(" & ei.NameValue.ToString() & ",'" & ei.Name & "'),")
        Next
                sw.Append(vbCrLf & ")")
            End If

        Next
        sw.Append(vbCrLf)

        For i = 0 To chkObjType.CheckedItems.Count - 1
            pb.Value = i + 1
            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)


            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sw.Append(PartMake_GenStores(ot.PART))
            pb.Value = i
            Application.DoEvents()
        Next



        Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\", "models.py", False)
        pb.Visible = False
        MsgBox("OK")
    End Sub


    Private Function PartMake_Store(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Try

            Dim fld As MTZMetaModel.MTZMetaModel.FIELD
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
            Dim ParentPart As MTZMetaModel.MTZMetaModel.PART

            Dim i As Integer


            Dim isroot As Boolean = False
            If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
                isroot = True
                ParentPart = Nothing
            Else
                ParentPart = P.Parent.Parent
            End If





            sw.Append(vbCrLf & "class " & P.Name.ToLower() & "(models.Model):")
            sw.Append(vbCrLf & vbTab & "class Meta:")
            sw.Append(vbCrLf & vbTab & vbTab & "verbose_name = _(u'" & P.Caption & "')")
            sw.Append(vbCrLf & vbTab & vbTab & "verbose_name_plural = _(u'" & P.Caption & "')")

            'sw.Append(vbCrLf & vbTab & P.Name.ToLower() & "id = models.CharField(max_length=38,primary_key=True, editable=False)")
            sw.Append(vbCrLf & vbTab & P.Name.ToLower() & "id = models.UUIDField(primary_key=True, default=uuid.uuid4, editable=False)")

            'If isroot Then
            '    sw.Append(vbCrLf & vbTab & "instanceid = models.ForeignKey('instance', on_delete=models.CASCADE)")
            'Else
            sw.Append(vbCrLf & vbTab & "parentid =  models.ForeignKey('" & ParentPart.Name.ToLower() & "', on_delete=models.CASCADE)")
            'End If

            If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                'sw.Append(vbCrLf & vbTab & "parentrowid = models.CharField(max_length=38)")
                sw.Append(vbCrLf & vbTab & "parentrowid = models.UUIDField()")
            End If

            Dim bf As MTZMetaModel.MTZMetaModel.FIELD
            Dim sNull As String
            bf = Nothing
            P.FIELD.Sort = "Sequence"

            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sNull = ",null=True"
                Else
                    sNull = ""
                End If
                If fld.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    If bf Is Nothing Then
                        bf = fld
                    End If

                End If
                ft = fld.FieldType

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                        If ft.Name.ToLower = "file" Then
                            sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.FileField(verbose_name='" & fld.Caption & "'" & sNull & ")")
                        Else
                            If fld.DataSize > 0 Then
                                sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "= models.CharField(max_length=" & fld.DataSize.ToString() & " ,verbose_name='" & fld.Caption & "'" & sNull & ")")
                            Else
                                sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "= models.CharField(max_length=255,verbose_name='" & fld.Caption & "'" & sNull & ")")
                            End If

                        End If

                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                        If ft.Name.ToLower = "date" Then
                            sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.DateField(verbose_name='" & fld.Caption & "'" & sNull & ")")
                        ElseIf ft.Name.ToLower = "time" Then
                            sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.TimeField(verbose_name='" & fld.Caption & "'" & sNull & ")")
                        ElseIf ft.Name.ToLower = "datetime" Then
                            sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.TimeField(verbose_name='" & fld.Caption & "'" & sNull & ")")
                        ElseIf ft.Name.ToLower = "birthday" Then
                            sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.DateField(verbose_name='" & fld.Caption & "'" & sNull & ")")
                        End If
                    End If

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then

                        sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.DecimalField(max_digits=12, decimal_places=2,verbose_name='" & fld.Caption & "'" & sNull & ")")

                    End If
                End If


                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                    sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.IntegerField(verbose_name='" & fld.Caption & "'" & sNull & ")")


                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                    sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.IntegerField(choices=enum_" & ft.Name.ToLower & ",verbose_name='" & fld.Caption & "'" & sNull & ")")

                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                    Dim refp As MTZMetaModel.MTZMetaModel.PART
                    refp = fld.RefToPart
                    sw.Append(vbCrLf & vbTab & fld.Name.ToLower() & "=models.ForeignKey('" & refp.Name.ToLower() & "', on_delete=models.SET_NULL,null=True,verbose_name='" & fld.Caption & "')")


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