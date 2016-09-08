Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Text

Public Class Writer
    Private Buf As StringBuilder

    Public Sub New()
        Buf = New StringBuilder
    End Sub

    Public Sub putBuf(ByRef s As String)
        Buf.AppendLine()
        Buf.Append(s)
    End Sub

    Public Sub putBufLC(ByRef s As String)
        Buf.AppendLine()
        Buf.Append(s.ToLower())
    End Sub

    Public Sub putBufUC(ByRef s As String)
        Buf.AppendLine()
        Buf.Append(s.ToUpper())
    End Sub


    Public Function getBuf() As String
        Return Buf.ToString()
    End Function
End Class