
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



''' <summary>
'''Контрол редактирования раздела Реализации расширения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editMTZExtRel
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

 dim iii as integer
    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel
Friend WithEvents lblThePlatform  as  System.Windows.Forms.Label
Friend WithEvents cmbThePlatform As System.Windows.Forms.ComboBox
Friend cmbThePlatformDATA As DataTable
Friend cmbThePlatformDATAROW As DataRow
Friend WithEvents lblTheClassName  as  System.Windows.Forms.Label
Friend WithEvents txtTheClassName As System.Windows.Forms.TextBox
Friend WithEvents lblTheLibraryName  as  System.Windows.Forms.Label
Friend WithEvents txtTheLibraryName As System.Windows.Forms.TextBox

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
Me.lblThePlatform = New System.Windows.Forms.Label
Me.cmbThePlatform = New System.Windows.Forms.ComboBox
Me.lblTheClassName = New System.Windows.Forms.Label
Me.txtTheClassName = New System.Windows.Forms.TextBox
Me.lblTheLibraryName = New System.Windows.Forms.Label
Me.txtTheLibraryName = New System.Windows.Forms.TextBox

Me.lblThePlatform.Location = New System.Drawing.Point(20,5)
Me.lblThePlatform.name = "lblThePlatform"
Me.lblThePlatform.Size = New System.Drawing.Size(200, 20)
Me.lblThePlatform.TabIndex = 1
Me.lblThePlatform.Text = "Реализация"
Me.lblThePlatform.ForeColor = System.Drawing.Color.Black
Me.cmbThePlatform.Location = New System.Drawing.Point(20,27)
Me.cmbThePlatform.name = "cmbThePlatform"
Me.cmbThePlatform.Size = New System.Drawing.Size(200,  20)
Me.cmbThePlatform.TabIndex = 2
Me.cmbThePlatform.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblTheClassName.Location = New System.Drawing.Point(20,52)
Me.lblTheClassName.name = "lblTheClassName"
Me.lblTheClassName.Size = New System.Drawing.Size(200, 20)
Me.lblTheClassName.TabIndex = 3
Me.lblTheClassName.Text = "Название класса"
Me.lblTheClassName.ForeColor = System.Drawing.Color.Black
Me.txtTheClassName.Location = New System.Drawing.Point(20,74)
Me.txtTheClassName.name = "txtTheClassName"
Me.txtTheClassName.Size = New System.Drawing.Size(200, 20)
Me.txtTheClassName.TabIndex = 4
Me.txtTheClassName.Text = "" 
Me.lblTheLibraryName.Location = New System.Drawing.Point(20,99)
Me.lblTheLibraryName.name = "lblTheLibraryName"
Me.lblTheLibraryName.Size = New System.Drawing.Size(200, 20)
Me.lblTheLibraryName.TabIndex = 5
Me.lblTheLibraryName.Text = "Название библиотеки"
Me.lblTheLibraryName.ForeColor = System.Drawing.Color.Blue
Me.txtTheLibraryName.Location = New System.Drawing.Point(20,121)
Me.txtTheLibraryName.name = "txtTheLibraryName"
Me.txtTheLibraryName.Size = New System.Drawing.Size(200, 20)
Me.txtTheLibraryName.TabIndex = 6
Me.txtTheLibraryName.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThePlatform)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbThePlatform)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheClassName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheClassName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheLibraryName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheLibraryName)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editMTZExtRel"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub cmbThePlatform_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbThePlatform.SelectedIndexChanged
  on error resume next
  Changing

end sub
private sub txtTheClassName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheClassName.TextChanged
  Changing

end sub
private sub txtTheLibraryName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheLibraryName.TextChanged
  Changing

end sub

Public Item As MTZExt.MTZExt.MTZExtRel
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZExt.MTZExt.MTZExtRel)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

cmbThePlatformData = New DataTable
cmbThePlatformData.Columns.Add("name", GetType(System.String))
cmbThePlatformData.Columns.Add("Value", GetType(System.Int32))
On Error Resume Next
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
txtTheClassName.text = item.TheClassName
txtTheLibraryName.text = item.TheLibraryName
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

   item.ThePlatform = cmbThePlatform.SelectedValue
item.TheClassName = txtTheClassName.text
item.TheLibraryName = txtTheLibraryName.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =(cmbThePlatform.SelectedIndex >=0)
if mIsOK then mIsOK =( txtTheClassName.text <> "" ) 
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
