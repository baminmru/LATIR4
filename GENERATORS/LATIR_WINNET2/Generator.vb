Option Strict Off
Option Explicit On

Public Class Generator
    Dim m As MTZMetaModel.MTZMetaModel.Application = Nothing
    Dim o As LATIRGenerator.Response = Nothing
    Dim tid As String = String.Empty
    Dim log As String = String.Empty
    Dim LATIRPath As String = String.Empty
    Dim GUIPath As String = String.Empty
    Dim ControlPath As String = String.Empty
    Dim Level2 As String = String.Empty





    Public ReadOnly Property LATIRManagerPath() As String
        Get
            Return LATIRPath
        End Get
    End Property

    Public ReadOnly Property GUIManagerPath() As String
        Get
            Return GUIPath
        End Get
    End Property

    Public ReadOnly Property GUIControlPath() As String
        Get
            Return ControlPath
        End Get
    End Property

    Public ReadOnly Property DLLPath() As String
        Get
            Return Level2
        End Get
    End Property

    Public Function Setup() As Boolean
        Dim f As Form1
        f = New Form1

        LATIRPath = GetSetting("LATIR4", "CFG", "LATIRPATH")
        If (LATIRPath = String.Empty) Then
            LATIRPath = My.Application.Info.DirectoryPath & "\Ltobjman.dll"
        End If

        GUIPath = GetSetting("LATIR4", "CFG", "GUIMANPATH")
        If (GUIPath = String.Empty) Then
            GUIPath = My.Application.Info.DirectoryPath & "\LATIR2GuiManager.dll"
        End If

        ControlPath = GetSetting("LATIR4", "CFG", "GUICTRLPATH")
        If (ControlPath = String.Empty) Then
            ControlPath = My.Application.Info.DirectoryPath & "\LATIR2GUIManager.dll"
        End If

        Level2 = GetSetting("LATIR4", "CFG", "LEVEL2PATH")
        If (Level2 = String.Empty) Then
            Level2 = My.Application.Info.DirectoryPath
        End If

        f.txtPath.Text = LATIRPath
        f.txtGUIManager.Text = GUIPath
        f.txtControls.Text = ControlPath
        f.txtLevel2.Text = Level2
        f.ShowDialog()
        If f.OK Then
            SaveSetting("LATIR4", "CFG", "LATIRPATH", f.txtPath.Text)
            SaveSetting("LATIR4", "CFG", "GUIMANPATH", f.txtGUIManager.Text)
            SaveSetting("LATIR4", "CFG", "GUICTRLPATH", f.txtControls.Text)
            SaveSetting("LATIR4", "CFG", "LEVEL2PATH", f.txtLevel2.Text)

            f.Close()
            Return True
        Else
            f.Close()
            Return False
        End If
        f.Close()
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

        Try
            LATIRPath = GetSetting("LATIR4", "CFG", "LATIRPATH")
            GUIPath = GetSetting("LATIR4", "CFG", "GUIMANPATH")
            ControlPath = GetSetting("LATIR4", "CFG", "GUICTRLPATH")
            Level2 = GetSetting("LATIR4", "CFG", "LEVEL2PATH")

            Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
            If TypeID = "" Then
                log = log & vbCrLf & "Define TYPE ID!!!"
                Return log
            End If
            ot = m.OBJECTTYPE.Item(TypeID)
            If ot Is Nothing Then
                log = log & vbCrLf & "Wrong TYPE ID!!!"
                Return log
            End If

            o.Project.Attributes.Add("Name").Value = ot.name
            o.Project.Attributes.Add("ID").Value = ot.ID.ToString
            o.Project.Attributes.Add("asmName").Value = ot.name
            MakePRJ(ot, o, LATIRPath, GUIPath, ControlPath, Level2, tid)

            log = log & vbCrLf & "Create code for type " & ot.name

            ' crate application class
            MakeApps(tid, m, ot, o)

            ' create classes for each part
            'ot.PART.Sort = "sequence"
            For j = 1 To ot.PART.Count
                os = ot.PART.Item(j)
                If os.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                    MakeRow(tid, m, ot, os, o, "")
                    MakeRowForm(tid, m, ot, os, o, "")
                End If
                MakeColls(tid, m, ot, os, o, "")
            Next
            For i = 1 To ot.OBJECTMODE.Count
                For j = 1 To ot.PART.Count
                    os = ot.PART.Item(j)
                    If os.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                        MakeRow(tid, m, ot, os, o, ot.OBJECTMODE.Item(i).Name)
                        MakeRowForm(tid, m, ot, os, o, ot.OBJECTMODE.Item(i).Name)
                    End If
                    MakeColls(tid, m, ot, os, o, ot.OBJECTMODE.Item(i).Name)
                Next
            Next
            ' return results
            Run = log

        Catch ex As Exception
            Debug.Print(ex.Message + " >> " + ex.StackTrace)
        End Try

    End Function





    ' return script code for specified generation target
    Private Function MapScript(ByVal sc As MTZMetaModel.MTZMetaModel.SCRIPT_col) As String
        Try


            MapScript = String.Empty
            Dim i As Object

            For i = 1 To sc.Count
                'UPGRADE_WARNING: Couldn't resolve default property of object sc.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If sc.Item(i).Target.ID.ToString = tid Then
                    MapScript = sc.Item(i).Code
                    Exit Function
                End If
            Next

        Catch ex As Exception
            Debug.Print(ex.Message + " >> " + ex.StackTrace)
        End Try
    End Function


    ' same as MAPFT, but return fieldtypemap object
    Private Function MapFTObj(ByVal TypeID As String) As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        MapFTObj = Nothing
        Try

            Dim i, s As Object
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
            ft = m.FIELDTYPE.Item(TypeID)
            If ft Is Nothing Then Exit Function
            For i = 1 To ft.FIELDTYPEMAP.Count
                'UPGRADE_WARNING: Couldn't resolve default property of object ft.FIELDTYPEMAP.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If ft.FIELDTYPEMAP.Item(i).Target.ID.ToString = tid Then
                    MapFTObj = ft.FIELDTYPEMAP.Item(i)
                    Exit For
                End If
            Next
        Catch ex As Exception
            Debug.Print(ex.Message + " >> " + ex.StackTrace)
        End Try
    End Function

    ' Create custom code for class code extracted from Meta model
    Private Function MakeMethodCode(ByRef sm As MTZMetaModel.MTZMetaModel.SHAREDMETHOD) As String


        Dim out As String = String.Empty
        Dim scr As String
        Dim i As Integer
        Dim p As MTZMetaModel.MTZMetaModel.PARAMETERS

        MakeMethodCode = String.Empty
        scr = MapScript(sm.SCRIPT)
        If scr = String.Empty Then Exit Function


        out = out & vbCrLf & "'" & LATIR2Framework.StringHelper.NoLF(sm.the_Comment)
        out = out & vbCrLf & "'" & sm.ID.ToString

        If sm.ReturnType Is Nothing Then
            out = out & vbCrLf & "public sub Run_" & sm.name & " ("
        Else
            out = out & vbCrLf & "public function Run_" & sm.name & " ("
        End If

        Dim params As MTZMetaModel.MTZMetaModel.PARAMETERS_col
        params = LATIR2Framework.ObjectHelper.GetParameters(sm.SCRIPT, tid)
        For i = 1 To params.Count
            p = params.Item(i)
            If i > 1 Then out = out & ","
            If p.AllowNull Then out = out & " Optional "
            'UPGRADE_WARNING: Couldn't resolve default property of object p.TypeOfParm.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            out = out & p.Name & " as " & LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, p.TypeOfParm.ID, tid, True)
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






    ' when class work in offline mode - offline brief algoritm used
    Private Function MakeOfflineBriefProc(ByRef os As MTZMetaModel.MTZMetaModel.PART) As String
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As String = String.Empty
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        Try

            s = s & vbCrLf & "  m_BRIEF="""""
            'st.FIELD.Sort = "sequence"
            For i = 1 To st.FIELD.Count
                If st.FIELD.Item(i).IsBrief Then
                    f = st.FIELD.Item(i)
                    s = s & vbCrLf & "  m_BRIEF= m_BRIEF & """ & LATIR2Framework.StringHelper.NoLF(f.Caption) & "="""
                    ft = st.FIELD.Item(i).FieldType
                    'enum
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        s = s & vbCrLf & "select case " & st.FIELD.Item(i).Name

                        For j = 1 To ft.ENUMITEM.Count
                            s = s & vbCrLf & "case " & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & "_" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.ENUMITEM.Item(j).Name)

                            s = s & vbCrLf & "   m_BRIEF=m_BRIEF &  """ & ft.ENUMITEM.Item(j).Name & "; """
                        Next
                        s = s & vbCrLf & "end select '" & st.FIELD.Item(i).Name

                    ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
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

        Catch ex As Exception
            Debug.Print(ex.Message + " >> " + ex.StackTrace)
        End Try

    End Function


    'Insert enum declarations to Application class



    ' Lock / Unlock support for all classes
    Private Sub MakeLockable(ByRef decl As String, ByRef body As String, ByVal Coll As Boolean, ByRef pt As MTZMetaModel.MTZMetaModel.PART)
        Try


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
            body = body & vbCrLf & "try"
            If pt Is Nothing Then
                body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_ISLOCKED"", nv"
            Else
                If Not Coll Then
                    body = body & vbCrLf & "Application.MTZSession.Exec """ & pt.name & "_ISLOCKED"", nv"
                Else
                    If TypeName(pt.Parent.Parent) = "OBJECTTYPE" Then
                        body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_ISLOCKED"", nv"
                    Else
                        body = body & vbCrLf & "Application.MTZSession.Exec """ & CType(pt.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).Name & "_ISLOCKED"", nv"
                    End If
                End If
            End If
            body = body & vbCrLf & "m_IsLocked = nv.item(""ISLocked"").Value"
            body = body & vbCrLf & "Set nv = nothing"
            body = body & vbCrLf & "LastCheckTime = now"
            body = body & vbCrLf & "catch ex as system.Exception"
            body = body & vbCrLf & "Debug.Print(ex.Message +"" >> ""+ ex.StackTrace)"
            body = body & vbCrLf & "end try"
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

            body = body & vbCrLf & "  try"

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
                    If TypeName(pt.Parent.Parent) = "OBJECTTYPE" Then
                        body = body & vbCrLf & "ok =Application.MTZSession.Exec( ""INSTANCE_LOCK"", nv)"
                    Else
                        body = body & vbCrLf & "ok=Application.MTZSession.Exec (""" & CType(pt.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).Name & "_LOCK"", nv)"
                    End If
                End If
            End If

            body = body & vbCrLf & "  if OK then  "
            body = body & vbCrLf & "    if Permanent then m_IsLocked = LockPermanent else m_IsLocked = LockSession"
            body = body & vbCrLf & "  else"
            body = body & vbCrLf & "    m_IsLocked = NoLock"
            body = body & vbCrLf & "  end if"

            body = body & vbCrLf & "catch ex as system.Exception"
            body = body & vbCrLf & "Debug.Print(ex.Message +"" >> ""+ ex.StackTrace)"
            body = body & vbCrLf & "end try"

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
            body = body & vbCrLf & "try"
            If pt Is Nothing Then
                body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_UNLOCK"", nv"
            Else
                If Not Coll Then
                    body = body & vbCrLf & "Application.MTZSession.Exec """ & pt.Name & "_UNLOCK"", nv"
                Else
                    If TypeName(pt.Parent.Parent) = "OBJECTTYPE" Then
                        body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_UNLOCK"", nv"
                    Else
                        body = body & vbCrLf & "Application.MTZSession.Exec """ & CType(pt.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).Name & "_UNLOCK"", nv"
                    End If
                End If
            End If
            body = body & vbCrLf & ""
            body = body & vbCrLf & "m_IsLocked = NoLock"
            body = body & vbCrLf & "catch ex as system.Exception"
            body = body & vbCrLf & "Debug.Print(ex.Message +"" >> ""+ ex.StackTrace)"
            body = body & vbCrLf & "end try"
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
            body = body & vbCrLf & "try"

            If pt Is Nothing Then
                body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_HCL"", nv"
            Else
                If Not Coll Then
                    body = body & vbCrLf & "Application.MTZSession.Exec """ & pt.Name & "_HCL"", nv"
                Else
                    If TypeName(pt.Parent.Parent) = "OBJECTTYPE" Then
                        body = body & vbCrLf & "Application.MTZSession.Exec ""INSTANCE_HCL"", nv"
                    Else
                        body = body & vbCrLf & "Application.MTZSession.Exec """ & CType(pt.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).Name & "_HCL"", nv"
                    End If
                End If
            End If

            body = body & vbCrLf & "If nv.Item(""LockMode"").Value = 0 Then"
            body = body & vbCrLf & " CanLock = True"
            body = body & vbCrLf & "Else"
            body = body & vbCrLf & " CanLock = False"
            body = body & vbCrLf & "End If"
            body = body & vbCrLf & "catch ex as system.Exception"
            body = body & vbCrLf & "Debug.Print(ex.Message +"" >> ""+ ex.StackTrace)"
            body = body & vbCrLf & "end try"
            body = body & vbCrLf & "Set nv = nothing"
            body = body & vbCrLf & "end function"
        Catch ex As Exception
            Debug.Print(ex.Message + " >> " + ex.StackTrace)
        End Try
    End Sub

    Public Sub New()
        MyBase.New()
        LATIRPath = GetSetting("LATIR4", "CFG", "LATIRPATH")
    End Sub
End Class