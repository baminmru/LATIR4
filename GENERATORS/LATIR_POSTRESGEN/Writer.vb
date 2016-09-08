

Imports System.IO
Public Class Writer

    Private fname As String
    Private ff As Integer
    Private closed As Boolean

    Private Buffer As String = String.Empty

    Public Sub New()
        'MyBase.New()
        'Dim mTempPath As String
        'mTempPath = GetSetting("MTZ", "CONFIG", "TEMPPATH", "")
        'If mTempPath = "" Then
        '    ChDir(My.Application.Info.DirectoryPath)
        '    On Error Resume Next
        '    MkDir("TMP")
        '    fname = My.Application.Info.DirectoryPath & "\TMP\" & Guid.NewGuid().ToString() & ".txt"
        'Else
        '    fname = mTempPath & Guid.NewGuid().ToString() & ".txt"
        'End If
        'ff = FreeFile()
        'FileOpen(ff, fname, OpenMode.Output)
        'closed = False
    End Sub

    Public Sub Close()
        'On Error Resume Next
        'If Not closed Then
        '    FileClose(ff)
        'End If
        'If (File.Exists(fname)) Then
        '    File.Delete(fname)
        'End If
        'closed = True
        Buffer = String.Empty
    End Sub


    Protected Overrides Sub Finalize()
        Close()
        MyBase.Finalize()
    End Sub

    Public Sub putBuf(ByRef s As String)
        'If closed Then
        '    ff = FreeFile()
        '    FileOpen(ff, fname, OpenMode.Append)
        'End If
        'PrintLine(ff, s)
        Buffer += vbCrLf + s
    End Sub

    'Public Sub putBuf2(ByRef s As String)
    '    'If closed Then
    '    '    ff = FreeFile()
    '    '    FileOpen(ff, fname, OpenMode.Append)
    '    'End If
    '    'PrintLine(ff, s)
    '    Buffer += s
    'End Sub

    Public Function getBuf() As String
        'Dim s As String
        'FileClose(ff)
        'ff = FreeFile()
        'FileOpen(ff, fname, OpenMode.Input)
        's = InputString(ff, LOF(ff))
        'FileClose(ff)
        'closed = True
        'getBuf = s
        Return Buffer
    End Function
End Class