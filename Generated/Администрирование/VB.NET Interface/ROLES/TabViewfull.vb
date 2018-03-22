


''' <summary>
'''Компонент, реализующий редактирование всего документа
''' </summary>
''' <remarks>
'''
''' </remarks>
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class Tabviewfull
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IViewPanel

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose (disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ViewROLES_DEF As ROLESGUI.viewROLES_DEFfull
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ViewROLES_WP As ROLESGUI.viewROLES_WPfull
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ViewROLES_MAP As ROLESGUI.viewROLES_MAPfull
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ViewROLES_USER As ROLESGUI.viewROLES_USERfull
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ViewROLES_DOC As ROLESGUI.viewROLES_DOCfull
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents ViewROLES_OPERATIONS As ROLESGUI.viewROLES_OPERATIONSfull
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents ViewROLES_REPORTS As ROLESGUI.viewROLES_REPORTSfull
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents ViewROLES2_MODULE As ROLESGUI.viewROLES2_MODULEfull
   
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tab = New System.Windows.Forms.TabControl
   TabPage1 = New System.Windows.Forms.TabPage
   ViewROLES_DEF = new viewROLES_DEFfull
   TabPage2 = New System.Windows.Forms.TabPage
   ViewROLES_WP = new viewROLES_WPfull
   TabPage3 = New System.Windows.Forms.TabPage
   ViewROLES_MAP = new viewROLES_MAPfull
   TabPage4 = New System.Windows.Forms.TabPage
   ViewROLES_USER = new viewROLES_USERfull
   TabPage5 = New System.Windows.Forms.TabPage
   ViewROLES_DOC = new viewROLES_DOCfull
   TabPage6 = New System.Windows.Forms.TabPage
   ViewROLES_OPERATIONS = new viewROLES_OPERATIONSfull
   TabPage7 = New System.Windows.Forms.TabPage
   ViewROLES_REPORTS = new viewROLES_REPORTSfull
   TabPage8 = New System.Windows.Forms.TabPage
   ViewROLES2_MODULE = new viewROLES2_MODULEfull
        Me.tab.SuspendLayout()
   Me.TabPage1.SuspendLayout()
   Me.TabPage2.SuspendLayout()
   Me.TabPage3.SuspendLayout()
   Me.TabPage4.SuspendLayout()
   Me.TabPage5.SuspendLayout()
   Me.TabPage6.SuspendLayout()
   Me.TabPage7.SuspendLayout()
   Me.TabPage8.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab
        '
        Me.tab.Location = New System.Drawing.Point(0, 0)
        Me.tab.name = "tab"
        Me.tab.Size = New System.Drawing.Size(528, 392)
        Me.tab.TabIndex = 0
        Me.tab.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add (Me.ViewROLES_DEF)
        Me.TabPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage1.name = "TabPage1"
        Me.TabPage1.Text = "Определение роли"
        Me.TabPage1.Size = New System.Drawing.Size(520, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.AutoScroll = True
        '
        'ViewROLES_DEF
        '
        Me.ViewROLES_DEF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewROLES_DEF.Location = New System.Drawing.Point(0, 0)
        Me.ViewROLES_DEF.name = "ViewROLES_DEF"
        Me.ViewROLES_DEF.Size = New System.Drawing.Size(504, 352)
        Me.ViewROLES_DEF.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add (Me.ViewROLES_WP)
        Me.TabPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage2.name = "TabPage2"
        Me.TabPage2.Text = "Доступные приложения"
        Me.TabPage2.Size = New System.Drawing.Size(520, 366)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.AutoScroll = True
        '
        'ViewROLES_WP
        '
        Me.ViewROLES_WP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewROLES_WP.Location = New System.Drawing.Point(0, 0)
        Me.ViewROLES_WP.name = "ViewROLES_WP"
        Me.ViewROLES_WP.Size = New System.Drawing.Size(504, 352)
        Me.ViewROLES_WP.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add (Me.ViewROLES_MAP)
        Me.TabPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage3.name = "TabPage3"
        Me.TabPage3.Text = "Отображение на группы"
        Me.TabPage3.Size = New System.Drawing.Size(520, 366)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.AutoScroll = True
        '
        'ViewROLES_MAP
        '
        Me.ViewROLES_MAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewROLES_MAP.Location = New System.Drawing.Point(0, 0)
        Me.ViewROLES_MAP.name = "ViewROLES_MAP"
        Me.ViewROLES_MAP.Size = New System.Drawing.Size(504, 352)
        Me.ViewROLES_MAP.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add (Me.ViewROLES_USER)
        Me.TabPage4.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage4.name = "TabPage4"
        Me.TabPage4.Text = "Пользователи"
        Me.TabPage4.Size = New System.Drawing.Size(520, 366)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.AutoScroll = True
        '
        'ViewROLES_USER
        '
        Me.ViewROLES_USER.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewROLES_USER.Location = New System.Drawing.Point(0, 0)
        Me.ViewROLES_USER.name = "ViewROLES_USER"
        Me.ViewROLES_USER.Size = New System.Drawing.Size(504, 352)
        Me.ViewROLES_USER.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add (Me.ViewROLES_DOC)
        Me.TabPage5.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage5.name = "TabPage5"
        Me.TabPage5.Text = "Доступные документы"
        Me.TabPage5.Size = New System.Drawing.Size(520, 366)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.AutoScroll = True
        '
        'ViewROLES_DOC
        '
        Me.ViewROLES_DOC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewROLES_DOC.Location = New System.Drawing.Point(0, 0)
        Me.ViewROLES_DOC.name = "ViewROLES_DOC"
        Me.ViewROLES_DOC.Size = New System.Drawing.Size(504, 352)
        Me.ViewROLES_DOC.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add (Me.ViewROLES_OPERATIONS)
        Me.TabPage6.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage6.name = "TabPage6"
        Me.TabPage6.Text = "Доступные действия"
        Me.TabPage6.Size = New System.Drawing.Size(520, 366)
        Me.TabPage6.TabIndex = 0
        Me.TabPage6.AutoScroll = True
        '
        'ViewROLES_OPERATIONS
        '
        Me.ViewROLES_OPERATIONS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewROLES_OPERATIONS.Location = New System.Drawing.Point(0, 0)
        Me.ViewROLES_OPERATIONS.name = "ViewROLES_OPERATIONS"
        Me.ViewROLES_OPERATIONS.Size = New System.Drawing.Size(504, 352)
        Me.ViewROLES_OPERATIONS.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add (Me.ViewROLES_REPORTS)
        Me.TabPage7.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage7.name = "TabPage7"
        Me.TabPage7.Text = "Отчёты"
        Me.TabPage7.Size = New System.Drawing.Size(520, 366)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.AutoScroll = True
        '
        'ViewROLES_REPORTS
        '
        Me.ViewROLES_REPORTS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewROLES_REPORTS.Location = New System.Drawing.Point(0, 0)
        Me.ViewROLES_REPORTS.name = "ViewROLES_REPORTS"
        Me.ViewROLES_REPORTS.Size = New System.Drawing.Size(504, 352)
        Me.ViewROLES_REPORTS.TabIndex = 0
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add (Me.ViewROLES2_MODULE)
        Me.TabPage8.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage8.name = "TabPage8"
        Me.TabPage8.Text = "Модули"
        Me.TabPage8.Size = New System.Drawing.Size(520, 366)
        Me.TabPage8.TabIndex = 0
        Me.TabPage8.AutoScroll = True
        '
        'ViewROLES2_MODULE
        '
        Me.ViewROLES2_MODULE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewROLES2_MODULE.Location = New System.Drawing.Point(0, 0)
        Me.ViewROLES2_MODULE.name = "ViewROLES2_MODULE"
        Me.ViewROLES2_MODULE.Size = New System.Drawing.Size(504, 352)
        Me.ViewROLES2_MODULE.TabIndex = 0
   Me.tab.Controls.Add (Me.TabPage1)
   Me.tab.Controls.Add (Me.TabPage2)
   Me.tab.Controls.Add (Me.TabPage3)
   Me.tab.Controls.Add (Me.TabPage4)
   Me.tab.Controls.Add (Me.TabPage5)
   Me.tab.Controls.Add (Me.TabPage6)
   Me.tab.Controls.Add (Me.TabPage7)
   Me.tab.Controls.Add (Me.TabPage8)
        '
        'Tabview
        '
        Me.Controls.Add (Me.tab)
        Me.name = "TabView"
        Me.Size = New System.Drawing.Size(528, 392)
        Me.tab.ResumeLayout (False)
   Me.TabPage1.ResumeLayout (False)
   Me.TabPage2.ResumeLayout (False)
   Me.TabPage3.ResumeLayout (False)
   Me.TabPage4.ResumeLayout (False)
   Me.TabPage5.ResumeLayout (False)
   Me.TabPage6.ResumeLayout (False)
   Me.TabPage7.ResumeLayout (False)
   Me.TabPage8.ResumeLayout (False)
        Me.ResumeLayout (False)

    End Sub

#End Region



''' <summary>
'''Редактируемый объект
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public item As ROLES.ROLES.Application
    Private mReadOnly as boolean



''' <summary>
'''Объект управления визуальными компонентами
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager



''' <summary>
'''Инициализация контрольного элемента
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, byval DocReadOnly as boolean  ) Implements LATIR2GUIManager.IViewPanel.Attach
        item = CType(docItem, ROLES.ROLES.Application)
        mReadOnly =DocReadOnly
        GuiManager = gm
        ViewROLES_DEF.Attach(item, GuiManager,DocReadOnly)
        ViewROLES_WP.Attach(item, GuiManager,DocReadOnly)
        ViewROLES_MAP.Attach(item, GuiManager,DocReadOnly)
        ViewROLES_USER.Attach(item, GuiManager,DocReadOnly)
        ViewROLES_DOC.Attach(item, GuiManager,DocReadOnly)
        ViewROLES_OPERATIONS.Attach(item, GuiManager,DocReadOnly)
        ViewROLES_REPORTS.Attach(item, GuiManager,DocReadOnly)
        ViewROLES2_MODULE.Attach(item, GuiManager,DocReadOnly)
    End Sub


''' <summary>
'''Сохранение всех изменений
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save
    Dim ok As Boolean
    ok = True
        ok = ok And ViewROLES_DEF.Save(Sielent, NoError)
        ok = ok And ViewROLES_WP.Save(Sielent, NoError)
        ok = ok And ViewROLES_MAP.Save(Sielent, NoError)
        ok = ok And ViewROLES_USER.Save(Sielent, NoError)
        ok = ok And ViewROLES_DOC.Save(Sielent, NoError)
        ok = ok And ViewROLES_OPERATIONS.Save(Sielent, NoError)
        ok = ok And ViewROLES_REPORTS.Save(Sielent, NoError)
        ok = ok And ViewROLES2_MODULE.Save(Sielent, NoError)
       Return ok
    End function


''' <summary>
'''Корректны ли измененные данные проверка после Verify
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK
    Dim ok As Boolean
    ok = True
        ok = ok And ViewROLES_DEF.IsOK()
        ok = ok And ViewROLES_WP.IsOK()
        ok = ok And ViewROLES_MAP.IsOK()
        ok = ok And ViewROLES_USER.IsOK()
        ok = ok And ViewROLES_DOC.IsOK()
        ok = ok And ViewROLES_OPERATIONS.IsOK()
        ok = ok And ViewROLES_REPORTS.IsOK()
        ok = ok And ViewROLES2_MODULE.IsOK()
       Return ok
    End function


''' <summary>
'''Были ли изменения данных
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged
    Dim ok As Boolean
    if mReadOnly then return false
    ok = False
        ok = ok or ViewROLES_DEF.IsChanged()
        ok = ok or ViewROLES_WP.IsChanged()
        ok = ok or ViewROLES_MAP.IsChanged()
        ok = ok or ViewROLES_USER.IsChanged()
        ok = ok or ViewROLES_DOC.IsChanged()
        ok = ok or ViewROLES_OPERATIONS.IsChanged()
        ok = ok or ViewROLES_REPORTS.IsChanged()
        ok = ok or ViewROLES2_MODULE.IsChanged()
       Return ok
    End function


''' <summary>
'''Проверить корректность данных
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify
    Dim ok As Boolean
    if mReadOnly then return true
    ok = True
        ok = ok And ViewROLES_DEF.Verify(NoError)
        ok = ok And ViewROLES_WP.Verify(NoError)
        ok = ok And ViewROLES_MAP.Verify(NoError)
        ok = ok And ViewROLES_USER.Verify(NoError)
        ok = ok And ViewROLES_DOC.Verify(NoError)
        ok = ok And ViewROLES_OPERATIONS.Verify(NoError)
        ok = ok And ViewROLES_REPORTS.Verify(NoError)
        ok = ok And ViewROLES2_MODULE.Verify(NoError)
       Return ok
    End function
    Private Sub TabPage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Leave
        If ViewROLES_DEF.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage1.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewROLES_DEF.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Leave
        If ViewROLES_WP.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage2.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewROLES_WP.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Leave
        If ViewROLES_MAP.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage3.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewROLES_MAP.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage4.Leave
        If ViewROLES_USER.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage4.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewROLES_USER.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage5.Leave
        If ViewROLES_DOC.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage5.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewROLES_DOC.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage6.Leave
        If ViewROLES_OPERATIONS.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage6.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewROLES_OPERATIONS.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage7.Leave
        If ViewROLES_REPORTS.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage7.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewROLES_REPORTS.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage8.Leave
        If ViewROLES2_MODULE.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage8.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewROLES2_MODULE.Save(True, False)
            End If
        End If
    End Sub
End Class
