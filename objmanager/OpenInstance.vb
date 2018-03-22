Option Explicit On
Imports System.Collections.Generic

Friend Class OpenInstance

    Private mvarLocked As Boolean 'local copy
    Private mvarID As Guid 'local copy
    Private mvarSite As String 'local copy
    Private mvarDoc As Document.Doc_Base 'local copy

    Public Property DOC() As Document.Doc_Base
        Get
            Return mvarDoc
        End Get
        Set(ByVal Value As Document.Doc_Base)
            mvarDoc = Value
        End Set
    End Property

    Public Property ID() As Guid
        Get
            Return mvarID
        End Get
        Set(ByVal Value As Guid)
            mvarID = Value
        End Set
    End Property

    Public Property Locked() As Boolean
        Get
            Return mvarLocked
        End Get
        Set(ByVal Value As Boolean)
            mvarLocked = Value
        End Set
    End Property

    Public Property site() As String
        Get
            Return mvarSite
        End Get
        Set(ByVal Value As String)
            mvarSite = Value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class


