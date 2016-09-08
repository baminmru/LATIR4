
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Отчёты режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editROLES_REPORTS
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
Friend WithEvents lblThe_Report  as  System.Windows.Forms.Label
Friend WithEvents txtThe_Report As System.Windows.Forms.TextBox
Friend WithEvents cmdThe_Report As System.Windows.Forms.Button

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
Me.lblThe_Report = New System.Windows.Forms.Label
Me.txtThe_Report = New System.Windows.Forms.TextBox
Me.cmdThe_Report = New System.Windows.Forms.Button

Me.lblThe_Report.Location = New System.Drawing.Point(20,5)
Me.lblThe_Report.name = "lblThe_Report"
Me.lblThe_Report.Size = New System.Drawing.Size(200, 20)
Me.lblThe_Report.TabIndex = 1
Me.lblThe_Report.Text = "Отчёт"
Me.lblThe_Report.ForeColor = System.Drawing.Color.Black
Me.txtThe_Report.Location = New System.Drawing.Point(20,27)
Me.txtThe_Report.name = "txtThe_Report"
Me.txtThe_Report.ReadOnly = True
Me.txtThe_Report.Size = New System.Drawing.Size(176, 20)
Me.txtThe_Report.TabIndex = 2
Me.txtThe_Report.Text = "" 
Me.cmdThe_Report.Location = New System.Drawing.Point(198,27)
Me.cmdThe_Report.name = "cmdThe_Report"
Me.cmdThe_Report.Size = New System.Drawing.Size(22, 20)
Me.cmdThe_Report.TabIndex = 3
Me.cmdThe_Report.Text = "..." 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThe_Report)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtThe_Report)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdThe_Report)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editROLES_REPORTS"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtThe_Report_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThe_Report.TextChanged
  Changing

end sub
private sub cmdThe_Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThe_Report.Click
  try
Dim id As guid
Dim brief As String  = string.Empty
Dim OK as boolean
       OK=GuiManager.GetObjectDialog("MTZRprt","",id,brief)
If OK Then
    txtThe_Report.Text = brief
    txtThe_Report.Tag = id
End If
        catch ex as system.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
End Sub

Public Item As ROLES.ROLES.ROLES_REPORTS
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,ROLES.ROLES.ROLES_REPORTS)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.The_Report Is Nothing Then
  txtThe_Report.Tag = item.The_Report.id
  txtThe_Report.text = item.The_Report.brief
else
  txtThe_Report.Tag = System.Guid.Empty 
  txtThe_Report.text = "" 
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

If not txtThe_Report.Tag.Equals(System.Guid.Empty) Then
   item.The_Report = GuiManager.Manager.GetInstanceObject(txtThe_Report.Tag)
Else
   item.The_Report = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtThe_Report.Tag.Equals(System.Guid.Empty)
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
