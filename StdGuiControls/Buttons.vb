Public Class Buttons
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        LoadDefaults()
    End Sub

    Private Sub Buttons_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents cmdRun As System.Windows.Forms.Button
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents cmdAddRoot As System.Windows.Forms.Button
    Friend WithEvents cmdProp As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.Panel7 = New System.Windows.Forms.Panel
    Me.cmdPrint = New System.Windows.Forms.Button
    Me.Panel22 = New System.Windows.Forms.Panel
    Me.cmdRun = New System.Windows.Forms.Button
    Me.Panel21 = New System.Windows.Forms.Panel
    Me.cmdProp = New System.Windows.Forms.Button
    Me.Panel8 = New System.Windows.Forms.Panel
    Me.cmdFind = New System.Windows.Forms.Button
    Me.Panel6 = New System.Windows.Forms.Panel
    Me.cmdRefresh = New System.Windows.Forms.Button
    Me.Panel5 = New System.Windows.Forms.Panel
    Me.cmdDel = New System.Windows.Forms.Button
    Me.Panel4 = New System.Windows.Forms.Panel
    Me.cmdEdit = New System.Windows.Forms.Button
    Me.Panel3 = New System.Windows.Forms.Panel
    Me.cmdAdd = New System.Windows.Forms.Button
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.cmdAddRoot = New System.Windows.Forms.Button
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Panel1.SuspendLayout()
    Me.Panel7.SuspendLayout()
    Me.Panel22.SuspendLayout()
    Me.Panel21.SuspendLayout()
    Me.Panel8.SuspendLayout()
    Me.Panel6.SuspendLayout()
    Me.Panel5.SuspendLayout()
    Me.Panel4.SuspendLayout()
    Me.Panel3.SuspendLayout()
    Me.Panel2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Panel7)
    Me.Panel1.Controls.Add(Me.Panel22)
    Me.Panel1.Controls.Add(Me.Panel21)
    Me.Panel1.Controls.Add(Me.Panel8)
    Me.Panel1.Controls.Add(Me.Panel6)
    Me.Panel1.Controls.Add(Me.Panel5)
    Me.Panel1.Controls.Add(Me.Panel4)
    Me.Panel1.Controls.Add(Me.Panel3)
    Me.Panel1.Controls.Add(Me.Panel2)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(920, 32)
    Me.Panel1.TabIndex = 14
    '
    'Panel7
    '
    Me.Panel7.Controls.Add(Me.cmdPrint)
    Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel7.Location = New System.Drawing.Point(720, 0)
    Me.Panel7.Name = "Panel7"
    Me.Panel7.Size = New System.Drawing.Size(88, 32)
    Me.Panel7.TabIndex = 1
    '
    'cmdPrint
    '
    Me.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmdPrint.Location = New System.Drawing.Point(0, 0)
    Me.cmdPrint.Name = "cmdPrint"
    Me.cmdPrint.Size = New System.Drawing.Size(72, 24)
    Me.cmdPrint.TabIndex = 19
    Me.cmdPrint.Tag = "Print"
    Me.cmdPrint.Text = "&Печать"
    '
    'Panel22
    '
    Me.Panel22.Controls.Add(Me.cmdRun)
    Me.Panel22.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel22.Location = New System.Drawing.Point(632, 0)
    Me.Panel22.Name = "Panel22"
    Me.Panel22.Size = New System.Drawing.Size(88, 32)
    Me.Panel22.TabIndex = 8
    '
    'cmdRun
    '
    Me.cmdRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmdRun.Location = New System.Drawing.Point(8, 0)
    Me.cmdRun.Name = "cmdRun"
    Me.cmdRun.Size = New System.Drawing.Size(72, 24)
    Me.cmdRun.TabIndex = 19
    Me.cmdRun.Tag = "Run"
    Me.cmdRun.Text = "&Открыть"
    '
    'Panel21
    '
    Me.Panel21.Controls.Add(Me.cmdProp)
    Me.Panel21.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel21.Location = New System.Drawing.Point(544, 0)
    Me.Panel21.Name = "Panel21"
    Me.Panel21.Size = New System.Drawing.Size(88, 32)
    Me.Panel21.TabIndex = 7
    '
    'cmdProp
    '
    Me.cmdProp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmdProp.Location = New System.Drawing.Point(8, 0)
    Me.cmdProp.Name = "cmdProp"
    Me.cmdProp.Size = New System.Drawing.Size(72, 24)
    Me.cmdProp.TabIndex = 13
    Me.cmdProp.Tag = "Config"
    Me.cmdProp.Text = "&Настройкa"
    '
    'Panel8
    '
    Me.Panel8.Controls.Add(Me.cmdFind)
    Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel8.Location = New System.Drawing.Point(456, 0)
    Me.Panel8.Name = "Panel8"
    Me.Panel8.Size = New System.Drawing.Size(88, 32)
    Me.Panel8.TabIndex = 6
    '
    'cmdFind
    '
    Me.cmdFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmdFind.Location = New System.Drawing.Point(8, 0)
    Me.cmdFind.Name = "cmdFind"
    Me.cmdFind.Size = New System.Drawing.Size(72, 24)
    Me.cmdFind.TabIndex = 12
    Me.cmdFind.Tag = "Find"
    Me.cmdFind.Text = "&Поиск"
    '
    'Panel6
    '
    Me.Panel6.Controls.Add(Me.cmdRefresh)
    Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel6.Location = New System.Drawing.Point(360, 0)
    Me.Panel6.Name = "Panel6"
    Me.Panel6.Size = New System.Drawing.Size(96, 32)
    Me.Panel6.TabIndex = 5
    '
    'cmdRefresh
    '
    Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmdRefresh.Location = New System.Drawing.Point(8, 0)
    Me.cmdRefresh.Name = "cmdRefresh"
    Me.cmdRefresh.Size = New System.Drawing.Size(72, 24)
    Me.cmdRefresh.TabIndex = 11
    Me.cmdRefresh.Tag = "Refresh"
    Me.cmdRefresh.Text = "&Обновить"
    '
    'Panel5
    '
    Me.Panel5.Controls.Add(Me.cmdDel)
    Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel5.Location = New System.Drawing.Point(272, 0)
    Me.Panel5.Name = "Panel5"
    Me.Panel5.Size = New System.Drawing.Size(88, 32)
    Me.Panel5.TabIndex = 4
    '
    'cmdDel
    '
    Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmdDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.cmdDel.Location = New System.Drawing.Point(8, 0)
    Me.cmdDel.Name = "cmdDel"
    Me.cmdDel.Size = New System.Drawing.Size(72, 24)
    Me.cmdDel.TabIndex = 9
    Me.cmdDel.Tag = "Delete"
    Me.cmdDel.Text = "&Удалить"
    '
    'Panel4
    '
    Me.Panel4.Controls.Add(Me.cmdEdit)
    Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel4.Location = New System.Drawing.Point(184, 0)
    Me.Panel4.Name = "Panel4"
    Me.Panel4.Size = New System.Drawing.Size(88, 32)
    Me.Panel4.TabIndex = 3
    '
    'cmdEdit
    '
    Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.cmdEdit.Location = New System.Drawing.Point(8, 0)
    Me.cmdEdit.Name = "cmdEdit"
    Me.cmdEdit.Size = New System.Drawing.Size(72, 24)
    Me.cmdEdit.TabIndex = 10
    Me.cmdEdit.Tag = "Prop"
    Me.cmdEdit.Text = "&Изменить"
    '
    'Panel3
    '
    Me.Panel3.Controls.Add(Me.cmdAdd)
    Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel3.Location = New System.Drawing.Point(88, 0)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(96, 32)
    Me.Panel3.TabIndex = 2
    '
    'cmdAdd
    '
    Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.cmdAdd.Location = New System.Drawing.Point(16, 0)
    Me.cmdAdd.Name = "cmdAdd"
    Me.cmdAdd.Size = New System.Drawing.Size(72, 24)
    Me.cmdAdd.TabIndex = 8
    Me.cmdAdd.Tag = "New"
    Me.cmdAdd.Text = "&Добавить"
    Me.ToolTip1.SetToolTip(Me.cmdAdd, "cdcccc")
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.cmdAddRoot)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel2.Location = New System.Drawing.Point(0, 0)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(88, 32)
    Me.Panel2.TabIndex = 0
    '
    'cmdAddRoot
    '
    Me.cmdAddRoot.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmdAddRoot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.cmdAddRoot.Location = New System.Drawing.Point(8, 0)
    Me.cmdAddRoot.Name = "cmdAddRoot"
    Me.cmdAddRoot.Size = New System.Drawing.Size(72, 24)
    Me.cmdAddRoot.TabIndex = 8
    Me.cmdAddRoot.Tag = "NewRoot"
    Me.cmdAddRoot.Text = "&В корень"
    Me.ToolTip1.SetToolTip(Me.cmdAddRoot, "cdcccc")
    '
    'Buttons
    '
    Me.Controls.Add(Me.Panel1)
    Me.Name = "Buttons"
    Me.Size = New System.Drawing.Size(920, 32)
    Me.Panel1.ResumeLayout(False)
    Me.Panel7.ResumeLayout(False)
    Me.Panel22.ResumeLayout(False)
    Me.Panel21.ResumeLayout(False)
    Me.Panel8.ResumeLayout(False)
    Me.Panel6.ResumeLayout(False)
    Me.Panel5.ResumeLayout(False)
    Me.Panel4.ResumeLayout(False)
    Me.Panel3.ResumeLayout(False)
    Me.Panel2.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region
    Private mAllowAddRoot As Boolean
    Private mAllowAdd As Boolean
    Private mAllowRefresh As Boolean
    Private mAllowFind As Boolean
    Private mAllowDel As Boolean
    Private mAllowEdit As Boolean
    Private mAllowProp As Boolean
    Private mAllowRun As Boolean
    Private mAllowPrint As Boolean

    Public Event OnAddRoot()
    Public Event OnAdd()
    Public Event OnRefresh()
    Public Event OnFind()
    Public Event OnDel()
    Public Event OnEdit()
    Public Event OnProp()
    Public Event OnRun()
    Public Shadows Event OnPrint()

    Private Sub LoadDefaults()
        mAllowAddRoot = True
        AllowAdd = True
        mAllowRefresh = True
        mAllowFind = False
        mAllowDel = True
        mAllowEdit = True
        mAllowProp = False
        mAllowRun = False
        mAllowPrint = False
    End Sub

    Public Property AllowAddRoot() As Boolean
        Get
            Return mAllowAddRoot
        End Get
        Set(ByVal Value As Boolean)
            mAllowAddRoot = Value
            If (mAllowAddRoot) Then
                cmdAddRoot.Visible = True
            Else
                cmdAddRoot.Visible = False
            End If
            ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        End Set
    End Property

    Public Property AllowAdd() As Boolean
        Get
            Return mAllowAdd
        End Get
        Set(ByVal Value As Boolean)
            mAllowAdd = Value
            If (mAllowAdd) Then
                cmdAdd.Visible = True
            Else
                cmdAdd.Visible = False
            End If
            ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        End Set
    End Property

    Public Property AllowRefresh() As Boolean
        Get
            Return mAllowRefresh
        End Get
        Set(ByVal Value As Boolean)
            mAllowRefresh = Value
            If (mAllowRefresh) Then
                cmdRefresh.Visible = True
            Else
                cmdRefresh.Visible = False
            End If
            ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        End Set
    End Property

    Public Property AllowFind() As Boolean
        Get
            Return mAllowFind
        End Get
        Set(ByVal Value As Boolean)
            mAllowFind = Value
            If (mAllowFind) Then
                cmdFind.Visible = True
            Else
                cmdFind.Visible = False
            End If
            ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        End Set
    End Property

    Public Property AllowDel() As Boolean
        Get
            Return mAllowDel
        End Get
        Set(ByVal Value As Boolean)
            mAllowDel = Value
            If (mAllowDel) Then
                cmdDel.Visible = True
            Else
                cmdDel.Visible = False
            End If
            ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        End Set
    End Property

    Public Property AllowEdit() As Boolean
        Get
            Return mAllowEdit
        End Get
        Set(ByVal Value As Boolean)
            mAllowEdit = Value
            If (mAllowEdit) Then
                cmdEdit.Visible = True
            Else
                cmdEdit.Visible = False
            End If
            ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        End Set
    End Property

    Public Property AllowProp() As Boolean
        Get
            Return mAllowProp
        End Get
        Set(ByVal Value As Boolean)
            mAllowProp = Value
            If (mAllowProp) Then
                cmdProp.Visible = True
            Else
                cmdProp.Visible = False
            End If
            ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        End Set
    End Property

    Public Property AllowRun() As Boolean
        Get
            Return mAllowRun
        End Get
        Set(ByVal Value As Boolean)
            mAllowRun = Value
            If (mAllowRun) Then
                cmdRun.Visible = True
            Else
                cmdRun.Visible = False
            End If
            ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        End Set
    End Property

    Public Property AllowPrint() As Boolean
        Get
            Return mAllowPrint
        End Get
        Set(ByVal Value As Boolean)
            mAllowPrint = Value
            If (mAllowPrint) Then
                cmdPrint.Visible = True
            Else
                cmdPrint.Visible = False
            End If
            ButtonUtils.PrepareForm(ToolTip1, Me.Controls)
        End Set
    End Property

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        RaiseEvent OnAdd()
    End Sub


    Private Sub cmdAddRoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRoot.Click
        RaiseEvent OnAddRoot()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        RaiseEvent OnEdit()
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        RaiseEvent OnDel()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RaiseEvent OnRefresh()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        RaiseEvent OnFind()
    End Sub

    Private Sub cmdProp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProp.Click
        RaiseEvent OnProp()
    End Sub

    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        RaiseEvent OnRun()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        RaiseEvent OnPrint()
    End Sub
End Class
