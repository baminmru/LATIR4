Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("Preprocessor_NET.Preprocessor")> Public Class Preprocessor
	Private mOpenCode As String
	Private mCloseCode As String
	Private mOutput As String
	Private mOut As String
	Private mOutNL As String
	'local variable(s) to hold property value(s)
	Private mvarOpenCode As String 'local copy
	Private mvarCloseCode As String 'local copy
	Private mvarOuputClass As String 'local copy
	Private mvarOutFunc As String 'local copy
	Private mvarOutNLFunc As String 'local copy
	
	'Parameters:
	'[IN]   vData , тип параметра: String  - ...
	'See Also:
	'  CloseCode
	'  Convert
	'  OpenCode
	'  OuputClass
	'  OutFunc
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.OutNLFunc = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа String
	'See Also:
	'  CloseCode
	'  Convert
	'  OpenCode
	'  OuputClass
	'  OutFunc
	'Example:
	' dim variable as String
	' variable = me.OutNLFunc
	Public Property OutNLFunc() As String
		Get
			OutNLFunc = mvarOutNLFunc
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.OutNLFunc = 5
			mvarOutNLFunc = Value
		End Set
	End Property
	
	'Parameters:
	'[IN]   vData , тип параметра: String  - ...
	'See Also:
	'  CloseCode
	'  Convert
	'  OpenCode
	'  OuputClass
	'  OutNLFunc
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.OutFunc = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа String
	'See Also:
	'  CloseCode
	'  Convert
	'  OpenCode
	'  OuputClass
	'  OutNLFunc
	'Example:
	' dim variable as String
	' variable = me.OutFunc
	Public Property OutFunc() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.OutFunc
			OutFunc = mvarOutFunc
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.OutFunc = 5
			mvarOutFunc = Value
		End Set
	End Property
	
	'Parameters:
	'[IN]   vData , тип параметра: String  - ...
	'See Also:
	'  CloseCode
	'  Convert
	'  OpenCode
	'  OutFunc
	'  OutNLFunc
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.OuputClass = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа String
	'See Also:
	'  CloseCode
	'  Convert
	'  OpenCode
	'  OutFunc
	'  OutNLFunc
	'Example:
	' dim variable as String
	' variable = me.OuputClass
	Public Property OuputClass() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.OuputClass
			OuputClass = mvarOuputClass
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.OuputClass = 5
			mvarOuputClass = Value
		End Set
	End Property
	
	'Parameters:
	'[IN]   vData , тип параметра: String  - ...
	'See Also:
	'  Convert
	'  OpenCode
	'  OuputClass
	'  OutFunc
	'  OutNLFunc
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.CloseCode = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа String
	'See Also:
	'  Convert
	'  OpenCode
	'  OuputClass
	'  OutFunc
	'  OutNLFunc
	'Example:
	' dim variable as String
	' variable = me.CloseCode
	Public Property CloseCode() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.CloseCode
			CloseCode = mvarCloseCode
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.CloseCode = 5
			mvarCloseCode = Left(Value & "~~", 2)
		End Set
	End Property
	
	'Parameters:
	'[IN]   vData , тип параметра: String  - ...
	'See Also:
	'  CloseCode
	'  Convert
	'  OuputClass
	'  OutFunc
	'  OutNLFunc
	'Example:
	' dim value as Variant
	' value = <значение>
	' me.OpenCode = value
	
	'Parameters:
	' параметров нет
	'Returns:
	'  значение типа String
	'See Also:
	'  CloseCode
	'  Convert
	'  OuputClass
	'  OutFunc
	'  OutNLFunc
	'Example:
	' dim variable as String
	' variable = me.OpenCode
	Public Property OpenCode() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.OpenCode
			OpenCode = mvarOpenCode
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.OpenCode = 5
			mvarOpenCode = Left(Value & "~~", 2)
		End Set
	End Property
	
	
	
	
	Private Sub BeforConvert()
		mOutput = mvarOuputClass
		If mvarOuputClass = "" Then
			mOut = mvarOutFunc
			mOutNL = mvarOutNLFunc
		Else
			mOut = mOutput & "." & mvarOutFunc
			mOutNL = mOutput & "." & mvarOutNLFunc
		End If
		mOpenCode = mvarOpenCode
		mCloseCode = mvarCloseCode
	End Sub
	
	
	Private Function DoubleQuoter(ByVal s As String) As String
		DoubleQuoter = Replace(s, """", """""")
	End Function
	
	'Parameters:
	'[IN]   s , тип параметра: String  - ...
	'Returns:
	'  значение типа String
	'See Also:
	'  CloseCode
	'  OpenCode
	'  OuputClass
	'  OutFunc
	'  OutNLFunc
	'Example:
	' dim variable as String
	' variable = me.Convert(<параметры>)
	Public Function Convert(ByVal s As String) As String
		Dim Lines() As String
		Dim Scr As Boolean
        Dim res As String = String.Empty
		Dim i As Integer
		BeforConvert()
		Lines = Split(s, vbCrLf)
		Scr = False
		For i = 0 To UBound(Lines)
			'Debug.Print Lines(i)
			res = res & ConvertLine(Lines(i), Scr)
		Next 
		Convert = res
	End Function
	
	
	Private Function ConvertLine(ByVal s As String, ByRef Scr As Boolean) As String
        Dim res As String = String.Empty
		Dim epos, pos, spos As Integer
		If Not Scr Then
			If InStr(1, s, mOpenCode, CompareMethod.Text) = 0 Then
				res = res & mOutNL & " """ & DoubleQuoter(s) & """" & vbCrLf
			Else
				spos = 1
				pos = 1
				While pos > 0
					pos = InStr(spos, s, mOpenCode, CompareMethod.Text)
					If pos = 0 Then GoTo done1
					Scr = True
					epos = InStr(pos + 1, s, mCloseCode, CompareMethod.Text)
					
					If epos = 0 Then
						epos = Len(s) + 1
					Else
						Scr = False
					End If
					
					If pos - spos > 0 Then
						res = res & mOut & " """ & DoubleQuoter(Mid(s, spos, pos - spos)) & """" & vbCrLf
					End If
					If epos - 2 - pos > 0 Then
						res = res & vbCrLf & Mid(s, pos + 2, epos - pos - 2) & vbCrLf
					End If
					spos = epos + 2
				End While
done1: 
				If Not Scr Then
					If spos <= Len(s) Then
						res = res & mOutNL & " """ & DoubleQuoter(Mid(s, spos, Len(s) - spos + 1)) & """" & vbCrLf
					End If
				End If
				
			End If
		Else
			If InStr(1, s, mCloseCode, CompareMethod.Text) = 0 Then
				res = res & s & vbCrLf
			Else
				spos = 1
				pos = -1
				While pos <> 0
					pos = InStr(spos, s, mCloseCode, CompareMethod.Text)
					If pos = 0 Then GoTo Done2
					Scr = False
					epos = InStr(pos + 2, s, mOpenCode, CompareMethod.Text)
					If epos = 0 Then
						epos = Len(s) + 1
					Else
						Scr = True
					End If
					If pos - spos - 2 > 0 Then
						res = res & Mid(s, spos, pos - spos) & vbCrLf
						
						'Else
						'  res = res & vbCrLf
					End If
					If Mid(s, pos + 2, epos - pos - 2) <> "" Then
						res = res & mOutNL & " """ & DoubleQuoter(Mid(s, pos + 2, epos - pos - 2)) & """" & vbCrLf
					End If
					spos = epos + 2
				End While
Done2: 
				If Scr Then
					If spos <= Len(s) Then
						res = res & Mid(s, spos, Len(s) - spos + 1) & vbCrLf
					End If
				End If
			End If
			
		End If
		ConvertLine = res
	End Function
	
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Private Sub Class_Initialize_Renamed()
		mvarOpenCode = "<%"
		mvarCloseCode = "%>"
		mvarOuputClass = "Response"
		mvarOutFunc = "Out"
		mvarOutNLFunc = "OutNL"
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
End Class