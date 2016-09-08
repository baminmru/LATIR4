
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Арм режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editWorkPlacemain
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
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As System.Windows.Forms.TextBox
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As System.Windows.Forms.TextBox
Friend WithEvents lblTheVersion  as  System.Windows.Forms.Label
Friend WithEvents txtTheVersion As System.Windows.Forms.TextBox
Friend WithEvents lblThePlatform  as  System.Windows.Forms.Label
Friend WithEvents cmbThePlatform As System.Windows.Forms.ComboBox
Friend cmbThePlatformDATA As DataTable
Friend cmbThePlatformDATAROW As DataRow
Friend WithEvents lblTheComment  as  System.Windows.Forms.Label
Friend WithEvents txtTheComment As System.Windows.Forms.TextBox

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
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New System.Windows.Forms.TextBox
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New System.Windows.Forms.TextBox
Me.lblTheVersion = New System.Windows.Forms.Label
Me.txtTheVersion = New System.Windows.Forms.TextBox
Me.lblThePlatform = New System.Windows.Forms.Label
Me.cmbThePlatform = New System.Windows.Forms.ComboBox
Me.lblTheComment = New System.Windows.Forms.Label
Me.txtTheComment = New System.Windows.Forms.TextBox

Me.lblName.Location = New System.Drawing.Point(20,5)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 1
Me.lblName.Text = "Название"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,27)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 2
Me.txtName.Text = "" 
Me.lblCaption.Location = New System.Drawing.Point(20,52)
Me.lblCaption.name = "lblCaption"
Me.lblCaption.Size = New System.Drawing.Size(200, 20)
Me.lblCaption.TabIndex = 3
Me.lblCaption.Text = "Заголовок"
Me.lblCaption.ForeColor = System.Drawing.Color.Black
Me.txtCaption.Location = New System.Drawing.Point(20,74)
Me.txtCaption.name = "txtCaption"
Me.txtCaption.Size = New System.Drawing.Size(200, 20)
Me.txtCaption.TabIndex = 4
Me.txtCaption.Text = "" 
Me.lblTheVersion.Location = New System.Drawing.Point(20,99)
Me.lblTheVersion.name = "lblTheVersion"
Me.lblTheVersion.Size = New System.Drawing.Size(200, 20)
Me.lblTheVersion.TabIndex = 5
Me.lblTheVersion.Text = "Версия"
Me.lblTheVersion.ForeColor = System.Drawing.Color.Blue
Me.txtTheVersion.Location = New System.Drawing.Point(20,121)
Me.txtTheVersion.name = "txtTheVersion"
Me.txtTheVersion.Size = New System.Drawing.Size(200, 20)
Me.txtTheVersion.TabIndex = 6
Me.txtTheVersion.Text = "" 
Me.lblThePlatform.Location = New System.Drawing.Point(20,146)
Me.lblThePlatform.name = "lblThePlatform"
Me.lblThePlatform.Size = New System.Drawing.Size(200, 20)
Me.lblThePlatform.TabIndex = 7
Me.lblThePlatform.Text = "Платформа реализации"
Me.lblThePlatform.ForeColor = System.Drawing.Color.Blue
Me.cmbThePlatform.Location = New System.Drawing.Point(20,168)
Me.cmbThePlatform.name = "cmbThePlatform"
Me.cmbThePlatform.Size = New System.Drawing.Size(200,  20)
Me.cmbThePlatform.TabIndex = 8
Me.cmbThePlatform.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblTheComment.Location = New System.Drawing.Point(20,193)
Me.lblTheComment.name = "lblTheComment"
Me.lblTheComment.Size = New System.Drawing.Size(200, 20)
Me.lblTheComment.TabIndex = 9
Me.lblTheComment.Text = "Примечание"
Me.lblTheComment.ForeColor = System.Drawing.Color.Blue
Me.txtTheComment.Location = New System.Drawing.Point(20,215)
Me.txtTheComment.name = "txtTheComment"
Me.txtTheComment.MultiLine = True
Me.txtTheComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTheComment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtTheComment.TabIndex = 10
Me.txtTheComment.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheVersion)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheVersion)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThePlatform)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbThePlatform)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheComment)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editWorkPlace"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
  Changing

end sub
private sub txtTheVersion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheVersion.TextChanged
  Changing

end sub
private sub cmbThePlatform_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbThePlatform.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheComment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheComment.TextChanged
  Changing

end sub

Public Item As MTZwp.MTZwp.WorkPlace
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZwp.MTZwp.WorkPlace)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
txtCaption.text = item.Caption
txtTheVersion.text = item.TheVersion
cmbThePlatformData = New DataTable
cmbThePlatformData.Columns.Add("name", GetType(System.String))
cmbThePlatformData.Columns.Add("Value", GetType(System.Int32))
try
cmbThePlatformDataRow = cmbThePlatformData.NewRow
cmbThePlatformDataRow("name") = "VB6"
cmbThePlatformDataRow("Value") = 0
cmbThePlatformData.Rows.Add (cmbThePlatformDataRow)
cmbThePlatformDataRow = cmbThePlatformData.NewRow
cmbThePlatformDataRow("name") = "DOTNET"
cmbThePlatformDataRow("Value") = 1
cmbThePlatformData.Rows.Add (cmbThePlatformDataRow)
cmbThePlatformDataRow = cmbThePlatformData.NewRow
cmbThePlatformDataRow("name") = "JAVA"
cmbThePlatformDataRow("Value") = 2
cmbThePlatformData.Rows.Add (cmbThePlatformDataRow)
cmbThePlatformDataRow = cmbThePlatformData.NewRow
cmbThePlatformDataRow("name") = "OTHER"
cmbThePlatformDataRow("Value") = 3
cmbThePlatformData.Rows.Add (cmbThePlatformDataRow)
cmbThePlatform.DisplayMember = "name"
cmbThePlatform.ValueMember = "Value"
cmbThePlatform.DataSource = cmbThePlatformData
 cmbThePlatform.SelectedValue=CInt(Item.ThePlatform)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtTheComment.text = item.TheComment
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

item.Name = txtName.text
item.Caption = txtCaption.text
item.TheVersion = txtTheVersion.text
   item.ThePlatform = cmbThePlatform.SelectedValue
item.TheComment = txtTheComment.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =( txtCaption.text <> "" ) 
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
