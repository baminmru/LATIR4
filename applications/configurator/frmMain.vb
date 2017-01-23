Imports Microsoft.Win32.Registry

Public Class frmMain
  Private colSite As New clsSite


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

#Region "Handling groub components -> Setting File Configuration"
    Private Sub btFileConfigSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFileConfigSite.Click
        If lblFileConfigSite.ForeColor = Color.Blue Then
            OpenFileDialog.FileName = tbFileConfigSite.Text
        End If
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            If colSite.formatFile(OpenFileDialog.FileName) Then
                tbFileConfigSite.Text = ""

                colSite.Clear()
                lstSite1.Items.Clear()
                tbFileConfigSite.Text = OpenFileDialog.FileName
                colSite.loadSites(tbFileConfigSite.Text)
                SaveSetting("LATIR4", "CFG", "FILE", OpenFileDialog.FileName)
            Else
                MsgBox("Файл имеет не правильный формат", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
            End If
        End If
    End Sub


#End Region
#Region "Handling SITE PAGE"
    Private Sub ctrlPageSite()
        If colSite.working Then
            gbServerDB.Enabled = True
            gbPrefixDB.Enabled = True

            pnlCtrlSite.Enabled = True
        Else
            gbServerDB.Enabled = False
            gbPrefixDB.Enabled = False

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
            .pathImage = ""
            .pathLayouts = ""
            .pathTemp = ""
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
        obj.pathImage = ""
        obj.pathLayouts = ""
        obj.pathTemp = ""
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
#Region "++++++++++++++++ LOAD & SAVE DATA CONFIGURATION ++++++++++++++++"
    Private Sub btSaveSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next

        SaveSetting(CRAppName, CRFileConfig, CRFileSite, tbFileConfigSite.Text)

    End Sub
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' загрузка значений по умолчанию

        tbFileConfigSite.Text = GetSetting("LATIR4", "CFG", "FILE", My.Application.Info.DirectoryPath & "\latir_sites.xml")


        ' загрузка Настроек Сайтов
        If Len(tbFileConfigSite.Text) > 0 Then colSite.loadSites(tbFileConfigSite.Text)
        loadListSite()


    End Sub
#End Region

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Application.Exit()
    End Sub


#Region "CREATE NEW FILES CONFIGURATION"
    Private Sub btCreateFileConfigSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim obj As New clsSite
            obj.createFile(SaveFileDialog.FileName)
            tbFileConfigSite.Text = SaveFileDialog.FileName
        End If
    End Sub

#End Region

    Private Sub TextChangedSite(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    tbNameSite.TextChanged, tbServerDB.TextChanged, tbOLEDBProvider.TextChanged,
    tbTime.TextChanged, chbNTsecurity.CheckedChanged, tbSQLpassword.TextChanged,
    chbARM.CheckedChanged, tbSQLuser.TextChanged, tbPrefixParam.TextChanged,
    tbPrefixFunction.TextChanged, tbPrefixSubType.TextChanged, tbPrefixSubKernel.TextChanged, tbNameDB.TextChanged
        btSaveSite.Enabled = True
    End Sub







End Class
