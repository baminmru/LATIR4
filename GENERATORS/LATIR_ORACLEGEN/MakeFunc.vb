Imports LATIRGenerator
Imports MTZMetaModel.MTZMetaModel


Public Class MakeFunc
    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim o As LatirGenerator.Response
    Dim tid As String
    Dim parent As Generator

    Public Sub Init(ByVal ap As Generator, ByVal am As MTZMetaModel.MTZMetaModel.Application, ByVal ao As LatirGenerator.Response, ByVal atid As String)
        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub


    Public Sub Run()
        Dim ot As OBJECTTYPE
        CreateFuncPackage()
        Dim j As Long, i As Long
        Dim os As PART

        For i = 1 To m.OBJECTTYPE.Count
            ot = m.OBJECTTYPE.Item(i)
            For j = 1 To ot.PART.Count
                os = ot.PART.Item(j)
                CreateStructBriefFunc(os)
                o.Status("Brief Function " & os.Caption, i)
            Next

        Next
        CloseFuncPackage()
    End Sub

    Private Sub CreateFuncPackage()
        o.ModuleName = "--Functions.Header"
        o.Block = "--body"
        o.OutNL(" create or replace package Func as")


        Dim SQL As Writer
        SQL = New Writer

        SQL.putBuf("  function instance_BRIEF_F  (")
        SQL.putBuf(" ainstanceid CHAR")
        SQL.putBuf(")return varchar2;")
        o.out(SQL.getBuf)

        o.ModuleName = "--Functions.Body"
        o.Block = "--body"
        o.OutNL(" create or replace package body Func as")

        SQL = Nothing
        SQL = New Writer
        SQL.putBuf("  function instance_BRIEF_F  (")
        SQL.putBuf(" ainstanceid CHAR")
        SQL.putBuf(")return varchar2 as  ")
        SQL.putBuf(" aBRIEF varchar2(4000);")
        SQL.putBuf(" atmpCnt numeric;")
        SQL.putBuf(" begin")
        SQL.putBuf("if ainstanceid is null then aBRIEF:=''; return (aBRIEF); end if;")
        SQL.putBuf(" -- Brief body --")
        SQL.putBuf("select count(*) into aTmpCnt from instance where instanceID=ainstanceID;")
        SQL.putBuf("if aTmpCnt >0 then")
        SQL.putBuf("  aBRIEF:='';")
        SQL.putBuf("  select aBRIEF")
        SQL.putBuf("  ||  nvl(Name,' ')||'; ' into aBrief")
        SQL.putBuf("  from instance where  instanceID = ainstanceID;")
        SQL.putBuf("else ")
        SQL.putBuf("  aBRIEF:= 'неверный идентификатор';")
        SQL.putBuf("End if;")
        SQL.putBuf(" aBRIEF:=substr(aBRIEF,1,255);")
        SQL.putBuf("  return (aBRIEF);")
        SQL.putBuf("End;")

        o.out(SQL.getBuf)

    End Sub

    Private Sub CloseFuncPackage()
        o.ModuleName = "--Functions.Header"
        o.Block = "--body"
        o.OutNL(" end Func;")
        o.OutNL("/")
        o.ModuleName = "--Functions.Body"
        o.Block = "--body"
        o.OutNL(" end Func;")
        o.OutNL("/")
    End Sub


    Private Sub CreateBriefFunc(ByVal os As PART)
        System.Diagnostics.Debug.Print("ORAGEN.CreateBriefFunc:start " & os.Caption)
        Dim st As PART
        st = os
        Dim chos As PART, i As Long, j As Long, f As FIELD
        Dim ft As FIELDTYPE
        Dim s As Writer
        s = New Writer

        ' делаем отдельно заголовки функций
        CreateBriefFuncHdr(os)

        On Error GoTo bye

        s.putBuf("")
        s.putBuf("function " & VF(os.Name) & "_BRIEF_F  (")
        s.putBuf(" a" & VF(os.Name) & "id CHAR")
        s.putBuf(") return varchar2 as ")
        s.putBuf(" aBRIEF varchar2(255);")
        s.putBuf(" atmpStr varchar2(255);")
        s.putBuf(" atmpBrief varchar2(2000);")
        s.putBuf(" atmpID CHAR(38);")
        s.putBuf(" atmpCnt Numeric;")
        s.putBuf(" begin  ")

        s.putBuf("if a" & VF(os.Name) & "id is null  then  aBRIEF:=' '; return (aBRIEF); end if;")
        s.putBuf(" -- Brief body -- ")
        s.putBuf("select count(*) into aTmpCnt from " & VF(os.Name) & " where " & VF(os.Name) & "ID=a" & VF(os.Name) & "ID;")
        s.putBuf("if aTmpCnt >0 then")
        s.putBuf("  aBRIEF:='';")

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            If st.FIELD.Item(i).IsBrief Then
                f = st.FIELD.Item(i)
                's.putbuf "  set aBRIEF= aBRIEF || '" & F.Caption & "='"
                ft = f.FieldType
                'enum
                If ft.TypeStyle = enumTypeStyle.TypeStyle_Perecislenie Then

                    s.putBuf("  select  aBRIEF ||")
                    s.putBuf("  Decode( " & VF(f.Name))
                    For j = 1 To ft.ENUMITEM.Count
                        s.putBuf(" ," & ft.ENUMITEM.Item(j).NameValue)
                        s.putBuf(" ,'" & ft.ENUMITEM.Item(j).Name & "'")
                    Next
                    s.putBuf(",'.') into aBrief from " & VF(st.Name) & " where " & VF(os.Name) & "ID=a" & VF(os.Name) & "ID;")

                ElseIf ft.TypeStyle = enumTypeStyle.TypeStyle_Ssilka Then
                    s.putBuf("select " & VF(f.Name))
                    s.putBuf(" into atmpID  from " & VF(os.Name) & "  where  " & VF(os.Name) & "ID = a" & VF(os.Name) & "ID ;")
                    If f.ReferenceType = enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        s.putBuf(" atmpBrief:= Func.Instance_BRIEF_F( atmpID);")
                    End If
                    If f.ReferenceType = enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        s.putBuf(" atmpBrief := func." & VF(CType(f.RefToPart, PART).Name) & "_BRIEF_F(atmpID);")
                    End If
                    s.putBuf("  aBRIEF:= aBRIEF || '{' || nvl(atmpbrief,' ') || '}; ';")
                Else
                    s.putBuf(" select aBRIEF ")
                    s.putBuf("  ||  nvl(to_char(" & VF(st.FIELD.Item(i).Name) & "),' ') ||'; '")
                    s.putBuf("  into aBrief from " & VF(os.Name) & "  where  " & VF(os.Name) & "ID = a" & VF(os.Name) & "ID; ")
                End If
            End If
        Next
        s.putBuf(" else ")
        s.putBuf("  aBRIEF:= '-';")
        s.putBuf("end if;")
        s.putBuf(" aBRIEF:=substr(aBRIEF,1,255);")
        s.putBuf("return (aBRIEF);")
        s.putBuf("end;")


        'Debug.Print os.Name

        o.ModuleName = "--Functions.Body"
        o.Block = "--body"
        o.OutNL(s.getBuf)

        System.Diagnostics.Debug.Print("ORAGEN.CreateBriefFunc:done " & os.Caption)
        s = Nothing
        Exit Sub
bye:
     
        s = Nothing
    End Sub


    Private Sub CreateBriefFuncHdr(ByVal os As PART)
        System.Diagnostics.Debug.Print("ORAGEN.CreateBriefFuncHdr:start " & os.Caption)
        Dim st As PART
        st = os
        Dim chos As PART, i As Long, j As Long, f As FIELD
        Dim s As String



        On Error GoTo bye
        s = ""
        s = s & vbCrLf & " function " & VF(os.Name) & "_BRIEF_F  ("
        s = s & vbCrLf & " a" & VF(os.Name) & "id CHAR"
        s = s & vbCrLf & ") return varchar2;"

        Debug.Print(os.Name)

        o.ModuleName = "--Functions.Header"
        o.Block = "--body"
        o.OutNL(s)

        System.Diagnostics.Debug.Print("ORAGEN.CreateBriefFuncHdr:done " & os.Caption)
        Exit Sub
bye:
      

    End Sub


    Private Sub CreateStructBriefFunc(ByVal os As PART)

        Dim st As PART
        st = os
        ' DoEvents()
        Dim chos As PART, i As Integer



        CreateBriefFunc(os)

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            CreateStructBriefFunc(chos)
        Next


        Exit Sub
bye:


    End Sub
End Class