
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Разрешенные владельцы режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editSysRefCache
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
Friend WithEvents lblCacheType  as  System.Windows.Forms.Label
Friend WithEvents cmbCacheType As System.Windows.Forms.ComboBox
Friend cmbCacheTypeDATA As DataTable
Friend cmbCacheTypeDATAROW As DataRow
Friend WithEvents lblObjectOwnerID  as  System.Windows.Forms.Label
Friend WithEvents txtObjectOwnerID As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblSessionID  as  System.Windows.Forms.Label
Friend WithEvents txtSessionID As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdSessionID As System.Windows.Forms.Button
Friend WithEvents lblmodulename  as  System.Windows.Forms.Label
Friend WithEvents txtmodulename As LATIR2GuiManager.TouchTextBox

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
Me.lblCacheType = New System.Windows.Forms.Label
Me.cmbCacheType = New System.Windows.Forms.ComboBox
Me.lblObjectOwnerID = New System.Windows.Forms.Label
Me.txtObjectOwnerID = New LATIR2GuiManager.TouchTextBox
Me.lblSessionID = New System.Windows.Forms.Label
Me.txtSessionID = New LATIR2GuiManager.TouchTextBox
Me.cmdSessionID = New System.Windows.Forms.Button
Me.lblmodulename = New System.Windows.Forms.Label
Me.txtmodulename = New LATIR2GuiManager.TouchTextBox

Me.lblCacheType.Location = New System.Drawing.Point(20,5)
Me.lblCacheType.name = "lblCacheType"
Me.lblCacheType.Size = New System.Drawing.Size(200, 20)
Me.lblCacheType.TabIndex = 1
Me.lblCacheType.Text = "Тип кеширования"
Me.lblCacheType.ForeColor = System.Drawing.Color.Black
Me.cmbCacheType.Location = New System.Drawing.Point(20,27)
Me.cmbCacheType.name = "cmbCacheType"
Me.cmbCacheType.Size = New System.Drawing.Size(200,  20)
Me.cmbCacheType.TabIndex = 2
Me.cmbCacheType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblObjectOwnerID.Location = New System.Drawing.Point(20,52)
Me.lblObjectOwnerID.name = "lblObjectOwnerID"
Me.lblObjectOwnerID.Size = New System.Drawing.Size(200, 20)
Me.lblObjectOwnerID.TabIndex = 3
Me.lblObjectOwnerID.Text = "Идентификатор владельца"
Me.lblObjectOwnerID.ForeColor = System.Drawing.Color.Black
Me.txtObjectOwnerID.Location = New System.Drawing.Point(20,74)
Me.txtObjectOwnerID.name = "txtObjectOwnerID"
Me.txtObjectOwnerID.Size = New System.Drawing.Size(200, 20)
Me.txtObjectOwnerID.TabIndex = 4
Me.txtObjectOwnerID.Text = "" 
Me.lblSessionID.Location = New System.Drawing.Point(20,99)
Me.lblSessionID.name = "lblSessionID"
Me.lblSessionID.Size = New System.Drawing.Size(200, 20)
Me.lblSessionID.TabIndex = 5
Me.lblSessionID.Text = "Сессия"
Me.lblSessionID.ForeColor = System.Drawing.Color.Black
Me.txtSessionID.Location = New System.Drawing.Point(20,121)
Me.txtSessionID.name = "txtSessionID"
Me.txtSessionID.ReadOnly = True
Me.txtSessionID.Size = New System.Drawing.Size(176, 20)
Me.txtSessionID.TabIndex = 6
Me.txtSessionID.Text = "" 
Me.cmdSessionID.Location = New System.Drawing.Point(198,121)
Me.cmdSessionID.name = "cmdSessionID"
Me.cmdSessionID.Size = New System.Drawing.Size(22, 20)
Me.cmdSessionID.TabIndex = 7
Me.cmdSessionID.Text = "..." 
Me.lblmodulename.Location = New System.Drawing.Point(20,146)
Me.lblmodulename.name = "lblmodulename"
Me.lblmodulename.Size = New System.Drawing.Size(200, 20)
Me.lblmodulename.TabIndex = 8
Me.lblmodulename.Text = "модуль"
Me.lblmodulename.ForeColor = System.Drawing.Color.Blue
Me.txtmodulename.Location = New System.Drawing.Point(20,168)
Me.txtmodulename.name = "txtmodulename"
Me.txtmodulename.Size = New System.Drawing.Size(200, 20)
Me.txtmodulename.TabIndex = 9
Me.txtmodulename.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCacheType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbCacheType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblObjectOwnerID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtObjectOwnerID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSessionID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSessionID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdSessionID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblmodulename)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtmodulename)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editSysRefCache"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub cmbCacheType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCacheType.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtObjectOwnerID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObjectOwnerID.TextChanged
  Changing

end sub
private sub txtSessionID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSessionID.TextChanged
  Changing

end sub
private sub cmdSessionID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSessionID.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("the_Session","",System.guid.Empty, id, brief) Then
          txtSessionID.Tag = id
          txtSessionID.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtmodulename_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmodulename.TextChanged
  Changing

end sub

Public Item As MTZSystem.MTZSystem.SysRefCache
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZSystem.MTZSystem.SysRefCache)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

cmbCacheTypeData = New DataTable
cmbCacheTypeData.Columns.Add("name", GetType(System.String))
cmbCacheTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbCacheTypeDataRow = cmbCacheTypeData.NewRow
cmbCacheTypeDataRow("name") = "Только свои"
cmbCacheTypeDataRow("Value") = 0
cmbCacheTypeData.Rows.Add (cmbCacheTypeDataRow)
cmbCacheTypeDataRow = cmbCacheTypeData.NewRow
cmbCacheTypeDataRow("name") = "Подчиненные"
cmbCacheTypeDataRow("Value") = 1
cmbCacheTypeData.Rows.Add (cmbCacheTypeDataRow)
cmbCacheTypeDataRow = cmbCacheTypeData.NewRow
cmbCacheTypeDataRow("name") = "Все"
cmbCacheTypeDataRow("Value") = 2
cmbCacheTypeData.Rows.Add (cmbCacheTypeDataRow)
cmbCacheType.DisplayMember = "name"
cmbCacheType.ValueMember = "Value"
cmbCacheType.DataSource = cmbCacheTypeData
 cmbCacheType.SelectedValue=CInt(Item.CacheType)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtObjectOwnerID.text = item.ObjectOwnerID.ToString()
If Not item.SessionID Is Nothing Then
  txtSessionID.Tag = item.SessionID.id
  txtSessionID.text = item.SessionID.brief
else
  txtSessionID.Tag = System.Guid.Empty 
  txtSessionID.text = "" 
End If
txtmodulename.text = item.modulename
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

   item.CacheType = cmbCacheType.SelectedValue
item.ObjectOwnerID = new System.Guid(txtObjectOwnerID.text)
If not txtSessionID.Tag.Equals(System.Guid.Empty) Then
  item.SessionID = Item.Application.FindRowObject("the_Session",txtSessionID.Tag)
Else
   item.SessionID = Nothing
End If
item.modulename = txtmodulename.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =(cmbCacheType.SelectedIndex >=0)
if mIsOK then mIsOK =( txtObjectOwnerID.text <> "" ) 
if mIsOK then mIsOK = not txtSessionID.Tag.Equals(System.Guid.Empty)
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
