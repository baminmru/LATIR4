
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Состав колонки режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editjcolumnsource
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IRowEditor

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    private mOnInit as boolean = false
    private mChanged as boolean = false
    public event Changed() Implements LATIR2GUIManager.IRowEditor.Changed 
    Public Event Saved() Implements LATIR2GUIManager.IRowEditor.Saved
    Public Event Refreshed() Implements LATIR2GUIManager.IRowEditor.Refreshed
    Public Sub Changing()
      if not mOnInit then
        mChanged = true
        raiseevent Changed()
      end if
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

 Dim iii As Integer
    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel
Friend WithEvents lblsrcpartview  as  System.Windows.Forms.Label
Friend WithEvents txtsrcpartview As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdsrcpartview As System.Windows.Forms.Button
Friend WithEvents lblviewfield  as  System.Windows.Forms.Label
Friend WithEvents txtviewfield As LATIR2GuiManager.TouchTextBox

<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

 Me.HolderPanel = New LATIR2GUIControls.AutoPanel
 Me.HolderPanel.SuspendLayout()
Me.SuspendLayout()
 '
'HolderPanel
'
Me.HolderPanel.AllowDrop = True
Me.HolderPanel.BackColor = System.Drawing.SystemColors.Control
Me.HolderPanel.Dock = System.Windows.Forms.DockStyle.Fill
Me.HolderPanel.Location = New System.Drawing.Point(0, 0)
Me.HolderPanel.Name = "HolderPanel"
Me.HolderPanel.Size = New System.Drawing.Size(232, 120)
Me.HolderPanel.TabIndex = 0
Me.lblsrcpartview = New System.Windows.Forms.Label
Me.txtsrcpartview = New LATIR2GuiManager.TouchTextBox
Me.cmdsrcpartview = New System.Windows.Forms.Button
Me.lblviewfield = New System.Windows.Forms.Label
Me.txtviewfield = New LATIR2GuiManager.TouchTextBox

Me.lblsrcpartview.Location = New System.Drawing.Point(20,5)
Me.lblsrcpartview.name = "lblsrcpartview"
Me.lblsrcpartview.Size = New System.Drawing.Size(200, 20)
Me.lblsrcpartview.TabIndex = 1
Me.lblsrcpartview.Text = "Представление"
Me.lblsrcpartview.ForeColor = System.Drawing.Color.Black
Me.txtsrcpartview.Location = New System.Drawing.Point(20,27)
Me.txtsrcpartview.name = "txtsrcpartview"
Me.txtsrcpartview.ReadOnly = True
Me.txtsrcpartview.Size = New System.Drawing.Size(176, 20)
Me.txtsrcpartview.TabIndex = 2
Me.txtsrcpartview.Text = "" 
Me.cmdsrcpartview.Location = New System.Drawing.Point(198,27)
Me.cmdsrcpartview.name = "cmdsrcpartview"
Me.cmdsrcpartview.Size = New System.Drawing.Size(22, 20)
Me.cmdsrcpartview.TabIndex = 3
Me.cmdsrcpartview.Text = "..." 
Me.lblviewfield.Location = New System.Drawing.Point(20,52)
Me.lblviewfield.name = "lblviewfield"
Me.lblviewfield.Size = New System.Drawing.Size(200, 20)
Me.lblviewfield.TabIndex = 4
Me.lblviewfield.Text = "Поле представления"
Me.lblviewfield.ForeColor = System.Drawing.Color.Black
Me.txtviewfield.Location = New System.Drawing.Point(20,74)
Me.txtviewfield.name = "txtviewfield"
Me.txtviewfield.Size = New System.Drawing.Size(200, 20)
Me.txtviewfield.TabIndex = 5
Me.txtviewfield.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsrcpartview)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsrcpartview)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdsrcpartview)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblviewfield)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtviewfield)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editjcolumnsource"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtsrcpartview_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrcpartview.TextChanged
  Changing

end sub
private sub cmdsrcpartview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsrcpartview.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("journalsrc","",item.application.ID, id, brief) Then
          txtsrcpartview.Tag = id
          txtsrcpartview.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtviewfield_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtviewfield.TextChanged
  Changing

end sub

Public Item As mtzjrnl.mtzjrnl.jcolumnsource
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,mtzjrnl.mtzjrnl.jcolumnsource)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.srcpartview Is Nothing Then
  txtsrcpartview.Tag = item.srcpartview.id
  txtsrcpartview.text = item.srcpartview.brief
else
  txtsrcpartview.Tag = System.Guid.Empty 
  txtsrcpartview.text = "" 
End If
txtviewfield.text = item.viewfield
        mOnInit = false
  raiseevent Refreshed()
end sub


''' <summary>
'''Сохранения данных в полях объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Save() Implements LATIR2GUIManager.IRowEditor.Save
  if mRowReadOnly =false then

If not txtsrcpartview.Tag.Equals(System.Guid.Empty) Then
  item.srcpartview = Item.Application.FindRowObject("journalsrc",txtsrcpartview.Tag)
Else
   item.srcpartview = Nothing
End If
item.viewfield = txtviewfield.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtsrcpartview.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtviewfield.text <> "" ) 
 return mIsOK
end function
Public function IsChanged() as boolean Implements LATIR2GUIManager.IRowEditor.IsChanged
 return mChanged
end function
Public Sub SetupPanel()
    HolderPanel.SetupPanel()
End Sub
Public Overridable Function GetMaxX() As Double
    Return HolderPanel.GetMaxX()
End Function
Public Overridable Function GetMaxY() As Double
    Return HolderPanel.GetMaxY()
End Function
end class
