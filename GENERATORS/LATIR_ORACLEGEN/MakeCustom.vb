Imports MTZMetaModel.MTZMetaModel
Imports LATIRGenerator


Public Class MakeCustom

    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim o As LATIRGenerator.Response
    Dim tid As String
    Dim parent As Generator

    Public Sub Init(ByVal ap As Generator, ByVal am As MTZMetaModel.MTZMetaModel.Application, ByVal ao As LATIRGenerator.Response, ByVal atid As String)
        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub

    Public Sub Run()
        Dim i As Long
        For i = 1 To m.SHAREDMETHOD.Count
            CreateMethod(m.SHAREDMETHOD.Item(i))

        Next

        'ManualCode
        o.ModuleName = "--Custom"
        o.Block = "--body"

        Dim targ As GENERATOR_TARGET
        Dim mc As GENMANUALCODE
        targ = m.FindRowObject("GENERATOR_TARGET", New Guid(tid))
        For i = 1 To targ.GENMANUALCODE.Count
            mc = targ.GENMANUALCODE.Item(i)
            o.OutNL("/*" & mc.Name & " (" & mc.the_Alias & ")*/")
            o.OutNL(mc.Code)
            o.OutNL("/")
        Next
    End Sub


    Private Sub CreateMethod(ByVal m As SHAREDMETHOD)
        System.Diagnostics.Debug.Print("ORAGEN.CreateMethod:start")
        On Error GoTo bye
        Dim p As PARAMETERS
        Dim i As Long
        Dim s As String, s1 As String
        Dim ftm As FIELDTYPEMAP
        Dim Parameters As PARAMETERS_col
        s1 = GetScript(m.SCRIPT)

        If s1 = "" Then Exit Sub


        Parameters = GetParameters(m.SCRIPT)
        s = "/* " & m.Name & "  " & m.the_Comment & "*/"
        If m.ReturnType Is Nothing Then
            s = s & vbCrLf & "create or replace procedure " & m.Name & vbCrLf
            If Parameters.Count > 0 Then
                s = s & vbCrLf & "("
            End If
        Else
            s = "create or replace function " & m.Name & vbCrLf
        End If



        Parameters.Sort = "sequence"
        For i = 1 To Parameters.Count
            p = Parameters.Item(i)
            If i > 1 Then s = s & vbCrLf & ","
            s = s & MethodParam(p) & vbCrLf
        Next

        If Not m.ReturnType Is Nothing Then
            s = s & vbCrLf & ") "
            s = s & vbCrLf & " return " & parent.MapFTObj(m.ReturnType.ID.ToString).StoageType & vbCrLf
        Else
            If Parameters.Count > 0 Then
                s = s & vbCrLf & ")"
            End If
        End If


        s = s & vbCrLf & " as "



        o.ModuleName = "--Custom"
        o.Block = "--Body"
        o.OutNL(s)
        s = ""

        s1 = GetScript(m.SCRIPT)

        If s1 = "" Then
            s1 = "print 'to do'"
            '  Else
            '    s1
            '    's1 = ""
        End If

        s = s & s1 & vbCrLf
        s = s & vbCrLf & "/"

        o.ModuleName = "--Custom"
        o.Block = "--body"
        o.OutNL(s)

        System.Diagnostics.Debug.Print("ORAGEN.CreateMethod:done")
        Exit Sub
bye:

        'Resume
    End Sub

    Friend Function GetScript(ByVal scol As SCRIPT_col) As String
        Dim i As Long

        On Error GoTo bye
        For i = 1 To scol.Count
            If scol.Item(i).Target.ID.Equals(New Guid(tid)) Then
                Return scol.Item(i).Code
                Exit Function
            End If
        Next

bye:

        Return ""

    End Function


    Friend Function GetParameters(ByVal scol As SCRIPT_col) As PARAMETERS_col
        Dim i As Long

        On Error GoTo bye
        For i = 1 To scol.Count
            If scol.Item(i).Target.ID.Equals(New Guid(tid)) Then
                Return scol.Item(i).PARAMETERS
                Exit Function
            End If
        Next

bye:

        Return Nothing
    End Function

    Private Function MethodParam(ByVal f As PARAMETERS) As String
        System.Diagnostics.Debug.Print("ORAGEN.MethodParam:start")
        On Error GoTo bye

        Dim s As String, ftm As FIELDTYPEMAP
        s = "a" & VF(f.Name)

        If f.OutParam Then
            s = s & " out "
        End If

        ftm = parent.MapFTObj(f.TypeOfParm.ID.ToString)
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType  '& "(" & ftm.FixedSize & ")"
        Else
            s = s & " " & ftm.StoageType
            If CType(f.TypeOfParm, FIELDTYPE).AllowSize Then
                If f.DataSize <> 0 Then
                    s = s ' & " (" & f.DataSize & ")"
                Else
                    s = s '& " (1)"
                End If
            End If
        End If

        If f.OutParam = enumBoolean.Boolean_Net Then
            If f.AllowNull Then
                s = s & " := null "
            End If
        End If

        MethodParam = s & "/* " & f.Caption & " */"
        System.Diagnostics.Debug.Print("ORAGEN.MethodParam:done")
        Exit Function
bye:

        'Resume
    End Function
End Class
