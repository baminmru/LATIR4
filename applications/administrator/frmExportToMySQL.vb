Imports System.Text
Imports LATIR2.Utils

Public Class frmExportToMySQL
    Private objectTypes As Hashtable
    Private Resp As LATIRGenerator.Response

    Private Sub button3_Click(sender As System.Object, e As System.EventArgs) Handles button3.Click
        BFolder.SelectedPath = txtExport.Text
        BFolder.ShowDialog()
        txtExport.Text = BFolder.SelectedPath
    End Sub

    Private Sub frmExportToMySQL_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dt As System.Data.DataTable
        Dim oID As System.Guid
        Dim i As Long
        dt = Manager.Session.GetRowsExDT("INSTANCE", Manager.Session.GetProvider.InstanceFieldList, "", "", "OBJTYPE='MTZMetaModel'", "")

        oID = New Guid(dt.Rows(0)("INSTANCEID").ToString())
        model = CType(Manager.GetInstanceObject(oID), MTZMetaModel.MTZMetaModel.Application)
        objectTypes = New Hashtable
        oID = New Guid(dt.Rows(0)("INSTANCEID").ToString())
        model = CType(Manager.GetInstanceObject(oID), MTZMetaModel.MTZMetaModel.Application)
        For i = 1 To model.OBJECTTYPE.Count
            objectTypes.Add(model.OBJECTTYPE.Item(i).Name, model.OBJECTTYPE.Item(i))
            chkTypes.Items.Add(model.OBJECTTYPE.Item(i).Name, False)
        Next
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        Dim i As Integer
        For i = 0 To chkTypes.Items.Count - 1
            chkTypes.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub cmdUnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnSelectAll.Click
        Dim i As Integer
        For i = 0 To chkTypes.Items.Count - 1
            chkTypes.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub cmdGen_Click(sender As System.Object, e As System.EventArgs) Handles cmdGen.Click
        Dim allSteps As Integer
        Dim ObjType As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim TypeID As Guid
        Dim j As Integer
        If (chkTypes.CheckedItems.Count > 0) Then
            Resp = New LATIRGenerator.Response
            allSteps = chkTypes.CheckedItems.Count
            progressBar.Maximum = allSteps
            progressBar.Minimum = 0
            progressBar.Value = 0
            progressBar.Visible = True
            For j = 0 To chkTypes.CheckedItems.Count - 1
                ObjType = objectTypes.Item(chkTypes.CheckedItems().Item(j))
                TypeID = ObjType.ID
                ExportType(ObjType)

                progressBar.Value = j
                Application.DoEvents()
            Next
            Dim d As DateTime
            d = DateTime.Now
            Resp.Save(txtExport.Text & "\export2MySQL_" & d.Year.ToString & "_" & d.Month.ToString & "_" & d.Day.ToString & "_" & d.Hour.ToString & "_" & d.Minute.ToString & "_" & d.Second.ToString & ".xml")
            progressBar.Value = progressBar.Maximum

            MsgBox("Экспорт завершен")
        Else
            MsgBox("Укажите тип объекта")
        End If

    End Sub
    Private Sub ExportType(ByVal ObjType As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Resp.ModuleName = ObjType.Name
        Resp.Block = "INSTANCE"

        Dim s As StringBuilder
        s = New StringBuilder

        Dim dt As DataTable
        Dim i As Integer

        dt = Manager.Session.GetData("select " + Manager.Session.GetProvider.InstanceFieldList + " from instance where objtype='" & ObjType.Name & "'")

        s.AppendLine("delete from instance where objtype='" & ObjType.Name & "';")
        s.AppendLine("GO")
        For i = 0 To dt.Rows.Count - 1
            Try
                s.AppendLine("insert into instance( instanceid ,name,objtype,status) values( G2B('" & dt.Rows(i)("INSTANCEID").ToString & "'),'" & dt.Rows(i)("NAME").ToString().Replace("'", "''") & "','" & dt.Rows(i)("OBJTYPE").ToString & "',")
                If TypeName(dt.Rows(i)("status")) = "DBNull" Then
                    s.Append("null")
                Else
                    s.Append("G2B('" & dt.Rows(i)("status").ToString & "')")
                End If

                s.Append(");")
                s.AppendLine("")
                s.AppendLine("GO")
                s.AppendLine("")
            Catch ex As Exception

            End Try
            
        Next


        Resp.Out(s.ToString())

        Dim p As MTZMetaModel.MTZMetaModel.PART

        For i = 1 To ObjType.PART.Count
            p = ObjType.PART.Item(i)
            ExportPart(p)
        Next

    End Sub


    Private Function MakeFList(ByVal p As MTZMetaModel.MTZMetaModel.PART) As String

        Dim j As Integer
        Dim i As Integer
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        Dim prv As LATIR2.DBProvider
        prv = Manager.Session.GetProvider

        Dim flist As String = prv.ID2Base(p.Name.ToLower() & "id") + "," + prv.ID2Base(p.Name.ToLower() & "id", "id")



        For j = 1 To p.FIELD.Count
            fld = p.FIELD.Item(j)
            ft = fld.FieldType


            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    flist = flist & "," & fld.Name.ToLower
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    flist = flist & "," + prv.Date2Base(fld.Name.ToLower())
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    flist = flist & "," & fld.Name.ToLower
                End If
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
                flist = flist & "," & fld.Name.ToLower
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                flist = flist & "," & fld.Name.ToLower

              

            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then


                If ft.Name.ToLower() = "multiref" Then
                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        flist = flist & "," & fld.Name.ToLower
                      

                    End If
                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        flist = flist & "," & prv.ID2Base(fld.Name.ToLower)
                       
                    End If
                Else
                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        flist = flist & "," & prv.ID2Base(fld.Name.ToLower)
                    End If
                    If fld.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        flist = flist & "," & prv.ID2Base(fld.Name.ToLower)
                    End If
                End If



            End If


        Next
        If TypeName(p.Parent.Parent).ToUpper = "OBJECTTYPE" Then
            flist = flist & "," & prv.ID2Base("instanceid")
        Else
            flist = flist & "," & prv.ID2Base("parentstructrowid")
        End If

        If p.PartType = 2 Then
            flist = flist & "," & prv.ID2Base("parentrowid")
        End If
        flist = flist & "," & prv.Date2Base("changestamp")
        Return flist
    End Function

    Private Sub ExportPart(ByVal p As MTZMetaModel.MTZMetaModel.PART)
        Dim p1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer
        Dim s As StringBuilder
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Debug.Print(p.Name)

        If p.Name = "OBJECTTYPE" Then
            'Stop
        End If
        If p.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
            s = New StringBuilder
            Resp.Block = p.Name

            Dim dt As DataTable
            Try
                dt = Manager.Session.GetData("select " + MakeFList(p)  + " from " & p.Name)
                s.AppendLine("delete from " & p.Name & ";")

                s.AppendLine("GO")
                s.AppendLine("")
                For j = 0 To dt.Rows.Count - 1
                    Try
                        s.AppendLine("insert into `" & p.Name & "`( " & p.Name & "id ")

                        If TypeName(p.Parent.Parent).ToUpper = "OBJECTTYPE" Then
                            s.Append(",InstanceID")
                        Else
                            s.Append(",ParentStructRowID")
                        End If

                        If p.PartType = 2 Then
                            s.Append(",ParentRowid")
                        End If
                        s.Append(",ChangeStamp")

                        For i = 1 To p.FIELD.Count
                            f = p.FIELD.Item(i)
                            ft = f.FieldType
                            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                                s.Append("," & f.Name)
                            End If
                        Next
                        s.Append(") values( G2B('" & dt.Rows(j)(p.Name & "id").ToString & "')")

                        If TypeName(p.Parent.Parent).ToUpper = "OBJECTTYPE" Then
                            s.Append(",G2B('" & dt.Rows(j)("instanceid").ToString() & "')")
                        Else
                            s.Append(",G2B('" & dt.Rows(j)("ParentStructRowID").ToString() & "')")
                        End If
                        If p.PartType = 2 Then
                            s.Append(",G2B('" & dt.Rows(j)("ParentRowid").ToString() & "')")
                        End If

                        Try
                            Dim ddd As DateTime

                            ddd = Date.Parse(dt.Rows(j)("ChangeStamp"))
                            s.Append("," & MakeMySQLDate(ddd))
                        Catch ex As Exception
                            s.Append("," & MakeMySQLDate(Now()))
                        End Try


                        For i = 1 To p.FIELD.Count
                            f = p.FIELD.Item(i)
                            ft = f.FieldType
                            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then

                                Try
                                    If TypeName(dt.Rows(j)(f.Name)) = "DBNull" Then
                                        s.Append(",null")
                                    Else
                                        If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                                            s.Append("," & MakeMySQLDate(dt.Rows(j)(f.Name)))
                                        ElseIf ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                                            s.Append("," & dt.Rows(j)(f.Name).ToString().Replace(",", "."))
                                        ElseIf ft.Name.ToLower = "reference" Or ft.Name.ToLower = "id" Then
                                            s.Append(",G2B('" & dt.Rows(j)(f.Name).ToString() & "')")
                                        ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                                            s.Append("," & dt.Rows(j)(f.Name).ToString().Replace(",", "."))
                                        Else
                                            If ft.Name.ToLower = "memo" Then
                                                s.Append(",'" & dt.Rows(j)(f.Name).ToString().Replace("'", "''").Replace(vbCrLf + "GO", vbCrLf + "$$") & "'")
                                            Else

                                                s.Append(",'" & dt.Rows(j)(f.Name).ToString().Replace("'", "''") & "'")
                                            End If

                                        End If
                                    End If
                                Catch ex As Exception
                                    s.Append(",null")
                                End Try
                               

                            End If
                        Next
                        s.AppendLine(");")


                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    s.AppendLine("")
                    s.AppendLine("GO")
                    s.AppendLine("")
                Next
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        



            Resp.Out(s.ToString())

            For i = 1 To p.PART.Count
                p1 = p.PART.Item(i)
                ExportPart(p1)
            Next
        End If

    End Sub
End Class