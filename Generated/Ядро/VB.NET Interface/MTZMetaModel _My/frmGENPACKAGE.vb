
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


''' <summary>
'''Форма редактирования раздела Пакет генерации режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class frmGENPACKAGE
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
    Friend WithEvents EditGENPACKAGE As MTZMetaModelGUI.editGENPACKAGE
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnPanel = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.EditGENPACKAGE = New MTZMetaModelGUI.EditGENPACKAGE
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
        'EditGENPACKAGE
        '
        Me.EditGENPACKAGE.AutoScroll = True
        Me.EditGENPACKAGE.Location = New System.Drawing.Point(8, 8)
        Me.EditGENPACKAGE.name = "EditGENPACKAGE"
        Me.EditGENPACKAGE.Size = New System.Drawing.Size(490, 600)
        Me.EditGENPACKAGE.TabIndex = 20
        Me.EditGENPACKAGE.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'frmGENPACKAGE
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add (EditGENPACKAGE)
        Me.Controls.Add (Me.btnPanel)
        Me.name = "frmGENPACKAGE"
        Me.Text = "Пакет генерации"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout (False)

    End Sub

#End Region
    Public Item As MTZMetaModel.MTZMetaModel.GENPACKAGE
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager
    Private mReadOnly as boolean



''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Sub Attach(ByVal RowItem As LATIR2.Document.DocRow_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, optional byval FormReadOnly as boolean =false)
        Item = CType(RowItem, MTZMetaModel.MTZMetaModel.GENPACKAGE)
        GuiManager = gm
        mReadOnly = FormReadOnly
        EditGENPACKAGE.Attach(GuiManager, Item, FormReadOnly)
        btnOK.Enabled = False
    End Sub

    Private Sub EditGENPACKAGE_Changed() Handles EditGENPACKAGE.Changed
        if not mReadOnly then
          btnOK.Enabled = True
        end if
    End Sub


''' <summary>
'''Завершение редактирования
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      if not mReadOnly then
        if EditGENPACKAGE.IsOK() then
          EditGENPACKAGE.Save()
          on error goto bye
          Item.Save()
          Me.DialogResult = System.Windows.Forms.DialogResult.OK
          Me.Close
        else
          MsgBox("Не все обязательные пля заполнены",vbOKOnly+vbExclamation,"Ошибка")
        end if
        exit sub
        bye:
          MsgBox(err.description,vbOKOnly+vbCritical,"Ошибка")
        end if
    End Sub
    Private Sub frmUsers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ClientSize() = New System.Drawing.Size(EditGENPACKAGE.GetMaxX() + 10, EditGENPACKAGE.GetMaxY() + 35)
    End Sub
End Class
