
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Связанные представления режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editPARTVIEW_LNK
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
Friend WithEvents lblTheView  as  System.Windows.Forms.Label
Friend WithEvents txtTheView As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheView As System.Windows.Forms.Button
Friend WithEvents lblTheJoinSource  as  System.Windows.Forms.Label
Friend WithEvents txtTheJoinSource As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheJoinSource As System.Windows.Forms.Button
Friend WithEvents cmdTheJoinSourceClear As System.Windows.Forms.Button
Friend WithEvents lblRefType  as  System.Windows.Forms.Label
Friend WithEvents cmbRefType As System.Windows.Forms.ComboBox
Friend cmbRefTypeDATA As DataTable
Friend cmbRefTypeDATAROW As DataRow
Friend WithEvents lblTheJoinDestination  as  System.Windows.Forms.Label
Friend WithEvents txtTheJoinDestination As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheJoinDestination As System.Windows.Forms.Button
Friend WithEvents cmdTheJoinDestinationClear As System.Windows.Forms.Button
Friend WithEvents lblHandJoin  as  System.Windows.Forms.Label
Friend WithEvents txtHandJoin As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblSEQ  as  System.Windows.Forms.Label
Friend WithEvents txtSEQ As LATIR2GuiManager.TouchTextBox

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
Me.lblTheView = New System.Windows.Forms.Label
Me.txtTheView = New LATIR2GuiManager.TouchTextBox
Me.cmdTheView = New System.Windows.Forms.Button
Me.lblTheJoinSource = New System.Windows.Forms.Label
Me.txtTheJoinSource = New LATIR2GuiManager.TouchTextBox
Me.cmdTheJoinSource = New System.Windows.Forms.Button
Me.cmdTheJoinSourceClear = New System.Windows.Forms.Button
Me.lblRefType = New System.Windows.Forms.Label
Me.cmbRefType = New System.Windows.Forms.ComboBox
Me.lblTheJoinDestination = New System.Windows.Forms.Label
Me.txtTheJoinDestination = New LATIR2GuiManager.TouchTextBox
Me.cmdTheJoinDestination = New System.Windows.Forms.Button
Me.cmdTheJoinDestinationClear = New System.Windows.Forms.Button
Me.lblHandJoin = New System.Windows.Forms.Label
Me.txtHandJoin = New LATIR2GuiManager.TouchTextBox
Me.lblSEQ = New System.Windows.Forms.Label
Me.txtSEQ = New LATIR2GuiManager.TouchTextBox

Me.lblTheView.Location = New System.Drawing.Point(20,5)
Me.lblTheView.name = "lblTheView"
Me.lblTheView.Size = New System.Drawing.Size(200, 20)
Me.lblTheView.TabIndex = 1
Me.lblTheView.Text = "Представление"
Me.lblTheView.ForeColor = System.Drawing.Color.Black
Me.txtTheView.Location = New System.Drawing.Point(20,27)
Me.txtTheView.name = "txtTheView"
Me.txtTheView.ReadOnly = True
Me.txtTheView.Size = New System.Drawing.Size(176, 20)
Me.txtTheView.TabIndex = 2
Me.txtTheView.Text = "" 
Me.cmdTheView.Location = New System.Drawing.Point(198,27)
Me.cmdTheView.name = "cmdTheView"
Me.cmdTheView.Size = New System.Drawing.Size(22, 20)
Me.cmdTheView.TabIndex = 3
Me.cmdTheView.Text = "..." 
Me.lblTheJoinSource.Location = New System.Drawing.Point(20,52)
Me.lblTheJoinSource.name = "lblTheJoinSource"
Me.lblTheJoinSource.Size = New System.Drawing.Size(200, 20)
Me.lblTheJoinSource.TabIndex = 4
Me.lblTheJoinSource.Text = "Связь: Поле для join источник"
Me.lblTheJoinSource.ForeColor = System.Drawing.Color.Blue
Me.txtTheJoinSource.Location = New System.Drawing.Point(20,74)
Me.txtTheJoinSource.name = "txtTheJoinSource"
Me.txtTheJoinSource.ReadOnly = True
Me.txtTheJoinSource.Size = New System.Drawing.Size(155, 20)
Me.txtTheJoinSource.TabIndex = 5
Me.txtTheJoinSource.Text = "" 
Me.cmdTheJoinSource.Location = New System.Drawing.Point(176,74)
Me.cmdTheJoinSource.name = "cmdTheJoinSource"
Me.cmdTheJoinSource.Size = New System.Drawing.Size(22, 20)
Me.cmdTheJoinSource.TabIndex = 6
Me.cmdTheJoinSource.Text = "..." 
Me.cmdTheJoinSourceClear.Location = New System.Drawing.Point(198,74)
Me.cmdTheJoinSourceClear.name = "cmdTheJoinSourceClear"
Me.cmdTheJoinSourceClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTheJoinSourceClear.TabIndex = 7
Me.cmdTheJoinSourceClear.Text = "X" 
Me.lblRefType.Location = New System.Drawing.Point(20,99)
Me.lblRefType.name = "lblRefType"
Me.lblRefType.Size = New System.Drawing.Size(200, 20)
Me.lblRefType.TabIndex = 8
Me.lblRefType.Text = "Связывать как"
Me.lblRefType.ForeColor = System.Drawing.Color.Black
Me.cmbRefType.Location = New System.Drawing.Point(20,121)
Me.cmbRefType.name = "cmbRefType"
Me.cmbRefType.Size = New System.Drawing.Size(200,  20)
Me.cmbRefType.TabIndex = 9
Me.cmbRefType.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblTheJoinDestination.Location = New System.Drawing.Point(20,146)
Me.lblTheJoinDestination.name = "lblTheJoinDestination"
Me.lblTheJoinDestination.Size = New System.Drawing.Size(200, 20)
Me.lblTheJoinDestination.TabIndex = 10
Me.lblTheJoinDestination.Text = "Свзяь: Поле для join приемник"
Me.lblTheJoinDestination.ForeColor = System.Drawing.Color.Blue
Me.txtTheJoinDestination.Location = New System.Drawing.Point(20,168)
Me.txtTheJoinDestination.name = "txtTheJoinDestination"
Me.txtTheJoinDestination.ReadOnly = True
Me.txtTheJoinDestination.Size = New System.Drawing.Size(155, 20)
Me.txtTheJoinDestination.TabIndex = 11
Me.txtTheJoinDestination.Text = "" 
Me.cmdTheJoinDestination.Location = New System.Drawing.Point(176,168)
Me.cmdTheJoinDestination.name = "cmdTheJoinDestination"
Me.cmdTheJoinDestination.Size = New System.Drawing.Size(22, 20)
Me.cmdTheJoinDestination.TabIndex = 12
Me.cmdTheJoinDestination.Text = "..." 
Me.cmdTheJoinDestinationClear.Location = New System.Drawing.Point(198,168)
Me.cmdTheJoinDestinationClear.name = "cmdTheJoinDestinationClear"
Me.cmdTheJoinDestinationClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTheJoinDestinationClear.TabIndex = 13
Me.cmdTheJoinDestinationClear.Text = "X" 
Me.lblHandJoin.Location = New System.Drawing.Point(20,193)
Me.lblHandJoin.name = "lblHandJoin"
Me.lblHandJoin.Size = New System.Drawing.Size(200, 20)
Me.lblHandJoin.TabIndex = 14
Me.lblHandJoin.Text = "Ручной join"
Me.lblHandJoin.ForeColor = System.Drawing.Color.Blue
Me.txtHandJoin.Location = New System.Drawing.Point(20,215)
Me.txtHandJoin.name = "txtHandJoin"
Me.txtHandJoin.Size = New System.Drawing.Size(200, 20)
Me.txtHandJoin.TabIndex = 15
Me.txtHandJoin.Text = "" 
Me.lblSEQ.Location = New System.Drawing.Point(20,240)
Me.lblSEQ.name = "lblSEQ"
Me.lblSEQ.Size = New System.Drawing.Size(200, 20)
Me.lblSEQ.TabIndex = 16
Me.lblSEQ.Text = "Порядок"
Me.lblSEQ.ForeColor = System.Drawing.Color.Black
Me.txtSEQ.Location = New System.Drawing.Point(20,262)
Me.txtSEQ.name = "txtSEQ"
Me.txtSEQ.MultiLine = false
Me.txtSEQ.Size = New System.Drawing.Size(200,  20)
Me.txtSEQ.TabIndex = 17
Me.txtSEQ.Text = "" 
Me.txtSEQ.MaxLength = 15
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheView)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheView)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheView)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheJoinSource)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheJoinSource)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheJoinSource)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheJoinSourceClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRefType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbRefType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheJoinDestination)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheJoinDestination)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheJoinDestination)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheJoinDestinationClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblHandJoin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtHandJoin)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSEQ)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSEQ)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editPARTVIEW_LNK"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheView_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheView.TextChanged
  Changing

end sub
private sub cmdTheView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheView.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("PARTVIEW","",item.application.ID, id, brief) Then
          txtTheView.Tag = id
          txtTheView.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheJoinSource_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheJoinSource.TextChanged
  Changing

end sub
private sub cmdTheJoinSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheJoinSource.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("ViewColumn","",item.application.ID, id, brief) Then
          txtTheJoinSource.Tag = id
          txtTheJoinSource.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdTheJoinSourceClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheJoinSourceClear.Click
  try
          txtTheJoinSource.Tag = Guid.Empty
          txtTheJoinSource.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbRefType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRefType.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheJoinDestination_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheJoinDestination.TextChanged
  Changing

end sub
private sub cmdTheJoinDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheJoinDestination.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("ViewColumn","",item.application.ID, id, brief) Then
          txtTheJoinDestination.Tag = id
          txtTheJoinDestination.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdTheJoinDestinationClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheJoinDestinationClear.Click
  try
          txtTheJoinDestination.Tag = Guid.Empty
          txtTheJoinDestination.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtHandJoin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHandJoin.TextChanged
  Changing

end sub
        Private Sub txtSEQ_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSEQ.Validating
        If txtSEQ.Text <> "" Then
            try
            If Not IsNumeric(txtSEQ.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtSEQ.Text) < -2000000000 Or Val(txtSEQ.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtSEQ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSEQ.TextChanged
  Changing

end sub

Public Item As MTZMetaModel.MTZMetaModel.PARTVIEW_LNK
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZMetaModel.MTZMetaModel.PARTVIEW_LNK)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.TheView Is Nothing Then
  txtTheView.Tag = item.TheView.id
  txtTheView.text = item.TheView.brief
else
  txtTheView.Tag = System.Guid.Empty 
  txtTheView.text = "" 
End If
If Not item.TheJoinSource Is Nothing Then
  txtTheJoinSource.Tag = item.TheJoinSource.id
  txtTheJoinSource.text = item.TheJoinSource.brief
else
  txtTheJoinSource.Tag = System.Guid.Empty 
  txtTheJoinSource.text = "" 
End If
cmbRefTypeData = New DataTable
cmbRefTypeData.Columns.Add("name", GetType(System.String))
cmbRefTypeData.Columns.Add("Value", GetType(System.Int32))
try
cmbRefTypeDataRow = cmbRefTypeData.NewRow
cmbRefTypeDataRow("name") = "Нет"
cmbRefTypeDataRow("Value") = 0
cmbRefTypeData.Rows.Add (cmbRefTypeDataRow)
cmbRefTypeDataRow = cmbRefTypeData.NewRow
cmbRefTypeDataRow("name") = "Ссылка на объект"
cmbRefTypeDataRow("Value") = 1
cmbRefTypeData.Rows.Add (cmbRefTypeDataRow)
cmbRefTypeDataRow = cmbRefTypeData.NewRow
cmbRefTypeDataRow("name") = "Ссылка на строку"
cmbRefTypeDataRow("Value") = 2
cmbRefTypeData.Rows.Add (cmbRefTypeDataRow)
cmbRefTypeDataRow = cmbRefTypeData.NewRow
cmbRefTypeDataRow("name") = "Связка InstanceID (в передлах объекта)"
cmbRefTypeDataRow("Value") = 3
cmbRefTypeData.Rows.Add (cmbRefTypeDataRow)
cmbRefTypeDataRow = cmbRefTypeData.NewRow
cmbRefTypeDataRow("name") = "Связка ParentStructRowID  (в передлах объекта)"
cmbRefTypeDataRow("Value") = 4
cmbRefTypeData.Rows.Add (cmbRefTypeDataRow)
cmbRefType.DisplayMember = "name"
cmbRefType.ValueMember = "Value"
cmbRefType.DataSource = cmbRefTypeData
 cmbRefType.SelectedValue=CInt(Item.RefType)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
If Not item.TheJoinDestination Is Nothing Then
  txtTheJoinDestination.Tag = item.TheJoinDestination.id
  txtTheJoinDestination.text = item.TheJoinDestination.brief
else
  txtTheJoinDestination.Tag = System.Guid.Empty 
  txtTheJoinDestination.text = "" 
End If
txtHandJoin.text = item.HandJoin
txtSEQ.text = item.SEQ.toString()
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

If not txtTheView.Tag.Equals(System.Guid.Empty) Then
  item.TheView = Item.Application.FindRowObject("PARTVIEW",txtTheView.Tag)
Else
   item.TheView = Nothing
End If
If not txtTheJoinSource.Tag.Equals(System.Guid.Empty) Then
  item.TheJoinSource = Item.Application.FindRowObject("ViewColumn",txtTheJoinSource.Tag)
Else
   item.TheJoinSource = Nothing
End If
   item.RefType = cmbRefType.SelectedValue
If not txtTheJoinDestination.Tag.Equals(System.Guid.Empty) Then
  item.TheJoinDestination = Item.Application.FindRowObject("ViewColumn",txtTheJoinDestination.Tag)
Else
   item.TheJoinDestination = Nothing
End If
item.HandJoin = txtHandJoin.text
item.SEQ = val(txtSEQ.text)
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtTheView.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbRefType.SelectedIndex >=0)
if mIsOK then mIsOK =( txtSEQ.text <> "" ) 
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
