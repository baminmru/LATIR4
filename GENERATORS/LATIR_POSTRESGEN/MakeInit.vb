Option Strict Off
Option Explicit On
Imports MTZMetaModel.MTZMetaModel

Friend Class MakeInit
	
    Dim m As MTZMetaModel.MTZMetaModel.Application
    'UPGRADE_WARNING: Arrays in structure o may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Dim o As LatirGenerator.Response
    Dim tid As String
    Dim parent As Generator

    Public Sub Init(ByRef ap As Generator, ByRef am As MTZMetaModel.MTZMetaModel.Application, ByRef ao As LatirGenerator.Response, ByVal atid As String)
        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub


    Private Function GetMap2(ByVal s As String) As String
        Dim out As String
        out = parent.GetMap(s)
        '  out = Replace(out, "{", "")
        '  out = Replace(out, "}", "")
        GetMap2 = out
    End Function

    Private Function GetID(ByVal s As String) As String
        Dim out As String = s

        '  out = Replace(s, "{", "")
        '  out = Replace(out, "}", "")
        GetID = out
    End Function

    Public Sub Run()
        System.Diagnostics.Debug.Print("POSTGRESGEN.LoadOptions:start ")
        Dim s As Writer
        s = New Writer
        System.Windows.Forms.Application.DoEvents()
        'Dim os As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim j As Integer
        s.putBuf("create or replace function InitBase() returns integer as $$ ")
        s.putBuf("declare")
        s.putBuf("aid uuid;")
        s.putBuf("ainstid uuid;")
        s.putBuf("auid uuid;")
        s.putBuf("aSESSION uuid;")
        s.putBuf("acid uuid;")
        s.putBuf("asecid uuid;")
        s.putBuf("ahid uuid;")
        s.putBuf("atmpstr varchar(255);")
        s.putBuf("begin")
        s.putBuf("ainstid := '" & GetMap2("MTSYSTEMID") & "';")
        s.putBuf("auid := '" & GetMap2("inituser") & "'; ")
        s.putBuf("asecid := '" & GetMap2("secid") & "'; --user security instance ")
        s.putBuf("ahid := '" & GetMap2("helper") & "'; -- helper id")

        s.putBuf("delete from users;")
        s.putBuf("delete from typelist;")
        s.putBuf("delete from sysoptions;")
        s.putBuf("delete from instance;")

        s.putBuf("insert into instance(InstanceID,OBJTYPE,Name) values(ainstid, 'MTZSYSTEM','Системная информация');")
        s.putBuf("insert into instance(InstanceID,OBJTYPE,Name) values(asecid, 'MTZUsers', 'Пользователи и группы');")
        s.putBuf("insert into users(usersid,instanceid,login,password,name) values('" & GetMap2("supervisor") & "',asecid,'supervisor','bami','Администратор');")
        For i = 1 To m.OBJECTTYPE.Count
            s.putBuf("insert into typelist( typelistid,name,DeleteProc, HCLProc, propagateProc) values(newid(),'" & m.OBJECTTYPE.Item(i).Name & "', '" & m.OBJECTTYPE.Item(i).Name & "_DELETE', '" & m.OBJECTTYPE.Item(i).Name & "_HCL', '" & m.OBJECTTYPE.Item(i).Name & "_propagate');")
        Next

        For i = 1 To m.OBJECTTYPE.Count

            If Not m.OBJECTTYPE.Item(i).ChooseView Is Nothing Then
                'UPGRADE_WARNING: Couldn't resolve default property of object m.OBJECTTYPE.Item(i).ChooseView.the_Alias. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                s.putBuf("PERFORM SysOptions_SAVE ( '" & GetMap2(m.OBJECTTYPE.Item(i).Name & "_TDEFVIEW") & "', '" & m.OBJECTTYPE.Item(i).Name & "', '" & CType(m.OBJECTTYPE.Item(i).ChooseView, MTZMetaModel.MTZMetaModel.PARTVIEW).the_Alias & "', 'TDEFVIEW');")
            End If

            For j = 1 To m.OBJECTTYPE.Item(i).PART.Count
                s.putBuf(MapAndParent(m.OBJECTTYPE.Item(i).PART.Item(j)))
                s.putBuf(MapPartView(m.OBJECTTYPE.Item(i).PART.Item(j)))
            Next
        Next

        For i = 1 To m.SHAREDMETHOD.Count
            s.putBuf("PERFORM SysOptions_SAVE ( '" & GetMap2(m.SHAREDMETHOD.Item(i).Name & "_METHOD") & "', '" & GetID(m.SHAREDMETHOD.Item(i).ID.ToString) & "', '" & m.SHAREDMETHOD.Item(i).Name & "', 'METHODNAME');")
        Next

        s.putBuf("return 1;")
        s.putBuf("end;")
        s.putBuf("$$ language 'plpgsql'; ")
        s.putBuf("GO")



        o.ModuleName = "--Init"
        o.Block = "--body"
        o.OutNL(s.getBuf)
        System.Diagnostics.Debug.Print("POSTGRESGEN.LoadOptions:done ")
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
    End Sub


    Private Function MapPartView(ByRef os As MTZMetaModel.MTZMetaModel.PART) As String
        Dim s As String = ""
        Dim i As Integer
        For i = 1 To os.PARTVIEW.Count
            If os.PARTVIEW.Item(i).ForChoose = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                s = s & vbCrLf & "PERFORM SysOptions_SAVE ( '" & GetMap2(os.Name & "_DEFVIEW") & "', '" & VF(os.Name) & "', '" & os.PARTVIEW.Item(i).the_Alias & "', 'DEFVIEW');"
                Exit For
            End If
        Next
        For i = 1 To os.PART.Count
            s = s & vbCrLf & MapPartView(os.PART.Item(i))
        Next

        MapPartView = s
        System.Diagnostics.Debug.Print("POSTGRESGEN.MapPartView:done " & os.Caption)
    End Function


    Private Function MapAndParent(ByRef os As MTZMetaModel.MTZMetaModel.PART) As String
        System.Diagnostics.Debug.Print("POSTGRESGEN.MapAndParent:start " & os.Caption)
        Dim s As String = ""
        Dim tn As String
        tn = parent.TypeForStruct(os).Name

        s = s & vbCrLf & "PERFORM SysOptions_SAVE  ('" & GetMap2(os.Name & "_structtype") & "', '" & VF(os.Name) & "', '" & tn & "', 'STRUCT_TYPE');"

       If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
             s = s & vbCrLf & "PERFORM SysOptions_SAVE ( '" & GetMap2(os.Name & "_PARENT") & "', '" & VF(os.Name) & "', '" & CType(os.Parent.Parent, PART).Name & "', 'PARENT');"
        End If

        'Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
       
        For i = 1 To os.PART.Count
            s = s & vbCrLf & MapAndParent(os.PART.Item(i))
        Next

        MapAndParent = s
        System.Diagnostics.Debug.Print("POSTGRESGEN.MapAndParent:done " & os.Caption)
    End Function


     Private Function MapViews(ByRef pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW) As String
        Dim s As String
        s = "PERFORM  SysOptions_SAVE  ('" & GetMap2(pv_Renamed.the_Alias & "_map") & "', '" & GetID(pv_Renamed.ID.ToString) & "', aValue=.'V_" & pv_Renamed.the_Alias & "', aOptionType=.'MAP');"
        MapViews = s
    End Function
End Class