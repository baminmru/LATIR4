Imports Janus.Windows.GridEX

Public Class frmViewSummary
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
    Friend WithEvents btnFields As System.Windows.Forms.Button
    Friend WithEvents lblFields As System.Windows.Forms.Label
    Friend WithEvents lblGroupBy As System.Windows.Forms.Label
    Friend WithEvents btnGroupBy As System.Windows.Forms.Button
    Friend WithEvents lblSort As System.Windows.Forms.Label
    Friend WithEvents btnSort As System.Windows.Forms.Button
    Friend WithEvents lblFormat As System.Windows.Forms.Label
    Friend WithEvents btnFormat As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnAutoFormatting As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnAutoFormatting = New System.Windows.Forms.Button
        Me.lblFormat = New System.Windows.Forms.Label
        Me.btnFormat = New System.Windows.Forms.Button
        Me.lblSort = New System.Windows.Forms.Label
        Me.btnSort = New System.Windows.Forms.Button
        Me.lblGroupBy = New System.Windows.Forms.Label
        Me.btnGroupBy = New System.Windows.Forms.Button
        Me.lblFields = New System.Windows.Forms.Label
        Me.btnFields = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAutoFormatting)
        Me.GroupBox1.Controls.Add(Me.lblFormat)
        Me.GroupBox1.Controls.Add(Me.btnFormat)
        Me.GroupBox1.Controls.Add(Me.lblSort)
        Me.GroupBox1.Controls.Add(Me.btnSort)
        Me.GroupBox1.Controls.Add(Me.lblGroupBy)
        Me.GroupBox1.Controls.Add(Me.btnGroupBy)
        Me.GroupBox1.Controls.Add(Me.lblFields)
        Me.GroupBox1.Controls.Add(Me.btnFields)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(480, 197)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Description"
        '
        'btnAutoFormatting
        '
        Me.btnAutoFormatting.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAutoFormatting.Location = New System.Drawing.Point(8, 164)
        Me.btnAutoFormatting.Name = "btnAutoFormatting"
        Me.btnAutoFormatting.Size = New System.Drawing.Size(128, 24)
        Me.btnAutoFormatting.TabIndex = 8
        Me.btnAutoFormatting.Text = "Automatic Formatting..."
        '
        'lblFormat
        '
        Me.lblFormat.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblFormat.Location = New System.Drawing.Point(143, 126)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(327, 28)
        Me.lblFormat.TabIndex = 7
        Me.lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFormat
        '
        Me.btnFormat.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFormat.Location = New System.Drawing.Point(8, 128)
        Me.btnFormat.Name = "btnFormat"
        Me.btnFormat.Size = New System.Drawing.Size(128, 24)
        Me.btnFormat.TabIndex = 6
        Me.btnFormat.Text = "Format..."
        '
        'lblSort
        '
        Me.lblSort.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblSort.Location = New System.Drawing.Point(143, 90)
        Me.lblSort.Name = "lblSort"
        Me.lblSort.Size = New System.Drawing.Size(327, 28)
        Me.lblSort.TabIndex = 5
        Me.lblSort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSort
        '
        Me.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSort.Location = New System.Drawing.Point(8, 92)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.Size = New System.Drawing.Size(128, 24)
        Me.btnSort.TabIndex = 4
        Me.btnSort.Text = "Sort..."
        '
        'lblGroupBy
        '
        Me.lblGroupBy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblGroupBy.Location = New System.Drawing.Point(143, 54)
        Me.lblGroupBy.Name = "lblGroupBy"
        Me.lblGroupBy.Size = New System.Drawing.Size(327, 28)
        Me.lblGroupBy.TabIndex = 3
        Me.lblGroupBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGroupBy
        '
        Me.btnGroupBy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGroupBy.Location = New System.Drawing.Point(8, 56)
        Me.btnGroupBy.Name = "btnGroupBy"
        Me.btnGroupBy.Size = New System.Drawing.Size(128, 24)
        Me.btnGroupBy.TabIndex = 2
        Me.btnGroupBy.Text = "Group By..."
        '
        'lblFields
        '
        Me.lblFields.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblFields.Location = New System.Drawing.Point(143, 18)
        Me.lblFields.Name = "lblFields"
        Me.lblFields.Size = New System.Drawing.Size(327, 28)
        Me.lblFields.TabIndex = 1
        Me.lblFields.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFields
        '
        Me.btnFields.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFields.Location = New System.Drawing.Point(8, 20)
        Me.btnFields.Name = "btnFields"
        Me.btnFields.Size = New System.Drawing.Size(128, 24)
        Me.btnFields.TabIndex = 0
        Me.btnFields.Text = "Fields..."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(143, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(327, 28)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Condition font and color formatting."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(504, 56)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(504, 24)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        '
        'frmViewSummary
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(596, 234)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmViewSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "View Summary"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private mGridEX As GridEX
    Private mJournalView As JournalView

    Public Overloads Function ShowDialog(ByVal grid As GridEX, ByVal parent As Form, ByVal JournalView As JournalView) As Windows.Forms.DialogResult
        mGridEX = grid
        mJournalView = JournalView
        SetFieldsLabel()
        SetGroupByLabel()
        SetSortLabel()
        SetFormatLabel()
        If grid.RootTable.CellLayoutMode = CellLayoutMode.UseColumnSets Then
            Me.btnFields.Enabled = False
        End If
        If mGridEX.View <> View.TableView Then
            Me.btnGroupBy.Enabled = False
        End If
        Return Me.ShowDialog(parent)
    End Function
    Private Sub SetFieldsLabel()
        Dim strFields As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim column As GridEXColumn
        Dim i As Integer
        For i = 0 To mGridEX.RootTable.Columns.Count - 1
            column = mGridEX.RootTable.Columns.GetColumnInPosition(i)
            If column.Visible Then
                If strFields.Length > 0 Then
                    strFields.Append(", ")
                End If
                strFields.Append(column.Caption)
            End If
        Next
        Me.lblFields.Text = strFields.ToString()
    End Sub
    Private Sub SetGroupByLabel()

        Dim strFields As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim group As GridEXGroup
        If mGridEX.RootTable.Groups.Count = 0 Then
            Me.lblGroupBy.Text = "None"
        Else
            For Each group In mGridEX.RootTable.Groups
                If strFields.Length > 0 Then
                    strFields.Append(", ")
                End If
                strFields.Append(group.Column.Caption)
                If group.SortOrder = SortOrder.Ascending Then
                    strFields.Append(" (Ascending)")
                Else
                    strFields.Append(" (Descending)")
                End If
            Next

            Me.lblGroupBy.Text = strFields.ToString()
        End If
    End Sub
    Private Sub SetSortLabel()
        Dim strFields As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim sortKey As GridEXSortKey
        If mGridEX.RootTable.SortKeys.Count = 0 Then
            Me.lblSort.Text = "None"
        Else
            For Each sortKey In mGridEX.RootTable.SortKeys
                If strFields.Length > 0 Then
                    strFields.Append(", ")
                End If
                strFields.Append(sortKey.Column.Caption)
                If sortKey.SortOrder = SortOrder.Ascending Then
                    strFields.Append(" (Ascending)")
                Else
                    strFields.Append(" (Descending)")
                End If
            Next
            Me.lblSort.Text = strFields.ToString()
        End If
    End Sub
    Private Sub SetFormatLabel()
        If mGridEX.View = View.TableView Then
            lblFormat.Text = "Fonts and other Table View settings."
        Else
            lblFormat.Text = "Fonts and other Card View settings."
        End If
    End Sub
    Private Sub btnFields_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFields.Click
        mJournalView.ShowFields()
        SetFieldsLabel()
    End Sub

    Private Sub btnGroupBy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGroupBy.Click
        mJournalView.ShowGroupBy()
        SetGroupByLabel()
    End Sub

    Private Sub btnSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSort.Click
        mJournalView.ShowSort()
        SetSortLabel()
    End Sub

    Private Sub btnFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormat.Click
        mJournalView.ShowFormatView()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAutoFormatting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoFormatting.Click
        mJournalView.ShowFormatConditions()
    End Sub

    Private Sub frmViewSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
