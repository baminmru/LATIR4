Public Class FieldExtentionControl
    Private mDefaultWidth As Integer
    Private mDefaultHeight As Integer
    Private mFieldIDX As Integer
    Private mFieldName As String
    Private mFieldCaption As String
    Private mFieldTip As String
    Private mGM As LATIR2GuiManager.LATIRGuiManager
    Private mRowItem As LATIR2.Document.DocRow_Base

    Public Overridable ReadOnly Property DefaultHeight() As Integer
        Get
            Return (mDefaultHeight)
        End Get
    End Property

    Public Overridable ReadOnly Property DefaultWidth() As Integer
        Get
            Return (mDefaultWidth)
        End Get
    End Property
    Public Overridable ReadOnly Property FieldName() As String
        Get
            Return (mFieldName)
        End Get
    End Property

    Public Overridable ReadOnly Property FieldCaption() As String
        Get
            Return (mFieldCaption)
        End Get
    End Property

    Public Overridable ReadOnly Property FieldTip() As String
        Get
            Return (mFieldTip)
        End Get
    End Property
    Public Overridable ReadOnly Property GuiManager() As LATIR2GuiManager.LATIRGuiManager
        Get
            Return (mGM)
        End Get
    End Property

    Public Overridable ReadOnly Property RowItem() As LATIR2.Document.DocRow_Base
        Get
            Return (mRowItem)
        End Get
    End Property

    Public Overridable ReadOnly Property NoCaption() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overridable ReadOnly Property NoTip() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overridable Sub Attach(ByVal GuiManager As LATIR2GuiManager.LATIRGuiManager, ByRef DocRowItem As LATIR2.Document.DocRow_Base, ByVal EditFieldName As String, ByVal EditFieldCaption As String, Optional ByVal EditFieldTip As String = "")
        mGM = GuiManager
        mRowItem = DocRowItem
        mFieldName = EditFieldName
        mFieldCaption = EditFieldCaption
        mFieldTip = EditFieldTip

        Dim i As Integer
        For i = 1 To RowItem.Count
            If RowItem.FieldNameByID(i).ToUpper() = FieldName.ToUpper() Then
                mFieldIDX = i
                Exit For
            End If
        Next
        InitOnAttach()
        LoadDataFromField()
    End Sub

    Protected Overridable Sub InitOnAttach()

    End Sub

    Public Overridable Function IsOK() As Boolean
        Return True
    End Function

    Public Overridable Sub LoadDataFromField()
     
    End Sub

    Public Overridable Sub SaveDataToField()

    End Sub

    Public Sub New()
        mDefaultHeight = 20
        mDefaultWidth = 100
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
