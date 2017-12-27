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
        Me.btExit = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.lblFileConfigSite = New System.Windows.Forms.Label()
        Me.btFileConfigSite = New System.Windows.Forms.Button()
        Me.tbFileConfigSite = New System.Windows.Forms.TextBox()
        Me.TabPageSite = New System.Windows.Forms.TabPage()
        Me.pnlDataSite = New System.Windows.Forms.Panel()
        Me.gbServerDB = New System.Windows.Forms.GroupBox()
        Me.chbARM = New System.Windows.Forms.CheckBox()
        Me.chbNTsecurity = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.cmdMakeZZZ = New System.Windows.Forms.Button()
        Me.chkAllowKbd = New System.Windows.Forms.CheckBox()
        ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPageSite.SuspendLayout()
        Me.pnlDataSite.SuspendLayout()
        Me.gbServerDB.SuspendLayout()
        Me.gbPrefixDB.SuspendLayout()
        Me.pnlCtrlSite.SuspendLayout()
        Me.TabControl.SuspendLayout()
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
        'btExit
        '
        resources.ApplyResources(Me.btExit, "btExit")
        Me.btExit.Name = "btExit"
        Me.btExit.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        resources.ApplyResources(Me.OpenFileDialog, "OpenFileDialog")
        '
        'SaveFileDialog
        '
        resources.ApplyResources(Me.SaveFileDialog, "SaveFileDialog")
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
        'lblFileConfigSite
        '
        resources.ApplyResources(Me.lblFileConfigSite, "lblFileConfigSite")
        Me.lblFileConfigSite.Name = "lblFileConfigSite"
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
        'TabPageSite
        '
        Me.TabPageSite.Controls.Add(Me.pnlDataSite)
        Me.TabPageSite.Controls.Add(Me.pnlCtrlSite)
        resources.ApplyResources(Me.TabPageSite, "TabPageSite")
        Me.TabPageSite.Name = "TabPageSite"
        Me.TabPageSite.UseVisualStyleBackColor = True
        '
        'pnlDataSite
        '
        resources.ApplyResources(Me.pnlDataSite, "pnlDataSite")
        Me.pnlDataSite.Controls.Add(Me.gbServerDB)
        Me.pnlDataSite.Controls.Add(Me.gbPrefixDB)
        Me.pnlDataSite.Name = "pnlDataSite"
        '
        'gbServerDB
        '
        resources.ApplyResources(Me.gbServerDB, "gbServerDB")
        Me.gbServerDB.Controls.Add(Me.chbARM)
        Me.gbServerDB.Controls.Add(Me.chbNTsecurity)
        Me.gbServerDB.Controls.Add(Me.Label8)
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
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
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
        resources.ApplyResources(Me.gbPrefixDB, "gbPrefixDB")
        Me.gbPrefixDB.Controls.Add(Me.Label7)
        Me.gbPrefixDB.Controls.Add(Me.Label6)
        Me.gbPrefixDB.Controls.Add(Me.Label4)
        Me.gbPrefixDB.Controls.Add(Me.Label3)
        Me.gbPrefixDB.Controls.Add(Me.tbPrefixSubKernel)
        Me.gbPrefixDB.Controls.Add(Me.tbPrefixSubType)
        Me.gbPrefixDB.Controls.Add(Me.tbPrefixFunction)
        Me.gbPrefixDB.Controls.Add(Me.tbPrefixParam)
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
        resources.ApplyResources(Me.pnlCtrlSite, "pnlCtrlSite")
        Me.pnlCtrlSite.Controls.Add(Me.btSaveSite)
        Me.pnlCtrlSite.Controls.Add(Me.btDeleteSite)
        Me.pnlCtrlSite.Controls.Add(Me.btCreateSite)
        Me.pnlCtrlSite.Controls.Add(Me.lstSite1)
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
        Me.lstSite1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSite1.FormattingEnabled = True
        Me.lstSite1.Name = "lstSite1"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPageSite)
        resources.ApplyResources(Me.TabControl, "TabControl")
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        '
        'cmdMakeZZZ
        '
        resources.ApplyResources(Me.cmdMakeZZZ, "cmdMakeZZZ")
        Me.cmdMakeZZZ.Name = "cmdMakeZZZ"
        Me.cmdMakeZZZ.UseVisualStyleBackColor = True
        '
        'chkAllowKbd
        '
        resources.ApplyResources(Me.chkAllowKbd, "chkAllowKbd")
        Me.chkAllowKbd.Name = "chkAllowKbd"
        Me.chkAllowKbd.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkAllowKbd)
        Me.Controls.Add(Me.cmdMakeZZZ)
        Me.Controls.Add(Me.lblFileConfigSite)
        Me.Controls.Add(Me.btFileConfigSite)
        Me.Controls.Add(Me.tbFileConfigSite)
        Me.Controls.Add(Me.btExit)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.TabPageSite.ResumeLayout(False)
        Me.pnlDataSite.ResumeLayout(False)
        Me.gbServerDB.ResumeLayout(False)
        Me.gbServerDB.PerformLayout()
        Me.gbPrefixDB.ResumeLayout(False)
        Me.gbPrefixDB.PerformLayout()
        Me.pnlCtrlSite.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btExit As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents lblFileConfigSite As Label
    Friend WithEvents btFileConfigSite As Button
    Friend WithEvents tbFileConfigSite As TextBox
    Friend WithEvents TabPageSite As TabPage
    Friend WithEvents pnlDataSite As Panel
    Friend WithEvents gbServerDB As GroupBox
    Friend WithEvents chbARM As CheckBox
    Friend WithEvents chbNTsecurity As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tbNameDB As TextBox
    Friend WithEvents tbNameSite As TextBox
    Friend WithEvents tbSQLpassword As TextBox
    Friend WithEvents tbTime As TextBox
    Friend WithEvents tbServerDB As TextBox
    Friend WithEvents tbSQLuser As TextBox
    Friend WithEvents tbOLEDBProvider As TextBox
    Friend WithEvents gbPrefixDB As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbPrefixSubKernel As TextBox
    Friend WithEvents tbPrefixSubType As TextBox
    Friend WithEvents tbPrefixFunction As TextBox
    Friend WithEvents tbPrefixParam As TextBox
    Friend WithEvents pnlCtrlSite As Panel
    Friend WithEvents btSaveSite As Button
    Friend WithEvents btDeleteSite As Button
    Friend WithEvents btCreateSite As Button
    Friend WithEvents lstSite1 As ListBox
    Friend WithEvents TabControl As TabControl
    Friend WithEvents cmdMakeZZZ As Button
    Friend WithEvents chkAllowKbd As CheckBox
End Class
