Imports System.IO
Imports System.Text

Public Class frmWebAPI_Amexio
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
            sw.AppendLine("using System;")
            sw.AppendLine("using System.Collections.Generic;")
            sw.AppendLine("using System.ComponentModel.DataAnnotations;")
            sw.AppendLine("using System.ComponentModel.DataAnnotations.Schema;")

            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            If txtNS.Text <> "" Then
                sw.Append(vbCrLf & "namespace " & txtNS.Text & ".models { ")
            Else
                pkg = ot.Package
                sw.Append(vbCrLf & "namespace " & pkg.Name & ".models { ")
            End If

            sw.Append(vbCrLf & vbTab & "/* " & ot.Name & " -  " & ot.the_Comment & " */ ")
            ot.PART.Sort = "sequence"
            sw.Append(PartMake_GenStores(ot.PART))
            sw.Append(vbCrLf & "}")
            Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\models\", ot.Name + ".cs", False)

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

            sw.Append(vbCrLf & "export namespace " & ot.Name & " { ")


            sw.Append(vbCrLf & vbTab & "/* " & ot.Name & " -  " & ot.the_Comment & " */ ")

            sw.Append(PartMake_TSList(ot.PART))
            sw.Append(vbCrLf & "}")
            Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\ts\", ot.Name + ".ts", False)

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



            '''''''''''''''''' make type level component
            TypeMake_Component(ot)

            Application.DoEvents()
        Next



        AppMake_module()

        '''''''''''  app.service 
        sw = New StringBuilder

        sw.AppendLine("import { Injectable } from '@angular/core'; ")
        sw.AppendLine("import { HttpClient, HttpRequest, HttpClientModule, HttpHeaders, HttpResponse } from '@angular/common/http'; ")
        sw.AppendLine("import { Observable,BehaviorSubject } from 'rxjs'; ")
        sw.AppendLine("import { environment } from '../environments/environment';")
        sw.AppendLine("")
        For i = 0 To chkObjType.CheckedItems.Count - 1
            ti = chkObjType.CheckedItems(i)
            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sw.AppendLine("import { %type% } from ""app/%type%"";".Replace("%type%", ot.Name))
            Application.DoEvents()
        Next

        sw.AppendLine("	")
        sw.AppendLine("export class ComboInfo{ ")
        sw.AppendLine("	id:string; ")
        sw.AppendLine("	name:string; ")
        sw.AppendLine("} ")
        sw.AppendLine(" ")
        sw.AppendLine("@Injectable() ")
        sw.AppendLine("export class AppService { ")
        sw.AppendLine("	private serviceURL: string = environment.baseAppUrl; ")
        sw.AppendLine("	 ")
        sw.AppendLine("	 constructor(private http:HttpClient) {  ")
        sw.AppendLine("		this.RefreshCombo(); ")
        sw.AppendLine("	} ")
        sw.AppendLine("	")

        sw.AppendLine(" ")
        For i = 0 To chkObjType.CheckedItems.Count - 1
            ti = chkObjType.CheckedItems(i)
            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sw.AppendLine(Make_AppServiceList(ot.PART))
            Application.DoEvents()
        Next

        sw.AppendLine(" ")
        For i = 0 To chkObjType.CheckedItems.Count - 1
            ti = chkObjType.CheckedItems(i)
            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sw.AppendLine(Make_AppComboSupport(ot.PART))
            Application.DoEvents()
        Next

        sw.AppendLine(" ")
        sw.AppendLine("public RefreshCombo(){")
        For i = 0 To chkObjType.CheckedItems.Count - 1
            ti = chkObjType.CheckedItems(i)
            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sw.AppendLine(Make_AppComboRefresh(ot.PART))
            Application.DoEvents()
        Next
        sw.AppendLine("}")
        sw.AppendLine(" ")


        sw.AppendLine(" // enum support")

        For i = 1 To model.FIELDTYPE.Count
            ft = model.FIELDTYPE.Item(i)
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                sw.AppendLine(vbCrLf & vbTab & "/* " & ft.Name & " - " & ft.the_Comment & " */ ")
                sw.AppendLine("	public enum" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & "Combo(){")
                sw.AppendLine("		return this.enum" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & ";")
                sw.AppendLine("	}")
                sw.AppendLine("	enum" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & ":Array<ComboInfo> =[")

                For eidx = 1 To ft.ENUMITEM.Count
                    sw.Append(vbCrLf & vbTab)
                    If (eidx > 1) Then
                        sw.Append(",")
                    End If
                    ei = ft.ENUMITEM.Item(eidx)
                    sw.Append(" {id:'" & ei.NameValue & "',name:'" & ei.Name & "'}")
                Next
                sw.AppendLine("	];")
            End If
            Application.DoEvents()
        Next

        sw.AppendLine(" ")




        ' end class
        sw.AppendLine("}")

        Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\ts\", "app.service.ts", False)

        MsgBox("OK")
    End Sub




    Sub AppMake_module()

        Dim i As Integer
        Dim j As Integer
        Dim ti As tmpInst

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim isFirst As Boolean

        Dim sb As StringBuilder
        sb = New StringBuilder




        sb.AppendLine("import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; ")
        sb.AppendLine("import { BrowserModule } from '@angular/platform-browser'; ")
        sb.AppendLine("import { NgModule } from '@angular/core'; ")
        sb.AppendLine("import { FormsModule } from '@angular/forms'; ")
        sb.AppendLine("import { HttpClientModule, HttpClient } from '@angular/common/http'; ")
        sb.AppendLine("import { AmexioWidgetModule,CommonHttpService } from 'amexio-ng-extensions'; ")
        sb.AppendLine("import {ThemeService} from './theme.service'; ")
        sb.AppendLine("import {CookieService} from 'ngx-cookie-service'; ")
        sb.AppendLine("import {AppService} from 'app/app.service'; ")
        'sb.AppendLine("import { ReactiveFormsModule } from '@angular/forms'; ")
        sb.AppendLine(" ")
        sb.AppendLine("import { AppComponent } from './app.component'; ")
        sb.AppendLine("import { ROUTING } from './app.routing'; ")
        sb.AppendLine("import { AboutComponent } from './about/about.component'; ")
        sb.AppendLine("import { TopnavComponent } from './topnav/topnav.component'; ")
        sb.AppendLine(" ")

        For i = 0 To chkObjType.CheckedItems.Count - 1

            ti = chkObjType.CheckedItems(i)

            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sb.AppendLine(" ")
            sb.AppendLine("import { " & ot.Name & "Component } from './" & ot.Name & "/" & ot.Name & ".component'; // " + ot.the_Comment)
            Make_AddCompServiceToAPP(sb, ot.PART)
        Next


        sb.AppendLine(" ")
        sb.AppendLine("@NgModule({ ")
        sb.AppendLine("    declarations: [ ")
        sb.AppendLine("        AppComponent, ")


        For i = 0 To chkObjType.CheckedItems.Count - 1

            ti = chkObjType.CheckedItems(i)

            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sb.AppendLine(" ")
            sb.AppendLine(" " & ot.Name & "Component ,  // " + ot.the_Comment)
            Make_AddCompToAPP(sb, ot.PART)


        Next


        sb.AppendLine("		 ")
        sb.AppendLine("        AboutComponent, ")
        sb.AppendLine("        TopnavComponent ")
        sb.AppendLine("		 ")
        sb.AppendLine("    ], ")
        sb.AppendLine("    imports: [ ")
        sb.AppendLine("        BrowserAnimationsModule, ")
        sb.AppendLine("        BrowserModule, ")
        sb.AppendLine("        FormsModule, ")
        'sb.AppendLine("		   ReactiveFormsModule, ")
        sb.AppendLine("        HttpClientModule, ")
        sb.AppendLine("        AmexioWidgetModule, ")
        sb.AppendLine(" ")
        sb.AppendLine("        ROUTING ")
        sb.AppendLine("    ], ")
        sb.AppendLine("    providers: [CommonHttpService,HttpClient,ThemeService ")

        For i = 0 To chkObjType.CheckedItems.Count - 1
            ti = chkObjType.CheckedItems(i)
            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            Make_AddServiceToAPP(sb, ot.PART)
        Next
        sb.AppendLine("	,AppService ")
        sb.AppendLine("	,CookieService ")
        sb.AppendLine("	], ")
        sb.AppendLine("    bootstrap: [AppComponent] ")
        sb.AppendLine("}) ")
        sb.AppendLine("export class AppModule { ")
        sb.AppendLine("} ")




        Tool_WriteFile(sb.ToString(), textBoxOutPutFolder.Text & "\ts\", "app.module.ts", False)


        '''''''''''''   routing ''''''''''''''
        sb = New StringBuilder

        sb.AppendLine("import { ModuleWithProviders } from '@angular/core/src/metadata/ng_module'; ")
        sb.AppendLine("import { Routes, RouterModule } from '@angular/router'; ")
        sb.AppendLine(" ")
        sb.AppendLine("import { AboutComponent } from './about/about.component'; ")


        For i = 0 To chkObjType.CheckedItems.Count - 1

            ti = chkObjType.CheckedItems(i)

            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sb.AppendLine("import { " & ot.Name & "Component } from './" & ot.Name & "/" & ot.Name & ".component'; ")

        Next

        sb.AppendLine("export const ROUTES: Routes = [ ")
        sb.AppendLine("    {path: '', redirectTo: 'home', pathMatch: 'full'}, ")
        sb.AppendLine("	 ")

        For i = 0 To chkObjType.CheckedItems.Count - 1

            ti = chkObjType.CheckedItems(i)

            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sb.AppendLine("	{path: '" & ot.Name & "', component:  " & ot.Name & "Component}, ")

        Next

        sb.AppendLine("	{path: 'home', component: AboutComponent} ")
        sb.AppendLine("]; ")
        sb.AppendLine(" ")
        sb.AppendLine("export const ROUTING: ModuleWithProviders = RouterModule.forRoot(ROUTES);")

        Tool_WriteFile(sb.ToString(), textBoxOutPutFolder.Text & "\ts\", "app.routing.ts", False)



        ''''''''''''' menu ''''''''''''''
        sb = New StringBuilder
        sb.AppendLine(" { ")
        sb.AppendLine("  ""data"":[ ")
        sb.AppendLine("	{ ")
        sb.AppendLine("	""text"": ""Home"", ")
        sb.AppendLine("	""icon"" : ""fa fa-home fa-fw fa-lg"", ")
        sb.AppendLine("	""mdbIcon"" : ""home"", ")
        sb.AppendLine("	""routerLink"" : ""/home"", ")
        sb.AppendLine("	""selected"":true ")
        sb.AppendLine("	} ")


        isFirst = True
        For i = 0 To chkObjType.CheckedItems.Count - 1

            ti = chkObjType.CheckedItems(i)

            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            sb.AppendLine("	,{ ")
            sb.AppendLine("	  ""text"": """ & ot.the_Comment & """, ")
            sb.AppendLine("	  ""icon"" : ""fa " & ot.objIconCls & " fa-fw"", ")
            sb.AppendLine("	  ""routerLink"" : ""/" & ot.Name & """ ")
            sb.AppendLine("	} ")

        Next

        sb.AppendLine("	] ")
        sb.AppendLine("} ")

        Tool_WriteFile(sb.ToString(), textBoxOutPutFolder.Text & "\ts\", "sidebar.json", False)

    End Sub


    Sub Make_AddCompToAPP(sb As StringBuilder, PCOL As MTZMetaModel.MTZMetaModel.PART_col)
        Dim i As Integer
        Dim P As MTZMetaModel.MTZMetaModel.PART
        For i = 1 To PCOL.Count
            P = PCOL.Item(i)
            sb.AppendLine("  " & P.Name & "Component, // " + P.Caption)
            Make_AddCompToAPP(sb, P.PART)
        Next
    End Sub

    Sub Make_AddServiceToAPP(sb As StringBuilder, PCOL As MTZMetaModel.MTZMetaModel.PART_col)
        Dim i As Integer
        Dim P As MTZMetaModel.MTZMetaModel.PART
        For i = 1 To PCOL.Count
            P = PCOL.Item(i)
            sb.AppendLine("  ," & P.Name & "_Service")
            Make_AddServiceToAPP(sb, P.PART)
        Next

    End Sub


    Sub Make_AddCompServiceToAPP(sb As StringBuilder, PCOL As MTZMetaModel.MTZMetaModel.PART_col)
        Dim i As Integer
        Dim P As MTZMetaModel.MTZMetaModel.PART
        For i = 1 To PCOL.Count
            P = PCOL.Item(i)
            sb.AppendLine("import { " & P.Name & "Component } from './" & P.Name & "/" & P.Name & ".component'; // " + P.Caption)
            sb.AppendLine("import { " & P.Name & "_Service } from 'app/" & P.Name & ".service'; ")
            Make_AddCompServiceToAPP(sb, P.PART)
        Next

    End Sub


    Sub TypeMake_Component(ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Dim sb As StringBuilder
        sb = New StringBuilder


        sb.AppendLine("<amexio-card-pane [enableHeader] =""true"" [enableFooter] =""false"">")
        sb.AppendLine("  <amexio-pane-header>")
        sb.AppendLine(" <i class=""fa " & ot.objIconCls & """ aria-hidden=""True""></i> %typename% ")
        sb.AppendLine("  </amexio-pane-header>")
        sb.AppendLine("  <amexio-pane-body>")
        sb.AppendLine("	<amexio-tab-pane #svd_tabs [closable]=""false"">")

        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim isFirst As Boolean
        Dim i As Integer
        Dim j As Integer

        isFirst = True
        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            If isFirst Then
                isFirst = False
                sb.AppendLine("		<amexio-tab  title=""" & P.Caption & """ [disabled]=""false"" [active]=""true"" >")
            Else
                sb.AppendLine("		<amexio-tab  title=""" & P.Caption & """ [disabled]=""false"" >")
            End If

            sb.AppendLine("			<app-" & P.Name & "></app-" & P.Name & ">")
            sb.AppendLine("		</amexio-tab>")
            sb.AppendLine("		")
        Next

        sb.AppendLine("	</amexio-tab-pane>")
        sb.AppendLine("  </amexio-pane-body>")
        sb.AppendLine("</amexio-card-pane>")


        Dim ss As String
        ss = sb.ToString()
        ss = ss.Replace("%typename%", ot.the_Comment)
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name)

        Tool_WriteFile(ss, textBoxOutPutFolder.Text & "\ts\" + ot.Name + "\", ot.Name + ".component.html", False)



        sb = New StringBuilder
        sb.AppendLine("import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core'; ")
        sb.AppendLine("import { TabPaneComponent} from ""amexio-ng-extensions""; ")
        sb.AppendLine("import { %type% } from ""app/%type%""; ")
        sb.AppendLine("import { AppService } from ""app/app.service""; ")
        sb.AppendLine(" ")
        sb.AppendLine("@Component({ ")
        sb.AppendLine("  selector: 'app-%type%', ")
        sb.AppendLine("  templateUrl: './%type%.component.html', ")
        sb.AppendLine("  styleUrls: ['./%type%.component.scss'] ")
        sb.AppendLine("}) ")
        sb.AppendLine("export class %type%Component implements OnInit { ")
        sb.AppendLine(" ")
        sb.AppendLine("  constructor(public AppService:AppService) { } ")
        sb.AppendLine(" ")
        sb.AppendLine("  ngOnInit() { ")
        sb.AppendLine("  } ")
        sb.AppendLine(" ")
        sb.AppendLine("}")

        ss = sb.ToString()
        ss = ss.Replace("%typename%", ot.the_Comment)
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name)

        Tool_WriteFile(ss, textBoxOutPutFolder.Text & "\ts\" + ot.Name + "\", ot.Name + ".component.ts", False)

        Tool_WriteFile(" ", textBoxOutPutFolder.Text & "\ts\" + ot.Name + "\", ot.Name + ".component.scss", False)

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
            P.PART.Sort = "sequence"
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

            sw.Append(vbCrLf & " public class  " & P.Name & " { // " & P.Caption)

            sw.Append(vbCrLf & vbTab & " public System.Guid  " & P.Name & "Id{ get; set; } // Primary key field")

            If Not isroot Then
                Dim ParentPart As MTZMetaModel.MTZMetaModel.PART
                ParentPart = P.Parent.Parent

                sw.Append(vbCrLf & vbTab & "[Required]") ' [ForeignKey(""FK_" & P.Name  & "_Parent"")]")
                'sw.Append(vbCrLf & vbTab & " public " & ParentPart.Name & "  " & ParentPart.Name & " { get; set; } // Parent part -> " & ParentPart.Caption)
                sw.Append(vbCrLf & vbTab & " public System.Guid  " & ParentPart.Name & "Id { get; set; } // Parent part Id -> " & ParentPart.Caption)
            Else
                If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then

                    '  все  разделы верхнего уровня  впихиваем в  0 -раздел
                    If P.Sequence = 0 Then

                        For i = 1 To ot.PART.Count
                            Dim SiblingPart As MTZMetaModel.MTZMetaModel.PART
                            SiblingPart = ot.PART.Item(i)
                            If SiblingPart.Sequence <> 0 Then
                                'sw.Append(vbCrLf & vbTab & " public List<" & SiblingPart.Name & ">  " & SiblingPart.Name.ToLower & " { get; set; } // " & SiblingPart.Caption)
                            End If
                        Next

                    Else
                        For i = 1 To ot.PART.Count
                            Dim SiblingPart As MTZMetaModel.MTZMetaModel.PART
                            SiblingPart = ot.PART.Item(i)
                            If SiblingPart.Sequence = 0 Then

                                sw.Append(vbCrLf & vbTab & "[Required]") ' [ForeignKey(""FK_" & P.Name  & "_Document"")]")
                                'sw.Append(vbCrLf & vbTab & " public " & SiblingPart.Name & "  " & SiblingPart.Name & " { get; set; } // " & SiblingPart.Caption)
                                sw.Append(vbCrLf & vbTab & " public System.Guid  " & SiblingPart.Name & "Id { get; set; } // Id for " & SiblingPart.Caption)
                            End If
                        Next

                    End If






                End If
            End If

            For i = 1 To P.PART.Count
                Dim ChildPart As MTZMetaModel.MTZMetaModel.PART
                ChildPart = P.PART.Item(i)
                'sw.Append(vbCrLf & vbTab & " public List<" & ChildPart.Name & ">  " & ChildPart.Name.ToLower & " { get; set; } // " & ChildPart.Caption)
            Next


            Dim bf As MTZMetaModel.MTZMetaModel.FIELD
            bf = Nothing
            P.FIELD.Sort = "sequence"
            For i = 1 To P.FIELD.Count
                fld = P.FIELD.Item(i)

                If fld.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    If bf Is Nothing Then
                        bf = fld
                    End If

                End If
                ft = fld.FieldType

                Dim NullMark As String = ""

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                    If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                        sw.Append(vbCrLf & vbTab & "[Required]")
                        NullMark = ""
                    Else
                        NullMark = "?"
                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                        If ft.Name.ToLower = "file" Then
                            sw.Append(vbCrLf & vbTab & "public string" & " " & fld.Name & "{ get; set; } // " & fld.Caption)
                        Else
                            If fld.DataSize > 0 Then
                                sw.Append(vbCrLf & vbTab & "public string" & "  " & fld.Name & "{ get; set; } // " & fld.Caption)
                            Else
                                sw.Append(vbCrLf & vbTab & "public string" & "  " & fld.Name & "{ get; set; } // " & fld.Caption)
                            End If

                        End If

                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                        If ft.Name.ToLower = "date" Then
                            sw.Append(vbCrLf & vbTab & "public DateTime" & NullMark & "  " & fld.Name & "{ get; set; } // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "time" Then
                            sw.Append(vbCrLf & vbTab & "public DateTime" & NullMark & "  " & fld.Name & "{ get; set; } // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "datetime" Then
                            sw.Append(vbCrLf & vbTab & "public DateTime" & NullMark & "  " & fld.Name & "{ get; set; } // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "birthday" Then
                            sw.Append(vbCrLf & vbTab & "public DateTime" & NullMark & "  " & fld.Name & "{ get; set; } // " & fld.Caption)
                        End If
                    End If

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then

                        sw.Append(vbCrLf & vbTab & "public double" & NullMark & "  " & fld.Name & "{ get; set; } // " & fld.Caption)

                    End If
                End If


                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                    sw.Append(vbCrLf & vbTab & "public int" & NullMark & "  " & fld.Name & "{ get; set; } // " & fld.Caption)


                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                    sw.Append(vbCrLf & vbTab & "public enum_" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & NullMark & "  " & fld.Name & "{ get; set; } // " & fld.Caption)

                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                    Dim refp As MTZMetaModel.MTZMetaModel.PART
                    refp = fld.RefToPart

                    ' sw.Append(vbCrLf & vbTab & "[ForeignKey(""FK_" & P.Name  & "_to_" & refp.Name  & "_as_" & fld.Name  & """)]")
                    'sw.Append(vbCrLf & vbTab & "public " & refp.Name & " " & fld.Name & "{ get; set; } //" & fld.Caption)
                    sw.Append(vbCrLf & vbTab & "public System.Guid" & NullMark & "  " & fld.Name & " { get; set; } //" & fld.Caption)



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

        pcol.Sort = "sequence"
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



            sw.Append(vbCrLf & " export interface   " & P.Name & " { // " & P.Caption)

            sw.Append(vbCrLf & vbTab & DeCap(P.Name) & "Id:string; // Primary key field")

            If Not isroot Then
                Dim ParentPart As MTZMetaModel.MTZMetaModel.PART
                ParentPart = P.Parent.Parent
                'sw.Append(vbCrLf & vbTab & " parentStructRowId :string; // Parent part -> " & ParentPart.Name)
                sw.Append(vbCrLf & vbTab & " " & DeCap(ParentPart.Name) & "Id :string // Parent part Id -> " & ParentPart.Caption)
            Else
                'If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                '    sw.Append(vbCrLf & vbTab & " instanceId:string // Document ID ")
                'End If

                If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then

                    '  все  разделы верхнего уровня  впихиваем в  0 -раздел
                    If P.Sequence = 0 Then

                        'For i = 1 To ot.PART.Count
                        '    Dim SiblingPart As MTZMetaModel.MTZMetaModel.PART
                        '    SiblingPart = ot.PART.Item(i)
                        '    If SiblingPart.Sequence <> 0 Then
                        '        sw.Append(vbCrLf & vbTab & " public List<" & SiblingPart.Name  & ">  " & SiblingPart.Name.ToLower & " { get; set; } // " & SiblingPart.Caption)
                        '    End If
                        'Next

                    Else
                        For i = 1 To ot.PART.Count
                            Dim SiblingPart As MTZMetaModel.MTZMetaModel.PART
                            SiblingPart = ot.PART.Item(i)
                            If SiblingPart.Sequence = 0 Then
                                'sw.Append(vbCrLf & vbTab & " public System.Guid  " & SiblingPart.Name  & "Id { get; set; } // " & SiblingPart.Caption)
                                'sw.Append(vbCrLf & vbTab & "[Required] [ForeignKey(""FK_" & P.Name  & "_Document"")]")
                                sw.Append(vbCrLf & vbTab & "  " & DeCap(SiblingPart.Name) & "Id:string; // " & SiblingPart.Caption)
                            End If
                        Next

                    End If

                    '        sw.Append(vbCrLf & vbTab & " public System.Guid  instanceId { get; set; } // Document ID ")
                End If
            End If





            Dim hasRef As Boolean
            Dim bf As MTZMetaModel.MTZMetaModel.FIELD
            bf = Nothing
            hasRef = False
            P.FIELD.Sort = "sequence"
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
                    sw.Append(vbCrLf & vbTab & fld.Name & ":string; //" & fld.Caption & " -> " & refp.Name)
                    hasRef = True

                End If
            Next

            If hasRef Then
                sw.Append(vbCrLf & vbTab & "// add dereference fields ")
                ''''' add dereference ref field
                P.FIELD.Sort = "sequence"
                For i = 1 To P.FIELD.Count
                    fld = P.FIELD.Item(i)
                    ft = fld.FieldType

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                        Dim refp As MTZMetaModel.MTZMetaModel.PART
                        refp = fld.RefToPart
                        sw.Append(vbCrLf & vbTab & fld.Name & "_name :string; //" & " dereference for " & refp.Name)
                    End If
                Next
            End If


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

        pcol.Sort = "sequence"
        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & PartMake_Service(P))

            sw.Append(PartMake_ServiceList(P.PART))

        Next
        Return sw.ToString()

    End Function


    Private Function Make_AppServiceList(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim P1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer


        pcol.Sort = "sequence"
        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & Make_AppService(P))

            sw.Append(Make_AppServiceList(P.PART))

        Next
        Return sw.ToString()

    End Function



    Private Function Make_AppComboSupport(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sb As StringBuilder
        sb = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer


        pcol.Sort = "sequence"
        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sb.AppendLine("	public Combo" & P.Name & ":Array<ComboInfo> = []; ")
            sb.AppendLine("	get" & P.Name & "(): Observable<ComboInfo[]> { ")
            sb.AppendLine("		return this.http.get<ComboInfo[]>(this.serviceURL + '/" & P.Name & "/Combo'); ")
            sb.AppendLine(" }")

            sb.Append(Make_AppComboSupport(P.PART))

        Next
        Return sb.ToString()

    End Function




    Private Function Make_AppComboRefresh(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sb As StringBuilder
        sb = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer


        pcol.Sort = "sequence"
        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sb.AppendLine("	this.get" & P.Name & "().subscribe(data => {this.Combo" & P.Name & "=data;}); ")

            sb.Append(Make_AppComboRefresh(P.PART))

        Next
        Return sb.ToString()

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
        P.FIELD.Sort = "sequence"
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




        Dim isroot As Boolean = False

        If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
            ot = P.Parent.Parent
            isroot = True
        End If



        Dim AddByParent As Boolean

        AddByParent = False


        If Not isroot Then
            AddByParent = True
        Else
            If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then


                '  все  разделы верхнего уровня  впихиваем в  0 -раздел
                If P.Sequence <> 0 Then
                    AddByParent = True
                End If
            End If
        End If



        If AddByParent Then
            sb.AppendLine("	//Fetch %obj% by parent")
            sb.AppendLine("    get_%obj%ByParent(parentId: string): Observable<%type%.%obj%[]> {")
            sb.AppendLine("        let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })")
            sb.AppendLine("		   console.log(this.serviceURL +'/%obj%/byparent/'+ parentId)")
            sb.AppendLine("        return this.http.get<%type%.%obj%[]>(this.serviceURL + '/%obj%/byparent/' + parentId, { headers: cpHeaders })//.catch(err => { console.log(err) return Observable.of(err) })")
            sb.AppendLine("    }	")
            sb.AppendLine("	")
        End If

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
        sb.AppendLine("        return this.http.put(this.serviceURL + '/%obj%/' + %obj%." & DeCap(P.Name) & "Id, %obj%, { headers: cpHeaders })")
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
        ss = ss.Replace("%obj%", P.Name)
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name)

        Tool_WriteFile(ss, textBoxOutPutFolder.Text & "\ts\", P.Name + ".service.ts", False)

    End Function




    Private Function PartMake_Components(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim P1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer

        pcol.Sort = "sequence"
        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & PartMake_PartComponent(P))

            sw.Append(PartMake_Components(P.PART))

        Next
        Return sw.ToString()

    End Function

    Private Function Make_AppService(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        ot = LATIR2Framework.ObjectTypeHelper.TypeForStruct(P)
        Dim ParentPart As MTZMetaModel.MTZMetaModel.PART = P
        Dim i As Integer
        Dim isFirst As Boolean = True
        Dim sb As StringBuilder
        Dim ss As String

        Dim isRoot As Boolean = False
        Dim hasChild As Boolean

        If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
            If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                If P.Sequence = 0 Then
                    isRoot = True

                    If ot.PART.Count > 1 Then
                        hasChild = True
                    End If
                Else
                    For i = 1 To ot.PART.Count
                        If ot.PART.Item(i).Sequence = 0 Then
                            ParentPart = ot.PART.Item(i)
                            Exit For
                        End If
                    Next
                End If

                If P.PART.Count > 0 Then
                    hasChild = True
                End If
            Else
                isRoot = True
                If P.PART.Count > 0 Then
                    hasChild = True
                End If
            End If
        Else
            ParentPart = P.Parent.Parent
            If P.PART.Count > 0 Then
                hasChild = True
            End If
        End If
        sb = New StringBuilder

        sb.AppendLine("	// support for Selected %type%.%obj%; ")
        sb.AppendLine("	public Last%obj%:%type%.%obj% = {} as %type%.%obj%; ")
        sb.AppendLine("	public Selected%obj% = new BehaviorSubject<%type%.%obj%>({} as %type%.%obj%); ")
        sb.AppendLine("	public pushSelected%obj%(item:%type%.%obj%){ ")
        sb.AppendLine("		console.log(""change Selected %obj%""); ")
        sb.AppendLine("		this.Last%obj%=item; ")
        sb.AppendLine("		this.Selected%obj%.next(item); ")
        sb.AppendLine("		 ")
        sb.AppendLine("	} ")
        sb.AppendLine("	public current%obj% = this.Selected%obj%.asObservable(); ")

        ss = sb.ToString()
        ss = ss.Replace("%obj%", P.Name)
        ss = ss.Replace("%parent%", ParentPart.Name)
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name)

        Return ss
    End Function

    Private Function PartMake_PartComponent(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return " "
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        ot = LATIR2Framework.ObjectTypeHelper.TypeForStruct(P)
        Dim sb As StringBuilder
        Dim ss As String
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim refP As MTZMetaModel.MTZMetaModel.PART
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim ParentPart As MTZMetaModel.MTZMetaModel.PART = P
        Dim i As Integer
        Dim isFirst As Boolean = True

        Dim isRoot As Boolean = False
        Dim hasChild As Boolean
#Region "init"
        If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
            If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                If P.Sequence = 0 Then
                    isRoot = True

                    If ot.PART.Count > 1 Then
                        hasChild = True
                    End If
                Else
                    For i = 1 To ot.PART.Count
                        If ot.PART.Item(i).Sequence = 0 Then
                            ParentPart = ot.PART.Item(i)
                            Exit For
                        End If
                    Next
                End If

                If P.PART.Count > 0 Then
                    hasChild = True
                End If
            Else
                isRoot = True
                If P.PART.Count > 0 Then
                    hasChild = True
                End If
            End If
        Else
            ParentPart = P.Parent.Parent
            If P.PART.Count > 0 Then
                hasChild = True
            End If
        End If
#End Region

#Region "SCSS"

        ' write style file
        Tool_WriteFile("  ", textBoxOutPutFolder.Text & "\ts\" + P.Name + "\", P.Name + ".component.scss", False)
#End Region


#Region "component"

        ' write component file
        sb = New StringBuilder()
        sb.AppendLine("import { Component, OnInit, Input, Output, EventEmitter } from ""@angular/core"";")
        sb.AppendLine("import { %obj%_Service } from ""app/%obj%.service"";")
        sb.AppendLine("import { AppService } from ""app/app.service"";")
        sb.AppendLine("import { Observable } from ""rxjs/Observable"";")
        sb.AppendLine("")
        sb.AppendLine("import { %type% } from ""app/%type%"";")
        sb.AppendLine("import {  Validators } from ""@angular/forms"";")
        sb.AppendLine("")
        sb.AppendLine("import 'rxjs/add/operator/switchMap';")
        sb.AppendLine("import 'rxjs/add/operator/publishReplay';")
        sb.AppendLine("")
        sb.AppendLine("const MODE_LIST = 0;")
        sb.AppendLine("const MODE_NEW = 1;")
        sb.AppendLine("const MODE_EDIT = 2;")
        sb.AppendLine("")

        sb.AppendLine("@Component({")
        sb.AppendLine("	   selector: 'app-%obj%',")
        sb.AppendLine("    styleUrls: ['./%obj%.component.scss'],")
        sb.AppendLine("    templateUrl: './%obj%.component.html',")
        sb.AppendLine("})")
        sb.AppendLine("export class %obj%Component implements OnInit {")
        sb.AppendLine("")

        sb.AppendLine("    %obj%Array: Array<%type%.%obj%> = [];")
        sb.AppendLine("    opened: boolean = false;")
        sb.AppendLine("    confirmOpened: boolean = false;")
        sb.AppendLine("    mode: Number = MODE_LIST;")
        sb.AppendLine("    current%obj%: %type%.%obj% = {} as %type%.%obj%;")
        sb.AppendLine("    formMsg: string = '';")


        sb.AppendLine("")
        sb.AppendLine("    constructor( private %obj%_Service: %obj%_Service,  public AppService:AppService ) {")
        If Not isRoot Then
            sb.AppendLine("                 this.AppService.current%parent%.subscribe(si =>{ this.refresh%obj%(); });")
        End If
        sb.AppendLine("    }")
        sb.AppendLine("")

        sb.AppendLine("    ngOnInit() {")
        sb.AppendLine("        this.refresh%obj%();")
        sb.AppendLine("    }")
        sb.AppendLine("")
        If isRoot Then
            sb.AppendLine("    refresh%obj%() {")
            sb.AppendLine("		   console.log(""refreshing %obj%""); ")
            sb.AppendLine("        this.%obj%_Service.getAll_%obj%s().subscribe(%obj%Array => { this.%obj%Array = %obj%Array; })")
            sb.AppendLine("        this.current%obj% = {} as %type%.%obj%;")
            If hasChild Then
                sb.AppendLine("        console.log(""clear selection for %obj% on refresh"");")
                sb.AppendLine("        this.AppService.pushSelected%obj%(this.current%obj%);")
            End If

            sb.AppendLine("    }")
        Else
            sb.AppendLine("    refresh%obj%() {")
            sb.AppendLine("		let item:%type%.%parent%;")
            sb.AppendLine("		item=this.AppService.Last%parent%;")
            sb.AppendLine("		console.log(""refreshing %obj%""); ")
            sb.AppendLine("     this.current%obj% = {} as %type%.%obj%;")
            If hasChild Then
                sb.AppendLine("     console.log(""clear selection for %obj% on refresh"");")
                sb.AppendLine("     this.AppService.pushSelected%obj%(this.current%obj%);")
            End If

            sb.AppendLine("		if(typeof item === 'undefined') { ")
            sb.AppendLine("			console.log(""no parent item for refresh""); ")
            sb.AppendLine("			return; ")
            sb.AppendLine("		} ")
            sb.AppendLine("		if(typeof item." & DeCap(ParentPart.Name) & "Id==='undefined') { ")
            sb.AppendLine("			console.log(""no parent id for refresh""); ")
            sb.AppendLine("			return; ")
            sb.AppendLine("		} ")
            sb.AppendLine("		if(typeof item." & DeCap(ParentPart.Name) & "Id === 'string' ) {")

            sb.AppendLine("        this.%obj%_Service.get_%obj%ByParent(item." & DeCap(ParentPart.Name) & "Id).subscribe(%obj%Array => { this.%obj%Array = %obj%Array; })")
            sb.AppendLine("      }")
            sb.AppendLine("    }")
        End If

        sb.AppendLine("")
        sb.AppendLine("	   getData(){")
        sb.AppendLine("		this.refresh%obj%();")
        sb.AppendLine("		return this.%obj%Array ;")
        sb.AppendLine("	   }")
        sb.AppendLine("")
        sb.AppendLine("    onSelect(item: %type%.%obj%) {")
        sb.AppendLine("        this.current%obj% = item;")
        If hasChild Then
            sb.AppendLine("        this.AppService.pushSelected%obj%(item);")
        End If
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    onNew() {")
        If Not isRoot Then
            sb.AppendLine("      if(typeof ( this.AppService.Last%parent%." & DeCap(ParentPart.Name) & "Id) === 'string' ) {")
            sb.AppendLine("        this.current%obj% = {} as %type%.%obj%;")
            sb.AppendLine("        this.current%obj%." & DeCap(ParentPart.Name) & "Id = this.AppService.Last%parent%." & DeCap(ParentPart.Name) & "Id;")
        Else
            sb.AppendLine("        this.current%obj% = {} as %type%.%obj%;")
        End If
        sb.AppendLine("        this.opened = true;")
        sb.AppendLine("        this.mode = MODE_NEW;")

        sb.AppendLine("        this.formMsg = 'Создать: ';")
        If Not isRoot Then
            sb.AppendLine("      }")
        End If

        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    onEdit(item: %type%.%obj%) {")
        sb.AppendLine("        this.opened = true;")
        sb.AppendLine("        this.formMsg = 'Изменить: ';")
        sb.AppendLine("        this.mode = MODE_EDIT;")
        sb.AppendLine("        this.current%obj% = item;")
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    onDelete(item: %type%.%obj%) {")
        sb.AppendLine("        this.confirmOpened = true;")
        sb.AppendLine("        this.current%obj% = item;")
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    onConfirmDeletion() {")
        sb.AppendLine("        this.%obj%_Service.delete_%obj%ById(this.current%obj%." & DeCap(P.Name) & "Id).subscribe(() => this.refresh%obj%());")
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
        sb.AppendLine("            alert(""invalid form"");")
        sb.AppendLine("        }")
        sb.AppendLine("    }")
        sb.AppendLine("")
        sb.AppendLine("    backToList() {")
        sb.AppendLine("        this.opened = false;")
        sb.AppendLine("        this.confirmOpened = false;")
        sb.AppendLine("        this.mode = MODE_LIST;")
        sb.AppendLine("        this.current%obj% = {} as %type%.%obj%;")

        If hasChild Then
            sb.AppendLine("        console.log(""clear selection for %obj%"");")
            sb.AppendLine("        this.AppService.pushSelected%obj%(this.current%obj%);")
        End If

        sb.AppendLine("    }")
        sb.AppendLine("}")
        sb.AppendLine(" ")

        ss = sb.ToString()
        ss = ss.Replace("%obj%", P.Name)
        ss = ss.Replace("%parent%", ParentPart.Name)
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name)

        Tool_WriteFile(ss, textBoxOutPutFolder.Text & "\ts\" + P.Name + "\", P.Name + ".component.ts", False)

#End Region
#Region "html"

        ' write component html

        sb = New StringBuilder()
        sb.AppendLine("<!-- edit row pane -->	 ")
        sb.AppendLine(" <amexio-card-pane [showCard]=""opened"" > ")
        sb.AppendLine("	  <amexio-pane-header> ")
        sb.AppendLine("        {{formMsg}} %objname% ")
        sb.AppendLine("      </amexio-pane-header> ")
        sb.AppendLine("     <amexio-pane-body> ")
        sb.AppendLine("     <table cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"" > ")
        sb.AppendLine("     <tbody>")
        isFirst = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                isFirst = False

                '''''''''''''''''''' todo: fieldtype to control map !!!
                sb.AppendLine("     <tr><td width=""100%"" >")


                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                        If ft.Name = "Memo" Then
                            sb.AppendLine(" <amexio-textarea-input [enablePopOver]=""false""  [fieldLabel]=""'" & fld.Caption & "'"" name =""" & fld.Name & """ ")
                            sb.AppendLine("             [placeholder]=""'" & fld.Caption & "'"" ")

                            If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                                sb.AppendLine("            [allowBlank]=""true"" ")
                            Else
                                sb.AppendLine("            [allowBlank]=""false"" [errorMsg] =""'Не задано: " & fld.Caption & "'"" ")
                            End If
                            sb.AppendLine("	            [(ngModel)]=""current%obj%." & fld.Name & """")
                            sb.AppendLine("             [iconFeedBack]=""true"" [noOfrows]=""'5'"" [noOfCols]=""'12'"" ")
                            sb.AppendLine("             [popoverPlacement]=""'top'"" > ")
                            sb.AppendLine("</amexio-textarea-input>")
                            sb.AppendLine("<br/><br/><br/><br/><br/><br/><br/><br/>")



                        Else

                            sb.AppendLine("                    <amexio-text-input [fieldLabel]= ""'" & fld.Caption & "'"" name =""" & fld.Name & """  ")
                            sb.AppendLine("                    [placeholder] = ""'" & fld.Caption & "'"" ")
                            sb.AppendLine("                    [iconFeedBack] = ""true"" [(ngModel)]=""current%obj%." & fld.Name & """ >")
                            sb.AppendLine("                    </amexio-text-input>")


                        End If



                    End If


                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                        sb.AppendLine("  <span>" & fld.Caption & "</span><br/>")
                        If ft.Name.ToLower() = "date" Then
                            sb.AppendLine("  <amexio-date-time-picker  ")
                            sb.AppendLine("        [timepicker]=""false""  ")
                            sb.AppendLine("        [datepicker]=""true""  ")
                            sb.AppendLine("        [(ngModel)]=""current%obj%." & fld.Name & """> ")
                            sb.AppendLine(" </amexio-date-time-picker> ")
                        End If
                        If ft.Name.ToLower() = "datetime" Then
                            sb.AppendLine("  <amexio-date-time-picker  ")
                            sb.AppendLine("        [timepicker]=""true""  ")
                            sb.AppendLine("        [datepicker]=""true""  ")
                            sb.AppendLine("        [(ngModel)]=""current%obj%." & fld.Name & """> ")
                            sb.AppendLine(" </amexio-date-time-picker> ")
                        End If
                        If ft.Name.ToLower() = "time" Then
                            sb.AppendLine("  <amexio-date-time-picker  ")
                            sb.AppendLine("        [timepicker]=""true""  ")
                            sb.AppendLine("        [datepicker]=""false""  ")
                            sb.AppendLine("        [(ngModel)]=""current%obj%." & fld.Name & """> ")
                            sb.AppendLine(" </amexio-date-time-picker> ")
                        End If

                    End If

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then

                        sb.AppendLine(" <amexio-number-input  [enablePopOver]= ""false"" [fieldLabel]=""'" & fld.Caption & "'"" name =""" & fld.Name & """ ")
                        sb.AppendLine("                    [placeholder]=""'" & fld.Caption & "'"" ")

                        If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            sb.AppendLine("            [allowBlank]=""true"" ")
                        Else
                            sb.AppendLine("            [allowBlank]=""false"" [errorMsg] =""'Не задано: " & fld.Caption & "'"" ")
                        End If



                        'sb.AppendLine("                    [minValue]=""1"" ")
                        'sb.AppendLine("                    [minErrorMsg]=""'age can not be less than 1'"" ")
                        'sb.AppendLine("                    [maxValue]=""100""  [maxErrorMsg]=""'age can not be greater than 100'"" ")
                        'sb.AppendLine("                    [iconFeedBack]=""true"" ")
                        'sb.AppendLine("                    [popoverPlacement]=""'right'"" ")
                        sb.AppendLine("	 [(ngModel)]=""current%obj%." & fld.Name & """")
                        sb.AppendLine("                    > ")
                        sb.AppendLine(" </amexio-number-input>")

                    End If


                End If

            End If


            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                sb.AppendLine(" <amexio-number-input  [enablePopOver]= ""false"" [fieldLabel]=""'" & fld.Caption & "'"" name =""" & fld.Name & """ ")
                sb.AppendLine("                    [placeholder]=""'" & fld.Caption & "'"" ")

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("            [allowBlank]=""true"" ")
                Else
                    sb.AppendLine("            [allowBlank]=""false"" [errorMsg] =""'Не задано: " & fld.Caption & "'"" ")
                End If

                sb.AppendLine("	 [(ngModel)]=""current%obj%." & fld.Name & """")
                sb.AppendLine("                    > ")
                sb.AppendLine(" </amexio-number-input>")

            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                sb.AppendLine("<amexio-dropdown ")
                sb.AppendLine("	 [fieldLabel]=""'" & fld.Caption & "'"" name =""" & fld.Name & """ ")
                sb.AppendLine("                    [placeholder]=""'" & fld.Caption & "'"" ")
                sb.AppendLine("	 [(ngModel)]=""current%obj%." & fld.Name & """")
                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("            [allowBlank]=""true"" ")
                Else
                    sb.AppendLine("            [allowBlank]=""false"" [errorMsg] =""'Не задано: " & fld.Caption & "'"" ")
                End If

                sb.AppendLine("	 [displayField]=""'name'""")
                sb.AppendLine("	 [valueField]=""'id'""")

                sb.AppendLine("	 [data]=""AppService.enum" & ft.Name & "Combo()""")
                sb.AppendLine("	 >")
                sb.AppendLine("</amexio-dropdown>")
            End If


            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                sb.AppendLine("	 <amexio-dropdown ")
                sb.AppendLine("	 [placeholder] = ""'" & fld.Caption & "'""")
                sb.AppendLine("	 name =""" & fld.Name & """")
                sb.AppendLine("	 [fieldLabel]= ""'" & fld.Caption & "'""")
                sb.AppendLine("	 [allowBlank]=""false""	")
                sb.AppendLine("	 ")
                sb.AppendLine("	 [displayField]=""'name'""")
                sb.AppendLine("	 [valueField]=""'id'""")
                refP = fld.RefToPart
                sb.AppendLine("	 [data]=""AppService.Combo" & refP.Name & """")
                sb.AppendLine("	 ")
                sb.AppendLine("	 [(ngModel)]=""current%obj%." & fld.Name & """")
                sb.AppendLine("	 >")
                sb.AppendLine("  </amexio-dropdown>")

            End If
            sb.AppendLine("     </td></tr>")
        Next
        sb.AppendLine("     </tbody></table>")


        sb.AppendLine("	</amexio-pane-body> ")
        sb.AppendLine("	<amexio-pane-action> ")
        sb.AppendLine("		<button type=""button"" class=""btn btn-outline"" (click) = ""opened = false"">Отмена</button> ")
        sb.AppendLine("		<button type=""submit"" class=""btn btn-primary"" (click)=""save(current%obj%, true)"" >Сохранить</button> ")
        sb.AppendLine("	</amexio-pane-action> ")
        sb.AppendLine("</amexio-card-pane> ")
        sb.AppendLine("   ")
        sb.AppendLine("<!-- list Of row pane --> ")
        sb.AppendLine("<amexio-card-pane [showCard]=""!opened"" [enableHeader] =""true"" [enableFooter] =""false"" > ")
        sb.AppendLine("    <amexio-pane-header> ")
        sb.AppendLine("	<div class=""row""> ")
        sb.AppendLine("		<div class=""col-3""> ")

        If Not isRoot Then
            sb.AppendLine("		<amexio-btn [disabled]=""AppService.Last%parent%." & DeCap(ParentPart.Name) & "Id==null"" [label]=""'Создать'"" [type]=""'primary'"" [tooltipMessage]=""'Создать новую запись'"" [icon]=""'fa fa-plus'"" (onClick)=""onNew()""></amexio-btn>")
        Else
            sb.AppendLine("		<amexio-btn [label]=""'Создать'"" [type]=""'primary'"" [tooltipMessage]=""'Создать новую запись'"" [icon]=""'fa fa-plus'"" (onClick)=""onNew()""></amexio-btn>")
        End If

        'sb.AppendLine("		<amexio-btn [label]=""'Создать'"" [type]=""'primary'"" [tooltipMessage]=""'Создать новую запись'"" [icon]=""'fa fa-plus'"" (onClick)=""onNew()""></amexio-btn>")


        sb.AppendLine("		</div><div class=""col-3""> ")
        sb.AppendLine("		<amexio-btn [disabled]=""current%obj%." & DeCap(P.Name) & "Id==null"" [label]=""'Изменить'"" (onClick)=""onEdit(current%obj%)"" [type]=""'primary'"" [tooltipMessage]=""'Изменить запись'"" [icon]=""'fa fa-id-card'""></amexio-btn>")
        sb.AppendLine("		</div><div class=""col-3""> ")
        sb.AppendLine("     <amexio-btn [disabled]=""current%obj%." & DeCap(P.Name) & "Id==null"" [label]=""'Удалить'"" (onClick)=""onDelete(current%obj%)"" [type]=""'primary'"" [tooltipMessage]=""'Удалить запись'"" [icon]=""'fa fa-trash'""></amexio-btn>")
        sb.AppendLine("		</div>")
        sb.AppendLine("		<div class=""col-3""> ")
        sb.AppendLine("     <amexio-btn  [label]=""'Обновить'"" (onClick)=""refresh%obj%()"" [type]=""'primary'"" [tooltipMessage]=""'Обновить данные'"" [icon]=""'fa fa-refresh'""></amexio-btn>")
        sb.AppendLine("		</div>")
        sb.AppendLine("	</div> ")
        sb.AppendLine("	</amexio-pane-header> ")
        sb.AppendLine("	<amexio-pane-body> ")
        sb.AppendLine("		<amexio-data-table ")
        sb.AppendLine("		  [title]=""'%objname%'"" ")
        sb.AppendLine("		  [pageSize] = ""10"" ")
        sb.AppendLine("		  [filtering]=""true"" ")
        sb.AppendLine("		  [checkboxSelect]=""false"" ")
        sb.AppendLine("		  [dataTableBindData]=""%obj%Array"" ")
        sb.AppendLine("		  (selectedRowData)=""onSelect($event)"" ")
        sb.AppendLine("		  (rowSelect)=""onSelect($event)""> ")


        isFirst = True

        P.FIELD.Sort = "sequence"
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                'If Not isFirst Then
                '    sb.Append(",")
                'End If
                isFirst = False
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        sb.AppendLine("		  <amexio-data-table-column [dataIndex]=""'" & fld.Name & "_name'"" [dataType]=""'string'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""></amexio-data-table-column> ")
                    ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        sb.AppendLine("		  <amexio-data-table-column [dataIndex]=""'" & fld.Name & "_name'"" [dataType]=""'string'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""></amexio-data-table-column> ")
                    Else

                        If ft.Name.ToLower = "memo" Or ft.Name.ToLower = "string" Then
                            sb.AppendLine("		  <amexio-data-table-column [dataIndex]=""'" & fld.Name & "'"" [dataType]=""'string'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""> ")
                            sb.AppendLine(" 		  <ng-template #amexioBodyTmpl let-column let-row=""row"">")
                            sb.AppendLine("             {{  ((row." & fld.Name & ") ? ((row." & fld.Name & ".length>100) ? row." & fld.Name & ".substr(0,100)+'...' : row." & fld.Name & " ) : '-') }} ")
                            sb.AppendLine("           </ng-template>")
                            sb.AppendLine("		  </amexio-data-table-column> ")
                        Else

                            sb.AppendLine("		  <amexio-data-table-column [dataIndex]=""'" & fld.Name & "'"" [dataType]=""'string'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""></amexio-data-table-column> ")
                        End If


                    End If
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    sb.AppendLine("		  <amexio-data-table-column [dataIndex]=""'" & fld.Name & "'"" [dataType]=""'number'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""></amexio-data-table-column> ")
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    sb.AppendLine("		  <amexio-data-table-column [dataIndex]=""'" & fld.Name & "'"" [dataType]=""'string'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""></amexio-data-table-column> ")
                End If
            End If
        Next


        sb.AppendLine("		</amexio-data-table> ")
        sb.AppendLine("	</amexio-pane-body> ")
        sb.AppendLine("</amexio-card-pane> ")
        sb.AppendLine(" ")
        sb.AppendLine("<!-- confirm delete  dialog -->  ")
        sb.AppendLine("<amexio-window-pane  [(showWindow)]=""confirmOpened"" [title]=""'Удалить строку: %objname%'"" [closable]=""true"" [size]=""2"">  ")
        sb.AppendLine("     ")
        sb.AppendLine("    <amexio-pane-body> ")


        isFirst = True
        Dim rowStr As String = ""
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If fld.IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                    If Not isFirst Then
                        rowStr = rowStr & " +'; '+  "
                    End If
                    isFirst = False

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        rowStr = rowStr & "current%obj%." & fld.Name & "_name"
                    Else
                        rowStr = rowStr & "current%obj%." & fld.Name
                    End If


                End If
            End If

        Next

        sb.AppendLine("            Удалить запись: {{" & rowStr & "}}?  ")

        sb.AppendLine("	</amexio-pane-body> ")
        sb.AppendLine("	<amexio-pane-action> ")
        sb.AppendLine("		 <button type=""button"" class=""btn btn-outline"" (click)=""confirmOpened = false"">Отмена</button> ")
        sb.AppendLine("      <button type=""submit"" class=""btn btn-danger"" (click)=""onConfirmDeletion()"">Удалить</button> ")
        sb.AppendLine("	</amexio-pane-action> ")
        sb.AppendLine("</amexio-window-pane> ")
        sb.AppendLine(" ")





        ss = sb.ToString()
        ss = ss.Replace("%obj%", P.Name)
        ss = ss.Replace("%parent%", ParentPart.Name)
        ss = ss.Replace("%objname%", ot.the_Comment & "::" & P.Caption)
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name)

        Tool_WriteFile(ss, textBoxOutPutFolder.Text & "\ts\" + P.Name + "\", P.Name + ".component.html", False)

#End Region




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