
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Состояния режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editOBJSTATUS
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
Friend WithEvents txtname As System.Windows.Forms.TextBox
Friend WithEvents lblisStartup  as  System.Windows.Forms.Label
Friend WithEvents cmbisStartup As System.Windows.Forms.ComboBox
Friend cmbisStartupDATA As DataTable
Friend cmbisStartupDATAROW As DataRow
Friend WithEvents lblIsArchive  as  System.Windows.Forms.Label
Friend WithEvents cmbIsArchive As System.Windows.Forms.ComboBox
Friend cmbIsArchiveDATA As DataTable
Friend cmbIsArchiveDATAROW As DataRow
Friend WithEvents lblthe_comment  as  System.Windows.Forms.Label
Friend WithEvents txtthe_comment As System.Windows.Forms.TextBox

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
Me.txtname = New System.Windows.Forms.TextBox
Me.lblisStartup = New System.Windows.Forms.Label
Me.cmbisStartup = New System.Windows.Forms.ComboBox
Me.lblIsArchive = New System.Windows.Forms.Label
Me.cmbIsArchive = New System.Windows.Forms.ComboBox
Me.lblthe_comment = New System.Windows.Forms.Label
Me.txtthe_comment = New System.Windows.Forms.TextBox

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
Me.lblisStartup.Location = New System.Drawing.Point(20,52)
Me.lblisStartup.name = "lblisStartup"
Me.lblisStartup.Size = New System.Drawing.Size(200, 20)
Me.lblisStartup.TabIndex = 3
Me.lblisStartup.Text = "Начальное"
Me.lblisStartup.ForeColor = System.Drawing.Color.Black
Me.cmbisStartup.Location = New System.Drawing.Point(20,74)
Me.cmbisStartup.name = "cmbisStartup"
Me.cmbisStartup.Size = New System.Drawing.Size(200,  20)
Me.cmbisStartup.TabIndex = 4
Me.lblIsArchive.Location = New System.Drawing.Point(20,99)
Me.lblIsArchive.name = "lblIsArchive"
Me.lblIsArchive.Size = New System.Drawing.Size(200, 20)
Me.lblIsArchive.TabIndex = 5
Me.lblIsArchive.Text = "Архивное"
Me.lblIsArchive.ForeColor = System.Drawing.Color.Black
Me.cmbIsArchive.Location = New System.Drawing.Point(20,121)
Me.cmbIsArchive.name = "cmbIsArchive"
Me.cmbIsArchive.Size = New System.Drawing.Size(200,  20)
Me.cmbIsArchive.TabIndex = 6
Me.lblthe_comment.Location = New System.Drawing.Point(20,146)
Me.lblthe_comment.name = "lblthe_comment"
Me.lblthe_comment.Size = New System.Drawing.Size(200, 20)
Me.lblthe_comment.TabIndex = 7
Me.lblthe_comment.Text = "Описание"
Me.lblthe_comment.ForeColor = System.Drawing.Color.Blue
Me.txtthe_comment.Location = New System.Drawing.Point(20,168)
Me.txtthe_comment.name = "txtthe_comment"
Me.txtthe_comment.MultiLine = True
Me.txtthe_comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtthe_comment.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtthe_comment.TabIndex = 8
Me.txtthe_comment.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblisStartup)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbisStartup)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsArchive)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsArchive)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblthe_comment)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtthe_comment)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editOBJSTATUS"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub cmbisStartup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbisStartup.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbIsArchive_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsArchive.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtthe_comment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtthe_comment.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.OBJSTATUS
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.OBJSTATUS)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtname.text = item.name
cmbisStartupData = New DataTable
cmbisStartupData.Columns.Add("name", GetType(System.String))
cmbisStartupData.Columns.Add("Value", GetType(System.Int32))
try
cmbisStartupDataRow = cmbisStartupData.NewRow
cmbisStartupDataRow("name") = "Да"
cmbisStartupDataRow("Value") = -1
cmbisStartupData.Rows.Add (cmbisStartupDataRow)
cmbisStartupDataRow = cmbisStartupData.NewRow
cmbisStartupDataRow("name") = "Нет"
cmbisStartupDataRow("Value") = 0
cmbisStartupData.Rows.Add (cmbisStartupDataRow)
cmbisStartup.DisplayMember = "name"
cmbisStartup.ValueMember = "Value"
cmbisStartup.DataSource = cmbisStartupData
 cmbisStartup.SelectedValue=CInt(Item.isStartup)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbIsArchiveData = New DataTable
cmbIsArchiveData.Columns.Add("name", GetType(System.String))
cmbIsArchiveData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsArchiveDataRow = cmbIsArchiveData.NewRow
cmbIsArchiveDataRow("name") = "Да"
cmbIsArchiveDataRow("Value") = -1
cmbIsArchiveData.Rows.Add (cmbIsArchiveDataRow)
cmbIsArchiveDataRow = cmbIsArchiveData.NewRow
cmbIsArchiveDataRow("name") = "Нет"
cmbIsArchiveDataRow("Value") = 0
cmbIsArchiveData.Rows.Add (cmbIsArchiveDataRow)
cmbIsArchive.DisplayMember = "name"
cmbIsArchive.ValueMember = "Value"
cmbIsArchive.DataSource = cmbIsArchiveData
 cmbIsArchive.SelectedValue=CInt(Item.IsArchive)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtthe_comment.text = item.the_comment
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
   item.isStartup = cmbisStartup.SelectedValue
   item.IsArchive = cmbIsArchive.SelectedValue
item.the_comment = txtthe_comment.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtname.text <> "" ) 
if mIsOK then mIsOK =(cmbisStartup.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbIsArchive.SelectedIndex >=0)
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
