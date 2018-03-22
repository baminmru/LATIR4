Option Strict Off
Option Explicit On
Friend Class Writer
	
    'Private fname As String
    'Private ff As Integer
    '   Private closed As Boolean
    Private buf As String
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Private Sub Class_Initialize_Renamed()
        '		Dim mTempPath As String
        '		mTempPath = GetSetting("MTZ", "CONFIG", "TEMPPATH", "")
        '		If mTempPath = "" Then
        '			ChDir(VB6.GetPath)
        '			On Error Resume Next
        '			MkDir("TMP")
        '            fname = VB6.GetPath & "\TMP\" & System.Guid.NewGuid.ToString & ".txt"
        '		Else
        '            fname = mTempPath & System.Guid.NewGuid.ToString & ".txt"
        '		End If
        '		On Error GoTo bye
        '		ff = FreeFile
        '		FileOpen(ff, fname, OpenMode.Output)
        '		closed = False
        '		Exit Sub
        'bye: 
        '		MsgBox("Проблема отрытия файла:" & fname,  , "Модель хранения метакода")
        '		closed = True
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	

	Private Sub Class_Terminate_Renamed()
		On Error Resume Next
        'If Not closed Then
        '	FileClose(ff)
        '	closed = True
        'End If
        'Kill(fname)
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
    Public Sub putBuf(ByRef s As String)
        buf += s & vbCrLf
        'If closed Then
        '    ff = FreeFile()
        '    FileOpen(ff, fname, OpenMode.Append)
        '    closed = False
        'End If
        'Print(ff, vbCrLf & s)
    End Sub

    Public Sub putBuf2(ByRef s As String)
        buf += s
        'If closed Then
        '    ff = FreeFile()
        '    FileOpen(ff, fname, OpenMode.Append)
        '    closed = False
        'End If
        'Print(ff, s)
    End Sub

    Public Sub Flush()
        'If Not closed Then
        '    FileClose(ff)
        '    closed = True
        'End If
    End Sub


    Public Function getBuf() As String
        'Dim s As String
        'FileClose(ff)
        'ff = FreeFile()
        'FileOpen(ff, fname, OpenMode.Input)
        's = InputString(ff, LOF(ff))
        'FileClose(ff)
        'closed = True
        getBuf = buf
    End Function
End Class