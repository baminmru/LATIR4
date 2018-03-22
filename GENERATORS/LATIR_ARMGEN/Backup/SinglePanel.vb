Option Strict Off
Option Explicit On
Module SinglePanel
	
    Sub MakeSinglePanel(ByRef prj As String, ByRef pctl As LATIRGenerator.ControlData, ByRef ot As MTZFltr.MTZFltr.Application, ByRef p As MTZFltr.MTZFltr.FilterFieldGroup, ByRef body As String, ByRef tsClick As String, ByRef tsInit As String)
        Dim lctl As LATIRGenerator.ControlData

        lctl = pctl.ControlData.Add()
        lctl.name = "edit" & p.name
        lctl.ProgId = prj & ".pnl" & ot.Filters.Item(1).name & "_" & p.name
        AddProp(lctl, "Name", lctl.name)

        Dim btn As LATIRGenerator.ControlData

        btn = pctl.ControlData.Add()
        btn.ProgId = "VB.CommandButton"
        btn.name = "cmd" & p.name & "Cfg"
        AddProp(btn, "Name", btn.name)
        AddProp(btn, "Caption", "")
        AddProp(btn, "Tag", "config.ico")
        AddProp(btn, "ToolTipText", "Настройка внешнего вида")
        AddProp(btn, "Style", CStr(1))
        AddProp(btn, "UseMaskColor", CStr(True))
        AddProp(btn, "Height", CStr(22 * VB6.TwipsPerPixelY))
        AddProp(btn, "Width", CStr(22 * VB6.TwipsPerPixelX))
        AddProp(btn, "Top", CStr(2 * VB6.TwipsPerPixelY))
        AddProp(btn, "Left", CStr(5 * VB6.TwipsPerPixelY))


        body = body & vbCrLf & "Private Sub cmd" & p.name & "Cfg_Click()"
        body = body & vbCrLf & "    on error resume next "
        body = body & vbCrLf & "    " & lctl.name & ".Customize"
        body = body & vbCrLf & "    dim ff as long "
        body = body & vbCrLf & "    ff = FreeFile"
        body = body & vbCrLf & "    Open GetSetting(""MTZ"", ""CONFIG"", ""LAYOUTS"", ""c:\"") & """ & ot.name & "_" & lctl.name & """ For Output As #ff"
        body = body & vbCrLf & "    print #ff, " & lctl.name & ".PanelCustomisationString"
        body = body & vbCrLf & "    Close #ff"
        body = body & vbCrLf & "End Sub"

        tsInit = tsInit & vbCrLf & "  LoadBtnPictures cmd" & p.name & "Cfg,cmd" & p.name & "Cfg.tag"

        tsClick = tsClick & vbCrLf & "      " & lctl.name & ".Top = 40 * Screen.TwipsPerPixelX"
        tsClick = tsClick & vbCrLf & "      " & lctl.name & ".Left = 5 * Screen.TwipsPerPixelX"
        tsClick = tsClick & vbCrLf & "      " & lctl.name & ".Width = usercontrol.Width - 10 * Screen.TwipsPerPixelX"
        tsClick = tsClick & vbCrLf & "      " & lctl.name & ".Height = usercontrol.Height - 45 * Screen.TwipsPerPixelY"

        tsInit = tsInit & vbCrLf & "  dim ff as long, buf as string"
        tsInit = tsInit & vbCrLf & "  ff = FreeFile"
        tsInit = tsInit & vbCrLf & "  On Error Resume Next"
        tsInit = tsInit & vbCrLf & "  Open GetSetting(""MTZ"", ""CONFIG"", ""LAYOUTS"", ""c:\"") & """ & ot.name & "_" & lctl.name & """ For Input As #ff"
        tsInit = tsInit & vbCrLf & "  buf = """""
        tsInit = tsInit & vbCrLf & "  buf = Input(LOF(ff), ff)"
        tsInit = tsInit & vbCrLf & "  Close #ff"
        tsInit = tsInit & vbCrLf & "  if buf <>"""" then " & lctl.name & ".PanelCustomisationString = buf"
        tsInit = tsInit & vbCrLf & "  set " & lctl.name & ".Item = item"
        tsInit = tsInit & vbCrLf & "  " & lctl.name & ".InitPanel"

    End Sub
End Module