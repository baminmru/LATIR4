Public Class frmChild
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
            If Not Item Is Nothing Then
                Try
                    Item.UnLockResource()
                Catch
                End Try
            End If
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents pnlStatus As System.Windows.Forms.Panel
    Friend WithEvents ctlStatus As LATIRGUIControls.StatusControl
    Friend WithEvents pnlObj As System.Windows.Forms.Panel

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChild))
        Me.pnlStatus = New System.Windows.Forms.Panel
        Me.ctlStatus = New LATIRGUIControls.StatusControl
        Me.pnlObj = New System.Windows.Forms.Panel
        Me.pnlStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlStatus
        '
        Me.pnlStatus.Controls.Add(Me.ctlStatus)
        Me.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStatus.Location = New System.Drawing.Point(0, 0)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(528, 36)
        Me.pnlStatus.TabIndex = 0
        '
        'ctlStatus
        '
        Me.ctlStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctlStatus.Location = New System.Drawing.Point(0, 0)
        Me.ctlStatus.Name = "ctlStatus"
        Me.ctlStatus.Size = New System.Drawing.Size(528, 36)
        Me.ctlStatus.TabIndex = 0
        '
        'pnlObj
        '
        Me.pnlObj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlObj.Location = New System.Drawing.Point(0, 36)
        Me.pnlObj.Name = "pnlObj"
        Me.pnlObj.Size = New System.Drawing.Size(528, 289)
        Me.pnlObj.TabIndex = 1
        '
        'frmChild
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 325)
        Me.Controls.Add(Me.pnlObj)
        Me.Controls.Add(Me.pnlStatus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChild"
        Me.Text = "frmChild"
        Me.pnlStatus.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private DataControl As LATIRGUIControls.IViewPanel
    Private GuiManager As LATIRGuiManager.LATIRGuiManager
    Public Item As LATIR.Document.Doc_Base

    Public Sub AppendControl(ByVal uc As System.Windows.Forms.UserControl)
        Me.SuspendLayout()
        pnlObj.SuspendLayout()
        DataControl = uc
        uc.Location = New Point(0, 0)
        uc.Dock = DockStyle.Fill
        pnlObj.Controls.Add(DataControl)
        pnlObj.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Public Sub Attach(ByVal gm As LATIRGuiManager.LATIRGuiManager, ByVal DOcItem As LATIR.Document.Doc_Base)
        GuiManager = gm
        Me.Text = DOcItem.Name
        Item = DOcItem

        If Item.IsLocked = LATIR.Session.LockStyle.ExternalLockPermanent Or Item.IsLocked = LATIR.Session.LockStyle.ExternalLockSession Then
            CType(DataControl, LATIRGUIControls.IViewPanel).Attach(DOcItem, gm, True)
        Else
            CType(DataControl, LATIRGUIControls.IViewPanel).Attach(DOcItem, gm, False)
            Item.LockResource(False)
        End If

      

        If Not DOcItem.HasStatuses Then
            pnlStatus.Size = New Size(528, 0)
            pnlStatus.Enabled = False
            'ctlStatus.Visible = False
        Else
            pnlStatus.Size = New System.Drawing.Size(528, 40)
            pnlStatus.Enabled = True
            'pnlStatus.Visible = True
            'ctlStatus.Visible = True
            ctlStatus.Attach(gm, DOcItem, True, True, True)
        End If


    End Sub

    Private Sub ctlStatus_AfterChangeState(ByVal DocItem As LATIR.Document.Doc_Base, ByVal NewStateID As System.Guid) Handles ctlStatus.AfterChangeState
        Dim bst As LATIR.Document.Doc_StatusSupport = Nothing
        Try
            bst = DocItem.Manager.GetDocStatusSupport(DocItem.TypeName)
        Catch
        End Try
        If Not bst Is Nothing Then
            Try
                bst.AfterChangeState(DocItem, NewStateID)
            Catch
                Return
            End Try
        End If

        If CheckAndSave() Then
            Me.Hide()
        End If
    End Sub

    Private Function CheckAndSave() As Boolean

        Dim iv As LATIRGUIControls.IViewPanel
        iv = CType(DataControl, LATIRGUIControls.IViewPanel)
        If iv.IsChanged() Then
            If iv.Verify(True) Then
                Return iv.Save(True, True)
            End If
            Return False
        End If
        Return False

    End Function

    Private Sub ctlStatus_BeforeChangeState(ByVal DocItem As LATIR.Document.Doc_Base, ByVal NewStateID As System.Guid) Handles ctlStatus.BeforeChangeState
        Dim bst As LATIR.Document.Doc_StatusSupport = Nothing
        Try
            bst = DocItem.Manager.GetDocStatusSupport(DocItem.TypeName)
        Catch
        End Try
        If Not bst Is Nothing Then
            bst.BeforeChangeState(DocItem, NewStateID)
        End If

    End Sub

    Private Sub ctlStatus_CheckFor(ByVal DocItem As LATIR.Document.Doc_Base, ByVal NewStateID As System.Guid, ByRef OK As Boolean) Handles ctlStatus.CheckFor
        Dim CanSwitch As Boolean

        CanSwitch = True 'RoleDocCanSwitchStatus(DocItem)
        If Not CanSwitch Then
            MsgBox("Для текущего документа не разрешена смена состояния", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Смена состояния")
            OK = False
            Exit Sub
        End If

        OK = True

        Dim bst As LATIR.Document.Doc_StatusSupport = Nothing
        Try
            bst = DocItem.Manager.GetDocStatusSupport(DocItem.TypeName)
        Catch
        End Try
        If Not bst Is Nothing Then
            OK = bst.CheckFor(DocItem, NewStateID)
        End If
    End Sub

    Private Sub ctlStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctlStatus.Load

    End Sub

    Private Sub frmChild_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CheckAndSave()
    End Sub
End Class
