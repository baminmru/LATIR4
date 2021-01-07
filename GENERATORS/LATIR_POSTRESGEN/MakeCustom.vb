Option Strict Off
Option Explicit On
Friend Class MakeCustom
	
    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim o As LATIRGenerator.Response
    Dim tid As String
    Dim parent As Generator

    Public Sub Init(ByRef ap As Generator, ByRef am As MTZMetaModel.MTZMetaModel.Application, ByRef ao As LATIRGenerator.Response, ByVal atid As String)
        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub

    Public Sub Run()
        Dim i As Integer
        For i = 1 To m.SHAREDMETHOD.Count
            CreateMethod(m.SHAREDMETHOD.Item(i))

        Next

        'ManualCode
        o.ModuleName = "--Custom"
        o.Block = "--body"

        Dim targ As MTZMetaModel.MTZMetaModel.GENERATOR_TARGET
        Dim mc As MTZMetaModel.MTZMetaModel.GENMANUALCODE
        targ = m.FindRowObject("GENERATOR_TARGET", New Guid(tid))
        For i = 1 To targ.GENMANUALCODE.Count
            mc = targ.GENMANUALCODE.Item(i)
            o.OutNL("/*" & mc.Name & " (" & mc.the_Alias & ")*/")
            o.OutNL(mc.Code)
            o.OutNL(";")
            o.OutNL("GO")
        Next
    End Sub


    Private Sub CreateMethod(ByRef m As MTZMetaModel.MTZMetaModel.SHAREDMETHOD)
        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateMethod:start")
        On Error GoTo bye
        Dim p As MTZMetaModel.MTZMetaModel.PARAMETERS
        Dim i As Integer
        Dim s, s1 As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        Dim Parameters As MTZMetaModel.MTZMetaModel.PARAMETERS_col
        s1 = GetScript(m.SCRIPT)

        If s1 = "" Then Exit Sub


        Parameters = GetParameters(m.SCRIPT)
        s = "/* " & m.Name & "  " & m.the_Comment & "*/"
        If m.ReturnType Is Nothing Then
            s = s & vbCrLf & "create or replace function " & m.Name & vbCrLf
            'If Parameters.Count > 0 Then
            s = s & vbCrLf & "("
            'End If
        Else
            s = "create or replace function " & m.Name & vbCrLf
        End If



        Parameters.Sort = "sequence"
        Dim pCnt As Short
        pCnt = 0
        For i = 1 To Parameters.Count
            p = Parameters.Item(i)
            If p.OutParam = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                If pCnt > 0 Then s = s & vbCrLf & ","
                s = s & MethodParam(p) & vbCrLf
                pCnt = pCnt + 1
            End If
        Next

        '  If Not m.ReturnType Is Nothing Then
        '    s = s & vbCrLf & ") "
        '    s = s & vbCrLf & " returns " & parent.MapFTObj(m.ReturnType.ID).StoageType & vbCrLf
        '  Else
        'If Parameters.Count > 0 Then
        s = s & vbCrLf & ")  "
        'End If
        '    s = s & vbCrLf & " returns void "
        '  End If
        '
        '
        '  s = s & vbCrLf & " as $$"
        '
        '

        o.ModuleName = "--Custom"
        o.Block = "--Body"
        o.OutNL(s)
        s = ""

        s1 = GetScript(m.SCRIPT)



        s = s & s1 & vbCrLf
        ' s = s & vbCrLf & " $$ language 'plpgsql';"

        o.ModuleName = "--Custom"
        o.Block = "--body"
        o.OutNL(s)
        o.OutNL("GO")

        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateMethod:done")
        Exit Sub
bye:

        'Resume
    End Sub

    Friend Function GetScript(ByRef scol As MTZMetaModel.MTZMetaModel.SCRIPT_col) As String
        Dim i As Integer
        GetScript = ""
        On Error GoTo bye
        For i = 1 To scol.Count
            If scol.Item(i).Target.ID.ToString = tid Then
                GetScript = scol.Item(i).Code
                Exit Function
            End If
        Next
        Exit Function
bye:



    End Function


    Friend Function GetParameters(ByRef scol As MTZMetaModel.MTZMetaModel.SCRIPT_col) As MTZMetaModel.MTZMetaModel.PARAMETERS_col
        Dim i As Integer

        On Error GoTo bye
        For i = 1 To scol.Count

            If scol.Item(i).Target.ID.ToString = tid Then
                Return scol.Item(i).PARAMETERS
                Exit Function
            End If
        Next

bye:

        Return Nothing
    End Function

    Private Function MethodParam(ByRef f As MTZMetaModel.MTZMetaModel.PARAMETERS) As String
        System.Diagnostics.Debug.Print("POSTGRESGEN.MethodParam:start")
        On Error GoTo bye

        Dim s As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        s = "a" & VF(f.Name)
        ft = f.TypeOfParm
        If f.OutParam Then
            s = s & " out "
        End If

        ftm = parent.MapFTObj(f.TypeOfParm.ID.ToString)
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType '& "(" & ftm.FixedSize & ")"
        Else
            s = s & " " & ftm.StoageType

            If ft.AllowSize Then
                If f.DataSize <> 0 Then
                    s = s ' & " (" & f.DataSize & ")"
                Else
                    s = s '& " (1)"
                End If
            End If
        End If

        If f.OutParam = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
            If f.AllowNull Then
                s = s '& " := null "
            End If
        End If

        MethodParam = s & "/* " & f.Caption & " */"
        System.Diagnostics.Debug.Print("POSTGRESGEN.MethodParam:done")
        Exit Function
bye:

        'Resume
    End Function
End Class