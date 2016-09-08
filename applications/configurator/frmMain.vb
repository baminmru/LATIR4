Imports Microsoft.Win32.Registry

Public Class frmMain
  Private colSite As New clsSite
  Private colServer As New clsServer

  Dim nSite, nServer As Integer, ld As Boolean

#Region "CONST REGISTR"
  'Private Const CRpath As String = "HKEY_CURRENT_USER\Software\"
  Private Const CRProjectName As String = "LATIR"
  Private Const CRAppName As String = "CONFIGURATOR"

  Private Const CRSectionDef As String = "DefaultValue"
  Private Const CRFolderPicture As String = "folderPicture"
  Private Const CRFolderLayouts As String = "folderLayouts"
  Private Const CRFolderTemp As String = "folderTemp"

  Private Const CRFileConfig As String = "FileConfig"
  Private Const CRFileSite As String = "fileSite"
  Private Const CRFileServer As String = "fileServer"

  Private Const CRSetingSystem As String = "SettingSystem"
  Private Const CRSettingForm As String = "settingForm"
  Private Const CRSettingJournal As String = "settingJournal"
  Private Const CRSettingPathProjects As String = "settingPathProjects"
  Private Const CROldVersion As String = "oldVersion"

  'Private Const C As String = ""
#End Region
#Region "Handling Folder"
  Private Sub btFolderDefClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
  btFolderDefPicture.Click, btFolderDefLayouts.Click, btFolderDefTemp.Click, btFolderProjects.Click, _
  btFolderPicture.Click, btFolderLayouts.Click, btFolderTemp.Click
        Dim out As TextBox
    Select Case sender.tag
      Case 1 : out = tbFolderDefPicture : FBD.Description = "Выберите папку с изображениями"
      Case 2 : out = tbFolderDefLayouts : FBD.Description = "Выберите папку для файлов с настройками форм"
      Case 3 : out = tbFolderDefTemp : FBD.Description = "Выберите папку для временных файлов"

      Case 4 : out = tbFolderProjects : FBD.Description = "Выберите папку проектов"

      Case 11 : out = tbFolderPicture : FBD.Description = "Выберите папку с изображениями"
      Case 12 : out = tbFolderLayouts : FBD.Description = "Выберите папку для файлов с настройками форм"
            Case Else : out = tbFolderTemp : FBD.Description = "Выберите папку для временных файлов"
        End Select

    If out.Text = "" Then FBD.SelectedPath = "c:\"
    If out.ForeColor = Color.Blue Then
      FBD.SelectedPath = out.Tag
    End If
    If FBD.ShowDialog = Windows.Forms.DialogResult.OK Then
      out.Text = FBD.SelectedPath
    End If
  End Sub

  Private Sub TextChangedFolderSetting(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
  tbFolderDefPicture.TextChanged, tbFolderDefLayouts.TextChanged, tbFolderDefTemp.TextChanged, _
  tbFolderProjects.TextChanged
    If System.IO.Directory.Exists(sender.Text) Then
      sender.ForeColor = Color.Blue
      sender.Tag = sender.Text
      If Microsoft.VisualBasic.Right(sender.Tag, 1) <> "\" Then
        sender.Tag = sender.Tag & "\"
        sender.text = sender.tag
      End If
    Else
      sender.ForeColor = Color.Red
      sender.Tag = ""
    End If
    btSaveSetting.Enabled = True
  End Sub
  Private Sub TextChangedFolderSite(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
  tbFolderPicture.TextChanged, tbFolderLayouts.TextChanged, tbFolderTemp.TextChanged
    If System.IO.Directory.Exists(sender.Text) Then
      sender.ForeColor = Color.Blue
      sender.Tag = sender.Text
      If Microsoft.VisualBasic.Right(sender.Tag, 1) <> "\" Then
        sender.Tag = sender.Tag & "\"
        sender.text = sender.tag
      End If
    Else
      sender.ForeColor = Color.Red
      sender.Tag = ""
    End If
    btSaveSite.Enabled = True
  End Sub
#End Region
#Region "Handling groub components -> Setting File Configuration"
  Private Sub btFileConfigSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFileConfigSite.Click
    If lblFileConfigSite.ForeColor = Color.Blue Then
      OpenFileDialog.FileName = tbFileConfigSite.Text
    End If
    If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
      If colSite.formatFile(OpenFileDialog.FileName) Then
        tbFileConfigSite.Text = ""
        tbFileConfigSite.Text = OpenFileDialog.FileName
      Else
        MsgBox("Файл имеет не правильный формат", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
      End If
    End If
  End Sub
  Private Sub btFileConfigServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFileConfigServer.Click
    If lblFileConfigServer.ForeColor = Color.Blue Then
      OpenFileDialog.FileName = tbFileConfigServer.Text
    End If
    If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
      If colServer.formatFile(OpenFileDialog.FileName) Then
        tbFileConfigServer.Text = ""
        tbFileConfigServer.Text = OpenFileDialog.FileName
      Else
        MsgBox("Файл имеет не правильный формат", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
      End If
    End If
  End Sub

  Private Sub tbFileConfigSite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbFileConfigSite.TextChanged
    If System.IO.File.Exists(tbFileConfigSite.Text) Then
      If colSite.formatFile(tbFileConfigSite.Text) Then
        lblFileConfigSite.ForeColor = Color.Blue
        btSaveSetting.Enabled = True
        colSite.loadSites(tbFileConfigSite.Text)
        loadListSite()
      End If
    Else
      lblFileConfigSite.ForeColor = Color.Red
    End If
  End Sub
  Private Sub tbFileConfigServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbFileConfigServer.TextChanged
    If System.IO.File.Exists(tbFileConfigServer.Text) Then
      lblFileConfigServer.ForeColor = Color.Blue
      btSaveSetting.Enabled = True
      colServer.loadServers(tbFileConfigServer.Text)
      loadListServer()
    Else
      lblFileConfigServer.ForeColor = Color.Red
    End If
  End Sub
#End Region
#Region "Handling SITE PAGE"
  Private Sub ctrlPageSite()
    If colSite.working Then
      gbServerDB.Enabled = True
      gbPrefixDB.Enabled = True
      gbFolder.Enabled = True
      pnlCtrlSite.Enabled = True
    Else
      gbServerDB.Enabled = False
      gbPrefixDB.Enabled = False
      gbFolder.Enabled = False
      pnlCtrlSite.Enabled = False
    End If
  End Sub
  Private Sub loadListSite()
    ctrlPageSite()
    If Not colSite.working Then Exit Sub
    lstSite1.Items.Clear()

    For i As Long = 1 To colSite.c.Count
      lstSite1.Items.Add(colSite.c.Item(i).name)
    Next

        btSaveSite.Enabled = False
        If colSite.c.Count > 0 Then
            lstSite1.SelectedIndex = nSite
        End If
        loadSite()
    End Sub
  Private Sub loadSite()
        nSite = lstSite1.SelectedIndex
        If nSite >= 0 Then
            Dim obj As clsPSite = colSite.c(nSite + 1)

            tbNameSite.Text = obj.name
            tbServerDB.Text = obj.serverDB
            tbNameDB.Text = obj.nameDB
            tbOLEDBProvider.Text = obj.nameProvider
            tbTime.Text = obj.time
            chbNTsecurity.Checked = obj.NTsecurity
            chbARM.Checked = obj.ARM
            tbSQLuser.Text = obj.SQLuser
            tbSQLpassword.Text = obj.SQLpassword
            tbPrefixParam.Text = obj.prfParam
            tbPrefixFunction.Text = obj.prfFunction
            tbPrefixSubType.Text = obj.prfSubType
            tbPrefixSubKernel.Text = obj.prfSubKernel
            tbFolderPicture.Text = obj.pathImage
            tbFolderLayouts.Text = obj.pathLayouts
            tbFolderTemp.Text = obj.pathTemp

            btSaveSite.Enabled = False
        End If
    End Sub
  Private Sub saveSite()
    With colSite.c(nSite + 1)
      .name = tbNameSite.Text
      .serverDB = tbServerDB.Text
      .nameDB = tbNameDB.Text
      .nameProvider = tbOLEDBProvider.Text
      .time = tbTime.Text
      .NTsecurity = chbNTsecurity.Checked
      .ARM = chbARM.Checked
      .SQLuser = tbSQLuser.Text
      .SQLpassword = tbSQLpassword.Text
      .prfParam = tbPrefixParam.Text
      .prfFunction = tbPrefixFunction.Text
      .prfSubType = tbPrefixSubType.Text
      .prfSubKernel = tbPrefixSubKernel.Text
            .pathImage = tbFolderPicture.Tag
      .pathLayouts = tbFolderLayouts.Tag
      .pathTemp = tbFolderTemp.Tag
    End With
    loadListSite()
  End Sub
  Private Sub lstSite1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSite1.SelectedIndexChanged
    If nSite <> lstSite1.SelectedIndex Then
      If btSaveSite.Enabled Then
        Dim bt As MsgBoxResult = MsgBox("Были изменены настройки сайта, сохранить???", MsgBoxStyle.YesNoCancel, "Конфигуратор системы")
        If bt = MsgBoxResult.Cancel Then
          lstSite1.SelectedIndex = nSite
          Exit Sub
        End If
        If bt = MsgBoxResult.Yes Then saveSite()
      End If
      loadSite()
    End If
  End Sub
  Private Sub btCreateSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreateSite.Click
    Dim obj As New clsPSite
    obj.name = "NEWSITE"
    obj.pathImage = tbFolderDefPicture.Tag
    obj.pathLayouts = tbFolderDefLayouts.Tag
    obj.pathTemp = tbFolderDefTemp.Tag
    colSite.c.Add(obj)
    obj = Nothing
    loadListSite()
    colSite.saveSites(tbFileConfigSite.Text)
  End Sub
  Private Sub btDeleteSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDeleteSite.Click
    colSite.c.Remove(nSite + 1)
    loadListSite()
    colSite.saveSites(tbFileConfigSite.Text)
  End Sub
  Private Sub btSaveSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveSite.Click
    saveSite()
    colSite.saveSites(tbFileConfigSite.Text)
  End Sub
#End Region
#Region "Handling SERVER"
  Private Sub ctrlPageServer()
    If colServer.working Then
      gb_ServerDB.Enabled = True
      gb_PrefixDB.Enabled = True
      pnlCtrlServer.Enabled = True
    Else
      gb_ServerDB.Enabled = False
      gb_PrefixDB.Enabled = False
      pnlCtrlServer.Enabled = False
    End If
  End Sub
  Private Sub loadListServer()
    cbServer.Items.Clear()
    ld = True
    cbServer.Items.Add("Не выбран")
    cbServer.SelectedItem = "Не выбран"

    ctrlPageServer()
    If Not colServer.working Then Exit Sub
    lstServer.Items.Clear()

    For i As Long = 1 To colServer.c.Count
      lstServer.Items.Add(colServer.c.Item(i).name)
      cbServer.Items.Add(colServer.c.Item(i).name)
    Next
    ld = False

        btSaveServer.Enabled = False
        If colServer.c.Count <> 0 Then
            lstServer.SelectedIndex = nServer
            loadServer()
        End If

    End Sub
  Private Sub loadServer()
    nServer = lstServer.SelectedIndex
    Dim obj As clsPServer = colServer.c(nServer + 1)

    tbNameServerDB.Text = obj.name
    tb_ServerDB.Text = obj.serverDB
    tb_OLEDBProvider.Text = obj.nameProvider
    tb_Time.Text = obj.time
    chb_NTsecurity.Checked = obj.NTsecurity
    chb_ARM.Checked = obj.ARM
    tb_SQLuser.Text = obj.SQLuser
    tb_SQLpassword.Text = obj.SQLpassword
    tb_prefixParam.Text = obj.prfParam
    tb_prefixFunction.Text = obj.prfFunction
    tb_prefixSubType.Text = obj.prfSubType
    tb_prefixSubKernel.Text = obj.prfSubKernel

    btSaveServer.Enabled = False
  End Sub
  Private Sub saveServer()
    With colServer.c(nServer + 1)
      .name = tbNameServerDB.Text
      .serverDB = tb_ServerDB.Text
      .nameProvider = tb_OLEDBProvider.Text
      .time = tb_Time.Text
      .NTsecurity = chb_NTsecurity.Checked
      .ARM = chb_ARM.Checked
      .SQLuser = tb_SQLuser.Text
      .SQLpassword = tb_SQLpassword.Text
      .prfParam = tb_prefixParam.Text
      .prfFunction = tb_prefixFunction.Text
      .prfSubType = tb_prefixSubType.Text
      .prfSubKernel = tb_prefixSubKernel.Text
    End With
    loadListServer()
  End Sub
  Private Sub lstServer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstServer.SelectedIndexChanged
    If nServer <> lstServer.SelectedIndex Then
      If btSaveServer.Enabled Then
        Dim bt As MsgBoxResult = MsgBox("Были изменены настройки сайта, сохранить???", MsgBoxStyle.YesNoCancel, "Конфигуратор системы")
        If bt = MsgBoxResult.Cancel Then
          lstServer.SelectedIndex = nServer
          Exit Sub
        End If
        If bt = MsgBoxResult.Yes Then saveServer()
      End If
      loadServer()
    End If
  End Sub
  Private Sub btCreateServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreateServer.Click
    Dim obj As New clsPServer
    obj.name = "NEWSERVER"
    colServer.c.Add(obj)
    obj = Nothing
    loadListServer()
    colServer.saveServers(tbFileConfigServer.Text)
  End Sub
  Private Sub btDeleteServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDeleteServer.Click
    colServer.c.Remove(nServer + 1)
    loadListServer()
    colServer.saveServers(tbFileConfigServer.Text)
  End Sub
  Private Sub btSaveServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveServer.Click
    saveServer()
    colServer.saveServers(tbFileConfigServer.Text)
  End Sub
#End Region
#Region "++++++++++++++++ LOAD & SAVE DATA CONFIGURATION ++++++++++++++++"
  Private Sub btSaveSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveSetting.Click
        On Error Resume Next
        SaveSetting(CRAppName, CRSectionDef, CRFolderPicture, tbFolderDefPicture.Tag)
    SaveSetting(CRAppName, CRSectionDef, CRFolderLayouts, tbFolderDefLayouts.Tag)
    SaveSetting(CRAppName, CRSectionDef, CRFolderTemp, tbFolderDefTemp.Tag)
    SaveSetting(CRAppName, CRSectionDef, CRSettingPathProjects, tbFolderProjects.Tag)

    SaveSetting(CRAppName, CRFileConfig, CRFileSite, tbFileConfigSite.Text)
    SaveSetting(CRAppName, CRFileConfig, CRFileServer, tbFileConfigServer.Text)

    SaveSetting(CRAppName, CRSetingSystem, CRSettingForm, chbSettingForm.Checked)
    SaveSetting(CRAppName, CRSetingSystem, CRSettingJournal, chbSettingJournal.Checked)
    SaveSetting(CRAppName, CRSetingSystem, CROldVersion, chbOldVersion.Checked)

    If chbOldVersion.Checked Then
      SaveSetting("MTZ", "CONFIG", "CFGFRM", chbSettingForm.Checked)
      SaveSetting("MTZ", "CONFIG", "CFGJRNL", chbSettingJournal.Checked)

      SaveSetting("MTZ", "CONFIG", "IMAGEPATH", tbFolderDefPicture.Tag)
      SaveSetting("MTZ", "CONFIG", "LAYOUTS", tbFolderDefLayouts.Tag)
      SaveSetting("MTZ", "CONFIG", "TEMPPATH", tbFolderDefTemp.Tag)
    End If

    btSaveSetting.Enabled = False

    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MTZ\CONFIG", "XMLPATH", tbFileConfigSite.Text, Microsoft.Win32.RegistryValueKind.String)
    'My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MTZ\CONFIG", "XMLPATH", tbFileConfigSite.Text)
  End Sub
  Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ' загрузка значений по умолчанию
    chbSettingForm.Checked = GetSetting(CRAppName, CRSetingSystem, CRSettingForm, "False")
    chbSettingJournal.Checked = GetSetting(CRAppName, CRSetingSystem, CRSettingJournal, "False")
        chbOldVersion.Checked = GetSetting(CRAppName, CRSetingSystem, CROldVersion, "False")

    tbFolderProjects.Text = GetSetting(CRAppName, CRSectionDef, CRSettingPathProjects, My.Application.Info.DirectoryPath & "\Projects\")

    tbFolderDefPicture.Text = GetSetting(CRAppName, CRSectionDef, CRFolderPicture, My.Application.Info.DirectoryPath & "\Images\")
    tbFolderDefLayouts.Text = GetSetting(CRAppName, CRSectionDef, CRFolderLayouts, My.Application.Info.DirectoryPath & "\Layouts\")
    tbFolderDefTemp.Text = GetSetting(CRAppName, CRSectionDef, CRFolderTemp, My.Application.Info.DirectoryPath & "\Temp\")

        tbFileConfigSite.Text = GetSetting(CRAppName, CRFileConfig, CRFileSite, My.Application.Info.DirectoryPath & "\latir_sites.xml")

    If chbOldVersion.Checked Then
      tbFolderDefPicture.Text = GetSetting("MTZ", "CONFIG", "IMAGEPATH", My.Application.Info.DirectoryPath & "\Images\")
      tbFolderDefLayouts.Text = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")
      tbFolderDefTemp.Text = GetSetting("MTZ", "CONFIG", "TEMPPATH", My.Application.Info.DirectoryPath & "\Temp\")
    End If

        tbFileConfigServer.Text = GetSetting(CRAppName, CRFileConfig, CRFileServer, My.Application.Info.DirectoryPath & "\Servers.xml")

    btSaveSetting.Enabled = False

    ' загрузка Настроек Сайтов
    If Len(tbFileConfigSite.Text) > 0 Then colSite.loadSites(tbFileConfigSite.Text)
    loadListSite()

    ' загрузка Настроек Серверов
    If Len(tbFileConfigServer.Text) > 0 Then colServer.loadServers(tbFileConfigServer.Text)
    loadListServer()
  End Sub
#End Region

  Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
    Application.Exit()
  End Sub

#Region "CREATE NEW FILES CONFIGURATION"
  Private Sub btCreateFileConfigSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreateFileConfigSite.Click
    If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim obj As New clsSite
      obj.createFile(SaveFileDialog.FileName)
      tbFileConfigSite.Text = SaveFileDialog.FileName
    End If
  End Sub
  Private Sub btCreateFileConfigServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreateFileConfigServer.Click
    If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim obj As New clsServer
      obj.createFile(SaveFileDialog.FileName)
      tbFileConfigServer.Text = SaveFileDialog.FileName
    End If
  End Sub
#End Region

    Private Sub TextChangedSite(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    tbNameSite.TextChanged, tbProject.TextChanged, tbServerDB.TextChanged, tbOLEDBProvider.TextChanged, _
    tbTime.TextChanged, chbNTsecurity.CheckedChanged, tbSQLpassword.TextChanged, _
    chbARM.CheckedChanged, tbSQLuser.TextChanged, tbPrefixParam.TextChanged, _
    tbPrefixFunction.TextChanged, tbPrefixSubType.TextChanged, tbPrefixSubKernel.TextChanged, tbNameDB.TextChanged
        btSaveSite.Enabled = True
    End Sub
  Private Sub TextChangedServer(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
  tbNameServerDB.TextChanged, tb_ServerDB.TextChanged, tb_OLEDBProvider.TextChanged, _
  tb_Time.TextChanged, chb_NTsecurity.CheckedChanged, tb_SQLpassword.TextChanged, _
  chb_ARM.CheckedChanged, tb_SQLuser.TextChanged, tb_prefixParam.TextChanged, _
  tb_prefixFunction.TextChanged, tb_prefixSubType.TextChanged, tb_prefixSubKernel.TextChanged
    btSaveServer.Enabled = True
  End Sub
  Private Sub CheckedChangedSetting(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
  chbSettingForm.CheckedChanged, chbSettingJournal.CheckedChanged, chbOldVersion.CheckedChanged
    btSaveSetting.Enabled = True
  End Sub

  Private Sub cbServer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbServer.SelectedIndexChanged
    If Not ld Then
      If MsgBox("Применить настройки сервера для сайта???", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, My.Application.Info.AssemblyName) = MsgBoxResult.Ok Then
        Dim n As Integer = cbServer.SelectedIndex
        Dim obj As clsPServer = colServer.c.Item(n)
        With colSite.c(nSite + 1)
          tbServerDB.Text = obj.serverDB
          tbOLEDBProvider.Text = obj.nameProvider
          tbTime.Text = obj.time
          chbNTsecurity.Checked = obj.NTsecurity
          chbARM.Checked = obj.ARM
          tbSQLuser.Text = obj.SQLuser
          tbSQLpassword.Text = obj.SQLpassword

          tbPrefixParam.Text = obj.prfParam
          tbPrefixFunction.Text = obj.prfFunction
          tbPrefixSubType.Text = obj.prfSubType
          tbPrefixSubKernel.Text = obj.prfSubKernel
        End With
        ld = True
        cbServer.SelectedItem = "Не выбран"
        ld = False
        lstSite1.SelectedIndex = nSite
      End If
    End If
  End Sub



#Region "LOAD VALUE PATH"
  Private Sub btLoadPathPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLoadPathPicture.Click
    tbFolderPicture.Text = tbFolderDefPicture.Tag
  End Sub
  Private Sub btLoadPathLayouts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLoadPathLayouts.Click
    tbFolderLayouts.Text = tbFolderDefLayouts.Tag
  End Sub
  Private Sub btLoadPathTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLoadPathTemp.Click
    tbFolderTemp.Text = tbFolderDefTemp.Tag
  End Sub
#End Region
End Class
