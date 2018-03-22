Imports Janus.Windows.GridEX

Public Class frmSort
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optAscending0 As System.Windows.Forms.RadioButton
    Friend WithEvents optDescending0 As System.Windows.Forms.RadioButton
    Friend WithEvents cboColumn0 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optDescending1 As System.Windows.Forms.RadioButton
    Friend WithEvents optAscending1 As System.Windows.Forms.RadioButton
    Friend WithEvents cboColumn1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optDescending2 As System.Windows.Forms.RadioButton
    Friend WithEvents optAscending2 As System.Windows.Forms.RadioButton
    Friend WithEvents cboColumn2 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents optDescending3 As System.Windows.Forms.RadioButton
    Friend WithEvents optAscending3 As System.Windows.Forms.RadioButton
    Friend WithEvents cboColumn3 As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optDescending0 = New System.Windows.Forms.RadioButton()
        Me.optAscending0 = New System.Windows.Forms.RadioButton()
        Me.cboColumn0 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optDescending1 = New System.Windows.Forms.RadioButton()
        Me.optAscending1 = New System.Windows.Forms.RadioButton()
        Me.cboColumn1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optDescending2 = New System.Windows.Forms.RadioButton()
        Me.optAscending2 = New System.Windows.Forms.RadioButton()
        Me.cboColumn2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.optDescending3 = New System.Windows.Forms.RadioButton()
        Me.optAscending3 = New System.Windows.Forms.RadioButton()
        Me.cboColumn3 = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.optDescending0, Me.optAscending0, Me.cboColumn0})
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(8, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(296, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sort Items By"
        '
        'optDescending0
        '
        Me.optDescending0.Enabled = False
        Me.optDescending0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.optDescending0.Location = New System.Drawing.Point(196, 36)
        Me.optDescending0.Name = "optDescending0"
        Me.optDescending0.Size = New System.Drawing.Size(88, 16)
        Me.optDescending0.TabIndex = 2
        Me.optDescending0.Text = "Descending"
        '
        'optAscending0
        '
        Me.optAscending0.Checked = True
        Me.optAscending0.Enabled = False
        Me.optAscending0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.optAscending0.Location = New System.Drawing.Point(196, 16)
        Me.optAscending0.Name = "optAscending0"
        Me.optAscending0.Size = New System.Drawing.Size(88, 16)
        Me.optAscending0.TabIndex = 1
        Me.optAscending0.TabStop = True
        Me.optAscending0.Text = "Ascending"
        '
        'cboColumn0
        '
        Me.cboColumn0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColumn0.Location = New System.Drawing.Point(8, 16)
        Me.cboColumn0.Name = "cboColumn0"
        Me.cboColumn0.Size = New System.Drawing.Size(180, 21)
        Me.cboColumn0.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.optDescending1, Me.optAscending1, Me.cboColumn1})
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Location = New System.Drawing.Point(8, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 64)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Then By"
        '
        'optDescending1
        '
        Me.optDescending1.Enabled = False
        Me.optDescending1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.optDescending1.Location = New System.Drawing.Point(196, 36)
        Me.optDescending1.Name = "optDescending1"
        Me.optDescending1.Size = New System.Drawing.Size(88, 16)
        Me.optDescending1.TabIndex = 2
        Me.optDescending1.Text = "Descending"
        '
        'optAscending1
        '
        Me.optAscending1.Checked = True
        Me.optAscending1.Enabled = False
        Me.optAscending1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.optAscending1.Location = New System.Drawing.Point(196, 16)
        Me.optAscending1.Name = "optAscending1"
        Me.optAscending1.Size = New System.Drawing.Size(88, 16)
        Me.optAscending1.TabIndex = 1
        Me.optAscending1.TabStop = True
        Me.optAscending1.Text = "Ascending"
        '
        'cboColumn1
        '
        Me.cboColumn1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColumn1.Location = New System.Drawing.Point(8, 16)
        Me.cboColumn1.Name = "cboColumn1"
        Me.cboColumn1.Size = New System.Drawing.Size(180, 21)
        Me.cboColumn1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.optDescending2, Me.optAscending2, Me.cboColumn2})
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Location = New System.Drawing.Point(8, 160)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(296, 64)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Then By"
        '
        'optDescending2
        '
        Me.optDescending2.Enabled = False
        Me.optDescending2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.optDescending2.Location = New System.Drawing.Point(196, 36)
        Me.optDescending2.Name = "optDescending2"
        Me.optDescending2.Size = New System.Drawing.Size(88, 16)
        Me.optDescending2.TabIndex = 2
        Me.optDescending2.Text = "Descending"
        '
        'optAscending2
        '
        Me.optAscending2.Checked = True
        Me.optAscending2.Enabled = False
        Me.optAscending2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.optAscending2.Location = New System.Drawing.Point(196, 16)
        Me.optAscending2.Name = "optAscending2"
        Me.optAscending2.Size = New System.Drawing.Size(88, 16)
        Me.optAscending2.TabIndex = 1
        Me.optAscending2.TabStop = True
        Me.optAscending2.Text = "Ascending"
        '
        'cboColumn2
        '
        Me.cboColumn2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColumn2.Location = New System.Drawing.Point(8, 16)
        Me.cboColumn2.Name = "cboColumn2"
        Me.cboColumn2.Size = New System.Drawing.Size(180, 21)
        Me.cboColumn2.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.optDescending3, Me.optAscending3, Me.cboColumn3})
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox4.Location = New System.Drawing.Point(8, 234)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(296, 64)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Then By"
        '
        'optDescending3
        '
        Me.optDescending3.Enabled = False
        Me.optDescending3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.optDescending3.Location = New System.Drawing.Point(196, 36)
        Me.optDescending3.Name = "optDescending3"
        Me.optDescending3.Size = New System.Drawing.Size(88, 16)
        Me.optDescending3.TabIndex = 2
        Me.optDescending3.Text = "Descending"
        '
        'optAscending3
        '
        Me.optAscending3.Checked = True
        Me.optAscending3.Enabled = False
        Me.optAscending3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.optAscending3.Location = New System.Drawing.Point(196, 16)
        Me.optAscending3.Name = "optAscending3"
        Me.optAscending3.Size = New System.Drawing.Size(88, 16)
        Me.optAscending3.TabIndex = 1
        Me.optAscending3.TabStop = True
        Me.optAscending3.Text = "Ascending"
        '
        'cboColumn3
        '
        Me.cboColumn3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColumn3.Location = New System.Drawing.Point(8, 16)
        Me.cboColumn3.Name = "cboColumn3"
        Me.cboColumn3.Size = New System.Drawing.Size(180, 21)
        Me.cboColumn3.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Location = New System.Drawing.Point(312, 16)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(312, 46)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClear.Location = New System.Drawing.Point(312, 76)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(80, 24)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear All"
        '
        'frmSort
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(400, 302)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.btnCancel, Me.btnOK, Me.GroupBox4, Me.GroupBox3, Me.GroupBox2, Me.GroupBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmSort"
        Me.Text = "Sort"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overloads Function ShowDialog(ByVal grid As GridEX, ByVal parent As Form) As DialogResult
        Dim sortKey As GridEXSortKey
        Me.FillColumnList(grid.RootTable.Columns, Me.cboColumn0)
        Me.FillColumnList(grid.RootTable.Columns, Me.cboColumn1)
        Me.FillColumnList(grid.RootTable.Columns, Me.cboColumn2)
        Me.FillColumnList(grid.RootTable.Columns, Me.cboColumn3)
        With grid.RootTable.SortKeys
            If .Count = 0 Then
                SetSortKey(Nothing, True, cboColumn0, optAscending0, optDescending0)
            Else
                If .Count >= 1 Then
                    sortKey = .Item(0)
                    SetSortKey(sortKey.Column, (sortKey.SortOrder = SortOrder.Ascending), cboColumn0, optAscending0, optDescending0)
                End If
                If .Count >= 2 Then
                    sortKey = .Item(1)
                    SetSortKey(sortKey.Column, (sortKey.SortOrder = SortOrder.Ascending), cboColumn1, optAscending1, optDescending1)
                End If
                If .Count >= 3 Then
                    sortKey = .Item(2)
                    SetSortKey(sortKey.Column, (sortKey.SortOrder = SortOrder.Ascending), cboColumn2, optAscending2, optDescending2)
                End If
                If .Count >= 4 Then
                    sortKey = .Item(3)
                    SetSortKey(sortKey.Column, (sortKey.SortOrder = SortOrder.Ascending), cboColumn3, optAscending3, optDescending3)
                End If
            End If
        End With
        Me.ShowDialog(parent)
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            grid.RootTable.SortKeys.Clear()
            CreateSortKeys(grid)
        End If
        Return Me.DialogResult
    End Function
    Private Sub CreateSortKeys(ByVal grid As GridEX)
        Dim sortKeysCount As Integer
        If cboColumn3.SelectedIndex > 0 Then
            sortKeysCount = 4
        ElseIf cboColumn2.SelectedIndex > 0 Then
            sortKeysCount = 3
        ElseIf cboColumn1.SelectedIndex > 0 Then
            sortKeysCount = 2
        ElseIf cboColumn0.SelectedIndex > 0 Then
            sortKeysCount = 1
        Else
            sortKeysCount = 0
        End If
        Dim sortKeys(sortKeysCount - 1) As GridEXSortKey
        If sortKeysCount > 0 Then
            sortKeys(0) = CreateSortKey(CType(cboColumn0.SelectedItem, NamedObject).Value, optAscending0.Checked)
        End If
        If sortKeysCount > 1 Then
            sortKeys(1) = CreateSortKey(CType(cboColumn1.SelectedItem, NamedObject).Value, optAscending1.Checked)
        End If
        If sortKeysCount > 2 Then
            sortKeys(2) = CreateSortKey(CType(cboColumn2.SelectedItem, NamedObject).Value, optAscending2.Checked)
        End If
        If sortKeysCount > 3 Then
            sortKeys(3) = CreateSortKey(CType(cboColumn3.SelectedItem, NamedObject).Value, optAscending3.Checked)
        End If
        grid.RootTable.SortKeys.AddRange(sortKeys)
    End Sub
    Private Function CreateSortKey(ByVal column As GridEXColumn, ByVal ascending As Boolean) As GridEXSortKey
        Dim sortKey As GridEXSortKey = New GridEXSortKey()
        sortKey.Column = column
        If Not ascending Then
            sortKey.SortOrder = SortOrder.Descending
        End If
        Return sortKey
    End Function
    Private Sub FillColumnList(ByVal columns As GridEXColumnCollection, ByVal combo As ComboBox)
        Dim column As GridEXColumn
        Dim i As Integer
        combo.DisplayMember = "Name"
        combo.Items.Clear()
        combo.Items.Add(New NamedObject(Nothing, "(None)"))
        For i = 0 To columns.Count - 1
            column = columns.Item(i)
            If column.AllowSort Then
                combo.Items.Add(New NamedObject(column, column.Caption))
            End If
        Next
    End Sub
    Private Sub SetSortKey(ByVal column As GridEXColumn, ByVal ascending As Boolean, ByVal combo As ComboBox, ByVal optAscending As RadioButton, ByVal optDescending As RadioButton)
        Dim item As NamedObject
        If column Is Nothing Then
            combo.SelectedIndex = 0
        Else
            For Each item In combo.Items
                If item.Value Is column Then
                    combo.SelectedItem = item
                    Exit For
                End If
            Next
        End If
        If ascending Then
            optAscending.Checked = True
        Else
            optDescending.Checked = True
        End If
    End Sub
    Private Sub cboColumn0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColumn0.SelectedIndexChanged
        If cboColumn0.SelectedIndex = 0 Then
            Me.optAscending0.Enabled = False
            Me.optDescending0.Enabled = False
            cboColumn1.SelectedIndex = 0
            cboColumn1.Enabled = False
        Else
            Me.optAscending0.Enabled = True
            Me.optDescending0.Enabled = True
            cboColumn1.Enabled = True
            If cboColumn1.SelectedIndex = -1 Then
                cboColumn1.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cboColumn1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColumn1.SelectedIndexChanged
        If cboColumn1.SelectedIndex = 0 Then
            Me.optAscending1.Enabled = False
            Me.optDescending1.Enabled = False
            cboColumn2.SelectedIndex = 0
            cboColumn2.Enabled = False
        Else
            Me.optAscending1.Enabled = True
            Me.optDescending1.Enabled = True
            cboColumn2.Enabled = True
            If cboColumn2.SelectedIndex = -1 Then
                cboColumn2.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cboColumn2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColumn2.SelectedIndexChanged
        If cboColumn2.SelectedIndex = 0 Then
            Me.optAscending2.Enabled = False
            Me.optDescending2.Enabled = False
            cboColumn3.SelectedIndex = 0
            cboColumn3.Enabled = False
        Else
            Me.optAscending2.Enabled = True
            Me.optDescending2.Enabled = True
            cboColumn3.Enabled = True
            If cboColumn3.SelectedIndex = -1 Then
                cboColumn3.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cboColumn3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColumn3.SelectedIndexChanged
        If cboColumn3.SelectedIndex = 0 Then
            Me.optAscending3.Enabled = False
            Me.optDescending3.Enabled = False
        Else
            Me.optAscending3.Enabled = True
            Me.optDescending3.Enabled = True
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        cboColumn0.SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click


        Me.Close()
    End Sub

End Class
