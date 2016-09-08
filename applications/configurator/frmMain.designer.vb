<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ImageList As System.Windows.Forms.ImageList
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btExit = New System.Windows.Forms.Button()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPageSite = New System.Windows.Forms.TabPage()
        Me.pnlDataSite = New System.Windows.Forms.Panel()
        Me.gbProject = New System.Windows.Forms.GroupBox()
        Me.tbProject = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.gbServerDB = New System.Windows.Forms.GroupBox()
        Me.chbARM = New System.Windows.Forms.CheckBox()
        Me.chbNTsecurity = New System.Windows.Forms.CheckBox()
        Me.cbServer = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbNameDB = New System.Windows.Forms.TextBox()
        Me.tbNameSite = New System.Windows.Forms.TextBox()
        Me.tbSQLpassword = New System.Windows.Forms.TextBox()
        Me.tbTime = New System.Windows.Forms.TextBox()
        Me.tbServerDB = New System.Windows.Forms.TextBox()
        Me.tbSQLuser = New System.Windows.Forms.TextBox()
        Me.tbOLEDBProvider = New System.Windows.Forms.TextBox()
        Me.gbPrefixDB = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbPrefixSubKernel = New System.Windows.Forms.TextBox()
        Me.tbPrefixSubType = New System.Windows.Forms.TextBox()
        Me.tbPrefixFunction = New System.Windows.Forms.TextBox()
        Me.tbPrefixParam = New System.Windows.Forms.TextBox()
        Me.pnlCtrlSite = New System.Windows.Forms.Panel()
        Me.btSaveSite = New System.Windows.Forms.Button()
        Me.btDeleteSite = New System.Windows.Forms.Button()
        Me.btCreateSite = New System.Windows.Forms.Button()
        Me.lstSite1 = New System.Windows.Forms.ListBox()
        Me.gbFolder = New System.Windows.Forms.GroupBox()
        Me.btLoadPathTemp = New System.Windows.Forms.Button()
        Me.btFolderTemp = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbFolderTemp = New System.Windows.Forms.TextBox()
        Me.btLoadPathLayouts = New System.Windows.Forms.Button()
        Me.btFolderLayouts = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFolderLayouts = New System.Windows.Forms.TextBox()
        Me.btLoadPathPicture = New System.Windows.Forms.Button()
        Me.btFolderPicture = New System.Windows.Forms.Button()
        Me.tbFolderPicture = New System.Windows.Forms.TextBox()
        Me.TabPageServer = New System.Windows.Forms.TabPage()
        Me.pnlCtrlServer = New System.Windows.Forms.Panel()
        Me.btSaveServer = New System.Windows.Forms.Button()
        Me.btDeleteServer = New System.Windows.Forms.Button()
        Me.btCreateServer = New System.Windows.Forms.Button()
        Me.lstServer = New System.Windows.Forms.ListBox()
        Me.gb_ServerDB = New System.Windows.Forms.GroupBox()
        Me.chb_ARM = New System.Windows.Forms.CheckBox()
        Me.chb_NTsecurity = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tbNameServerDB = New System.Windows.Forms.TextBox()
        Me.tb_SQLpassword = New System.Windows.Forms.TextBox()
        Me.tb_Time = New System.Windows.Forms.TextBox()
        Me.tb_SQLuser = New System.Windows.Forms.TextBox()
        Me.tb_ServerDB = New System.Windows.Forms.TextBox()
        Me.tb_OLEDBProvider = New System.Windows.Forms.TextBox()
        Me.gb_PrefixDB = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.tb_prefixSubKernel = New System.Windows.Forms.TextBox()
        Me.tb_prefixSubType = New System.Windows.Forms.TextBox()
        Me.tb_prefixFunction = New System.Windows.Forms.TextBox()
        Me.tb_prefixParam = New System.Windows.Forms.TextBox()
        Me.TabPageSystem = New System.Windows.Forms.TabPage()
        Me.btSaveSetting = New System.Windows.Forms.Button()
        Me.btCreateFileConfigSite = New System.Windows.Forms.Button()
        Me.gbSettingSystem = New System.Windows.Forms.GroupBox()
        Me.chbOldVersion = New System.Windows.Forms.CheckBox()
        Me.chbSettingJournal = New System.Windows.Forms.CheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.chbSettingForm = New System.Windows.Forms.CheckBox()
        Me.tbFolderProjects = New System.Windows.Forms.TextBox()
        Me.btFolderProjects = New System.Windows.Forms.Button()
        Me.gbFileConfig = New System.Windows.Forms.GroupBox()
        Me.lblFileConfigSite = New System.Windows.Forms.Label()
        Me.btFileConfigServer = New System.Windows.Forms.Button()
        Me.lblFileConfigServer = New System.Windows.Forms.Label()
        Me.tbFileConfigServer = New System.Windows.Forms.TextBox()
        Me.btFileConfigSite = New System.Windows.Forms.Button()
        Me.tbFileConfigSite = New System.Windows.Forms.TextBox()
        Me.gbSettingFolderApplication = New System.Windows.Forms.GroupBox()
        Me.btFolderDefTemp = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblFolderDefPicture = New System.Windows.Forms.Label()
        Me.tbFolderDefTemp = New System.Windows.Forms.TextBox()
        Me.btFolderDefLayouts = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.tbFolderDefLayouts = New System.Windows.Forms.TextBox()
        Me.btFolderDefPicture = New System.Windows.Forms.Button()
        Me.tbFolderDefPicture = New System.Windows.Forms.TextBox()
        Me.btCreateFileConfigServer = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.lstSite = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPageSite.SuspendLayout()
        Me.pnlDataSite.SuspendLayout()
        Me.gbProject.SuspendLayout()
        Me.gbServerDB.SuspendLayout()
        Me.gbPrefixDB.SuspendLayout()
        Me.pnlCtrlSite.SuspendLayout()
        Me.gbFolder.SuspendLayout()
        Me.TabPageServer.SuspendLayout()
        Me.pnlCtrlServer.SuspendLayout()
        Me.gb_ServerDB.SuspendLayout()
        Me.gb_PrefixDB.SuspendLayout()
        Me.TabPageSystem.SuspendLayout()
        Me.gbSettingSystem.SuspendLayout()
        Me.gbFileConfig.SuspendLayout()
        Me.gbSettingFolderApplication.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList
        '
        ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        ImageList.TransparentColor = System.Drawing.Color.Transparent
        ImageList.Images.SetKeyName(0, "Purple Folder XP.ico")
        ImageList.Images.SetKeyName(1, "Red Folder.ico")
        ImageList.Images.SetKeyName(2, "Contacts 2.ico")
        ImageList.Images.SetKeyName(3, "Control Panel 1.ico")
        ImageList.Images.SetKeyName(4, "ARW05LT.ICO")
        ImageList.Images.SetKeyName(5, "attach.png")
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'btExit
        '
        resources.ApplyResources(Me.btExit, "btExit")
        Me.btExit.Name = "btExit"
        Me.btExit.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPageSite)
        Me.TabControl.Controls.Add(Me.TabPageServer)
        Me.TabControl.Controls.Add(Me.TabPageSystem)
        resources.ApplyResources(Me.TabControl, "TabControl")
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        '
        'TabPageSite
        '
        Me.TabPageSite.AllowDrop = True
        Me.TabPageSite.Controls.Add(Me.pnlDataSite)
        Me.TabPageSite.Controls.Add(Me.pnlCtrlSite)
        Me.TabPageSite.Controls.Add(Me.gbFolder)
        resources.ApplyResources(Me.TabPageSite, "TabPageSite")
        Me.TabPageSite.Name = "TabPageSite"
        Me.TabPageSite.UseVisualStyleBackColor = True
        '
        'pnlDataSite
        '
        Me.pnlDataSite.Controls.Add(Me.gbProject)
        Me.pnlDataSite.Controls.Add(Me.gbServerDB)
        Me.pnlDataSite.Controls.Add(Me.gbPrefixDB)
        resources.ApplyResources(Me.pnlDataSite, "pnlDataSite")
        Me.pnlDataSite.Name = "pnlDataSite"
        '
        'gbProject
        '
        Me.gbProject.Controls.Add(Me.tbProject)
        Me.gbProject.Controls.Add(Me.Label20)
        resources.ApplyResources(Me.gbProject, "gbProject")
        Me.gbProject.Name = "gbProject"
        Me.gbProject.TabStop = False
        '
        'tbProject
        '
        resources.ApplyResources(Me.tbProject, "tbProject")
        Me.tbProject.Name = "tbProject"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.Name = "Label20"
        '
        'gbServerDB
        '
        Me.gbServerDB.Controls.Add(Me.chbARM)
        Me.gbServerDB.Controls.Add(Me.chbNTsecurity)
        Me.gbServerDB.Controls.Add(Me.cbServer)
        Me.gbServerDB.Controls.Add(Me.Label8)
        Me.gbServerDB.Controls.Add(Me.Label14)
        Me.gbServerDB.Controls.Add(Me.Label18)
        Me.gbServerDB.Controls.Add(Me.Label12)
        Me.gbServerDB.Controls.Add(Me.Label15)
        Me.gbServerDB.Controls.Add(Me.Label11)
        Me.gbServerDB.Controls.Add(Me.Label9)
        Me.gbServerDB.Controls.Add(Me.Label10)
        Me.gbServerDB.Controls.Add(Me.tbNameDB)
        Me.gbServerDB.Controls.Add(Me.tbNameSite)
        Me.gbServerDB.Controls.Add(Me.tbSQLpassword)
        Me.gbServerDB.Controls.Add(Me.tbTime)
        Me.gbServerDB.Controls.Add(Me.tbServerDB)
        Me.gbServerDB.Controls.Add(Me.tbSQLuser)
        Me.gbServerDB.Controls.Add(Me.tbOLEDBProvider)
        resources.ApplyResources(Me.gbServerDB, "gbServerDB")
        Me.gbServerDB.Name = "gbServerDB"
        Me.gbServerDB.TabStop = False
        '
        'chbARM
        '
        resources.ApplyResources(Me.chbARM, "chbARM")
        Me.chbARM.Name = "chbARM"
        Me.chbARM.UseVisualStyleBackColor = True
        '
        'chbNTsecurity
        '
        resources.ApplyResources(Me.chbNTsecurity, "chbNTsecurity")
        Me.chbNTsecurity.Name = "chbNTsecurity"
        Me.chbNTsecurity.UseVisualStyleBackColor = True
        '
        'cbServer
        '
        resources.ApplyResources(Me.cbServer, "cbServer")
        Me.cbServer.Name = "cbServer"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'tbNameDB
        '
        resources.ApplyResources(Me.tbNameDB, "tbNameDB")
        Me.tbNameDB.Name = "tbNameDB"
        '
        'tbNameSite
        '
        resources.ApplyResources(Me.tbNameSite, "tbNameSite")
        Me.tbNameSite.Name = "tbNameSite"
        '
        'tbSQLpassword
        '
        resources.ApplyResources(Me.tbSQLpassword, "tbSQLpassword")
        Me.tbSQLpassword.Name = "tbSQLpassword"
        '
        'tbTime
        '
        resources.ApplyResources(Me.tbTime, "tbTime")
        Me.tbTime.Name = "tbTime"
        '
        'tbServerDB
        '
        resources.ApplyResources(Me.tbServerDB, "tbServerDB")
        Me.tbServerDB.Name = "tbServerDB"
        '
        'tbSQLuser
        '
        resources.ApplyResources(Me.tbSQLuser, "tbSQLuser")
        Me.tbSQLuser.Name = "tbSQLuser"
        '
        'tbOLEDBProvider
        '
        resources.ApplyResources(Me.tbOLEDBProvider, "tbOLEDBProvider")
        Me.tbOLEDBProvider.Name = "tbOLEDBProvider"
        '
        'gbPrefixDB
        '
        Me.gbPrefixDB.Controls.Add(Me.Label7)
        Me.gbPrefixDB.Controls.Add(Me.Label6)
        Me.gbPrefixDB.Controls.Add(Me.Label4)
        Me.gbPrefixDB.Controls.Add(Me.Label3)
        Me.gbPrefixDB.Controls.Add(Me.tbPrefixSubKernel)
        Me.gbPrefixDB.Controls.Add(Me.tbPrefixSubType)
        Me.gbPrefixDB.Controls.Add(Me.tbPrefixFunction)
        Me.gbPrefixDB.Controls.Add(Me.tbPrefixParam)
        resources.ApplyResources(Me.gbPrefixDB, "gbPrefixDB")
        Me.gbPrefixDB.Name = "gbPrefixDB"
        Me.gbPrefixDB.TabStop = False
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'tbPrefixSubKernel
        '
        resources.ApplyResources(Me.tbPrefixSubKernel, "tbPrefixSubKernel")
        Me.tbPrefixSubKernel.Name = "tbPrefixSubKernel"
        '
        'tbPrefixSubType
        '
        resources.ApplyResources(Me.tbPrefixSubType, "tbPrefixSubType")
        Me.tbPrefixSubType.Name = "tbPrefixSubType"
        '
        'tbPrefixFunction
        '
        resources.ApplyResources(Me.tbPrefixFunction, "tbPrefixFunction")
        Me.tbPrefixFunction.Name = "tbPrefixFunction"
        '
        'tbPrefixParam
        '
        resources.ApplyResources(Me.tbPrefixParam, "tbPrefixParam")
        Me.tbPrefixParam.Name = "tbPrefixParam"
        '
        'pnlCtrlSite
        '
        Me.pnlCtrlSite.Controls.Add(Me.btSaveSite)
        Me.pnlCtrlSite.Controls.Add(Me.btDeleteSite)
        Me.pnlCtrlSite.Controls.Add(Me.btCreateSite)
        Me.pnlCtrlSite.Controls.Add(Me.lstSite1)
        resources.ApplyResources(Me.pnlCtrlSite, "pnlCtrlSite")
        Me.pnlCtrlSite.Name = "pnlCtrlSite"
        '
        'btSaveSite
        '
        resources.ApplyResources(Me.btSaveSite, "btSaveSite")
        Me.btSaveSite.Name = "btSaveSite"
        Me.btSaveSite.UseVisualStyleBackColor = True
        '
        'btDeleteSite
        '
        resources.ApplyResources(Me.btDeleteSite, "btDeleteSite")
        Me.btDeleteSite.Name = "btDeleteSite"
        Me.btDeleteSite.UseVisualStyleBackColor = True
        '
        'btCreateSite
        '
        resources.ApplyResources(Me.btCreateSite, "btCreateSite")
        Me.btCreateSite.Name = "btCreateSite"
        Me.btCreateSite.UseVisualStyleBackColor = True
        '
        'lstSite1
        '
        resources.ApplyResources(Me.lstSite1, "lstSite1")
        Me.lstSite1.FormattingEnabled = True
        Me.lstSite1.Name = "lstSite1"
        '
        'gbFolder
        '
        Me.gbFolder.Controls.Add(Me.btLoadPathTemp)
        Me.gbFolder.Controls.Add(Me.btFolderTemp)
        Me.gbFolder.Controls.Add(Me.Label5)
        Me.gbFolder.Controls.Add(Me.Label1)
        Me.gbFolder.Controls.Add(Me.tbFolderTemp)
        Me.gbFolder.Controls.Add(Me.btLoadPathLayouts)
        Me.gbFolder.Controls.Add(Me.btFolderLayouts)
        Me.gbFolder.Controls.Add(Me.Label2)
        Me.gbFolder.Controls.Add(Me.tbFolderLayouts)
        Me.gbFolder.Controls.Add(Me.btLoadPathPicture)
        Me.gbFolder.Controls.Add(Me.btFolderPicture)
        Me.gbFolder.Controls.Add(Me.tbFolderPicture)
        resources.ApplyResources(Me.gbFolder, "gbFolder")
        Me.gbFolder.Name = "gbFolder"
        Me.gbFolder.TabStop = False
        '
        'btLoadPathTemp
        '
        resources.ApplyResources(Me.btLoadPathTemp, "btLoadPathTemp")
        Me.btLoadPathTemp.ImageList = ImageList
        Me.btLoadPathTemp.Name = "btLoadPathTemp"
        Me.btLoadPathTemp.UseVisualStyleBackColor = True
        '
        'btFolderTemp
        '
        resources.ApplyResources(Me.btFolderTemp, "btFolderTemp")
        Me.btFolderTemp.ImageList = ImageList
        Me.btFolderTemp.Name = "btFolderTemp"
        Me.btFolderTemp.Tag = "13"
        Me.btFolderTemp.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'tbFolderTemp
        '
        resources.ApplyResources(Me.tbFolderTemp, "tbFolderTemp")
        Me.tbFolderTemp.Name = "tbFolderTemp"
        '
        'btLoadPathLayouts
        '
        resources.ApplyResources(Me.btLoadPathLayouts, "btLoadPathLayouts")
        Me.btLoadPathLayouts.ImageList = ImageList
        Me.btLoadPathLayouts.Name = "btLoadPathLayouts"
        Me.btLoadPathLayouts.UseVisualStyleBackColor = True
        '
        'btFolderLayouts
        '
        resources.ApplyResources(Me.btFolderLayouts, "btFolderLayouts")
        Me.btFolderLayouts.ImageList = ImageList
        Me.btFolderLayouts.Name = "btFolderLayouts"
        Me.btFolderLayouts.Tag = "12"
        Me.btFolderLayouts.UseVisualStyleBackColor = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'tbFolderLayouts
        '
        resources.ApplyResources(Me.tbFolderLayouts, "tbFolderLayouts")
        Me.tbFolderLayouts.Name = "tbFolderLayouts"
        '
        'btLoadPathPicture
        '
        resources.ApplyResources(Me.btLoadPathPicture, "btLoadPathPicture")
        Me.btLoadPathPicture.ImageList = ImageList
        Me.btLoadPathPicture.Name = "btLoadPathPicture"
        Me.btLoadPathPicture.UseVisualStyleBackColor = True
        '
        'btFolderPicture
        '
        resources.ApplyResources(Me.btFolderPicture, "btFolderPicture")
        Me.btFolderPicture.ImageList = ImageList
        Me.btFolderPicture.Name = "btFolderPicture"
        Me.btFolderPicture.Tag = "11"
        Me.btFolderPicture.UseVisualStyleBackColor = True
        '
        'tbFolderPicture
        '
        resources.ApplyResources(Me.tbFolderPicture, "tbFolderPicture")
        Me.tbFolderPicture.Name = "tbFolderPicture"
        '
        'TabPageServer
        '
        Me.TabPageServer.Controls.Add(Me.pnlCtrlServer)
        Me.TabPageServer.Controls.Add(Me.gb_ServerDB)
        Me.TabPageServer.Controls.Add(Me.gb_PrefixDB)
        resources.ApplyResources(Me.TabPageServer, "TabPageServer")
        Me.TabPageServer.Name = "TabPageServer"
        Me.TabPageServer.UseVisualStyleBackColor = True
        '
        'pnlCtrlServer
        '
        Me.pnlCtrlServer.Controls.Add(Me.btSaveServer)
        Me.pnlCtrlServer.Controls.Add(Me.btDeleteServer)
        Me.pnlCtrlServer.Controls.Add(Me.btCreateServer)
        Me.pnlCtrlServer.Controls.Add(Me.lstServer)
        resources.ApplyResources(Me.pnlCtrlServer, "pnlCtrlServer")
        Me.pnlCtrlServer.Name = "pnlCtrlServer"
        '
        'btSaveServer
        '
        resources.ApplyResources(Me.btSaveServer, "btSaveServer")
        Me.btSaveServer.Name = "btSaveServer"
        Me.btSaveServer.UseVisualStyleBackColor = True
        '
        'btDeleteServer
        '
        resources.ApplyResources(Me.btDeleteServer, "btDeleteServer")
        Me.btDeleteServer.Name = "btDeleteServer"
        Me.btDeleteServer.UseVisualStyleBackColor = True
        '
        'btCreateServer
        '
        resources.ApplyResources(Me.btCreateServer, "btCreateServer")
        Me.btCreateServer.Name = "btCreateServer"
        Me.btCreateServer.UseVisualStyleBackColor = True
        '
        'lstServer
        '
        resources.ApplyResources(Me.lstServer, "lstServer")
        Me.lstServer.FormattingEnabled = True
        Me.lstServer.Name = "lstServer"
        '
        'gb_ServerDB
        '
        Me.gb_ServerDB.Controls.Add(Me.chb_ARM)
        Me.gb_ServerDB.Controls.Add(Me.chb_NTsecurity)
        Me.gb_ServerDB.Controls.Add(Me.Label21)
        Me.gb_ServerDB.Controls.Add(Me.Label23)
        Me.gb_ServerDB.Controls.Add(Me.Label24)
        Me.gb_ServerDB.Controls.Add(Me.Label25)
        Me.gb_ServerDB.Controls.Add(Me.Label19)
        Me.gb_ServerDB.Controls.Add(Me.Label26)
        Me.gb_ServerDB.Controls.Add(Me.tbNameServerDB)
        Me.gb_ServerDB.Controls.Add(Me.tb_SQLpassword)
        Me.gb_ServerDB.Controls.Add(Me.tb_Time)
        Me.gb_ServerDB.Controls.Add(Me.tb_SQLuser)
        Me.gb_ServerDB.Controls.Add(Me.tb_ServerDB)
        Me.gb_ServerDB.Controls.Add(Me.tb_OLEDBProvider)
        resources.ApplyResources(Me.gb_ServerDB, "gb_ServerDB")
        Me.gb_ServerDB.Name = "gb_ServerDB"
        Me.gb_ServerDB.TabStop = False
        '
        'chb_ARM
        '
        resources.ApplyResources(Me.chb_ARM, "chb_ARM")
        Me.chb_ARM.Name = "chb_ARM"
        Me.chb_ARM.UseVisualStyleBackColor = True
        '
        'chb_NTsecurity
        '
        resources.ApplyResources(Me.chb_NTsecurity, "chb_NTsecurity")
        Me.chb_NTsecurity.Name = "chb_NTsecurity"
        Me.chb_NTsecurity.UseVisualStyleBackColor = True
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.Name = "Label21"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.Name = "Label23"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.Name = "Label24"
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.Name = "Label25"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.Name = "Label19"
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.Name = "Label26"
        '
        'tbNameServerDB
        '
        resources.ApplyResources(Me.tbNameServerDB, "tbNameServerDB")
        Me.tbNameServerDB.Name = "tbNameServerDB"
        '
        'tb_SQLpassword
        '
        resources.ApplyResources(Me.tb_SQLpassword, "tb_SQLpassword")
        Me.tb_SQLpassword.Name = "tb_SQLpassword"
        '
        'tb_Time
        '
        resources.ApplyResources(Me.tb_Time, "tb_Time")
        Me.tb_Time.Name = "tb_Time"
        '
        'tb_SQLuser
        '
        resources.ApplyResources(Me.tb_SQLuser, "tb_SQLuser")
        Me.tb_SQLuser.Name = "tb_SQLuser"
        '
        'tb_ServerDB
        '
        resources.ApplyResources(Me.tb_ServerDB, "tb_ServerDB")
        Me.tb_ServerDB.Name = "tb_ServerDB"
        '
        'tb_OLEDBProvider
        '
        resources.ApplyResources(Me.tb_OLEDBProvider, "tb_OLEDBProvider")
        Me.tb_OLEDBProvider.Name = "tb_OLEDBProvider"
        '
        'gb_PrefixDB
        '
        Me.gb_PrefixDB.Controls.Add(Me.Label28)
        Me.gb_PrefixDB.Controls.Add(Me.Label29)
        Me.gb_PrefixDB.Controls.Add(Me.Label30)
        Me.gb_PrefixDB.Controls.Add(Me.Label31)
        Me.gb_PrefixDB.Controls.Add(Me.tb_prefixSubKernel)
        Me.gb_PrefixDB.Controls.Add(Me.tb_prefixSubType)
        Me.gb_PrefixDB.Controls.Add(Me.tb_prefixFunction)
        Me.gb_PrefixDB.Controls.Add(Me.tb_prefixParam)
        resources.ApplyResources(Me.gb_PrefixDB, "gb_PrefixDB")
        Me.gb_PrefixDB.Name = "gb_PrefixDB"
        Me.gb_PrefixDB.TabStop = False
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.Name = "Label28"
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.Name = "Label29"
        '
        'Label30
        '
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.Name = "Label30"
        '
        'Label31
        '
        resources.ApplyResources(Me.Label31, "Label31")
        Me.Label31.Name = "Label31"
        '
        'tb_prefixSubKernel
        '
        resources.ApplyResources(Me.tb_prefixSubKernel, "tb_prefixSubKernel")
        Me.tb_prefixSubKernel.Name = "tb_prefixSubKernel"
        '
        'tb_prefixSubType
        '
        resources.ApplyResources(Me.tb_prefixSubType, "tb_prefixSubType")
        Me.tb_prefixSubType.Name = "tb_prefixSubType"
        '
        'tb_prefixFunction
        '
        resources.ApplyResources(Me.tb_prefixFunction, "tb_prefixFunction")
        Me.tb_prefixFunction.Name = "tb_prefixFunction"
        '
        'tb_prefixParam
        '
        resources.ApplyResources(Me.tb_prefixParam, "tb_prefixParam")
        Me.tb_prefixParam.Name = "tb_prefixParam"
        '
        'TabPageSystem
        '
        Me.TabPageSystem.Controls.Add(Me.btSaveSetting)
        Me.TabPageSystem.Controls.Add(Me.btCreateFileConfigSite)
        Me.TabPageSystem.Controls.Add(Me.gbSettingSystem)
        Me.TabPageSystem.Controls.Add(Me.gbFileConfig)
        Me.TabPageSystem.Controls.Add(Me.gbSettingFolderApplication)
        Me.TabPageSystem.Controls.Add(Me.btCreateFileConfigServer)
        resources.ApplyResources(Me.TabPageSystem, "TabPageSystem")
        Me.TabPageSystem.Name = "TabPageSystem"
        Me.TabPageSystem.UseVisualStyleBackColor = True
        '
        'btSaveSetting
        '
        resources.ApplyResources(Me.btSaveSetting, "btSaveSetting")
        Me.btSaveSetting.Name = "btSaveSetting"
        Me.btSaveSetting.UseVisualStyleBackColor = True
        '
        'btCreateFileConfigSite
        '
        resources.ApplyResources(Me.btCreateFileConfigSite, "btCreateFileConfigSite")
        Me.btCreateFileConfigSite.Name = "btCreateFileConfigSite"
        Me.btCreateFileConfigSite.UseVisualStyleBackColor = True
        '
        'gbSettingSystem
        '
        Me.gbSettingSystem.Controls.Add(Me.chbOldVersion)
        Me.gbSettingSystem.Controls.Add(Me.chbSettingJournal)
        Me.gbSettingSystem.Controls.Add(Me.Label27)
        Me.gbSettingSystem.Controls.Add(Me.chbSettingForm)
        Me.gbSettingSystem.Controls.Add(Me.tbFolderProjects)
        Me.gbSettingSystem.Controls.Add(Me.btFolderProjects)
        resources.ApplyResources(Me.gbSettingSystem, "gbSettingSystem")
        Me.gbSettingSystem.Name = "gbSettingSystem"
        Me.gbSettingSystem.TabStop = False
        '
        'chbOldVersion
        '
        resources.ApplyResources(Me.chbOldVersion, "chbOldVersion")
        Me.chbOldVersion.Name = "chbOldVersion"
        Me.chbOldVersion.UseVisualStyleBackColor = True
        '
        'chbSettingJournal
        '
        resources.ApplyResources(Me.chbSettingJournal, "chbSettingJournal")
        Me.chbSettingJournal.Name = "chbSettingJournal"
        Me.chbSettingJournal.UseVisualStyleBackColor = True
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.Name = "Label27"
        '
        'chbSettingForm
        '
        resources.ApplyResources(Me.chbSettingForm, "chbSettingForm")
        Me.chbSettingForm.Name = "chbSettingForm"
        Me.chbSettingForm.UseVisualStyleBackColor = True
        '
        'tbFolderProjects
        '
        resources.ApplyResources(Me.tbFolderProjects, "tbFolderProjects")
        Me.tbFolderProjects.Name = "tbFolderProjects"
        '
        'btFolderProjects
        '
        resources.ApplyResources(Me.btFolderProjects, "btFolderProjects")
        Me.btFolderProjects.ImageList = ImageList
        Me.btFolderProjects.Name = "btFolderProjects"
        Me.btFolderProjects.Tag = "4"
        Me.btFolderProjects.UseVisualStyleBackColor = True
        '
        'gbFileConfig
        '
        Me.gbFileConfig.Controls.Add(Me.lblFileConfigSite)
        Me.gbFileConfig.Controls.Add(Me.btFileConfigServer)
        Me.gbFileConfig.Controls.Add(Me.lblFileConfigServer)
        Me.gbFileConfig.Controls.Add(Me.tbFileConfigServer)
        Me.gbFileConfig.Controls.Add(Me.btFileConfigSite)
        Me.gbFileConfig.Controls.Add(Me.tbFileConfigSite)
        resources.ApplyResources(Me.gbFileConfig, "gbFileConfig")
        Me.gbFileConfig.Name = "gbFileConfig"
        Me.gbFileConfig.TabStop = False
        '
        'lblFileConfigSite
        '
        resources.ApplyResources(Me.lblFileConfigSite, "lblFileConfigSite")
        Me.lblFileConfigSite.Name = "lblFileConfigSite"
        '
        'btFileConfigServer
        '
        resources.ApplyResources(Me.btFileConfigServer, "btFileConfigServer")
        Me.btFileConfigServer.ImageList = ImageList
        Me.btFileConfigServer.Name = "btFileConfigServer"
        Me.btFileConfigServer.UseVisualStyleBackColor = True
        '
        'lblFileConfigServer
        '
        resources.ApplyResources(Me.lblFileConfigServer, "lblFileConfigServer")
        Me.lblFileConfigServer.Name = "lblFileConfigServer"
        '
        'tbFileConfigServer
        '
        resources.ApplyResources(Me.tbFileConfigServer, "tbFileConfigServer")
        Me.tbFileConfigServer.Name = "tbFileConfigServer"
        Me.tbFileConfigServer.ReadOnly = True
        '
        'btFileConfigSite
        '
        resources.ApplyResources(Me.btFileConfigSite, "btFileConfigSite")
        Me.btFileConfigSite.ImageList = ImageList
        Me.btFileConfigSite.Name = "btFileConfigSite"
        Me.btFileConfigSite.UseVisualStyleBackColor = True
        '
        'tbFileConfigSite
        '
        Me.tbFileConfigSite.AcceptsTab = True
        resources.ApplyResources(Me.tbFileConfigSite, "tbFileConfigSite")
        Me.tbFileConfigSite.Name = "tbFileConfigSite"
        Me.tbFileConfigSite.ReadOnly = True
        '
        'gbSettingFolderApplication
        '
        Me.gbSettingFolderApplication.Controls.Add(Me.btFolderDefTemp)
        Me.gbSettingFolderApplication.Controls.Add(Me.Label22)
        Me.gbSettingFolderApplication.Controls.Add(Me.lblFolderDefPicture)
        Me.gbSettingFolderApplication.Controls.Add(Me.tbFolderDefTemp)
        Me.gbSettingFolderApplication.Controls.Add(Me.btFolderDefLayouts)
        Me.gbSettingFolderApplication.Controls.Add(Me.Label32)
        Me.gbSettingFolderApplication.Controls.Add(Me.tbFolderDefLayouts)
        Me.gbSettingFolderApplication.Controls.Add(Me.btFolderDefPicture)
        Me.gbSettingFolderApplication.Controls.Add(Me.tbFolderDefPicture)
        resources.ApplyResources(Me.gbSettingFolderApplication, "gbSettingFolderApplication")
        Me.gbSettingFolderApplication.Name = "gbSettingFolderApplication"
        Me.gbSettingFolderApplication.TabStop = False
        '
        'btFolderDefTemp
        '
        resources.ApplyResources(Me.btFolderDefTemp, "btFolderDefTemp")
        Me.btFolderDefTemp.ImageList = ImageList
        Me.btFolderDefTemp.Name = "btFolderDefTemp"
        Me.btFolderDefTemp.Tag = "3"
        Me.btFolderDefTemp.UseVisualStyleBackColor = True
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.Name = "Label22"
        '
        'lblFolderDefPicture
        '
        resources.ApplyResources(Me.lblFolderDefPicture, "lblFolderDefPicture")
        Me.lblFolderDefPicture.Name = "lblFolderDefPicture"
        '
        'tbFolderDefTemp
        '
        resources.ApplyResources(Me.tbFolderDefTemp, "tbFolderDefTemp")
        Me.tbFolderDefTemp.Name = "tbFolderDefTemp"
        '
        'btFolderDefLayouts
        '
        resources.ApplyResources(Me.btFolderDefLayouts, "btFolderDefLayouts")
        Me.btFolderDefLayouts.ImageList = ImageList
        Me.btFolderDefLayouts.Name = "btFolderDefLayouts"
        Me.btFolderDefLayouts.Tag = "2"
        Me.btFolderDefLayouts.UseVisualStyleBackColor = True
        '
        'Label32
        '
        resources.ApplyResources(Me.Label32, "Label32")
        Me.Label32.Name = "Label32"
        '
        'tbFolderDefLayouts
        '
        resources.ApplyResources(Me.tbFolderDefLayouts, "tbFolderDefLayouts")
        Me.tbFolderDefLayouts.Name = "tbFolderDefLayouts"
        '
        'btFolderDefPicture
        '
        resources.ApplyResources(Me.btFolderDefPicture, "btFolderDefPicture")
        Me.btFolderDefPicture.ImageList = ImageList
        Me.btFolderDefPicture.Name = "btFolderDefPicture"
        Me.btFolderDefPicture.Tag = "1"
        Me.btFolderDefPicture.UseVisualStyleBackColor = True
        '
        'tbFolderDefPicture
        '
        resources.ApplyResources(Me.tbFolderDefPicture, "tbFolderDefPicture")
        Me.tbFolderDefPicture.Name = "tbFolderDefPicture"
        '
        'btCreateFileConfigServer
        '
        resources.ApplyResources(Me.btCreateFileConfigServer, "btCreateFileConfigServer")
        Me.btCreateFileConfigServer.Name = "btCreateFileConfigServer"
        Me.btCreateFileConfigServer.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        resources.ApplyResources(Me.OpenFileDialog, "OpenFileDialog")
        '
        'SaveFileDialog
        '
        resources.ApplyResources(Me.SaveFileDialog, "SaveFileDialog")
        '
        'lstSite
        '
        resources.ApplyResources(Me.lstSite, "lstSite")
        Me.lstSite.FormattingEnabled = True
        Me.lstSite.Name = "lstSite"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'TextBox11
        '
        resources.ApplyResources(Me.TextBox11, "TextBox11")
        Me.TextBox11.Name = "TextBox11"
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'TextBox13
        '
        resources.ApplyResources(Me.TextBox13, "TextBox13")
        Me.TextBox13.Name = "TextBox13"
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox14
        '
        resources.ApplyResources(Me.TextBox14, "TextBox14")
        Me.TextBox14.Name = "TextBox14"
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btExit)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.TabPageSite.ResumeLayout(False)
        Me.pnlDataSite.ResumeLayout(False)
        Me.gbProject.ResumeLayout(False)
        Me.gbProject.PerformLayout()
        Me.gbServerDB.ResumeLayout(False)
        Me.gbServerDB.PerformLayout()
        Me.gbPrefixDB.ResumeLayout(False)
        Me.gbPrefixDB.PerformLayout()
        Me.pnlCtrlSite.ResumeLayout(False)
        Me.gbFolder.ResumeLayout(False)
        Me.gbFolder.PerformLayout()
        Me.TabPageServer.ResumeLayout(False)
        Me.pnlCtrlServer.ResumeLayout(False)
        Me.gb_ServerDB.ResumeLayout(False)
        Me.gb_ServerDB.PerformLayout()
        Me.gb_PrefixDB.ResumeLayout(False)
        Me.gb_PrefixDB.PerformLayout()
        Me.TabPageSystem.ResumeLayout(False)
        Me.gbSettingSystem.ResumeLayout(False)
        Me.gbSettingSystem.PerformLayout()
        Me.gbFileConfig.ResumeLayout(False)
        Me.gbFileConfig.PerformLayout()
        Me.gbSettingFolderApplication.ResumeLayout(False)
        Me.gbSettingFolderApplication.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
  Friend WithEvents btExit As System.Windows.Forms.Button
  Friend WithEvents TabControl As System.Windows.Forms.TabControl
  Friend WithEvents TabPageServer As System.Windows.Forms.TabPage
  Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
  Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
  Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
  Friend WithEvents TabPageSite As System.Windows.Forms.TabPage
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents lstSite As System.Windows.Forms.ListBox
  Friend WithEvents gbFolder As System.Windows.Forms.GroupBox
  Friend WithEvents btFolderTemp As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents tbFolderTemp As System.Windows.Forms.TextBox
  Friend WithEvents btFolderLayouts As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents tbFolderLayouts As System.Windows.Forms.TextBox
  Friend WithEvents btFolderPicture As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents tbFolderPicture As System.Windows.Forms.TextBox
  Friend WithEvents pnlCtrlSite As System.Windows.Forms.Panel
  Friend WithEvents btDeleteSite As System.Windows.Forms.Button
  Friend WithEvents btCreateSite As System.Windows.Forms.Button
  Friend WithEvents lstSite1 As System.Windows.Forms.ListBox
  Friend WithEvents pnlDataSite As System.Windows.Forms.Panel
  Friend WithEvents gbServerDB As System.Windows.Forms.GroupBox
  Friend WithEvents gbPrefixDB As System.Windows.Forms.GroupBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents tbPrefixSubKernel As System.Windows.Forms.TextBox
  Friend WithEvents tbPrefixSubType As System.Windows.Forms.TextBox
  Friend WithEvents tbPrefixFunction As System.Windows.Forms.TextBox
  Friend WithEvents tbPrefixParam As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents tbServerDB As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents tbNameDB As System.Windows.Forms.TextBox
  Friend WithEvents tbOLEDBProvider As System.Windows.Forms.TextBox
  Friend WithEvents cbServer As System.Windows.Forms.ComboBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents tbTime As System.Windows.Forms.TextBox
  Friend WithEvents chbARM As System.Windows.Forms.CheckBox
  Friend WithEvents chbNTsecurity As System.Windows.Forms.CheckBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents tbSQLpassword As System.Windows.Forms.TextBox
  Friend WithEvents tbSQLuser As System.Windows.Forms.TextBox
  Friend WithEvents gb_ServerDB As System.Windows.Forms.GroupBox
  Friend WithEvents chb_ARM As System.Windows.Forms.CheckBox
  Friend WithEvents chb_NTsecurity As System.Windows.Forms.CheckBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents tbNameServerDB As System.Windows.Forms.TextBox
  Friend WithEvents tb_SQLpassword As System.Windows.Forms.TextBox
  Friend WithEvents tb_Time As System.Windows.Forms.TextBox
  Friend WithEvents tb_SQLuser As System.Windows.Forms.TextBox
  Friend WithEvents tb_OLEDBProvider As System.Windows.Forms.TextBox
  Friend WithEvents gb_PrefixDB As System.Windows.Forms.GroupBox
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents tb_prefixSubKernel As System.Windows.Forms.TextBox
  Friend WithEvents tb_prefixSubType As System.Windows.Forms.TextBox
  Friend WithEvents tb_prefixFunction As System.Windows.Forms.TextBox
  Friend WithEvents tb_prefixParam As System.Windows.Forms.TextBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
  Friend WithEvents pnlCtrlServer As System.Windows.Forms.Panel
  Friend WithEvents btDeleteServer As System.Windows.Forms.Button
  Friend WithEvents btCreateServer As System.Windows.Forms.Button
  Friend WithEvents lstServer As System.Windows.Forms.ListBox
  Friend WithEvents TabPageSystem As System.Windows.Forms.TabPage
  Friend WithEvents gbSettingFolderApplication As System.Windows.Forms.GroupBox
  Friend WithEvents btFolderDefTemp As System.Windows.Forms.Button
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents lblFolderDefPicture As System.Windows.Forms.Label
  Friend WithEvents tbFolderDefTemp As System.Windows.Forms.TextBox
  Friend WithEvents btFolderDefLayouts As System.Windows.Forms.Button
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents tbFolderDefLayouts As System.Windows.Forms.TextBox
  Friend WithEvents btFolderDefPicture As System.Windows.Forms.Button
  Friend WithEvents tbFolderDefPicture As System.Windows.Forms.TextBox
  Friend WithEvents gbFileConfig As System.Windows.Forms.GroupBox
  Friend WithEvents gbSettingSystem As System.Windows.Forms.GroupBox
  Friend WithEvents lblFileConfigSite As System.Windows.Forms.Label
  Friend WithEvents btFileConfigServer As System.Windows.Forms.Button
  Friend WithEvents lblFileConfigServer As System.Windows.Forms.Label
  Friend WithEvents tbFileConfigServer As System.Windows.Forms.TextBox
  Friend WithEvents btFileConfigSite As System.Windows.Forms.Button
  Friend WithEvents tbFileConfigSite As System.Windows.Forms.TextBox
  Friend WithEvents chbSettingJournal As System.Windows.Forms.CheckBox
  Friend WithEvents chbSettingForm As System.Windows.Forms.CheckBox
  Friend WithEvents btCreateFileConfigSite As System.Windows.Forms.Button
  Friend WithEvents btCreateFileConfigServer As System.Windows.Forms.Button
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents tbNameSite As System.Windows.Forms.TextBox
    Friend WithEvents chbOldVersion As System.Windows.Forms.CheckBox
  Friend WithEvents btSaveSetting As System.Windows.Forms.Button
  Friend WithEvents btSaveSite As System.Windows.Forms.Button
  Friend WithEvents btSaveServer As System.Windows.Forms.Button
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents tb_ServerDB As System.Windows.Forms.TextBox
  Friend WithEvents btLoadPathTemp As System.Windows.Forms.Button
  Friend WithEvents btLoadPathLayouts As System.Windows.Forms.Button
  Friend WithEvents btLoadPathPicture As System.Windows.Forms.Button
  Friend WithEvents gbProject As System.Windows.Forms.GroupBox
  Friend WithEvents tbProject As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents tbFolderProjects As System.Windows.Forms.TextBox
  Friend WithEvents btFolderProjects As System.Windows.Forms.Button

End Class
