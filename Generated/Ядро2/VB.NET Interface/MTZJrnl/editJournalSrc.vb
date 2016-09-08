
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Источники журнала режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editJournalSrc
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
Friend WithEvents lblPartView  as  System.Windows.Forms.Label
Friend WithEvents txtPartView As System.Windows.Forms.TextBox
Friend WithEvents lblOnRun  as  System.Windows.Forms.Label
Friend WithEvents cmbOnRun As System.Windows.Forms.ComboBox
Friend cmbOnRunDATA As DataTable
Friend cmbOnRunDATAROW As DataRow
Friend WithEvents lblOpenMode  as  System.Windows.Forms.Label
Friend WithEvents txtOpenMode As System.Windows.Forms.TextBox
Friend WithEvents lblViewAlias  as  System.Windows.Forms.Label
Friend WithEvents txtViewAlias As System.Windows.Forms.TextBox

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
Me.lblPartView = New System.Windows.Forms.Label
Me.txtPartView = New System.Windows.Forms.TextBox
Me.lblOnRun = New System.Windows.Forms.Label
Me.cmbOnRun = New System.Windows.Forms.ComboBox
Me.lblOpenMode = New System.Windows.Forms.Label
Me.txtOpenMode = New System.Windows.Forms.TextBox
Me.lblViewAlias = New System.Windows.Forms.Label
Me.txtViewAlias = New System.Windows.Forms.TextBox

Me.lblPartView.Location = New System.Drawing.Point(20,5)
Me.lblPartView.name = "lblPartView"
Me.lblPartView.Size = New System.Drawing.Size(200, 20)
Me.lblPartView.TabIndex = 1
Me.lblPartView.Text = "Представление"
Me.lblPartView.ForeColor = System.Drawing.Color.Black
Me.txtPartView.Location = New System.Drawing.Point(20,27)
Me.txtPartView.name = "txtPartView"
Me.txtPartView.Size = New System.Drawing.Size(200, 20)
Me.txtPartView.TabIndex = 2
Me.txtPartView.Text = "" 
Me.lblOnRun.Location = New System.Drawing.Point(20,52)
Me.lblOnRun.name = "lblOnRun"
Me.lblOnRun.Size = New System.Drawing.Size(200, 20)
Me.lblOnRun.TabIndex = 3
Me.lblOnRun.Text = "При открытии"
Me.lblOnRun.ForeColor = System.Drawing.Color.Black
Me.cmbOnRun.Location = New System.Drawing.Point(20,74)
Me.cmbOnRun.name = "cmbOnRun"
Me.cmbOnRun.Size = New System.Drawing.Size(200,  20)
Me.cmbOnRun.TabIndex = 4
Me.cmbOnRun.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblOpenMode.Location = New System.Drawing.Point(20,99)
Me.lblOpenMode.name = "lblOpenMode"
Me.lblOpenMode.Size = New System.Drawing.Size(200, 20)
Me.lblOpenMode.TabIndex = 5
Me.lblOpenMode.Text = "Режим открытия"
Me.lblOpenMode.ForeColor = System.Drawing.Color.Blue
Me.txtOpenMode.Location = New System.Drawing.Point(20,121)
Me.txtOpenMode.name = "txtOpenMode"
Me.txtOpenMode.Size = New System.Drawing.Size(200, 20)
Me.txtOpenMode.TabIndex = 6
Me.txtOpenMode.Text = "" 
Me.lblViewAlias.Location = New System.Drawing.Point(20,146)
Me.lblViewAlias.name = "lblViewAlias"
Me.lblViewAlias.Size = New System.Drawing.Size(200, 20)
Me.lblViewAlias.TabIndex = 7
Me.lblViewAlias.Text = "Псевдоним представления"
Me.lblViewAlias.ForeColor = System.Drawing.Color.Blue
Me.txtViewAlias.Location = New System.Drawing.Point(20,168)
Me.txtViewAlias.name = "txtViewAlias"
Me.txtViewAlias.Size = New System.Drawing.Size(200, 20)
Me.txtViewAlias.TabIndex = 8
Me.txtViewAlias.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPartView)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPartView)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblOnRun)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbOnRun)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblOpenMode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtOpenMode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblViewAlias)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtViewAlias)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editJournalSrc"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtPartView_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartView.TextChanged
  Changing

end sub
private sub cmbOnRun_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOnRun.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtOpenMode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOpenMode.TextChanged
  Changing

end sub
private sub txtViewAlias_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtViewAlias.TextChanged
  Changing

end sub

Public Item As MTZJrnl.MTZJrnl.JournalSrc
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZJrnl.MTZJrnl.JournalSrc)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtPartView.text = item.PartView.ToString()
cmbOnRunData = New DataTable
cmbOnRunData.Columns.Add("name", GetType(System.String))
cmbOnRunData.Columns.Add("Value", GetType(System.Int32))
try
cmbOnRunDataRow = cmbOnRunData.NewRow
cmbOnRunDataRow("name") = "Ничего не делать"
cmbOnRunDataRow("Value") = 0
cmbOnRunData.Rows.Add (cmbOnRunDataRow)
cmbOnRunDataRow = cmbOnRunData.NewRow
cmbOnRunDataRow("name") = "Открыть строку"
cmbOnRunDataRow("Value") = 1
cmbOnRunData.Rows.Add (cmbOnRunDataRow)
cmbOnRunDataRow = cmbOnRunData.NewRow
cmbOnRunDataRow("name") = "Открыть документ"
cmbOnRunDataRow("Value") = 2
cmbOnRunData.Rows.Add (cmbOnRunDataRow)
cmbOnRun.DisplayMember = "name"
cmbOnRun.ValueMember = "Value"
cmbOnRun.DataSource = cmbOnRunData
 cmbOnRun.SelectedValue=CInt(Item.OnRun)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtOpenMode.text = item.OpenMode
txtViewAlias.text = item.ViewAlias
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

item.PartView = new System.Guid(txtPartView.text)
   item.OnRun = cmbOnRun.SelectedValue
item.OpenMode = txtOpenMode.text
item.ViewAlias = txtViewAlias.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtPartView.text <> "" ) 
if mIsOK then mIsOK =(cmbOnRun.SelectedIndex >=0)
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
