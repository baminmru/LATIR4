Option Strict Off
Option Explicit On
Imports LATIR2Framework.StringHelper
Imports MTZMetaModel.MTZMetaModel
Module MakeCollections

    'здесь делаем View контролы


    Public Sub MakeColls(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef o As LATIRGenerator.Response, ByVal mode As String)
        Dim s As String = String.Empty
        Dim i As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim n1 As String
        Dim ifs As LATIR2Framework.ObjectHelper.InterfaceType
        Dim child As MTZMetaModel.MTZMetaModel.PART

        Dim tt As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        tt = LATIR2Framework.ObjectTypeHelper.TypeForStruct(p)

        ifs = LATIR2Framework.ObjectHelper.AnalyzeInterfaceForGUI(p, mode)

        s = s & vbCrLf & "Imports System.Windows.Forms"
        s = s & vbCrLf & "Imports Microsoft.VisualBasic"
        s = s & vbCrLf & "Imports System.Diagnostics"
        s = s & vbCrLf


        Select Case ifs

            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeExtention
                Try

                    s = s & vbCrLf & MakeComment("Контрол для просмотра раздела " & p.Caption)
                    s = s & vbCrLf & "  Public Class view" & p.Name & mode
                    s = s & vbCrLf & "    Inherits System.Windows.Forms.UserControl"
                    s = s & vbCrLf & "    Implements LATIR2GUIManager.IViewPanel"
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
                    s = s & vbCrLf & "    'NOTE: The following procedure is required by the Windows Form Designer"
                    s = s & vbCrLf & "    'It can be modified using the Windows Form Designer."
                    s = s & vbCrLf & "    'Do not modify it using the code editor."

                    Dim ei As ExtenderInterface = Nothing
                    Dim tp As GENERATOR_TARGET
                    Dim idx As Integer
                    For idx = 1 To p.ExtenderInterface.Count
                        tp = p.ExtenderInterface.Item(idx).TargetPlatform
                        If tp.ID.ToString = tid Then
                            ei = p.ExtenderInterface.Item(idx)
                            Exit For
                        End If
                    Next
                    If Not ei Is Nothing Then
                        s = s & vbCrLf & MakeComment("Основной контрол для просмотра раздела " & p.Caption)
                        s = s & vbCrLf & "    Friend WithEvents Edit" & p.Name & "1 As " & ei.TheName
                        s = s & vbCrLf & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
                        s = s & vbCrLf & "        Me.Edit" & p.Name & "1 = New " & ot.Name & "GUI.edit" & p.Name
                        's = s & vbCrLf & "        Me.Edit" & p.Name & "1 = New " & ei.TheName
                        s = s & vbCrLf & "        Me.SuspendLayout()"
                        s = s & vbCrLf & "        '"
                        s = s & vbCrLf & "        'Edit" & p.Name & "1"
                        s = s & vbCrLf & "        '"
                        s = s & vbCrLf & "        Me.Edit" & p.Name & "1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _"
                        s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Left) _"
                        s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)"
                        s = s & vbCrLf & "        Me.Edit" & p.Name & "1.Location = New System.Drawing.Point(0, 0)"
                        s = s & vbCrLf & "        Me.Edit" & p.Name & "1.name = ""Edit" & p.Name & "1"""
                        s = s & vbCrLf & "        Me.Edit" & p.Name & "1.Size = New System.Drawing.Size(248, 128)"
                        s = s & vbCrLf & "        Me.Edit" & p.Name & "1.TabIndex = 0"
                        s = s & vbCrLf & "        Me.Edit" & p.Name & "1.Dock = System.Windows.Forms.DockStyle.Fill"
                        s = s & vbCrLf & "        Me.Controls.Add (Me.Edit" & p.Name & "1)"
                        s = s & vbCrLf & "        Me.name = ""view" & p.Name & """"
                        s = s & vbCrLf & "        Me.Size = New System.Drawing.Size(248, 168)"
                        s = s & vbCrLf & "        Me.ResumeLayout (False)"
                        s = s & vbCrLf & ""
                        s = s & vbCrLf & "    End Sub"
                        s = s & vbCrLf & ""
                        s = s & vbCrLf & "#End Region"
                        s = s & vbCrLf & "    Public item As " & ot.Name & "." & ot.Name & ".Application"
                        's = s & vbCrLf & "    Public item As " & ot.Name & ".Application"
                        s = s & vbCrLf & "    Public GuiManager As LATIR2GuiManager.LATIRGuiManager"
                        s = s & vbCrLf & "    Private mReadOnly as boolean"
                        s = s & vbCrLf & MakeComment("Инициализация")
                        s = s & vbCrLf & "    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager,byval ReadOnlyView as boolean) Implements LATIR2GUIManager.IViewPanel.Attach"
                        s = s & vbCrLf & "        mReadOnly = ReadOnlyView"
                        s = s & vbCrLf & "        item = CType(docItem, " & ot.Name & "." & ot.Name & ".Application)"
                        's = s & vbCrLf & "        item = CType(docItem, " & ot.Name & ".Application)"
                        s = s & vbCrLf & "        GuiManager = gm"

                        Dim prest As MTZMetaModel.MTZMetaModel.STRUCTRESTRICTION
                        prest = LATIR2Framework.ObjectHelper.GetPartRestriction(p, mode)

                        If prest Is Nothing Then
                            s = s & vbCrLf & "        Edit" & p.Name & "1.Attach(gm, docItem,true,true,true)"
                        Else
                            s = s & vbCrLf & "        Edit" & p.Name & "1.Attach(gm, docItem," & (prest.AllowAdd = enumBoolean.Boolean_Da).ToString() & "," & (prest.AllowEdit = enumBoolean.Boolean_Da).ToString() & "," & (prest.AllowDelete = enumBoolean.Boolean_Da).ToString() & ")"
                        End If

                        If Not p.ExtenderObject Is Nothing Then
                            If p.ExtenderObject.ID.Equals(Guid.Empty) Then
                                s = s & vbCrLf & "        Edit" & p.Name & "1.SetupFromObject(Guid.Empty)"
                            Else
                                s = s & vbCrLf & "        Edit" & p.Name & "1.SetupFromObject(new Guid(""" & p.ExtenderObject.ID.ToString() & """))"
                            End If

                        Else
                            s = s & vbCrLf & "        Edit" & p.Name & "1.SetupFromObject(Guid.Empty)"
                        End If
                        s = s & vbCrLf & "    End Sub"
                        s = s & vbCrLf & ""

                        s = s & vbCrLf & " Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save"
                        s = s & vbCrLf & "     Return Edit" & p.Name & "1.Save(Sielent, NoError)"
                        s = s & vbCrLf & " End Function"

                        s = s & vbCrLf & " Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK"
                        s = s & vbCrLf & "     Return Edit" & p.Name & "1.IsOK()"
                        s = s & vbCrLf & " End Function"

                        s = s & vbCrLf & " Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged"
                        s = s & vbCrLf & "     Return Edit" & p.Name & "1.IsChanged()"
                        s = s & vbCrLf & " End Function"

                        s = s & vbCrLf & " Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify"
                        s = s & vbCrLf & "     Return Edit" & p.Name & "1.Verify(NoError)"
                        s = s & vbCrLf & " End Function"


                    End If
                    s = s & vbCrLf & "End Class"

                Catch ex As Exception
                    Debug.Print(ex.Message + " >> " + ex.StackTrace)
                End Try
            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypePanel ' "panel"
                Try


                    s = s & vbCrLf & "  Public Class view" & p.Name & mode
                    s = s & vbCrLf & "    Inherits System.Windows.Forms.UserControl"
                    s = s & vbCrLf & "    Implements LATIR2GUIManager.IViewPanel "
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
                    s = s & vbCrLf & "    'NOTE: The following procedure is required by the Windows Form Designer"
                    s = s & vbCrLf & "    'It can be modified using the Windows Form Designer."
                    s = s & vbCrLf & "    'Do not modify it using the code editor."

                    s = s & vbCrLf & "    Friend WithEvents Edit" & p.Name & "1 As " & ot.Name & "GUI.edit" & p.Name
                    's = s & vbCrLf & "    Friend WithEvents Edit" & p.Name & "1 As edit" & p.Name & mode
                    s = s & vbCrLf & "    Friend WithEvents cmdSave As System.Windows.Forms.Button"
                    s = s & vbCrLf & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
                    s = s & vbCrLf & "        Me.Edit" & p.Name & "1 = New " & ot.Name & "GUI.edit" & p.Name
                    's = s & vbCrLf & "        Me.Edit" & p.Name & "1 = New edit" & p.Name & mode
                    s = s & vbCrLf & "        Me.cmdSave = New System.Windows.Forms.Button"
                    s = s & vbCrLf & "        Me.SuspendLayout()"
                    s = s & vbCrLf & "        '"
                    s = s & vbCrLf & "        'Edit" & p.Name & "1"
                    s = s & vbCrLf & "        '"
                    s = s & vbCrLf & "        Me.Edit" & p.Name & "1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _"
                    s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Left) _"
                    s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)"
                    s = s & vbCrLf & "        Me.Edit" & p.Name & "1.Location = New System.Drawing.Point(0, 40)"
                    s = s & vbCrLf & "        Me.Edit" & p.Name & "1.name = ""Edit" & p.Name & "1"""
                    s = s & vbCrLf & "        Me.Edit" & p.Name & "1.Size = New System.Drawing.Size(248, 128)"
                    s = s & vbCrLf & "        Me.Edit" & p.Name & "1.TabIndex = 0"
                    s = s & vbCrLf & "        '"
                    s = s & vbCrLf & "        'cmdSave"
                    s = s & vbCrLf & "        '"
                    s = s & vbCrLf & "        Me.cmdSave.Location = New System.Drawing.Point(8, 8)"
                    s = s & vbCrLf & "        Me.cmdSave.name = ""cmdSave"""
                    s = s & vbCrLf & "        Me.cmdSave.Size = New System.Drawing.Size(104, 24)"
                    s = s & vbCrLf & "        Me.cmdSave.TabIndex = 1"
                    s = s & vbCrLf & "        Me.cmdSave.Text = ""&Сохранить"""
                    s = s & vbCrLf & "        '"
                    s = s & vbCrLf & "        'view"" & p.name & """
                    s = s & vbCrLf & "        '"
                    s = s & vbCrLf & "        Me.Controls.Add (Me.cmdSave)"
                    s = s & vbCrLf & "        Me.Controls.Add (Me.Edit" & p.Name & "1)"
                    s = s & vbCrLf & "        Me.name = ""view" & p.Name & """"
                    s = s & vbCrLf & "        Me.Size = New System.Drawing.Size(248, 168)"
                    s = s & vbCrLf & "        Me.ResumeLayout (False)"
                    s = s & vbCrLf & ""
                    s = s & vbCrLf & "    End Sub"
                    s = s & vbCrLf & ""
                    s = s & vbCrLf & "#End Region"
                    s = s & vbCrLf & "    Public item As " & ot.Name & "." & ot.Name & ".Application"
                    's = s & vbCrLf & "    Public item As " & ot.Name & ".Application"
                    s = s & vbCrLf & "    Public GuiManager As LATIR2GuiManager.LATIRGuiManager"
                    s = s & vbCrLf & "    Private mReadOnly as boolean"

                    s = s & vbCrLf & MakeComment("Инициализация")
                    s = s & vbCrLf & "    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager,byval ReadOnlyView as boolean) Implements LATIR2GUIManager.IViewPanel.Attach"
                    s = s & vbCrLf & "        mReadOnly = ReadOnlyView"
                    s = s & vbCrLf & "        item = CType(docItem, " & ot.Name & "." & ot.Name & ".Application)"
                    s = s & vbCrLf & "        GuiManager = gm"
                    s = s & vbCrLf & "        If item." & p.Name & ".Count = 0 Then"
                    s = s & vbCrLf & "            item." & p.Name & ".Add()"
                    s = s & vbCrLf & "        End If"
                    s = s & vbCrLf & "        Edit" & p.Name & "1.Attach(gm, item." & p.Name & ".Item(1),mReadOnly)"
                    s = s & vbCrLf & "        cmdSave.Enabled = false"
                    s = s & vbCrLf & "    End Sub"
                    s = s & vbCrLf & ""
                    s = s & vbCrLf & "    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click"
                    s = s & vbCrLf & "        if not mReadOnly then"
                    s = s & vbCrLf & "          if Edit" & p.Name & "1.IsOK() then"
                    s = s & vbCrLf & "            Edit" & p.Name & "1.Save()"
                    s = s & vbCrLf & "            item." & p.Name & ".Item(1).Save()"
                    s = s & vbCrLf & "            cmdSave.Enabled = false"
                    s = s & vbCrLf & "          Else"
                    s = s & vbCrLf & "            MsgBox(""Не все обязательные поля заполнены"")"
                    s = s & vbCrLf & "          End If"
                    s = s & vbCrLf & "        Else"
                    s = s & vbCrLf & "          MsgBox(""Сохранение невозможно, документ в режиме просмотра"")"
                    s = s & vbCrLf & "        End If"
                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & "    Private Sub Edit" & p.Name & "1_Changed() Handles Edit" & p.Name & "1.Changed"
                    s = s & vbCrLf & "        cmdSave.Enabled = True"
                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & " Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save"
                    s = s & vbCrLf & "   if not mReadOnly then"
                    s = s & vbCrLf & "     Edit" & p.Name & "1.Save()"
                    s = s & vbCrLf & "     item." & p.Name & ".Item(1).Save()"
                    s = s & vbCrLf & "     cmdSave.Enabled = false"
                    s = s & vbCrLf & "     Return true"
                    s = s & vbCrLf & "   Else"
                    s = s & vbCrLf & "     Return false"
                    s = s & vbCrLf & "   End If"
                    s = s & vbCrLf & " End Function"

                    s = s & vbCrLf & " Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK"
                    s = s & vbCrLf & "     Return Edit" & p.Name & "1.IsOK()"
                    s = s & vbCrLf & " End Function"

                    s = s & vbCrLf & " Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged"
                    s = s & vbCrLf & "   if not mReadOnly then"
                    s = s & vbCrLf & "     Return Edit" & p.Name & "1.IsChanged()"
                    s = s & vbCrLf & "   else"
                    s = s & vbCrLf & "     Return false"
                    s = s & vbCrLf & "   end if"
                    s = s & vbCrLf & " End Function"

                    s = s & vbCrLf & " Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify"
                    s = s & vbCrLf & "   if not mReadOnly then"
                    s = s & vbCrLf & "     Return  Edit" & p.Name & "1.IsOK()"
                    s = s & vbCrLf & "   else"
                    s = s & vbCrLf & "     Return true"
                    s = s & vbCrLf & "   end if"
                    s = s & vbCrLf & " End Function"

                    s = s & vbCrLf & "End Class"
                Catch ex As Exception
                    Debug.Print(ex.Message + " >> " + ex.StackTrace)
                End Try
                '
            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeGrid  ' "grid"
                Try
                    s = s & vbCrLf & "  Imports LATIR2GuiManager"
                s = s & vbCrLf & "Public Class view" & p.Name & mode
                s = s & vbCrLf & "    Inherits System.Windows.Forms.UserControl"
                s = s & vbCrLf & "    Implements LATIR2GUIManager.IViewPanel"
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
                s = s & vbCrLf & "    'NOTE: The following procedure is required by the Windows Form Designer"
                s = s & vbCrLf & "    'It can be modified using the Windows Form Designer."
                s = s & vbCrLf & "    'Do not modify it using the code editor."
                s = s & vbCrLf & "    Friend WithEvents gv As LATIR2GUIControls.GridView"
                s = s & vbCrLf & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
                s = s & vbCrLf & "        Me.gv = New LATIR2GUIControls.GridView"
                s = s & vbCrLf & "        Me.SuspendLayout()"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        'gv"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        Me.gv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _"
                s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Left) _"
                s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)"
                s = s & vbCrLf & "        Me.gv.Location = New System.Drawing.Point(0, 0)"
                s = s & vbCrLf & "        Me.gv.name = ""gv"""
                s = s & vbCrLf & "        Me.gv.Size = New System.Drawing.Size(424, 216)"
                s = s & vbCrLf & "        Me.gv.TabIndex = 0"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        'view" & p.Name & mode
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        Me.Controls.Add (Me.gv)"
                s = s & vbCrLf & "        Me.name = ""view" & p.Name & mode & """"
                s = s & vbCrLf & "        Me.Size = New System.Drawing.Size(424, 216)"
                s = s & vbCrLf & "        Me.ResumeLayout (False)"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "#End Region"
                s = s & vbCrLf & "    Public item As " & ot.Name & "." & ot.Name & ".Application"
                's = s & vbCrLf & "    Public item As " & ot.Name & ".Application"
                s = s & vbCrLf & "    Private mReadOnly as boolean"
                s = s & vbCrLf & "    Public GuiManager As LATIR2GuiManager.LATIRGuiManager"


                s = s & vbCrLf & MakeComment("Инициализация")
                s = s & vbCrLf & "    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, byval ReadOnlyView as boolean )  Implements LATIR2GUIManager.IViewPanel.Attach"
                s = s & vbCrLf & "        mReadOnly = ReadOnlyView"
                s = s & vbCrLf & "        item = CType(docItem, " & ot.Name & "." & ot.Name & ".Application)"
                s = s & vbCrLf & "        GuiManager = gm"
                s = s & vbCrLf & "        Init()"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Load table settings")
                s = s & vbCrLf & "    Public Sub Init()"
                s = s & vbCrLf & "        Dim ts As DataGridTableStyle"
                s = s & vbCrLf & "        Dim cs As DataGridTextBoxColumn"
                s = s & vbCrLf & "        Dim dt As DataTable"
                's = s & vbCrLf & "        Dim i As Integer"
                s = s & vbCrLf & "        dt = item." & p.Name & ".GetDataTable()"
                s = s & vbCrLf & "        dt.TableName = """ & p.Name & """"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "        ts = New DataGridTableStyle"
                s = s & vbCrLf & "        ts.MappingName = """ & p.Name & """"
                s = s & vbCrLf & "        ts.ReadOnly = True"
                s = s & vbCrLf & "        ts.RowHeaderWidth = 30"
                s = s & vbCrLf & ""
                For i = 1 To p.FIELD.Count

                    s = s & vbCrLf & ""
                    s = s & vbCrLf & "        cs = New DataGridTextBoxColumn"
                    s = s & vbCrLf & "        cs.ReadOnly = True"
                    s = s & vbCrLf & "        cs.HeaderText = """ & p.FIELD.Item(i).Caption & """"
                    s = s & vbCrLf & "        cs.MappingName = """ & p.FIELD.Item(i).Name & """"
                    s = s & vbCrLf & "        cs.NullText = """""
                    s = s & vbCrLf & "        ts.GridColumnStyles.Add (cs)"
                Next
                s = s & vbCrLf & ""
                s = s & vbCrLf & "        gv.InitFields (ts)"
                s = s & vbCrLf & "        gv.SetData (dt)"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & ""

                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Обслуживание редактирования Edit action")
                s = s & vbCrLf & "    Private Sub gv_OnEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnGridEdit"
                's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        ed = item.FindRowObject(""" & p.Name & """, ID)"
                s = s & vbCrLf & "        Dim gui As Doc_GUIBase"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base), mReadOnly ) = True Then"
                s = s & vbCrLf & "            Dim dt As DataTable"
                s = s & vbCrLf & "            dt = item." & p.Name & ".GetDataTable()"
                s = s & vbCrLf & "            dt.TableName = """ & p.Name & """"
                s = s & vbCrLf & "            gv.SetData (dt)"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Обслуживание удаления Delete action")
                s = s & vbCrLf & "    Private Sub gv_OnDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnGridDel"
                s = s & vbCrLf & "      If not mReadOnly Then"
                's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        ed = item.FindRowObject(""" & p.Name & """, ID)"
                s = s & vbCrLf & "        If MsgBox(""Удалить <"" & ed.Brief & ""> ?"", MsgBoxStyle.YesNo + MsgBoxStyle.Question, ""Удаление"") = MsgBoxResult.Yes Then"
                s = s & vbCrLf & "            OK = ed.Parent.Delete(ed.ID.ToString)"
                s = s & vbCrLf & "            If OK Then"
                s = s & vbCrLf & "                Dim dt As DataTable"
                s = s & vbCrLf & "                dt = item." & p.Name & ".GetDataTable()"
                s = s & vbCrLf & "                dt.TableName = """ & p.Name & """"
                s = s & vbCrLf & "                gv.SetData (dt)"
                s = s & vbCrLf & "            End If"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Обслуживание создания записи Create action")
                s = s & vbCrLf & "    Private Sub gv_OnAdd(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnGridAdd"
                's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "      If not mReadOnly Then"
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        If ID.Equals(System.guid.Empty) Then"
                s = s & vbCrLf & "              ed = Item." & p.Name & ".Add"
                s = s & vbCrLf & "          Else"
                s = s & vbCrLf & "              ed = Item." & p.Name & ".Add(ID.ToString())"
                s = s & vbCrLf & "          End If"
                s = s & vbCrLf & "        Dim gui As Doc_GUIBase"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed,LATIR2.Document.DocRow_Base) ) = True Then"
                s = s & vbCrLf & "            dt = item." & p.Name & ".GetDataTable()"
                s = s & vbCrLf & "            dt.TableName = """ & p.Name & """"
                s = s & vbCrLf & "            gv.SetData (dt)"
                s = s & vbCrLf & "        Else"
                s = s & vbCrLf & "            item." & p.Name & ".Refresh()"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Обслуживание кнопки <обновить> refresh action")
                s = s & vbCrLf & "    Private Sub gv_OnRefresh() Handles gv.OnGridRefresh"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        item." & p.Name & ".Refresh()"
                s = s & vbCrLf & "        dt = item." & p.Name & ".GetDataTable()"
                s = s & vbCrLf & "        dt.TableName = """ & p.Name & """"
                s = s & vbCrLf & "        gv.SetData (dt)"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & " Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged"
                s = s & vbCrLf & "     Return false"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"


                    s = s & vbCrLf & "End Class"
                Catch ex As Exception
                    Debug.Print(ex.Message + " >> " + ex.StackTrace)
                End Try

            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeTree  ' "tree"
                Try


                    s = s & vbCrLf & "Public Class view" & p.Name & mode
                s = s & vbCrLf & "    Inherits System.Windows.Forms.UserControl"
                s = s & vbCrLf & "    Implements LATIR2GUIManager.IViewPanel"

                s = s & vbCrLf & "#Region "" Windows Form Designer generated code """
                s = s & vbCrLf & "    Public Sub New()"
                s = s & vbCrLf & "        MyBase.New()"
                s = s & vbCrLf & "        InitializeComponent()"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    'UserControl overrides dispose to clean up the component list."
                s = s & vbCrLf & "    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)"
                s = s & vbCrLf & "        If disposing Then"
                s = s & vbCrLf & "            If Not (components Is Nothing) Then"
                s = s & vbCrLf & "                components.Dispose()"
                s = s & vbCrLf & "            End If"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "        MyBase.Dispose(disposing)"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    'Required by the Windows Form Designer"
                s = s & vbCrLf & "    Private components As System.ComponentModel.IContainer"

                s = s & vbCrLf & "    'NOTE: The following procedure is required by the Windows Form Designer"
                s = s & vbCrLf & "    'It can be modified using the Windows Form Designer."
                s = s & vbCrLf & "    'Do not modify it using the code editor."
                s = s & vbCrLf & "    Friend WithEvents TreeView1 As LATIR2GUIControls.TreeView"
                s = s & vbCrLf & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
                s = s & vbCrLf & "        Me.TreeView1 = New LATIR2GUIControls.TreeView"
                s = s & vbCrLf & "        Me.SuspendLayout()"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        'TreeView1"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _"
                s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Left) _"
                s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)"
                s = s & vbCrLf & "        Me.TreeView1.Caption = """""
                s = s & vbCrLf & "        Me.TreeView1.Location = New System.Drawing.Point(0, 8)"
                s = s & vbCrLf & "        Me.TreeView1.Name = ""TreeView1"""
                s = s & vbCrLf & "        Me.TreeView1.Size = New System.Drawing.Size(680, 304)"
                s = s & vbCrLf & "        Me.TreeView1.TabIndex = 0"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        'view"" & p.name & """
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        Me.Controls.Add(Me.TreeView1)"
                s = s & vbCrLf & "        Me.Name = ""view" & p.Name & mode & """"
                s = s & vbCrLf & "        Me.Size = New System.Drawing.Size(496, 288)"
                s = s & vbCrLf & "        Me.ResumeLayout(False)"

                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "#End Region"
                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Reference to the document, that serve control")
                's = s & vbCrLf & "    Public item As " & ot.Name & ".Application"
                s = s & vbCrLf & "    Public item As " & ot.Name & "." & ot.Name & ".Application"
                s = s & vbCrLf & "    Private mReadOnly as boolean"
                s = s & vbCrLf & "    Public GuiManager As LATIR2GuiManager.LATIRGuiManager"

                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Control initialization")
                s = s & vbCrLf & "    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, byval ReadOnlyView as boolean )  Implements LATIR2GUIManager.IViewPanel.Attach"
                s = s & vbCrLf & "        mReadOnly = ReadOnlyView"

                s = s & vbCrLf & "        item = CType(docItem, " & ot.Name & "." & ot.Name & ".Application)"
                s = s & vbCrLf & "        GuiManager = gm"
                s = s & vbCrLf & "        InitCols()"
                s = s & vbCrLf & "        TreeView1.Attach(gm, """ & p.Name & """, ""Brief"", """")"
                s = s & vbCrLf & "    End Sub"


                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Load column settings")
                s = s & vbCrLf & "    Private Sub InitCols()"
                s = s & vbCrLf & "        Dim ts As DataGridTableStyle"
                s = s & vbCrLf & "        Dim cs As DataGridTextBoxColumn"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "        ts = New DataGridTableStyle"
                s = s & vbCrLf & "        ts.MappingName = """ & p.Name & """"
                s = s & vbCrLf & "        ts.ReadOnly = True"
                s = s & vbCrLf & "        ts.RowHeaderWidth = 30"
                s = s & vbCrLf & ""

                s = s & vbCrLf & "        cs = New DataGridTextBoxColumn"
                s = s & vbCrLf & "        cs.ReadOnly = True"
                s = s & vbCrLf & "        cs.HeaderText = ""Кратко"""
                s = s & vbCrLf & "        cs.MappingName = ""Brief"""
                s = s & vbCrLf & "        cs.NullText = """""
                s = s & vbCrLf & "        ts.GridColumnStyles.Add (cs)"
                For i = 1 To p.FIELD.Count
                    s = s & vbCrLf & ""
                    s = s & vbCrLf & "        cs = New DataGridTextBoxColumn"
                    s = s & vbCrLf & "        cs.ReadOnly = True"
                    s = s & vbCrLf & "        cs.HeaderText = """ & p.FIELD.Item(i).Caption & """"
                    s = s & vbCrLf & "        cs.MappingName = """ & p.FIELD.Item(i).Name & """"
                    s = s & vbCrLf & "        cs.NullText = """""
                    s = s & vbCrLf & "        ts.GridColumnStyles.Add (cs)"
                Next
                s = s & vbCrLf & ""
                s = s & vbCrLf & "        TreeView1.InitTreeColumns (ts)"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""

                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Load data to tree")
                s = s & vbCrLf & "    Private Sub TreeView1_GetLevelData(ByVal Parent As System.Guid) Handles TreeView1.OnTreeGetData"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        Dim f As " & ot.Name & "." & ot.Name & "." & p.Name
                s = s & vbCrLf & "        If Parent.Equals(System.Guid.Empty) Then"
                s = s & vbCrLf & "            dt = item." & p.Name & ".GetDataTable"
                s = s & vbCrLf & "            TreeView1.LoadLevelData(Parent, dt)"
                s = s & vbCrLf & "        Else"
                s = s & vbCrLf & "            f = CType(item.FindRowObject(""" & p.Name & """, Parent), " & ot.Name & "." & ot.Name & "." & p.Name & ")"
                s = s & vbCrLf & "            dt = f." & p.Name & ".GetDataTable"
                s = s & vbCrLf & "            TreeView1.LoadLevelData(Parent, dt)"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Обслуживание добавления в корневой элемент")
                s = s & vbCrLf & "    Private Sub TreeView1_OnAddRoot(Byref OK As Boolean) Handles TreeView1.OnTreeAddRoot"
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name
                s = s & vbCrLf & "        ed = item." & p.Name & ".Add"
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base )) = True Then"
                s = s & vbCrLf & "            TreeView1.RefreshData()"
                s = s & vbCrLf & "        Else"
                s = s & vbCrLf & "            item." & p.Name & ".Refresh()"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Обслуживание редактирования")
                s = s & vbCrLf & "    Private Sub gv_OnEdit(Byref OK As Boolean, ByVal ID As System.Guid) Handles TreeView1.OnTreeEdit"
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name
                s = s & vbCrLf & "        ed = item.FindRowObject(""" & p.Name & """, ID)"
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base ), mReadOnly) = True Then"
                s = s & vbCrLf & "            if Typeof(ed.parent.parent) is " & ot.Name & "." & ot.Name & "." & p.Name & " then"
                s = s & vbCrLf & "              TreeView1_GetLevelData(ed.parent.parent.id) "
                s = s & vbCrLf & "            else"
                s = s & vbCrLf & "              TreeView1.RefreshData()"
                s = s & vbCrLf & "            end if"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Обслуживание удаления")
                s = s & vbCrLf & "    Private Sub gv_OnDel(Byref OK As Boolean, ByVal ID As System.Guid) Handles TreeView1.OnTreeDel"
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name
                s = s & vbCrLf & "        Dim edp As Object"
                s = s & vbCrLf & "        ed = item.FindRowObject(""" & p.Name & """, ID)"
                s = s & vbCrLf & "        if ed  is nothing then exit sub"
                s = s & vbCrLf & "        edp=ed.parent.parent"
                s = s & vbCrLf & "        If MsgBox(""Удалить <"" & ed.Brief & ""> ?"", MsgBoxStyle.YesNo + MsgBoxStyle.Question, ""Удаление строки"") = MsgBoxResult.Yes Then"
                s = s & vbCrLf & "            OK = ed.Parent.Delete(ed.ID.ToString)"
                s = s & vbCrLf & "            If OK Then"
                s = s & vbCrLf & "              if Typeof(edp) is " & ot.Name & "." & ot.Name & "." & p.Name & " then"
                s = s & vbCrLf & "               TreeView1_GetLevelData(edp.id) "
                s = s & vbCrLf & "             else"
                s = s & vbCrLf & "                TreeView1.RefreshData()"
                s = s & vbCrLf & "              end if"
                s = s & vbCrLf & "            End If"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Обслуживание добавления в уровень дерева")
                s = s & vbCrLf & "    Private Sub gv_OnAdd(Byref OK As Boolean, ByVal ID As System.Guid) Handles TreeView1.OnTreeAdd"
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name
                s = s & vbCrLf & "        Dim fs As " & ot.Name & "." & ot.Name & "." & p.Name
                s = s & vbCrLf & "        fs = item.FindRowObject(""" & p.Name & """, ID)"
                s = s & vbCrLf & "        ed = fs." & p.Name & ".Add()"
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed,LATIR2.Document.DocRow_Base) ) = True Then"
                s = s & vbCrLf & "            if Typeof(ed.parent.parent) is " & ot.Name & "." & ot.Name & "." & p.Name & " then"
                s = s & vbCrLf & "              TreeView1_GetLevelData(ed.parent.parent.id) "
                s = s & vbCrLf & "            else"
                s = s & vbCrLf & "              TreeView1.RefreshData()"
                s = s & vbCrLf & "            end if"
                s = s & vbCrLf & "        Else"
                s = s & vbCrLf & "            item." & p.Name & ".Refresh()"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"


                s = s & vbCrLf & " Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged"
                s = s & vbCrLf & "     Return false"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"

                    s = s & vbCrLf & "End Class"
                Catch ex As Exception
                    Debug.Print(ex.Message + " >> " + ex.StackTrace)
                End Try


            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeTreeGrid ' "treegrid"
                child = Nothing
                Try
                    p.PART.Sort = "sequence"
                For i = 1 To p.PART.Count
                    If LATIR2Framework.ObjectHelper.IsPresent(p.PART.Item(i), mode) Then
                        child = p.PART.Item(i)
                        Exit For
                    End If
                Next


                s = s & vbCrLf & "  Public Class view" & p.Name & mode
                s = s & vbCrLf & "    Inherits System.Windows.Forms.UserControl"
                s = s & vbCrLf & "    Implements LATIR2GUIManager.IViewPanel"
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
                s = s & vbCrLf & "    'NOTE: The following procedure is required by the Windows Form Designer"
                s = s & vbCrLf & "    'It can be modified using the Windows Form Designer."
                s = s & vbCrLf & "    'Do not modify it using the code editor."
                s = s & vbCrLf & "    Friend WithEvents tgv As LATIR2GUIControls.TreeGridView"
                s = s & vbCrLf & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
                s = s & vbCrLf & "        Me.tgv = New LATIR2GUIControls.TreeGridView"
                s = s & vbCrLf & "        Me.SuspendLayout()"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        'tgv"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        Me.tgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _"
                s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Left) _"
                s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)"
                s = s & vbCrLf & "        Me.tgv.Location = New System.Drawing.Point(0, 0)"
                s = s & vbCrLf & "        Me.tgv.name = ""tgv"""
                s = s & vbCrLf & "        Me.tgv.Size = New System.Drawing.Size(520, 304)"
                s = s & vbCrLf & "        Me.tgv.TabIndex = 0"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        'view" & p.Name & mode
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        Me.Controls.Add (Me.tgv)"
                s = s & vbCrLf & "        Me.name = ""view" & p.Name & mode & """"
                s = s & vbCrLf & "        Me.Size = New System.Drawing.Size(512, 304)"
                s = s & vbCrLf & "        Me.ResumeLayout (False)"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "#End Region"
                's = s & vbCrLf & "    Public item As " & ot.Name & ".Application"
                s = s & vbCrLf & "    Public item As " & ot.Name & "." & ot.Name & ".Application"
                s = s & vbCrLf & "    Public GuiManager As LATIR2GuiManager.LATIRGuiManager"
                s = s & vbCrLf & "    Private mReadOnly as boolean"
                s = s & vbCrLf & "    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager,byval ReadOnlyView as boolean)  Implements LATIR2GUIManager.IViewPanel.Attach"
                s = s & vbCrLf & "        mReadOnly = ReadOnlyView"
                s = s & vbCrLf & "        item = CType(docItem, " & ot.Name & "." & ot.Name & ".Application)"
                s = s & vbCrLf & "        GuiManager = gm"
                s = s & vbCrLf & "        InitCols()"
                s = s & vbCrLf & "        tgv.Attach(gm, """ & p.Name & """, ""Brief"")"
                s = s & vbCrLf & "        Dim ts As DataGridTableStyle"
                s = s & vbCrLf & "        Dim cs As DataGridTextBoxColumn"
                s = s & vbCrLf & ""
                s = s & vbCrLf & ""
                s = s & vbCrLf & "        ts = New DataGridTableStyle"
                If (Not child Is Nothing) Then
                    s = s & vbCrLf & "        ts.MappingName = """ & child.Name & """"
                Else
                    s = s & vbCrLf & "        ts.MappingName = """ & """"
                End If
                s = s & vbCrLf & "        ts.ReadOnly = True"
                s = s & vbCrLf & "        ts.RowHeaderWidth = 30"
                s = s & vbCrLf & ""

                child.FIELD.Sort = "sequence"
                For i = 1 To child.FIELD.Count
                    s = s & vbCrLf & "        cs = New DataGridTextBoxColumn"
                    s = s & vbCrLf & "        cs.ReadOnly = True"
                    s = s & vbCrLf & "        cs.HeaderText = """ & child.FIELD.Item(i).Caption & """"
                    s = s & vbCrLf & "        cs.MappingName = """ & child.FIELD.Item(i).Name & """"
                    s = s & vbCrLf & "        cs.NullText = """""
                    s = s & vbCrLf & "        ts.GridColumnStyles.Add (cs)"
                Next

                s = s & vbCrLf & "        tgv.InitChildFields (ts)"
                s = s & vbCrLf & "    End Sub"


                s = s & vbCrLf & LATIR2Framework.StringHelper.MakeComment("Load column settings")
                s = s & vbCrLf & "    Private Sub InitCols()"
                s = s & vbCrLf & "        Dim ts As DataGridTableStyle"
                s = s & vbCrLf & "        Dim cs As DataGridTextBoxColumn"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "        ts = New DataGridTableStyle"
                s = s & vbCrLf & "        ts.MappingName = """ & p.Name & """"
                s = s & vbCrLf & "        ts.ReadOnly = True"
                s = s & vbCrLf & "        ts.RowHeaderWidth = 30"
                s = s & vbCrLf & ""

                s = s & vbCrLf & "        cs = New DataGridTextBoxColumn"
                s = s & vbCrLf & "        cs.ReadOnly = True"
                s = s & vbCrLf & "        cs.HeaderText = ""Кратко"""
                s = s & vbCrLf & "        cs.MappingName = ""Brief"""
                s = s & vbCrLf & "        cs.NullText = """""
                s = s & vbCrLf & "        ts.GridColumnStyles.Add (cs)"
                For i = 1 To p.FIELD.Count
                    s = s & vbCrLf & ""
                    s = s & vbCrLf & "        cs = New DataGridTextBoxColumn"
                    s = s & vbCrLf & "        cs.ReadOnly = True"
                    s = s & vbCrLf & "        cs.HeaderText = """ & p.FIELD.Item(i).Caption & """"
                    s = s & vbCrLf & "        cs.MappingName = """ & p.FIELD.Item(i).Name & """"
                    s = s & vbCrLf & "        cs.NullText = """""
                    s = s & vbCrLf & "        ts.GridColumnStyles.Add (cs)"
                Next
                s = s & vbCrLf & ""
                s = s & vbCrLf & "        tgv.InitTreeColumns (ts)"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""

                s = s & vbCrLf & ""
                s = s & vbCrLf & "    Private Sub tgv_GetLevelData(ByVal Parent As System.Guid) Handles tgv.OnTreeGetData"
                s = s & vbCrLf & "        Dim dt As DataTable"
                's = s & vbCrLf & "        Dim f As " & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        Dim f As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        If Parent.Equals(System.guid.Empty) Then"
                s = s & vbCrLf & "            dt = item." & p.Name & ".GetDataTable"
                s = s & vbCrLf & "            tgv.LoadLevelData(Parent, dt)"
                s = s & vbCrLf & "        Else"
                's = s & vbCrLf & "            f = CType(item.FindRowObject(""" & p.Name & """, Parent), " & ot.Name & "." & p.Name & ")"
                s = s & vbCrLf & "            f = CType(item.FindRowObject(""" & p.Name & """, Parent), " & ot.Name & "." & ot.Name & "." & p.Name & ")"
                s = s & vbCrLf & "            dt = f." & p.Name & ".GetDataTable"
                s = s & vbCrLf & "            tgv.LoadLevelData(Parent, dt)"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "    Private Sub tgv_OnAddRoot(Byref OK As Boolean) Handles tgv.OnTreeAddRoot"
                's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        ed = item." & p.Name & ".Add"
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType( ed, LATIR2.Document.DocRow_Base) ) = True Then"
                s = s & vbCrLf & "            tgv.RefreshData()"
                s = s & vbCrLf & "        Else"
                s = s & vbCrLf & "            item." & p.Name & ".Refresh()"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "    Private Sub tgv_OnEdit(Byref OK As Boolean, ByVal ID As System.Guid) Handles tgv.OnTreeEdit"
                's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"
                s = s & vbCrLf & "        Dim edp As Object"
                s = s & vbCrLf & "        ed = item.FindRowObject(""" & p.Name & """, ID)"
                s = s & vbCrLf & "        if ed is nothing then exit sub"
                s = s & vbCrLf & "        edp =ed.parent.parent"
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed,LATIR2.Document.DocRow_Base ),mreadonly ) = True Then"
                's = s & vbCrLf & "              if typeof(edp) is " & ot.Name & "." & p.Name & " then "
                s = s & vbCrLf & "              if typeof(edp) is " & ot.Name & "." & ot.Name & "." & p.Name & " then "
                s = s & vbCrLf & "                tgv_GetLevelData(edp.id) "
                s = s & vbCrLf & "              Else"
                s = s & vbCrLf & "                tgv.RefreshData()"
                s = s & vbCrLf & "              End If"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "    Private Sub tgv_OnDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles tgv.OnTreeDel"
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name
                s = s & vbCrLf & "        Dim edp As Object"
                s = s & vbCrLf & "        ed = item.FindRowObject(""" & p.Name & """, ID)"
                s = s & vbCrLf & "        if ed is nothing then exit sub"
                s = s & vbCrLf & "        edp =ed.parent.parent"
                s = s & vbCrLf & "        If MsgBox(""Удалить <"" & ed.Brief & ""> ?"", MsgBoxStyle.YesNo + MsgBoxStyle.Question, ""Удаление строки"") = MsgBoxResult.Yes Then"
                s = s & vbCrLf & "            OK = ed.Parent.Delete(ed.ID.ToString)"
                s = s & vbCrLf & "            If OK Then"
                's = s & vbCrLf & "              if typeof(edp) is " & ot.Name & "." & p.Name & " then "
                s = s & vbCrLf & "              if typeof(edp) is " & ot.Name & "." & ot.Name & "." & p.Name & " then "
                s = s & vbCrLf & "                tgv_GetLevelData(edp.id) "
                s = s & vbCrLf & "              Else"
                s = s & vbCrLf & "                tgv.RefreshData()"
                s = s & vbCrLf & "              End If"
                s = s & vbCrLf & "            End If"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "    Private Sub tgv_OnAdd(ByRef OK As Boolean, ByVal ID As System.Guid) Handles tgv.OnTreeAdd"
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                's = s & vbCrLf & "        Dim fs As " & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        Dim fs As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & ""
                s = s & vbCrLf & "        fs = item.FindRowObject(""" & p.Name & """, ID)"
                s = s & vbCrLf & "        ed = fs." & p.Name & ".Add()"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType( ed, LATIR2.Document.DocRow_Base) ) = True Then"
                s = s & vbCrLf & "            tgv_GetLevelData(fs.id) "
                s = s & vbCrLf & "        Else"
                s = s & vbCrLf & "            fs." & p.Name & ".Refresh()"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""

                s = s & vbCrLf & "    Private Sub tgv_OnChildRefresh(ByVal ParentID As System.Guid) Handles tgv.OnGridRefresh"
                s = s & vbCrLf & ""
                's = s & vbCrLf & "        Dim fs As " & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        Dim fs As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        fs = item.FindRowObject(""" & p.Name & """, ParentID)"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        dt = fs." & child.Name & ".GetDataTable"
                s = s & vbCrLf & "        dt.TableName = """ & child.Name & """"
                s = s & vbCrLf & "        tgv.SetChildData (dt)"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "    Private Sub tgv_OnChildAdd(ByRef OK As Boolean, ByVal ParentID As System.Guid) Handles tgv.OnGridAdd"
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & child.Name & ""
                's = s & vbCrLf & "        Dim fs As " & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        Dim fs As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        fs = item.FindRowObject(""" & p.Name & """, ParentID)"
                s = s & vbCrLf & "        ed = fs." & child.Name & ".Add()"
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base ) ) = True Then"
                s = s & vbCrLf & "            dt = fs." & child.Name & ".GetDataTable"
                s = s & vbCrLf & "            dt.TableName = """ & child.Name & """"
                s = s & vbCrLf & "            tgv.SetChildData (dt)"
                s = s & vbCrLf & "        Else"
                s = s & vbCrLf & "            fs." & child.Name & ".Refresh()"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "    Private Sub tgv_OnChildDel(ByRef OK As Boolean, ByVal ParentID As System.Guid, ByVal ID As System.Guid) Handles tgv.OnGridDel"
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim fs As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        fs = item.FindRowObject(""" & p.Name & """, ParentID)"
                's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & child.Name & ""
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & child.Name & ""
                s = s & vbCrLf & "        ed = item.FindRowObject(""" & child.Name & """, ID)"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        If MsgBox(""Удалить <"" & ed.Brief & ""> ?"", MsgBoxStyle.YesNo + MsgBoxStyle.Question, ""Удаление строки"") = MsgBoxResult.Yes Then"
                s = s & vbCrLf & "            OK = ed.Parent.Delete(ed.ID.ToString)"
                s = s & vbCrLf & "            If OK Then"
                s = s & vbCrLf & "                dt = fs." & child.Name & ".GetDataTable"
                s = s & vbCrLf & "                dt.TableName = """ & child.Name & """"
                s = s & vbCrLf & "                tgv.SetChildData (dt)"
                s = s & vbCrLf & "            End If"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"
                s = s & vbCrLf & ""
                s = s & vbCrLf & "    Private Sub tgv_OnChildEdit(ByRef OK As Boolean, ByVal ParentID As System.Guid, ByVal ID As System.Guid) Handles tgv.OnGridEdit"
                's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & child.Name & ""
                s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & child.Name & ""
                's = s & vbCrLf & "        Dim fs As " & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        Dim fs As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                s = s & vbCrLf & "        fs = item.FindRowObject(""" & p.Name & """, ParentID)"
                s = s & vbCrLf & "        ed = item.FindRowObject(""" & child.Name & """, ID)"
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base ),mReadOnly ) = True Then"
                s = s & vbCrLf & "            dt = fs." & child.Name & ".GetDataTable"
                s = s & vbCrLf & "            dt.TableName = """ & child.Name & """"
                s = s & vbCrLf & "            tgv.SetChildData (dt)"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & " Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged"
                s = s & vbCrLf & "     Return false"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"


                    s = s & vbCrLf & "End Class"
                Catch ex As Exception
                    Debug.Print(ex.Message + " >> " + ex.StackTrace)
                End Try

            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeGridGrid ' "gridgrid"

                child = Nothing
                Try
                    p.PART.Sort = "sequence"
                    For i = 1 To p.PART.Count
                        If LATIR2Framework.ObjectHelper.IsPresent(p.PART.Item(i), mode) Then
                            child = p.PART.Item(i)
                            Exit For
                        End If
                    Next


                    s = s & vbCrLf & "Imports LATIR2GuiManager"
                    s = s & vbCrLf & "Public Class view" & p.Name & mode
                    s = s & vbCrLf & "    Inherits System.Windows.Forms.UserControl"
                    s = s & vbCrLf & "    Implements LATIR2GUIManager.IViewPanel"

                    s = s & vbCrLf & "#Region "" Windows Form Designer generated code """

                    s = s & vbCrLf & "    Public Sub New()"
                    s = s & vbCrLf & "        MyBase.New()"

                    s = s & vbCrLf & "        'This call is required by the Windows Form Designer."
                    s = s & vbCrLf & "        InitializeComponent()"

                    s = s & vbCrLf & "        'Add any initialization after the InitializeComponent() call"

                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & "    'UserControl overrides dispose to clean up the component list."
                    s = s & vbCrLf & "    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)"
                    s = s & vbCrLf & "        If disposing Then"
                    s = s & vbCrLf & "            If Not (components Is Nothing) Then"
                    s = s & vbCrLf & "                components.Dispose()"
                    s = s & vbCrLf & "            End If"
                    s = s & vbCrLf & "        End If"
                    s = s & vbCrLf & "        MyBase.Dispose(disposing)"
                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & "    'Required by the Windows Form Designer"
                    s = s & vbCrLf & "    Private components As System.ComponentModel.IContainer"

                    s = s & vbCrLf & "    'NOTE: The following procedure is required by the Windows Form Designer"
                    s = s & vbCrLf & "    'It can be modified using the Windows Form Designer."
                    s = s & vbCrLf & "    'Do not modify it using the code editor."
                    s = s & vbCrLf & "    Friend WithEvents gv As LATIR2GUIControls.GridGridView"
                    s = s & vbCrLf & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
                    s = s & vbCrLf & "        Me.gv = New LATIR2GUIControls.GridGridView"
                    s = s & vbCrLf & "        Me.SuspendLayout()"
                    s = s & vbCrLf & "        '"
                    s = s & vbCrLf & "        'gv"
                    s = s & vbCrLf & "        '"
                    s = s & vbCrLf & "        Me.gv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _"
                    s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Left) _"
                    s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)"
                    s = s & vbCrLf & "        Me.gv.Caption = """""
                    s = s & vbCrLf & "        Me.gv.Location = New System.Drawing.Point(0, 0)"
                    s = s & vbCrLf & "        Me.gv.Name = ""gv"""
                    s = s & vbCrLf & "        Me.gv.Size = New System.Drawing.Size(424, 392)"
                    s = s & vbCrLf & "        Me.gv.TabIndex = 0"
                    s = s & vbCrLf & "        '"
                    s = s & vbCrLf & "        'view" & p.Name & mode
                    s = s & vbCrLf & "        '"
                    s = s & vbCrLf & "        Me.Controls.Add(Me.gv)"
                    s = s & vbCrLf & "        Me.Name = ""view" & p.Name & mode & """"
                    s = s & vbCrLf & "        Me.Size = New System.Drawing.Size(424, 392)"
                    s = s & vbCrLf & "        Me.ResumeLayout(False)"

                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & "#End Region"
                    's = s & vbCrLf & "    Public item As " & ot.Name & ".Application"
                    s = s & vbCrLf & "    Public item As " & ot.Name & "." & ot.Name & ".Application"
                    s = s & vbCrLf & "    Public GuiManager As LATIR2GuiManager.LATIRGuiManager"
                    s = s & vbCrLf & "    Private mReadOnly as boolean"
                    s = s & vbCrLf & "    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager,byval ReadOnlyView as boolean )  Implements LATIR2GUIManager.IViewPanel.Attach"
                    s = s & vbCrLf & "        mReadOnly = ReadOnlyView"
                    s = s & vbCrLf & "        item = CType(docItem, " & ot.Name & "." & ot.Name & ".Application)"
                    s = s & vbCrLf & "        GuiManager = gm"
                    s = s & vbCrLf & "        Init()"
                    s = s & vbCrLf & "    End Sub"
                    s = s & vbCrLf & "    Public Sub Init()"
                    s = s & vbCrLf & "        Dim ts As DataGridTableStyle"
                    s = s & vbCrLf & "        Dim cs As DataGridTextBoxColumn"
                    s = s & vbCrLf & "        Dim dt As DataTable"
                    s = s & vbCrLf & "        Dim i As Integer"
                    s = s & vbCrLf & "        dt = item." & p.Name & ".GetDataTable()"
                    s = s & vbCrLf & "        dt.TableName = """ & p.Name & """"



                    s = s & vbCrLf & "        ts = New DataGridTableStyle"
                    s = s & vbCrLf & "        ts.MappingName = """ & p.Name & """"
                    s = s & vbCrLf & "        ts.ReadOnly = True"
                    s = s & vbCrLf & "        ts.RowHeaderWidth = 30"

                    p.FIELD.Sort = "sequence"
                    For i = 1 To p.FIELD.Count
                        s = s & vbCrLf & "        cs = New DataGridTextBoxColumn"
                        s = s & vbCrLf & "        ' TextBoxColumn"
                        s = s & vbCrLf & "        cs.ReadOnly = True"
                        s = s & vbCrLf & "        cs.HeaderText = """ & p.FIELD.Item(i).Caption & """"
                        s = s & vbCrLf & "        cs.MappingName = """ & p.FIELD.Item(i).Name & """"
                        s = s & vbCrLf & "        cs.NullText = """""
                        s = s & vbCrLf & "        ts.GridColumnStyles.Add(cs)"
                    Next
                    s = s & vbCrLf & "        gv.InitFieldsMaster(ts)"


                    s = s & vbCrLf & "        ts = New DataGridTableStyle"
                    s = s & vbCrLf & "        ts.MappingName = """ & child.Name & """"
                    s = s & vbCrLf & "        ts.ReadOnly = True"
                    s = s & vbCrLf & "        ts.RowHeaderWidth = 30"

                    child.FIELD.Sort = "sequence"
                    For i = 1 To child.FIELD.Count
                        s = s & vbCrLf & "        cs = New DataGridTextBoxColumn"
                        s = s & vbCrLf & "        ' TextBoxColumn"
                        s = s & vbCrLf & "        cs.ReadOnly = True"
                        s = s & vbCrLf & "        cs.HeaderText = """ & child.FIELD.Item(i).Caption & """"
                        s = s & vbCrLf & "        cs.MappingName = """ & child.FIELD.Item(i).Name & """"
                        s = s & vbCrLf & "        cs.NullText = """""
                        s = s & vbCrLf & "        ts.GridColumnStyles.Add(cs)"
                    Next

                    s = s & vbCrLf & "        gv.InitFieldsChild(ts)"
                    s = s & vbCrLf & "        gv.SetDataMaster(dt)"
                    s = s & vbCrLf & "    End Sub"




                    s = s & vbCrLf & "    Private Sub gv_OnEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnMasterGridEdit"
                    ' s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & p.Name & ""
                    s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                    s = s & vbCrLf & "        ed = item.FindRowObject(""" & p.Name & """, ID)"
                    s = s & vbCrLf & "        Dim gui As Doc_GUIBase"

                    s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                    s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base ),mReadOnly ) = True Then"
                    s = s & vbCrLf & "            Dim dt As DataTable"
                    s = s & vbCrLf & "            dt = item." & p.Name & ".GetDataTable()"
                    s = s & vbCrLf & "            dt.TableName = """ & p.Name & """"
                    s = s & vbCrLf & "            gv.SetDataMaster(dt)"
                    s = s & vbCrLf & "        End If"

                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & "    Private Sub gv_OnDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnMasterGridDel"
                    s = s & vbCrLf & "      if not mReadOnly then"
                    s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                    s = s & vbCrLf & "        ed = item.FindRowObject(""" & p.Name & """, ID)"
                    s = s & vbCrLf & "        If MsgBox(""Удалить <"" & ed.Brief & ""> ?"", MsgBoxStyle.YesNo + MsgBoxStyle.Question, ""Удаление строки"") = MsgBoxResult.Yes Then"
                    s = s & vbCrLf & "            OK = ed.Parent.Delete(ed.ID.ToString)"
                    s = s & vbCrLf & "            If OK Then"
                    s = s & vbCrLf & "                Dim dt As DataTable"
                    s = s & vbCrLf & "                'item." & p.Name & ".Refresh()"
                    s = s & vbCrLf & "                dt = item." & p.Name & ".GetDataTable()"
                    s = s & vbCrLf & "                dt.TableName = """ & p.Name & """"
                    s = s & vbCrLf & "                gv.SetDataMaster(dt)"
                    s = s & vbCrLf & "            End If"
                    s = s & vbCrLf & "        End If"
                    s = s & vbCrLf & "      End If"

                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & "    Private Sub gv_OnAdd(ByRef OK As Boolean) Handles gv.OnMasterGridAdd"
                    s = s & vbCrLf & "      if not mReadOnly then"
                    s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                    s = s & vbCrLf & "        ed = item." & p.Name & ".Add"
                    s = s & vbCrLf & "        Dim gui As Doc_GUIBase"
                    s = s & vbCrLf & "        Dim dt As DataTable"
                    s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                    s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base )) = True Then"
                    s = s & vbCrLf & "            dt = item." & p.Name & ".GetDataTable()"
                    s = s & vbCrLf & "            dt.TableName = """ & p.Name & """"
                    s = s & vbCrLf & "            gv.SetDataMaster(dt)"
                    s = s & vbCrLf & "        Else"
                    s = s & vbCrLf & "            item." & p.Name & ".Refresh()"
                    s = s & vbCrLf & "        End If"
                    s = s & vbCrLf & "      End If"
                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & "    Private Sub gv_OnRefresh() Handles gv.OnMasterGridRefresh"
                    s = s & vbCrLf & "        Dim dt As DataTable"
                    s = s & vbCrLf & "        item." & p.Name & ".Refresh()"
                    s = s & vbCrLf & "        dt = item." & p.Name & ".GetDataTable()"
                    s = s & vbCrLf & "        dt.TableName = """ & p.Name & """"
                    s = s & vbCrLf & "        gv.SetDataMaster(dt)"
                    s = s & vbCrLf & "    End Sub"



                    s = s & vbCrLf & "    Private Sub gv_OnChildRefresh() Handles gv.OnChildGridRefresh"
                    's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & p.Name & ""
                    s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                    s = s & vbCrLf & "        ed = item.FindRowObject(""" & p.Name & """, gv.GetMasterID)"
                    s = s & vbCrLf & "        Dim dt As DataTable"
                    s = s & vbCrLf & "        If Not ed Is Nothing Then"
                    s = s & vbCrLf & "            dt = ed." & child.Name & ".GetDataTable"
                    s = s & vbCrLf & "        Else"
                    s = s & vbCrLf & "            dt = New DataTable"
                    s = s & vbCrLf & "        End If"
                    s = s & vbCrLf & "        dt.TableName = """ & child.Name & """"
                    s = s & vbCrLf & "        gv.SetDataChild(dt)"

                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & "    Private Sub gv_OnChildDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnChildGridDel"
                    s = s & vbCrLf & "      if not mReadOnly then"
                    s = s & vbCrLf & "        Dim parent As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                    s = s & vbCrLf & "        parent = item.FindRowObject(""" & p.Name & """, gv.GetMasterID)"
                    's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & child.Name & ""
                    s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & child.Name & ""
                    s = s & vbCrLf & "        ed = item.FindRowObject(""" & child.Name & """, ID)"
                    s = s & vbCrLf & "        If MsgBox(""Удалить <"" & ed.Brief & ""> ?"", MsgBoxStyle.YesNo + MsgBoxStyle.Question, ""Удаление строки"") = MsgBoxResult.Yes Then"
                    s = s & vbCrLf & "            OK = ed.Parent.Delete(ed.ID.ToString)"
                    s = s & vbCrLf & "            If OK Then"
                    s = s & vbCrLf & "                Dim dt As DataTable"
                    s = s & vbCrLf & "                'parent." & p.Name & ".Refresh()"
                    s = s & vbCrLf & "                dt = parent." & child.Name & ".GetDataTable()"
                    s = s & vbCrLf & "                dt.TableName = """ & child.Name & """"
                    s = s & vbCrLf & "                gv.SetDataChild(dt)"
                    s = s & vbCrLf & "            End If"
                    s = s & vbCrLf & "        End If"
                    s = s & vbCrLf & "      End If"
                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & "    Private Sub gv_OnChildEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnChildGridEdit"
                    's = s & vbCrLf & "        Dim parent As " & ot.Name & "." & p.Name & ""
                    s = s & vbCrLf & "        Dim parent As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                    s = s & vbCrLf & "        parent = item.FindRowObject(""" & p.Name & """, gv.GetMasterID)"
                    's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & child.Name & ""
                    s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & child.Name & ""
                    s = s & vbCrLf & "        ed = item.FindRowObject(""" & child.Name & """, ID)"
                    s = s & vbCrLf & "        Dim gui As Doc_GUIBase"
                    s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                    s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base ),mreadonly) = True Then"
                    s = s & vbCrLf & "            Dim dt As DataTable"
                    s = s & vbCrLf & "            'parent." & p.Name & ".Refresh()"
                    s = s & vbCrLf & "            dt = parent." & child.Name & ".GetDataTable()"
                    s = s & vbCrLf & "            dt.TableName = """ & child.Name & """"
                    s = s & vbCrLf & "            gv.SetDataChild(dt)"
                    s = s & vbCrLf & "        End If"
                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & "    Private Sub gv_OnChildAdd(Byref OK As Boolean) Handles gv.OnChildGridAdd"
                    s = s & vbCrLf & "      if not mReadOnly then"
                    s = s & vbCrLf & "        Dim parent As " & ot.Name & "." & ot.Name & "." & p.Name & ""
                    s = s & vbCrLf & "        parent = item.FindRowObject(""" & p.Name & """, gv.GetMasterID)"
                    's = s & vbCrLf & "        Dim ed As " & ot.Name & "." & child.Name & ""
                    s = s & vbCrLf & "        Dim ed As " & ot.Name & "." & ot.Name & "." & child.Name & ""
                    s = s & vbCrLf & "        ed = parent." & child.Name & ".Add"
                    s = s & vbCrLf & "        Dim gui As Doc_GUIBase"
                    s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                    s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base ) ) = True Then"
                    s = s & vbCrLf & "            Dim dt As DataTable"
                    s = s & vbCrLf & "            'parent." & p.Name & ".Refresh()"
                    s = s & vbCrLf & "            dt = parent." & child.Name & ".GetDataTable()"
                    s = s & vbCrLf & "            dt.TableName = """ & child.Name & """"
                    s = s & vbCrLf & "            gv.SetDataChild(dt)"
                    s = s & vbCrLf & "        Else"
                    s = s & vbCrLf & "            parent." & child.Name & ".Refresh()"
                    s = s & vbCrLf & "        End If"
                    s = s & vbCrLf & "      End If"
                    s = s & vbCrLf & "    End Sub"

                    s = s & vbCrLf & " Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save"
                    s = s & vbCrLf & "     Return true"
                    s = s & vbCrLf & " End Function"

                    s = s & vbCrLf & " Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK"
                    s = s & vbCrLf & "     Return true"
                    s = s & vbCrLf & " End Function"

                    s = s & vbCrLf & " Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged"
                    s = s & vbCrLf & "     Return false"
                    s = s & vbCrLf & " End Function"

                    s = s & vbCrLf & " Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify"
                    s = s & vbCrLf & "     Return true"
                    s = s & vbCrLf & " End Function"


                    s = s & vbCrLf & "End Class"
                Catch ex As Exception
                    Debug.Print(ex.Message + " >> " + ex.StackTrace)
                End Try

            Case LATIR2Framework.ObjectHelper.InterfaceType.InterfaceTypeCommon ' "common"
                Try
                    s = s & vbCrLf & "Public Class View" & p.Name & mode
                s = s & vbCrLf & "    Inherits System.Windows.Forms.UserControl"
                s = s & vbCrLf & "    Implements LATIR2GUIManager.IViewPanel"

                s = s & vbCrLf & "#Region "" Windows Form Designer generated code """

                s = s & vbCrLf & "    Public Sub New()"
                s = s & vbCrLf & "        MyBase.New()"
                s = s & vbCrLf & "        'This call is required by the Windows Form Designer."
                s = s & vbCrLf & "        InitializeComponent()"
                s = s & vbCrLf & "        'Add any initialization after the InitializeComponent() call"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    'UserControl overrides dispose to clean up the component list."
                s = s & vbCrLf & "    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)"
                s = s & vbCrLf & "        If disposing Then"
                s = s & vbCrLf & "            If Not (components Is Nothing) Then"
                s = s & vbCrLf & "                components.Dispose()"
                s = s & vbCrLf & "            End If"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "        MyBase.Dispose(disposing)"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    'Required by the Windows Form Designer"
                s = s & vbCrLf & "    Private components As System.ComponentModel.IContainer"

                s = s & vbCrLf & "    'NOTE: The following procedure is required by the Windows Form Designer"
                s = s & vbCrLf & "    'It can be modified using the Windows Form Designer."
                s = s & vbCrLf & "    'Do not modify it using the code editor."
                s = s & vbCrLf & "    Friend WithEvents cv As LATIR2GUIControls.ComplexTreeView"
                s = s & vbCrLf & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
                s = s & vbCrLf & "        Me.cv = New LATIR2GUIControls.ComplexTreeView"
                s = s & vbCrLf & "        Me.SuspendLayout()"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        'cv"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        Me.cv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _"
                s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Left) _"
                s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)"
                s = s & vbCrLf & "        Me.cv.Location = New System.Drawing.Point(0, 0)"
                s = s & vbCrLf & "        Me.cv.Name = ""cv"""
                s = s & vbCrLf & "        Me.cv.Size = New System.Drawing.Size(520, 328)"
                s = s & vbCrLf & "        Me.cv.TabIndex = 0"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        'View" & p.Name & mode
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        Me.Controls.Add(Me.cv)"
                s = s & vbCrLf & "        Me.Name = ""View" & p.Name & mode & """"
                s = s & vbCrLf & "        Me.Size = New System.Drawing.Size(520, 328)"
                s = s & vbCrLf & "        Me.ResumeLayout(False)"

                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "#End Region"


                's = s & vbCrLf & "    Public item As " & ot.Name & ".Application"
                s = s & vbCrLf & "    Public item As " & ot.Name & "." & ot.Name & ".Application"
                s = s & vbCrLf & "    Public GuiManager As LATIR2GuiManager.LATIRGuiManager"
                s = s & vbCrLf & "    Private mReadOnly as boolean"
                s = s & vbCrLf & "    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager ,byval ReadOnlyView as boolean)  Implements LATIR2GUIManager.IViewPanel.Attach"
                s = s & vbCrLf & "        mReadOnly = ReadOnlyView"
                s = s & vbCrLf & "        item = CType(docItem, " & ot.Name & "." & ot.Name & ".Application)"
                s = s & vbCrLf & "        GuiManager = gm"
                s = s & vbCrLf & "        cv.Attach(gm, """ & p.Name & ""","""","""","""")"
                s = s & vbCrLf & "    End Sub"


                s = s & vbCrLf & "    Private Sub cv_GetLevelData(ByVal Parent As System.Guid, ByVal PartName As String, ByVal ChildPartName As String) Handles cv.OnTreeGetLevelData"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        Dim fl As Object"
                s = s & vbCrLf & "        If Parent.Equals(System.Guid.Empty) Then"
                s = s & vbCrLf & "            dt = item." & p.Name & ".GetDataTable"
                s = s & vbCrLf & "            dt.TableName = """ & p.Name & """"
                s = s & vbCrLf & "            cv.TreeLoadData(Parent, """ & p.Name & """, ""Brief"", dt)"
                s = s & vbCrLf & "        Else"
                s = s & vbCrLf & "            fl = item.FindRowObject(PartName, Parent)"
                s = s & vbCrLf & MakeGetLevelData(ot.PART, mode)

                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    Private Sub cv_GetItemParts(ByVal Parent As System.Guid, ByVal PartName As String) Handles cv.OnTreeGetItemParts"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        Dim dr As DataRow"
                s = s & vbCrLf & "        dt = New DataTable"
                s = s & vbCrLf & "        dt.Columns.Add(""name"", GetType(System.String))"
                s = s & vbCrLf & "        dt.Columns.Add(""Caption"", GetType(System.String))"
                    s = s & vbCrLf & "        try"

                    s = s & vbCrLf & MakeGetItemParts(ot.PART, mode)

                s = s & vbCrLf & "        cv.LoadItemParts(Parent, dt)"
                    s = s & vbCrLf & "        catch ex as system.Exception"
                    s = s & vbCrLf & "        Debug.Print(ex.Message +"" >> "" + ex.StackTrace)"
                    s = s & vbCrLf & "        end try"
                    s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    Private Sub cv_OnDel(ByRef OK As Boolean, ByVal ID As System.Guid, ByVal PartName As String) Handles cv.OnTreeDel"
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim ed As LATIR2.Document.DocRow_Base"
                s = s & vbCrLf & "        Dim edCol As LATIR2.Document.DocCollection_Base"
                s = s & vbCrLf & "        Dim pr As Object"
                s = s & vbCrLf & "        ed = item.FindRowObject(PartName, ID)"
                s = s & vbCrLf & "        if ed is nothing then exit sub"
                s = s & vbCrLf & "        edCol=ed.parent"
                s = s & vbCrLf & "        pr=ed.parent.parent"
                s = s & vbCrLf & "        If MsgBox(""Удалить <"" & ed.Brief & ""> ?"", MsgBoxStyle.YesNo + MsgBoxStyle.Question, ""Удаление строки"") = MsgBoxResult.Yes Then"
                s = s & vbCrLf & "            OK = ed.Parent.Delete(ID.ToString)"
                s = s & vbCrLf & "            If OK Then"
                s = s & vbCrLf & "              If TypeOf (pr) Is LATIR2.Document.DocRow_Base Then"
                s = s & vbCrLf & "                 cv.TreeLoadData(pr.ID, PartName, ""Brief"", edcol.GetDataTable)"
                s = s & vbCrLf & "              End If"
                s = s & vbCrLf & "              If TypeOf (pr) Is LATIR2.Document.Doc_Base Then"
                s = s & vbCrLf & "                 cv.TreeLoadData(System.Guid.Empty, PartName, ""Brief"", edcol.GetDataTable)"
                s = s & vbCrLf & "              End If"
                s = s & vbCrLf & "            End If"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    Private Sub cv_OnAddRoot(ByRef OK As Boolean) Handles cv.OnTreeAddRoot"
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim ed As Object"
                s = s & vbCrLf & "        ed = item." & p.Name & ".Add"
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"
                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base ) ) = True Then"
                s = s & vbCrLf & "            cv.RefreshData()"
                s = s & vbCrLf & "        Else"
                s = s & vbCrLf & "            item." & p.Name & ".Refresh()"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    Private Sub cv_OnAddBy(ByRef OK As Boolean, ByVal ParentID As System.Guid, ByVal ParentPartName As String, ByVal RowPartName As String) Handles cv.OnTreeAdd"
                s = s & vbCrLf & "      if not mReadOnly then"
                s = s & vbCrLf & "        Dim ed As Object"
                s = s & vbCrLf & "        Dim fs As Object"
                s = s & vbCrLf & "        Dim sc As Object"
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"
                s = s & vbCrLf & "        Dim dt As DataTable"

                s = s & vbCrLf & "        fs = item.FindRowObject(ParentPartName, ParentID)"
                s = s & vbCrLf & MakeOnAdd(ot.PART, mode)

                s = s & vbCrLf & "      End If"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    Private Sub cv_OnEdit(ByRef OK As Boolean, ByVal ID As System.Guid, ByVal PartName As String) Handles cv.OnTreeEdit"
                s = s & vbCrLf & "        Dim ed As LATIR2.Document.DocRow_Base"
                s = s & vbCrLf & "        Dim pr As LATIR2.Document.DocRow_Base"
                s = s & vbCrLf & "        ed = item.FindRowObject(PartName, ID)"
                s = s & vbCrLf & "        Dim gui As LATIR2GuiManager.Doc_GUIBase"

                s = s & vbCrLf & "        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                s = s & vbCrLf & "        If gui.ShowPartEditForm(""" & mode & """, CType(ed, LATIR2.Document.DocRow_Base ),mReadOnly ) = True Then"
                s = s & vbCrLf & "          If TypeOf (ed.Parent.Parent) Is LATIR2.Document.DocRow_Base Then"
                s = s & vbCrLf & "            pr = ed.Parent.Parent"
                s = s & vbCrLf & "            cv.TreeLoadData(pr.ID, ed.PartName, ""Brief"", ed.Parent.GetDataTable)"
                s = s & vbCrLf & "          End If"
                s = s & vbCrLf & "          If TypeOf (ed.Parent.Parent) Is LATIR2.Document.Doc_Base Then"
                s = s & vbCrLf & "            cv.TreeLoadData(System.Guid.Empty, ed.PartName, ""Brief"", ed.Parent.GetDataTable)"
                s = s & vbCrLf & "          End If"
                s = s & vbCrLf & "        End If"


                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    Private Sub cv_OnGridSetup(ByVal PartName As String) Handles cv.OnGridSetup"
                s = s & vbCrLf & "        Dim ts As DataGridTableStyle"
                s = s & vbCrLf & "        Dim cs As DataGridTextBoxColumn"

                s = s & vbCrLf & MakeOnGridSetup(ot.PART, mode)

                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & "    Private Sub cv_OnGridRefresh(ByVal ParentID As System.Guid, ByVal PartName As String, ByVal ChildPartName As String) Handles cv.OnGridRefresh"
                s = s & vbCrLf & "        Dim dt As DataTable"
                s = s & vbCrLf & "        Dim fl As Object"

                s = s & vbCrLf & "        If ParentID.Equals(System.Guid.Empty) Then"
                s = s & vbCrLf & "            dt = item." & p.Name & ".GetDataTable"
                s = s & vbCrLf & "            dt.TableName = """ & p.Name & """"
                s = s & vbCrLf & "            cv.SetGridData(dt)"
                s = s & vbCrLf & "        Else"
                s = s & vbCrLf & "        fl = item.FindRowObject(PartName, Parentid)"
                s = s & vbCrLf & MakeOnGridRefresh(ot.PART, mode)
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "    End Sub"

                s = s & vbCrLf & " Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged"
                s = s & vbCrLf & "     Return false"
                s = s & vbCrLf & " End Function"

                s = s & vbCrLf & " Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify"
                s = s & vbCrLf & "     Return true"
                s = s & vbCrLf & " End Function"


                    s = s & vbCrLf & "End Class"
                Catch ex As Exception
                    Debug.Print(ex.Message + " >> " + ex.StackTrace)
                End Try
        End Select


        LATIR2Framework.StringHelper.SetExt(o, "View" & p.Name & mode, "vb")
        o.Block = "code"
        o.OutNL(s)
        Exit Sub


    End Sub


    Private Function MakeOnGridSetup(ByRef pc As MTZMetaModel.MTZMetaModel.PART_col, ByVal mode As String) As String
        Dim s As String = String.Empty
        Dim i, j As Short
        pc.Sort = "sequence"
        For i = 1 To pc.Count
            s = s & vbCrLf & "        If PartName.ToUpper() = """ & UCase(pc.Item(i).Name) & """ Then"
            s = s & vbCrLf & "            ts = New DataGridTableStyle"
            s = s & vbCrLf & "            ts.MappingName = """ & pc.Item(i).Name & """"
            s = s & vbCrLf & "            ts.ReadOnly = True"
            s = s & vbCrLf & "            ts.RowHeaderWidth = 30"
            pc.Item(i).FIELD.Sort = "sequence"
            For j = 1 To pc.Item(i).FIELD.Count
                s = s & vbCrLf & "            cs = New DataGridTextBoxColumn"
                s = s & vbCrLf & "            cs.ReadOnly = True"
                s = s & vbCrLf & "            cs.HeaderText = """ & LATIR2Framework.StringHelper.NoLF(pc.Item(i).FIELD.Item(j).Caption) & """"
                s = s & vbCrLf & "            cs.MappingName = """ & pc.Item(i).FIELD.Item(j).Name & """"
                s = s & vbCrLf & "            cs.NullText = """""
                s = s & vbCrLf & "            ts.GridColumnStyles.Add(cs)"
            Next
            s = s & vbCrLf & "            cv.GridView.InitFields(ts)"
            s = s & vbCrLf & "        End If"

            s = s & vbCrLf & MakeOnGridSetup(pc.Item(i).PART, mode)
        Next

        MakeOnGridSetup = s

    End Function



    Private Function MakeGetItemParts(ByRef pc As MTZMetaModel.MTZMetaModel.PART_col, ByVal mode As String) As String
        Dim s As String = String.Empty
        Dim i, j As Short
        pc.Sort = "sequence"
        For i = 1 To pc.Count
            s = s & vbCrLf & "        If PartName.ToUpper() = """ & UCase(pc.Item(i).Name) & """ Then"
            If pc.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                s = s & vbCrLf & "            dr = dt.NewRow"
                s = s & vbCrLf & "            dr(""name"") = """ & pc.Item(i).Name & """"
                s = s & vbCrLf & "            dr(""Caption"") = """ & pc.Item(i).Caption & """"
                s = s & vbCrLf & "            dt.Rows.Add(dr)"
            End If

            pc.Item(i).PART.Sort = "sequence"
            For j = 1 To pc.Item(i).PART.Count
                s = s & vbCrLf & "            dr = dt.NewRow"
                s = s & vbCrLf & "            dr(""name"") = """ & pc.Item(i).PART.Item(j).Name & """"
                s = s & vbCrLf & "            dr(""Caption"") = """ & pc.Item(i).PART.Item(j).Caption & """"
                s = s & vbCrLf & "            dt.Rows.Add(dr)"
            Next
            s = s & vbCrLf & "        End If"

            s = s & vbCrLf & MakeGetItemParts(pc.Item(i).PART, mode)
        Next
        MakeGetItemParts = s
    End Function



    Private Function MakeGetLevelData(ByRef pc As MTZMetaModel.MTZMetaModel.PART_col, ByVal mode As String) As String
        Dim s As String = String.Empty
        Dim i, j As Short
        pc.Sort = "sequence"
        For i = 1 To pc.Count

            s = s & vbCrLf & "        If PartName.ToUpper() = """ & UCase(pc.Item(i).Name) & """ Then"
            If pc.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then

                s = s & vbCrLf & "                If ChildPartName.ToUpper() = """ & UCase(pc.Item(i).Name) & """ Then"
                s = s & vbCrLf & "                    dt = fl." & pc.Item(i).Name & ".GetDataTable"
                s = s & vbCrLf & "                    dt.TableName = """ & pc.Item(i).Name & """"
                s = s & vbCrLf & "                    cv.TreeLoadData(Parent, ChildPartName, ""Brief"", dt)"
                s = s & vbCrLf & "                End If"
            End If
            pc.Item(i).PART.Sort = "sequence"
            For j = 1 To pc.Item(i).PART.Count

                s = s & vbCrLf & "                If ChildPartName.ToUpper() = """ & UCase(pc.Item(i).PART.Item(j).Name) & """ Then"
                s = s & vbCrLf & "                    dt = fl." & pc.Item(i).PART.Item(j).Name & ".GetDataTable"
                s = s & vbCrLf & "                    dt.TableName = """ & pc.Item(i).PART.Item(j).Name & """"
                s = s & vbCrLf & "                    cv.TreeLoadData(Parent, ChildPartName, ""Brief"", dt)"
                s = s & vbCrLf & "                End If"
            Next
            s = s & vbCrLf & "        End If"

            s = s & vbCrLf & MakeGetLevelData(pc.Item(i).PART, mode)
        Next
        MakeGetLevelData = s
    End Function


    Private Function MakeOnGridRefresh(ByRef pc As MTZMetaModel.MTZMetaModel.PART_col, ByVal mode As String) As String
        Dim s As String = String.Empty
        Dim i, j As Short
        pc.Sort = "sequence"
        For i = 1 To pc.Count

            s = s & vbCrLf & "        If PartName.ToUpper() = """ & UCase(pc.Item(i).Name) & """ Then"
            If pc.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then

                s = s & vbCrLf & "                If ChildPartName.ToUpper() = """ & UCase(pc.Item(i).Name) & """ Then"
                s = s & vbCrLf & "                    dt = fl." & pc.Item(i).Name & ".GetDataTable"
                s = s & vbCrLf & "                    dt.TableName = """ & pc.Item(i).Name & """"
                s = s & vbCrLf & "                    cv.SetGridData(dt)"
                s = s & vbCrLf & "                End If"
            End If

            pc.Item(i).PART.Sort = "sequence"
            For j = 1 To pc.Item(i).PART.Count

                s = s & vbCrLf & "                If ChildPartName.ToUpper() = """ & UCase(pc.Item(i).PART.Item(j).Name) & """ Then"
                s = s & vbCrLf & "                    dt = fl." & pc.Item(i).PART.Item(j).Name & ".GetDataTable"
                s = s & vbCrLf & "                    dt.TableName = """ & pc.Item(i).PART.Item(j).Name & """"
                s = s & vbCrLf & "                    cv.SetGridData(dt)"
                s = s & vbCrLf & "                End If"
            Next
            s = s & vbCrLf & "        End If"

            s = s & vbCrLf & MakeOnGridRefresh(pc.Item(i).PART, mode)
        Next
        MakeOnGridRefresh = s
    End Function

    Private Function MakeOnAdd(ByRef pc As MTZMetaModel.MTZMetaModel.PART_col, ByVal mode As String) As String
        Dim s As String = String.Empty
        Dim i, j As Short
        Try
            pc.Sort = "sequence"
            For i = 1 To pc.Count
                'ByVal ParentID As System.Guid, ByVal ParentPartName As String, ByVal RowPartName As String
                s = s & vbCrLf & "        If ParentPartName.ToUpper() = """ & UCase(pc.Item(i).Name) & """ Then"
                If pc.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                    s = s & vbCrLf & "        If RowPartName.ToUpper() = """ & UCase(pc.Item(i).Name) & """ Then"
                    s = s & vbCrLf & "            ed = fs." & pc.Item(i).Name & ".Add()"
                    s = s & vbCrLf & "            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                    s = s & vbCrLf & "            If gui.ShowPartEditForm("""", CType(ed, LATIR2.Document.DocRow_Base)) = True Then"
                    s = s & vbCrLf & "                cv.TreeLoadData(ParentID, ed.PartName, ""Brief"", ed.Parent.GetDataTable)"
                    s = s & vbCrLf & "            Else"
                    s = s & vbCrLf & "                fs." & pc.Item(i).Name & ".Refresh()"
                    s = s & vbCrLf & "            End If"
                    s = s & vbCrLf & "        End If"

                End If

                pc.Item(i).PART.Sort = "sequence"
                For j = 1 To pc.Item(i).PART.Count
                    s = s & vbCrLf & "        If RowPartName.ToUpper() = """ & UCase(pc.Item(i).PART.Item(j).Name) & """ Then"
                    s = s & vbCrLf & "            ed = fs." & pc.Item(i).PART.Item(j).Name & ".Add()"
                    s = s & vbCrLf & "            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)"
                    s = s & vbCrLf & "            If gui.ShowPartEditForm("""", CType( ed,LATIR2.Document.DocRow_Base )) = True Then"
                    s = s & vbCrLf & "                cv.TreeLoadData(ParentID, ed.PartName, ""Brief"", ed.Parent.GetDataTable)"
                    s = s & vbCrLf & "            Else"
                    s = s & vbCrLf & "                fs." & pc.Item(i).PART.Item(j).Name & ".Refresh()"
                    s = s & vbCrLf & "            End If"
                    s = s & vbCrLf & "        End If"
                Next

                s = s & vbCrLf & "        End If"

                s = s & vbCrLf & MakeOnAdd(pc.Item(i).PART, mode)
            Next
            MakeOnAdd = s
        Catch ex As Exception
            Debug.Print(ex.Message + " >> " + ex.StackTrace)
        End Try
    End Function
End Module