


''' <summary>
'''Компонент, реализующий редактирование всего документа
''' </summary>
''' <remarks>
'''
''' </remarks>
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class Tabviewmain
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
    Friend WithEvents ViewROLES_DEF As ROLESGUI.viewROLES_DEFmain
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents ViewROLES2_MODULE As ROLESGUI.viewROLES2_MODULEmain
   
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tab = New System.Windows.Forms.TabControl
   TabPage1 = New System.Windows.Forms.TabPage
   ViewROLES_DEF = new viewROLES_DEFmain
   TabPage8 = New System.Windows.Forms.TabPage
   ViewROLES2_MODULE = new viewROLES2_MODULEmain
        Me.tab.SuspendLayout()
   Me.TabPage1.SuspendLayout()
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
   Me.tab.Controls.Add (Me.TabPage8)
        '
        'Tabview
        '
        Me.Controls.Add (Me.tab)
        Me.name = "TabView"
        Me.Size = New System.Drawing.Size(528, 392)
        Me.tab.ResumeLayout (False)
   Me.TabPage1.ResumeLayout (False)
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
    Private Sub TabPage8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage8.Leave
        If ViewROLES2_MODULE.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage8.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewROLES2_MODULE.Save(True, False)
            End If
        End If
    End Sub
End Class
