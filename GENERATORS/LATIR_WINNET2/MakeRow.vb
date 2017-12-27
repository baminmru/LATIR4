Option Strict Off
Option Explicit On

Imports LATIR2Framework.StringHelper
Module MakeRowProc

    'Public Sub GenerateControls(fd As Object, fld As FIELD, pos As Long, SaveFields As String, LoadFields As String, COLUMN As Long, MINPOS As Long, pname As String, body As String, decl As String, GenStyle As String, IsOK As String, Optional ReadOnly As Boolean = False)
    Public Sub MakeRowForm(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef o As LATIRGenerator.Response, ByVal mode As String)
        Dim s As String = String.Empty
        Try
            s = s & vbCrLf & "Imports System.Windows.Forms"
            s = s & vbCrLf & "Imports Microsoft.VisualBasic"
            s = s & vbCrLf & "Imports System.Diagnostics"
            s = s & vbCrLf & "Imports System.Drawing"


            s = s & vbCrLf & MakeComment("Форма редактирования раздела " & p.Caption & " режим:" & mode)

            s = s & vbCrLf & "Public Class frm" & p.Name & mode
            s = s & vbCrLf & "    Inherits System.Windows.Forms.Form"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "#Region "" Windows Form Designer generated code """
            s = s & vbCrLf & ""
            s = s & vbCrLf & "    Public Sub New()"
            s = s & vbCrLf & "        MyBase.New()"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "        'This call is required by the Windows Form Designer."
            s = s & vbCrLf & "        InitializeComponent()"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "        'Add any initialization after the InitializeComponent() call"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "    End Sub"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "    'Form overrides dispose to clean up the component list."
            s = s & vbCrLf & "    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)"
            s = s & vbCrLf & "        If disposing Then"
            s = s & vbCrLf & "            If Not (components Is Nothing) Then"
            s = s & vbCrLf & "                components.Dispose()"
            s = s & vbCrLf & "            End If"
            s = s & vbCrLf & "        End If"
            s = s & vbCrLf & "        MyBase.Dispose (disposing)"
            s = s & vbCrLf & "    End Sub"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "    'Required by the Windows Form Designer"
            s = s & vbCrLf & "    Private components As System.ComponentModel.IContainer"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "    'NOTE: The following procedure is required by the Windows Form Designer"
            s = s & vbCrLf & "    'It can be modified using the Windows Form Designer."
            s = s & vbCrLf & "    'Do not modify it using the code editor."
            s = s & vbCrLf & "    Friend WithEvents btnPanel As System.Windows.Forms.Panel"
            s = s & vbCrLf & "    Friend WithEvents edPanel As System.Windows.Forms.Panel"
            s = s & vbCrLf & "    Friend WithEvents btnCancel As System.Windows.Forms.Button"
            s = s & vbCrLf & "    Friend WithEvents btnOK As System.Windows.Forms.Button"
            s = s & vbCrLf & "    Friend WithEvents Edit" & p.Name & " As " & ot.Name & "GUI.edit" & p.Name & mode
            s = s & vbCrLf & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
            s = s & vbCrLf & "        Me.btnPanel = New System.Windows.Forms.Panel"
            s = s & vbCrLf & "        Me.btnCancel = New System.Windows.Forms.Button"
            s = s & vbCrLf & "        Me.btnOK = New System.Windows.Forms.Button"
            s = s & vbCrLf & "        Me.Edit" & p.Name & " = New " & ot.Name & "GUI.Edit" & p.Name & mode
            s = s & vbCrLf & "        Me.btnPanel.SuspendLayout()"
            s = s & vbCrLf & "        Me.SuspendLayout()"


            s = s & vbCrLf & "        'btnOK"
            s = s & vbCrLf & "        '"
            s = s & vbCrLf & "        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)"
            s = s & vbCrLf & "        Me.btnOK.Location = New System.Drawing.Point(5, 3)"
            s = s & vbCrLf & "        Me.btnOK.name = ""btnOK"""
            s = s & vbCrLf & "        Me.btnOK.Size = New System.Drawing.Size(80, 24)"
            s = s & vbCrLf & "        Me.btnOK.TabIndex = 18"
            s = s & vbCrLf & "        Me.btnOK.Text = ""ОК"""

            s = s & vbCrLf & "        '"
            s = s & vbCrLf & "        'btnCancel"
            s = s & vbCrLf & "        '"
            s = s & vbCrLf & "        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)"
            s = s & vbCrLf & "        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel"
            s = s & vbCrLf & "        Me.btnCancel.Location = New System.Drawing.Point(90, 3)"
            s = s & vbCrLf & "        Me.btnCancel.name = ""btnCancel"""
            s = s & vbCrLf & "        Me.btnCancel.Size = New System.Drawing.Size(80, 24)"
            s = s & vbCrLf & "        Me.btnCancel.TabIndex = 19"
            s = s & vbCrLf & "        Me.btnCancel.Text = ""Cancel"""
            s = s & vbCrLf & "        '"


            s = s & vbCrLf & "        '"
            s = s & vbCrLf & "        'btnPanel"
            s = s & vbCrLf & "        '"
            s = s & vbCrLf & "        Me.btnPanel.Controls.Add (Me.btnCancel)"
            s = s & vbCrLf & "        Me.btnPanel.Controls.Add (Me.btnOK)"
            s = s & vbCrLf & "        Me.btnPanel.Dock = System.Windows.Forms.DockStyle.Bottom"
            s = s & vbCrLf & "        Me.btnPanel.Location = New System.Drawing.Point(0, 500)"
            s = s & vbCrLf & "        Me.btnPanel.name = ""btnPanel"""
            s = s & vbCrLf & "        Me.btnPanel.Size = New System.Drawing.Size(500, 32)"
            s = s & vbCrLf & "        Me.btnPanel.TabIndex = 21"

            s = s & vbCrLf & "        '"
            s = s & vbCrLf & "        'Edit" & p.Name
            s = s & vbCrLf & "        '"
            s = s & vbCrLf & "        Me.Edit" & p.Name & ".AutoScroll = True"
            s = s & vbCrLf & "        Me.Edit" & p.Name & ".Location = New System.Drawing.Point(8, 8)"
            s = s & vbCrLf & "        Me.Edit" & p.Name & ".name = ""Edit" & p.Name & """"
            s = s & vbCrLf & "        Me.Edit" & p.Name & ".Size = New System.Drawing.Size(800-40-16, 600-16)"
            s = s & vbCrLf & "        Me.Edit" & p.Name & ".TabIndex = 20"
            s = s & vbCrLf & "        Me.Edit" & p.Name & ".Dock = System.Windows.Forms.DockStyle.Fill"


            s = s & vbCrLf & "        '"
            s = s & vbCrLf & "        'frm" & p.Name & ""
            s = s & vbCrLf & "        '"
            s = s & vbCrLf & "        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)"
            s = s & vbCrLf & "        Me.ClientSize = New System.Drawing.Size(800, 600)"
            s = s & vbCrLf & "        Me.Controls.Add (Edit" & p.Name & ")"
            s = s & vbCrLf & "        Me.Controls.Add (Me.btnPanel)"
            s = s & vbCrLf & "        Me.name = ""frm" & p.Name & """"
            s = s & vbCrLf & "        Me.Text = """ & p.Caption & """"
            s = s & vbCrLf & "        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen"
            s = s & vbCrLf & "        Me.ResumeLayout (False)"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "    End Sub"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "#End Region"


            s = s & vbCrLf & "    Public Item As " & ot.Name & "." & ot.Name & "." & p.Name & ""
            's = s & vbCrLf & "    Public Item As " &  ot.Name & "." & p.Name & ""
            s = s & vbCrLf & "    Public GuiManager As LATIR2GuiManager.LATIRGuiManager"
            s = s & vbCrLf & "    Private myResizer As LATIR2GuiManager.Resizer = New LATIR2GuiManager.Resizer"
            s = s & vbCrLf & "    Private mReadOnly As Boolean"
            s = s & vbCrLf & ""
            s = s & vbCrLf & MakeComment("Инициализация")
            s = s & vbCrLf & "    Public Sub Attach(ByVal RowItem As LATIR2.Document.DocRow_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, Optional ByVal FormReadOnly As Boolean =False)"
            s = s & vbCrLf & "        Item = CType(RowItem, " & ot.Name & "." & ot.Name & "." & p.Name & ")"
            's = s & vbCrLf & "        Item = CType(RowItem, " & ot.Name & "." & p.Name & ")"
            s = s & vbCrLf & "        GuiManager = gm"
            s = s & vbCrLf & "        mReadOnly = FormReadOnly"
            s = s & vbCrLf & "        Edit" & p.Name & ".Attach(GuiManager, Item, FormReadOnly)"
            s = s & vbCrLf & "        btnOK.Enabled = False"
            s = s & vbCrLf & "    End Sub"
            s = s & vbCrLf & ""

            s = s & vbCrLf & "    Private Sub Edit" & p.Name & "_Changed() Handles Edit" & p.Name & ".Changed"
            s = s & vbCrLf & "        If Not mReadOnly Then"
            s = s & vbCrLf & "          btnOK.Enabled = True"
            s = s & vbCrLf & "        End If"
            s = s & vbCrLf & "    End Sub"

            s = s & vbCrLf & MakeComment("Завершение редактирования")
            s = s & vbCrLf & "    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click"
            s = s & vbCrLf & "      If Not mReadOnly Then"

            s = s & vbCrLf & "        If Edit" & p.Name & ".IsOK() Then"
            s = s & vbCrLf & "          Edit" & p.Name & ".Save()"
            s = s & vbCrLf & "         Try"
            s = s & vbCrLf & "          Item.Save()"
            s = s & vbCrLf & "          Me.DialogResult = System.Windows.Forms.DialogResult.OK"
            s = s & vbCrLf & "          Me.Close"
            s = s & vbCrLf & "        Catch ex As System.Exception"
            s = s & vbCrLf & "          MsgBox(ex.Message,vbOKOnly+vbCritical,""Ошибка"")"
            s = s & vbCrLf & "        End Try"
            s = s & vbCrLf & "        Else"
            s = s & vbCrLf & "          MsgBox(""Не все обязательные пля заполнены"",vbOKOnly+vbExclamation,""Ошибка"")"
            s = s & vbCrLf & "        End If"
            s = s & vbCrLf & "        Exit Sub"
            s = s & vbCrLf & "        End If"
            s = s & vbCrLf & "    End Sub"



            s = s & vbCrLf & "    Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated"
            ' s = s & vbCrLf & "        if GetSetting(""LATIR4"", ""CFG"", ""TABTIP"", ""true"")=""false"" then "
            's = s & vbCrLf & "          Me.ClientSize() = New System.Drawing.Size(Edit" & p.Name & ".GetMaxX() + 10, Edit" & p.Name & ".GetMaxY() + 35)"
            's = s & vbCrLf & "        else "
            s = s & vbCrLf & "          Me.StartPosition = FormStartPosition.Manual"
            s = s & vbCrLf & "          Me.WindowState = FormWindowState.Normal"
            s = s & vbCrLf & "          Me.Location = Screen.PrimaryScreen.WorkingArea.Location"
            s = s & vbCrLf & "          Me.Size = Screen.PrimaryScreen.WorkingArea.Size"
            's = s & vbCrLf & "        end if "
            ' s = s & vbCrLf & "        myResizer.ResizeAllControls(Me)"
            s = s & vbCrLf & "    End Sub"


            s = s & vbCrLf & "    Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load"
            s = s & vbCrLf & "        Me.ClientSize() = New System.Drawing.Size(Edit" & p.Name & ".GetMaxX() + 10, Edit" & p.Name & ".GetMaxY() + 35)"
            ' s = s & vbCrLf & "        LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)"
            s = s & vbCrLf & "        myResizer.FindAllControls(Me) "
            's = s & vbCrLf & "        Me.StartPosition = FormStartPosition.Manual"
            's = s & vbCrLf & "        Me.WindowState = FormWindowState.Normal"
            's = s & vbCrLf & "        Me.Location = Screen.PrimaryScreen.WorkingArea.Location"
            's = s & vbCrLf & "        Me.Size = Screen.PrimaryScreen.WorkingArea.Size"
            ' s = s & vbCrLf & "        myResizer.ResizeAllControls(Me)"
            s = s & vbCrLf & "    End Sub"


            s = s & vbCrLf & "    Private Sub frm_Resize(sender As Object, e As EventArgs) Handles Me.Resize"
            s = s & vbCrLf & "      myResizer.ResizeAllControls(Me)"
            s = s & vbCrLf & "   End Sub"

            s = s & vbCrLf & "End Class"


            LATIR2Framework.StringHelper.SetExt(o, "frm" & p.Name & mode, "vb")
            o.Block = "code"
            o.OutNL(s)
            Dim i As Short
            For i = 1 To p.PART.Count
                MakeRowForm(tid, m, ot, p.PART.Item(i), o, mode)
            Next
        Catch ex As Exception
            Debug.Print(ex.Message + " >> " + ex.StackTrace)
        End Try
    End Sub

    Public Sub MakeRow(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef o As LATIRGenerator.Response, ByVal mode As String)
        Dim s As String = String.Empty
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim p1 As MTZMetaModel.MTZMetaModel.PART
        Dim n1 As String
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim decl As String
        Dim create As String = String.Empty
        Dim addctl As String = String.Empty

        Dim IsFieldReadOnly As Boolean
        Dim IsFieldPresent As Boolean
        Dim mproc, txt As String
        Dim pp, pos As Integer
        Dim tabidx As Short
        Dim column As Short
        Dim MINPOS As Short
        Dim GENSTYLE As String
        Dim IsOK As String = String.Empty
        Dim loadFields As String = String.Empty
        Dim saveFields As String = String.Empty
        Dim tt As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim sp As String = String.Empty
        tt = LATIR2Framework.ObjectTypeHelper.TypeForStruct(p)
        MINPOS = 5
        IsFieldReadOnly = False

        Dim ctlName As String
        'p.FIELD.Sort = "sequence"

        Try
            decl = " Dim iii As Integer"
            decl = decl & vbCrLf & "    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel"


            s = s & vbCrLf & "Imports System.Windows.Forms"
            s = s & vbCrLf & "Imports Microsoft.VisualBasic"
            s = s & vbCrLf & "Imports System.Diagnostics"
            s = s & vbCrLf
            s = s & vbCrLf & MakeComment("Контрол редактирования раздела " & p.Caption & " режим:" & mode)
            s = s & vbCrLf & "Public Class edit" & p.Name & mode
            s = s & vbCrLf & "    Inherits System.Windows.Forms.UserControl"
            s = s & vbCrLf & "    Implements LATIR2GUIManager.IRowEditor"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "#Region "" Windows Form Designer generated code """
            s = s & vbCrLf & ""
            s = s & vbCrLf & "    Public Sub New()"
            s = s & vbCrLf & "        MyBase.New()"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "        'This call is required by the Windows Form Designer."
            s = s & vbCrLf & "        InitializeComponent()"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "        'Add any initialization after the InitializeComponent() call"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "    End Sub"

            s = s & vbCrLf & "    private mOnInit as boolean = false"
            s = s & vbCrLf & "    private mChanged as boolean = false"
            s = s & vbCrLf & "    public event Changed() Implements LATIR2GUIManager.IRowEditor.Changed "
            s = s & vbCrLf & "    Public Event Saved() Implements LATIR2GUIManager.IRowEditor.Saved"
            s = s & vbCrLf & "    Public Event Refreshed() Implements LATIR2GUIManager.IRowEditor.Refreshed"

            s = s & vbCrLf & "    Public Sub Changing()"
            s = s & vbCrLf & "      if not mOnInit then"
            s = s & vbCrLf & "        mChanged = true"
            s = s & vbCrLf & "        raiseevent Changed()"
            s = s & vbCrLf & "      end if"
            s = s & vbCrLf & "    End Sub"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "    'UserControl overrides dispose to clean up the component list."
            s = s & vbCrLf & "    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)"
            s = s & vbCrLf & "        If disposing Then"
            s = s & vbCrLf & "            If Not (components Is Nothing) Then"
            s = s & vbCrLf & "                components.Dispose()"
            s = s & vbCrLf & "            End If"
            s = s & vbCrLf & "        End If"
            s = s & vbCrLf & "        MyBase.Dispose (disposing)"
            s = s & vbCrLf & "    End Sub"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "    'Required by the Windows Form Designer"
            s = s & vbCrLf & "    Private components As System.ComponentModel.IContainer"

            s = s & vbCrLf & ""
            s = s & vbCrLf & "%%DECL%%"
            '''''''''''''' decl - here
            s = s & vbCrLf & ""
            s = s & vbCrLf & "<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
            s = s & vbCrLf & "%%CREATE%%"
            s = s & vbCrLf
            '''''''''''''' Create - here

            create = create & vbCrLf & " Me.HolderPanel = New LATIR2GUIControls.AutoPanel"
            create = create & vbCrLf & " Me.HolderPanel.SuspendLayout()"
            create = create & vbCrLf & "Me.SuspendLayout()"
            create = create & vbCrLf & " '"
            create = create & vbCrLf & "'HolderPanel"
            create = create & vbCrLf & "'"
            create = create & vbCrLf & "Me.HolderPanel.AllowDrop = True"
            create = create & vbCrLf & "Me.HolderPanel.BackColor = System.Drawing.SystemColors.Control"
            create = create & vbCrLf & "Me.HolderPanel.Dock = System.Windows.Forms.DockStyle.Fill"
            create = create & vbCrLf & "Me.HolderPanel.Location = New System.Drawing.Point(0, 0)"
            create = create & vbCrLf & "Me.HolderPanel.Name = ""HolderPanel"""
            create = create & vbCrLf & "Me.HolderPanel.Size = New System.Drawing.Size(232, 120)"
            create = create & vbCrLf & "Me.HolderPanel.TabIndex = 0"


            pos = MINPOS
            tabidx = 1
            Dim strScript As String = String.Empty
            Dim ii As Integer
            p.FIELD.Sort = "sequence"
            For i = 1 To p.FIELD.Count
                f = p.FIELD.Item(i)
                IsFieldPresent = LATIR2Framework.ObjectHelper.IsFieldPresent(p, f.ID.ToString, mode)
                If IsFieldPresent Then
                    IsFieldReadOnly = LATIR2Framework.ObjectHelper.IsFieldReadOnly(p, f.ID.ToString, mode)

                    If pos > 420 Then
                        column = column + 1
                        pos = MINPOS
                    End If

                    decl = decl & vbCrLf & "Friend WithEvents lbl" & f.Name & "  as  System.Windows.Forms.Label"
                    create = create & vbCrLf & "Me.lbl" & f.Name & " = New System.Windows.Forms.Label"
                    addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbl" & f.Name & ")"

                    ft = f.FieldType

                    s = s & vbCrLf & "Me.lbl" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                    s = s & vbCrLf & "Me.lbl" & f.Name & ".name = ""lbl" & f.Name & """"
                    s = s & vbCrLf & "Me.lbl" & f.Name & ".Size = New System.Drawing.Size(200, 20)"
                    s = s & vbCrLf & "Me.lbl" & f.Name & ".TabIndex = " & tabidx
                    s = s & vbCrLf & "Me.lbl" & f.Name & ".Text = """ & LATIR2Framework.StringHelper.NoLF(f.Caption) & """"
                    tabidx = tabidx + 1

                    If f.AllowNull Then
                        s = s & vbCrLf & "Me.lbl" & f.Name & ".ForeColor = System.Drawing.Color.Blue"
                    Else
                        s = s & vbCrLf & "Me.lbl" & f.Name & ".ForeColor = System.Drawing.Color.Black"
                    End If

                    pos = pos + 22
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' control labeled

                    GENSTYLE = LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, False)

                    If GENSTYLE = "REFERENCE" Then

                        decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As LATIR2GuiManager.TouchTextBox"
                        decl = decl & vbCrLf & "Friend WithEvents cmd" & f.Name & " As System.Windows.Forms.Button"
                        create = create & vbCrLf & "Me.txt" & f.Name & " = New LATIR2GuiManager.TouchTextBox"
                        create = create & vbCrLf & "Me.cmd" & f.Name & " = New System.Windows.Forms.Button"
                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txt" & f.Name & ")"
                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmd" & f.Name & ")"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".name = ""txt" & f.Name & """"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"

                        If f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(155, 20)"
                        Else
                            s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(176, 20)"
                        End If

                        s = s & vbCrLf & "Me.txt" & f.Name & ".TabIndex = " & tabidx
                        s = s & vbCrLf & "Me.txt" & f.Name & ".Text = """" "
                        tabidx = tabidx + 1

                        If f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            s = s & vbCrLf & "Me.cmd" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20 + 156) & "," & pos & ")"
                        Else
                            s = s & vbCrLf & "Me.cmd" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20 + 178) & "," & pos & ")"
                        End If

                        s = s & vbCrLf & "Me.cmd" & f.Name & ".name = ""cmd" & f.Name & """"
                        s = s & vbCrLf & "Me.cmd" & f.Name & ".Size = New System.Drawing.Size(22, 20)"
                        s = s & vbCrLf & "Me.cmd" & f.Name & ".TabIndex = " & tabidx
                        s = s & vbCrLf & "Me.cmd" & f.Name & ".Text = ""..."" "

                        tabidx = tabidx + 1

                        If f.AllowNull = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then

                            decl = decl & vbCrLf & "Friend WithEvents cmd" & f.Name & "Clear As System.Windows.Forms.Button"
                            create = create & vbCrLf & "Me.cmd" & f.Name & "Clear = New System.Windows.Forms.Button"
                            addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmd" & f.Name & "Clear)"

                            s = s & vbCrLf & "Me.cmd" & f.Name & "Clear.Location = New System.Drawing.Point(" & (210 * column + 20 + 178) & "," & pos & ")"
                            s = s & vbCrLf & "Me.cmd" & f.Name & "Clear.name = ""cmd" & f.Name & "Clear"""
                            s = s & vbCrLf & "Me.cmd" & f.Name & "Clear.Size = New System.Drawing.Size(22, 20)"
                            s = s & vbCrLf & "Me.cmd" & f.Name & "Clear.TabIndex = " & tabidx
                            s = s & vbCrLf & "Me.cmd" & f.Name & "Clear.Text = ""X"" "

                            tabidx = tabidx + 1
                        End If

                        pos = pos + 25

                        sp = sp & vbCrLf & "private sub txt" & f.Name & "_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt" & f.Name & ".TextChanged"
                        sp = sp & vbCrLf & "  Changing"
                        sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)

                        sp = sp & vbCrLf & "end sub"

                        If Not f.AllowNull Then
                            IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK = not txt" & f.Name & ".Tag.Equals(System.Guid.Empty)"
                        End If

                        loadFields = loadFields & vbCrLf & "If Not item." & f.Name & " Is Nothing Then"
                        loadFields = loadFields & vbCrLf & "  txt" & f.Name & ".Tag = item." & f.Name & ".id"
                        loadFields = loadFields & vbCrLf & "  txt" & f.Name & ".text = item." & f.Name & ".brief"
                        loadFields = loadFields & vbCrLf & "else"
                        loadFields = loadFields & vbCrLf & "  txt" & f.Name & ".Tag = System.Guid.Empty "
                        loadFields = loadFields & vbCrLf & "  txt" & f.Name & ".text = """" "
                        loadFields = loadFields & vbCrLf & "End If"


                        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then

                            saveFields = saveFields & vbCrLf & "If not txt" & f.Name & ".Tag.Equals(System.Guid.Empty) Then"
                            saveFields = saveFields & vbCrLf & "   item." & f.Name & " = GuiManager.Manager.GetInstanceObject(txt" & f.Name & ".Tag)"
                            saveFields = saveFields & vbCrLf & "Else"
                            saveFields = saveFields & vbCrLf & "   item." & f.Name & " = Nothing"
                            saveFields = saveFields & vbCrLf & "End If"

                            sp = sp & vbCrLf & "private sub cmd" & f.Name & "_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd" & f.Name & ".Click"

                            sp = sp & vbCrLf & "  try"
                            sp = sp & vbCrLf & "Dim id As guid"
                            sp = sp & vbCrLf & "Dim brief As String  = string.Empty"
                            sp = sp & vbCrLf & "Dim OK as boolean"

                            If f.RefToType Is Nothing Then
                                If strScript <> "" Then
                                    sp = sp & vbCrLf & "        OK=GuiManager.GetObjectDialog("""",""" & strScript & """,id,brief)"
                                Else
                                    sp = sp & vbCrLf & "        OK=GuiManager.GetObjectDialog("""","""",id,brief)"
                                End If
                            Else
                                If strScript <> "" Then

                                    sp = sp & vbCrLf & "       OK=GuiManager.GetObjectDialog(""" & CType(f.RefToType, MTZMetaModel.MTZMetaModel.OBJECTTYPE).Name & """,""" & strScript & """,id,brief)"
                                Else

                                    sp = sp & vbCrLf & "       OK=GuiManager.GetObjectDialog(""" & CType(f.RefToType, MTZMetaModel.MTZMetaModel.OBJECTTYPE).Name & ""","""",id,brief)"
                                End If
                            End If

                            sp = sp & vbCrLf & "If OK Then"
                            sp = sp & vbCrLf & "    txt" & f.Name & ".Text = brief"
                            sp = sp & vbCrLf & "    txt" & f.Name & ".Tag = id"
                            sp = sp & vbCrLf & "End If"
                            sp = sp & vbCrLf & "        catch ex as system.Exception"
                            sp = sp & vbCrLf & "        Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                            sp = sp & vbCrLf & "        end try"
                            sp = sp & vbCrLf & "End Sub"
                        End If ' Ref to object

                        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then

                            If Not IsFieldReadOnly Then
                                saveFields = saveFields & vbCrLf & "If not txt" & f.Name & ".Tag.Equals(System.Guid.Empty) Then"

                                saveFields = saveFields & vbCrLf & "  item." & f.Name & " = Item.Application.FindRowObject(""" & CType(f.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & """,txt" & f.Name & ".Tag)"
                                saveFields = saveFields & vbCrLf & "Else"
                                saveFields = saveFields & vbCrLf & "   item." & f.Name & " = Nothing"
                                saveFields = saveFields & vbCrLf & "End If"
                            End If ' not readonly

                            sp = sp & vbCrLf & "private sub cmd" & f.Name & "_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd" & f.Name & ".Click"
                            sp = sp & vbCrLf & "  try"
                            sp = sp & vbCrLf & "Dim id As guid"
                            sp = sp & vbCrLf & "Dim brief As String = string.Empty"
                            sp = sp & vbCrLf & "Dim OK as boolean "

                            If Not IsFieldReadOnly Then

                                strScript = LATIR2Framework.ObjectHelper.GetDynamicFieldFilter(f.DINAMICFILTERSCRIPT, tid)
                                If strScript <> "" Then

                                    If f.InternalReference = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                                        sp = sp & vbCrLf & "        If GuiManager.GetReferenceDialog(""" & CType(f.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & """," & strScript & ",item.application.ID, id, brief) Then"
                                    Else
                                        sp = sp & vbCrLf & "        If GuiManager.GetReferenceDialog(""" & CType(f.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & """," & strScript & ",System.guid.Empty, id, brief) Then"
                                    End If
                                Else
                                    If f.InternalReference = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                                        sp = sp & vbCrLf & "        If GuiManager.GetReferenceDialog(""" & CType(f.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & ""","""",item.application.ID, id, brief) Then"
                                    Else
                                        sp = sp & vbCrLf & "        If GuiManager.GetReferenceDialog(""" & CType(f.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & ""","""",System.guid.Empty, id, brief) Then"
                                    End If
                                End If
                                sp = sp & vbCrLf & "          txt" & f.Name & ".Tag = id"
                                sp = sp & vbCrLf & "          txt" & f.Name & ".text = brief"
                                sp = sp & vbCrLf & "        End If"

                            Else
                                sp = sp & vbCrLf & "        MsgBox (""Режим не предусматривает редактирования"",vbInformation)"
                            End If ' not readonly
                            sp = sp & vbCrLf & "        catch ex as System.Exception"
                            sp = sp & vbCrLf & "        Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                            sp = sp & vbCrLf & "        end try"
                            sp = sp & vbCrLf & "end sub"


                            If f.AllowNull Then
                                sp = sp & vbCrLf & "private sub cmd" & f.Name & "Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd" & f.Name & "Clear.Click"
                                sp = sp & vbCrLf & "  try"
                                If Not IsFieldReadOnly Then
                                    sp = sp & vbCrLf & "          txt" & f.Name & ".Tag = Guid.Empty"
                                    sp = sp & vbCrLf & "          txt" & f.Name & ".text = """""
                                Else
                                    sp = sp & vbCrLf & "        MsgBox (""Режим не предусматривает редактирования"",vbInformation)"
                                End If ' not readonly
                                sp = sp & vbCrLf & "        catch ex as System.Exception"
                                sp = sp & vbCrLf & "        Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                                sp = sp & vbCrLf & "        end try"
                                sp = sp & vbCrLf & "end sub"
                            End If

                        End If ' ref to row

                    End If 'REFERENCE

                    If GENSTYLE = "TEXT" Or GENSTYLE = "PASSWORD" Or GENSTYLE = "GUID" Then

                        If f.TheMask = "" Then
                            decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As LATIR2GuiManager.TouchTextBox"
                            create = create & vbCrLf & "Me.txt" & f.Name & " = New LATIR2GuiManager.TouchTextBox"
                        Else
                            decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As System.Windows.Forms.MaskedTextBox"
                            create = create & vbCrLf & "Me.txt" & f.Name & " = New System.Windows.Forms.MaskedTextBox"
                        End If

                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txt" & f.Name & ")"

                            s = s & vbCrLf & "Me.txt" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                            s = s & vbCrLf & "Me.txt" & f.Name & ".name = ""txt" & f.Name & """"

                            's = s & vbCrLf & "Me.txt" & f.name & ".ReadOnly = True"
                            If f.TheMask <> "" Then
                                s = s & vbCrLf & "Me.txt" & f.Name & ".Mask = """ & f.TheMask & """"
                            Else
                                s = s & vbCrLf & "Me.txt" & f.Name & ".MaxLength = " & f.DataSize.ToString()
                            End If


                            s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(200, 20)"
                            s = s & vbCrLf & "Me.txt" & f.Name & ".TabIndex = " & tabidx
                            s = s & vbCrLf & "Me.txt" & f.Name & ".Text = """" "
                            tabidx = tabidx + 1

                            If GENSTYLE = "PASSWORD" Then
                                s = s & vbCrLf & "Me.txt" & f.Name & ".PasswordChar = Microsoft.VisualBasic.ChrW(42)"
                            End If
                            pos = pos + 25

                            If IsFieldReadOnly Then
                                s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"
                            End If
                            If GENSTYLE = "GUID" Then
                                loadFields = loadFields & vbCrLf & "txt" & f.Name & ".text = item." & f.Name & ".ToString()"
                                If Not IsFieldReadOnly Then
                                    saveFields = saveFields & vbCrLf & "item." & f.Name & " = new System.Guid(txt" & f.Name & ".text)"
                                End If
                            Else
                                loadFields = loadFields & vbCrLf & "txt" & f.Name & ".text = item." & f.Name
                                If Not IsFieldReadOnly Then
                                    saveFields = saveFields & vbCrLf & "item." & f.Name & " = txt" & f.Name & ".text"
                                End If
                            End If

                            If Not f.AllowNull Then
                                IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =( txt" & f.Name & ".text <> """" ) "
                            End If

                            sp = sp & vbCrLf & "private sub txt" & f.Name & "_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt" & f.Name & ".TextChanged"
                            sp = sp & vbCrLf & "  Changing"
                            sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)

                            sp = sp & vbCrLf & "end sub"


                        End If ' TEXT PASSWORD GUID

                        ' todo
                        If GENSTYLE = "EMAIL" Then
                        decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As LATIR2GuiManager.TouchTextBox"
                        create = create & vbCrLf & "Me.txt" & f.Name & " = New LATIR2GuiManager.TouchTextBox"
                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txt" & f.Name & ")"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".name = ""txt" & f.Name & """"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(200, 20)"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".TabIndex = " & tabidx
                        s = s & vbCrLf & "Me.txt" & f.Name & ".Text = """" "
                        tabidx = tabidx + 1

                        If GENSTYLE = "PASSWORD" Then
                            s = s & vbCrLf & "Me.txt" & f.Name & ".PasswordChar = Microsoft.VisualBasic.ChrW(42)"
                        End If
                        pos = pos + 25

                        If Not IsFieldReadOnly Then
                            saveFields = saveFields & vbCrLf & "item." & f.Name & " = txt" & f.Name & ".text"
                        Else
                            s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"
                        End If
                        loadFields = loadFields & vbCrLf & "txt" & f.Name & ".text = item." & f.Name

                        If Not f.AllowNull Then
                            IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =( txt" & f.Name & ".text <> """" ) "
                        End If

                        sp = sp & vbCrLf & "private sub txt" & f.Name & "_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt" & f.Name & ".TextChanged"
                        sp = sp & vbCrLf & "  Changing"
                        sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)

                        sp = sp & vbCrLf & "end sub"

                    End If 'EMAIL


                    ' todo
                    If GENSTYLE = "URL" Then
                        decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As LATIR2GuiManager.TouchTextBox"
                        create = create & vbCrLf & "Me.txt" & f.Name & " = New LATIR2GuiManager.TouchTextBox"
                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txt" & f.Name & ")"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".name = ""txt" & f.Name & """"



                        s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(200, 20)"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".TabIndex = " & tabidx
                        s = s & vbCrLf & "Me.txt" & f.Name & ".Text = """" "
                        tabidx = tabidx + 1

                        If GENSTYLE = "PASSWORD" Then
                            s = s & vbCrLf & "Me.txt" & f.Name & ".PasswordChar = Microsoft.VisualBasic.ChrW(42)"
                        Else
                            s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"
                        End If
                        pos = pos + 25

                        If Not IsFieldReadOnly Then
                            saveFields = saveFields & vbCrLf & "item." & f.Name & " = txt" & f.Name & ".text"
                        End If
                        loadFields = loadFields & vbCrLf & "txt" & f.Name & ".text = item." & f.Name

                        If Not f.AllowNull Then
                            IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =( txt" & f.Name & ".text <> """" ) "
                        End If

                        sp = sp & vbCrLf & "private sub txt" & f.Name & "_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt" & f.Name & ".TextChanged"
                        sp = sp & vbCrLf & "  Changing"
                        sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)

                        sp = sp & vbCrLf & "end sub"
                    End If 'URL

                    If GENSTYLE = "HTML" Then
                        decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As LATIR2GuiManager.TouchTextBox"
                        create = create & vbCrLf & "Me.txt" & f.Name & " = New LATIR2GuiManager.TouchTextBox"
                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txt" & f.Name & ")"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".name = ""txt" & f.Name & """"

                        's = s & vbCrLf & "Me.txt" & f.name & ".ReadOnly = True"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(200, 20)"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".TabIndex = " & tabidx
                        s = s & vbCrLf & "Me.txt" & f.Name & ".Text = """" "
                        tabidx = tabidx + 1


                        pos = pos + 25

                        If Not IsFieldReadOnly Then
                            saveFields = saveFields & vbCrLf & "item." & f.Name & " = txt" & f.Name & ".text"
                        Else
                            s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"
                        End If
                        loadFields = loadFields & vbCrLf & "txt" & f.Name & ".text = item." & f.Name

                        If Not f.AllowNull Then
                            IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =( txt" & f.Name & ".text <> """" ) "
                        End If

                        sp = sp & vbCrLf & "private sub txt" & f.Name & "_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt" & f.Name & ".TextChanged"
                        sp = sp & vbCrLf & "  Changing"
                        sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)

                        sp = sp & vbCrLf & "end sub"

                    End If 'HTML

                    If GENSTYLE = "MEMO" Then
                        decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As LATIR2GuiManager.TouchTextBox"
                        create = create & vbCrLf & "Me.txt" & f.Name & " = New LATIR2GuiManager.TouchTextBox"
                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txt" & f.Name & ")"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".name = ""txt" & f.Name & """"


                        s = s & vbCrLf & "Me.txt" & f.Name & ".MultiLine = True"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".ScrollBars = System.Windows.Forms.ScrollBars.Vertical"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(200, 50 + 20)"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".TabIndex = " & tabidx
                        s = s & vbCrLf & "Me.txt" & f.Name & ".Text = """" "
                        tabidx = tabidx + 1


                        pos = pos + 70 '25

                        If Not IsFieldReadOnly Then
                            saveFields = saveFields & vbCrLf & "item." & f.Name & " = txt" & f.Name & ".text"
                        Else
                            s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"
                        End If

                        loadFields = loadFields & vbCrLf & "txt" & f.Name & ".text = item." & f.Name

                        If Not f.AllowNull Then
                            IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =( txt" & f.Name & ".text <> """" ) "
                        End If

                        sp = sp & vbCrLf & "private sub txt" & f.Name & "_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt" & f.Name & ".TextChanged"
                        sp = sp & vbCrLf & "  Changing"
                        sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)
                        sp = sp & vbCrLf & "end sub"

                    End If ' MEMO


                    If GENSTYLE = "RTF" Then
                        decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As LATIR2GuiManager.TouchTextBox"
                        create = create & vbCrLf & "Me.txt" & f.Name & " = New LATIR2GuiManager.TouchTextBox"
                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txt" & f.Name & ")"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".name = ""txt" & f.Name & """"


                        s = s & vbCrLf & "Me.txt" & f.Name & ".MultiLine = True"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".ScrollBars = System.Windows.Forms.ScrollBars.Vertical"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(200, 50 + 20)"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".TabIndex = " & tabidx
                        s = s & vbCrLf & "Me.txt" & f.Name & ".Text = """" "
                        tabidx = tabidx + 1


                        pos = pos + 25

                        If Not IsFieldReadOnly Then
                            saveFields = saveFields & vbCrLf & "item." & f.Name & " = txt" & f.Name & ".text"
                        Else
                            s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"
                        End If

                        loadFields = loadFields & vbCrLf & "txt" & f.Name & ".text = item." & f.Name

                        If Not f.AllowNull Then
                            IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =( txt" & f.Name & ".text <> """" ) "
                        End If

                        sp = sp & vbCrLf & "private sub txt" & f.Name & "_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt" & f.Name & ".TextChanged"
                        sp = sp & vbCrLf & "  Changing"
                        sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)

                        sp = sp & vbCrLf & "end sub"

                    End If ' RTF



                    ''''''''''' File

                    If GENSTYLE = "FILE" Then
                        decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As LATIR2GuiManager.TouchTextBox"
                        create = create & vbCrLf & "Me.txt" & f.Name & " = New LATIR2GuiManager.TouchTextBox"
                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txt" & f.Name & ")"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".name = ""txt" & f.Name & """"


                        s = s & vbCrLf & "Me.txt" & f.Name & ".MultiLine = True"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".ScrollBars = System.Windows.Forms.ScrollBars.Vertical"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(200, 50 + 20)"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".TabIndex = " & tabidx
                        s = s & vbCrLf & "Me.txt" & f.Name & ".Text = """" "
                        tabidx = tabidx + 1


                        pos = pos + 25

                        If Not IsFieldReadOnly Then
                            saveFields = saveFields & vbCrLf & "item." & f.Name & " = txt" & f.Name & ".text"
                        Else
                            s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"
                        End If

                        loadFields = loadFields & vbCrLf & "txt" & f.Name & ".text = item." & f.Name

                        If Not f.AllowNull Then
                            IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =( txt" & f.Name & ".text <> """" ) "
                        End If

                        sp = sp & vbCrLf & "private sub txt" & f.Name & "_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt" & f.Name & ".TextChanged"
                        sp = sp & vbCrLf & "  Changing"
                        sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)

                        sp = sp & vbCrLf & "end sub"


                    End If ' FILE

                    '''''''''''

                    If GENSTYLE = "IMAGE" Then
                        decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As LATIR2GuiManager.TouchTextBox"
                        create = create & vbCrLf & "Me.txt" & f.Name & " = New LATIR2GuiManager.TouchTextBox"
                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txt" & f.Name & ")"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".name = ""txt" & f.Name & """"


                        s = s & vbCrLf & "Me.txt" & f.Name & ".MultiLine = True"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".ScrollBars = System.Windows.Forms.ScrollBars.Vertical"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(200, 50 + 20)"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".TabIndex = " & tabidx
                        s = s & vbCrLf & "Me.txt" & f.Name & ".Text = """" "
                        tabidx = tabidx + 1


                        pos = pos + 25

                        If Not IsFieldReadOnly Then
                            saveFields = saveFields & vbCrLf & "item." & f.Name & " = txt" & f.Name & ".text"
                        Else
                            s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"
                        End If

                        loadFields = loadFields & vbCrLf & "txt" & f.Name & ".text = item." & f.Name

                        If Not f.AllowNull Then
                            IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =( txt" & f.Name & ".text <> """" ) "
                        End If

                        sp = sp & vbCrLf & "private sub txt" & f.Name & "_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt" & f.Name & ".TextChanged"
                        sp = sp & vbCrLf & "  Changing"
                        sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)

                        sp = sp & vbCrLf & "end sub"

                    End If 'IMAGE


                    ' numeric type
                    'Double
                    'Integer
                    'Long

                    If GENSTYLE = "NUMERIC" Or GENSTYLE = "INTEGER" Or GENSTYLE = "INTERVAL" Then

                        decl = decl & vbCrLf & "Friend WithEvents txt" & f.Name & " As LATIR2GuiManager.TouchTextBox"
                        create = create & vbCrLf & "Me.txt" & f.Name & " = New LATIR2GuiManager.TouchTextBox"
                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txt" & f.Name & ")"

                        s = s & vbCrLf & "Me.txt" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".name = ""txt" & f.Name & """"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".MultiLine = false"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".Size = New System.Drawing.Size(200,  20)"
                        s = s & vbCrLf & "Me.txt" & f.Name & ".TabIndex = " & tabidx
                        s = s & vbCrLf & "Me.txt" & f.Name & ".Text = """" "
                        tabidx = tabidx + 1



                        loadFields = loadFields & vbCrLf & "txt" & f.Name & ".text = item." & f.Name & ".toString()"

                        If Not f.AllowNull Then
                            IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =( txt" & f.Name & ".text <> """" ) "
                        End If

                        If GENSTYLE = "NUMERIC" Then
                            s = s & vbCrLf & "Me.txt" & f.Name & ".MaxLength = 27"
                            If Not IsFieldReadOnly Then
                                saveFields = saveFields & vbCrLf & "item." & f.Name & " = cdbl(txt" & f.Name & ".text)"
                            Else
                                s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"
                            End If
                        Else
                            s = s & vbCrLf & "Me.txt" & f.Name & ".MaxLength = 15"

                            If Not IsFieldReadOnly Then
                                saveFields = saveFields & vbCrLf & "item." & f.Name & " = val(txt" & f.Name & ".text)"
                            Else
                                s = s & vbCrLf & "Me.txt" & f.Name & ".ReadOnly = True"
                            End If
                        End If
                        If Not IsFieldReadOnly Then
                            If GENSTYLE = "NUMERIC" Then
                                sp = sp & vbCrLf & "        Private Sub txt" & f.Name & "_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt" & f.Name & ".Validating"
                                sp = sp & vbCrLf & "        If txt" & f.Name & ".Text <> """" Then"
                                sp = sp & vbCrLf & "            try"
                                sp = sp & vbCrLf & "            If Not IsNumeric(txt" & f.Name & ".Text) Then"
                                sp = sp & vbCrLf & "                e.Cancel = True"
                                sp = sp & vbCrLf & "                MsgBox(""Ожидалось число"", vbOKOnly + vbExclamation, ""Внимание"")"
                                sp = sp & vbCrLf & "            ElseIf Val(txt" & f.Name & ".Text) < -922337203685478# Or Val(txt" & f.Name & ".Text) > 922337203685478# Then"
                                sp = sp & vbCrLf & "                e.Cancel = True"
                                sp = sp & vbCrLf & "                MsgBox(""Значение вне допустимого диапазона"", vbOKOnly + vbExclamation, ""Внимание"")"
                                sp = sp & vbCrLf & "            End If"
                                sp = sp & vbCrLf & "        catch ex as System.Exception"
                                sp = sp & vbCrLf & "        Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                                sp = sp & vbCrLf & "        end try"
                                sp = sp & vbCrLf & "        End If"
                                sp = sp & vbCrLf & "    End Sub"
                            ElseIf GENSTYLE = "INTEGER" Then
                                sp = sp & vbCrLf & "        Private Sub txt" & f.Name & "_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt" & f.Name & ".Validating"
                                sp = sp & vbCrLf & "        If txt" & f.Name & ".Text <> """" Then"
                                sp = sp & vbCrLf & "            try"
                                sp = sp & vbCrLf & "            If Not IsNumeric(txt" & f.Name & ".Text) Then"
                                sp = sp & vbCrLf & "                e.Cancel = True"
                                sp = sp & vbCrLf & "                MsgBox(""Ожидалось число"", vbOKOnly + vbExclamation, ""Внимание"")"
                                sp = sp & vbCrLf & "            ElseIf Val(txt" & f.Name & ".Text) < -2000000000 Or Val(txt" & f.Name & ".Text) > 2000000000 Then"
                                sp = sp & vbCrLf & "                e.Cancel = True"
                                sp = sp & vbCrLf & "                MsgBox(""Значение вне допустимого диапазона"", vbOKOnly + vbExclamation, ""Внимание"")"
                                sp = sp & vbCrLf & "            End If"
                                sp = sp & vbCrLf & "        catch ex as System.Exception"
                                sp = sp & vbCrLf & "            Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                                sp = sp & vbCrLf & "        end try"
                                sp = sp & vbCrLf & "        End If"
                                sp = sp & vbCrLf & "    End Sub"
                            ElseIf GENSTYLE = "INTERVAL" Then
                                sp = sp & vbCrLf & "        Private Sub txt" & f.Name & "_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt" & f.Name & ".Validating"
                                sp = sp & vbCrLf & "        If txt" & f.Name & ".Text <> """" Then"
                                sp = sp & vbCrLf & "            try"
                                sp = sp & vbCrLf & "            If Not IsNumeric(txt" & f.Name & ".Text) Then"
                                sp = sp & vbCrLf & "                e.Cancel = True"
                                sp = sp & vbCrLf & "                MsgBox(""Ожидалось число"", vbOKOnly + vbExclamation, ""Внимание"")"
                                sp = sp & vbCrLf & "            elseif Val(txt" & f.Name & ".text) < 0" & ft.Minimum & " or  Val(txt" & f.Name & ".text)> 0" & ft.Maximum & " then "
                                sp = sp & vbCrLf & "                e.Cancel = True"
                                sp = sp & vbCrLf & "                MsgBox(""Значение вне допустимого диапазона"", vbOKOnly + vbExclamation, ""Внимание"")"
                                sp = sp & vbCrLf & "            End If"
                                sp = sp & vbCrLf & "        catch ex as System.Exception"
                                sp = sp & vbCrLf & "             Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                                sp = sp & vbCrLf & "        end try"
                                sp = sp & vbCrLf & "        End If"
                                sp = sp & vbCrLf & "    End Sub"
                            End If
                        End If


                        sp = sp & vbCrLf & "private sub txt" & f.Name & "_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt" & f.Name & ".TextChanged"
                        sp = sp & vbCrLf & "  Changing"
                        sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)

                        sp = sp & vbCrLf & "end sub"
                        pos = pos + 25
                    End If

                    ' date type
                    If GENSTYLE = "DATE" Or GENSTYLE = "DATETIME" Or GENSTYLE = "TIME" Then
                        decl = decl & vbCrLf & "Friend WithEvents dtp" & f.Name & " As System.Windows.Forms.DateTimePicker"
                        create = create & vbCrLf & "Me.dtp" & f.Name & " = New System.Windows.Forms.DateTimePicker"



                        addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtp" & f.Name & ")"

                        s = s & vbCrLf & "Me.dtp" & f.Name & ".Format = System.Windows.Forms.DateTimePickerFormat.Custom"
                        s = s & vbCrLf & "Me.dtp" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                        s = s & vbCrLf & "Me.dtp" & f.Name & ".name = ""dtp" & f.Name & """"

                        s = s & vbCrLf & "Me.dtp" & f.Name & ".Size = New System.Drawing.Size(200,  20)"
                        s = s & vbCrLf & "Me.dtp" & f.Name & ".TabIndex =" & tabidx
                        tabidx = tabidx + 1


                        's = s & vbCrLf & "Me.dtp" & f.Name & ".FormatString = """

                        If GENSTYLE = "DATETIME" Then
                            s = s & vbCrLf & "Me.dtp" & f.Name & ".CustomFormat = ""dd/MM/yyyy HH:mm:ss"""
                            loadFields = loadFields & vbCrLf & "dtp" & f.Name & ".value = System.DateTime.Now"
                        End If
                        If GENSTYLE = "DATE" Then
                            s = s & vbCrLf & "Me.dtp" & f.Name & ".CustomFormat = ""dd/MM/yyyy"""
                            loadFields = loadFields & vbCrLf & "dtp" & f.Name & ".value = System.DateTime.Today"
                        End If
                        If GENSTYLE = "TIME" Then
                            s = s & vbCrLf & "Me.dtp" & f.Name & ".CustomFormat = ""HH:mm:ss"""
                            loadFields = loadFields & vbCrLf & "dtp" & f.Name & ".value = System.DateTime.Now"
                        End If

                        If f.AllowNull Then
                            s = s & vbCrLf & "Me.dtp" & f.Name & ".ShowCheckBox=True"

                        Else
                            s = s & vbCrLf & "Me.dtp" & f.Name & ".ShowCheckBox=False"
                        End If

                        sp = sp & vbCrLf & "private sub dtp" & f.Name & "_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp" & f.Name & ".ValueChanged"
                        sp = sp & vbCrLf & "  Changing "
                        sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)
                        sp = sp & vbCrLf & "end sub"


                        If Not IsFieldReadOnly Then
                            If f.AllowNull Then
                                saveFields = saveFields & vbCrLf & "  if dtp" & f.Name & ".checked=false then"
                                saveFields = saveFields & vbCrLf & "       item." & f.Name & " = System.DateTime.MinValue"
                                saveFields = saveFields & vbCrLf & "  else "
                            End If
                            saveFields = saveFields & vbCrLf & "  try"
                            saveFields = saveFields & vbCrLf & "    item." & f.Name & " = dtp" & f.Name & ".value"
                            saveFields = saveFields & vbCrLf & "  catch"
                            saveFields = saveFields & vbCrLf & "    item." & f.Name & " = System.DateTime.MinValue"
                            saveFields = saveFields & vbCrLf & "  end try"


                            If f.AllowNull Then
                                saveFields = saveFields & vbCrLf & "  end if"
                            End If
                        End If

                        loadFields = loadFields & vbCrLf & "if item." & f.Name & " <> System.DateTime.MinValue then"
                        loadFields = loadFields & vbCrLf & "  try"
                        loadFields = loadFields & vbCrLf & "     dtp" & f.Name & ".value = item." & f.Name
                        loadFields = loadFields & vbCrLf & "  catch"
                        loadFields = loadFields & vbCrLf & "   dtp" & f.Name & ".value = System.DateTime.MinValue"
                        loadFields = loadFields & vbCrLf & "  end try"
                        If f.AllowNull Then
                            loadFields = loadFields & vbCrLf & "else"
                            loadFields = loadFields & vbCrLf & "   dtp" & f.Name & ".value = System.DateTime.Today"
                            loadFields = loadFields & vbCrLf & "   dtp" & f.Name & ".Checked =false"
                        End If

                        loadFields = loadFields & vbCrLf & "end if"
                        pos = pos + 25

                        If Not f.AllowNull Then
                            IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK = (dtp" & f.Name & ".value <> System.DateTime.MinValue)"
                        End If


                    End If ' DATE TIME DATETIME
                    Debug.Print(GENSTYLE)
                    ' Enum !!!
                    If GENSTYLE = "COMBOBOX" Or GENSTYLE = "CHECKBOX" Then
                        ' Friend WithEvents cmbFolderType As System.Windows.Forms.ComboBox
                        Dim ft2 As MTZMetaModel.MTZMetaModel.FIELDTYPE
                        ft2 = f.FieldType


                        If ft2.ENUMITEM.Count > 2 Then

                            decl = decl & vbCrLf & "Friend WithEvents cmb" & f.Name & " As System.Windows.Forms.ComboBox"
                            decl = decl & vbCrLf & "Friend cmb" & f.Name & "DATA As DataTable"
                            decl = decl & vbCrLf & "Friend cmb" & f.Name & "DATAROW As DataRow"
                            create = create & vbCrLf & "Me.cmb" & f.Name & " = New System.Windows.Forms.ComboBox"
                            addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmb" & f.Name & ")"

                            s = s & vbCrLf & "Me.cmb" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                            s = s & vbCrLf & "Me.cmb" & f.Name & ".name = ""cmb" & f.Name & """"
                            s = s & vbCrLf & "Me.cmb" & f.Name & ".Size = New System.Drawing.Size(200,  20)"
                            s = s & vbCrLf & "Me.cmb" & f.Name & ".TabIndex = " & tabidx
                            ' s = s & vbCrLf & "Me.cmb" & f.Name & ".Nullable = false"
                            s = s & vbCrLf & "Me.cmb" & f.Name & ".DropDownStyle = ComboBoxStyle.DropDownList"

                            tabidx = tabidx + 1


                            sp = sp & vbCrLf & "private sub cmb" & f.Name & "_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb" & f.Name & ".SelectedIndexChanged"
                            sp = sp & vbCrLf & "  try"
                            sp = sp & vbCrLf & "     Changing"
                            sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)
                            sp = sp & vbCrLf & "        catch ex as System.Exception"
                            sp = sp & vbCrLf & "             Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                            sp = sp & vbCrLf & "        end try"
                            sp = sp & vbCrLf & "end sub"

                            If Not IsFieldReadOnly Then
                                saveFields = saveFields & vbCrLf & "   item." & f.Name & " = cmb" & f.Name & ".SelectedValue"
                            Else
                                s = s & vbCrLf & "Me.cmb" & f.Name & ".Enabled = true"
                            End If



                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & "Data = New DataTable"
                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & "Data.Columns.Add(""name"", GetType(System.String))"
                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & "Data.Columns.Add(""Value"", GetType(System.Int32))"
                            loadFields = loadFields & vbCrLf & "try"


                            ft2.ENUMITEM.Sort = "NameValue"
                            For ii = 1 To ft2.ENUMITEM.Count
                                loadFields = loadFields & vbCrLf & "cmb" & f.Name & "DataRow = cmb" & f.Name & "Data.NewRow"
                                loadFields = loadFields & vbCrLf & "cmb" & f.Name & "DataRow(""name"") = """ & ft2.ENUMITEM.Item(ii).Name & """"
                                loadFields = loadFields & vbCrLf & "cmb" & f.Name & "DataRow(""Value"") = " & ft2.ENUMITEM.Item(ii).NameValue
                                loadFields = loadFields & vbCrLf & "cmb" & f.Name & "Data.Rows.Add (cmb" & f.Name & "DataRow)"
                            Next

                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & ".DisplayMember = ""name"""
                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & ".ValueMember = ""Value"""


                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & ".DataSource = cmb" & f.Name & "Data"
                            loadFields = loadFields & vbCrLf & " cmb" & f.Name & ".SelectedValue=CInt(Item." & f.Name & ")"


                            If Not f.AllowNull Then
                                IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =(cmb" & f.Name & ".SelectedIndex >=0)"
                            End If
                            loadFields = loadFields & vbCrLf & "        catch ex as System.Exception"
                            loadFields = loadFields & vbCrLf & "             Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                            loadFields = loadFields & vbCrLf & "        end try"
                        Else
                            decl = decl & vbCrLf & "Friend WithEvents cmb" & f.Name & " As System.Windows.Forms.ComboBox"
                            decl = decl & vbCrLf & "Friend cmb" & f.Name & "DATA As DataTable"
                            decl = decl & vbCrLf & "Friend cmb" & f.Name & "DATAROW As DataRow"
                            create = create & vbCrLf & "Me.cmb" & f.Name & " = New System.Windows.Forms.ComboBox"
                            addctl = addctl & vbCrLf & "CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmb" & f.Name & ")"



                            s = s & vbCrLf & "Me.cmb" & f.Name & ".Location = New System.Drawing.Point(" & (210 * column + 20) & "," & pos & ")"
                            s = s & vbCrLf & "Me.cmb" & f.Name & ".name = ""cmb" & f.Name & """"
                            s = s & vbCrLf & "Me.cmb" & f.Name & ".Size = New System.Drawing.Size(200,  20)"
                            s = s & vbCrLf & "Me.cmb" & f.Name & ".TabIndex = " & tabidx



                            tabidx = tabidx + 1


                            sp = sp & vbCrLf & "private sub cmb" & f.Name & "_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb" & f.Name & ".SelectedIndexChanged"
                            sp = sp & vbCrLf & "  try"
                            sp = sp & vbCrLf & "  Changing"
                            sp = sp & vbCrLf & LATIR2Framework.StringHelper.GetScript2((f.FIELDVALIDATOR), tid)
                            sp = sp & vbCrLf & "        catch ex as System.Exception"
                            sp = sp & vbCrLf & "             Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                            sp = sp & vbCrLf & "        end try"
                            sp = sp & vbCrLf & "end sub"

                            If Not IsFieldReadOnly Then
                                saveFields = saveFields & vbCrLf & "   item." & f.Name & " = cmb" & f.Name & ".SelectedValue"
                            Else
                                s = s & vbCrLf & "Me.cmb" & f.Name & ".Enabled = true"
                            End If



                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & "Data = New DataTable"
                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & "Data.Columns.Add(""name"", GetType(System.String))"
                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & "Data.Columns.Add(""Value"", GetType(System.Int32))"
                            loadFields = loadFields & vbCrLf & "try"


                            ft2.ENUMITEM.Sort = "NameValue"
                            For ii = 1 To ft2.ENUMITEM.Count
                                loadFields = loadFields & vbCrLf & "cmb" & f.Name & "DataRow = cmb" & f.Name & "Data.NewRow"
                                loadFields = loadFields & vbCrLf & "cmb" & f.Name & "DataRow(""name"") = """ & ft2.ENUMITEM.Item(ii).Name & """"
                                loadFields = loadFields & vbCrLf & "cmb" & f.Name & "DataRow(""Value"") = " & ft2.ENUMITEM.Item(ii).NameValue
                                loadFields = loadFields & vbCrLf & "cmb" & f.Name & "Data.Rows.Add (cmb" & f.Name & "DataRow)"
                            Next

                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & ".DisplayMember = ""name"""
                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & ".ValueMember = ""Value"""


                            loadFields = loadFields & vbCrLf & "cmb" & f.Name & ".DataSource = cmb" & f.Name & "Data"
                            loadFields = loadFields & vbCrLf & " cmb" & f.Name & ".SelectedValue=CInt(Item." & f.Name & ")"


                            If Not f.AllowNull Then
                                IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =(cmb" & f.Name & ".SelectedIndex >=0)"
                            End If
                            loadFields = loadFields & vbCrLf & "        catch ex as System.Exception"
                            loadFields = loadFields & vbCrLf & "             Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                            loadFields = loadFields & vbCrLf & "        end try"

                        End If


                        pos = pos + 25
                    Else

                    End If
                End If
            Next


            s = s & vbCrLf & "        Me.AutoScroll = True"
            s = s & vbCrLf & addctl
            s = s & vbCrLf & "        Me.Controls.Add(Me.HolderPanel)"
            s = s & vbCrLf & "        Me.HolderPanel.ResumeLayout(False)"
            s = s & vbCrLf & "        Me.HolderPanel.PerformLayout()"
            s = s & vbCrLf & "        Me.name = ""edit" & p.Name & """"
            s = s & vbCrLf & "        Me.Size = New System.Drawing.Size(232, 120)"
            s = s & vbCrLf & "        Me.ResumeLayout (False)"
            s = s & vbCrLf & "    End Sub"

            s = Replace(s, "%%DECL%%", decl)
            s = Replace(s, "%%CREATE%%", create)


            s = s & vbCrLf & "#End Region"
            s = s & vbCrLf & sp & vbCrLf
            s = s & vbCrLf & "Public Item As " & ot.Name & "." & ot.Name & "." & p.Name
            's = s & vbCrLf & "Public Item As " & ot.Name & "." & p.Name
            s = s & vbCrLf & "Private mRowReadOnly As Boolean"
            s = s & vbCrLf & "Public GuiManager As LATIR2GuiManager.LATIRGuiManager"

            s = s & vbCrLf & MakeComment("Инициализация")
            s = s & vbCrLf & "Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach"
            's = s & vbCrLf & "        Item = Ctype(ri," & ot.Name & "." & p.Name & ")"
            s = s & vbCrLf & "        Item = Ctype(ri," & ot.Name & "." & ot.Name & "." & p.Name & ")"
            s = s & vbCrLf & "        GuiManager = gm"
            s = s & vbCrLf & "        mRowReadOnly = RowReadOnly"
            s = s & vbCrLf & "        If Item Is Nothing Then Exit Sub"
            s = s & vbCrLf & "        mOnInit = true"
            s = s & vbCrLf & loadFields
            s = s & vbCrLf & "        mOnInit = false"
            s = s & vbCrLf & "  raiseevent Refreshed()"
            s = s & vbCrLf & "end sub"


            s = s & vbCrLf & MakeComment("Сохранения данных в полях объекта")
            s = s & vbCrLf & "Public Sub Save() Implements LATIR2GUIManager.IRowEditor.Save"
            s = s & vbCrLf & "  if mRowReadOnly =false then"
            s = s & vbCrLf & saveFields
            s = s & vbCrLf & "  end if"
            s = s & vbCrLf & "  mChanged = false"
            s = s & vbCrLf & "  raiseevent saved()"
            s = s & vbCrLf & "end sub"

            s = s & vbCrLf & "Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK"
            s = s & vbCrLf & " Dim mIsOK as boolean"
            s = s & vbCrLf & " mIsOK=true"
            s = s & vbCrLf & " if mRowReadOnly  then return true"
            s = s & vbCrLf & IsOK
            s = s & vbCrLf & " return mIsOK"
            s = s & vbCrLf & "end function"

            s = s & vbCrLf & "Public function IsChanged() as boolean Implements LATIR2GUIManager.IRowEditor.IsChanged"
            s = s & vbCrLf & " return mChanged"
            s = s & vbCrLf & "end function"

            s = s & vbCrLf & "Public Sub SetupPanel()"
            s = s & vbCrLf & "    HolderPanel.SetupPanel()"
            s = s & vbCrLf & "End Sub"


            s = s & vbCrLf & "Public Overridable Function GetMaxX() As Double"

            s = s & vbCrLf & "    Return HolderPanel.GetMaxX()"
            s = s & vbCrLf & "End Function"

            s = s & vbCrLf & "Public Overridable Function GetMaxY() As Double"
            s = s & vbCrLf & "    Return HolderPanel.GetMaxY()"
            s = s & vbCrLf & "End Function"

            s = s & vbCrLf & "end class"

            LATIR2Framework.StringHelper.SetExt(o, "edit" & p.Name & mode, "vb")
            o.Block = "code"
            o.OutNL(s)

            p.PART.Sort = "sequence"
            For i = 1 To p.PART.Count
                MakeRow(tid, m, ot, p.PART.Item(i), o, mode)
            Next

        Catch ex As Exception
            Debug.Print(ex.Message + " >> " + ex.StackTrace)
        End Try
    End Sub
End Module
