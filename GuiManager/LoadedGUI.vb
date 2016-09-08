Option Strict Off
Option Explicit On 



Friend Class LoadedGUI

    Private mvarTypeName As String 'local copy
    Private mvarGUI As Doc_GUIBase 'local copy

    Public Property GUI() As Doc_GUIBase
        Get
            GUI = mvarGUI
        End Get
        Set(ByVal Value As Doc_GUIBase)
            mvarGUI = Value
        End Set
    End Property

    

    Public Property TypeName() As String
        Get
            Return mvarTypeName
        End Get
        Set(ByVal Value As String)
            mvarTypeName = Value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
