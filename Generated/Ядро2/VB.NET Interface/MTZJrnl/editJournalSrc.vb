
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Источники журнала режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editjournalsrc
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
Friend WithEvents lblspartview  as  System.Windows.Forms.Label
Friend WithEvents txtspartview As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblonrun  as  System.Windows.Forms.Label
Friend WithEvents cmbonrun As System.Windows.Forms.ComboBox
Friend cmbonrunDATA As DataTable
Friend cmbonrunDATAROW As DataRow
Friend WithEvents lblopenmode  as  System.Windows.Forms.Label
Friend WithEvents txtopenmode As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblviewalias  as  System.Windows.Forms.Label
Friend WithEvents txtviewalias As LATIR2GuiManager.TouchTextBox

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
Me.lblspartview = New System.Windows.Forms.Label
Me.txtspartview = New LATIR2GuiManager.TouchTextBox
Me.lblonrun = New System.Windows.Forms.Label
Me.cmbonrun = New System.Windows.Forms.ComboBox
Me.lblopenmode = New System.Windows.Forms.Label
Me.txtopenmode = New LATIR2GuiManager.TouchTextBox
Me.lblviewalias = New System.Windows.Forms.Label
Me.txtviewalias = New LATIR2GuiManager.TouchTextBox

Me.lblspartview.Location = New System.Drawing.Point(20,5)
Me.lblspartview.name = "lblspartview"
Me.lblspartview.Size = New System.Drawing.Size(200, 20)
Me.lblspartview.TabIndex = 1
Me.lblspartview.Text = "Представление"
Me.lblspartview.ForeColor = System.Drawing.Color.Black
Me.txtspartview.Location = New System.Drawing.Point(20,27)
Me.txtspartview.name = "txtspartview"
Me.txtspartview.Size = New System.Drawing.Size(200, 20)
Me.txtspartview.TabIndex = 2
Me.txtspartview.Text = "" 
Me.lblonrun.Location = New System.Drawing.Point(20,52)
Me.lblonrun.name = "lblonrun"
Me.lblonrun.Size = New System.Drawing.Size(200, 20)
Me.lblonrun.TabIndex = 3
Me.lblonrun.Text = "При открытии"
Me.lblonrun.ForeColor = System.Drawing.Color.Black
Me.cmbonrun.Location = New System.Drawing.Point(20,74)
Me.cmbonrun.name = "cmbonrun"
Me.cmbonrun.Size = New System.Drawing.Size(200,  20)
Me.cmbonrun.TabIndex = 4
Me.cmbonrun.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblopenmode.Location = New System.Drawing.Point(20,99)
Me.lblopenmode.name = "lblopenmode"
Me.lblopenmode.Size = New System.Drawing.Size(200, 20)
Me.lblopenmode.TabIndex = 5
Me.lblopenmode.Text = "Режим открытия"
Me.lblopenmode.ForeColor = System.Drawing.Color.Blue
Me.txtopenmode.Location = New System.Drawing.Point(20,121)
Me.txtopenmode.name = "txtopenmode"
Me.txtopenmode.Size = New System.Drawing.Size(200, 20)
Me.txtopenmode.TabIndex = 6
Me.txtopenmode.Text = "" 
Me.lblviewalias.Location = New System.Drawing.Point(20,146)
Me.lblviewalias.name = "lblviewalias"
Me.lblviewalias.Size = New System.Drawing.Size(200, 20)
Me.lblviewalias.TabIndex = 7
Me.lblviewalias.Text = "Псевдоним представления"
Me.lblviewalias.ForeColor = System.Drawing.Color.Blue
Me.txtviewalias.Location = New System.Drawing.Point(20,168)
Me.txtviewalias.name = "txtviewalias"
Me.txtviewalias.Size = New System.Drawing.Size(200, 20)
Me.txtviewalias.TabIndex = 8
Me.txtviewalias.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblspartview)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtspartview)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblonrun)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbonrun)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblopenmode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtopenmode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblviewalias)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtviewalias)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editjournalsrc"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtspartview_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtspartview.TextChanged
  Changing

end sub
private sub cmbonrun_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbonrun.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtopenmode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtopenmode.TextChanged
  Changing

end sub
private sub txtviewalias_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtviewalias.TextChanged
  Changing

end sub

Public Item As mtzjrnl.mtzjrnl.journalsrc
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,mtzjrnl.mtzjrnl.journalsrc)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtspartview.text = item.spartview
cmbonrunData = New DataTable
cmbonrunData.Columns.Add("name", GetType(System.String))
cmbonrunData.Columns.Add("Value", GetType(System.Int32))
try
cmbonrunDataRow = cmbonrunData.NewRow
cmbonrunDataRow("name") = "Ничего не делать"
cmbonrunDataRow("Value") = 0
cmbonrunData.Rows.Add (cmbonrunDataRow)
cmbonrunDataRow = cmbonrunData.NewRow
cmbonrunDataRow("name") = "Открыть строку"
cmbonrunDataRow("Value") = 1
cmbonrunData.Rows.Add (cmbonrunDataRow)
cmbonrunDataRow = cmbonrunData.NewRow
cmbonrunDataRow("name") = "Открыть документ"
cmbonrunDataRow("Value") = 2
cmbonrunData.Rows.Add (cmbonrunDataRow)
cmbonrun.DisplayMember = "name"
cmbonrun.ValueMember = "Value"
cmbonrun.DataSource = cmbonrunData
 cmbonrun.SelectedValue=CInt(Item.onrun)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtopenmode.text = item.openmode
txtviewalias.text = item.viewalias
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

item.spartview = txtspartview.text
   item.onrun = cmbonrun.SelectedValue
item.openmode = txtopenmode.text
item.viewalias = txtviewalias.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtspartview.text <> "" ) 
if mIsOK then mIsOK =(cmbonrun.SelectedIndex >=0)
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
