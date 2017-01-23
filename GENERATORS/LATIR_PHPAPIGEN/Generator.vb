Option Strict Off
Option Explicit On

Public Class Generator
    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim o As LATIRGenerator.Response
    Dim tid As String
    Dim log As String

    Dim _LATIRManagerPath As String = String.Empty


    Public Property LATIRManagerPath() As String
        Get
            Return _LATIRManagerPath
        End Get
        Set(ByVal value As String)
            _LATIRManagerPath = value
        End Set
    End Property





    'DateTime vSource;
    '      DateTime vDest = System.DateTime.MinValue;
    '      long Ticks;
    '      vSource = System.DateTime.Now;
    '      Ticks = vSource.Ticks ;
    '
    '      vDest = vDest.AddTicks(Ticks);
    '      System.Diagnostics.Trace.WriteLine (vSource.ToString());
    '      System.Diagnostics.Trace.WriteLine (vDest.ToString());
    Public Function Setup() As Boolean
        Dim Form1 As New frmConfig
        Form1.txtPath.Text = _LATIRManagerPath
        Form1.ShowDialog()
        If Form1.OK Then
            _LATIRManagerPath = Form1.txtPath.Text
            My.Settings.LTOBJMAN = _LATIRManagerPath
            My.Settings.Save()
            'SaveSetting("MTZ", "ASPNETGEN", "MKSNPATH", mksnPath)
            Return True
        Else
            Return False
        End If
    End Function


    ' method for activate generation process
    Public Function Run(ByRef Model As Object, ByRef Output As Object, ByRef targetid As String, Optional ByRef TypeID As String = "") As String
        m = Model
        o = Output
        tid = targetid
        log = ""

        Dim i, j As Integer
        Dim desc, body As String
        Dim os As MTZMetaModel.MTZMetaModel.PART

        On Error GoTo bye
        _LATIRManagerPath = My.Settings.LTOBJMAN
        'mksnPath = GetSetting("MTZ", "ASPNETGEN", "MKSNPATH", My.Application.Info.DirectoryPath & "\MKSNManager\MKSNManager.dll")

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        If TypeID = String.Empty Then
            log = log & vbCrLf & "Define TYPE ID!!!"
            Run = String.Empty
            Exit Function
        End If
        ot = m.OBJECTTYPE.Item(TypeID)
        If ot Is Nothing Then
            log = log & vbCrLf & "Wrong TYPE ID!!!"
            Run = String.Empty
            Exit Function
        End If

        o.Project.Attributes.Add("Name").Value = ot.Name
        o.Project.Attributes.Add("ID").Value = ot.ID.ToString()
        o.Project.Attributes.Add("asmName").Value = ot.Name
        MakePRJ(ot, o, _LATIRManagerPath)

        log = log & vbCrLf & "Create code for type " & ot.Name

        ' crate application class
        MakeApps(tid, m, ot, o)

        ' crate application classes
        MakeParents(ot, o)


        ' create classes for each part
        For j = 1 To ot.PART.Count
            os = ot.PART.Item(j)
            MakeRow(tid, m, ot, os, o)
            MakeColls(tid, m, ot, os, o)
        Next

        ' return results
        Run = log

        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
        MsgBox(Err.Description)
        Stop
        Resume
        Run = log

    End Function





    ' return script code for specified generation target
    Private Function MapScript(ByVal sc As MTZMetaModel.MTZMetaModel.SCRIPT_col) As String
        On Error GoTo bye
        Dim i As Object

        For i = 1 To sc.Count
            'UPGRADE_WARNING: Couldn't resolve default property of object sc.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If sc.Item(i).Target.ID.ToString() = tid Then
                MapScript = sc.Item(i).Code
                Exit Function
            End If
        Next
        MapScript = String.Empty
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        Stop
        Resume
    End Function


    ' same as MAPFT, but return fieldtypemap object
    Private Function MapFTObj(ByVal TypeID As String) As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        On Error GoTo bye
        MapFTObj = Nothing
        Dim i, s As Object
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = m.FIELDTYPE.Item(TypeID)
        If ft Is Nothing Then
            Exit Function
        End If
        For i = 1 To ft.FIELDTYPEMAP.Count
            Dim FIELDTYPEMAP As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
            FIELDTYPEMAP = ft.FIELDTYPEMAP.Item(i)
            If (FIELDTYPEMAP.Target.ID.ToString() = tid) Then
                MapFTObj = ft.FIELDTYPEMAP.Item(i)
                Exit For
            End If
        Next
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        Stop
        Resume
    End Function

    ' Create custom code for class code extracted from Meta model
    Private Function MakeMethodCode(ByRef sm As MTZMetaModel.MTZMetaModel.SHAREDMETHOD) As String
        Dim out As String = String.Empty
        Dim scr As String = String.Empty
        Dim i As Integer
        Dim p As MTZMetaModel.MTZMetaModel.PARAMETERS
        scr = MapScript(sm.SCRIPT)
        If scr = String.Empty Then
            MakeMethodCode = String.Empty
            Exit Function
        End If
        out = out & vbCrLf & "'" & NoLF(sm.the_Comment)
        out = out & vbCrLf & "'" & sm.ID.ToString()

        If sm.ReturnType Is Nothing Then
            out = out & vbCrLf & "public sub Run_" & sm.Name & " ("
        Else
            out = out & vbCrLf & "public function Run_" & sm.Name & " ("
        End If

        Dim params As MTZMetaModel.MTZMetaModel.PARAMETERS_col
        params = GetParameters(sm.SCRIPT, tid)
        For i = 1 To params.Count
            p = params.Item(i)
            If i > 1 Then out = out & ","
            If p.AllowNull Then out = out & " Optional "
            out = out & p.Name & " as " & MapFT(m, p.TypeOfParm.ID.ToString(), tid)
        Next
        out = out & ")"
        out = out & vbCrLf & scr


        If sm.ReturnType Is Nothing Then
            out = out & vbCrLf & "end sub"
        Else
            out = out & vbCrLf & "end function"
        End If
        out = out & vbCrLf
        out = out & vbCrLf
        MakeMethodCode = out
    End Function



    ' create class for all part



    'Make _COL class for each part







    ' when class work in offline mode - offline brief algoritm used
    Private Function MakeOfflineBriefProc(ByRef os As MTZMetaModel.MTZMetaModel.PART) As String
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As String = String.Empty

        On Error GoTo bye

        s = s & vbCrLf & "  m_BRIEF="""""
        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            If st.FIELD.Item(i).IsBrief Then
                f = st.FIELD.Item(i)
                s = s & vbCrLf & "  m_BRIEF= m_BRIEF & """ & NoLF(f.Caption) & "="""

                'enum
                Dim FieldType As MTZMetaModel.MTZMetaModel.FIELDTYPE
                FieldType = st.FIELD.Item(i).FieldType
                If FieldType.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                    s = s & vbCrLf & "select case " & st.FIELD.Item(i).Name
                    'UPGRADE_WARNING: Couldn't resolve default property of object st.FIELD.Item(i).FIELDTYPE.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Dim ENUMITEM_col As MTZMetaModel.MTZMetaModel.ENUMITEM_col
                    ENUMITEM_col = FieldType.ENUMITEM
                    For j = 1 To ENUMITEM_col.Count
                        'UPGRADE_WARNING: Couldn't resolve default property of object st.FIELD.Item().FIELDTYPE.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object st.FIELD.Item().FIELDTYPE.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        s = s & vbCrLf & "case " & MakeValidName(FieldType.Name) & "_" & MakeValidName(ENUMITEM_col.Item(j).Name)
                        'UPGRADE_WARNING: Couldn't resolve default property of object st.FIELD.Item().FIELDTYPE.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        s = s & vbCrLf & "   m_BRIEF=m_BRIEF &  """ & ENUMITEM_col.Item(j).Name & "; """
                    Next
                    s = s & vbCrLf & "end select '" & st.FIELD.Item(i).Name
                    'UPGRADE_WARNING: Couldn't resolve default property of object st.FIELD.Item(i).FIELDTYPE.TypeStyle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf FieldType.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    s = s & vbCrLf & "   if  " & st.FIELD.Item(i).Name & " is nothing then "
                    s = s & vbCrLf & "     m_BRIEF=m_BRIEF & ""{"" & m_" & st.FIELD.Item(i).Name & "_ID_BRIEF & ""}; """
                    s = s & vbCrLf & "   else"
                    s = s & vbCrLf & "     m_BRIEF=m_BRIEF & ""{"" & " & st.FIELD.Item(i).Name & ".Brief  & ""}; """
                    s = s & vbCrLf & "   end if"
                Else
                    s = s & vbCrLf & " m_BRIEF= m_BRIEF & " & st.FIELD.Item(i).Name & " & ""; """

                End If
            End If
        Next
        s = s & vbCrLf & " BRIEF= m_BRIEF"
        MakeOfflineBriefProc = s

        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume

    End Function


    'Insert enum declarations to Application class



    ' Lock / Unlock support for all classes
    Private Sub MakeLockable(ByRef decl As String, ByRef body As String, ByVal Coll As Boolean, ByRef pt As MTZMetaModel.MTZMetaModel.PART)
        On Error GoTo bye


        ' declare variables
        decl = decl & vbCrLf & "private m_IsLocked as  LockStyle"


        'CanChange
        body = body & vbCrLf & "' может ли быть изменено"
        body = body & vbCrLf & "public property Get CanChange() as boolean"
        body = body & vbCrLf & "   if application.workoffline then"
        body = body & vbCrLf & "     CanChange =  CanChangeoffLine "
        body = body & vbCrLf & "   else  "
        body = body & vbCrLf & "     CanChange =  canchangeonline"
        body = body & vbCrLf & "   end if"
        body = body & vbCrLf & "end property"



        ' CanChangeOffline
        body = body & vbCrLf & "' может ли быть изменено в режиме Offline"
        body = body & vbCrLf & "public property Get CanChangeOffline() as boolean"
        body = body & vbCrLf & "  dim test as boolean"
        body = body & vbCrLf & "  if not parent is nothing then"
        body = body & vbCrLf & "   test = parent.CanChangeOffline"
        body = body & vbCrLf & "  end if"
        body = body & vbCrLf & "  if not test  then "
        body = body & vbCrLf & "   test = (IsLocked = LockPermanent)"
        body = body & vbCrLf & "  end if"
        body = body & vbCrLf & "   CanChangeOffline = test"
        body = body & vbCrLf & "end property"

        ' CanChangeONline
        body = body & vbCrLf & "' может ли быть изменено в режиме ONline"
        body = body & vbCrLf & "public property Get CanChangeONLine() as boolean"
        body = body & vbCrLf & "  dim test as boolean"
        body = body & vbCrLf & "  if not parent is nothing then"
        body = body & vbCrLf & "   test = parent.CanChangeONLine"
        body = body & vbCrLf & "  end if"
        body = body & vbCrLf & "  if  not test then "
        body = body & vbCrLf & "   test = (IsLocked < ExternalLockSession)"
        body = body & vbCrLf & "  end if"
        body = body & vbCrLf & "   CanChangeOnline = test"
        body = body & vbCrLf & "end property"


        'IsLocked
        body = body & vbCrLf & "friend property Let IsLocked(newIsLocked as LockStyle)"
        body = body & vbCrLf & "  m_IsLocked = newIsLocked"
        body = body & vbCrLf & "end property"

        body = body & vbCrLf & "' User has locked record"
        body = body & vbCrLf & "public property Get IsLocked() as LockStyle"
        body = body & vbCrLf & "  if m_IsLocked <> LockSession and m_IsLocked <> LockPermanent then CheckLock"
        body = body & vbCrLf & "  IsLocked = m_IsLocked"
        body = body & vbCrLf & "end property"

        ' CheckLock
        body = body & vbCrLf & "private sub CheckLock()"
        body = body & vbCrLf & "static LastCheckTime as date"
        body = body & vbCrLf & "if application.WorkOffline then exit sub"
        body = body & vbCrLf & "If Now - LastCheckTime < CDbl(CDate(""00:00:10"")) Then Exit Sub"
        body = body & vbCrLf & "Dim nv As NamedValues, LockType As Long"
        body = body & vbCrLf & "Set nv = New NamedValues"
        If Not Coll Then
            body = body & vbCrLf & "nv.Add ""ROWID"", id"
        Else
            body = body & vbCrLf & "nv.Add ""ROWID"", parent.id"
        End If
        body = body & vbCrLf & "nv.Add ""IsLocked"", LockType"
        body = body & vbCrLf & "On Error Resume Next"
        If pt Is Nothing Then
            body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_ISLOCKED"", nv"
        Else
            If Not Coll Then
                body = body & vbCrLf & "Application.MTZSession.Exec """ & pt.Name & "_ISLOCKED"", nv"
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object pt.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                If TypeName(pt.Parent.Parent) = "OBJECTTYPE" Then
                    body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_ISLOCKED"", nv"
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object pt.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    body = body & vbCrLf & "Application.MTZSession.Exec """ & pt.Parent.Parent.name & "_ISLOCKED"", nv"
                End If
            End If
        End If
        body = body & vbCrLf & "m_IsLocked = nv.item(""ISLocked"").Value"
        body = body & vbCrLf & "Set nv = nothing"
        body = body & vbCrLf & "LastCheckTime = now"
        body = body & vbCrLf & "end sub"


        body = body & vbCrLf & "public function LockResource(optional byval Permanent as boolean=false ) as boolean"
        body = body & vbCrLf & "if application.WorkOffline then exit function"
        body = body & vbCrLf & "  dim OK "
        body = body & vbCrLf & "  Dim nv As NamedValues"
        body = body & vbCrLf & "  Set nv =  New NamedValues"
        If Not Coll Then
            body = body & vbCrLf & "nv.Add ""ROWID"", id"
        Else
            body = body & vbCrLf & "nv.Add ""ROWID"", parent.id"
        End If

        body = body & vbCrLf & "  On Error GoTo bye"

        body = body & vbCrLf & "  If Not Permanent Then"
        body = body & vbCrLf & "      nv.Add ""LOCKMODE"", 1"
        body = body & vbCrLf & "  Else"
        body = body & vbCrLf & "      nv.Add ""LOCKMODE"", 2"
        body = body & vbCrLf & "  End If"

        If pt Is Nothing Then
            body = body & vbCrLf & "ok=Application.MTZSession.Exec( ""INSTANCE_LOCK"", nv)"
        Else
            If Not Coll Then
                body = body & vbCrLf & "ok=Application.MTZSession.Exec( """ & pt.Name & "_LOCK"", nv)"
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object pt.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                If TypeName(pt.Parent.Parent) = "OBJECTTYPE" Then
                    body = body & vbCrLf & "ok =Application.MTZSession.Exec( ""INSTANCE_LOCK"", nv)"
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object pt.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    body = body & vbCrLf & "ok=Application.MTZSession.Exec (""" & pt.Parent.Parent.name & "_LOCK"", nv)"
                End If
            End If
        End If

        body = body & vbCrLf & "  if OK then  "
        body = body & vbCrLf & "    if Permanent then m_IsLocked = LockPermanent else m_IsLocked = LockSession"
        body = body & vbCrLf & "  else"
        body = body & vbCrLf & "    m_IsLocked = NoLock"
        body = body & vbCrLf & "  end if"

        body = body & vbCrLf & "bye:"
        body = body & vbCrLf & "Set nv = nothing"
        body = body & vbCrLf & "end function"

        body = body & vbCrLf & "public function UnLockResource() as boolean"
        body = body & vbCrLf & "if application.WorkOffline then exit function"
        body = body & vbCrLf & " Dim nv As NamedValues"
        body = body & vbCrLf & "Set nv =  New NamedValues"
        If Not Coll Then
            body = body & vbCrLf & "nv.Add ""ROWID"", id"
        Else
            body = body & vbCrLf & "nv.Add ""ROWID"", parent.id"
        End If
        body = body & vbCrLf & "On Error GoTo bye"
        If pt Is Nothing Then
            body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_UNLOCK"", nv"
        Else
            If Not Coll Then
                body = body & vbCrLf & "Application.MTZSession.Exec """ & pt.Name & "_UNLOCK"", nv"
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object pt.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                If TypeName(pt.Parent.Parent) = "OBJECTTYPE" Then
                    body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_UNLOCK"", nv"
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object pt.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    body = body & vbCrLf & "Application.MTZSession.Exec """ & pt.Parent.Parent.name & "_UNLOCK"", nv"
                End If
            End If
        End If
        body = body & vbCrLf & ""
        body = body & vbCrLf & "m_IsLocked = NoLock"
        body = body & vbCrLf & "bye:"
        body = body & vbCrLf & "Set nv = nothing"
        body = body & vbCrLf & "end function"


        body = body & vbCrLf & "public function CanLock() as boolean"
        body = body & vbCrLf & "if application.WorkOffline then exit function"
        body = body & vbCrLf & "Dim nv As NamedValues, notLocked As Long"
        body = body & vbCrLf & "Set nv = New NamedValues"
        If Not Coll Then
            body = body & vbCrLf & "nv.Add ""ROWID"", id"
        Else
            body = body & vbCrLf & "nv.Add ""ROWID"", parent.id & ChildPartName"
        End If
        body = body & vbCrLf & "nv.Add ""LockMode"", notLocked"
        body = body & vbCrLf & "notLocked = 0"
        body = body & vbCrLf & "On Error Resume Next"

        If pt Is Nothing Then
            body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_HCL"", nv"
        Else
            If Not Coll Then
                body = body & vbCrLf & "Application.MTZSession.Exec """ & pt.Name & "_HCL"", nv"
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object pt.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                If TypeName(pt.Parent.Parent) = "OBJECTTYPE" Then
                    body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_HCL"", nv"
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object pt.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    body = body & vbCrLf & "Application.MTZSession.Exec """ & pt.Parent.Parent.name & "_HCL"", nv"
                End If
            End If
        End If

        body = body & vbCrLf & "If nv.Item(""LockMode"").Value = 0 Then"
        body = body & vbCrLf & " CanLock = True"
        body = body & vbCrLf & "Else"
        body = body & vbCrLf & " CanLock = False"
        body = body & vbCrLf & "End If"
        body = body & vbCrLf & "Set nv = nothing"
        body = body & vbCrLf & "end function"
bye:
    End Sub



    Public Sub New()
        MyBase.New()
        _LATIRManagerPath = My.Settings.LTOBJMAN
    End Sub
End Class