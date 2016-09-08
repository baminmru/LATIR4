Imports System.Windows.Forms
Public Class frmRefDialog
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
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents dg As System.Windows.Forms.DataGrid
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.dg = New System.Windows.Forms.DataGrid()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(692, 328)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(70, 24)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.Location = New System.Drawing.Point(616, 328)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(70, 24)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        '
        'dg
        '
        Me.dg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg.DataMember = ""
        Me.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg.Location = New System.Drawing.Point(4, 0)
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.Size = New System.Drawing.Size(758, 322)
        Me.dg.TabIndex = 3
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmRefDialog
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(770, 359)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.dg)
        Me.MinimizeBox = False
        Me.Name = "frmRefDialog"
        Me.Text = "—сылка на строку"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public GuiManager As LATIRGuiManager
    Public ID As System.Guid
    Public Brief As String
    Public InstanceID As System.Guid
    Private mPartName As String
    Private Const ColWidth As Integer = 150

    Public Sub Attach(ByVal gm As LATIRGuiManager, Optional ByVal PartName As String = "", Optional ByVal Filter As String = "")
        GuiManager = gm
        Dim dt As DataTable
        Dim colDt As DataTable
        Dim va As String
        Dim pvid As System.Guid
        Dim ts As System.Windows.Forms.DataGridTableStyle
        Dim cs As DataGridTextBoxColumn
        Dim fc As DataGridTextBoxColumn
        Dim i As Integer

        ts = New DataGridTableStyle

        mPartName = PartName


        dt = GuiManager.Manager.Session.GetData("select caption from part where name='" & PartName & "'")
        If dt.Rows.Count = 0 Then Exit Sub
        Me.Text = dt.Rows(0)("Caption")


        If PartName <> "" Then
            va = GuiManager.Manager.Session.GetPartViewAlias(PartName)
            If va <> "" Then

                ' прочитать определение View 
                ' построить список колонок с мапингом

                colDt = GuiManager.Manager.Session.GetRowsDT("PartView", GuiManager.Manager.Session.GetProvider.ID2Base("partviewid"), "", "", "the_Alias='" & va & "'")


                pvid = New System.Guid(colDt.Rows(0).Item("partviewid").ToString())
                colDt = GuiManager.Manager.Session.GetRowsExDT("Viewcolumn", "name,the_alias,sequence", pvid.ToString, "", "", " order by sequence ")
                If colDt.Rows.Count = 0 Then Exit Sub

                ts.MappingName = va
                ts.ReadOnly = True
                ts.RowHeaderWidth = ColWidth

                For i = 0 To colDt.Rows.Count - 1
                    cs = New DataGridTextBoxColumn
                    cs.ReadOnly = True
                    cs.HeaderText = colDt.Rows(i).Item("Name")
                    cs.MappingName = colDt.Rows(i).Item("the_ALIAS")
                    cs.NullText = ""
                    If i = 0 Then fc = cs
                    cs.Width = ColWidth
                    ts.GridColumnStyles.Add(cs)

                Next

                'cs = New DataGridTextBoxColumn
                'cs.ReadOnly = True
                'cs.HeaderText = "—осто€ние"
                'cs.MappingName = "StatusName"
                'cs.NullText = ""

                'ts.GridColumnStyles.Add(cs)

                If InstanceID.Equals(System.Guid.Empty) Then
                    dt = GuiManager.Manager.Session.GetView(va, Filter, colDt.Rows(0)("the_alias"))
                Else
                    If Filter = "" Then
                        dt = GuiManager.Manager.Session.GetView(va, "Instanceid=" & GuiManager.Manager.Session.GetProvider.ID2Const(InstanceID), colDt.Rows(0)("the_alias"))
                    Else
                        dt = GuiManager.Manager.Session.GetView(va, "Instanceid=" & GuiManager.Manager.Session.GetProvider.ID2Const(InstanceID) & " and ( " & Filter & " )", colDt.Rows(0)("the_alias"))
                    End If
                End If

                dt.TableName = va
                dg.TableStyles.Add(ts)

            Else
                dt = GuiManager.Manager.Session.GetRowsExDT(PartName, GuiManager.Manager.Session.GetProvider.ID2Base(PartName + "ID", "ID") + "," + PartName + ".*", , , Filter)
                dt.TableName = PartName
            End If
        Else
            dt = GuiManager.Manager.Session.GetRowsExDT(PartName, GuiManager.Manager.Session.GetProvider.ID2Base(PartName + "ID", "ID") + "," + PartName + ".*", , , , Filter)
            dt.TableName = PartName
        End If

        If dt.TableName = PartName Then

            ts.MappingName = PartName
            ts.ReadOnly = True
            ts.RowHeaderWidth = ColWidth
            cs = New DataGridTextBoxColumn


            colDt = GuiManager.Manager.Session.GetRowsDT("Part", GuiManager.Manager.Session.GetProvider.ID2Base("partID", "ID") + ",part.*", "", "", "name='" & PartName & "'")

            pvid = New Guid(colDt.Rows(0).Item("id").ToString)
            colDt = GuiManager.Manager.Session.GetRowsDT("field", GuiManager.Manager.Session.GetProvider.ID2Base("fieldID", "ID") + ",field.*", pvid.ToString)
            If colDt.Rows.Count = 0 Then Exit Sub


            For i = 0 To colDt.Rows.Count - 1
                cs = New DataGridTextBoxColumn
                cs.ReadOnly = True
                cs.HeaderText = colDt.Rows(i).Item("Caption")
                cs.MappingName = colDt.Rows(i).Item("name")
                cs.NullText = ""
                cs.Width = ColWidth
                ts.GridColumnStyles.Add(cs)
            Next

            dg.TableStyles.Add(ts)
        End If
        dg.DataSource = dt
    End Sub
   
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim dt As DataTable
        dt = dg.DataSource
        If dg.CurrentCell.RowNumber >= 0 Then
            Try
                ID = New System.Guid(dt.DefaultView.Item(dg.CurrentCell.RowNumber).Item("ID").ToString())
            Catch ex As Exception
                ID = New System.Guid(dt.DefaultView.Item(dg.CurrentCell.RowNumber).Item(mPartName & "ID").ToString())
            End Try

            If ID.Equals(System.Guid.Empty) Then
                Exit Sub
            Else
                GuiManager.Manager.Session.GetBrief(mPartName, ID, Brief)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        End If
    End Sub
    Private Sub frmRefDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

    End Sub




End Class
