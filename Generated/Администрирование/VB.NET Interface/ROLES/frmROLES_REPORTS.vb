
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System.Drawing


''' <summary>
'''Форма редактирования раздела Отчёты режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class frmROLES_REPORTS
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents btnPanel As System.Windows.Forms.Panel
    Friend WithEvents edPanel As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents EditROLES_REPORTS As ROLESGUI.editROLES_REPORTS
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnPanel = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.EditROLES_REPORTS = New ROLESGUI.EditROLES_REPORTS
        Me.btnPanel.SuspendLayout()
        Me.SuspendLayout()
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(5, 3)
        Me.btnOK.name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 18
        Me.btnOK.Text = "ОК"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(90, 3)
        Me.btnCancel.name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        '
        '
        'btnPanel
        '
        Me.btnPanel.Controls.Add (Me.btnCancel)
        Me.btnPanel.Controls.Add (Me.btnOK)
        Me.btnPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnPanel.Location = New System.Drawing.Point(0, 500)
        Me.btnPanel.name = "btnPanel"
        Me.btnPanel.Size = New System.Drawing.Size(500, 32)
        Me.btnPanel.TabIndex = 21
        '
        'EditROLES_REPORTS
        '
        Me.EditROLES_REPORTS.AutoScroll = True
        Me.EditROLES_REPORTS.Location = New System.Drawing.Point(8, 8)
        Me.EditROLES_REPORTS.name = "EditROLES_REPORTS"
        Me.EditROLES_REPORTS.Size = New System.Drawing.Size(490, 600)
        Me.EditROLES_REPORTS.TabIndex = 20
        Me.EditROLES_REPORTS.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'frmROLES_REPORTS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add (EditROLES_REPORTS)
        Me.Controls.Add (Me.btnPanel)
        Me.name = "frmROLES_REPORTS"
        Me.Text = "Отчёты"
        Me.ResumeLayout (False)

    End Sub

#End Region
    Public Item As ROLES.ROLES.ROLES_REPORTS
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager
    Private mReadOnly As Boolean



''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Sub Attach(ByVal RowItem As LATIR2.Document.DocRow_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, Optional ByVal FormReadOnly As Boolean =False)
        Item = CType(RowItem, ROLES.ROLES.ROLES_REPORTS)
        GuiManager = gm
        mReadOnly = FormReadOnly
        EditROLES_REPORTS.Attach(GuiManager, Item, FormReadOnly)
        btnOK.Enabled = False
    End Sub

    Private Sub EditROLES_REPORTS_Changed() Handles EditROLES_REPORTS.Changed
        If Not mReadOnly Then
          btnOK.Enabled = True
        End If
    End Sub


''' <summary>
'''Завершение редактирования
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      If Not mReadOnly Then
        If EditROLES_REPORTS.IsOK() Then
          EditROLES_REPORTS.Save()
         Try
          Item.Save()
          Me.DialogResult = System.Windows.Forms.DialogResult.OK
          Me.Close
        Catch ex As System.Exception
          MsgBox(ex.Message,vbOKOnly+vbCritical,"Ошибка")
        End Try
        Else
          MsgBox("Не все обязательные пля заполнены",vbOKOnly+vbExclamation,"Ошибка")
        End If
        Exit Sub
        End If
    End Sub
    Private Sub frmUsers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ClientSize() = New System.Drawing.Size(EditROLES_REPORTS.GetMaxX() + 10, EditROLES_REPORTS.GetMaxY() + 35)
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
    End Sub
End Class
