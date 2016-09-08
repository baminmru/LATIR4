Option Explicit On
Imports System.Data
Imports System.xml
Imports System.Data.Common

Namespace Document
    Public MustInherit Class Doc_StatusSupport
        Public MustOverride Function CheckFor(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid, Optional ByRef Message As String = "") As Boolean
        Public MustOverride Sub BeforeChangeState(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid)
        Public MustOverride Sub AfterChangeState(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid)
    End Class
End Namespace
