
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Журнал режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editjournal
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
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthe_alias  as  System.Windows.Forms.Label
Friend WithEvents txtthe_alias As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblthecomment  as  System.Windows.Forms.Label
Friend WithEvents txtthecomment As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbljrnliconcls  as  System.Windows.Forms.Label
Friend WithEvents txtjrnliconcls As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblusefavorites  as  System.Windows.Forms.Label
Friend WithEvents cmbusefavorites As System.Windows.Forms.ComboBox
Friend cmbusefavoritesDATA As DataTable
Friend cmbusefavoritesDATAROW As DataRow

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
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New LATIR2GuiManager.TouchTextBox
Me.lblthe_alias = New System.Windows.Forms.Label
Me.txtthe_alias = New LATIR2GuiManager.TouchTextBox
Me.lblthecomment = New System.Windows.Forms.Label
Me.txtthecomment = New LATIR2GuiManager.TouchTextBox
Me.lbljrnliconcls = New System.Windows.Forms.Label
Me.txtjrnliconcls = New LATIR2GuiManager.TouchTextBox
Me.lblusefavorites = New System.Windows.Forms.Label
Me.cmbusefavorites = New System.Windows.Forms.ComboBox

Me.lblname.Location = New System.Drawing.Point(20,5)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 1
Me.lblname.Text = "Название"
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,27)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 2
Me.txtname.Text = "" 
Me.lblthe_alias.Location = New System.Drawing.Point(20,52)
Me.lblthe_alias.name = "lblthe_alias"
Me.lblthe_alias.Size = New System.Drawing.Size(200, 20)
Me.lblthe_alias.TabIndex = 3
Me.lblthe_alias.Text = "Псевдоним"
Me.lblthe_alias.ForeColor = System.Drawing.Color.Blue
Me.txtthe_alias.Location = New System.Drawing.Point(20,74)
Me.txtthe_alias.name = "txtthe_alias"
Me.txtthe_alias.Size = New System.Drawing.Size(200, 20)
Me.txtthe_alias.TabIndex = 4
Me.txtthe_alias.Text = "" 
Me.lblthecomment.Location = New System.Drawing.Point(20,99)
Me.lblthecomment.name = "lblthecomment"
Me.lblthecomment.Size = New System.Drawing.Size(200, 20)
Me.lblthecomment.TabIndex = 5
Me.lblthecomment.Text = "Описание"
Me.lblthecomment.ForeColor = System.Drawing.Color.Blue
Me.txtthecomment.Location = New System.Drawing.Point(20,121)
Me.txtthecomment.name = "txtthecomment"
Me.txtthecomment.MultiLine = True
Me.txtthecomment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtthecomment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtthecomment.TabIndex = 6
Me.txtthecomment.Text = "" 
Me.lbljrnliconcls.Location = New System.Drawing.Point(20,191)
Me.lbljrnliconcls.name = "lbljrnliconcls"
Me.lbljrnliconcls.Size = New System.Drawing.Size(200, 20)
Me.lbljrnliconcls.TabIndex = 7
Me.lbljrnliconcls.Text = "Иконка журнала"
Me.lbljrnliconcls.ForeColor = System.Drawing.Color.Blue
Me.txtjrnliconcls.Location = New System.Drawing.Point(20,213)
Me.txtjrnliconcls.name = "txtjrnliconcls"
Me.txtjrnliconcls.Size = New System.Drawing.Size(200, 20)
Me.txtjrnliconcls.TabIndex = 8
Me.txtjrnliconcls.Text = "" 
Me.lblusefavorites.Location = New System.Drawing.Point(20,238)
Me.lblusefavorites.name = "lblusefavorites"
Me.lblusefavorites.Size = New System.Drawing.Size(200, 20)
Me.lblusefavorites.TabIndex = 9
Me.lblusefavorites.Text = "Массовое выделение"
Me.lblusefavorites.ForeColor = System.Drawing.Color.Black
Me.cmbusefavorites.Location = New System.Drawing.Point(20,260)
Me.cmbusefavorites.name = "cmbusefavorites"
Me.cmbusefavorites.Size = New System.Drawing.Size(200,  20)
Me.cmbusefavorites.TabIndex = 10
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_alias)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_alias)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthecomment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthecomment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbljrnliconcls)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtjrnliconcls)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblusefavorites)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbusefavorites)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editjournal"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub txtthe_alias_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_alias.TextChanged
  Changing

end sub
private sub txtthecomment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthecomment.TextChanged
  Changing

end sub
private sub txtjrnliconcls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtjrnliconcls.TextChanged
  Changing

end sub
private sub cmbusefavorites_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbusefavorites.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As mtzjrnl.mtzjrnl.journal
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,mtzjrnl.mtzjrnl.journal)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtname.text = item.name
txtthe_alias.text = item.the_alias
txtthecomment.text = item.thecomment
txtjrnliconcls.text = item.jrnliconcls
cmbusefavoritesData = New DataTable
cmbusefavoritesData.Columns.Add("name", GetType(System.String))
cmbusefavoritesData.Columns.Add("Value", GetType(System.Int32))
try
cmbusefavoritesDataRow = cmbusefavoritesData.NewRow
cmbusefavoritesDataRow("name") = "Да"
cmbusefavoritesDataRow("Value") = -1
cmbusefavoritesData.Rows.Add (cmbusefavoritesDataRow)
cmbusefavoritesDataRow = cmbusefavoritesData.NewRow
cmbusefavoritesDataRow("name") = "Нет"
cmbusefavoritesDataRow("Value") = 0
cmbusefavoritesData.Rows.Add (cmbusefavoritesDataRow)
cmbusefavorites.DisplayMember = "name"
cmbusefavorites.ValueMember = "Value"
cmbusefavorites.DataSource = cmbusefavoritesData
 cmbusefavorites.SelectedValue=CInt(Item.usefavorites)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
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

item.name = txtname.text
item.the_alias = txtthe_alias.text
item.thecomment = txtthecomment.text
item.jrnliconcls = txtjrnliconcls.text
   item.usefavorites = cmbusefavorites.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtname.text <> "" ) 
if mIsOK then mIsOK =(cmbusefavorites.SelectedIndex >=0)
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
