Option Strict Off
Option Explicit On
Imports System.Text

Friend Class Writer
    Private Buf As StringBuilder

    Public Sub New()
        Buf = New StringBuilder
    End Sub

    Public Sub putBuf(ByRef s As String)
        Buf.AppendLine()
        Buf.Append(s)
    End Sub

    Public Sub putBuf2(ByRef s As String)
        Buf.Append(s)
    End Sub

    Public Function getBuf() As String
        Return Buf.ToString()
    End Function
End Class