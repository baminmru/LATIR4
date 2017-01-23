


''' <summary>
'''Компонент, реализующий редактирование всего документа
''' </summary>
''' <remarks>
'''
''' </remarks>
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class Tabview
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
    Friend WithEvents Viewjournal As mtzjrnlGUI.viewjournal
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Viewjournalsrc As mtzjrnlGUI.viewjournalsrc
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Viewjournalcolumn As mtzjrnlGUI.viewjournalcolumn
   
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tab = New System.Windows.Forms.TabControl
   TabPage1 = New System.Windows.Forms.TabPage
   Viewjournal = new viewjournal
   TabPage2 = New System.Windows.Forms.TabPage
   Viewjournalsrc = new viewjournalsrc
   TabPage3 = New System.Windows.Forms.TabPage
   Viewjournalcolumn = new viewjournalcolumn
        Me.tab.SuspendLayout()
   Me.TabPage1.SuspendLayout()
   Me.TabPage2.SuspendLayout()
   Me.TabPage3.SuspendLayout()
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
        Me.TabPage1.Controls.Add (Me.Viewjournal)
        Me.TabPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage1.name = "TabPage1"
        Me.TabPage1.Text = "Журнал"
        Me.TabPage1.Size = New System.Drawing.Size(520, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.AutoScroll = True
        '
        'Viewjournal
        '
        Me.Viewjournal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewjournal.Location = New System.Drawing.Point(0, 0)
        Me.Viewjournal.name = "Viewjournal"
        Me.Viewjournal.Size = New System.Drawing.Size(504, 352)
        Me.Viewjournal.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add (Me.Viewjournalsrc)
        Me.TabPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage2.name = "TabPage2"
        Me.TabPage2.Text = "Источники журнала"
        Me.TabPage2.Size = New System.Drawing.Size(520, 366)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.AutoScroll = True
        '
        'Viewjournalsrc
        '
        Me.Viewjournalsrc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewjournalsrc.Location = New System.Drawing.Point(0, 0)
        Me.Viewjournalsrc.name = "Viewjournalsrc"
        Me.Viewjournalsrc.Size = New System.Drawing.Size(504, 352)
        Me.Viewjournalsrc.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add (Me.Viewjournalcolumn)
        Me.TabPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage3.name = "TabPage3"
        Me.TabPage3.Text = "Колонки журнала"
        Me.TabPage3.Size = New System.Drawing.Size(520, 366)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.AutoScroll = True
        '
        'Viewjournalcolumn
        '
        Me.Viewjournalcolumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewjournalcolumn.Location = New System.Drawing.Point(0, 0)
        Me.Viewjournalcolumn.name = "Viewjournalcolumn"
        Me.Viewjournalcolumn.Size = New System.Drawing.Size(504, 352)
        Me.Viewjournalcolumn.TabIndex = 0
   Me.tab.Controls.Add (Me.TabPage1)
   Me.tab.Controls.Add (Me.TabPage2)
   Me.tab.Controls.Add (Me.TabPage3)
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
        Me.ResumeLayout (False)

    End Sub

#End Region



''' <summary>
'''Редактируемый объект
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public item As mtzjrnl.mtzjrnl.Application
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
        item = CType(docItem, mtzjrnl.mtzjrnl.Application)
        mReadOnly =DocReadOnly
        GuiManager = gm
        Viewjournal.Attach(item, GuiManager,DocReadOnly)
        Viewjournalsrc.Attach(item, GuiManager,DocReadOnly)
        Viewjournalcolumn.Attach(item, GuiManager,DocReadOnly)
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
        ok = ok And Viewjournal.Save(Sielent, NoError)
        ok = ok And Viewjournalsrc.Save(Sielent, NoError)
        ok = ok And Viewjournalcolumn.Save(Sielent, NoError)
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
        ok = ok And Viewjournal.IsOK()
        ok = ok And Viewjournalsrc.IsOK()
        ok = ok And Viewjournalcolumn.IsOK()
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
        ok = ok or Viewjournal.IsChanged()
        ok = ok or Viewjournalsrc.IsChanged()
        ok = ok or Viewjournalcolumn.IsChanged()
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
        ok = ok And Viewjournal.Verify(NoError)
        ok = ok And Viewjournalsrc.Verify(NoError)
        ok = ok And Viewjournalcolumn.Verify(NoError)
       Return ok
    End function
    Private Sub TabPage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Leave
        If Viewjournal.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage1.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewjournal.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Leave
        If Viewjournalsrc.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage2.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewjournalsrc.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Leave
        If Viewjournalcolumn.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage3.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                Viewjournalcolumn.Save(True, False)
            End If
        End If
    End Sub
End Class
