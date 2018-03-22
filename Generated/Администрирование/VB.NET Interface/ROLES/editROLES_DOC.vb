
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Доступные документы режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editROLES_DOC
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
Friend WithEvents lblThe_Document  as  System.Windows.Forms.Label
Friend WithEvents txtThe_Document As System.Windows.Forms.TextBox
Friend WithEvents cmdThe_Document As System.Windows.Forms.Button
Friend WithEvents lblThe_Denied  as  System.Windows.Forms.Label
Friend WithEvents cmbThe_Denied As System.Windows.Forms.ComboBox
Friend cmbThe_DeniedDATA As DataTable
Friend cmbThe_DeniedDATAROW As DataRow
Friend WithEvents lblAllowDeleteDoc  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowDeleteDoc As System.Windows.Forms.ComboBox
Friend cmbAllowDeleteDocDATA As DataTable
Friend cmbAllowDeleteDocDATAROW As DataRow

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
Me.lblThe_Document = New System.Windows.Forms.Label
Me.txtThe_Document = New System.Windows.Forms.TextBox
Me.cmdThe_Document = New System.Windows.Forms.Button
Me.lblThe_Denied = New System.Windows.Forms.Label
Me.cmbThe_Denied = New System.Windows.Forms.ComboBox
Me.lblAllowDeleteDoc = New System.Windows.Forms.Label
Me.cmbAllowDeleteDoc = New System.Windows.Forms.ComboBox

Me.lblThe_Document.Location = New System.Drawing.Point(20,5)
Me.lblThe_Document.name = "lblThe_Document"
Me.lblThe_Document.Size = New System.Drawing.Size(200, 20)
Me.lblThe_Document.TabIndex = 1
Me.lblThe_Document.Text = "Тип документа"
Me.lblThe_Document.ForeColor = System.Drawing.Color.Black
Me.txtThe_Document.Location = New System.Drawing.Point(20,27)
Me.txtThe_Document.name = "txtThe_Document"
Me.txtThe_Document.ReadOnly = True
Me.txtThe_Document.Size = New System.Drawing.Size(176, 20)
Me.txtThe_Document.TabIndex = 2
Me.txtThe_Document.Text = "" 
Me.cmdThe_Document.Location = New System.Drawing.Point(198,27)
Me.cmdThe_Document.name = "cmdThe_Document"
Me.cmdThe_Document.Size = New System.Drawing.Size(22, 20)
Me.cmdThe_Document.TabIndex = 3
Me.cmdThe_Document.Text = "..." 
Me.lblThe_Denied.Location = New System.Drawing.Point(20,52)
Me.lblThe_Denied.name = "lblThe_Denied"
Me.lblThe_Denied.Size = New System.Drawing.Size(200, 20)
Me.lblThe_Denied.TabIndex = 4
Me.lblThe_Denied.Text = "Запрещен"
Me.lblThe_Denied.ForeColor = System.Drawing.Color.Blue
Me.cmbThe_Denied.Location = New System.Drawing.Point(20,74)
Me.cmbThe_Denied.name = "cmbThe_Denied"
Me.cmbThe_Denied.Size = New System.Drawing.Size(200,  20)
Me.cmbThe_Denied.TabIndex = 5
Me.lblAllowDeleteDoc.Location = New System.Drawing.Point(20,99)
Me.lblAllowDeleteDoc.name = "lblAllowDeleteDoc"
Me.lblAllowDeleteDoc.Size = New System.Drawing.Size(200, 20)
Me.lblAllowDeleteDoc.TabIndex = 6
Me.lblAllowDeleteDoc.Text = "Разрешено удаление"
Me.lblAllowDeleteDoc.ForeColor = System.Drawing.Color.Black
Me.cmbAllowDeleteDoc.Location = New System.Drawing.Point(20,121)
Me.cmbAllowDeleteDoc.name = "cmbAllowDeleteDoc"
Me.cmbAllowDeleteDoc.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowDeleteDoc.TabIndex = 7
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThe_Document)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtThe_Document)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdThe_Document)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThe_Denied)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbThe_Denied)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowDeleteDoc)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowDeleteDoc)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editROLES_DOC"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtThe_Document_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThe_Document.TextChanged
  Changing

end sub
private sub cmdThe_Document_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThe_Document.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("OBJECTTYPE","",System.guid.Empty, id, brief) Then
          txtThe_Document.Tag = id
          txtThe_Document.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbThe_Denied_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbThe_Denied.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowDeleteDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowDeleteDoc.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As ROLES.ROLES.ROLES_DOC
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,ROLES.ROLES.ROLES_DOC)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.The_Document Is Nothing Then
  txtThe_Document.Tag = item.The_Document.id
  txtThe_Document.text = item.The_Document.brief
else
  txtThe_Document.Tag = System.Guid.Empty 
  txtThe_Document.text = "" 
End If
cmbThe_DeniedData = New DataTable
cmbThe_DeniedData.Columns.Add("name", GetType(System.String))
cmbThe_DeniedData.Columns.Add("Value", GetType(System.Int32))
try
cmbThe_DeniedDataRow = cmbThe_DeniedData.NewRow
cmbThe_DeniedDataRow("name") = "Нет"
cmbThe_DeniedDataRow("Value") = 0
cmbThe_DeniedData.Rows.Add (cmbThe_DeniedDataRow)
cmbThe_DeniedDataRow = cmbThe_DeniedData.NewRow
cmbThe_DeniedDataRow("name") = "Да"
cmbThe_DeniedDataRow("Value") = 1
cmbThe_DeniedData.Rows.Add (cmbThe_DeniedDataRow)
cmbThe_Denied.DisplayMember = "name"
cmbThe_Denied.ValueMember = "Value"
cmbThe_Denied.DataSource = cmbThe_DeniedData
 cmbThe_Denied.SelectedValue=CInt(Item.The_Denied)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbAllowDeleteDocData = New DataTable
cmbAllowDeleteDocData.Columns.Add("name", GetType(System.String))
cmbAllowDeleteDocData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowDeleteDocDataRow = cmbAllowDeleteDocData.NewRow
cmbAllowDeleteDocDataRow("name") = "Да"
cmbAllowDeleteDocDataRow("Value") = -1
cmbAllowDeleteDocData.Rows.Add (cmbAllowDeleteDocDataRow)
cmbAllowDeleteDocDataRow = cmbAllowDeleteDocData.NewRow
cmbAllowDeleteDocDataRow("name") = "Нет"
cmbAllowDeleteDocDataRow("Value") = 0
cmbAllowDeleteDocData.Rows.Add (cmbAllowDeleteDocDataRow)
cmbAllowDeleteDoc.DisplayMember = "name"
cmbAllowDeleteDoc.ValueMember = "Value"
cmbAllowDeleteDoc.DataSource = cmbAllowDeleteDocData
 cmbAllowDeleteDoc.SelectedValue=CInt(Item.AllowDeleteDoc)
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

If not txtThe_Document.Tag.Equals(System.Guid.Empty) Then
  item.The_Document = Item.Application.FindRowObject("OBJECTTYPE",txtThe_Document.Tag)
Else
   item.The_Document = Nothing
End If
   item.The_Denied = cmbThe_Denied.SelectedValue
   item.AllowDeleteDoc = cmbAllowDeleteDoc.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtThe_Document.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbAllowDeleteDoc.SelectedIndex >=0)
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
