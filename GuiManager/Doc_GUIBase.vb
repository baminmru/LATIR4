Imports LATIR2


Public Class Doc_GUIBase

    Protected mGuiManager As LATIRGuiManager

    Public Overridable Function TypeName() As String
        Return "UNKNOWN"
    End Function
    Public Overridable Function ShowPartEditForm(ByVal Mode As String, ByRef RowItem As LATIR2.Document.DocRow_Base, Optional ByVal FormReadOnly As Boolean = False) As Boolean
        MsgBox("Base class call")
        Return False
    End Function
    Public Overridable Function ShowForm(ByVal Mode As String, ByRef DocItem As LATIR2.Document.Doc_Base, Optional ByVal FormReadOnly As Boolean = False) As Boolean
        MsgBox("Base class call")
        Return False
    End Function
    Public Sub Attach(ByVal GuiManager As LATIRGuiManager)
        mGuiManager = GuiManager
    End Sub
    Public Function GUIManager() As LATIRGuiManager
        Return mGuiManager
    End Function
    Public Overridable Sub Dispose()
        'do nothing
    End Sub
    Public Overridable Function GetObjectControl(ByVal Mode As String, ByVal TypeName As String) As Object
        Return Nothing
    End Function

End Class
