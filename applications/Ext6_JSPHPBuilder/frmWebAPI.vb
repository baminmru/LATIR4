Imports System.IO
Imports System.Text

Public Class frmWebAPI
    Private Sub frmJDL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        textBoxOutPutFolder.Text = GetSetting("L2BUILDER", "EXT2NET_" & Manager.Site, "WEBAPIPATH", "c:\")
        txtNS.Text = GetSetting("L2BUILDER", "EXT2NET_" & Manager.Site, "DEFNS", "")
    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click
        folderBrowserDialogProjectOutput.SelectedPath = textBoxOutPutFolder.Text
        folderBrowserDialogProjectOutput.ShowDialog()
        textBoxOutPutFolder.Text = folderBrowserDialogProjectOutput.SelectedPath
        If Not textBoxOutPutFolder.Text.EndsWith("\") Then
            textBoxOutPutFolder.Text += "\"
            SaveSetting("L2BUILDER", "EXT2NET_" & Manager.Site, "WEBAPIPATH", textBoxOutPutFolder.Text)
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
        If txtNS.Text <> "" Then
            sw.Append(vbCrLf & "namespace " & txtNS.Text & " {")
        End If
        For i = 1 To model.FIELDTYPE.Count
            ft = model.FIELDTYPE.Item(i)
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                sw.Append(vbCrLf & "public enum enum_" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & " {")
                sw.Append(vbCrLf & vbTab & "/* " & ft.Name & " - " & ft.the_Comment & " */ ")
                For eidx = 1 To ft.ENUMITEM.Count
                    sw.Append(vbCrLf & vbTab)
                    If (eidx > 1) Then
                        sw.Append(",")
                    End If
                    ei = ft.ENUMITEM.Item(eidx)
                    sw.Append(LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & "_" & LATIR2Framework.FieldTypesHelper.MakeValidName(ei.Name) & "=" & ei.NameValue & " // " & ei.Name)
                Next
                sw.Append(vbCrLf & "}")
            End If

        Next
        sw.Append(vbCrLf)
        If txtNS.Text <> "" Then
            sw.Append(vbCrLf & "}")
        End If
        Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\", "enums.cs", False)

        ''''''''''' Make type models for CS project

        For i = 0 To chkObjType.CheckedItems.Count - 1

            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)

            sw = New StringBuilder
            Dim pkg As MTZMetaModel.MTZMetaModel.MTZAPP


            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            If txtNS.Text <> "" Then
                sw.Append(vbCrLf & "namespace " & txtNS.Text & ".models { ")
            Else
                pkg = ot.Package
                sw.Append(vbCrLf & "namespace " & pkg.Name.ToLower() & ".models { ")
            End If

            sw.Append(vbCrLf & vbTab & "/* " & ot.Name & " -  " & ot.the_Comment & " */ ")

            sw.Append(PartMake_GenStores(ot.PART))
            sw.Append(vbCrLf & "}")
            Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\models\", ot.Name.ToLower() + ".cs", False)

            Application.DoEvents()
        Next

        ''''''''''''''''''' typescript enums
        sw = New StringBuilder
        If txtNS.Text <> "" Then
            sw.Append(vbCrLf & "export namespace enums {")
        End If
        For i = 1 To model.FIELDTYPE.Count
            ft = model.FIELDTYPE.Item(i)
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                sw.Append(vbCrLf & " export enum enum_" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & " {")
                sw.Append(vbCrLf & vbTab & "/* " & ft.Name & " - " & ft.the_Comment & " */ ")
                For eidx = 1 To ft.ENUMITEM.Count
                    sw.Append(vbCrLf & vbTab)
                    If (eidx > 1) Then
                        sw.Append(",")
                    End If
                    ei = ft.ENUMITEM.Item(eidx)
                    sw.Append(LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & "_" & LATIR2Framework.FieldTypesHelper.MakeValidName(ei.Name) & "=" & ei.NameValue & " // " & ei.Name)
                Next
                sw.Append(vbCrLf & "}")
            End If

        Next
        sw.Append(vbCrLf)
        If txtNS.Text <> "" Then
            sw.Append(vbCrLf & "}")
        End If
        Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\ts\", "enums.ts", False)



        ''''''''''''''''''' Make Model Types for TypeScript objects

        For i = 0 To chkObjType.CheckedItems.Count - 1

            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)

            sw = New StringBuilder

            ot = model.OBJECTTYPE.Item(ti.ID.ToString())

            sw.AppendLine("import { enums } from './enums';")

            sw.Append(vbCrLf & "export namespace " & ot.Name.ToLower() & " { ")


            sw.Append(vbCrLf & vbTab & "/* " & ot.Name & " -  " & ot.the_Comment & " */ ")

            sw.Append(PartMake_TSList(ot.PART))
            sw.Append(vbCrLf & "}")
            Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\ts\", ot.Name.ToLower() + ".ts", False)

            Application.DoEvents()
        Next


        ''''''''''''''''''' Make Services for TypeScript objects

        For i = 0 To chkObjType.CheckedItems.Count - 1

            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)

            sw = New StringBuilder
            Dim pkg As MTZMetaModel.MTZMetaModel.MTZAPP


            ot = model.OBJECTTYPE.Item(ti.ID.ToString())


            PartMake_ServiceList(ot.PART)

            Application.DoEvents()
        Next



        ''''''''''''''''''' Make Components for TypeScript objects

        For i = 0 To chkObjType.CheckedItems.Count - 1

            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)

            sw = New StringBuilder
            Dim pkg As MTZMetaModel.MTZMetaModel.MTZAPP


            ot = model.OBJECTTYPE.Item(ti.ID.ToString())


            PartMake_Components(ot.PART)

            Application.DoEvents()
        Next


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
            Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
            ot = Nothing
            If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
                ot = P.Parent.Parent
                isroot = True
            End If

            sw.Append(vbCrLf & " public class  " & P.Name.ToLower() & " { // " & P.Caption)

            sw.Append(vbCrLf & vbTab & " public System.Guid  " & P.Name.ToLower() & "Id{ get; set; } // Primary key field")

            If Not isroot Then
                Dim ParentPart As MTZMetaModel.MTZMetaModel.PART
                ParentPart = P.Parent.Parent
                sw.Append(vbCrLf & vbTab & " public System.Guid  parentStructRowId { get; set; } // Parent part -> " & ParentPart.Name)
            Else
                If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & vbTab & " public System.Guid  instanceId { get; set; } // Document ID ")
                End If


            End If

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
                            sw.Append(vbCrLf & vbTab & "public string " & fld.Name & "{ get; set; } // " & fld.Caption)
                        Else
                            If fld.DataSize > 0 Then
                                sw.Append(vbCrLf & vbTab & "public string " & fld.Name & "{ get; set; } // " & fld.Caption)
                            Else
                                sw.Append(vbCrLf & vbTab & "public string " & fld.Name & "{ get; set; } // " & fld.Caption)
                            End If

                        End If

                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                        If ft.Name.ToLower = "date" Then
                            sw.Append(vbCrLf & vbTab & "public DateTime " & fld.Name & "{ get; set; } // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "time" Then
                            sw.Append(vbCrLf & vbTab & "public DateTime " & fld.Name & "{ get; set; } // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "datetime" Then
                            sw.Append(vbCrLf & vbTab & "public DateTime " & fld.Name & "{ get; set; } // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "birthday" Then
                            sw.Append(vbCrLf & vbTab & "public DateTime " & fld.Name & "{ get; set; } // " & fld.Caption)
                        End If
                    End If

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then

                        sw.Append(vbCrLf & vbTab & "public double " & fld.Name & "{ get; set; } // " & fld.Caption)

                    End If
                End If


                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                    sw.Append(vbCrLf & vbTab & "public int " & fld.Name & "{ get; set; } // " & fld.Caption)


                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                    sw.Append(vbCrLf & vbTab & "public enum_" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & " " & fld.Name & "{ get; set; } // " & fld.Caption)

                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                    Dim refp As MTZMetaModel.MTZMetaModel.PART
                    refp = fld.RefToPart
                    sw.Append(vbCrLf & vbTab & "public " & refp.Name.ToLower() & " " & fld.Name & "{ get; set; } //" & fld.Caption)


                End If
            Next

            sw.Append(vbCrLf & " }")


        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
            ' Stop
        End Try

        Return sw.ToString()

    End Function




    Private Function PartMake_TSList(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim P1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer


        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & PartMake_TS(P))

            sw.Append(PartMake_TSList(P.PART))

        Next
        Return sw.ToString()

    End Function

    Private Function PartMake_TS(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Try

            Dim fld As MTZMetaModel.MTZMetaModel.FIELD
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

            Dim i As Integer


            Dim isroot As Boolean = False
            Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
            ot = Nothing
            If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
                ot = P.Parent.Parent
                isroot = True
            End If



            sw.Append(vbCrLf & " export interface   " & P.Name.ToLower() & " { // " & P.Caption)

            sw.Append(vbCrLf & vbTab & P.Name.ToLower() & "Id:string; // Primary key field")

            If Not isroot Then
                Dim ParentPart As MTZMetaModel.MTZMetaModel.PART
                ParentPart = P.Parent.Parent
                sw.Append(vbCrLf & vbTab & " parentStructRowId :string; // Parent part -> " & ParentPart.Name)
            Else
                If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    sw.Append(vbCrLf & vbTab & " instanceId:string // Document ID ")
                End If


            End If

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
                            sw.Append(vbCrLf & vbTab & fld.Name & ":string; // " & fld.Caption)
                        Else
                            If fld.DataSize > 0 Then
                                sw.Append(vbCrLf & vbTab & fld.Name & ":string; // " & fld.Caption)
                            Else
                                sw.Append(vbCrLf & vbTab & fld.Name & ":string; // " & fld.Caption)
                            End If

                        End If

                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                        If ft.Name.ToLower = "date" Then
                            sw.Append(vbCrLf & vbTab & fld.Name & ":string; // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "time" Then
                            sw.Append(vbCrLf & vbTab & fld.Name & ":string;  // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "datetime" Then
                            sw.Append(vbCrLf & vbTab & fld.Name & ":string;  // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "birthday" Then
                            sw.Append(vbCrLf & vbTab & fld.Name & ":string;  // " & fld.Caption)
                        End If
                    End If

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then

                        sw.Append(vbCrLf & vbTab & fld.Name & ":Number; // " & fld.Caption)

                    End If
                End If


                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                    sw.Append(vbCrLf & vbTab & fld.Name & ":Number;  // " & fld.Caption)


                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                    sw.Append(vbCrLf & vbTab & " " & fld.Name & ":enums.enum_" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & "; // " & fld.Caption)

                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                    Dim refp As MTZMetaModel.MTZMetaModel.PART
                    refp = fld.RefToPart
                    sw.Append(vbCrLf & vbTab & fld.Name & ":string; //" & fld.Caption & " -> " & refp.Name.ToLower())


                End If
            Next

            sw.Append(vbCrLf & " }")


        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
            ' Stop
        End Try

        Return sw.ToString()

    End Function


    Private Function PartMake_ServiceList(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim P1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer


        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & PartMake_Service(P))

            sw.Append(PartMake_ServiceList(P.PART))

        Next
        Return sw.ToString()

    End Function

    Private Function PartMake_Service(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return " "
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        ot = LATIR2Framework.ObjectTypeHelper.TypeForStruct(P)



        Dim sb As StringBuilder
        sb = New StringBuilder()
        sb.AppendLine("import { Injectable } from '@angular/core';")
        sb.AppendLine("import { HttpClient, HttpRequest, HttpClientModule, HttpHeaders, HttpResponse } from '@angular/common/http';")
        sb.AppendLine("import { Observable } from 'rxjs';")
        sb.AppendLine("import { environment } from '../environments/environment';")
        sb.AppendLine("import { enums } from './enums';")
        sb.AppendLine("import { %type%} from './%type%';")

        sb.AppendLine("@Injectable()")
        sb.AppendLine("export class %obj%_Service {")
        sb.AppendLine("	private serviceURL: string = environment.baseAppUrl;")
        sb.AppendLine(" ")
        sb.AppendLine("	//Create constructor to get Http instance")
        sb.AppendLine("	constructor(private http:HttpClient) { ")
        sb.AppendLine("	}")
        sb.AppendLine("	")
        sb.AppendLine("	")



        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim i As Integer
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                sb.AppendLine(vbTab & fld.Name & ":string = '';")
            End If
        Next

        sb.AppendLine("	PageSize:number=10;")
        sb.AppendLine("	PageUrl:string='';")
        sb.AppendLine("    ")
        sb.AppendLine("	//Fetch all %obj%s")
        sb.AppendLine("    getAll_%obj%s(): Observable<%type%.%obj%[]> {")
        sb.AppendLine("		var qry:string;")
        sb.AppendLine("		qry='';")
        sb.AppendLine("		")

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                sb.AppendLine("		if(this." & fld.Name & "!=''){")
                sb.AppendLine("			if(qry !='') qry=qry +'&';")
                sb.AppendLine("			qry='" & fld.Name & "='+encodeURIComponent(this." & fld.Name & ")")
                sb.AppendLine("		}")
            End If
        Next

        sb.AppendLine("		/*")
        sb.AppendLine("		if(this.PageNo!=null){")
        sb.AppendLine("			if(qry !='') qry=qry +" & ";")
        sb.AppendLine("			//qry='page='+this.PageNo;")
        sb.AppendLine("			qry='_getpagesoffset=' + ((this.PageNo-1) * this.PageSize)+'&_count=' +this.PageSize;")
        sb.AppendLine("		}")
        sb.AppendLine("		*/")
        sb.AppendLine("		")
        sb.AppendLine("		if(this.PageUrl!=''){")
        sb.AppendLine("			return this.http.get<%type%.%obj%[]>(this.PageUrl)")
        sb.AppendLine("		}else{")
        sb.AppendLine("			if(qry !='')")
        sb.AppendLine("				qry='?' +qry;")
        sb.AppendLine("			return this.http.get<%type%.%obj%[]>(this.serviceURL + '/%obj%/'+qry)")
        sb.AppendLine("        }")
        sb.AppendLine("    }")
        sb.AppendLine("	")
        sb.AppendLine("	clearSearch():void{")
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                sb.AppendLine(vbTab & "this." & fld.Name & " = '';")
            End If
        Next
        sb.AppendLine("		")
        sb.AppendLine("	}")
        sb.AppendLine(" ")
        sb.AppendLine("	   //Create %obj%")
        sb.AppendLine("    create_%obj%(%obj%: %type%.%obj%): Observable<Object > {")
        sb.AppendLine("       // %obj%.%obj%Id = '';")
        sb.AppendLine("        let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })")
        sb.AppendLine("        return this.http.post(this.serviceURL + '/%obj%/', %obj%, { headers: cpHeaders })")
        sb.AppendLine("		")
        sb.AppendLine("    }")
        sb.AppendLine("	")
        sb.AppendLine("	//Fetch %obj% by id")
        sb.AppendLine("    get_%obj%ById(%obj%Id: string): Observable<%type%.%obj%> {")
        sb.AppendLine("        let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })")
        sb.AppendLine("		console.log(this.serviceURL +'/%obj%/'+ %obj%Id)")
        sb.AppendLine("        return this.http.get<%type%.%obj%>(this.serviceURL + '/%obj%/' + %obj%Id, { headers: cpHeaders })//.catch(err => { console.log(err) return Observable.of(err) })")
        sb.AppendLine("    }	")
        sb.AppendLine("	")
        sb.AppendLine("	   //Update %obj%")
        sb.AppendLine("    update_%obj%(%obj%: %type%.%obj%):Observable<Object > {")
        sb.AppendLine("        let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })")
        sb.AppendLine("        return this.http.put(this.serviceURL + '/%obj%/' + %obj%.%obj%Id, %obj%, { headers: cpHeaders })")
        sb.AppendLine("    }")
        sb.AppendLine("	")
        sb.AppendLine("    //Delete %obj%	")
        sb.AppendLine("    delete_%obj%ById(%obj%Id: string): Observable<Object> {")
        sb.AppendLine("        let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })")
        sb.AppendLine("        return this.http.delete(this.serviceURL + '/%obj%/' + %obj%Id, { headers: cpHeaders })")
        sb.AppendLine("            ")
        sb.AppendLine("			")
        sb.AppendLine("    }	")
        sb.AppendLine("	")
        sb.AppendLine("	private mSelecetd:%type%.%obj% = null;")
        sb.AppendLine("	")
        sb.AppendLine("	public 	get Selected():%type%.%obj%{ return this.mSelecetd;}")
        sb.AppendLine("	")
        sb.AppendLine("	public  set Selected(_%obj%:%type%.%obj%){ this.mSelecetd=_%obj%; }")
        sb.AppendLine(" ")
        sb.AppendLine("}")

        Dim ss As String = sb.ToString()
        ss = ss.Replace("%obj%", P.Name.ToLower())
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name.ToLower())

        Tool_WriteFile(ss, textBoxOutPutFolder.Text & "\ts\", P.Name.ToLower() + ".service.ts", False)

    End Function




    Private Function PartMake_Components(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim P1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer


        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & PartMake_PartComponent(P))

            sw.Append(PartMake_Components(P.PART))

        Next
        Return sw.ToString()

    End Function



    Private Function PartMake_PartComponent(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return " "
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        ot = LATIR2Framework.ObjectTypeHelper.TypeForStruct(P)
        Dim sb As StringBuilder
        Dim ss As String
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim i As Integer
        Dim isFirst As Boolean = True

        ' write style file
        Tool_WriteFile("  ", textBoxOutPutFolder.Text & "\ts\" + P.Name.ToLower() + "\", P.Name.ToLower() + ".component.scss", False)





        ' write component file
        sb = New StringBuilder()
        sb.AppendLine("import { Component, OnInit } from ""@angular/core"";")
        sb.AppendLine("import { %obj%_Service } from ""app/%obj%.service"";")
        sb.AppendLine("import { Observable } from ""rxjs/Observable"";")
        sb.AppendLine("import { StringFilter } from ""@clr/angular"";")
        sb.AppendLine("")
        sb.AppendLine("import { %type% } from ""app/%type%"";")
        sb.AppendLine("import { FormGroup, FormBuilder, Validators } from ""@angular/forms"";")
        sb.AppendLine("")
        sb.AppendLine("import 'rxjs/add/operator/switchMap';")
        sb.AppendLine("import 'rxjs/add/operator/publishReplay';")
        sb.AppendLine("")
        sb.AppendLine("const MODE_LIST = 0;")
        sb.AppendLine("const MODE_NEW = 1;")
        sb.AppendLine("const MODE_EDIT = 2;")
        sb.AppendLine("")


        isFirst = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                sb.AppendLine("class filter_%obj%_" & fld.Name & " implements StringFilter<%type%.%obj%> {")
                sb.AppendLine(" accepts(item: %type%.%obj%, search: string){ ")
                sb.AppendLine("     return item." & fld.Name & ".toString().toLowerCase( ).indexOf(search)>=0; ")
                sb.AppendLine(" };")
                sb.AppendLine("}")

            End If
        Next



        sb.AppendLine("@Component({")
        sb.AppendLine("	   selector: 'app-%obj%',")
        sb.AppendLine("    styleUrls: ['./%obj%.component.scss'],")
        sb.AppendLine("    templateUrl: './%obj%.component.html',")
        sb.AppendLine("})")
        sb.AppendLine("export class %obj%Component implements OnInit {")
        sb.AppendLine("")
        sb.AppendLine("    %obj%Form: FormGroup;")
        sb.AppendLine("    %obj%Array: Array<%type%.%obj%> = [];")
        sb.AppendLine("    opened: boolean = false;")
        sb.AppendLine("    confirmOpened: boolean = false;")
        sb.AppendLine("    mode: Number = MODE_LIST;")
        sb.AppendLine("    current%obj%: %type%.%obj% = {} as %type%.%obj%;")
        sb.AppendLine("    formMsg: string = '';")


        isFirst = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                sb.AppendLine(" _filter_%obj%_" & fld.Name & " " & ": filter_%obj%_" & fld.Name & ";")
            End If
        Next

        sb.AppendLine("")
        sb.AppendLine("    constructor(private _fb: FormBuilder, private %obj%_Service: %obj%_Service) {")
        sb.AppendLine("        this.%obj%Form = this._fb.group({")


        isFirst = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If Not isFirst Then
                    sb.Append(",")
                End If
                isFirst = False
                sb.AppendLine(vbTab & fld.Name & ":['']")
            End If
        Next


        sb.AppendLine("        });")


        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                sb.AppendLine(" this._filter_%obj%_" & fld.Name & " = new " & " filter_%obj%_" & fld.Name & "();")
            End If
        Next


        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    ngOnInit() {")
        sb.AppendLine("        this.refresh%obj%();")
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    refresh%obj%() {")
        sb.AppendLine("        this.%obj%_Service.getAll_%obj%s().subscribe(%obj%Array => { this.%obj%Array = %obj%Array; })")
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    onNew() {")
        sb.AppendLine("        this.opened = true;")
        sb.AppendLine("        this.mode = MODE_NEW;")
        sb.AppendLine("        this.current%obj% = {} as %type%.%obj%;")
        sb.AppendLine("        this.formMsg = 'Create: ';")
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    onEdit(item: %type%.%obj%) {")
        sb.AppendLine("        this.opened = true;")
        sb.AppendLine("        this.formMsg = 'Edit: ';")
        sb.AppendLine("        this.mode = MODE_EDIT;")
        sb.AppendLine("        this.current%obj% = item;")
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    onDelete(item: %type%.%obj%) {")
        sb.AppendLine("        this.confirmOpened = true;")
        sb.AppendLine("        this.current%obj% = item;")
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    onConfirmDeletion(item) {")
        sb.AppendLine("        this.%obj%_Service.delete_%obj%ById(this.current%obj%.%obj%Id).subscribe(() => this.refresh%obj%());")
        sb.AppendLine("        this.backToList();")
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    save(item: %type%.%obj%, isValid: boolean) {")
        sb.AppendLine("        if (isValid) {")
        sb.AppendLine("            switch (this.mode) {")
        sb.AppendLine("                case MODE_NEW: {")
        sb.AppendLine("                    this.%obj%_Service.create_%obj%(item)")
        sb.AppendLine("                        .subscribe(() => this.refresh%obj%());")
        sb.AppendLine("                    break;")
        sb.AppendLine("                }")
        sb.AppendLine("                case MODE_EDIT: {")
        sb.AppendLine("                    this.%obj%_Service.update_%obj%( item)")
        sb.AppendLine("                        .subscribe(() => this.refresh%obj%());")
        sb.AppendLine("                    break;")
        sb.AppendLine("                }")
        sb.AppendLine("                default:")
        sb.AppendLine("                    break;")
        sb.AppendLine("            }")
        sb.AppendLine("            this.backToList();")
        sb.AppendLine("        } else {")
        sb.AppendLine("            console.log(""invalid form"");")
        sb.AppendLine("        }")
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    backToList() {")
        sb.AppendLine("        this.opened = false;")
        sb.AppendLine("        this.confirmOpened = false;")
        sb.AppendLine("        this.mode = MODE_LIST;")
        sb.AppendLine("        this.current%obj% = {} as %type%.%obj%;")
        sb.AppendLine("    }")
        sb.AppendLine("}")
        sb.AppendLine(" ")

        ss = sb.ToString()
        ss = ss.Replace("%obj%", P.Name.ToLower())
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name.ToLower())

        Tool_WriteFile(ss, textBoxOutPutFolder.Text & "\ts\" + P.Name.ToLower() + "\", P.Name.ToLower() + ".component.ts", False)



        ' write component html

        sb = New StringBuilder()
        sb.AppendLine("<p>")
        sb.AppendLine("    <button type=""button"" class=""btn btn-sm btn-secondary"" (click)=""onNew()""><clr-icon shape=""plus""></clr-icon> New</button>")
        sb.AppendLine("    <button type=""button"" class=""btn btn-sm btn-secondary"" (click)=""onDelete(current%obj%)"" *ngIf=""current%obj%.%obj%Id !=null ""><clr-icon shape=""close""></clr-icon> Delete</button>")
        sb.AppendLine("    <button type=""button"" class=""btn btn-sm btn-secondary"" (click)=""onEdit(current%obj%)"" *ngIf=""current%obj%.%obj%Id !=null ""><clr-icon shape=""pencil""></clr-icon> Edit</button>")
        sb.AppendLine("</p>")
        sb.AppendLine("<clr-modal [(clrModalOpen)]=""opened"">")
        sb.AppendLine("    <h3 class=""modal-title"">{{formMsg}} %objname%</h3>")
        sb.AppendLine("    <div class=""modal-body"">")
        sb.AppendLine("        <form [formGroup]=""%obj%Form"" novalidate (ngSubmit)=""save(%obj%Form.value, %obj%Form.valid)"">")
        sb.AppendLine("            <section class=""form-block"">")


        isFirst = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                'If Not isFirst Then
                '    sb.Append(",")
                'End If
                isFirst = False
                sb.AppendLine("                <div class=""form-group"">")
                sb.AppendLine("                    <label for=""" & fld.Name & """>" & fld.Caption & "</label>")
                sb.AppendLine("                    <input [(ngModel)]=""current%obj%." & fld.Name & """ type=""text"" id=""" & fld.Name & """ placeholder=""" & fld.Caption & """  formControlName=""" & fld.Name & """>")
                'sb.AppendLine("                    <input [(ngModel)]=""current%obj%." & fld.Name & """ type=""text"" id=""" & fld.Name & """ placeholder=""" & fld.Caption & """ size=""45"" formControlName=""" & fld.Name & """>")
                sb.AppendLine("                </div>")

            End If
        Next

        sb.AppendLine("            </section>")
        sb.AppendLine("            <div class=""modal-footer"">")
        sb.AppendLine("                <button type=""button"" class=""btn btn-outline"" (click)=""opened = false"">Cancel</button>")
        sb.AppendLine("                <button type=""submit"" class=""btn btn-primary"">Save</button>")
        sb.AppendLine("            </div>")
        sb.AppendLine("        </form>")
        sb.AppendLine("    </div>")
        sb.AppendLine("</clr-modal>")
        sb.AppendLine("")
        sb.AppendLine("<clr-modal [(clrModalOpen)]=""confirmOpened"">")
        sb.AppendLine("    <h3 class=""modal-title"">Delete a %objname%</h3>")
        sb.AppendLine("    <div class=""modal-body"">")
        sb.AppendLine("        <form [formGroup]=""%obj%Form"" novalidate (ngSubmit)=""save(%obj%Form.value, %obj%Form.valid)"">")
        sb.AppendLine("            <p> Are you sure to delete this %objname%? </p>")
        sb.AppendLine("            <div class=""modal-footer"">")
        sb.AppendLine("                <button type=""button"" class=""btn btn-outline"" (click)=""confirmOpened = false"">Cancel</button>")
        sb.AppendLine("                <button type=""submit"" class=""btn btn-danger"" (click)=""onConfirmDeletion()"">Delete</button>")
        sb.AppendLine("            </div>")
        sb.AppendLine("        </form>")
        sb.AppendLine("    </div>")
        sb.AppendLine("</clr-modal>")
        sb.AppendLine("")
        sb.AppendLine("<clr-datagrid [(clrDgSingleSelected)]=""current%obj%"">")

        isFirst = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                'If Not isFirst Then
                '    sb.Append(",")
                'End If
                isFirst = False
                sb.AppendLine("    <clr-dg-column>" & fld.Caption & "<clr-dg-string-filter [clrDgStringFilter]=""_filter_%obj%_" & fld.Name & """></clr-dg-string-filter></clr-dg-column>")
            End If
        Next

        sb.AppendLine("")
        sb.AppendLine("    <clr-dg-row *clrDgItems=""let %obj% of %obj%Array"" [clrDgItem]=""%obj%"">")
        'sb.AppendLine("        <clr-dg-action-overflow>")
        'sb.AppendLine("            <button class=""action-item"" (click)=""onEdit(%obj%)"">Edit</button>")
        'sb.AppendLine("            <button class=""action-item"" (click)=""onDelete(%obj%)"">Delete</button>")
        'sb.AppendLine("        </clr-dg-action-overflow>")


        isFirst = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                'If Not isFirst Then
                '    sb.Append(",")
                'End If
                isFirst = False
                sb.AppendLine("        <clr-dg-cell>{{%obj%." & fld.Name & "}}</clr-dg-cell>")
            End If
        Next
        sb.AppendLine("    </clr-dg-row>")
        sb.AppendLine("    <clr-dg-footer>")
        sb.AppendLine("        {{pagination.firstItem + 1}} - {{pagination.lastItem + 1}} of {{%obj%Array.length}} records")
        sb.AppendLine("        <clr-dg-pagination #pagination [clrDgTotalItems]=""%obj%Array.length"" [clrDgPageSize]=""10""></clr-dg-pagination>")
        sb.AppendLine("    </clr-dg-footer>")
        sb.AppendLine("</clr-datagrid>")
        sb.AppendLine(" ")

        'Selected item: <span  *ngIf="current%obj%.%obj%Id !=null">{{current%obj%.name}}</span>

        ss = sb.ToString()
        ss = ss.Replace("%obj%", P.Name.ToLower())
        ss = ss.Replace("%objname%", ot.the_Comment & " \ " & P.Caption)
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name.ToLower())

        Tool_WriteFile(ss, textBoxOutPutFolder.Text & "\ts\" + P.Name.ToLower() + "\", P.Name.ToLower() + ".component.html", False)


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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtNS.TextChanged
        SaveSetting("L2BUILDER", "EXT2NET_" & Manager.Site, "DEFNS", txtNS.Text)
    End Sub
End Class