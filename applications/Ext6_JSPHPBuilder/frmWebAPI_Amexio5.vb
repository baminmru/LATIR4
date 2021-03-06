﻿Imports System.IO
Imports System.Text

Public Class frmWebAPI_Amexio5
    Private Sub frmA4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkUseDecap.Checked = UseDeCap
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
        txtNS.Text = GetSetting("L2BUILDER", "EXT2NET_" & Manager.Site, "DEFNS", "myApp")
        txtContext.Text = GetSetting("L2BUILDER", "EXT2NET_" & Manager.Site, "DEFCONTEXT", "myContext")
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
                        sw.AppendLine(",")
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
            sw.Append(PartMake_CS_Models(ot.PART))
            sw.Append(vbCrLf & "}")
            Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\models\", ot.Name + ".cs", False)

            Application.DoEvents()
        Next



        ''''''''''' Make type controllers for CS project

        For i = 0 To chkObjType.CheckedItems.Count - 1

            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)
            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            PartMake_CS_Controllers(ot.PART)
            Application.DoEvents()
        Next

        ''''''''''' Make DbSets
        sw = New StringBuilder
        For i = 0 To chkObjType.CheckedItems.Count - 1
            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)
            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            ot.PART.Sort = "sequence"
            sw.Append(PartMake_DbSet(ot.PART))
            Application.DoEvents()
        Next
        Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\Controllers\", "DbSet.Inc", False)


        sw = New StringBuilder
        For i = 0 To chkObjType.CheckedItems.Count - 1
            Application.DoEvents()
            ti = chkObjType.CheckedItems(i)
            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            ot.PART.Sort = "sequence"
            sw.Append(PartMake_FK(ot.PART))
            Application.DoEvents()
        Next
        Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\sql\", "fk.sql", False)

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
                        sw.AppendLine(",")
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

        sw.AppendLine("export class enumInfo{ ")
        sw.AppendLine("	id:number; ")
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
                sw.AppendLine("	enum" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & ":Array<enumInfo> =[")

                For eidx = 1 To ft.ENUMITEM.Count
                    sw.Append(vbCrLf & vbTab)
                    If (eidx > 1) Then
                        sw.Append(",")
                    End If
                    ei = ft.ENUMITEM.Item(eidx)
                    sw.Append(" {id:" & ei.NameValue & ",name:'" & ei.Name & "'}")
                Next
                sw.AppendLine("	];")
            End If
            Application.DoEvents()
        Next

        sw.AppendLine(" ")




        ' end class
        sw.AppendLine("}")

        Tool_WriteFile(sw.ToString(), textBoxOutPutFolder.Text & "\ts\", "app.service.ts", False)

        If optMS.Checked Then
            Dim targetID As System.Guid
            targetID = New System.Guid("{0C652C58-A952-4E8F-8CB0-D266431CD24B}")
            Dim generator As New MSSQLGenerator
            ' generator.Setup()
            generator.ClearSelectedParts()

            For i = 0 To chkObjType.CheckedItems.Count - 1
                ti = chkObjType.CheckedItems(i)
                ot = model.OBJECTTYPE.Item(ti.ID.ToString())
                SelectAllParts(generator, ot.PART)

                Application.DoEvents()
            Next


            Dim response As LATIRGenerator.Response
            response = New LATIRGenerator.Response()
            Dim fname As String
            generator.Run(CType(model, Object), CType(response, Object), targetID.ToString)
            fname = textBoxOutPutFolder.Text & "\db\db.xml"
            Tool_WriteFile("<>", textBoxOutPutFolder.Text & "\db\", "db.xml", False)
            response.Save(fname)
            ReplaceInFile(fname, "&#xD;&#xA;", vbCrLf)
        Else
            Dim targetID As System.Guid
            targetID = New System.Guid("{9D7DD39D-7A43-4EC3-AA10-1FBCED75F3CB}")
            Dim generator As New PGSQLGenerator
            ' generator.Setup()
            generator.ClearSelectedParts()

            For i = 0 To chkObjType.CheckedItems.Count - 1
                ti = chkObjType.CheckedItems(i)
                ot = model.OBJECTTYPE.Item(ti.ID.ToString())
                SelectAllParts(generator, ot.PART)

                Application.DoEvents()
            Next


            Dim response As LATIRGenerator.Response
            response = New LATIRGenerator.Response()
            Dim fname As String
            generator.Run(CType(model, Object), CType(response, Object), targetID.ToString)
            fname = textBoxOutPutFolder.Text & "\db\dbPG.xml"
            Tool_WriteFile("<>", textBoxOutPutFolder.Text & "\db\", "dbPG.xml", False)
            response.Save(fname)
            ReplaceInFile(fname, "&#xD;&#xA;", vbCrLf)

        End If

        MsgBox("OK")
    End Sub

    Private Sub SelectAllParts(generator As MSSQLGenerator, Parts As MTZMetaModel.MTZMetaModel.PART_col)
        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        For i = 1 To Parts.Count
            p = Parts.Item(i)
            generator.SelectedParts.Add(p.Name)
            SelectAllParts(generator, p.PART)
        Next
    End Sub

    Private Sub SelectAllParts(generator As PGSQLGenerator, Parts As MTZMetaModel.MTZMetaModel.PART_col)
        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        For i = 1 To Parts.Count
            p = Parts.Item(i)
            generator.SelectedParts.Add(p.Name)
            SelectAllParts(generator, p.PART)
        Next
    End Sub

    Private Function FindRootPart(ByVal s As MTZMetaModel.MTZMetaModel.PART) As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim obj As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        If TypeName(s.Parent.Parent) <> "OBJECTTYPE" Then
            Return Nothing
        End If

        obj = s.Parent.Parent

        For i = 1 To obj.PART.Count
            p = obj.PART.Item(i)
            If p.Sequence = 0 Then
                If Not p.ID.Equals(s.ID) Then
                    Return p
                Else
                    Return Nothing
                End If
            End If

        Next

        Return Nothing


    End Function

    Private Sub PartMake_CS_Controllers(Parts As MTZMetaModel.MTZMetaModel.PART_col)
        Dim i As Integer
        Dim P As MTZMetaModel.MTZMetaModel.PART
        For i = 1 To Parts.Count
            P = Parts.Item(i)

            Dim sw As StringBuilder
            sw = New StringBuilder
            sw.AppendLine("using System;")
            sw.AppendLine("using System.Collections.Generic;")
            sw.AppendLine("using System.Linq;")
            sw.AppendLine("using System.Threading.Tasks;")
            sw.AppendLine("using Microsoft.AspNetCore.Http;")
            sw.AppendLine("using Microsoft.AspNetCore.Mvc;")
            sw.AppendLine("using Microsoft.EntityFrameworkCore;")
            sw.AppendLine("using Microsoft.AspNetCore.Hosting;")
            sw.AppendLine("using Microsoft.AspNetCore.Authorization;")
            sw.AppendLine("using %NAMESPACE%.models;")
            sw.AppendLine("")
            sw.AppendLine("namespace %NAMESPACE%.Controllers")
            sw.AppendLine("{")
            sw.AppendLine("    [Authorize]")
            sw.AppendLine("    [Produces(""application/json"")]")
            sw.AppendLine("    [Route(""api/%TABLE%"")]")
            sw.AppendLine("    public class %TABLE%Controller : Controller")
            sw.AppendLine("    {")
            sw.AppendLine("        private readonly %MyContext% _context;")
            sw.AppendLine("        IWebHostEnvironment _appEnvironment;")
            sw.AppendLine("")
            sw.AppendLine("        public %TABLE%Controller(%MyContext% context, IWebHostEnvironment appEnvironment)")
            sw.AppendLine("        {")
            sw.AppendLine("            _context = context;")
            sw.AppendLine("            _appEnvironment = appEnvironment;")
            sw.AppendLine("        }")
            sw.AppendLine("")
            sw.AppendLine("        // GET: api/%TABLE%")
            sw.AppendLine("        [HttpGet]")
            If chkAutorize.Checked Then
                sw.AppendLine("       //[AllowAnonymous]")
            Else
                sw.AppendLine("       [AllowAnonymous]")
            End If
            sw.AppendLine("        public IActionResult Get%TABLE%()")
            sw.AppendLine("        {")
            sw.AppendLine("            return Json (_context.%TABLE%, _context.serializerSettings());")
            sw.AppendLine("        }")
            sw.AppendLine("")
            sw.AppendLine("        [HttpGet(""combo"")]")
            If chkAutorize.Checked Then
                sw.AppendLine("       //[AllowAnonymous]")
            Else
                sw.AppendLine("       [AllowAnonymous]")
            End If
            If optMS.Checked Then




                sw.AppendLine("        public List<Dictionary<string, object>> GetCombo()")
                sw.AppendLine("        {")
                sw.AppendLine("            //var uid = User.GetUserId();")
                sw.AppendLine("")
                sw.AppendLine("            string sql = @""SELECT %TABLE%id id, ( [dbo].[%TABLE%_brief_f](%TABLE%id,null)  ) name")
                sw.AppendLine("                         FROM            ")
                sw.AppendLine("                          %TABLE% ")
                sw.AppendLine("                            order by name "";")
                sw.AppendLine("            return _context.GetRaw(sql);")
                sw.AppendLine("        }")
                sw.AppendLine("        ")
            Else
                sw.AppendLine("        public List<Dictionary<string, object>> GetCombo()")
                sw.AppendLine("        {")
                sw.AppendLine("")
                sw.AppendLine("            string sql = @""SELECT %TABLE%id id, ( [%TABLE%_brief_f](%TABLE%id)  ) name")
                sw.AppendLine("                         FROM            ")
                sw.AppendLine("                          %TABLE% ")
                sw.AppendLine("                            order by name "";")
                sw.AppendLine("            return _context.GetRaw(sql);")
                sw.AppendLine("        }")
                sw.AppendLine("        ")

            End If





            Dim pos As MTZMetaModel.MTZMetaModel.PART = Nothing
            If TypeName(P.Parent.Parent) <> "OBJECTTYPE" Then
                pos = P.Parent.Parent
            Else
                pos = FindRootPart(P)
            End If

            If pos IsNot Nothing Then
                sw.AppendLine("        [HttpGet(""byparent/{id}"")]")
                If chkAutorize.Checked Then
                    sw.AppendLine("       //[AllowAnonymous]")
                Else
                    sw.AppendLine("       [AllowAnonymous]")
                End If
                sw.AppendLine("        public List<Dictionary<string, object>> GetByBarent([FromRoute] Guid id)")
                sw.AppendLine("        {")
                sw.AppendLine("            //var uid = User.GetUserId();")
                sw.AppendLine("")
                sw.AppendLine("            string sql = @""SELECT * FROM v_%TABLE% where " & pos.Name & "id='"" + id.ToString() + ""'"";")
                sw.AppendLine("            return _context.GetRaw(sql);")
                sw.AppendLine("        }")
                sw.AppendLine("        ")
            Else
                sw.AppendLine("        [HttpGet(""view"")]")
                If chkAutorize.Checked Then
                    sw.AppendLine("       //[AllowAnonymous]")
                Else
                    sw.AppendLine("       [AllowAnonymous]")
                End If
                sw.AppendLine("        public List<Dictionary<string, object>> GetView()")
                sw.AppendLine("        {")
                sw.AppendLine("            //var uid = User.GetUserId();")
                sw.AppendLine("")
                sw.AppendLine("            string sql = @""SELECT * FROM v_%TABLE% "";")
                sw.AppendLine("            return _context.GetRaw(sql);")
                sw.AppendLine("        }")
                sw.AppendLine("        ")
            End If


            sw.AppendLine("        // GET: api/%TABLE%/5")
            sw.AppendLine("        [HttpGet(""{id}"")]")
            If chkAutorize.Checked Then
                sw.AppendLine("       //[AllowAnonymous]")
            Else
                sw.AppendLine("       [AllowAnonymous]")
            End If
            sw.AppendLine("        public async Task<IActionResult> Get%TABLE%([FromRoute] Guid id)")
            sw.AppendLine("        {")
            sw.AppendLine("            if (!ModelState.IsValid)")
            sw.AppendLine("            {")
            sw.AppendLine("                return BadRequest(ModelState);")
            sw.AppendLine("            }")
            sw.AppendLine("")
            sw.AppendLine("            var var%TABLE% = await _context.%TABLE%.SingleOrDefaultAsync(m => m.%TABLE%id == id);")
            sw.AppendLine("")
            sw.AppendLine("            if (var%TABLE% == null)")
            sw.AppendLine("            {")
            sw.AppendLine("                return NotFound();")
            sw.AppendLine("            }")
            sw.AppendLine("")
            sw.AppendLine("            return Ok(var%TABLE%);")
            sw.AppendLine("        }")
            sw.AppendLine("")
            sw.AppendLine("        // PUT: api/%TABLE%/5")
            sw.AppendLine("        [HttpPut(""{id}"")]")
            If chkAutorize.Checked Then
                sw.AppendLine("       //[AllowAnonymous]")
            Else
                sw.AppendLine("       [AllowAnonymous]")
            End If
            sw.AppendLine("        public async Task<IActionResult> Put%TABLE%([FromRoute] Guid id, [FromBody] %TABLE% var%TABLE%)")
            sw.AppendLine("        {")
            sw.AppendLine("            if (!ModelState.IsValid)")
            sw.AppendLine("            {")
            sw.AppendLine("                return BadRequest(ModelState);")
            sw.AppendLine("            }")
            sw.AppendLine("")
            sw.AppendLine("            if (id != var%TABLE%.%TABLE%id)")
            sw.AppendLine("            {")
            sw.AppendLine("                return BadRequest();")
            sw.AppendLine("            }")
            sw.AppendLine("")
            sw.AppendLine("            _context.Entry(var%TABLE%).State = EntityState.Modified;")
            sw.AppendLine("")
            sw.AppendLine("            try")
            sw.AppendLine("            {")
            sw.AppendLine("                await _context.SaveChangesAsync();")
            sw.AppendLine("            }")
            sw.AppendLine("            catch (DbUpdateConcurrencyException)")
            sw.AppendLine("            {")
            sw.AppendLine("                if (!%TABLE%Exists(id))")
            sw.AppendLine("                {")
            sw.AppendLine("                    return NotFound();")
            sw.AppendLine("                }")
            sw.AppendLine("                else")
            sw.AppendLine("                {")
            sw.AppendLine("                    throw;")
            sw.AppendLine("                }")
            sw.AppendLine("            }")
            sw.AppendLine("")
            sw.AppendLine("            return NoContent();")
            sw.AppendLine("        }")
            sw.AppendLine("")
            sw.AppendLine("        // POST: api/%TABLE%")
            sw.AppendLine("        [HttpPost]")
            If chkAutorize.Checked Then
                sw.AppendLine("       //[AllowAnonymous]")
            Else
                sw.AppendLine("       [AllowAnonymous]")
            End If
            sw.AppendLine("        public async Task<IActionResult> Post%TABLE%([FromBody] %TABLE% var%TABLE%)")
            sw.AppendLine("        {")
            sw.AppendLine("            if (!ModelState.IsValid)")
            sw.AppendLine("            {")
            sw.AppendLine("                return BadRequest(ModelState);")
            sw.AppendLine("            }")
            sw.AppendLine("")
            sw.AppendLine("            _context.%TABLE%.Add(var%TABLE%);")
            sw.AppendLine("            await _context.SaveChangesAsync();")
            sw.AppendLine("")
            sw.AppendLine("            return CreatedAtAction(""Get%TABLE%"", new { id = var%TABLE%.%TABLE%id }, var%TABLE%);")
            sw.AppendLine("        }")
            sw.AppendLine("")
            sw.AppendLine("        // DELETE: api/%TABLE%/5")
            sw.AppendLine("        [HttpDelete(""{id}"")]")
            If chkAutorize.Checked Then
                sw.AppendLine("       //[AllowAnonymous]")
            Else
                sw.AppendLine("       [AllowAnonymous]")
            End If
            sw.AppendLine("        public async Task<IActionResult> Delete%TABLE%([FromRoute] Guid id)")
            sw.AppendLine("        {")
            sw.AppendLine("            if (!ModelState.IsValid)")
            sw.AppendLine("            {")
            sw.AppendLine("                return BadRequest(ModelState);")
            sw.AppendLine("            }")
            sw.AppendLine("")
            sw.AppendLine("            var var%TABLE% = await _context.%TABLE%.SingleOrDefaultAsync(m => m.%TABLE%id == id);")
            sw.AppendLine("            if (var%TABLE% == null)")
            sw.AppendLine("            {")
            sw.AppendLine("                return NotFound();")
            sw.AppendLine("            }")
            sw.AppendLine("")
            sw.AppendLine("            _context.%TABLE%.Remove(var%TABLE%);")
            sw.AppendLine("            await _context.SaveChangesAsync();")
            sw.AppendLine("")
            sw.AppendLine("            return Ok(var%TABLE%);")
            sw.AppendLine("        }")
            sw.AppendLine("")
            sw.AppendLine("        private bool %TABLE%Exists(Guid id)")
            sw.AppendLine("        {")
            sw.AppendLine("            return _context.%TABLE%.Any(e => e.%TABLE%id == id);")
            sw.AppendLine("        }")
            sw.AppendLine("    }")
            sw.AppendLine("}")

            Dim s As String

            s = sw.ToString()
            s = s.Replace("%TABLE%", (P.Name))
            s = s.Replace("%NAMESPACE%", txtNS.Text)
            s = s.Replace("%MyContext%", txtContext.Text)




            Tool_WriteFile(s, textBoxOutPutFolder.Text & "\controllers\", P.Name + "Controller.cs", False)
            PartMake_CS_Controllers(P.PART)

        Next

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
        sb.AppendLine("import { AmexioWidgetModule } from 'amexio-ng-extensions'; ")
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
            Make_AddPartCompServiceToAPP(sb, ot.PART)
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
        sb.AppendLine("    providers: [HttpClient ")

        For i = 0 To chkObjType.CheckedItems.Count - 1
            ti = chkObjType.CheckedItems(i)
            ot = model.OBJECTTYPE.Item(ti.ID.ToString())
            Make_AddServiceToImportAPP(sb, ot.PART)
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
            sb.AppendLine("  " & DeCap(P.Name) & "Component, // " + P.Caption)
            Make_AddCompToAPP(sb, P.PART)
        Next
    End Sub

    Sub Make_AddServiceToImportAPP(sb As StringBuilder, PCOL As MTZMetaModel.MTZMetaModel.PART_col)
        Dim i As Integer
        Dim P As MTZMetaModel.MTZMetaModel.PART
        For i = 1 To PCOL.Count
            P = PCOL.Item(i)
            sb.AppendLine("  ," & DeCap(P.Name) & "_Service")
            Make_AddServiceToImportAPP(sb, P.PART)
        Next

    End Sub


    Sub Make_AddPartCompServiceToAPP(sb As StringBuilder, PCOL As MTZMetaModel.MTZMetaModel.PART_col)
        Dim i As Integer
        Dim P As MTZMetaModel.MTZMetaModel.PART
        For i = 1 To PCOL.Count
            P = PCOL.Item(i)
            sb.AppendLine("import { " & DeCap(P.Name) & "Component } from './" & P.Name & "/" & P.Name & ".component'; // " + P.Caption)
            sb.AppendLine("import { " & DeCap(P.Name) & "_Service } from 'app/" & P.Name & ".service'; ")
            Make_AddPartCompServiceToAPP(sb, P.PART)
        Next

    End Sub


    Sub TypeMake_Component(ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Dim sb As StringBuilder
        sb = New StringBuilder


        sb.AppendLine("<amexio-card  amexioColorPalette [color-palette]=""'classic'"" [gradient]=""true"" [header] =""true"" [footer] =""false"">")
        sb.AppendLine("  <amexio-header>")
        sb.AppendLine(" <i class=""fa " & ot.objIconCls & """ aria-hidden=""True""></i> %typename% ")
        sb.AppendLine("  </amexio-header>")
        sb.AppendLine("  <amexio-body>")
        sb.AppendLine("	<amexio-tab-view  [closable]=""false"">")

        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim isFirst As Boolean
        Dim i As Integer
        Dim j As Integer

        isFirst = True
        For i = 1 To ot.PART.Count
            P = ot.PART.Item(i)
            If isFirst Then
                isFirst = False
                sb.AppendLine("		<amexio-tab  title=""" & P.Caption & """  [active]=""true"" >")
            Else
                sb.AppendLine("		<amexio-tab  title=""" & P.Caption & """  >")
            End If

            sb.AppendLine("			<app-" & DeCap(P.Name) & "></app-" & DeCap(P.Name) & ">")
            sb.AppendLine("		</amexio-tab>")
            sb.AppendLine("		")
        Next

        sb.AppendLine("	</amexio-tab-view>")
        sb.AppendLine("  </amexio-body>")
        sb.AppendLine("</amexio-card>")


        Dim ss As String
        ss = sb.ToString()
        ss = ss.Replace("%typename%", ot.the_Comment)
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name)

        Tool_WriteFile(ss, textBoxOutPutFolder.Text & "\ts\" + ot.Name + "\", ot.Name + ".component.html", False)



        sb = New StringBuilder
        sb.AppendLine("import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core'; ")
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


    Private Function PartMake_FK(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim P1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer


        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & PartMake_OneFK(P))
            P.PART.Sort = "sequence"
            sw.Append(PartMake_FK(P.PART))

        Next
        Return sw.ToString()

    End Function


    Private Function PartMake_DbSet(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim P1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer


        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & "public DbSet<" & txtNS.Text & ".models." & P.Name & "> " & P.Name & " { get; set; }")
            P.PART.Sort = "sequence"
            sw.Append(PartMake_DbSet(P.PART))

        Next
        Return sw.ToString()

    End Function




    Private Function PartMake_OneFK(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
        If P.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then Return ""
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Try



            Dim i As Integer


            Dim isroot As Boolean = False
            Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
            ot = Nothing
            If TypeName(P.Parent.Parent) = "OBJECTTYPE" Then
                ot = P.Parent.Parent
                isroot = True
            End If


            If Not isroot Then
                Dim ParentPart As MTZMetaModel.MTZMetaModel.PART
                ParentPart = P.Parent.Parent

                'sw.Append(vbCrLf & vbTab & "[Required]") ' [ForeignKey(""FK_" & P.Name  & "_Parent"")]")


                sw.Append(vbCrLf & vbTab & " delete from " & P.Name & " where " & ParentPart.Name & "id not in ( select " & ParentPart.Name & "id from " & ParentPart.Name & ") ")
                sw.Append(vbCrLf & vbTab & " go ")
                sw.Append(vbCrLf & vbTab & " ALTER TABLE " & P.Name & " 
                ADD CONSTRAINT FK_" & P.Name & "_Parent
                FOREIGN KEY (" & ParentPart.Name & "id)
                REFERENCES " & ParentPart.Name & " (" & ParentPart.Name & "id)
                ON DELETE CASCADE ")
                sw.Append(vbCrLf & vbTab & " go ")

                'sw.Append(vbCrLf & vbTab & " public System.Guid  " & ParentPart.Name & "id { get; set; } // Parent part id -> " & ParentPart.Caption)
            Else
                If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then

                    '  все  разделы верхнего уровня  впихиваем в  0 -раздел
                    If P.Sequence = 0 Then



                    Else
                        For i = 1 To ot.PART.Count
                            Dim SiblingPart As MTZMetaModel.MTZMetaModel.PART
                            SiblingPart = ot.PART.Item(i)
                            If SiblingPart.Sequence = 0 Then

                                sw.Append(vbCrLf & vbTab & " delete from " & P.Name & " where " & SiblingPart.Name & "id not in ( select " & SiblingPart.Name & "id from " & SiblingPart.Name & ") ")
                                sw.Append(vbCrLf & vbTab & " go ")
                                sw.Append(vbCrLf & vbTab & " ALTER TABLE " & P.Name & " 
                                ADD CONSTRAINT FK_" & P.Name & "_Parent
                                FOREIGN KEY (" & SiblingPart.Name & "id)
                                REFERENCES " & SiblingPart.Name & " (" & SiblingPart.Name & "id)
                                ON DELETE CASCADE ")
                                sw.Append(vbCrLf & vbTab & " go ")
                                Exit For
                            End If
                        Next

                    End If






                End If

            End If




        Catch ex As Exception
            Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
            ' Stop
        End Try

        Return sw.ToString()

    End Function


    Private Function PartMake_CS_Models(ByVal pcol As MTZMetaModel.MTZMetaModel.PART_col) As String
        Dim sw As StringBuilder
        sw = New StringBuilder()
        Dim P As MTZMetaModel.MTZMetaModel.PART
        Dim P1 As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer


        For i = 1 To pcol.Count
            P = pcol.Item(i)
            sw.Append(vbCrLf & PartMake_CS_Model(P))
            P.PART.Sort = "sequence"
            sw.Append(PartMake_CS_Models(P.PART))

        Next
        Return sw.ToString()

    End Function

    Private Function PartMake_CS_Model(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
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

            sw.Append(vbCrLf & vbTab & " public System.Guid  " & P.Name & "id{ get; set; } // Идентификатор (первичный ключ)")

            If Not isroot Then
                Dim ParentPart As MTZMetaModel.MTZMetaModel.PART
                ParentPart = P.Parent.Parent

                'sw.Append(vbCrLf & vbTab & "[Required]") ' [ForeignKey(""FK_" & P.Name  & "_Parent"")]")
                sw.Append(vbCrLf & vbTab & " public System.Guid  " & ParentPart.Name & "id { get; set; } // обратная ссылка на родителя: " & ParentPart.Caption)
                'sw.Append(vbCrLf & vbTab & " public " & ParentPart.Name & "  " & ParentPart.Name & " { get; set; } // Parent part -> " & ParentPart.Caption)

                'For i = 1 To P.PART.Count
                '    Dim SiblingPart As MTZMetaModel.MTZMetaModel.PART
                '    SiblingPart = P.PART.Item(i)
                '    sw.Append(vbCrLf & vbTab & " public List<" & SiblingPart.Name & ">  " & SiblingPart.Name & " { get; set; } // " & SiblingPart.Caption)
                'Next
            Else
                If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then

                    '  все  разделы верхнего уровня  впихиваем в  0 -раздел
                    If P.Sequence = 0 Then

                        For i = 1 To ot.PART.Count
                            Dim SiblingPart As MTZMetaModel.MTZMetaModel.PART
                            SiblingPart = ot.PART.Item(i)
                            If SiblingPart.Sequence <> 0 Then
                                sw.Append(vbCrLf & vbTab & " public List<" & SiblingPart.Name & ">  " & SiblingPart.Name & " { get; set; } // дочерний раздел: " & SiblingPart.Caption)
                            End If
                        Next

                    Else
                        For i = 1 To ot.PART.Count
                            Dim SiblingPart As MTZMetaModel.MTZMetaModel.PART
                            SiblingPart = ot.PART.Item(i)
                            If SiblingPart.Sequence = 0 Then

                                'sw.Append(vbCrLf & vbTab & "[Required]") ' [ForeignKey(""FK_" & P.Name  & "_Document"")]")
                                'sw.Append(vbCrLf & vbTab & " public " & SiblingPart.Name & "  " & SiblingPart.Name & " { get; set; } // " & SiblingPart.Caption)
                                sw.Append(vbCrLf & vbTab & " public System.Guid  " & SiblingPart.Name & "id { get; set; } // обратная ссылка на: " & SiblingPart.Caption)
                            End If
                        Next

                    End If






                End If
            End If

            For i = 1 To P.PART.Count
                Dim ChildPart As MTZMetaModel.MTZMetaModel.PART
                ChildPart = P.PART.Item(i)
                sw.Append(vbCrLf & vbTab & " public List<" & ChildPart.Name & ">  " & ChildPart.Name & " { get; set; } // дочерний раздел: " & ChildPart.Caption)
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

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    'sw.Append(vbCrLf & vbTab & "[Required]")
                    NullMark = ""
                Else
                    NullMark = "?"
                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then



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
                        If ft.Name.ToLower().StartsWith("int") Then
                            sw.Append(vbCrLf & vbTab & "public int" & NullMark & "  " & fld.Name & "{ get; set; } // " & fld.Caption)
                        Else
                            sw.Append(vbCrLf & vbTab & "public double" & NullMark & "  " & fld.Name & "{ get; set; } // " & fld.Caption)
                        End If


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

                    sw.Append(vbCrLf & vbTab & "public System.Guid" & NullMark & "  " & fld.Name & " { get; set; } //" & fld.Caption)

                    sw.Append(vbCrLf & vbTab & "[ForeignKey(""" & fld.Name & """)]")
                    ' sw.Append(vbCrLf & vbTab & "public " & refp.Name & " " & fld.Name & "_as_" & refp.Name & " { get; set; } // Объект - " & fld.Caption)
                    sw.Append(vbCrLf & vbTab & "public " & refp.Name & " " & fld.Name & "_as_" & refp.Name & " { get; set; } // Объект - " & fld.Caption)





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



            sw.Append(vbCrLf & " export interface   " & DeCap(P.Name) & " { // " & P.Caption)

            sw.Append(vbCrLf & vbTab & DeCap(P.Name) & "id:string; // Primary key field")

            If Not isroot Then
                Dim ParentPart As MTZMetaModel.MTZMetaModel.PART
                ParentPart = P.Parent.Parent
                'sw.Append(vbCrLf & vbTab & " parentStructRowId :string; // Parent part -> " & ParentPart.Name)
                sw.Append(vbCrLf & vbTab & " " & DeCap(ParentPart.Name) & "id :string // Parent part id -> " & ParentPart.Caption)


                'For i = 1 To ot.PART.Count
                '    Dim ChildPart As MTZMetaModel.MTZMetaModel.PART
                '    ChildPart = ot.PART.Item(i)

                '    sw.Append(vbCrLf & vbTab & " public List<" & ChildPart.Name & ">  " & ChildPart.Name.ToLower & " { get; set; } // " & ChildPart.Caption)

                'Next

            Else
                'If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                '    sw.Append(vbCrLf & vbTab & " instanceId:string // Document id ")
                'End If

                If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then

                    '  все  разделы верхнего уровня  впихиваем в  0 -раздел
                    If P.Sequence = 0 Then

                        'For i = 1 To ot.PART.Count
                        '    Dim SiblingPart As MTZMetaModel.MTZMetaModel.PART
                        '    SiblingPart = ot.PART.Item(i)
                        '    If SiblingPart.Sequence <> 0 Then
                        '        sw.Append(vbCrLf & vbTab & " public List<" & SiblingPart.Name & ">  " & SiblingPart.Name.ToLower & " { get; set; } // " & SiblingPart.Caption)
                        '    End If
                        'Next

                    Else
                        For i = 1 To ot.PART.Count
                            Dim SiblingPart As MTZMetaModel.MTZMetaModel.PART
                            SiblingPart = ot.PART.Item(i)
                            If SiblingPart.Sequence = 0 Then
                                'sw.Append(vbCrLf & vbTab & " public System.Guid  " & SiblingPart.Name  & "id { get; set; } // " & SiblingPart.Caption)
                                'sw.Append(vbCrLf & vbTab & "[Required] [ForeignKey(""FK_" & P.Name  & "_Document"")]")
                                sw.Append(vbCrLf & vbTab & "  " & DeCap(SiblingPart.Name) & "id:string; // " & SiblingPart.Caption)
                            End If
                        Next

                    End If

                    '        sw.Append(vbCrLf & vbTab & " public System.Guid  instanceId { get; set; } // Document id ")
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
                            sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & ":string; // " & fld.Caption)
                        Else
                            If fld.DataSize > 0 Then
                                sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & ":string; // " & fld.Caption)
                            Else
                                sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & ":string; // " & fld.Caption)
                            End If

                        End If

                    End If
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                        If ft.Name.ToLower = "date" Then
                            sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & ":string; // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "time" Then
                            sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & ":string;  // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "datetime" Then
                            sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & ":string;  // " & fld.Caption)
                        ElseIf ft.Name.ToLower = "birthday" Then
                            sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & ":string;  // " & fld.Caption)
                        End If
                    End If

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then

                        sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & ":Number; // " & fld.Caption)

                    End If
                End If


                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then

                    sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & ":Number;  // " & fld.Caption)


                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                    sw.Append(vbCrLf & vbTab & " " & DeCap(fld.Name) & ":enums.enum_" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & "; // " & fld.Caption)
                    sw.Append(vbCrLf & vbTab & " " & DeCap(fld.Name) & "_name :string; // enum to text for " & fld.Caption)

                End If

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                    Dim refp As MTZMetaModel.MTZMetaModel.PART
                    refp = fld.RefToPart
                    sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & ":string; //" & fld.Caption & " -> " & refp.Name)
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
                        sw.Append(vbCrLf & vbTab & DeCap(fld.Name) & "_name :string; //" & " dereference for " & refp.Name)
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
            sb.AppendLine("	public get" & P.Name & "(): Observable<ComboInfo[]> { ")
            sb.AppendLine("     let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json','Authorization': 'Bearer '+ sessionStorage.getItem('auth_token') });")
            sb.AppendLine("		return this.http.get<ComboInfo[]>(this.serviceURL + '/" & P.Name & "/Combo', { headers: cpHeaders }); ")
            sb.AppendLine(" }")
            sb.AppendLine("	public refreshCombo" & P.Name & "() { ")
            sb.AppendLine("	this.get" & P.Name & "().subscribe(Data => {this.Combo" & P.Name & "=Data;});")
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
        sb.AppendLine("		let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json','Authorization': 'Bearer '+ sessionStorage.getItem('auth_token') });")
        sb.AppendLine("		if(this.PageUrl!=''){")
        sb.AppendLine("			return this.http.get<%type%.%obj%[]>(this.PageUrl, { headers: cpHeaders })")
        sb.AppendLine("		}else{")
        sb.AppendLine("			if(qry !='')")
        sb.AppendLine("				qry='?' +qry;")
        sb.AppendLine("			return this.http.get<%type%.%obj%[]>(this.serviceURL + '/%obj%/view/'+qry, { headers: cpHeaders })")
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
        sb.AppendLine("    create_%obj%(%obj%: %type%.%obj%): Observable<%type%.%obj% > {")
        sb.AppendLine("       // %obj%.%obj%id = '';")
        sb.AppendLine("        let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json','Authorization': 'Bearer '+ sessionStorage.getItem('auth_token') });")
        sb.AppendLine("        return this.http.post<%type%.%obj% >(this.serviceURL + '/%obj%/', %obj%, { headers: cpHeaders })")
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
            sb.AppendLine("        let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json','Authorization': 'Bearer '+ sessionStorage.getItem('auth_token') });")
            sb.AppendLine("		   //console.log(this.serviceURL +'/%obj%/byparent/'+ parentId)")
            sb.AppendLine("        return this.http.get<%type%.%obj%[]>(this.serviceURL + '/%obj%/byparent/' + parentId, { headers: cpHeaders })//.catch(err => { console.log(err) return Observable.of(err) })")
            sb.AppendLine("    }	")
            sb.AppendLine("	")
        End If

        sb.AppendLine("	//Fetch %obj% by id")
        sb.AppendLine("    get_%obj%ById(%obj%id: string): Observable<%type%.%obj%> {")
        sb.AppendLine("        let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json','Authorization': 'Bearer '+ sessionStorage.getItem('auth_token') });")
        sb.AppendLine("		//console.log(this.serviceURL +'/%obj%/'+ %obj%id)")
        sb.AppendLine("        return this.http.get<%type%.%obj%>(this.serviceURL + '/%obj%/' + %obj%id, { headers: cpHeaders })//.catch(err => { console.log(err) return Observable.of(err) })")
        sb.AppendLine("    }	")
        sb.AppendLine("	")
        sb.AppendLine("	   //Update %obj%")
        sb.AppendLine("    update_%obj%(%obj%: %type%.%obj%):Observable<Object > {")
        sb.AppendLine("        let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json','Authorization': 'Bearer '+ sessionStorage.getItem('auth_token') });")
        sb.AppendLine("        return this.http.put(this.serviceURL + '/%obj%/' + %obj%." & DeCap(P.Name) & "id, %obj%, { headers: cpHeaders })")
        sb.AppendLine("    }")
        sb.AppendLine("	")
        sb.AppendLine("    //Delete %obj%	")
        sb.AppendLine("    delete_%obj%ById(%obj%id: string): Observable<Object> {")
        sb.AppendLine("        let cpHeaders = new HttpHeaders({ 'Content-Type': 'application/json','Authorization': 'Bearer '+ sessionStorage.getItem('auth_token') });")
        sb.AppendLine("        return this.http.delete(this.serviceURL + '/%obj%/' + %obj%id, { headers: cpHeaders })")
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
        ss = ss.Replace("%obj%", DeCap(P.Name))
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
            sw.Append(vbCrLf & PartMake_Component(P))

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
        sb.AppendLine("		//console.log(""change Selected %obj%""); ")
        sb.AppendLine("		this.Last%obj%=item; ")
        sb.AppendLine("		this.Selected%obj%.next(item); ")
        sb.AppendLine("		 ")
        sb.AppendLine("	} ")
        sb.AppendLine("	public current%obj% = this.Selected%obj%.asObservable(); ")

        ss = sb.ToString()
        ss = ss.Replace("%obj%", DeCap(P.Name))
        ss = ss.Replace("%parent%", DeCap(ParentPart.Name))
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name)

        Return ss
    End Function

    Private Function PartMake_Component(ByVal P As MTZMetaModel.MTZMetaModel.PART) As String
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
        sb.AppendLine("import { Component, OnInit, OnDestroy,  Input, Output, EventEmitter } from ""@angular/core"";")
        sb.AppendLine("import { %obj%_Service } from ""app/%capobj%.service"";")
        sb.AppendLine("import { AppService } from ""app/app.service"";")
        sb.AppendLine("import { Observable, SubscriptionLike as ISubscription} from ""rxjs"";")
        sb.AppendLine("import {  Validators } from ""@angular/forms"";")
        'sb.AppendLine("import { ISubscription} from ""rxjs/Subscription"";")
        sb.AppendLine("")
        sb.AppendLine("import { RemoveHTMLtagPipe } from 'app/pipes';")
        sb.AppendLine("import { %type% } from ""app/%type%"";")
        sb.AppendLine("import * as XLSX from 'xlsx';")
        sb.AppendLine("")
        sb.AppendLine("const MODE_LIST = 0;")
        sb.AppendLine("const MODE_NEW = 1;")
        sb.AppendLine("const MODE_EDIT = 2;")
        sb.AppendLine("")

        sb.AppendLine("@Component({")
        sb.AppendLine("	   selector: 'app-%obj%',")
        sb.AppendLine("    styleUrls: ['./%capobj%.component.scss'],")
        sb.AppendLine("    templateUrl: './%capobj%.component.html',")
        sb.AppendLine("})")
        sb.AppendLine("export class %obj%Component implements OnInit {")
        sb.AppendLine("")

        sb.AppendLine("    %obj%Array: Array<%type%.%obj%> = [];")
        sb.AppendLine("    opened: boolean = false;")
        sb.AppendLine("    confirmOpened: boolean = false;")
        sb.AppendLine("    mode: Number = MODE_LIST;")
        sb.AppendLine("    current%obj%: %type%.%obj% = {} as %type%.%obj%;")
        sb.AppendLine("    formMsg: string = '';")
        sb.AppendLine("    valid:boolean=true;")
        sb.AppendLine("    errorFlag:boolean=false;")
        sb.AppendLine("    errorMessage:string='';")
        sb.AppendLine("    errorDetail:string='';")



        If Not isRoot Then
            sb.AppendLine("   subscription:ISubscription;")
        End If
        sb.AppendLine("")
        sb.AppendLine("    constructor( private %obj%_Service: %obj%_Service,  public AppService:AppService ) {")
        sb.AppendLine("    }")
        sb.AppendLine("")

        sb.AppendLine("    ngOnInit() {")
        If Not isRoot Then
            sb.AppendLine("		   // console.log(""Subscribe %obj%""); ")
            sb.AppendLine("        this.subscription=this.AppService.current%parent%.subscribe(si =>{ this.refresh%obj%(); }, error => { this.ShowError(error); } );")
        End If
        sb.AppendLine("        this.refresh%obj%();")
        sb.AppendLine("    }")

        'refreshCombo
        Dim part As MTZMetaModel.MTZMetaModel.PART
        sb.AppendLine("    refreshCombo() {")
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    part = fld.RefToPart
                    sb.AppendLine("     this.AppService.refreshCombo" + part.Name + "();")
                End If
            End If


        Next

        sb.AppendLine("    }")


        sb.AppendLine("    ngOnDestroy() {")
        If Not isRoot Then
            sb.AppendLine("		   // console.log(""Unsubscribe %obj%""); ")
            sb.AppendLine("        this.subscription.unsubscribe();")
        End If
        sb.AppendLine("    }")
        sb.AppendLine("")
        If isRoot Then
            sb.AppendLine("    refresh%obj%() {")
            sb.AppendLine("		   //console.log(""refreshing %obj%""); ")
            sb.AppendLine("        this.%obj%_Service.getAll_%obj%s().subscribe(%obj%Array => { this.%obj%Array = %obj%Array; }, error => { this.ShowError(error); })")
            sb.AppendLine("        this.current%obj% = {} as %type%.%obj%;")
            If hasChild Then
                sb.AppendLine("       //console.log(""clear selection for %obj% on refresh"");")
                sb.AppendLine("        this.AppService.pushSelected%obj%(this.current%obj%);")
            End If

            sb.AppendLine("    }")
        Else
            sb.AppendLine("    refresh%obj%() {")
            sb.AppendLine("		let item:%type%.%parent%;")
            sb.AppendLine("		item=this.AppService.Last%parent%;")
            sb.AppendLine("		//console.log(""refreshing %obj%""); ")
            sb.AppendLine("     this.current%obj% = {} as %type%.%obj%;")
            If hasChild Then
                sb.AppendLine("     //console.log(""clear selection for %obj% on refresh"");")
                sb.AppendLine("     this.AppService.pushSelected%obj%(this.current%obj%);")
            End If

            sb.AppendLine("		if(typeof item === 'undefined') { ")
            sb.AppendLine("		   //console.log(""no parent item for refresh""); ")
            sb.AppendLine("        this.%obj%_Service.get_%obj%ByParent('00000000-0000-0000-0000-000000000000').subscribe(%obj%Array => { this.%obj%Array = %obj%Array; }, error => { this.ShowError(error); })")
            sb.AppendLine("			return; ")
            sb.AppendLine("		} ")
            sb.AppendLine("		if(typeof item." & DeCap(ParentPart.Name) & "id==='undefined') { ")
            sb.AppendLine("		   //console.log(""no parent id for refresh""); ")
            sb.AppendLine("        this.%obj%_Service.get_%obj%ByParent('00000000-0000-0000-0000-000000000000').subscribe(%obj%Array => { this.%obj%Array = %obj%Array; }, error => { this.ShowError(error); })")
            sb.AppendLine("			return; ")
            sb.AppendLine("		} ")
            sb.AppendLine("		if(typeof item." & DeCap(ParentPart.Name) & "id === 'string' ) {")
            sb.AppendLine("        this.%obj%_Service.get_%obj%ByParent(item." & DeCap(ParentPart.Name) & "id).subscribe(%obj%Array => { this.%obj%Array = %obj%Array; }, error => { this.ShowError(error); })")
            sb.AppendLine("      }")
            sb.AppendLine("    }")
        End If


        sb.AppendLine("")
        sb.AppendLine("	   ShowError(err:any){")
        sb.AppendLine("		this.errorMessage=err.message;")
        sb.AppendLine("		this.errorDetail=JSON.stringify(err.error);")
        sb.AppendLine("		this.errorFlag=true;")
        sb.AppendLine("	   }")

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
        sb.AppendLine("    this.refreshCombo(); ")
        If Not isRoot Then
            sb.AppendLine("      if(typeof ( this.AppService.Last%parent%." & DeCap(ParentPart.Name) & "id) === 'string' ) {")
            sb.AppendLine("        this.current%obj% = {} as %type%.%obj%;")
            sb.AppendLine("        this.current%obj%." & DeCap(ParentPart.Name) & "id = this.AppService.Last%parent%." & DeCap(ParentPart.Name) & "id;")
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
        sb.AppendLine("    this.refreshCombo(); ")
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
        sb.AppendLine("        this.confirmOpened = false;")
        sb.AppendLine("        this.%obj%_Service.delete_%obj%ById(this.current%obj%." & DeCap(P.Name) & "id).subscribe(data => {this.refresh%obj%(); this.backToList();}, error => { this.ShowError(error); });")
        sb.AppendLine("    }")
        sb.AppendLine("")



        ''''''''''''''''''''''''' clear combo boxes
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("	 " & DeCap(fld.Name) & "_clear
(){")
                    sb.AppendLine("     this.current%obj%." & DeCap(fld.Name) & " = -10000 ;")
                    sb.AppendLine("     setTimeout(function(){ this.current%obj%." & DeCap(fld.Name) & " = null;}.bind(this), 500);")
                    sb.AppendLine("	}")
                End If
            End If


            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("	 " & DeCap(fld.Name) & "_clear(){")
                    sb.AppendLine("     this.current%obj%." & DeCap(fld.Name) & " = 'empty-ref' ;")
                    sb.AppendLine("     setTimeout(function(){ this.current%obj%." & DeCap(fld.Name) & " = null;}.bind(this), 500);")
                    sb.AppendLine("	}")
                End If
            End If
        Next




        sb.AppendLine("    save(item: %type%.%obj%) {")
        sb.AppendLine("        this.valid=true; ")
        ''''''''''''''''''''''''' field validation
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType


            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                        If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                            sb.AppendLine("     if(this.current%obj%." & DeCap(fld.Name) & " == undefined ) this.valid=false;")
                        ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                            sb.AppendLine("     if(this.current%obj%." & DeCap(fld.Name) & " == undefined ) this.valid=false;")
                        Else
                            sb.AppendLine("     if(this.current%obj%." & DeCap(fld.Name) & " == undefined || this.current%obj%." & DeCap(fld.Name) & "=='') this.valid=false;")
                        End If
                    End If
                End If


                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                        sb.AppendLine("     if(this.current%obj%." & DeCap(fld.Name) & " == undefined ) this.valid=false;")
                    End If
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                        sb.AppendLine("     if(this.current%obj%." & DeCap(fld.Name) & " == undefined  ) this.valid=false;")
                    End If
                End If
            End If
        Next

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sb.AppendLine("        if (this.valid) {")
        sb.AppendLine("            switch (this.mode) {")
        sb.AppendLine("                case MODE_NEW: {")
        sb.AppendLine("                    this.%obj%_Service.create_%obj%(item)")
        sb.AppendLine("                        .subscribe(data =>{ this.refresh%obj%();this.backToList();}, error => { this.ShowError(error); });")
        sb.AppendLine("                    break;")
        sb.AppendLine("                }")
        sb.AppendLine("                case MODE_EDIT: {")
        sb.AppendLine("                    this.%obj%_Service.update_%obj%( item)")
        sb.AppendLine("                        .subscribe(data => {this.refresh%obj%();this.backToList();}, error => { this.ShowError(error); });")
        sb.AppendLine("                    break;")
        sb.AppendLine("                }")
        sb.AppendLine("                default:")
        sb.AppendLine("                    break;")
        sb.AppendLine("            }")
        sb.AppendLine("        }")
        sb.AppendLine("    }")
        sb.AppendLine("")

        sb.AppendLine(" exportXSLX(): void {")
        sb.AppendLine("        var aoa = [];")
        sb.AppendLine("/* set column headers at first line */")
        sb.AppendLine("        if(!aoa[0]) aoa[0] = [];")


        P.FIELD.Sort = "sequence"
        Dim fCnt As Integer
        fCnt = 0
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                sb.AppendLine("            aoa[0][" & fCnt.ToString() & "]='" & fld.Caption & "';")
                fCnt += 1
            End If
        Next


        sb.AppendLine("/* fill data to array */")
        sb.AppendLine("        for(var i = 0; i < this.%obj%Array.length; ++i) {")
        sb.AppendLine("            if(!aoa[i+1]) aoa[i+1] = [];")

        fCnt = 0
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                isFirst = False
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        sb.AppendLine("            aoa[i+1][" & fCnt.ToString() & "]=this.%obj%Array[i]." & DeCap(fld.Name) & "_name;")
                    ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        sb.AppendLine("            aoa[i+1][" & fCnt.ToString() & "]=this.%obj%Array[i]." & DeCap(fld.Name) & "_name;")
                    Else
                        sb.AppendLine("            aoa[i+1][" & fCnt.ToString() & "]=this.%obj%Array[i]." & DeCap(fld.Name) & ";")
                    End If
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    sb.AppendLine("            aoa[i+1][" & fCnt.ToString() & "]=this.%obj%Array[i]." & DeCap(fld.Name) & ";")
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    sb.AppendLine("            aoa[i+1][" & fCnt.ToString() & "]=this.%obj%Array[i]." & DeCap(fld.Name) & ";")
                End If
                fCnt += 1
            End If
        Next

        sb.AppendLine("        }")
        sb.AppendLine("		/* generate worksheet */")
        sb.AppendLine("		const ws: XLSX.WorkSheet = XLSX.utils.aoa_to_sheet(aoa);")
        sb.AppendLine("")
        sb.AppendLine("        var wscols = [")


        isFirst = True
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then

                If Not isFirst Then
                    sb.Append(",")
                End If
                isFirst = False
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        sb.AppendLine("            {wch: 50}")
                    ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        sb.AppendLine("            {wch: 30}")
                    ElseIf ft.Name.ToLower() = "memo" Then
                        sb.AppendLine("            {wch: 80}")
                    Else
                        sb.AppendLine("            {wch: 64}")
                    End If
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    sb.AppendLine("            {wch: 20}")
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    sb.AppendLine("            {wch: 18}")
                End If

            End If
        Next

        sb.AppendLine("        ];")
        sb.AppendLine("")
        sb.AppendLine("        ws['!cols'] = wscols;")
        sb.AppendLine("")
        sb.AppendLine("		/* generate workbook and add the worksheet */")
        sb.AppendLine("		const wb: XLSX.WorkBook = XLSX.utils.book_new();")
        sb.AppendLine("        XLSX.utils.book_append_sheet(wb, ws, '%obj%');")
        sb.AppendLine("        ")
        sb.AppendLine("")
        sb.AppendLine("        wb.Props = {")
        sb.AppendLine("            Title: ""%objname%"",")
        sb.AppendLine("            Subject: ""%objname%"",")
        sb.AppendLine("            Company: ""master.bami"",")
        sb.AppendLine("            Category: ""Experimentation"",")
        sb.AppendLine("            Keywords: ""Export service"",")
        sb.AppendLine("            Author: ""master.bami"",")
        sb.AppendLine("	           Manager: ""master.bami"",")
        sb.AppendLine("	           Comments: ""Raw data export"",")
        sb.AppendLine("	           LastAuthor: ""master.bami"",")
        sb.AppendLine("            CreatedDate: new Date(Date.now())")
        sb.AppendLine("        }")
        sb.AppendLine("")
        sb.AppendLine("		/* save to file */")
        sb.AppendLine("		XLSX.writeFile(wb, '%obj%.xlsx');")
        sb.AppendLine("	}")

        sb.AppendLine("    backToList() {")
        sb.AppendLine("        this.opened = false;")
        sb.AppendLine("        this.confirmOpened = false;")
        sb.AppendLine("        this.mode = MODE_LIST;")
        sb.AppendLine("        this.current%obj% = {} as %type%.%obj%;")

        If hasChild Then
            sb.AppendLine("        //console.log(""clear selection for %obj%"");")
            sb.AppendLine("        this.AppService.pushSelected%obj%(this.current%obj%);")
        End If

        sb.AppendLine("    }")
        sb.AppendLine("}")
        sb.AppendLine(" ")

        ss = sb.ToString()
        ss = ss.Replace("%obj%", DeCap(P.Name))
        ss = ss.Replace("%capobj%", P.Name)
        ss = ss.Replace("%parent%", DeCap(ParentPart.Name))
        ss = ss.Replace("%ns%", txtNS.Text)
        ss = ss.Replace("%type%", ot.Name)
        ss = ss.Replace("%objname%", ot.the_Comment & "::" & P.Caption)

        Tool_WriteFile(ss, textBoxOutPutFolder.Text & "\ts\" + P.Name + "\", P.Name + ".component.ts", False)

#End Region
#Region "html"

        ' write component html

        sb = New StringBuilder()

        sb.AppendLine("<!--Error dialogue-->")
        sb.AppendLine("<amexio-window amexioColorPalette [color-palette]=""'amexio-theme-color2'"" [gradient]=""true""  [show-window]=""errorFlag""")
        sb.AppendLine("            [header]=""true""")
        sb.AppendLine("			   [footer]=""true"" ")
        sb.AppendLine("			   [draggable]=""false"" ")   ' не работает выделение текста мышкой
        sb.AppendLine("			   [vertical-position]=""'top'"" ")
        sb.AppendLine("			   [horizontal-position]=""'center'"" ")
        sb.AppendLine("			   [closable]=""false""")
        sb.AppendLine("            amexioThemeStyle  [theme-style]=""'round-edge'""    >")
        sb.AppendLine("	<amexio-header>")
        sb.AppendLine("        <i class=""fa fa-exclamation-triangle""></i> Ошибка")
        sb.AppendLine("      </amexio-header>")
        sb.AppendLine("	   <amexio-body>")
        sb.AppendLine("        <amexio-row>")
        sb.AppendLine("          <amexio-column [size]=""11"">")
        sb.AppendLine("		  <span style=""color:red"">{{errorMessage}}</span>")
        sb.AppendLine("		  </amexio-column>")
        sb.AppendLine("        </amexio-row>
        <amexio-panel amexioThemeStyle   title=""Подробнее..."" [background]=""'yellow'"" [color]=""'black'"" [fit]=""false"" [border]=""false"" [header]=""true"" [height]=""'360'"" [expanded]=""false"">
          {{errorDetail}}
        </amexio-panel>")
        sb.AppendLine("	</amexio-body> ")
        sb.AppendLine("	<amexio-action> ")
        sb.AppendLine("	<amexio-row> ")
        sb.AppendLine("	<amexio-column size=""11""> ")
        sb.AppendLine("     <amexio-button amexioThemeStyle [theme-style]=""'round-edge'""    [label]=""'Ok'"" (onClick)=""errorFlag=false"" [type]=""'red'"" [tooltip]=""'Ok'"" [icon]=""'fa fa-exclamation-triangle'""></amexio-button>")
        sb.AppendLine("	</amexio-column> ")
        sb.AppendLine("	</amexio-row> ")
        sb.AppendLine("	</amexio-action> ")
        sb.AppendLine("</amexio-window>")



        sb.AppendLine("<!-- edit row pane -->	 ")
        sb.AppendLine(" <amexio-window amexioColorPalette [color-palette]=""'amexio-theme-color2'"" [gradient]=""true""  
        [closable]=""false"" [maximize]=""true"" 
        [vertical-position]=""'center'""    
        [horizontal-position]=""'center'""  
        [draggable]=""false"" 
        [remember-window-position]=""true"" 
        [width]=""'auto'""  
        amexioThemeStyle  [theme-style]=""'round-edge'""  
        [show-window]=""opened  && errorFlag==false"" 
        [header]=""true"" 
        [footer]=""true"" > ")
        'sb.AppendLine(" <amexio-window amexioColorPalette [color-palette]=""'amexio-theme-color2'"" [gradient]=""true""  [closable]=""false"" [vertical-position]=""'top'""  [horizontal-position]=""'right'"" [body-height]=""90"" [show-window]=""opened"" [header]=""true"" [footer]=""true"" > ")
        'sb.AppendLine(" <amexio-window amexioColorPalette [color-palette]=""'amexio-theme-color2'"" [gradient]=""true""  [closable]=""false""  [show-window]=""opened"" [header]=""true"" [footer]=""true"" > ")

        sb.AppendLine("	  <amexio-header> ")
        sb.AppendLine("        {{formMsg}} %objname% ")
        sb.AppendLine("<amexio-box *ngIf=""valid==false"" border-color =""red"" border=""all"" padding=""true"" background-color=""yellow"">")
        sb.AppendLine("	<amexio-label font-color=""red""  border=""bottom"">Ошибка заполнения формы</amexio-label>")
        sb.AppendLine("</amexio-box>")
        sb.AppendLine("      </amexio-header> ")
        sb.AppendLine("     <amexio-body> ")

        isFirst = True

        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                isFirst = False

                sb.AppendLine("     <amexio-row><amexio-column size=""12"" >")


                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                        If ft.Name = "Memo" Then


                            sb.AppendLine("<amexio-label ")
                            If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                                sb.AppendLine("            [size]=""'small'"" font-color=""BLUE"" ")
                            Else
                                sb.AppendLine("            [size]=""'small-bold'"" font-color=""BLACK"" ")
                            End If
                            sb.AppendLine(">" & fld.Caption & "</amexio-label>")

                            'sb.AppendLine("<ngx-wig  ")
                            'sb.AppendLine(" [(ngModel)]=""current%obj%." & DeCap(fld.Name) & """")
                            'sb.AppendLine(" [placeholder]=""'" & fld.Caption & "'"" ")
                            'sb.AppendLine(" [buttons]=""'bold,italic,link,list1,list2'"">")
                            'sb.AppendLine("</ngx-wig>")


                            sb.AppendLine("<angular-editor  ")
                            sb.AppendLine(" [(ngModel)]=""current%obj%." & DeCap(fld.Name) & """")
                            sb.AppendLine(" [placeholder]=""'" & fld.Caption & "'"" ")
                            sb.AppendLine(" [config]=""{ editable: true, spellcheck: false, height: 'auto', minHeight: '40', maxHeight: '600', width: 'auto', minWidth: '0' , translate: 'yes', enableToolbar: true, showToolbar: true, sanitize: true, toolbarPosition: 'top' }"">")
                            sb.AppendLine("</angular-editor>")

                        Else
                            If fld.TheStyle.Contains("textarea") Then
                                sb.AppendLine("<amexio-label ")
                                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                                    sb.AppendLine("            [size]=""'small'"" font-color=""BLUE"" ")
                                Else
                                    sb.AppendLine("            [size]=""'small-bold'"" font-color=""BLACK"" ")
                                End If
                                sb.AppendLine(">" & fld.Caption & "</amexio-label>")
                                sb.AppendLine(" <amexio-textarea-input [enable-popover]=""false""   name =""" & DeCap(fld.Name) & """ ")
                                sb.AppendLine("             [place-holder]=""'" & fld.Caption & "'"" ")

                                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                                    sb.AppendLine("            [allow-blank]=""true"" ")
                                Else
                                    sb.AppendLine("            [allow-blank]=""false"" [error-msg] =""'Не задано: " & fld.Caption & "'"" ")
                                End If
                                sb.AppendLine("	            [(ngModel)]=""current%obj%." & DeCap(fld.Name) & """")
                                sb.AppendLine("             [icon-feedback]=""true"" [rows]=""'5'"" [columns]=""'12'"" ")
                                sb.AppendLine("              > ")
                                sb.AppendLine("</amexio-textarea-input>")
                            Else
                                sb.AppendLine("<amexio-label ")
                                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                                    sb.AppendLine("            [size]=""'small'"" font-color=""BLUE"" ")
                                Else
                                    sb.AppendLine("            [size]=""'small-bold'"" font-color=""BLACK"" ")
                                End If
                                sb.AppendLine(">" & fld.Caption & "</amexio-label>")
                                sb.AppendLine("                    <amexio-text-input  name =""" & DeCap(fld.Name) & """  ")
                                sb.AppendLine("                    [place-holder] = ""'" & fld.Caption & "'"" ")
                                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                                    sb.AppendLine("            [allow-blank]=""true"" ")
                                Else
                                    sb.AppendLine("            [allow-blank]=""false"" [error-msg] =""'Не задано: " & fld.Caption & "'"" ")
                                End If
                                sb.AppendLine("                    [icon-feedback] = ""true"" [(ngModel)]=""current%obj%." & DeCap(fld.Name) & """ >")
                                sb.AppendLine("                    </amexio-text-input>")
                            End If


                        End If



                    End If


                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                        sb.AppendLine("<amexio-label ")
                        If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            sb.AppendLine("            [size]=""'small'"" font-color=""BLUE"" ")
                        Else
                            sb.AppendLine("            [size]=""'small-bold'"" font-color=""BLACK"" ")
                        End If
                        sb.AppendLine(">" & fld.Caption & "</amexio-label>")
                        sb.AppendLine("  <amexio-date-time-picker    ")
                        If ft.Name.ToLower() = "date" Then
                            sb.AppendLine("        [time-picker]=""false""  ")
                            sb.AppendLine("        [date-picker]=""true""  ")
                        End If
                        If ft.Name.ToLower() = "datetime" Then
                            sb.AppendLine("        [time-picker]=""true""  ")
                            sb.AppendLine("        [date-picker]=""true""  ")
                        End If
                        If ft.Name.ToLower() = "time" Then
                            sb.AppendLine("        [time-picker]=""true""  ")
                            sb.AppendLine("        [date-picker]=""false""  ")
                        End If

                        If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            sb.AppendLine("            [required]=""false"" ")
                        Else
                            sb.AppendLine("            [required]=""true"" ")
                        End If

                        sb.AppendLine("        [(ngModel)]=""current%obj%." & DeCap(fld.Name) & """> ")


                        sb.AppendLine(" </amexio-date-time-picker> ")

                    End If

                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                        sb.AppendLine("<amexio-label ")
                        If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            sb.AppendLine("            [size]=""'small'"" font-color=""BLUE"" ")
                        Else
                            sb.AppendLine("            [size]=""'small-bold'"" font-color=""BLACK"" ")
                        End If
                        sb.AppendLine(">" & fld.Caption & "</amexio-label>")
                        sb.AppendLine(" <amexio-number-input  [enable-popover]= ""false""  name =""" & DeCap(fld.Name) & """ ")
                        sb.AppendLine("                    [place-holder]=""'" & fld.Caption & "'"" ")

                        If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            sb.AppendLine("            [allow-blank]=""true"" ")
                        Else
                            sb.AppendLine("            [allow-blank]=""false"" [error-msg] =""'Не задано: " & fld.Caption & "'"" ")
                        End If

                        sb.AppendLine("	 [(ngModel)]=""current%obj%." & DeCap(fld.Name) & """")
                        sb.AppendLine("                    > ")
                        sb.AppendLine(" </amexio-number-input>")

                    End If


                End If

            End If


            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
                sb.AppendLine("<amexio-label ")
                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("            [size]=""'small'"" font-color=""BLUE"" ")
                Else
                    sb.AppendLine("            [size]=""'small-bold'"" font-color=""BLACK"" ")
                End If
                sb.AppendLine(">" & fld.Caption & "</amexio-label>")
                sb.AppendLine(" <amexio-number-input  [enable-popover]= ""false""  name =""" & DeCap(fld.Name) & """ ")
                sb.AppendLine("                    [place-holder]=""'" & fld.Caption & "'"" ")

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("            [allow-blank]=""true"" ")
                Else
                    sb.AppendLine("            [allow-blank]=""false"" [error-msg] =""'Не задано: " & fld.Caption & "'"" ")
                End If

                sb.AppendLine("	 [(ngModel)]=""current%obj%." & DeCap(fld.Name) & """")
                sb.AppendLine("                    > ")
                sb.AppendLine(" </amexio-number-input>")

            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine(" <amexio-row>
           <amexio-column size=""11"" >")
                End If

                sb.AppendLine("<amexio-label ")
                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("            [size]=""'small'"" font-color=""BLUE"" ")
                Else
                    sb.AppendLine("            [size]=""'small-bold'"" font-color=""BLACK"" ")
                End If
                sb.AppendLine(">" & fld.Caption & "</amexio-label>")
                sb.AppendLine("<amexio-dropdown ")
                sb.AppendLine("	  name =""" & DeCap(fld.Name) & """ ")
                sb.AppendLine("                    [place-holder]=""'" & fld.Caption & "'"" ")
                sb.AppendLine("	 [(ngModel)]=""current%obj%." & DeCap(fld.Name) & """")

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("            [allow-blank]=""true"" ")
                Else
                    sb.AppendLine("            [allow-blank]=""false"" [error-msg] =""'Не задано: " & fld.Caption & "'"" ")
                End If

                sb.AppendLine("	 [display-field]=""'name'""")
                sb.AppendLine("	 [value-field]=""'id'""")

                sb.AppendLine("	 [data]=""AppService.enum" & ft.Name & "Combo()""")
                sb.AppendLine("	 >")
                sb.AppendLine("</amexio-dropdown>")

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("  </amexio-column>
                   <amexio-column size=""1"" >")
                    sb.AppendLine(" <amexio-button amexioThemeStyle  [label]=""'X'"" (onClick)=""" & DeCap(fld.Name) & "_clear();"" [type]=""'secondary'"" [tooltip]=""'Сброс'"" ></amexio-button>")
                    sb.AppendLine("</amexio-column>
     </amexio-row>")
                End If

            End If


            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine(" <amexio-row>
           <amexio-column size=""11"" >")
                End If

                sb.AppendLine("<amexio-label ")
                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("            [size]=""'small'"" font-color=""BLUE"" ")
                Else
                    sb.AppendLine("            [size]=""'small-bold'"" font-color=""BLACK"" ")
                End If
                sb.AppendLine(">" & fld.Caption & "</amexio-label>")
                sb.AppendLine("	 <amexio-dropdown ")
                sb.AppendLine("	 [place-holder] = ""'" & fld.Caption & "'""")
                sb.AppendLine("	 name =""" & DeCap(fld.Name) & """")
                ' sb.AppendLine("	 [field-label]= ""'" & fld.Caption & "'""")

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("            [allow-blank]=""true"" ")
                Else
                    sb.AppendLine("            [allow-blank]=""false"" [error-msg] =""'Не задано: " & fld.Caption & "'"" ")
                End If
                sb.AppendLine("	 ")
                sb.AppendLine("	 [display-field]=""'name'""")
                sb.AppendLine("	 [value-field]=""'id'""")
                refP = fld.RefToPart
                sb.AppendLine("	 [data]=""AppService.Combo" & refP.Name & """")
                sb.AppendLine("	 ")
                sb.AppendLine("	 [(ngModel)]=""current%obj%." & DeCap(fld.Name) & """")
                sb.AppendLine("	 >")
                sb.AppendLine("  </amexio-dropdown>")

                If fld.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    sb.AppendLine("  </amexio-column>
                   <amexio-column size=""1"" >")
                    ' '00000000-0000-0000-0000-000000000000';
                    sb.AppendLine(" <amexio-button amexioThemeStyle  [label]=""'X'"" (onClick)=""" & DeCap(fld.Name) & "_clear(); "" [type]=""'secondary'"" [tooltip]=""'Сброс'"" ></amexio-button>")
                    sb.AppendLine("</amexio-column>
     </amexio-row>")
                End If

            End If
            sb.AppendLine("     </amexio-column></amexio-row>")
        Next
        sb.AppendLine("	</amexio-body> ")
        sb.AppendLine("	<amexio-action> ")
        sb.AppendLine("	<amexio-row> ")
        sb.AppendLine("	<amexio-column size=""12""> ")
        'sb.AppendLine("		<button type=""button"" class=""btn btn-outline"" (click) = ""opened = false"">Отмена</button> ")
        sb.AppendLine("     <amexio-button amexioThemeStyle [theme-style]=""'round-edge'""   [label]=""'Отмена'"" (onClick)=""opened = false;  refresh%obj%();"" [type]=""'secondary'"" [tooltip]=""'Отмена'"" [icon]=""'fa fa-times'""></amexio-button>")
        'sb.AppendLine("		<button type=""submit"" class=""btn btn-primary"" (click)=""save(current%obj%, true)"" >Сохранить</button> ")
        sb.AppendLine("     <amexio-button amexioThemeStyle [theme-style]=""'round-edge'""   [label]=""'Сохранить'"" (onClick)=""save(current%obj%)"" [type]=""'success'"" [tooltip]=""'Сохранить'"" [icon]=""'fa fa-save'""></amexio-button>")
        sb.AppendLine("	</amexio-column> ")
        sb.AppendLine("	</amexio-row> ")
        sb.AppendLine("	</amexio-action> ")
        sb.AppendLine("</amexio-window> ")
        sb.AppendLine("   ")
        sb.AppendLine("<!-- list Of row pane --> ")
        sb.AppendLine("<amexio-card  amexioColorPalette [color-palette]=""'classic'"" [gradient]=""true"" [show]=""true"" [header] =""true"" [footer] =""false"" > ")
        sb.AppendLine("    <amexio-header> ")
        sb.AppendLine("	<amexio-row> ")
        sb.AppendLine("		<amexio-column size=""12"" > ")

        If Not isRoot Then
            sb.AppendLine("		<amexio-button amexioThemeStyle [theme-style]=""'round-edge'""  [disabled]=""AppService.Last%parent%." & DeCap(ParentPart.Name) & "id==null"" [label]=""'Создать'"" [type]=""'secondary'"" [tooltip]=""'Создать новую запись'"" [icon]=""'fa fa-plus'"" (onClick)=""onNew()""></amexio-button>")
        Else
            sb.AppendLine("		<amexio-button amexioThemeStyle [theme-style]=""'round-edge'""  [label]=""'Создать'"" [type]=""'secondary'"" [tooltip]=""'Создать новую запись'"" [icon]=""'fa fa-plus'"" (onClick)=""onNew()""></amexio-button>")
        End If
        sb.AppendLine("		<amexio-button amexioThemeStyle [theme-style]=""'round-edge'""  [disabled]=""current%obj%." & DeCap(P.Name) & "id==null"" [label]=""'Изменить'"" (onClick)=""onEdit(current%obj%)"" [type]=""'secondary'"" [tooltip]=""'Изменить запись'"" [icon]=""'fa fa-edit'""></amexio-button>")

        sb.AppendLine("     <amexio-button amexioThemeStyle [theme-style]=""'round-edge'""  [disabled]=""current%obj%." & DeCap(P.Name) & "id==null"" [label]=""'Удалить'"" (onClick)=""onDelete(current%obj%)"" [type]=""'secondary'"" [tooltip]=""'Удалить запись'"" [icon]=""'fa fa-trash'""></amexio-button>")

        sb.AppendLine("     <amexio-button amexioThemeStyle [theme-style]=""'round-edge'""   [label]=""'Обновить'"" (onClick)=""refresh%obj%()"" [type]=""'secondary'"" [tooltip]=""'Обновить данные'"" [icon]=""'fa fa-refresh'""></amexio-button>")

        sb.AppendLine("     <amexio-button amexioThemeStyle [theme-style]=""'round-edge'""   [label]=""'Экспорт'"" (onClick)=""exportXSLX()"" [type]=""'secondary'"" [tooltip]=""'Экспорт данных'"" [icon]=""'fa fa-cloud'""></amexio-button>")

        sb.AppendLine("		</amexio-column>")
        sb.AppendLine("	</amexio-row> ")
        sb.AppendLine("	</amexio-header> ")
        sb.AppendLine("	<amexio-body> ")
        sb.AppendLine("		<amexio-datagrid amexioColorPalette [color-palette]=""'vibrant'"" [gradient]=""true"" ")
        sb.AppendLine("		  [title]=""'%objname%'"" ")
        sb.AppendLine("		  [page-size] = ""10"" ")
        sb.AppendLine("		  [enable-data-filter]=""false"" [global-filter]=""true"" ")
        sb.AppendLine("		  [enable-checkbox]=""false"" ")
        sb.AppendLine("		  [data]=""%obj%Array"" ")
        sb.AppendLine("		  (selectedRowData)=""onSelect($event)"" ")
        sb.AppendLine("		  (rowSelect)=""onSelect($event)""> ")


        isFirst = True

        P.FIELD.Sort = "sequence"
        For i = 1 To P.FIELD.Count
            fld = P.FIELD.Item(i)
            ft = fld.FieldType

            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then

                isFirst = False
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        sb.AppendLine("		  <amexio-data-table-column [data-index]=""'" & DeCap(fld.Name) & "_name'"" [data-type]=""'string'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""></amexio-data-table-column> ")
                    ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        sb.AppendLine("		  <amexio-data-table-column [data-index]=""'" & DeCap(fld.Name) & "_name'"" [data-type]=""'string'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""></amexio-data-table-column> ")
                    Else

                        If ft.Name.ToLower = "memo" Or ft.Name.ToLower = "string" Then
                            sb.AppendLine("		  <amexio-data-table-column [data-index]=""'" & DeCap(fld.Name) & "'"" [data-type]=""'string'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""> ")
                            sb.AppendLine(" 		  <ng-template #amexioBodyTmpl let-column let-row=""row"">")
                            sb.AppendLine("             {{  ((row." & DeCap(fld.Name) & ") ? ((row." & DeCap(fld.Name) & ".length>100) ? row." & DeCap(fld.Name) & ".substr(0,100)+'...' : row." & DeCap(fld.Name) & " ) : '-') | removehtmltag }} ")
                            sb.AppendLine("           </ng-template>")
                            sb.AppendLine("		  </amexio-data-table-column> ")
                        Else

                            sb.AppendLine("		  <amexio-data-table-column [data-index]=""'" & DeCap(fld.Name) & "'"" [data-type]=""'string'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""></amexio-data-table-column> ")
                        End If


                    End If
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    sb.AppendLine("		  <amexio-data-table-column [data-index]=""'" & DeCap(fld.Name) & "'"" [data-type]=""'number'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""></amexio-data-table-column> ")
                End If
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    sb.AppendLine("		  <amexio-data-table-column [data-index]=""'" & DeCap(fld.Name) & "'"" [data-type]=""'string'"" [hidden]=""false"" [text]=""'" & fld.Caption & "'""></amexio-data-table-column> ")
                End If
            End If
        Next


        sb.AppendLine("		</amexio-datagrid> ")
        sb.AppendLine("	</amexio-body> ")
        sb.AppendLine("</amexio-card> ")
        sb.AppendLine(" ")
        sb.AppendLine("<!-- confirm delete  dialog -->  ")
        sb.AppendLine("<amexio-window amexioColorPalette [color-palette]=""'amexio-theme-color2'"" [gradient]=""true""   [show-window]=""confirmOpened && errorFlag==false "" [closable]=""false"" [header]=""true"" [footer]=""true"" amexioThemeStyle  [theme-style]=""'round-edge'"" >  ")
        sb.AppendLine("     ")
        sb.AppendLine("    <amexio-header>")
        sb.AppendLine("Удалить строку:  %objname% ?")
        sb.AppendLine("    </amexio-header> ")
        sb.AppendLine("    <amexio-body> ")


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
                        rowStr = rowStr & "current%obj%." & DeCap(fld.Name) & "_name"
                    Else
                        rowStr = rowStr & "current%obj%." & DeCap(fld.Name)
                    End If


                End If
            End If

        Next

        sb.AppendLine("            Удалить запись: {{ ( (" & rowStr & "||'').length >100 ? (" & rowStr & "||'').substr(0,100)+'...' : (" & rowStr & "||'')) | removehtmltag }}?  ")


        sb.AppendLine("	</amexio-body> ")
        sb.AppendLine("	<amexio-action> ")
        sb.AppendLine("	<amexio-row> ")
        sb.AppendLine("	<amexio-column size=""12""> ")
        sb.AppendLine("     <amexio-button amexioThemeStyle [theme-style]=""'round-edge'""   [label]=""'Отмена'"" (onClick)=""confirmOpened = false"" [type]=""'secondary'"" [tooltip]=""'Отмена'"" [icon]=""'fa fa-times'""></amexio-button>")
        sb.AppendLine("     <amexio-button amexioThemeStyle [theme-style]=""'round-edge'""   [label]=""'Удалить'"" (onClick)=""onConfirmDeletion()"" [type]=""'danger'"" [tooltip]=""'Удалить'"" [icon]=""'fa fa-trash'""></amexio-button>")
        sb.AppendLine("	</amexio-column> ")
        sb.AppendLine("	</amexio-row> ")
        sb.AppendLine("	</amexio-action> ")
        sb.AppendLine("</amexio-window> ")
        sb.AppendLine(" ")





        ss = sb.ToString()
        ss = ss.Replace("%obj%", DeCap(P.Name))
        ss = ss.Replace("%parent%", DeCap(ParentPart.Name))
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

    Private Sub chkUseDecap_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseDecap.CheckedChanged
        UseDeCap = chkUseDecap.Checked


    End Sub

    Private Sub txtContext_TextChanged(sender As Object, e As EventArgs) Handles txtContext.TextChanged
        SaveSetting("L2BUILDER", "EXT2NET_" & Manager.Site, "DEFCONTEXT", txtContext.Text)
    End Sub
End Class