Option Strict Off
Option Explicit On
Imports LATIRFramework.StringHelper
Module MakeApp
	
	
	
    Private Function MakeSPEF(ByRef pc As MTZMetaModel.MTZMetaModel.PART_col, ByVal mode As String) As String
        Dim s As String = String.Empty
        Dim i As Integer
        For i = 1 To pc.Count
            If pc.Item(i).PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                s = s & vbCrLf & "            If RowItem.PartName.ToUpper = """ & UCase(pc.Item(i).Name) & """ Then"
                s = s & vbCrLf & "                Dim f As frm" & pc.Item(i).Name & mode
                s = s & vbCrLf & "                f = New frm" & pc.Item(i).Name & mode
                s = s & vbCrLf & "                f.Attach(RowItem, Me.GUIManager,FormReadOnly)"
                s = s & vbCrLf & "                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)"
                s = s & vbCrLf & "                f = Nothing"
                s = s & vbCrLf & "            End If"
                s = s & vbCrLf & MakeSPEF(pc.Item(i).PART, mode)
            End If
        Next

        MakeSPEF = s
    End Function


    Public Sub MakeApps(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZwp.MTZwp.Application, ByRef o As LATIRGenerator.Response)
        'Dim s As String = String.Empty

        's = s & vbCrLf & "Imports LATIRGuiManager"
        's = s & vbCrLf & "Imports System.Windows.Forms"
        's = s & vbCrLf & MakeComment("Основной класс компонента", "Класс обслуживает визуальное редактирование ", "", "")
        's = s & vbCrLf & "Public Class GUI"
        's = s & vbCrLf & "    Inherits LATIRGuiManager.Doc_GUIBase"
        's = s & vbCrLf & MakeComment("Имя типа", "Код типа в метамодели", "Строковое значение кода типа объекта ", "")
        's = s & vbCrLf & "    Public Overrides Function TypeName() As String"
        's = s & vbCrLf & "        Return """ & ot.Name & """"
        's = s & vbCrLf & "    End Function"
        's = s & vbCrLf & MakeComment("Форма редактирования раздела", "Определяется какая форма должна быть вызвана, происходит инициализация и вызов формы", "Результат работы формы редактирования", "")
        's = s & vbCrLf & "    Public Overrides Function ShowPartEditForm(ByVal Mode As String, ByRef RowItem As LATIR.Document.DocRow_Base, optional byval FormReadOnly as boolean = false) As Boolean"
        's = s & vbCrLf & "        ' Mode"
        's = s & vbCrLf & "        If Mode = """" Then"
        's = s & vbCrLf & MakeSPEF(ot.PART, "")
        's = s & vbCrLf & "        End If"
        'Dim i As Integer
        'Dim mode As String
        'For i = 1 To ot.OBJECTMODE.Count
        '    mode = ot.OBJECTMODE.Item(i).Name
        '    s = s & vbCrLf & "        If Mode = """ & mode & """ Then"
        '    s = s & vbCrLf & MakeSPEF(ot.PART, mode)
        '    s = s & vbCrLf & "        End If"
        'Next
        's = s & vbCrLf & ""
        's = s & vbCrLf & "    End Function"
        's = s & vbCrLf & MakeComment("Форма редактирования документа", "Определяется какая форма должна быть вызвана, происходит инициализация и вызов формы в модальном режиме", "Резултат работы формы редактирования", "")
        's = s & vbCrLf & "    Public Overrides Function ShowForm(ByVal Mode As String, ByRef DocItem As LATIR.Document.Doc_Base, optional byval FormReadOnly as boolean = false) As Boolean"
        's = s & vbCrLf & "        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then"
        's = s & vbCrLf & "            If mode = """" Then"
        's = s & vbCrLf & "                Dim f As frm" & ot.Name
        's = s & vbCrLf & "                f = New frm" & ot.Name
        's = s & vbCrLf & "                f.Attach(DocItem, Me.GUIManager, FormReadOnly)"
        's = s & vbCrLf & "                ShowForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)"
        's = s & vbCrLf & "                f = Nothing"
        's = s & vbCrLf & "            End If"
        's = s & vbCrLf & "        End If"

        'For i = 1 To ot.OBJECTMODE.Count
        '    mode = ot.OBJECTMODE.Item(i).Name
        '    s = s & vbCrLf & "        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then"
        '    s = s & vbCrLf & "            If mode = """ & mode & """ Then"
        '    s = s & vbCrLf & "                Dim f" & mode & " As frm" & ot.Name & mode
        '    s = s & vbCrLf & "                f" & mode & " = New frm" & ot.Name & mode
        '    s = s & vbCrLf & "                f" & mode & ".Attach(DocItem, Me.GUIManager,FormReadOnly)"
        '    s = s & vbCrLf & "                ShowForm = (f" & mode & ".ShowDialog() = System.Windows.Forms.DialogResult.OK)"
        '    s = s & vbCrLf & "                f" & mode & " = Nothing"
        '    s = s & vbCrLf & "            End If"
        '    s = s & vbCrLf & "        End If"
        'Next

        's = s & vbCrLf & "    End Function"
        's = s & vbCrLf & MakeComment("Получить контрол, реализующий работу в заданном режиме")
        's = s & vbCrLf & "    Public Overrides Function GetObjectControl(ByVal Mode As String, ByVal TypeName As String) As Object"
        's = s & vbCrLf & "      Return New Tabview"
        's = s & vbCrLf & "    End Function"

        's = s & vbCrLf & ""
        's = s & vbCrLf & "    Public Overrides Sub Dispose()"
        's = s & vbCrLf & "        ' do nothing"
        's = s & vbCrLf & "    End Sub"
        's = s & vbCrLf & ""
        's = s & vbCrLf & ""
        's = s & vbCrLf & ""
        's = s & vbCrLf & ""
        's = s & vbCrLf & "End Class"

        'SetExt(o, "GUI", "vb")

        'o.Block = "code"
        'o.OutNL(s)


        'For i = 1 To ot.OBJECTMODE.Count
        '    MakeTabView(tid, m, ot, o, ot.OBJECTMODE.Item(i).Name)
        '    MakeMainForm(tid, m, ot, o, ot.OBJECTMODE.Item(i).Name)
        'Next
        'MakeTabView(tid, m, ot, o, "")
        MakeMainForm(tid, m, ot, o, "")


    End Sub

    Private Sub MakeTabView(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef o As LATIRGenerator.Response, ByVal mode As String)
        Dim s As String = String.Empty
        Dim i As Short
        s = s & vbCrLf & MakeComment("Компонент, реализующий редактирование всего документа")

        s = s & vbCrLf & "Imports System.Windows.Forms"
        s = s & vbCrLf & "Imports Microsoft.VisualBasic"
        s = s & vbCrLf & "Public Class Tabview" & mode
        s = s & vbCrLf & "    Inherits System.Windows.Forms.UserControl"
        s = s & vbCrLf & "    Implements LATIRGUIControls.IViewPanel"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "#Region "" Windows Form Designer generated code """
        s = s & vbCrLf & "    Public Sub New()"
        s = s & vbCrLf & "        MyBase.New()"
        s = s & vbCrLf & "        'This call is required by the Windows Form Designer."
        s = s & vbCrLf & "        InitializeComponent()"
        s = s & vbCrLf & "        'Add any initialization after the InitializeComponent() call"
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
        s = s & vbCrLf & "    Friend WithEvents tab As System.Windows.Forms.TabControl"

        ot.PART.Sort = "sequence"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "    Friend WithEvents TabPage" & i & " As System.Windows.Forms.TabPage"
                's = s & vbCrLf & "    Friend WithEvents View" & ot.PART.Item(i).Name & " As " & ot.Name & "GUI.view" & ot.PART.Item(i).Name
                s = s & vbCrLf & "    Friend WithEvents View" & ot.PART.Item(i).Name & " As view" & ot.PART.Item(i).Name & mode
            End If
        Next
        s = s & vbCrLf & "   "
        s = s & vbCrLf & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
        s = s & vbCrLf & "        Me.tab = New System.Windows.Forms.TabControl"

        ot.PART.Sort = "sequence"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "   TabPage" & i & " = new System.Windows.Forms.TabPage"
                's = s & vbCrLf & "    View" & ot.PART.Item(i).Name & " = new " & ot.Name & "GUI.view" & ot.PART.Item(i).Name
                s = s & vbCrLf & "    View" & ot.PART.Item(i).Name & " = new view" & ot.PART.Item(i).Name & mode
            End If
        Next

        s = s & vbCrLf & "        Me.tab.SuspendLayout()"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "   Me.TabPage" & i & ".SuspendLayout()"
            End If
        Next


        s = s & vbCrLf & "        Me.SuspendLayout()"
        s = s & vbCrLf & "        '"
        s = s & vbCrLf & "        'tab"
        s = s & vbCrLf & "        '"
        s = s & vbCrLf & "        Me.tab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _"
        s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Left) _"
        s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)"

        ot.PART.Sort = "sequence"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "   Me.tab.Controls.Add (Me.TabPage" & i & ")"
            End If
        Next

        s = s & vbCrLf & "        Me.tab.Location = New System.Drawing.Point(0, 0)"
        s = s & vbCrLf & "        Me.tab.name = ""tab"""
        s = s & vbCrLf & "        Me.tab.SelectedIndex = 0"
        s = s & vbCrLf & "        Me.tab.Size = New System.Drawing.Size(528, 392)"
        s = s & vbCrLf & "        Me.tab.TabIndex = 0"

        ot.PART.Sort = "sequence"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        'TabPage" & i
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        Me.TabPage" & i & ".Controls.Add (Me.View" & ot.PART.Item(i).Name & ")"
                s = s & vbCrLf & "        Me.TabPage" & i & ".Location = New System.Drawing.Point(4, 22)"
                s = s & vbCrLf & "        Me.TabPage" & i & ".name = ""TabPage" & i & """"
                s = s & vbCrLf & "        Me.TabPage" & i & ".Size = New System.Drawing.Size(520, 366)"
                s = s & vbCrLf & "        Me.TabPage" & i & ".TabIndex = 0"
                s = s & vbCrLf & "        Me.TabPage" & i & ".Text = """ & ot.PART.Item(i).Caption & """"
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        'View" & ot.PART.Item(i).Name & ""
                s = s & vbCrLf & "        '"
                s = s & vbCrLf & "        Me.View" & ot.PART.Item(i).Name & ".Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _"
                s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Left) _"
                s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)"
                s = s & vbCrLf & "        Me.View" & ot.PART.Item(i).Name & ".Location = New System.Drawing.Point(8, 8)"
                s = s & vbCrLf & "        Me.View" & ot.PART.Item(i).Name & ".name = ""View" & ot.PART.Item(i).Name & """"
                s = s & vbCrLf & "        Me.View" & ot.PART.Item(i).Name & ".Size = New System.Drawing.Size(504, 352)"
                s = s & vbCrLf & "        Me.View" & ot.PART.Item(i).Name & ".TabIndex = 0"
            End If
        Next
        s = s & vbCrLf & "        '"
        s = s & vbCrLf & "        'Tabview"
        s = s & vbCrLf & "        '"
        s = s & vbCrLf & "        Me.Controls.Add (Me.tab)"
        s = s & vbCrLf & "        Me.name = ""TabView"""
        s = s & vbCrLf & "        Me.Size = New System.Drawing.Size(528, 392)"
        s = s & vbCrLf & "        Me.tab.ResumeLayout (False)"

        ot.PART.Sort = "sequence"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "   Me.TabPage" & i & ".ResumeLayout (False)"
            End If
        Next

        s = s & vbCrLf & "        Me.ResumeLayout (False)"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "    End Sub"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "#End Region"
        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Редактируемый объект")
        ' s = s & vbCrLf & "    Public item As " & ot.Name & "." & ot.Name & ".Application"
        s = s & vbCrLf & "    Public item As " & ot.Name & ".Application"
        s = s & vbCrLf & "    Private mReadOnly as boolean"
        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Объект управления визуальными компонентами")
        s = s & vbCrLf & "    Public GuiManager As LATIRGuiManager.LATIRGuiManager"
        s = s & vbCrLf & ""

        s = s & vbCrLf & MakeComment("Инициализация контрольного элемента")
        s = s & vbCrLf & "    Public Sub Attach(ByVal docItem As LATIR.Document.Doc_Base, ByVal gm As LATIRGuiManager.LATIRGuiManager, byval DocReadOnly as boolean  ) Implements LATIRGUIControls.IViewPanel.Attach"
        's = s & vbCrLf & "        item = CType(docItem, " & ot.Name & "." & ot.Name & ".Application)"
        s = s & vbCrLf & "        item = CType(docItem, " & ot.Name & ".Application)"
        s = s & vbCrLf & "        mReadOnly =DocReadOnly"

        s = s & vbCrLf & "        GuiManager = gm"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "        View" & ot.PART.Item(i).Name & ".Attach(item, GuiManager,DocReadOnly)"
            End If
        Next
        s = s & vbCrLf & "    End Sub"



        s = s & vbCrLf & MakeComment("Сохранение всех изменений")
        s = s & vbCrLf & "    Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIRGUIControls.IViewPanel.Save"
        s = s & vbCrLf & "    Dim ok As Boolean"
        s = s & vbCrLf & "    ok = True"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "        ok = ok And View" & ot.PART.Item(i).Name & ".Save(Sielent, NoError)"
            End If
        Next
        s = s & vbCrLf & "       Return ok"
        s = s & vbCrLf & "    End function"

        s = s & vbCrLf & MakeComment("Корректны ли измененные данные проверка после Verify")
        s = s & vbCrLf & "    Public Function IsOK() As Boolean Implements LATIRGUIControls.IViewPanel.IsOK"
        s = s & vbCrLf & "    Dim ok As Boolean"
        s = s & vbCrLf & "    ok = True"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "        ok = ok And View" & ot.PART.Item(i).Name & ".IsOK()"
            End If
        Next
        s = s & vbCrLf & "       Return ok"
        s = s & vbCrLf & "    End function"


        s = s & vbCrLf & MakeComment("Были ли изменения данных")
        s = s & vbCrLf & "    Public Function IsChanged() As Boolean Implements LATIRGUIControls.IViewPanel.IsChanged"
        s = s & vbCrLf & "    Dim ok As Boolean"
        s = s & vbCrLf & "    if mReadOnly then return false"

        s = s & vbCrLf & "    ok = False"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "        ok = ok or View" & ot.PART.Item(i).Name & ".IsChanged()"
            End If
        Next
        s = s & vbCrLf & "       Return ok"
        s = s & vbCrLf & "    End function"

        s = s & vbCrLf & MakeComment("Проверить корректность данных")
        s = s & vbCrLf & "    Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIRGUIControls.IViewPanel.Verify"
        s = s & vbCrLf & "    Dim ok As Boolean"
        s = s & vbCrLf & "    if mReadOnly then return true"
        s = s & vbCrLf & "    ok = True"
        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "        ok = ok And View" & ot.PART.Item(i).Name & ".Verify(NoError)"
            End If
        Next
        s = s & vbCrLf & "       Return ok"
        s = s & vbCrLf & "    End function"


        For i = 1 To ot.PART.Count
            If LATIRFramework.ObjectHelper.IsPresent(ot.PART.Item(i), mode) Then
                s = s & vbCrLf & "    Private Sub TabPage" + i.ToString() + "_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage" + i.ToString() + ".Leave"
                s = s & vbCrLf & "        If View" & ot.PART.Item(i).Name & ".IsChanged() Then"
                s = s & vbCrLf & "            If MsgBox(""Сохранить изменения на вкладке <"" + TabPage" + i.ToString() + ".Text + ""> ?"", MsgBoxStyle.YesNo, ""Изменения"") = MsgBoxResult.Yes Then"
                s = s & vbCrLf & "                View" & ot.PART.Item(i).Name & ".Save(True, False)"
                s = s & vbCrLf & "            End If"
                s = s & vbCrLf & "        End If"
                s = s & vbCrLf & "    End Sub"
            End If
        Next

        

        s = s & vbCrLf & "End Class"
        SetExt(o, "TabView" & mode, "vb")

        o.Block = "code"
        o.OutNL(s)

    End Sub


    Private Sub MakeMainForm(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZwp.MTZwp.Application, ByRef o As LATIRGenerator.Response, ByVal mode As String)

        Dim s As String = String.Empty
        s = s & vbCrLf & "  Imports System.Windows.Forms"
        s = s & vbCrLf & "  Imports Microsoft.VisualBasic"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "  Public Class frmMain"
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
        ' s = s & vbCrLf & "    Friend WithEvents tv As " & ot.Name & "GUI.Tabview"
        s = s & vbCrLf & "    Friend WithEvents tv As Tabview" & mode
        s = s & vbCrLf & "    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()"
        's = s & vbCrLf & "        Me.tv = New " & ot.Name & "GUI.TabView"
        s = s & vbCrLf & "        Me.tv = New TabView" & mode
        s = s & vbCrLf & "        Me.SuspendLayout()"
        s = s & vbCrLf & "        '"
        s = s & vbCrLf & "        'tv"
        s = s & vbCrLf & "        '"
        s = s & vbCrLf & "        Me.tv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _"
        s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Left) _"
        s = s & vbCrLf & "                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)"
        s = s & vbCrLf & "        Me.tv.Location = New System.Drawing.Point(8, 8)"
        s = s & vbCrLf & "        Me.tv.name = ""tv"""
        s = s & vbCrLf & "        Me.tv.Size = New System.Drawing.Size(600, 344)"
        s = s & vbCrLf & "        Me.tv.TabIndex = 0"
        s = s & vbCrLf & "        '"
        s = s & vbCrLf & "        'frm" & ot.Name & ""
        s = s & vbCrLf & "        '"
        s = s & vbCrLf & "        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)"
        s = s & vbCrLf & "        Me.ClientSize = New System.Drawing.Size(608, 357)"
        s = s & vbCrLf & "        Me.Controls.Add (Me.tv)"
        s = s & vbCrLf & "        Me.name = ""frm" & ot.Name & """"
        s = s & vbCrLf & "        Me.ResumeLayout (False)"
        s = s & vbCrLf & "    End Sub"
        s = s & vbCrLf & "#End Region"
        's = s & vbCrLf & "    Public item As " & ot.Name & "." & ot.Name & ".Application"
        s = s & vbCrLf & "    Public item As " & ot.Name & ".Application"
        s = s & vbCrLf & "    Public GuiManager As LATIRGuiManager.LATIRGuiManager"
        s = s & vbCrLf & MakeComment("Инициализация", "Процедура инициализации формы", "", "")
        s = s & vbCrLf & "    Public Sub Attach(ByVal docItem As LATIR.Document.Doc_Base, ByVal gm As LATIRGuiManager.LATIRGuiManager, optional byval FormReadOnly as boolean =false)"
        's = s & vbCrLf & "        item = CType(docItem, " & ot.Name & "." & ot.Name & ".Application)"
        s = s & vbCrLf & "        item = CType(docItem, " & ot.Name & ".Application)"
        s = s & vbCrLf & "        GuiManager = gm"
        s = s & vbCrLf & "        tv.Attach(item, GuiManager,FormReadOnly)"
        s = s & vbCrLf & "        Me.Text = item.name"
        s = s & vbCrLf & "    End Sub"



        s = s & vbCrLf & "    Private Sub frmChild_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing"
        s = s & vbCrLf & "        If e.CloseReason = CloseReason.FormOwnerClosing Then"
        s = s & vbCrLf & "            e.Cancel = Not CheckAndSave(False)"
        s = s & vbCrLf & "        End If"

        s = s & vbCrLf & "        If e.CloseReason = CloseReason.ApplicationExitCall Then"
        s = s & vbCrLf & "            e.Cancel = Not CheckAndSave(False)"
        s = s & vbCrLf & "        End If"

        s = s & vbCrLf & "        If e.CloseReason = CloseReason.MdiFormClosing Then"
        s = s & vbCrLf & "            e.Cancel = Not CheckAndSave(False)"
        s = s & vbCrLf & "        End If"

        s = s & vbCrLf & "        If e.CloseReason = CloseReason.TaskManagerClosing Then"
        s = s & vbCrLf & "            CheckAndSave(True)"
        s = s & vbCrLf & "        End If"

        s = s & vbCrLf & "        If e.CloseReason = CloseReason.WindowsShutDown Then"
        s = s & vbCrLf & "            CheckAndSave(True)"
        s = s & vbCrLf & "        End If"

        s = s & vbCrLf & "        If e.CloseReason = CloseReason.UserClosing Then"
        s = s & vbCrLf & "            e.Cancel = Not CheckAndSave(False)"
        s = s & vbCrLf & "        End If"

        s = s & vbCrLf & "        If e.CloseReason = CloseReason.None Then"
        s = s & vbCrLf & "            e.Cancel = Not CheckAndSave(False)"
        s = s & vbCrLf & "        End If"

        s = s & vbCrLf & "    End Sub"

        s = s & vbCrLf & "    Private function CheckAndSave(byval sielent as boolean) as boolean"

        s = s & vbCrLf & "    Dim iv As LATIRGUIControls.IViewPanel"
        s = s & vbCrLf & "    iv = CType(tv, LATIRGUIControls.IViewPanel)"
        s = s & vbCrLf & "    If iv.IsChanged() Then"
        s = s & vbCrLf & "        If Not sielent Then"
        s = s & vbCrLf & "            If MsgBox(""Данные изменены. Сохранить изменения?"", MsgBoxStyle.Question + MsgBoxStyle.YesNo, ""Закрытие документа"") = MsgBoxResult.Yes Then"
        s = s & vbCrLf & "                If iv.Verify(True) Then"
        s = s & vbCrLf & "                    Return iv.Save(True, False)"
        s = s & vbCrLf & "                Else"
        s = s & vbCrLf & "                    Return False"
        s = s & vbCrLf & "                End If"
        s = s & vbCrLf & "            End If"
        s = s & vbCrLf & "        Else"

        s = s & vbCrLf & "            If iv.Verify(True) Then"
        s = s & vbCrLf & "                Return iv.Save(True, True)"
        s = s & vbCrLf & "            End If"
        s = s & vbCrLf & "            Return False"
        s = s & vbCrLf & "        End If"
        s = s & vbCrLf & "    End If"
        s = s & vbCrLf & "    Return True"

        s = s & vbCrLf & "    End function"





        s = s & vbCrLf & "End Class"


        SetExt(o, "frm" & ot.Name & mode, "vb")

        o.Block = "code"
        o.OutNL(s)

    End Sub
End Module