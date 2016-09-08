


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
    Friend WithEvents ViewMTZAPP As MTZMetaModelGUI.viewMTZAPP
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ViewOBJECTTYPE As MTZMetaModelGUI.viewOBJECTTYPE
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ViewFIELDTYPE As MTZMetaModelGUI.viewFIELDTYPE
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ViewSHAREDMETHOD As MTZMetaModelGUI.viewSHAREDMETHOD
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ViewGENPACKAGE As MTZMetaModelGUI.viewGENPACKAGE
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents ViewLocalizeInfo As MTZMetaModelGUI.viewLocalizeInfo
   
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tab = New System.Windows.Forms.TabControl
   TabPage1 = New System.Windows.Forms.TabPage
   ViewMTZAPP = new viewMTZAPP
   TabPage2 = New System.Windows.Forms.TabPage
   ViewOBJECTTYPE = new viewOBJECTTYPE
   TabPage3 = New System.Windows.Forms.TabPage
   ViewFIELDTYPE = new viewFIELDTYPE
   TabPage4 = New System.Windows.Forms.TabPage
   ViewSHAREDMETHOD = new viewSHAREDMETHOD
   TabPage5 = New System.Windows.Forms.TabPage
   ViewGENPACKAGE = new viewGENPACKAGE
   TabPage6 = New System.Windows.Forms.TabPage
   ViewLocalizeInfo = new viewLocalizeInfo
        Me.tab.SuspendLayout()
   Me.TabPage1.SuspendLayout()
   Me.TabPage2.SuspendLayout()
   Me.TabPage3.SuspendLayout()
   Me.TabPage4.SuspendLayout()
   Me.TabPage5.SuspendLayout()
   Me.TabPage6.SuspendLayout()
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
        Me.TabPage1.Controls.Add (Me.ViewMTZAPP)
        Me.TabPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage1.name = "TabPage1"
        Me.TabPage1.Text = "Приложение"
        Me.TabPage1.Size = New System.Drawing.Size(520, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.AutoScroll = True
        '
        'ViewMTZAPP
        '
        Me.ViewMTZAPP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewMTZAPP.Location = New System.Drawing.Point(0, 0)
        Me.ViewMTZAPP.name = "ViewMTZAPP"
        Me.ViewMTZAPP.Size = New System.Drawing.Size(504, 352)
        Me.ViewMTZAPP.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add (Me.ViewOBJECTTYPE)
        Me.TabPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage2.name = "TabPage2"
        Me.TabPage2.Text = "Тип объекта"
        Me.TabPage2.Size = New System.Drawing.Size(520, 366)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.AutoScroll = True
        '
        'ViewOBJECTTYPE
        '
        Me.ViewOBJECTTYPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewOBJECTTYPE.Location = New System.Drawing.Point(0, 0)
        Me.ViewOBJECTTYPE.name = "ViewOBJECTTYPE"
        Me.ViewOBJECTTYPE.Size = New System.Drawing.Size(504, 352)
        Me.ViewOBJECTTYPE.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add (Me.ViewFIELDTYPE)
        Me.TabPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage3.name = "TabPage3"
        Me.TabPage3.Text = "Тип поля"
        Me.TabPage3.Size = New System.Drawing.Size(520, 366)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.AutoScroll = True
        '
        'ViewFIELDTYPE
        '
        Me.ViewFIELDTYPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewFIELDTYPE.Location = New System.Drawing.Point(0, 0)
        Me.ViewFIELDTYPE.name = "ViewFIELDTYPE"
        Me.ViewFIELDTYPE.Size = New System.Drawing.Size(504, 352)
        Me.ViewFIELDTYPE.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add (Me.ViewSHAREDMETHOD)
        Me.TabPage4.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage4.name = "TabPage4"
        Me.TabPage4.Text = "Методы и процедуры"
        Me.TabPage4.Size = New System.Drawing.Size(520, 366)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.AutoScroll = True
        '
        'ViewSHAREDMETHOD
        '
        Me.ViewSHAREDMETHOD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewSHAREDMETHOD.Location = New System.Drawing.Point(0, 0)
        Me.ViewSHAREDMETHOD.name = "ViewSHAREDMETHOD"
        Me.ViewSHAREDMETHOD.Size = New System.Drawing.Size(504, 352)
        Me.ViewSHAREDMETHOD.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add (Me.ViewGENPACKAGE)
        Me.TabPage5.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage5.name = "TabPage5"
        Me.TabPage5.Text = "Пакет генерации"
        Me.TabPage5.Size = New System.Drawing.Size(520, 366)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.AutoScroll = True
        '
        'ViewGENPACKAGE
        '
        Me.ViewGENPACKAGE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewGENPACKAGE.Location = New System.Drawing.Point(0, 0)
        Me.ViewGENPACKAGE.name = "ViewGENPACKAGE"
        Me.ViewGENPACKAGE.Size = New System.Drawing.Size(504, 352)
        Me.ViewGENPACKAGE.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add (Me.ViewLocalizeInfo)
        Me.TabPage6.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage6.name = "TabPage6"
        Me.TabPage6.Text = "Локализация"
        Me.TabPage6.Size = New System.Drawing.Size(520, 366)
        Me.TabPage6.TabIndex = 0
        Me.TabPage6.AutoScroll = True
        '
        'ViewLocalizeInfo
        '
        Me.ViewLocalizeInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewLocalizeInfo.Location = New System.Drawing.Point(0, 0)
        Me.ViewLocalizeInfo.name = "ViewLocalizeInfo"
        Me.ViewLocalizeInfo.Size = New System.Drawing.Size(504, 352)
        Me.ViewLocalizeInfo.TabIndex = 0
   Me.tab.Controls.Add (Me.TabPage1)
   Me.tab.Controls.Add (Me.TabPage2)
   Me.tab.Controls.Add (Me.TabPage3)
   Me.tab.Controls.Add (Me.TabPage4)
   Me.tab.Controls.Add (Me.TabPage5)
   Me.tab.Controls.Add (Me.TabPage6)
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
        Me.ResumeLayout (False)

    End Sub

#End Region



''' <summary>
'''Редактируемый объект
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public item As MTZMetaModel.MTZMetaModel.Application
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
        item = CType(docItem, MTZMetaModel.MTZMetaModel.Application)
        mReadOnly =DocReadOnly
        GuiManager = gm
        ViewMTZAPP.Attach(item, GuiManager,DocReadOnly)
        ViewOBJECTTYPE.Attach(item, GuiManager,DocReadOnly)
        ViewFIELDTYPE.Attach(item, GuiManager,DocReadOnly)
        ViewSHAREDMETHOD.Attach(item, GuiManager,DocReadOnly)
        ViewGENPACKAGE.Attach(item, GuiManager,DocReadOnly)
        ViewLocalizeInfo.Attach(item, GuiManager,DocReadOnly)
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
        ok = ok And ViewMTZAPP.Save(Sielent, NoError)
        ok = ok And ViewOBJECTTYPE.Save(Sielent, NoError)
        ok = ok And ViewFIELDTYPE.Save(Sielent, NoError)
        ok = ok And ViewSHAREDMETHOD.Save(Sielent, NoError)
        ok = ok And ViewGENPACKAGE.Save(Sielent, NoError)
        ok = ok And ViewLocalizeInfo.Save(Sielent, NoError)
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
        ok = ok And ViewMTZAPP.IsOK()
        ok = ok And ViewOBJECTTYPE.IsOK()
        ok = ok And ViewFIELDTYPE.IsOK()
        ok = ok And ViewSHAREDMETHOD.IsOK()
        ok = ok And ViewGENPACKAGE.IsOK()
        ok = ok And ViewLocalizeInfo.IsOK()
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
        ok = ok or ViewMTZAPP.IsChanged()
        ok = ok or ViewOBJECTTYPE.IsChanged()
        ok = ok or ViewFIELDTYPE.IsChanged()
        ok = ok or ViewSHAREDMETHOD.IsChanged()
        ok = ok or ViewGENPACKAGE.IsChanged()
        ok = ok or ViewLocalizeInfo.IsChanged()
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
        ok = ok And ViewMTZAPP.Verify(NoError)
        ok = ok And ViewOBJECTTYPE.Verify(NoError)
        ok = ok And ViewFIELDTYPE.Verify(NoError)
        ok = ok And ViewSHAREDMETHOD.Verify(NoError)
        ok = ok And ViewGENPACKAGE.Verify(NoError)
        ok = ok And ViewLocalizeInfo.Verify(NoError)
       Return ok
    End function
    Private Sub TabPage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Leave
        If ViewMTZAPP.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage1.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewMTZAPP.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Leave
        If ViewOBJECTTYPE.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage2.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewOBJECTTYPE.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Leave
        If ViewFIELDTYPE.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage3.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewFIELDTYPE.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage4.Leave
        If ViewSHAREDMETHOD.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage4.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewSHAREDMETHOD.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage5.Leave
        If ViewGENPACKAGE.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage5.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewGENPACKAGE.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage6.Leave
        If ViewLocalizeInfo.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage6.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewLocalizeInfo.Save(True, False)
            End If
        End If
    End Sub
End Class
