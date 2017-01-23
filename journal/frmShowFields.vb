Imports Janus.Windows.GridEX

Public Class frmShowFields
    Inherits System.Windows.Forms.Form

    Private mAvailableFields As ArrayList
    Private mVisibleFields As ArrayList

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
    Friend WithEvents lbAvail As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbVisible As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lbAvail = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbVisible = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbAvail
        '
        Me.lbAvail.Location = New System.Drawing.Point(8, 28)
        Me.lbAvail.Name = "lbAvail"
        Me.lbAvail.Size = New System.Drawing.Size(184, 173)
        Me.lbAvail.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Available Fields:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(288, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Show these fields in this order:"
        '
        'lbVisible
        '
        Me.lbVisible.Location = New System.Drawing.Point(288, 28)
        Me.lbVisible.Name = "lbVisible"
        Me.lbVisible.Size = New System.Drawing.Size(184, 173)
        Me.lbVisible.TabIndex = 3
        '
        'btnAdd
        '
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAdd.Location = New System.Drawing.Point(200, 28)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 24)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add ->"
        '
        'btnRemove
        '
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRemove.Location = New System.Drawing.Point(200, 60)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(80, 24)
        Me.btnRemove.TabIndex = 5
        Me.btnRemove.Text = "<- Remove"
        '
        'btnUp
        '
        Me.btnUp.Enabled = False
        Me.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnUp.Location = New System.Drawing.Point(288, 208)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(80, 24)
        Me.btnUp.TabIndex = 6
        Me.btnUp.Text = "Move Up"
        '
        'btnDown
        '
        Me.btnDown.Enabled = False
        Me.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDown.Location = New System.Drawing.Point(392, 208)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(80, 24)
        Me.btnDown.TabIndex = 7
        Me.btnDown.Text = "Move Down"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Location = New System.Drawing.Point(480, 32)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(480, 64)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'frmShowFields
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(564, 236)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnOK, Me.btnDown, Me.btnUp, Me.btnRemove, Me.btnAdd, Me.lbVisible, Me.Label2, Me.Label1, Me.lbAvail})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmShowFields"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Show Fields"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overloads Function ShowDialog(ByVal grid As Janus.Windows.GridEX.GridEX, ByVal parent As Form) As DialogResult
        Dim column As GridEXColumn
        Dim i As Integer
        Me.lbAvail.DisplayMember = "Caption"
        Me.lbVisible.DisplayMember = "Caption"

        For i = 0 To grid.RootTable.Columns.Count - 1
            column = grid.RootTable.Columns.GetColumnInPosition(i)
            If column.ShowInFieldChooser Then
                If column.Visible Then
                    AddVisibleField(column, False)
                Else
                    AddAvailableField(column, False)
                End If
            End If
        Next
        FillAvailableList()
        FillVisibleList()
        Return Me.ShowDialog(parent)
    End Function
    Private Sub AddAvailableField(ByVal column As GridEXColumn, ByVal refresh As Boolean)
        If mAvailableFields Is Nothing Then
            mAvailableFields = New ArrayList()
        End If
        mAvailableFields.Add(column)
        If refresh Then
            FillAvailableList()
        End If
    End Sub
    Private Sub FillAvailableList()
        Dim column As GridEXColumn
        Me.lbAvail.Items.Clear()
        If Not mAvailableFields Is Nothing Then
            For Each column In mAvailableFields
                lbAvail.Items.Add(column.Caption)
            Next
        End If
        If lbAvail.Items.Count > 0 Then
            lbAvail.SelectedIndex = 0
            btnAdd.Enabled = True
        Else
            btnAdd.Enabled = False
        End If
    End Sub
    Private Sub AddVisibleField(ByVal column As GridEXColumn, ByVal refresh As Boolean)
        If mVisibleFields Is Nothing Then
            mVisibleFields = New ArrayList()
        End If
        mVisibleFields.Add(column)
        If refresh Then
            FillVisibleList()
        End If
    End Sub
    Private Sub FillVisibleList()
        Dim column As GridEXColumn
        Me.lbVisible.Items.Clear()
        If Not mVisibleFields Is Nothing Then
            For Each column In mVisibleFields
                lbVisible.Items.Add(column.Caption)
            Next
        End If
        If lbVisible.Items.Count > 0 Then
            lbVisible.SelectedIndex = 0
            btnRemove.Enabled = True
        Else
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim column As GridEXColumn
        Dim selIndex As Integer
        If lbAvail.SelectedIndex <> -1 Then
            selIndex = lbAvail.SelectedIndex
            column = CType(mAvailableFields.Item(selIndex), GridEXColumn)
            mAvailableFields.Remove(column)
            FillAvailableList()
            Me.AddVisibleField(column, True)
            lbVisible.SelectedIndex = lbVisible.Items.Count - 1
            If selIndex < lbAvail.Items.Count Then
                lbAvail.SelectedIndex = selIndex
            Else
                lbAvail.SelectedIndex = lbAvail.Items.Count - 1
            End If
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim column As GridEXColumn
        Dim selIndex As Integer
        If lbVisible.SelectedIndex <> -1 Then
            selIndex = lbVisible.SelectedIndex
            column = CType(mVisibleFields.Item(selIndex), GridEXColumn)
            mVisibleFields.Remove(column)
            FillVisibleList()
            Me.AddAvailableField(column, True)
            lbAvail.SelectedIndex = lbAvail.Items.Count - 1
            If selIndex < lbVisible.Items.Count Then
                lbVisible.SelectedIndex = selIndex
            Else
                lbVisible.SelectedIndex = lbVisible.Items.Count - 1
            End If
        End If
    End Sub

    Private Sub lbVisible_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbVisible.SelectedIndexChanged
        Me.btnUp.Enabled = (lbVisible.SelectedIndex > 0)
        Me.btnDown.Enabled = (lbVisible.SelectedIndex < lbVisible.Items.Count - 1)
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Dim column As GridEXColumn
        Dim selIndex As Integer = lbVisible.SelectedIndex
        column = CType(Me.mVisibleFields.Item(selIndex), GridEXColumn)
        mVisibleFields.Remove(column)
        mVisibleFields.Insert(selIndex - 1, column)
        FillVisibleList()
        lbVisible.SelectedIndex = selIndex - 1
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Dim column As GridEXColumn
        Dim selIndex As Integer = lbVisible.SelectedIndex
        column = CType(Me.mVisibleFields.Item(selIndex), GridEXColumn)
        mVisibleFields.Remove(column)
        mVisibleFields.Insert(selIndex + 1, column)
        FillVisibleList()
        lbVisible.SelectedIndex = selIndex + 1
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim column As GridEXColumn
        Dim pos As Integer
        If Not mAvailableFields Is Nothing Then
            For Each column In mAvailableFields
                column.Visible = False
            Next
        End If
        If Not mVisibleFields Is Nothing Then
            pos = 0
            For Each column In mVisibleFields
                column.Visible = True
                column.Position = pos
                pos = pos + 1
            Next
        End If
        Me.Close()
    End Sub

    Private Sub lbAvail_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAvail.DoubleClick
        Me.btnAdd_Click(Nothing, EventArgs.Empty)
    End Sub

    Private Sub lbVisible_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbVisible.DoubleClick
        Me.btnRemove_Click(Nothing, EventArgs.Empty)
    End Sub
End Class
