
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class ViewGENPACKAGE
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IViewPanel
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents cv As LATIR2GUIControls.ComplexTreeView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cv = New LATIR2GUIControls.ComplexTreeView
        Me.SuspendLayout()
        '
        'cv
        '
        Me.cv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cv.Location = New System.Drawing.Point(0, 0)
        Me.cv.Name = "cv"
        Me.cv.Size = New System.Drawing.Size(520, 328)
        Me.cv.TabIndex = 0
        '
        'ViewGENPACKAGE
        '
        Me.Controls.Add(Me.cv)
        Me.Name = "ViewGENPACKAGE"
        Me.Size = New System.Drawing.Size(520, 328)
        Me.ResumeLayout(False)
    End Sub
#End Region
    Public item As MTZMetaModel.MTZMetaModel.Application
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager
    Private mReadOnly as boolean
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager ,byval ReadOnlyView as boolean)  Implements LATIR2GUIManager.IViewPanel.Attach
        mReadOnly = ReadOnlyView
        item = CType(docItem, MTZMetaModel.MTZMetaModel.Application)
        GuiManager = gm
        cv.Attach(gm, "GENPACKAGE","","","")
    End Sub
    Private Sub cv_GetLevelData(ByVal Parent As System.Guid, ByVal PartName As String, ByVal ChildPartName As String) Handles cv.OnTreeGetLevelData
        Dim dt As DataTable
        Dim fl As Object
        If Parent.Equals(System.Guid.Empty) Then
            dt = item.GENPACKAGE.GetDataTable
            dt.TableName = "GENPACKAGE"
            cv.TreeLoadData(Parent, "GENPACKAGE", "Brief", dt)
        Else
            fl = item.FindRowObject(PartName, Parent)

        If PartName.ToUpper() = "MTZAPP" Then
                If ChildPartName.ToUpper() = "PARENTPACKAGE" Then
                    dt = fl.ParentPackage.GetDataTable
                    dt.TableName = "ParentPackage"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "PARENTPACKAGE" Then
        End If

        If PartName.ToUpper() = "OBJECTTYPE" Then
                If ChildPartName.ToUpper() = "PART" Then
                    dt = fl.PART.GetDataTable
                    dt.TableName = "PART"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "TYPEMENU" Then
                    dt = fl.TYPEMENU.GetDataTable
                    dt.TableName = "TYPEMENU"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "INSTANCEVALIDATOR" Then
                    dt = fl.INSTANCEVALIDATOR.GetDataTable
                    dt.TableName = "INSTANCEVALIDATOR"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "OBJECTMODE" Then
                    dt = fl.OBJECTMODE.GetDataTable
                    dt.TableName = "OBJECTMODE"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "OBJSTATUS" Then
                    dt = fl.OBJSTATUS.GetDataTable
                    dt.TableName = "OBJSTATUS"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "PART" Then
                If ChildPartName.ToUpper() = "PART" Then
                    dt = fl.PART.GetDataTable
                    dt.TableName = "PART"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "FIELD" Then
                    dt = fl.FIELD.GetDataTable
                    dt.TableName = "FIELD"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "PARTMENU" Then
                    dt = fl.PARTMENU.GetDataTable
                    dt.TableName = "PARTMENU"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "UNIQUECONSTRAINT" Then
                    dt = fl.UNIQUECONSTRAINT.GetDataTable
                    dt.TableName = "UNIQUECONSTRAINT"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "VALIDATOR" Then
                    dt = fl.VALIDATOR.GetDataTable
                    dt.TableName = "VALIDATOR"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "PARTVIEW" Then
                    dt = fl.PARTVIEW.GetDataTable
                    dt.TableName = "PARTVIEW"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "EXTENDERINTERFACE" Then
                    dt = fl.ExtenderInterface.GetDataTable
                    dt.TableName = "ExtenderInterface"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "FIELD" Then
                If ChildPartName.ToUpper() = "FIELDMENU" Then
                    dt = fl.FIELDMENU.GetDataTable
                    dt.TableName = "FIELDMENU"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "DINAMICFILTERSCRIPT" Then
                    dt = fl.DINAMICFILTERSCRIPT.GetDataTable
                    dt.TableName = "DINAMICFILTERSCRIPT"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "FIELDVALIDATOR" Then
                    dt = fl.FIELDVALIDATOR.GetDataTable
                    dt.TableName = "FIELDVALIDATOR"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "FIELDEXPRESSION" Then
                    dt = fl.FIELDEXPRESSION.GetDataTable
                    dt.TableName = "FIELDEXPRESSION"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "FIELDSRCDEF" Then
                    dt = fl.FIELDSRCDEF.GetDataTable
                    dt.TableName = "FIELDSRCDEF"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "FLDEXTENDERS" Then
                    dt = fl.FldExtenders.GetDataTable
                    dt.TableName = "FldExtenders"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "FIELDMENU" Then
                If ChildPartName.ToUpper() = "FIELDPARAMMAP" Then
                    dt = fl.FIELDPARAMMAP.GetDataTable
                    dt.TableName = "FIELDPARAMMAP"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "FIELDPARAMMAP" Then
        End If

        If PartName.ToUpper() = "DINAMICFILTERSCRIPT" Then
        End If

        If PartName.ToUpper() = "FIELDVALIDATOR" Then
        End If

        If PartName.ToUpper() = "FIELDEXPRESSION" Then
        End If

        If PartName.ToUpper() = "FIELDSRCDEF" Then
        End If

        If PartName.ToUpper() = "FLDEXTENDERS" Then
        End If

        If PartName.ToUpper() = "PARTMENU" Then
                If ChildPartName.ToUpper() = "PARTPARAMMAP" Then
                    dt = fl.PARTPARAMMAP.GetDataTable
                    dt.TableName = "PARTPARAMMAP"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "PARTPARAMMAP" Then
        End If

        If PartName.ToUpper() = "UNIQUECONSTRAINT" Then
                If ChildPartName.ToUpper() = "CONSTRAINTFIELD" Then
                    dt = fl.CONSTRAINTFIELD.GetDataTable
                    dt.TableName = "CONSTRAINTFIELD"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "CONSTRAINTFIELD" Then
        End If

        If PartName.ToUpper() = "VALIDATOR" Then
        End If

        If PartName.ToUpper() = "PARTVIEW" Then
                If ChildPartName.ToUpper() = "VIEWCOLUMN" Then
                    dt = fl.ViewColumn.GetDataTable
                    dt.TableName = "ViewColumn"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "PARTVIEW_LNK" Then
                    dt = fl.PARTVIEW_LNK.GetDataTable
                    dt.TableName = "PARTVIEW_LNK"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "VIEWCOLUMN" Then
        End If

        If PartName.ToUpper() = "PARTVIEW_LNK" Then
        End If

        If PartName.ToUpper() = "EXTENDERINTERFACE" Then
        End If

        If PartName.ToUpper() = "TYPEMENU" Then
        End If

        If PartName.ToUpper() = "INSTANCEVALIDATOR" Then
        End If

        If PartName.ToUpper() = "OBJECTMODE" Then
                If ChildPartName.ToUpper() = "STRUCTRESTRICTION" Then
                    dt = fl.STRUCTRESTRICTION.GetDataTable
                    dt.TableName = "STRUCTRESTRICTION"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "FIELDRESTRICTION" Then
                    dt = fl.FIELDRESTRICTION.GetDataTable
                    dt.TableName = "FIELDRESTRICTION"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "METHODRESTRICTION" Then
                    dt = fl.METHODRESTRICTION.GetDataTable
                    dt.TableName = "METHODRESTRICTION"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "STRUCTRESTRICTION" Then
        End If

        If PartName.ToUpper() = "FIELDRESTRICTION" Then
        End If

        If PartName.ToUpper() = "METHODRESTRICTION" Then
        End If

        If PartName.ToUpper() = "OBJSTATUS" Then
                If ChildPartName.ToUpper() = "NEXTSTATE" Then
                    dt = fl.NEXTSTATE.GetDataTable
                    dt.TableName = "NEXTSTATE"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "NEXTSTATE" Then
        End If

        If PartName.ToUpper() = "FIELDTYPE" Then
                If ChildPartName.ToUpper() = "FIELDTYPEMAP" Then
                    dt = fl.FIELDTYPEMAP.GetDataTable
                    dt.TableName = "FIELDTYPEMAP"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "ENUMITEM" Then
                    dt = fl.ENUMITEM.GetDataTable
                    dt.TableName = "ENUMITEM"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "FIELDTYPEMAP" Then
        End If

        If PartName.ToUpper() = "ENUMITEM" Then
        End If

        If PartName.ToUpper() = "SHAREDMETHOD" Then
                If ChildPartName.ToUpper() = "SCRIPT" Then
                    dt = fl.SCRIPT.GetDataTable
                    dt.TableName = "SCRIPT"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "SCRIPT" Then
                If ChildPartName.ToUpper() = "PARAMETERS" Then
                    dt = fl.PARAMETERS.GetDataTable
                    dt.TableName = "PARAMETERS"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "PARAMETERS" Then
        End If

        If PartName.ToUpper() = "GENPACKAGE" Then
                If ChildPartName.ToUpper() = "GENERATOR_TARGET" Then
                    dt = fl.GENERATOR_TARGET.GetDataTable
                    dt.TableName = "GENERATOR_TARGET"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "GENERATOR_TARGET" Then
                If ChildPartName.ToUpper() = "GENREFERENCE" Then
                    dt = fl.GENREFERENCE.GetDataTable
                    dt.TableName = "GENREFERENCE"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "GENCONTROLS" Then
                    dt = fl.GENCONTROLS.GetDataTable
                    dt.TableName = "GENCONTROLS"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
                If ChildPartName.ToUpper() = "GENMANUALCODE" Then
                    dt = fl.GENMANUALCODE.GetDataTable
                    dt.TableName = "GENMANUALCODE"
                    cv.TreeLoadData(Parent, ChildPartName, "Brief", dt)
                End If
        End If

        If PartName.ToUpper() = "GENREFERENCE" Then
        End If

        If PartName.ToUpper() = "GENCONTROLS" Then
        End If

        If PartName.ToUpper() = "GENMANUALCODE" Then
        End If

        If PartName.ToUpper() = "LOCALIZEINFO" Then
        End If

        End If
    End Sub
    Private Sub cv_GetItemParts(ByVal Parent As System.Guid, ByVal PartName As String) Handles cv.OnTreeGetItemParts
        Dim dt As DataTable
        Dim dr As DataRow
        dt = New DataTable
        dt.Columns.Add("name", GetType(System.String))
        dt.Columns.Add("Caption", GetType(System.String))
        On Error Resume Next

        If PartName.ToUpper() = "MTZAPP" Then
            dr = dt.NewRow
            dr("name") = "ParentPackage"
            dr("Caption") = "Обязательные приложения"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "PARENTPACKAGE" Then
        End If

        If PartName.ToUpper() = "OBJECTTYPE" Then
            dr = dt.NewRow
            dr("name") = "PART"
            dr("Caption") = "Раздел"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "TYPEMENU"
            dr("Caption") = "Методы типа"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "INSTANCEVALIDATOR"
            dr("Caption") = "Проверка правильности"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "OBJECTMODE"
            dr("Caption") = "Режим работы"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "OBJSTATUS"
            dr("Caption") = "Состояния"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "PART" Then
            dr = dt.NewRow
            dr("name") = "PART"
            dr("Caption") = "Раздел"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "FIELD"
            dr("Caption") = "Поле"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "PARTMENU"
            dr("Caption") = "Методы раздела"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "UNIQUECONSTRAINT"
            dr("Caption") = "Ограничение уникальности"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "VALIDATOR"
            dr("Caption") = "Логика на форме"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "PARTVIEW"
            dr("Caption") = "Представление"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "ExtenderInterface"
            dr("Caption") = "Интерфейсы расширения"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "FIELD" Then
            dr = dt.NewRow
            dr("name") = "FIELDMENU"
            dr("Caption") = "Методы поля"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "DINAMICFILTERSCRIPT"
            dr("Caption") = "Динамический фильтр"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "FIELDVALIDATOR"
            dr("Caption") = "Логика поля на форме"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "FIELDEXPRESSION"
            dr("Caption") = "Значение по умолчанию"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "FIELDSRCDEF"
            dr("Caption") = "Описание источника данных"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "FldExtenders"
            dr("Caption") = "Интерфейсы расширения"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "FIELDMENU" Then
            dr = dt.NewRow
            dr("name") = "FIELDPARAMMAP"
            dr("Caption") = "Отображение параметров"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "FIELDPARAMMAP" Then
        End If

        If PartName.ToUpper() = "DINAMICFILTERSCRIPT" Then
        End If

        If PartName.ToUpper() = "FIELDVALIDATOR" Then
        End If

        If PartName.ToUpper() = "FIELDEXPRESSION" Then
        End If

        If PartName.ToUpper() = "FIELDSRCDEF" Then
        End If

        If PartName.ToUpper() = "FLDEXTENDERS" Then
        End If

        If PartName.ToUpper() = "PARTMENU" Then
            dr = dt.NewRow
            dr("name") = "PARTPARAMMAP"
            dr("Caption") = "Отображение параметров"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "PARTPARAMMAP" Then
        End If

        If PartName.ToUpper() = "UNIQUECONSTRAINT" Then
            dr = dt.NewRow
            dr("name") = "CONSTRAINTFIELD"
            dr("Caption") = "Поля ограничения"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "CONSTRAINTFIELD" Then
        End If

        If PartName.ToUpper() = "VALIDATOR" Then
        End If

        If PartName.ToUpper() = "PARTVIEW" Then
            dr = dt.NewRow
            dr("name") = "ViewColumn"
            dr("Caption") = "Колонка"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "PARTVIEW_LNK"
            dr("Caption") = "Связанные представления"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "VIEWCOLUMN" Then
        End If

        If PartName.ToUpper() = "PARTVIEW_LNK" Then
        End If

        If PartName.ToUpper() = "EXTENDERINTERFACE" Then
        End If

        If PartName.ToUpper() = "TYPEMENU" Then
        End If

        If PartName.ToUpper() = "INSTANCEVALIDATOR" Then
        End If

        If PartName.ToUpper() = "OBJECTMODE" Then
            dr = dt.NewRow
            dr("name") = "STRUCTRESTRICTION"
            dr("Caption") = "Органичения разделов"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "FIELDRESTRICTION"
            dr("Caption") = "Ограничения полей"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "METHODRESTRICTION"
            dr("Caption") = "Ограничения методов"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "STRUCTRESTRICTION" Then
        End If

        If PartName.ToUpper() = "FIELDRESTRICTION" Then
        End If

        If PartName.ToUpper() = "METHODRESTRICTION" Then
        End If

        If PartName.ToUpper() = "OBJSTATUS" Then
            dr = dt.NewRow
            dr("name") = "NEXTSTATE"
            dr("Caption") = "Разрешенные переходы"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "NEXTSTATE" Then
        End If

        If PartName.ToUpper() = "FIELDTYPE" Then
            dr = dt.NewRow
            dr("name") = "FIELDTYPEMAP"
            dr("Caption") = "Отображение"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "ENUMITEM"
            dr("Caption") = "Зачения"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "FIELDTYPEMAP" Then
        End If

        If PartName.ToUpper() = "ENUMITEM" Then
        End If

        If PartName.ToUpper() = "SHAREDMETHOD" Then
            dr = dt.NewRow
            dr("name") = "SCRIPT"
            dr("Caption") = "Реализация"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "SCRIPT" Then
            dr = dt.NewRow
            dr("name") = "PARAMETERS"
            dr("Caption") = "Параметры"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "PARAMETERS" Then
        End If

        If PartName.ToUpper() = "GENPACKAGE" Then
            dr = dt.NewRow
            dr("name") = "GENERATOR_TARGET"
            dr("Caption") = "Генераторы"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "GENERATOR_TARGET" Then
            dr = dt.NewRow
            dr("name") = "GENREFERENCE"
            dr("Caption") = "Библиотеки"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "GENCONTROLS"
            dr("Caption") = "Контрольные элементы"
            dt.Rows.Add(dr)
            dr = dt.NewRow
            dr("name") = "GENMANUALCODE"
            dr("Caption") = "Ручной код"
            dt.Rows.Add(dr)
        End If

        If PartName.ToUpper() = "GENREFERENCE" Then
        End If

        If PartName.ToUpper() = "GENCONTROLS" Then
        End If

        If PartName.ToUpper() = "GENMANUALCODE" Then
        End If

        If PartName.ToUpper() = "LOCALIZEINFO" Then
        End If

        cv.LoadItemParts(Parent, dt)
    End Sub
    Private Sub cv_OnDel(ByRef OK As Boolean, ByVal ID As System.Guid, ByVal PartName As String) Handles cv.OnTreeDel
      if not mReadOnly then
        Dim ed As LATIR2.Document.DocRow_Base
        Dim edCol As LATIR2.Document.DocCollection_Base
        Dim pr As Object
        ed = item.FindRowObject(PartName, ID)
        if ed is nothing then exit sub
        edCol=ed.parent
        pr=ed.parent.parent
        If MsgBox("Удалить <" & ed.Brief & "> ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Удаление строки") = MsgBoxResult.Yes Then
            OK = ed.Parent.Delete(ID.ToString)
            If OK Then
              If TypeOf (pr) Is LATIR2.Document.DocRow_Base Then
                 cv.TreeLoadData(pr.ID, PartName, "Brief", edcol.GetDataTable)
              End If
              If TypeOf (pr) Is LATIR2.Document.Doc_Base Then
                 cv.TreeLoadData(System.Guid.Empty, PartName, "Brief", edcol.GetDataTable)
              End If
            End If
        End If
      End If
    End Sub
    Private Sub cv_OnAddRoot(ByRef OK As Boolean) Handles cv.OnTreeAddRoot
      if not mReadOnly then
        Dim ed As Object
        ed = item.GENPACKAGE.Add
        Dim gui As LATIR2GuiManager.Doc_GUIBase
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType(ed, LATIR2.Document.DocRow_Base ) ) = True Then
            cv.RefreshData()
        Else
            item.GENPACKAGE.Refresh()
        End If
      End If
    End Sub
    Private Sub cv_OnAddBy(ByRef OK As Boolean, ByVal ParentID As System.Guid, ByVal ParentPartName As String, ByVal RowPartName As String) Handles cv.OnTreeAdd
      if not mReadOnly then
        Dim ed As Object
        Dim fs As Object
        Dim sc As Object
        Dim gui As LATIR2GuiManager.Doc_GUIBase
        Dim dt As DataTable
        fs = item.FindRowObject(ParentPartName, ParentID)

        If ParentPartName.ToUpper() = "MTZAPP" Then
        If RowPartName.ToUpper() = "PARENTPACKAGE" Then
            ed = fs.ParentPackage.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.ParentPackage.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "PARENTPACKAGE" Then
        End If

        If ParentPartName.ToUpper() = "OBJECTTYPE" Then
        If RowPartName.ToUpper() = "PART" Then
            ed = fs.PART.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.PART.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "TYPEMENU" Then
            ed = fs.TYPEMENU.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.TYPEMENU.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "INSTANCEVALIDATOR" Then
            ed = fs.INSTANCEVALIDATOR.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.INSTANCEVALIDATOR.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "OBJECTMODE" Then
            ed = fs.OBJECTMODE.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.OBJECTMODE.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "OBJSTATUS" Then
            ed = fs.OBJSTATUS.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.OBJSTATUS.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "PART" Then
        If RowPartName.ToUpper() = "PART" Then
            ed = fs.PART.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType(ed, LATIR2.Document.DocRow_Base)) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.PART.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "FIELD" Then
            ed = fs.FIELD.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.FIELD.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "PARTMENU" Then
            ed = fs.PARTMENU.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.PARTMENU.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "UNIQUECONSTRAINT" Then
            ed = fs.UNIQUECONSTRAINT.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.UNIQUECONSTRAINT.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "VALIDATOR" Then
            ed = fs.VALIDATOR.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.VALIDATOR.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "PARTVIEW" Then
            ed = fs.PARTVIEW.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.PARTVIEW.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "EXTENDERINTERFACE" Then
            ed = fs.ExtenderInterface.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.ExtenderInterface.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "FIELD" Then
        If RowPartName.ToUpper() = "FIELDMENU" Then
            ed = fs.FIELDMENU.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.FIELDMENU.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "DINAMICFILTERSCRIPT" Then
            ed = fs.DINAMICFILTERSCRIPT.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.DINAMICFILTERSCRIPT.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "FIELDVALIDATOR" Then
            ed = fs.FIELDVALIDATOR.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.FIELDVALIDATOR.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "FIELDEXPRESSION" Then
            ed = fs.FIELDEXPRESSION.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.FIELDEXPRESSION.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "FIELDSRCDEF" Then
            ed = fs.FIELDSRCDEF.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.FIELDSRCDEF.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "FLDEXTENDERS" Then
            ed = fs.FldExtenders.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.FldExtenders.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "FIELDMENU" Then
        If RowPartName.ToUpper() = "FIELDPARAMMAP" Then
            ed = fs.FIELDPARAMMAP.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.FIELDPARAMMAP.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "FIELDPARAMMAP" Then
        End If

        If ParentPartName.ToUpper() = "DINAMICFILTERSCRIPT" Then
        End If

        If ParentPartName.ToUpper() = "FIELDVALIDATOR" Then
        End If

        If ParentPartName.ToUpper() = "FIELDEXPRESSION" Then
        End If

        If ParentPartName.ToUpper() = "FIELDSRCDEF" Then
        End If

        If ParentPartName.ToUpper() = "FLDEXTENDERS" Then
        End If

        If ParentPartName.ToUpper() = "PARTMENU" Then
        If RowPartName.ToUpper() = "PARTPARAMMAP" Then
            ed = fs.PARTPARAMMAP.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.PARTPARAMMAP.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "PARTPARAMMAP" Then
        End If

        If ParentPartName.ToUpper() = "UNIQUECONSTRAINT" Then
        If RowPartName.ToUpper() = "CONSTRAINTFIELD" Then
            ed = fs.CONSTRAINTFIELD.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.CONSTRAINTFIELD.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "CONSTRAINTFIELD" Then
        End If

        If ParentPartName.ToUpper() = "VALIDATOR" Then
        End If

        If ParentPartName.ToUpper() = "PARTVIEW" Then
        If RowPartName.ToUpper() = "VIEWCOLUMN" Then
            ed = fs.ViewColumn.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.ViewColumn.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "PARTVIEW_LNK" Then
            ed = fs.PARTVIEW_LNK.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.PARTVIEW_LNK.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "VIEWCOLUMN" Then
        End If

        If ParentPartName.ToUpper() = "PARTVIEW_LNK" Then
        End If

        If ParentPartName.ToUpper() = "EXTENDERINTERFACE" Then
        End If

        If ParentPartName.ToUpper() = "TYPEMENU" Then
        End If

        If ParentPartName.ToUpper() = "INSTANCEVALIDATOR" Then
        End If

        If ParentPartName.ToUpper() = "OBJECTMODE" Then
        If RowPartName.ToUpper() = "STRUCTRESTRICTION" Then
            ed = fs.STRUCTRESTRICTION.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.STRUCTRESTRICTION.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "FIELDRESTRICTION" Then
            ed = fs.FIELDRESTRICTION.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.FIELDRESTRICTION.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "METHODRESTRICTION" Then
            ed = fs.METHODRESTRICTION.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.METHODRESTRICTION.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "STRUCTRESTRICTION" Then
        End If

        If ParentPartName.ToUpper() = "FIELDRESTRICTION" Then
        End If

        If ParentPartName.ToUpper() = "METHODRESTRICTION" Then
        End If

        If ParentPartName.ToUpper() = "OBJSTATUS" Then
        If RowPartName.ToUpper() = "NEXTSTATE" Then
            ed = fs.NEXTSTATE.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.NEXTSTATE.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "NEXTSTATE" Then
        End If

        If ParentPartName.ToUpper() = "FIELDTYPE" Then
        If RowPartName.ToUpper() = "FIELDTYPEMAP" Then
            ed = fs.FIELDTYPEMAP.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.FIELDTYPEMAP.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "ENUMITEM" Then
            ed = fs.ENUMITEM.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.ENUMITEM.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "FIELDTYPEMAP" Then
        End If

        If ParentPartName.ToUpper() = "ENUMITEM" Then
        End If

        If ParentPartName.ToUpper() = "SHAREDMETHOD" Then
        If RowPartName.ToUpper() = "SCRIPT" Then
            ed = fs.SCRIPT.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.SCRIPT.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "SCRIPT" Then
        If RowPartName.ToUpper() = "PARAMETERS" Then
            ed = fs.PARAMETERS.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.PARAMETERS.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "PARAMETERS" Then
        End If

        If ParentPartName.ToUpper() = "GENPACKAGE" Then
        If RowPartName.ToUpper() = "GENERATOR_TARGET" Then
            ed = fs.GENERATOR_TARGET.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.GENERATOR_TARGET.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "GENERATOR_TARGET" Then
        If RowPartName.ToUpper() = "GENREFERENCE" Then
            ed = fs.GENREFERENCE.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.GENREFERENCE.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "GENCONTROLS" Then
            ed = fs.GENCONTROLS.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.GENCONTROLS.Refresh()
            End If
        End If
        If RowPartName.ToUpper() = "GENMANUALCODE" Then
            ed = fs.GENMANUALCODE.Add()
            gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
            If gui.ShowPartEditForm("", CType( ed,LATIR2.Document.DocRow_Base )) = True Then
                cv.TreeLoadData(ParentID, ed.PartName, "Brief", ed.Parent.GetDataTable)
            Else
                fs.GENMANUALCODE.Refresh()
            End If
        End If
        End If

        If ParentPartName.ToUpper() = "GENREFERENCE" Then
        End If

        If ParentPartName.ToUpper() = "GENCONTROLS" Then
        End If

        If ParentPartName.ToUpper() = "GENMANUALCODE" Then
        End If

        If ParentPartName.ToUpper() = "LOCALIZEINFO" Then
        End If

      End If
    End Sub
    Private Sub cv_OnEdit(ByRef OK As Boolean, ByVal ID As System.Guid, ByVal PartName As String) Handles cv.OnTreeEdit
        Dim ed As LATIR2.Document.DocRow_Base
        Dim pr As LATIR2.Document.DocRow_Base
        ed = item.FindRowObject(PartName, ID)
        Dim gui As LATIR2GuiManager.Doc_GUIBase
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType(ed, LATIR2.Document.DocRow_Base ),mReadOnly ) = True Then
          If TypeOf (ed.Parent.Parent) Is LATIR2.Document.DocRow_Base Then
            pr = ed.Parent.Parent
            cv.TreeLoadData(pr.ID, ed.PartName, "Brief", ed.Parent.GetDataTable)
          End If
          If TypeOf (ed.Parent.Parent) Is LATIR2.Document.Doc_Base Then
            cv.TreeLoadData(System.Guid.Empty, ed.PartName, "Brief", ed.Parent.GetDataTable)
          End If
        End If
    End Sub
    Private Sub cv_OnGridSetup(ByVal PartName As String) Handles cv.OnGridSetup
        Dim ts As DataGridTableStyle
        Dim cs As DataGridTextBoxColumn

        If PartName.ToUpper() = "MTZAPP" Then
            ts = New DataGridTableStyle
            ts.MappingName = "MTZAPP"
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
            cs.HeaderText = "База данных"
            cs.MappingName = "DBName"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Описание"
            cs.MappingName = "TheComment"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "PARENTPACKAGE" Then
            ts = New DataGridTableStyle
            ts.MappingName = "ParentPackage"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Приложение"
            cs.MappingName = "Package"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "OBJECTTYPE" Then
            ts = New DataGridTableStyle
            ts.MappingName = "OBJECTTYPE"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Приложение"
            cs.MappingName = "Package"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Название"
            cs.MappingName = "the_Comment"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Код"
            cs.MappingName = "Name"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Допускается только один объект"
            cs.MappingName = "IsSingleInstance"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Представление для выбора"
            cs.MappingName = "ChooseView"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "При запуске"
            cs.MappingName = "OnRun"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "При создании"
            cs.MappingName = "OnCreate"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "При удалении"
            cs.MappingName = "OnDelete"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Отображать при выборе ссылки"
            cs.MappingName = "AllowRefToObject"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Отображать при поиске"
            cs.MappingName = "AllowSearch"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Тип репликации"
            cs.MappingName = "ReplicaType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Описание"
            cs.MappingName = "TheComment"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Видмость зависит от пользователя"
            cs.MappingName = "UseOwnership"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Архивировать вместо удаления"
            cs.MappingName = "UseArchiving"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Сохранять объект целиком"
            cs.MappingName = "CommitFullObject"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Иконка объекта"
            cs.MappingName = "objIconCls"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "PART" Then
            ts = New DataGridTableStyle
            ts.MappingName = "PART"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "№ п/п"
            cs.MappingName = "Sequence"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Тип структры"
            cs.MappingName = "PartType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Заголовок"
            cs.MappingName = "Caption"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Название"
            cs.MappingName = "Name"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Описание"
            cs.MappingName = "the_Comment"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Не записывать в журнал"
            cs.MappingName = "NoLog"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Исключить из индексирования"
            cs.MappingName = "ManualRegister"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "При создании"
            cs.MappingName = "OnCreate"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "При сохранении"
            cs.MappingName = "OnSave"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "При открытии"
            cs.MappingName = "OnRun"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "При удалении"
            cs.MappingName = "OnDelete"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поведение при добавлении"
            cs.MappingName = "AddBehaivor"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Объект расширения"
            cs.MappingName = "ExtenderObject"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Шаблон для краткого отображения"
            cs.MappingName = "shablonBrief"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Правило составления BRIEF поля"
            cs.MappingName = "ruleBrief"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Вести журнал изменений"
            cs.MappingName = "IsJormalChange"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Архивировать вместо удаления"
            cs.MappingName = "UseArchiving"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Целочисленный ключ"
            cs.MappingName = "integerpkey"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Иконка раздела"
            cs.MappingName = "partIconCls"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "FIELD" Then
            ts = New DataGridTableStyle
            ts.MappingName = "FIELD"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Имя вкладки"
            cs.MappingName = "TabName"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Имя группы"
            cs.MappingName = "FieldGroupBox"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "№ п/п"
            cs.MappingName = "Sequence"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Надпись"
            cs.MappingName = "Caption"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Имя поля"
            cs.MappingName = "Name"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Тип поля"
            cs.MappingName = "FieldType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Краткая информация"
            cs.MappingName = "IsBrief"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Для отображения в таблице"
            cs.MappingName = "IsTabBrief"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Может быть пустым"
            cs.MappingName = "AllowNull"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Размер поля"
            cs.MappingName = "DataSize"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Тип ссылки"
            cs.MappingName = "ReferenceType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Ссылка на тип"
            cs.MappingName = "RefToType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Ссылка на раздел"
            cs.MappingName = "RefToPart"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Стиль"
            cs.MappingName = "TheStyle"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Ссылка в пределах объекта"
            cs.MappingName = "InternalReference"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Только создание объекта"
            cs.MappingName = "CreateRefOnly"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Автонумерация"
            cs.MappingName = "IsAutoNumber"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Нумератор"
            cs.MappingName = "TheNumerator"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Шаблон зоны нумерации"
            cs.MappingName = "ZoneTemplate"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поле для расчета даты"
            cs.MappingName = "NumberDateField"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Описание"
            cs.MappingName = "TheComment"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Шаблон для краткого отображения"
            cs.MappingName = "shablonBrief"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Имя класса для мастера строк"
            cs.MappingName = "theNameClass"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Маска"
            cs.MappingName = "TheMask"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "FIELDMENU" Then
            ts = New DataGridTableStyle
            ts.MappingName = "FIELDMENU"
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
            cs.HeaderText = "Заголовок"
            cs.MappingName = "Caption"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Подсказка"
            cs.MappingName = "ToolTip"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Идентификатор вызываемого метода"
            cs.MappingName = "ActionID"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "В меню"
            cs.MappingName = "IsMenuItem"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "В тулбар"
            cs.MappingName = "IsToolBarButton"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Горячая клавиша"
            cs.MappingName = "HotKey"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "FIELDPARAMMAP" Then
            ts = New DataGridTableStyle
            ts.MappingName = "FIELDPARAMMAP"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поле (значение)"
            cs.MappingName = "FieldName"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Параметр"
            cs.MappingName = "ParamName"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Редактировать параметр нельзя"
            cs.MappingName = "NoEdit"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "DINAMICFILTERSCRIPT" Then
            ts = New DataGridTableStyle
            ts.MappingName = "DINAMICFILTERSCRIPT"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Целевая платформа"
            cs.MappingName = "Target"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Скрипт"
            cs.MappingName = "Code"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "FIELDVALIDATOR" Then
            ts = New DataGridTableStyle
            ts.MappingName = "FIELDVALIDATOR"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Платформа"
            cs.MappingName = "Target"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Скрипт"
            cs.MappingName = "Code"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "FIELDEXPRESSION" Then
            ts = New DataGridTableStyle
            ts.MappingName = "FIELDEXPRESSION"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Платформа"
            cs.MappingName = "Target"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Скрипт"
            cs.MappingName = "Code"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "FIELDSRCDEF" Then
            ts = New DataGridTableStyle
            ts.MappingName = "FIELDSRCDEF"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Провайдер"
            cs.MappingName = "Provider"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Строка соединения с источником"
            cs.MappingName = "ConnectionString"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Источник данных"
            cs.MappingName = "DataSource"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "ID"
            cs.MappingName = "IDField"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Источник краткой информации"
            cs.MappingName = "BriefString"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Фильтр источника данных"
            cs.MappingName = "FilterString"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Сортировка источника данных"
            cs.MappingName = "SortField"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Примечания"
            cs.MappingName = "DescriptionString"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Не показывать форму выбора"
            cs.MappingName = "DontShowDialog"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "FLDEXTENDERS" Then
            ts = New DataGridTableStyle
            ts.MappingName = "FldExtenders"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Название"
            cs.MappingName = "TheName"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Целевая платформа"
            cs.MappingName = "TargetPlatform"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Объект"
            cs.MappingName = "TheObject"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Конфиг"
            cs.MappingName = "TheConfig"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "PARTMENU" Then
            ts = New DataGridTableStyle
            ts.MappingName = "PARTMENU"
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
            cs.HeaderText = "Заголовок"
            cs.MappingName = "Caption"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Подсказка"
            cs.MappingName = "ToolTip"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Метод"
            cs.MappingName = "the_Action"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Включать в меню"
            cs.MappingName = "IsMenuItem"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "В тулбар"
            cs.MappingName = "IsToolBarButton"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Горячая клавиша"
            cs.MappingName = "HotKey"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "PARTPARAMMAP" Then
            ts = New DataGridTableStyle
            ts.MappingName = "PARTPARAMMAP"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поле (значение)"
            cs.MappingName = "FieldName"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Параметр"
            cs.MappingName = "ParamName"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Редактировать параметр нельзя"
            cs.MappingName = "NoEdit"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "UNIQUECONSTRAINT" Then
            ts = New DataGridTableStyle
            ts.MappingName = "UNIQUECONSTRAINT"
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
            cs.HeaderText = "По родителю"
            cs.MappingName = "PerParent"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Описание"
            cs.MappingName = "TheComment"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "CONSTRAINTFIELD" Then
            ts = New DataGridTableStyle
            ts.MappingName = "CONSTRAINTFIELD"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поле"
            cs.MappingName = "TheField"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "VALIDATOR" Then
            ts = New DataGridTableStyle
            ts.MappingName = "VALIDATOR"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Целевая платформа"
            cs.MappingName = "Target"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Скрипт"
            cs.MappingName = "Code"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "PARTVIEW" Then
            ts = New DataGridTableStyle
            ts.MappingName = "PARTVIEW"
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
            cs.HeaderText = "Псевдоним"
            cs.MappingName = "the_Alias"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Для поиска"
            cs.MappingName = "ForChoose"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поле - фильтр 0"
            cs.MappingName = "FilterField0"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поле - фильтр 1"
            cs.MappingName = "FilterField1"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поле - фильтр 2"
            cs.MappingName = "FilterField2"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поле - фильтр 3"
            cs.MappingName = "FilterField3"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "VIEWCOLUMN" Then
            ts = New DataGridTableStyle
            ts.MappingName = "ViewColumn"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "№"
            cs.MappingName = "sequence"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Название"
            cs.MappingName = "Name"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Псвдоним"
            cs.MappingName = "the_Alias"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Раздел"
            cs.MappingName = "FromPart"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поле"
            cs.MappingName = "Field"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Агрегация"
            cs.MappingName = "Aggregation"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Формула"
            cs.MappingName = "Expression"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Для комбо"
            cs.MappingName = "ForCombo"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "PARTVIEW_LNK" Then
            ts = New DataGridTableStyle
            ts.MappingName = "PARTVIEW_LNK"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Представление"
            cs.MappingName = "TheView"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Связь: Поле для join источник"
            cs.MappingName = "TheJoinSource"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Связывать как"
            cs.MappingName = "RefType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Свзяь: Поле для join приемник"
            cs.MappingName = "TheJoinDestination"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Ручной join"
            cs.MappingName = "HandJoin"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Порядок"
            cs.MappingName = "SEQ"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "EXTENDERINTERFACE" Then
            ts = New DataGridTableStyle
            ts.MappingName = "ExtenderInterface"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Название"
            cs.MappingName = "TheName"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Целевая платформа"
            cs.MappingName = "TargetPlatform"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Объект"
            cs.MappingName = "TheObject"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Конфиг"
            cs.MappingName = "TheConfig"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "TYPEMENU" Then
            ts = New DataGridTableStyle
            ts.MappingName = "TYPEMENU"
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
            cs.HeaderText = "Заголовок"
            cs.MappingName = "Caption"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Подсказка"
            cs.MappingName = "ToolTip"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Метод"
            cs.MappingName = "the_Action"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Включать в меню"
            cs.MappingName = "IsMenuItem"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Включать в тулбар"
            cs.MappingName = "IsToolBarButton"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Горячая клавиша"
            cs.MappingName = "HotKey"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "INSTANCEVALIDATOR" Then
            ts = New DataGridTableStyle
            ts.MappingName = "INSTANCEVALIDATOR"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Платформа"
            cs.MappingName = "Target"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Скрипт"
            cs.MappingName = "Code"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "OBJECTMODE" Then
            ts = New DataGridTableStyle
            ts.MappingName = "OBJECTMODE"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Название режима"
            cs.MappingName = "Name"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Этот режим является основным режимом работы объекта"
            cs.MappingName = "DefaultMode"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Описание"
            cs.MappingName = "TheComment"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "STRUCTRESTRICTION" Then
            ts = New DataGridTableStyle
            ts.MappingName = "STRUCTRESTRICTION"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "структура, доступ к которой ограничен"
            cs.MappingName = "Struct"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Разрешен просмотр"
            cs.MappingName = "AllowRead"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Разрешено добавлять"
            cs.MappingName = "AllowAdd"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Разрешено изменять"
            cs.MappingName = "AllowEdit"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Разрешено удалять"
            cs.MappingName = "AllowDelete"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "FIELDRESTRICTION" Then
            ts = New DataGridTableStyle
            ts.MappingName = "FIELDRESTRICTION"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Структура, которой принадлежит поле"
            cs.MappingName = "ThePart"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поле, на которое накладывается ограничение"
            cs.MappingName = "TheField"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Разрешен просмотр"
            cs.MappingName = "AllowRead"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Разрешена модификация"
            cs.MappingName = "AllowModify"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Обязательное поле"
            cs.MappingName = "MandatoryField"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "METHODRESTRICTION" Then
            ts = New DataGridTableStyle
            ts.MappingName = "METHODRESTRICTION"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Структура, которой принадлежит метод"
            cs.MappingName = "Part"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Метод"
            cs.MappingName = "Method"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Запрещено использовать"
            cs.MappingName = "IsRestricted"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "OBJSTATUS" Then
            ts = New DataGridTableStyle
            ts.MappingName = "OBJSTATUS"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Название"
            cs.MappingName = "name"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Начальное"
            cs.MappingName = "isStartup"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Архивное"
            cs.MappingName = "IsArchive"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Описание"
            cs.MappingName = "the_comment"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "NEXTSTATE" Then
            ts = New DataGridTableStyle
            ts.MappingName = "NEXTSTATE"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Разрешенное состояние"
            cs.MappingName = "TheState"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "FIELDTYPE" Then
            ts = New DataGridTableStyle
            ts.MappingName = "FIELDTYPE"
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
            cs.HeaderText = "Трактовка"
            cs.MappingName = "TypeStyle"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Описание"
            cs.MappingName = "the_Comment"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Нужен размер"
            cs.MappingName = "AllowSize"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Минимум"
            cs.MappingName = "Minimum"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Максимум"
            cs.MappingName = "Maximum"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Поиск текста"
            cs.MappingName = "AllowLikeSearch"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Вариант сортировки в табличном представлении"
            cs.MappingName = "GridSortType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Отложенное сохранение"
            cs.MappingName = "DelayedSave"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "FIELDTYPEMAP" Then
            ts = New DataGridTableStyle
            ts.MappingName = "FIELDTYPEMAP"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Платформа"
            cs.MappingName = "Target"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Тип хранения"
            cs.MappingName = "StoageType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Размер"
            cs.MappingName = "FixedSize"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "ENUMITEM" Then
            ts = New DataGridTableStyle
            ts.MappingName = "ENUMITEM"
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
            cs.HeaderText = "Значение"
            cs.MappingName = "NameValue"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Название в коде"
            cs.MappingName = "NameInCode"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "SHAREDMETHOD" Then
            ts = New DataGridTableStyle
            ts.MappingName = "SHAREDMETHOD"
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
            cs.HeaderText = "Описание метода"
            cs.MappingName = "the_Comment"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Возвращаемый тип"
            cs.MappingName = "ReturnType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "SCRIPT" Then
            ts = New DataGridTableStyle
            ts.MappingName = "SCRIPT"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Целевая платформа"
            cs.MappingName = "Target"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Скрипт"
            cs.MappingName = "Code"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "PARAMETERS" Then
            ts = New DataGridTableStyle
            ts.MappingName = "PARAMETERS"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Последовательность"
            cs.MappingName = "sequence"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Имя"
            cs.MappingName = "Name"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Заголовок"
            cs.MappingName = "Caption"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Тип данных"
            cs.MappingName = "TypeOfParm"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Размер"
            cs.MappingName = "DataSize"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Можно не задавать"
            cs.MappingName = "AllowNull"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Возвращает значение"
            cs.MappingName = "OutParam"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Тип ссылки"
            cs.MappingName = "ReferenceType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Ссылка на тип"
            cs.MappingName = "RefToType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Ссылка на раздел"
            cs.MappingName = "RefToPart"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "GENPACKAGE" Then
            ts = New DataGridTableStyle
            ts.MappingName = "GENPACKAGE"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Название"
            cs.MappingName = "Name"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "GENERATOR_TARGET" Then
            ts = New DataGridTableStyle
            ts.MappingName = "GENERATOR_TARGET"
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
            cs.HeaderText = "Тип платформы"
            cs.MappingName = "TargetType"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Очередь"
            cs.MappingName = "QueueName"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "COM класс"
            cs.MappingName = "GeneratorProgID"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Вариант"
            cs.MappingName = "GeneratorStyle"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Среда разработки"
            cs.MappingName = "TheDevelopmentEnv"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "GENREFERENCE" Then
            ts = New DataGridTableStyle
            ts.MappingName = "GENREFERENCE"
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
            cs.HeaderText = "Класс ссылки"
            cs.MappingName = "RefClassID"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Номер версии"
            cs.MappingName = "VersionMajor"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Подверсия"
            cs.MappingName = "VersionMinor"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "GENCONTROLS" Then
            ts = New DataGridTableStyle
            ts.MappingName = "GENCONTROLS"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "ProgID контрольконо элемента"
            cs.MappingName = "ControlProgID"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Класс контрольногоэлемента"
            cs.MappingName = "ControlClassID"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Версия"
            cs.MappingName = "VersionMajor"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Подверсия"
            cs.MappingName = "VersionMinor"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "GENMANUALCODE" Then
            ts = New DataGridTableStyle
            ts.MappingName = "GENMANUALCODE"
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
            cs.HeaderText = "Псевдоним"
            cs.MappingName = "the_Alias"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Код"
            cs.MappingName = "Code"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

        If PartName.ToUpper() = "LOCALIZEINFO" Then
            ts = New DataGridTableStyle
            ts.MappingName = "LocalizeInfo"
            ts.ReadOnly = True
            ts.RowHeaderWidth = 30
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Язык - название"
            cs.MappingName = "LangFull"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cs = New DataGridTextBoxColumn
            cs.ReadOnly = True
            cs.HeaderText = "Код языка"
            cs.MappingName = "LangShort"
            cs.NullText = ""
            ts.GridColumnStyles.Add(cs)
            cv.GridView.InitFields(ts)
        End If

    End Sub
    Private Sub cv_OnGridRefresh(ByVal ParentID As System.Guid, ByVal PartName As String, ByVal ChildPartName As String) Handles cv.OnGridRefresh
        Dim dt As DataTable
        Dim fl As Object
        If ParentID.Equals(System.Guid.Empty) Then
            dt = item.GENPACKAGE.GetDataTable
            dt.TableName = "GENPACKAGE"
            cv.SetGridData(dt)
        Else
        fl = item.FindRowObject(PartName, Parentid)

        If PartName.ToUpper() = "MTZAPP" Then
                If ChildPartName.ToUpper() = "PARENTPACKAGE" Then
                    dt = fl.ParentPackage.GetDataTable
                    dt.TableName = "ParentPackage"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "PARENTPACKAGE" Then
        End If

        If PartName.ToUpper() = "OBJECTTYPE" Then
                If ChildPartName.ToUpper() = "PART" Then
                    dt = fl.PART.GetDataTable
                    dt.TableName = "PART"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "TYPEMENU" Then
                    dt = fl.TYPEMENU.GetDataTable
                    dt.TableName = "TYPEMENU"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "INSTANCEVALIDATOR" Then
                    dt = fl.INSTANCEVALIDATOR.GetDataTable
                    dt.TableName = "INSTANCEVALIDATOR"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "OBJECTMODE" Then
                    dt = fl.OBJECTMODE.GetDataTable
                    dt.TableName = "OBJECTMODE"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "OBJSTATUS" Then
                    dt = fl.OBJSTATUS.GetDataTable
                    dt.TableName = "OBJSTATUS"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "PART" Then
                If ChildPartName.ToUpper() = "PART" Then
                    dt = fl.PART.GetDataTable
                    dt.TableName = "PART"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "FIELD" Then
                    dt = fl.FIELD.GetDataTable
                    dt.TableName = "FIELD"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "PARTMENU" Then
                    dt = fl.PARTMENU.GetDataTable
                    dt.TableName = "PARTMENU"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "UNIQUECONSTRAINT" Then
                    dt = fl.UNIQUECONSTRAINT.GetDataTable
                    dt.TableName = "UNIQUECONSTRAINT"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "VALIDATOR" Then
                    dt = fl.VALIDATOR.GetDataTable
                    dt.TableName = "VALIDATOR"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "PARTVIEW" Then
                    dt = fl.PARTVIEW.GetDataTable
                    dt.TableName = "PARTVIEW"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "EXTENDERINTERFACE" Then
                    dt = fl.ExtenderInterface.GetDataTable
                    dt.TableName = "ExtenderInterface"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "FIELD" Then
                If ChildPartName.ToUpper() = "FIELDMENU" Then
                    dt = fl.FIELDMENU.GetDataTable
                    dt.TableName = "FIELDMENU"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "DINAMICFILTERSCRIPT" Then
                    dt = fl.DINAMICFILTERSCRIPT.GetDataTable
                    dt.TableName = "DINAMICFILTERSCRIPT"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "FIELDVALIDATOR" Then
                    dt = fl.FIELDVALIDATOR.GetDataTable
                    dt.TableName = "FIELDVALIDATOR"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "FIELDEXPRESSION" Then
                    dt = fl.FIELDEXPRESSION.GetDataTable
                    dt.TableName = "FIELDEXPRESSION"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "FIELDSRCDEF" Then
                    dt = fl.FIELDSRCDEF.GetDataTable
                    dt.TableName = "FIELDSRCDEF"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "FLDEXTENDERS" Then
                    dt = fl.FldExtenders.GetDataTable
                    dt.TableName = "FldExtenders"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "FIELDMENU" Then
                If ChildPartName.ToUpper() = "FIELDPARAMMAP" Then
                    dt = fl.FIELDPARAMMAP.GetDataTable
                    dt.TableName = "FIELDPARAMMAP"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "FIELDPARAMMAP" Then
        End If

        If PartName.ToUpper() = "DINAMICFILTERSCRIPT" Then
        End If

        If PartName.ToUpper() = "FIELDVALIDATOR" Then
        End If

        If PartName.ToUpper() = "FIELDEXPRESSION" Then
        End If

        If PartName.ToUpper() = "FIELDSRCDEF" Then
        End If

        If PartName.ToUpper() = "FLDEXTENDERS" Then
        End If

        If PartName.ToUpper() = "PARTMENU" Then
                If ChildPartName.ToUpper() = "PARTPARAMMAP" Then
                    dt = fl.PARTPARAMMAP.GetDataTable
                    dt.TableName = "PARTPARAMMAP"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "PARTPARAMMAP" Then
        End If

        If PartName.ToUpper() = "UNIQUECONSTRAINT" Then
                If ChildPartName.ToUpper() = "CONSTRAINTFIELD" Then
                    dt = fl.CONSTRAINTFIELD.GetDataTable
                    dt.TableName = "CONSTRAINTFIELD"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "CONSTRAINTFIELD" Then
        End If

        If PartName.ToUpper() = "VALIDATOR" Then
        End If

        If PartName.ToUpper() = "PARTVIEW" Then
                If ChildPartName.ToUpper() = "VIEWCOLUMN" Then
                    dt = fl.ViewColumn.GetDataTable
                    dt.TableName = "ViewColumn"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "PARTVIEW_LNK" Then
                    dt = fl.PARTVIEW_LNK.GetDataTable
                    dt.TableName = "PARTVIEW_LNK"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "VIEWCOLUMN" Then
        End If

        If PartName.ToUpper() = "PARTVIEW_LNK" Then
        End If

        If PartName.ToUpper() = "EXTENDERINTERFACE" Then
        End If

        If PartName.ToUpper() = "TYPEMENU" Then
        End If

        If PartName.ToUpper() = "INSTANCEVALIDATOR" Then
        End If

        If PartName.ToUpper() = "OBJECTMODE" Then
                If ChildPartName.ToUpper() = "STRUCTRESTRICTION" Then
                    dt = fl.STRUCTRESTRICTION.GetDataTable
                    dt.TableName = "STRUCTRESTRICTION"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "FIELDRESTRICTION" Then
                    dt = fl.FIELDRESTRICTION.GetDataTable
                    dt.TableName = "FIELDRESTRICTION"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "METHODRESTRICTION" Then
                    dt = fl.METHODRESTRICTION.GetDataTable
                    dt.TableName = "METHODRESTRICTION"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "STRUCTRESTRICTION" Then
        End If

        If PartName.ToUpper() = "FIELDRESTRICTION" Then
        End If

        If PartName.ToUpper() = "METHODRESTRICTION" Then
        End If

        If PartName.ToUpper() = "OBJSTATUS" Then
                If ChildPartName.ToUpper() = "NEXTSTATE" Then
                    dt = fl.NEXTSTATE.GetDataTable
                    dt.TableName = "NEXTSTATE"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "NEXTSTATE" Then
        End If

        If PartName.ToUpper() = "FIELDTYPE" Then
                If ChildPartName.ToUpper() = "FIELDTYPEMAP" Then
                    dt = fl.FIELDTYPEMAP.GetDataTable
                    dt.TableName = "FIELDTYPEMAP"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "ENUMITEM" Then
                    dt = fl.ENUMITEM.GetDataTable
                    dt.TableName = "ENUMITEM"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "FIELDTYPEMAP" Then
        End If

        If PartName.ToUpper() = "ENUMITEM" Then
        End If

        If PartName.ToUpper() = "SHAREDMETHOD" Then
                If ChildPartName.ToUpper() = "SCRIPT" Then
                    dt = fl.SCRIPT.GetDataTable
                    dt.TableName = "SCRIPT"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "SCRIPT" Then
                If ChildPartName.ToUpper() = "PARAMETERS" Then
                    dt = fl.PARAMETERS.GetDataTable
                    dt.TableName = "PARAMETERS"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "PARAMETERS" Then
        End If

        If PartName.ToUpper() = "GENPACKAGE" Then
                If ChildPartName.ToUpper() = "GENERATOR_TARGET" Then
                    dt = fl.GENERATOR_TARGET.GetDataTable
                    dt.TableName = "GENERATOR_TARGET"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "GENERATOR_TARGET" Then
                If ChildPartName.ToUpper() = "GENREFERENCE" Then
                    dt = fl.GENREFERENCE.GetDataTable
                    dt.TableName = "GENREFERENCE"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "GENCONTROLS" Then
                    dt = fl.GENCONTROLS.GetDataTable
                    dt.TableName = "GENCONTROLS"
                    cv.SetGridData(dt)
                End If
                If ChildPartName.ToUpper() = "GENMANUALCODE" Then
                    dt = fl.GENMANUALCODE.GetDataTable
                    dt.TableName = "GENMANUALCODE"
                    cv.SetGridData(dt)
                End If
        End If

        If PartName.ToUpper() = "GENREFERENCE" Then
        End If

        If PartName.ToUpper() = "GENCONTROLS" Then
        End If

        If PartName.ToUpper() = "GENMANUALCODE" Then
        End If

        If PartName.ToUpper() = "LOCALIZEINFO" Then
        End If

        End If
    End Sub
 Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save
     Return true
 End Function
 Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK
     Return true
 End Function
 Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged
     Return false
 End Function
 Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify
     Return true
 End Function
End Class
