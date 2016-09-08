Imports System.Windows.Forms
Public Class frmObjectDialog
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
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents dg As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dg = New System.Windows.Forms.DataGrid()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg
        '
        Me.dg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg.DataMember = ""
        Me.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg.Location = New System.Drawing.Point(8, 8)
        Me.dg.Name = "dg"
        Me.dg.Size = New System.Drawing.Size(751, 356)
        Me.dg.TabIndex = 0
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(613, 370)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(70, 24)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(689, 370)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(70, 24)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        '
        'frmObjectDialog
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(767, 401)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.dg)
        Me.MinimizeBox = False
        Me.Name = "frmObjectDialog"
        Me.Text = "Выбор документа"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public GuiManager As LATIRGuiManager
    Public ID As System.Guid
    Public Brief As String

    Public Sub Attach(ByVal gm As LATIRGuiManager, Optional ByVal TypeName As String = "", Optional ByVal Filter As String = "")
        GuiManager = gm
        Dim dt As DataTable
        Dim va As String
        Dim colDt As DataTable
        Dim pvid As System.Guid
        Dim ts As System.Windows.Forms.DataGridTableStyle
        Dim cs As DataGridTextBoxColumn
        Dim i As Integer

        ts = New DataGridTableStyle

        If TypeName <> "" Then
            va = GuiManager.Manager.Session.GetTypeViewAlias(TypeName)
            If va <> "" Then

                ' прочитать определение View 
                ' построить список колонок с мапингом
                colDt = GuiManager.Manager.Session.GetRowsDT("PartView", GuiManager.Manager.Session.GetProvider.ID2Base("partviewid"), "", "", "the_Alias='" & va & "'")

                pvid = colDt.Rows(0).Item("partviewid")
                colDt = GuiManager.Manager.Session.GetRowsDT("Viewcolumn", "*", pvid.ToString)
                If colDt.Rows.Count = 0 Then Exit Sub

                ts.MappingName = va
                ts.ReadOnly = True
                ts.RowHeaderWidth = 30


                For i = 0 To colDt.Rows.Count - 1
                    cs = New DataGridTextBoxColumn
                    cs.ReadOnly = True
                    cs.HeaderText = colDt.Rows(i).Item("Name")
                    cs.MappingName = colDt.Rows(i).Item("the_ALIAS")
                    cs.NullText = ""
                    ts.GridColumnStyles.Add(cs)

                Next

                cs = New DataGridTextBoxColumn
                cs.ReadOnly = True
                cs.HeaderText = "Состояние"
                cs.MappingName = "StatusName"
                cs.NullText = ""
                ts.GridColumnStyles.Add(cs)
                dt = GuiManager.Manager.Session.GetView(va, Filter)
                dt.TableName = va
                dg.TableStyles.Add(ts)



            Else
                dt = GuiManager.Manager.Session.GetRowsExDT("V_INSTANCE", "*", , , "OBJType='" & TypeName & "'", "order by Name")
                dt.TableName = "V_INSTANCE"
            End If
        Else
            dt = GuiManager.Manager.Session.GetRowsExDT("V_INSTANCE", "*", , , "", "order by Name")
            dt.TableName = "V_INSTANCE"
        End If

        If dt.TableName = "V_INSTANCE" Then
            ts.MappingName = "V_INSTANCE"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30



            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Название"
            cs.MappingName = "Name"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)



            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Состояние"
            cs.MappingName = "StatusName"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            dg.TableStyles.Add(ts)

        End If
        dg.DataSource = dt
    End Sub



    Private Sub frmObjectDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim dt As DataTable
        dt = dg.DataSource
        If dg.CurrentCell.RowNumber >= 0 Then
            ID = New Guid(dt.DefaultView.Item(dg.CurrentCell.RowNumber).Item("InstanceID").ToString)
            If ID.Equals(System.Guid.Empty) Then
                Exit Sub
            Else
                GuiManager.Manager.Session.GetBrief("INSTANCE", ID, Brief)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        End If
    End Sub

   
End Class
