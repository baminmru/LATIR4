
Imports LATIR2GuiManager
Imports System.Windows.Forms
Imports System.Diagnostics


''' <summary>
'''Основной класс компонента
''' </summary>
''' <remarks>
'''Класс обслуживает визуальное редактирование 
''' </remarks>
Public Class GUI
    Inherits LATIR2GuiManager.Doc_GUIBase


''' <summary>
'''Имя типа
''' </summary>
''' <returns>
'''Строковое значение кода типа объекта 
''' </returns>
''' <remarks>
'''Код типа в метамодели
''' </remarks>
    Public Overrides Function TypeName() As String
        Return "MTZMetaModel"
    End Function


''' <summary>
'''Форма редактирования раздела
''' </summary>
''' <returns>
'''Результат работы формы редактирования
''' </returns>
''' <remarks>
'''Определяется какая форма должна быть вызвана, происходит инициализация и вызов формы
''' </remarks>
    Public Overrides Function ShowPartEditForm(ByVal Mode As String, ByRef RowItem As LATIR2.Document.DocRow_Base, optional byval FormReadOnly as boolean = false) As Boolean
        ' Mode
        If Mode = "" Then

            If RowItem.PartName.ToUpper = "MTZAPP" Then
                Dim f As frmMTZAPP
                f = New frmMTZAPP
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "PARENTPACKAGE" Then
                Dim f As frmParentPackage
                f = New frmParentPackage
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "OBJECTTYPE" Then
                Dim f As frmOBJECTTYPE
                f = New frmOBJECTTYPE
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "OBJSTATUS" Then
                Dim f As frmOBJSTATUS
                f = New frmOBJSTATUS
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "NEXTSTATE" Then
                Dim f As frmNEXTSTATE
                f = New frmNEXTSTATE
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "OBJECTMODE" Then
                Dim f As frmOBJECTMODE
                f = New frmOBJECTMODE
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "STRUCTRESTRICTION" Then
                Dim f As frmSTRUCTRESTRICTION
                f = New frmSTRUCTRESTRICTION
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "METHODRESTRICTION" Then
                Dim f As frmMETHODRESTRICTION
                f = New frmMETHODRESTRICTION
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "FIELDRESTRICTION" Then
                Dim f As frmFIELDRESTRICTION
                f = New frmFIELDRESTRICTION
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TYPEMENU" Then
                Dim f As frmTYPEMENU
                f = New frmTYPEMENU
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "INSTANCEVALIDATOR" Then
                Dim f As frmINSTANCEVALIDATOR
                f = New frmINSTANCEVALIDATOR
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "PART" Then
                Dim f As frmPART
                f = New frmPART
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "PARTMENU" Then
                Dim f As frmPARTMENU
                f = New frmPARTMENU
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "PARTPARAMMAP" Then
                Dim f As frmPARTPARAMMAP
                f = New frmPARTPARAMMAP
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "PARTVIEW" Then
                Dim f As frmPARTVIEW
                f = New frmPARTVIEW
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "VIEWCOLUMN" Then
                Dim f As frmViewColumn
                f = New frmViewColumn
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "PARTVIEW_LNK" Then
                Dim f As frmPARTVIEW_LNK
                f = New frmPARTVIEW_LNK
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "VALIDATOR" Then
                Dim f As frmVALIDATOR
                f = New frmVALIDATOR
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "UNIQUECONSTRAINT" Then
                Dim f As frmUNIQUECONSTRAINT
                f = New frmUNIQUECONSTRAINT
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "CONSTRAINTFIELD" Then
                Dim f As frmCONSTRAINTFIELD
                f = New frmCONSTRAINTFIELD
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "EXTENDERINTERFACE" Then
                Dim f As frmExtenderInterface
                f = New frmExtenderInterface
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "FIELD" Then
                Dim f As frmFIELD
                f = New frmFIELD
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "FLDEXTENDERS" Then
                Dim f As frmFldExtenders
                f = New frmFldExtenders
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "FIELDSRCDEF" Then
                Dim f As frmFIELDSRCDEF
                f = New frmFIELDSRCDEF
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "DINAMICFILTERSCRIPT" Then
                Dim f As frmDINAMICFILTERSCRIPT
                f = New frmDINAMICFILTERSCRIPT
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "FIELDEXPRESSION" Then
                Dim f As frmFIELDEXPRESSION
                f = New frmFIELDEXPRESSION
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "FIELDVALIDATOR" Then
                Dim f As frmFIELDVALIDATOR
                f = New frmFIELDVALIDATOR
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "FIELDMENU" Then
                Dim f As frmFIELDMENU
                f = New frmFIELDMENU
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "FIELDPARAMMAP" Then
                Dim f As frmFIELDPARAMMAP
                f = New frmFIELDPARAMMAP
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "FIELDTYPE" Then
                Dim f As frmFIELDTYPE
                f = New frmFIELDTYPE
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "ENUMITEM" Then
                Dim f As frmENUMITEM
                f = New frmENUMITEM
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "FIELDTYPEMAP" Then
                Dim f As frmFIELDTYPEMAP
                f = New frmFIELDTYPEMAP
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "SHAREDMETHOD" Then
                Dim f As frmSHAREDMETHOD
                f = New frmSHAREDMETHOD
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "SCRIPT" Then
                Dim f As frmSCRIPT
                f = New frmSCRIPT
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "PARAMETERS" Then
                Dim f As frmPARAMETERS
                f = New frmPARAMETERS
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "GENPACKAGE" Then
                Dim f As frmGENPACKAGE
                f = New frmGENPACKAGE
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "GENERATOR_TARGET" Then
                Dim f As frmGENERATOR_TARGET
                f = New frmGENERATOR_TARGET
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "GENREFERENCE" Then
                Dim f As frmGENREFERENCE
                f = New frmGENREFERENCE
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "GENMANUALCODE" Then
                Dim f As frmGENMANUALCODE
                f = New frmGENMANUALCODE
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "GENCONTROLS" Then
                Dim f As frmGENCONTROLS
                f = New frmGENCONTROLS
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "LOCALIZEINFO" Then
                Dim f As frmLocalizeInfo
                f = New frmLocalizeInfo
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If

    End Function


''' <summary>
'''Форма редактирования документа
''' </summary>
''' <returns>
'''Резултат работы формы редактирования
''' </returns>
''' <remarks>
'''Определяется какая форма должна быть вызвана, происходит инициализация и вызов формы в модальном режиме
''' </remarks>
    Public Overrides Function ShowForm(ByVal Mode As String, ByRef DocItem As LATIR2.Document.Doc_Base, optional byval FormReadOnly as boolean = false) As Boolean
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "" Then
                Dim f As frmMTZMetaModel
                f = New frmMTZMetaModel
                f.Attach(DocItem, Me.GUIManager, FormReadOnly)
                ShowForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If
        End If
    End Function


''' <summary>
'''Получить контрол, реализующий работу в заданном режиме
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides Function GetObjectControl(ByVal Mode As String, ByVal TypeName As String) As Object
      Return New Tabview
    End Function

    Public Overrides Sub Dispose()
        ' do nothing
    End Sub




End Class
