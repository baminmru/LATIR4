
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Отчеты режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editARMJRNLREP
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
Friend WithEvents lblrepname  as  System.Windows.Forms.Label
Friend WithEvents txtrepname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTheReport  as  System.Windows.Forms.Label
Friend WithEvents txtTheReport As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheReport As System.Windows.Forms.Button

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
Me.lblrepname = New System.Windows.Forms.Label
Me.txtrepname = New LATIR2GuiManager.TouchTextBox
Me.lblTheReport = New System.Windows.Forms.Label
Me.txtTheReport = New LATIR2GuiManager.TouchTextBox
Me.cmdTheReport = New System.Windows.Forms.Button

Me.lblrepname.Location = New System.Drawing.Point(20,5)
Me.lblrepname.name = "lblrepname"
Me.lblrepname.Size = New System.Drawing.Size(200, 20)
Me.lblrepname.TabIndex = 1
Me.lblrepname.Text = "Название отчета"
Me.lblrepname.ForeColor = System.Drawing.Color.Black
Me.txtrepname.Location = New System.Drawing.Point(20,27)
Me.txtrepname.name = "txtrepname"
Me.txtrepname.Size = New System.Drawing.Size(200, 20)
Me.txtrepname.TabIndex = 2
Me.txtrepname.Text = "" 
Me.lblTheReport.Location = New System.Drawing.Point(20,52)
Me.lblTheReport.name = "lblTheReport"
Me.lblTheReport.Size = New System.Drawing.Size(200, 20)
Me.lblTheReport.TabIndex = 3
Me.lblTheReport.Text = "Отчет"
Me.lblTheReport.ForeColor = System.Drawing.Color.Black
Me.txtTheReport.Location = New System.Drawing.Point(20,74)
Me.txtTheReport.name = "txtTheReport"
Me.txtTheReport.ReadOnly = True
Me.txtTheReport.Size = New System.Drawing.Size(176, 20)
Me.txtTheReport.TabIndex = 4
Me.txtTheReport.Text = "" 
Me.cmdTheReport.Location = New System.Drawing.Point(198,74)
Me.cmdTheReport.name = "cmdTheReport"
Me.cmdTheReport.Size = New System.Drawing.Size(22, 20)
Me.cmdTheReport.TabIndex = 5
Me.cmdTheReport.Text = "..." 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblrepname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtrepname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheReport)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheReport)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheReport)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editARMJRNLREP"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtrepname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrepname.TextChanged
  Changing

end sub
private sub txtTheReport_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheReport.TextChanged
  Changing

end sub
private sub cmdTheReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheReport.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("MTZRprt","",id,brief)
If OK Then
    txtTheReport.Text = brief
    txtTheReport.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub

Public Item As MTZwp.MTZwp.ARMJRNLREP
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,MTZwp.MTZwp.ARMJRNLREP)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtrepname.text = item.repname
If Not item.TheReport Is Nothing Then
  txtTheReport.Tag = item.TheReport.id
  txtTheReport.text = item.TheReport.brief
else
  txtTheReport.Tag = System.Guid.Empty 
  txtTheReport.text = "" 
End If
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

item.repname = txtrepname.text
If not txtTheReport.Tag.Equals(System.Guid.Empty) Then
   item.TheReport = GuiManager.Manager.GetInstanceObject(txtTheReport.Tag)
Else
   item.TheReport = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtrepname.text <> "" ) 
if mIsOK then mIsOK = not txtTheReport.Tag.Equals(System.Guid.Empty)
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
