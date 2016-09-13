Imports LATIRGenerator
Imports MTZMetaModel.MTZMetaModel


Public Class MakeInit
    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim o As LatirGenerator.Response
    Dim tid As String
    Dim parent As Generator

    Public Sub Init(ByVal ap As Generator, ByVal am As MTZMetaModel.MTZMetaModel.Application, ByVal ao As LatirGenerator.Response, ByVal atid As String)
        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub


    Private Function GetMap2(ByVal s As String) As String
        Dim out As String
        out = parent.GetMap(s)
        out = out.ToUpper()
        Return out
    End Function

    Private Function GetID(ByVal s As String) As String
        Dim out As String = s

        out = out.ToUpper()
        Return out
    End Function

    Public Sub Run()
        System.Diagnostics.Debug.Print("ORAGEN.LoadOptions:start ")
        Dim s As Writer
        s = New Writer
        ' DoEvents()
        'Dim os As PART
        Dim i As Long
        Dim j As Long
        s.putBuf("create or replace procedure InitBase as ")
        s.putBuf("aid CHAR(38);")
        s.putBuf("ainstid CHAR(38);")
        s.putBuf("auid CHAR(38);")
        s.putBuf("aSESSION CHAR(38);")
        s.putBuf("acid CHAR(38);")
        s.putBuf("asecid CHAR(38);")
        s.putBuf("ahid CHAR(38);")
        s.putBuf("atmpstr varchar2(255);")
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
                s.putBuf("" + SchemaName +".Kernel.SysOptions_SAVE ( aSysOptionsid=>'" & GetMap2(m.OBJECTTYPE.Item(i).Name & "_TDEFVIEW") & "', aName=>'" & m.OBJECTTYPE.Item(i).Name & "', aValue=>'" & CType(m.OBJECTTYPE.Item(i).ChooseView, PARTVIEW).the_Alias & "', aOptionType=>'TDEFVIEW');")
            End If

            For j = 1 To m.OBJECTTYPE.Item(i).PART.Count
                s.putBuf(MapAndParent(m.OBJECTTYPE.Item(i).PART.Item(j)))
                s.putBuf(MapPartView(m.OBJECTTYPE.Item(i).PART.Item(j)))
            Next
        Next

        For i = 1 To m.SHAREDMETHOD.Count
            s.putBuf("" + SchemaName +".Kernel.SysOptions_SAVE ( aSysOptionsid=>'" & GetMap2(m.SHAREDMETHOD.Item(i).Name & "_METHOD") & "', aName=>'" & GetID(m.SHAREDMETHOD.Item(i).ID.ToString) & "', aValue=>'" & m.SHAREDMETHOD.Item(i).Name & "', aOptionType=>'METHODNAME');")
        Next




        s.putBuf(" --Logout  (acursession=>asession);")

        's.putBuf "delete from the_session;"

        s.putBuf("end;")
        s.putBuf("/")
        s.putBuf("begin InitBase(); end;")
        s.putBuf("/")
        o.ModuleName = "--Init"
        o.Block = "--body"
        o.OutNL(s.getBuf)
        System.Diagnostics.Debug.Print("ORAGEN.LoadOptions:done ")
        s = Nothing
    End Sub


    Private Function MapPartView(ByVal os As PART) As String
        Dim s As String = ""
        Dim i As Long
        For i = 1 To os.PARTVIEW.Count
            If os.PARTVIEW.Item(i).ForChoose = enumBoolean.Boolean_Da Then
                s = s & vbCrLf & "" + SchemaName +".Kernel.SysOptions_SAVE ( aSysOptionsid=>'" & GetMap2(os.Name & "_DEFVIEW") & "', aName=>'" & VF(os.Name) & "', aValue=>'" & os.PARTVIEW.Item(i).the_Alias & "', aOptionType=>'DEFVIEW');"
                Exit For
            End If
        Next
        For i = 1 To os.PART.Count
            s = s & vbCrLf & MapPartView(os.PART.Item(i))
        Next

        MapPartView = s
        System.Diagnostics.Debug.Print("ORAGEN.MapPartView:done " & os.Caption)
    End Function


    Private Function MapAndParent(ByVal os As PART) As String
        System.Diagnostics.Debug.Print("ORAGEN.MapAndParent:start " & os.Caption)
        Dim s As String = ""
        Dim tn As String
        tn = parent.TypeForStruct(os).Name

        s = s & vbCrLf & "" + SchemaName +".Kernel.SysOptions_SAVE  (aSysOptionsid=>'" & GetMap2(os.Name & "_structtype") & "', aName=>'" & VF(os.Name) & "', aValue=>'" & tn & "', aOptionType=>'STRUCT_TYPE');"

        If TypeName(os.parent.parent) <> "OBJECTTYPE" Then
            s = s & vbCrLf & "" + SchemaName +".Kernel.SysOptions_SAVE ( aSysOptionsid=>'" & GetMap2(os.Name & "_PARENT") & "', aName=>'" & VF(os.Name) & "', aValue=>'" & CType(os.Parent.Parent, PART).Name & "', aOptionType=>'PARENT');"
        End If

        'Dim chos As PART
        Dim i As Long
        '  For i = 1 To os.PARTVIEW.Count
        '    s = s & vbCrLf & MapViews(os.PARTVIEW.Item(i))
        '  Next


        For i = 1 To os.PART.Count
            s = s & vbCrLf & MapAndParent(os.PART.Item(i))
        Next

        MapAndParent = s
        System.Diagnostics.Debug.Print("ORAGEN.MapAndParent:done " & os.Caption)
    End Function


    Private Function MapViews(ByVal pv As PARTVIEW) As String
        Dim s As String
        s = "  " + SchemaName +".Kernel.SysOptions_SAVE  (aSysOptionsid=>'" & GetMap2(pv.the_Alias & "_map") & "', aName=>'" & GetID(pv.ID.ToString) & "', aValue=.'V_" & pv.the_Alias & "', aOptionType=.'MAP');"
        MapViews = s
    End Function
End Class