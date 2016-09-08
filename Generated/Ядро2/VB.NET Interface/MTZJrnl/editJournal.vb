
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Журнал режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editJournal
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
Friend WithEvents lblthe_Alias  as  System.Windows.Forms.Label
Friend WithEvents txtthe_Alias As System.Windows.Forms.TextBox
Friend WithEvents lblTheComment  as  System.Windows.Forms.Label
Friend WithEvents txtTheComment As System.Windows.Forms.TextBox
Friend WithEvents lbljrnlIconCls  as  System.Windows.Forms.Label
Friend WithEvents txtjrnlIconCls As System.Windows.Forms.TextBox
Friend WithEvents lblUseFavorites  as  System.Windows.Forms.Label
Friend WithEvents cmbUseFavorites As System.Windows.Forms.ComboBox
Friend cmbUseFavoritesDATA As DataTable
Friend cmbUseFavoritesDATAROW As DataRow

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
Me.lblthe_Alias = New System.Windows.Forms.Label
Me.txtthe_Alias = New System.Windows.Forms.TextBox
Me.lblTheComment = New System.Windows.Forms.Label
Me.txtTheComment = New System.Windows.Forms.TextBox
Me.lbljrnlIconCls = New System.Windows.Forms.Label
Me.txtjrnlIconCls = New System.Windows.Forms.TextBox
Me.lblUseFavorites = New System.Windows.Forms.Label
Me.cmbUseFavorites = New System.Windows.Forms.ComboBox

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
Me.lblthe_Alias.Location = New System.Drawing.Point(20,52)
Me.lblthe_Alias.name = "lblthe_Alias"
Me.lblthe_Alias.Size = New System.Drawing.Size(200, 20)
Me.lblthe_Alias.TabIndex = 3
Me.lblthe_Alias.Text = "Псевдоним"
Me.lblthe_Alias.ForeColor = System.Drawing.Color.Blue
Me.txtthe_Alias.Location = New System.Drawing.Point(20,74)
Me.txtthe_Alias.name = "txtthe_Alias"
Me.txtthe_Alias.Size = New System.Drawing.Size(200, 20)
Me.txtthe_Alias.TabIndex = 4
Me.txtthe_Alias.Text = "" 
Me.lblTheComment.Location = New System.Drawing.Point(20,99)
Me.lblTheComment.name = "lblTheComment"
Me.lblTheComment.Size = New System.Drawing.Size(200, 20)
Me.lblTheComment.TabIndex = 5
Me.lblTheComment.Text = "Описание"
Me.lblTheComment.ForeColor = System.Drawing.Color.Blue
Me.txtTheComment.Location = New System.Drawing.Point(20,121)
Me.txtTheComment.name = "txtTheComment"
Me.txtTheComment.MultiLine = True
Me.txtTheComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtTheComment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtTheComment.TabIndex = 6
Me.txtTheComment.Text = "" 
Me.lbljrnlIconCls.Location = New System.Drawing.Point(20,191)
Me.lbljrnlIconCls.name = "lbljrnlIconCls"
Me.lbljrnlIconCls.Size = New System.Drawing.Size(200, 20)
Me.lbljrnlIconCls.TabIndex = 7
Me.lbljrnlIconCls.Text = "Иконка журнала"
Me.lbljrnlIconCls.ForeColor = System.Drawing.Color.Blue
Me.txtjrnlIconCls.Location = New System.Drawing.Point(20,213)
Me.txtjrnlIconCls.name = "txtjrnlIconCls"
Me.txtjrnlIconCls.Size = New System.Drawing.Size(200, 20)
Me.txtjrnlIconCls.TabIndex = 8
Me.txtjrnlIconCls.Text = "" 
Me.lblUseFavorites.Location = New System.Drawing.Point(20,238)
Me.lblUseFavorites.name = "lblUseFavorites"
Me.lblUseFavorites.Size = New System.Drawing.Size(200, 20)
Me.lblUseFavorites.TabIndex = 9
Me.lblUseFavorites.Text = "Массовое выделение"
Me.lblUseFavorites.ForeColor = System.Drawing.Color.Black
Me.cmbUseFavorites.Location = New System.Drawing.Point(20,260)
Me.cmbUseFavorites.name = "cmbUseFavorites"
Me.cmbUseFavorites.Size = New System.Drawing.Size(200,  20)
Me.cmbUseFavorites.TabIndex = 10
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_Alias)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_Alias)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheComment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbljrnlIconCls)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtjrnlIconCls)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblUseFavorites)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbUseFavorites)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editJournal"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtthe_Alias_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_Alias.TextChanged
  Changing

end sub
private sub txtTheComment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheComment.TextChanged
  Changing

end sub
private sub txtjrnlIconCls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtjrnlIconCls.TextChanged
  Changing

end sub
private sub cmbUseFavorites_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUseFavorites.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As MTZJrnl.MTZJrnl.Journal
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZJrnl.MTZJrnl.Journal)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtName.text = item.Name
txtthe_Alias.text = item.the_Alias
txtTheComment.text = item.TheComment
txtjrnlIconCls.text = item.jrnlIconCls
cmbUseFavoritesData = New DataTable
cmbUseFavoritesData.Columns.Add("name", GetType(System.String))
cmbUseFavoritesData.Columns.Add("Value", GetType(System.Int32))
try
cmbUseFavoritesDataRow = cmbUseFavoritesData.NewRow
cmbUseFavoritesDataRow("name") = "Да"
cmbUseFavoritesDataRow("Value") = -1
cmbUseFavoritesData.Rows.Add (cmbUseFavoritesDataRow)
cmbUseFavoritesDataRow = cmbUseFavoritesData.NewRow
cmbUseFavoritesDataRow("name") = "Нет"
cmbUseFavoritesDataRow("Value") = 0
cmbUseFavoritesData.Rows.Add (cmbUseFavoritesDataRow)
cmbUseFavorites.DisplayMember = "name"
cmbUseFavorites.ValueMember = "Value"
cmbUseFavorites.DataSource = cmbUseFavoritesData
 cmbUseFavorites.SelectedValue=CInt(Item.UseFavorites)
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

item.Name = txtName.text
item.the_Alias = txtthe_Alias.text
item.TheComment = txtTheComment.text
item.jrnlIconCls = txtjrnlIconCls.text
   item.UseFavorites = cmbUseFavorites.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =(cmbUseFavorites.SelectedIndex >=0)
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
