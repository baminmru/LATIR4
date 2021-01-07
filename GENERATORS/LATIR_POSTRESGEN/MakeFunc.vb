Option Strict Off
Option Explicit On
Friend Class MakeFunc
	
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
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
		CreateFuncPackage()
		Dim j, i As Integer
        Dim os As MTZMetaModel.MTZMetaModel.PART
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



        Dim SQL As Writer
        SQL = New Writer

        SQL.putBuf("create or replace   function instance_BRIEF_F  (")
        SQL.putBuf(" ainstanceid uuid")
        SQL.putBuf(")returns varchar as $$ begin return 'INSTANCE'; end;  $$ language 'plpgsql';")
        SQL.putBuf("GO")

        o.Out(SQL.getBuf)

        o.ModuleName = "--Functions.Body"
        o.Block = "--body"
    
        SQL = Nothing
        SQL = New Writer
        SQL.putBuf(" create or replace  function instance_BRIEF_F  (")
        SQL.putBuf(" ainstanceid uuid")
        SQL.putBuf(")returns varchar as  $$")
        SQL.putBuf(" declare ")
        SQL.putBuf(" aBRIEF varchar(4000);")
        SQL.putBuf(" atmpCnt numeric;")
        SQL.putBuf(" begin")
        SQL.putBuf("if ainstanceid is null then aBRIEF:=''; return (aBRIEF); end if;")
        SQL.putBuf(" -- Brief body --")
        SQL.putBuf("select count(*) into aTmpCnt from instance where instanceID=ainstanceID;")
        SQL.putBuf("if aTmpCnt >0 then")
        SQL.putBuf("  aBRIEF:='';")
        SQL.putBuf("  select aBRIEF")
        SQL.putBuf("  ||  COALESCE(Name,' ')||'; ' into aBrief")
        SQL.putBuf("  from instance where  instanceID = ainstanceID;")
        SQL.putBuf("else ")
        SQL.putBuf("  aBRIEF:= 'неверный идентификатор';")
        SQL.putBuf("End if;")
        SQL.putBuf(" aBRIEF:=substr(aBRIEF,1,255);")
        SQL.putBuf("  return (aBRIEF);")
        SQL.putBuf("End; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        o.Out(SQL.getBuf)

    End Sub

    Private Sub CloseFuncPackage()
        o.ModuleName = "--Functions.Header"
        o.Block = "--body"
        'o.OutNL " end Func;"
        o.OutNL(";")
        o.ModuleName = "--Functions.Body"
        o.Block = "--body"
        'o.OutNL " end Func;"
        o.OutNL(";")
    End Sub


    Private Sub CreateBriefFunc(ByRef os As MTZMetaModel.MTZMetaModel.PART)

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As Writer
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        s = New Writer

        ' делаем отдельно заголовки функций
        CreateBriefFuncHdr(os)

        On Error GoTo bye

        s.putBuf("")
        s.putBuf("create or replace function " & VF(os.Name) & "_BRIEF_F  (")
        s.putBuf(" a" & VF(os.Name) & "id uuid")
        s.putBuf(") returns varchar as $$ ")
        s.putBuf(" declare ")
        s.putBuf(" aBRIEF varchar(255);")
        s.putBuf(" atmpStr varchar(255);")
        s.putBuf(" atmpBrief varchar(2000);")
        s.putBuf(" atmpID uuid;")
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
                ft = f.FieldType
             
                'enum
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                    s.putBuf("  select  aBRIEF ||")
                    s.putBuf("  (case " & VF(f.Name) & " ")
                    For j = 1 To ft.ENUMITEM.Count
                        s.putBuf(" when " & ft.ENUMITEM.Item(j).NameValue)
                        s.putBuf("  then '" & ft.ENUMITEM.Item(j).Name & "'")
                    Next
                    s.putBuf(" else '.' end ) into aBrief from " & VF(st.Name) & " where " & VF(os.Name) & "ID=a" & VF(os.Name) & "ID;")

                ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    s.putBuf("select " & VF(f.Name))
                    s.putBuf(" into atmpID  from " & VF(os.Name) & "  where  " & VF(os.Name) & "ID = a" & VF(os.Name) & "ID ;")
                    If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        s.putBuf(" atmpBrief:=  Instance_BRIEF_F( atmpID);")
                    End If
                    If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        s.putBuf(" atmpBrief :=  " & VF(CType(f.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name) & "_BRIEF_F(atmpID);")
                    End If
                    s.putBuf("  aBRIEF:= aBRIEF || '{' || COALESCE(atmpbrief,' ') || '}; ';")
                Else
                    s.putBuf(" select aBRIEF ")
                    If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                        s.putBuf("  ||  COALESCE(to_char(" & VF(st.FIELD.Item(i).Name) & ",'DD.MM.YYYY HH24:MI:SS'),' ') || ';' ")
                    Else
                        s.putBuf("  ||  COALESCE(cast(" & VF(st.FIELD.Item(i).Name) & " as varchar),' ') || ';' ")
                    End If

                    s.putBuf("  into aBrief from " & VF(os.Name) & "  where  " & VF(os.Name) & "ID = a" & VF(os.Name) & "ID; ")
                End If
            End If
        Next
        s.putBuf(" else ")
        s.putBuf("  aBRIEF:= '-';")
        s.putBuf("end if;")
        s.putBuf(" aBRIEF:=substr(aBRIEF,1,255);")
        s.putBuf("return (aBRIEF);")
        s.putBuf("end; $$ language 'plpgsql';")
        s.putBuf("GO")


        'Debug.Print os.Name

        o.ModuleName = "--Functions.Body"
        o.Block = "--body"
        o.OutNL(s.getBuf)

        s = Nothing
        Exit Sub
bye:
        
        s = Nothing
    End Sub


    Private Sub CreateBriefFuncHdr(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateBriefFuncHdr:start " & os.Caption)
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As String



        On Error GoTo bye
        s = ""
        s = s & vbCrLf & "create or replace function " & VF(os.Name) & "_BRIEF_F  ("
        s = s & vbCrLf & " a" & VF(os.Name) & "id uuid"
        s = s & vbCrLf & ") returns varchar  as $$ begin return '" & os.Name & "'; end; $$ language 'plpgsql';"
        s = s & vbCrLf & "GO"

        Debug.Print(os.Name)

        o.ModuleName = "--Functions.Header"
        o.Block = "--body"
        o.OutNL(s)

        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateBriefFuncHdr:done " & os.Caption)
        Exit Sub
bye:
   

    End Sub


    Private Sub CreateStructBriefFunc(ByRef os As MTZMetaModel.MTZMetaModel.PART)

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        System.Windows.Forms.Application.DoEvents()
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short



        CreateBriefFunc(os)

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            CreateStructBriefFunc(chos)
        Next


        Exit Sub
bye:


    End Sub
End Class