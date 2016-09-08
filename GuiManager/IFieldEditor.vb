Public Interface IFieldEditor
    Event Changed()
    Sub Save()
    Function IsOK() As Boolean
    Function IsChanged() As Boolean
    Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base, ByVal FieldName As String, ByVal ReadOnlyMode As Boolean)
    Function DefaultHeight() As Int32
    'sub SetParameter( byval Name as string, byval Value as Object)
End Interface
