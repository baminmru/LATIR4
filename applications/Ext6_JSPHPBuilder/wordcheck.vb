Option Strict Off
Option Explicit On
Imports System.IO
Module wordcheck
	Public words() As String
	Public Const MaxNameLen As Short = 28
	
	Public Function IsValidFieldName2(ByVal Name As String) As Boolean
		If Len(Name) = 0 Then IsValidFieldName2 = False : Exit Function
		If Asc(Name) >= Asc("0") And Asc(Name) <= Asc("9") Then IsValidFieldName2 = False : Exit Function
		If IsValidFieldName(Name) Then
			If Not IsKeyword(Name) Then
				IsValidFieldName2 = True
			End If
		End If
	End Function
	
	Public Sub LoadWords()
		Dim ff As Short
        Dim s As String = ""
		Dim cnt As Integer
		ff = FreeFile
		On Error Resume Next
        Erase words

        If (Not File.Exists(My.Application.Info.DirectoryPath & "\words.txt")) Then
            MsgBox("Íåò 'words.txt' â '" & My.Application.Info.DirectoryPath & "'")
        End If

		FileOpen(ff, My.Application.Info.DirectoryPath & "\words.txt", OpenMode.Input)
		Input(ff, s)
		cnt = 0
		While s <> ""
			cnt = cnt + 1
			ReDim Preserve words(cnt)
			words(cnt) = s
			s = ""
			Input(ff, s)
		End While
		FileClose(ff)
	End Sub
	
	Public Function IsKeyword(ByVal Name As String) As Boolean
		Dim ustr As String
		Dim i As Integer
		ustr = UCase(Name)
		IsKeyword = False
		On Error Resume Next
		For i = 1 To UBound(words)
			If ustr = words(i) Then IsKeyword = True : Exit Function
		Next 
	End Function
	
	
	
	Public Function IsValidName(ByVal Name As String) As Boolean
		Dim m As String
		Dim i As Integer
		IsValidName = True
		If InStr(1, "_", Left(Name, 1), CompareMethod.Text) > 0 Then IsValidName = False : Exit Function
		For i = 1 To Len(Name)
			m = Mid(Name, i, 1)
			If Asc(m) < Asc("0") Then IsValidName = False : Exit Function
			If Asc(m) > Asc("z") Then IsValidName = False : Exit Function
			If InStr(1, ":;<=>?@[\]^`", m) > 0 Then IsValidName = False : Exit Function
		Next 
	End Function
	
	Public Function IsValidFieldName(ByVal Name As String) As Boolean
		Dim m As String
		Dim i As Integer
		IsValidFieldName = True
		For i = 1 To Len(Name)
			m = Mid(Name, i, 1)
			If Asc(m) < Asc("0") Then IsValidFieldName = False : Exit Function
			If Asc(m) > Asc("z") Then IsValidFieldName = False : Exit Function
			If InStr(1, ":;<=>?@[\]^`", m) > 0 Then IsValidFieldName = False : Exit Function
		Next 
	End Function
	
	Public Function MakeValidName(ByVal Name As String) As String
		Dim s As String
		Dim changes As String
		Dim transfr, transto As String
		Dim i As Integer
		Dim begs As String
		begs = "_1234567890"
		changes = " +-`~'""/\|*:.,<>?][{}!@#$%^&()"
		transfr = "éöóêåíãøùçõúôûâàïðîëäæýÿ÷ñìèòüáþ¸ÉÖÓÊÅÍÃØÙÇÕÚÔÛÂÀÏÐÎËÄÆÝß×ÑÌÈÒÜÁÞ¨"
		transto = "ycukengsszh_fivaproldgeycsmit_buyYCUKENGSSZH_FIVAPROLDGEYCSMIT_BUE"
		
		s = Name
		For i = 1 To Len(changes)
			s = Replace(s, Mid(changes, i, 1), "_")
		Next 
		
		For i = 1 To Len(transfr)
			s = Replace(s, Mid(transfr, i, 1), Mid(transto, i, 1))
		Next 
		If InStr(1, begs, Left(s, 1)) > 0 Then
			s = "the_" & s
		End If
		If Not IsValidFieldName2(s) Then
			s = "the_" & s
		End If
		MakeValidName = s
	End Function
	
	Public Function VF(ByVal Name As String) As String
		If Len(Name) > MaxNameLen Then
			VF = VF(Left(Name, MaxNameLen))
			Exit Function
		End If
		VF = MakeValidName(Name)
	End Function
End Module