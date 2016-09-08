Imports System.Xml
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmLogin
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
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents txtUser As System.Windows.Forms.TextBox
    Public WithEvents txtPassword As System.Windows.Forms.TextBox
    Public WithEvents cmbProfile As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbProfile = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User name:"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(3, 23)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(296, 22)
        Me.txtUser.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(3, 67)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(1061)
        Me.txtPassword.Size = New System.Drawing.Size(296, 22)
        Me.txtPassword.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "DataBase profile:"
        '
        'cmbProfile
        '
        Me.cmbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProfile.Location = New System.Drawing.Point(3, 111)
        Me.cmbProfile.Name = "cmbProfile"
        Me.cmbProfile.Size = New System.Drawing.Size(296, 24)
        Me.cmbProfile.Sorted = True
        Me.cmbProfile.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(152, 138)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(70, 24)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "&ÎÊ"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(228, 138)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 24)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(313, 173)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cmbProfile)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log In"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Friend PreviousSiteName As String
    Public Manager As LATIR2.Manager
    Dim tabtip As String

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        tabtip = GetSetting("LATIR4", "CFG", "TABTIP", "true")

        'Dim sizefOld As SizeF = GetAutoScaleSize(Font)
        'Dim MyScale As Integer
        'MyScale = Integer.Parse(GetSetting("LATIR4", "CFG", "SCALE", "10"))
        'Font = New Font(Font.FontFamily, MyScale)
        'Dim sizefNew As SizeF = GetAutoScaleSize(Font)
        'Scale(sizefNew.Width / sizefOld.Width, sizefNew.Height / sizefOld.Height)


        'Me.StartPosition = FormStartPosition.Manual

        'If Me.Width > Screen.GetWorkingArea(New Point(Me.Top, Me.Left)).Width Then Me.Width = Screen.GetWorkingArea(New Point(Me.Top, Me.Left)).Width
        'If Me.Height > Screen.GetWorkingArea(New Point(Me.Top, Me.Left)).Height Then Me.Height = Screen.GetWorkingArea(New Point(Me.Top, Me.Left)).Height

        'Me.Left = (Screen.GetWorkingArea(New Point(Me.Top, Me.Left)).Width - Me.Width) / 2
        'Me.Top = (Screen.GetWorkingArea(New Point(Me.Top, Me.Left)).Height - Me.Height) / 2
        'If Me.Left < 0 Then Me.Left = 0
        'If Me.Top < 0 Then Me.Top = 0

        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)



        Dim xdom As XmlDocument
        Dim I As Integer
        xdom = New XmlDocument
        xdom.Load(Manager.XmlFile)
        cmbProfile.Items.Clear()

        For I = 0 To xdom.LastChild.ChildNodes.Count - 1
            cmbProfile.Items.Add(xdom.LastChild.ChildNodes.Item(I).Attributes.GetNamedItem("Name").Value())
        Next
        xdom = Nothing
        If (PreviousSiteName <> String.Empty) Then
            For I = 0 To cmbProfile.Items.Count - 1
                If (cmbProfile.Items(I).ToString() = PreviousSiteName) Then
                    cmbProfile.SelectedItem = cmbProfile.Items(I)
                    Exit For
                End If
            Next
        End If
        If tabtip = "true" Then
            Dim oskProcessArray() As Process = Process.GetProcessesByName("TabTip")
            For Each onscreenProcess As Process In oskProcessArray
                Try
                    onscreenProcess.Kill()
                Catch ex As Exception

                End Try

            Next
        End If

    End Sub

    Private Sub txtUser_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged

    End Sub

    Private Sub txtUser_Enter(sender As Object, e As EventArgs) Handles txtUser.Enter, txtPassword.Enter
        If tabtip = "true" Then

            Dim progFiles As String = "C:\Program Files\Common Files\Microsoft Shared\ink"
            Dim onScreenKeyboardPath As String = System.IO.Path.Combine(progFiles, "TabTip.exe")
            Dim onScreenKeyboardProc As Process
            Try
                onScreenKeyboardProc = System.Diagnostics.Process.Start(onScreenKeyboardPath)
            Catch ex As Exception
                onScreenKeyboardProc = Nothing
            End Try

        End If
    End Sub

    Private Sub txtUser_Leave(sender As Object, e As EventArgs) Handles txtUser.Leave, txtPassword.Leave
        'If tabtip = "true" Then
        '    If Not onScreenKeyboardProc Is Nothing Then
        '        If Not onScreenKeyboardProc.HasExited Then
        '            onScreenKeyboardProc.Kill()
        '        End If
        '        onScreenKeyboardProc = Nothing
        '    End If

        'End If
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'If tabtip = "true" Then
        '    If Not onScreenKeyboardProc Is Nothing Then
        '        If Not onScreenKeyboardProc.HasExited Then
        '            onScreenKeyboardProc.Kill()
        '        End If
        '        onScreenKeyboardProc = Nothing
        '    End If
        'End If
        If tabtip = "true" Then
            Dim oskProcessArray() As Process = Process.GetProcessesByName("TabTip")
            For Each onscreenProcess As Process In oskProcessArray
                Try
                    onscreenProcess.Kill()
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try

            Next
        End If
    End Sub
End Class
