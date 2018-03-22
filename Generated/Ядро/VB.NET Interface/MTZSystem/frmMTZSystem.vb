
  Imports System.Windows.Forms
  Imports Microsoft.VisualBasic
  Imports System.Drawing

  Public Class frmMTZSystem
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents tv As MTZSystemGUI.Tabview
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tv = New MTZSystemGUI.TabView
        Me.SuspendLayout()
        '
        'tv
        '
        Me.tv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tv.Location = New System.Drawing.Point(8, 8)
        Me.tv.name = "tv"
        Me.tv.Size = New System.Drawing.Size(600, 344)
        Me.tv.TabIndex = 0
        '
        'frmMTZSystem
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(608, 357)
        Me.Controls.Add (Me.tv)
        Me.name = "frmMTZSystem"
        Me.ResumeLayout (False)
    End Sub
#End Region
    Public item As MTZSystem.MTZSystem.Application
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''Процедура инициализации формы
''' </remarks>
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, optional byval FormReadOnly as boolean =false)
        item = CType(docItem, MTZSystem.MTZSystem.Application)
        GuiManager = gm
        tv.Attach(item, GuiManager,FormReadOnly)
        Me.Text = item.name
    End Sub
    ' Private myResizer As LATIR2GuiManager.Resizer = New LATIR2GuiManager.Resizer
   Private Sub frm_Load(sender As Object, e As EventArgs) Handles Me.Load
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
       ' myResizer.FindAllControls(Me) 
          Me.StartPosition = FormStartPosition.Manual
          Me.WindowState = FormWindowState.Normal
          Me.Location = Screen.PrimaryScreen.WorkingArea.Location
          Me.Size = Screen.PrimaryScreen.WorkingArea.Size
   End Sub
   Private Sub frm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
   '   myResizer.ResizeAllControls(Me)
   End Sub
        Private Sub frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.FormOwnerClosing Then
            e.Cancel = Not CheckAndSave(False)
        End If
        If e.CloseReason = CloseReason.ApplicationExitCall Then
            e.Cancel = Not CheckAndSave(False)
        End If
        If e.CloseReason = CloseReason.MdiFormClosing Then
            e.Cancel = Not CheckAndSave(False)
        End If
        If e.CloseReason = CloseReason.TaskManagerClosing Then
            CheckAndSave(True)
        End If
        If e.CloseReason = CloseReason.WindowsShutDown Then
            CheckAndSave(True)
        End If
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = Not CheckAndSave(False)
        End If
        If e.CloseReason = CloseReason.None Then
            e.Cancel = Not CheckAndSave(False)
        End If
    End Sub
    Private function CheckAndSave(byval sielent as boolean) as boolean
    Dim iv As LATIR2GUIManager.IViewPanel
    iv = CType(tv, LATIR2GUIManager.IViewPanel)
    If iv.IsChanged() Then
        If Not sielent Then
            If MsgBox("Данные изменены. Сохранить изменения?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Закрытие документа") = MsgBoxResult.Yes Then
                If iv.Verify(True) Then
                    Return iv.Save(True, False)
                Else
                    Return False
                End If
            End If
        Else
            If iv.Verify(True) Then
                Return iv.Save(True, True)
            End If
            Return False
        End If
    End If
    Return True
    End function
End Class
