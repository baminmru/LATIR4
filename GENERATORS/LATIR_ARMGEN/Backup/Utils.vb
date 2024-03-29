Option Strict Off
Option Explicit On
Module Utils
	
	'Utils
    Public Function TypeForStruct(ByVal s As MTZMetaModel.MTZMetaModel.PART) As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim i As Integer
        Dim obj As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object s.parent.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        obj = s.parent.parent

        ' ���� ��� �� ��� �������
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        While TypeName(obj) <> "OBJECTTYPE"
            'UPGRADE_WARNING: Couldn't resolve default property of object obj.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj = obj.parent.parent
        End While

        TypeForStruct = obj
    End Function


    Public Function NoLF(ByVal s As String) As String
        NoLF = Replace(Replace(Replace(Replace(Replace(s, vbCrLf, " "), vbTab, " "), vbCr, " "), vbLf, " "), "  ", " ")
    End Function


    'Count Stucts for mode
    Public Function CountStructs(ByVal s As MTZMetaModel.MTZMetaModel.PART_COL, ByVal mode As String) As Integer
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim om As MTZMetaModel.MTZMetaModel.OBJECTMODE
        Dim dom As MTZMetaModel.MTZMetaModel.OBJECTMODE
        Dim i As Integer
        Dim obj As Object
        obj = s.Parent

        ' ���� ��� �� ��� �������
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        While TypeName(obj) <> "OBJECTTYPE"
            'UPGRADE_WARNING: Couldn't resolve default property of object obj.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj = obj.parent.parent
        End While

        ot = obj

        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).DefaultMode Then
                dom = ot.OBJECTMODE.Item(i)
                Exit For
            End If
        Next

        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).Name = mode Then
                om = ot.OBJECTMODE.Item(i)
                Exit For
            End If
        Next

        If om Is Nothing Then
            om = dom
        End If

        If om Is Nothing Then
            CountStructs = s.Count
            Exit Function
        End If

        Dim j, CNT As Integer
        Dim ok As Boolean
        CNT = 0
        For j = 1 To s.Count
            ok = True
            For i = 1 To om.STRUCTRESTRICTION.Count
                'UPGRADE_WARNING: Couldn't resolve default property of object om.STRUCTRESTRICTION.Item(i).struct.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If om.STRUCTRESTRICTION.Item(i).Struct.ID = s.Item(j).ID Then
                    If om.STRUCTRESTRICTION.Item(i).AllowRead Then
                        ok = True
                    Else
                        ok = False
                    End If
                    Exit For
                End If
            Next
            If ok Then CNT = CNT + 1
        Next

        CountStructs = CNT

    End Function


    'True if struct exists in this mode
    Public Function IsPresent(ByVal st As MTZMetaModel.MTZMetaModel.PART, ByVal mode As String) As Boolean
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim om As MTZMetaModel.MTZMetaModel.OBJECTMODE
        Dim dom As MTZMetaModel.MTZMetaModel.OBJECTMODE


        Dim i As Integer
        Dim obj As Object

        'UPGRADE_WARNING: Couldn't resolve default property of object st.parent.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        obj = st.Parent.Parent

        ' ���� ��� �� ��� �������
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        While TypeName(obj) <> "OBJECTTYPE"
            'UPGRADE_WARNING: Couldn't resolve default property of object obj.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj = obj.parent.parent
        End While

        ot = obj

        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).DefaultMode Then
                dom = ot.OBJECTMODE.Item(i)
                Exit For
            End If
        Next


        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).Name = mode Then
                om = ot.OBJECTMODE.Item(i)
                Exit For
            End If
        Next

        If om Is Nothing Then
            om = dom
        End If

        If om Is Nothing Then
            IsPresent = True
            Exit Function
        End If

        Dim ok As Boolean

        ok = True
        For i = 1 To om.STRUCTRESTRICTION.Count
            'UPGRADE_WARNING: Couldn't resolve default property of object om.STRUCTRESTRICTION.Item(i).struct.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If om.STRUCTRESTRICTION.Item(i).Struct.ID = st.ID Then
                If om.STRUCTRESTRICTION.Item(i).AllowRead Then
                    ok = True
                Else
                    ok = False
                End If
                Exit For
            End If
        Next
        If ok Then IsPresent = True

    End Function



    'Count fields for mode
    Public Function CountFields(ByVal s As MTZMetaModel.MTZMetaModel.PART, ByVal mode As String) As Integer
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim om As MTZMetaModel.MTZMetaModel.OBJECTMODE
        Dim dom As MTZMetaModel.MTZMetaModel.OBJECTMODE
        Dim i As Integer
        Dim obj As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object s.parent.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        obj = s.Parent.Parent

        ' ���� ��� �� ��� �������
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        While TypeName(obj) <> "OBJECTTYPE"
            'UPGRADE_WARNING: Couldn't resolve default property of object obj.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj = obj.parent.parent
        End While

        ot = obj


        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).DefaultMode Then
                dom = ot.OBJECTMODE.Item(i)
                Exit For
            End If
        Next


        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).Name = mode Then
                om = ot.OBJECTMODE.Item(i)
                Exit For
            End If
        Next

        If om Is Nothing Then
            om = dom
        End If

        If om Is Nothing Then
            CountFields = s.FIELD.Count
            Exit Function
        End If

        Dim j, CNT As Integer
        Dim ok As Boolean
        CNT = 0
        For j = 1 To s.FIELD.Count
            ok = True
            For i = 1 To om.FIELDRESTRICTION.Count
                'UPGRADE_WARNING: Couldn't resolve default property of object om.FIELDRESTRICTION.Item(i).ThePart.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If om.FIELDRESTRICTION.Item(i).ThePart.ID = s.ID Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object om.FIELDRESTRICTION.Item(i).TheField.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If om.FIELDRESTRICTION.Item(i).TheField.ID = s.FIELD.Item(j).ID Then
                        If om.FIELDRESTRICTION.Item(i).AllowRead Then
                            ok = True
                        Else
                            ok = False
                        End If
                        Exit For
                    End If
                End If
            Next
            If ok Then CNT = CNT + 1
        Next

        CountFields = CNT

    End Function



    'Yes if field exists for mode
    Public Function IsFieldPresent(ByVal s As MTZMetaModel.MTZMetaModel.PART, ByVal FieldID As String, ByVal mode As String) As Boolean
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim om As MTZMetaModel.MTZMetaModel.OBJECTMODE
        Dim dom As MTZMetaModel.MTZMetaModel.OBJECTMODE
        Dim i As Integer
        Dim obj As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object s.parent.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        obj = s.Parent.Parent

        ' ���� ��� �� ��� �������
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        While TypeName(obj) <> "OBJECTTYPE"
            'UPGRADE_WARNING: Couldn't resolve default property of object obj.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj = obj.parent.parent
        End While

        ot = obj


        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).DefaultMode Then
                dom = ot.OBJECTMODE.Item(i)
                Exit For
            End If
        Next


        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).Name = mode Then
                om = ot.OBJECTMODE.Item(i)
                Exit For
            End If
        Next

        If om Is Nothing Then
            om = dom
        End If

        If om Is Nothing Then
            IsFieldPresent = True
            Exit Function
        End If

        Dim ok As Boolean

        ok = True
        For i = 1 To om.FIELDRESTRICTION.Count
            If om.FIELDRESTRICTION.Item(i).ThePart Is Nothing Then
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object om.FIELDRESTRICTION.Item(i).ThePart.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If om.FIELDRESTRICTION.Item(i).ThePart.ID = s.ID Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object om.FIELDRESTRICTION.Item(i).TheField.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If om.FIELDRESTRICTION.Item(i).TheField.ID.ToString = FieldID Then
                        If om.FIELDRESTRICTION.Item(i).AllowRead Then
                            ok = True
                        Else
                            ok = False
                        End If
                        Exit For
                    End If
                End If
            End If
        Next
        IsFieldPresent = ok

    End Function






    Public Function AnalizeInterface(ByRef s As MTZMetaModel.MTZMetaModel.PART, ByVal mode As String) As String
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim obj As Object
        Dim nxt As MTZMetaModel.MTZMetaModel.PART
        Dim prev As MTZMetaModel.MTZMetaModel.PART
        Dim level As String
        Dim i As Integer
        'UPGRADE_WARNING: Couldn't resolve default property of object s.parent.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        obj = s.parent.parent
        level = CStr(1)

        ' ���� ��� �� ��� �������
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        While TypeName(obj) <> "OBJECTTYPE"
            'UPGRADE_WARNING: Couldn't resolve default property of object obj.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj = obj.parent.parent
            level = CStr(CDbl(level) + 1)
        End While

        ot = obj

        If CDbl(level) > 2 Then
            AnalizeInterface = "common"
            Exit Function
        End If


        If CDbl(level) = 2 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object s.parent.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            prev = s.parent.parent
            If CountStructs(prev.PART, mode) > 1 Then
                AnalizeInterface = "common"
                Exit Function
            End If

            If CountStructs(s.PART, mode) > 0 Then
                AnalizeInterface = "common"
                Exit Function
            End If


            If prev.PartType = 0 Or prev.PartType = 2 Then

                If s.PartType = 2 Then
                    AnalizeInterface = "righttree"
                    Exit Function
                End If

                If s.PartType = 1 Then
                    AnalizeInterface = "rightgrid"
                    Exit Function
                End If

                If s.PartType = 0 Then
                    AnalizeInterface = "rightpanel"
                    Exit Function
                End If
            Else
                If s.PartType = 2 Then
                    AnalizeInterface = "bottomtree"
                    Exit Function
                End If

                If s.PartType = 1 Then
                    AnalizeInterface = "bottomgrid"
                    Exit Function
                End If

                If s.PartType = 0 Then
                    AnalizeInterface = "bottompanel"
                    Exit Function
                End If

            End If

        End If


        If CDbl(level) = 1 Then

            If CountStructs(s.PART, mode) > 1 Then
                AnalizeInterface = "common"
                Exit Function
            End If


            For i = 1 To s.PART.Count
                If IsPresent(s.PART.Item(i), mode) Then
                    If CountStructs(s.PART.Item(1).PART, mode) > 0 Then
                        AnalizeInterface = "common"
                        Exit Function
                    End If
                End If
            Next

            If CountStructs(s.PART, mode) = 1 Then

                If s.PartType = 2 Then
                    AnalizeInterface = "lefttree"
                    Exit Function
                End If

                If s.PartType = 1 Then
                    AnalizeInterface = "topgrid"
                    Exit Function
                End If

                If s.PartType = 0 Then
                    AnalizeInterface = "leftpanel"
                    Exit Function
                End If
            Else
                If s.PartType = 2 Then
                    AnalizeInterface = "tree"
                    Exit Function
                End If

                If s.PartType = 1 Then
                    AnalizeInterface = "grid"
                    Exit Function
                End If

                If s.PartType = 0 Then
                    AnalizeInterface = "panel"
                    Exit Function
                End If
            End If
        End If
    End Function
	
	
	
	' Util function
	Public Function CommentSplit(ByVal Prefix As String, ByVal c As String) As String
		Dim out As String
		Dim i As Short
		Dim ss As Object
		On Error Resume Next
		'UPGRADE_WARNING: Couldn't resolve default property of object ss. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ss = Split(c, vbCrLf)
		For i = 0 To UBound(ss)
			'UPGRADE_WARNING: Couldn't resolve default property of object ss(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			out = Prefix & ss(i)
		Next 
		CommentSplit = out
		
	End Function
	
	'Util function for transliteration
	Public Function MakeValidName(ByVal name As String) As String
		Dim s As String
		Dim out As String
		Dim changes As String
		Dim arr As Object
		Dim transfr, transto As String
		Dim i, j As Integer
		Dim begs As String
		begs = "_1234567890"
		
		transfr = "����������������������������������������������������������������ި"
		transto = "ycukengsszh_fivaproldgeycsmit_buyYCUKENGSSZH_FIVAPROLDGEYCSMIT_BUE"
		
		
		changes = " +-`~'""/\|*:.,<>?][{}!@#$%^&()="
		'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		'UPGRADE_WARNING: Couldn't resolve default property of object arr. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		arr = New Object(){"_", "PLS", "MNS", "LAPS", "WAV", "APS", "DAPS", "SLASH", "BSLASH", "FENCE", "STAR", "DDOT", "DOT", "COMA", "LS", "GT", "QMARK", "BCLS", "BOPN", "WOPN", "WCLS", "IMARK", "AT", "SHARP", "DOLL", "PCNT", "ROOF", "AND", "OPN", "CLS", "EQ", "XX", "XX", "XX", "XX"}
		
		
		s = name
		
		
		Dim changeIt As Integer
		For i = 1 To Len(transfr)
			s = Replace(s, Mid(transfr, i, 1), Mid(transto, i, 1))
		Next 
		
		For i = 1 To Len(s)
			changeIt = -1
			For j = 1 To Len(changes)
				If Mid(s, i, 1) = Mid(changes, j, 1) Then
					changeIt = j
					Exit For
				End If
			Next 
			If changeIt = -1 Then
				out = out & Mid(s, i, 1)
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object arr(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				out = out & arr(changeIt - 1)
			End If
		Next 
		s = out
		
		
		
		
		
		If InStr(1, begs, Left(s, 1)) > 0 Then
			s = "cls_" & s
		End If
		'If Not IsValidFieldName2(s) Then
		'  s = "n_" & s
		'End If
		MakeValidName = s
	End Function
	
	
	' return phisical type for fieldtypeid
	Public Function MapFT(ByVal m As Object, ByVal TypeID As String, ByVal tid As String) As String
		On Error GoTo bye
		
		Dim i, s As Object
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
		MapFT = "TEXTBOX"
		'UPGRADE_WARNING: Couldn't resolve default property of object m.FIELDTYPE. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ft = m.FIELDTYPE.Item(TypeID)
		If ft Is Nothing Then Exit Function
		For i = 1 To ft.FIELDTYPEMAP.Count
			'UPGRADE_WARNING: Couldn't resolve default property of object ft.FIELDTYPEMAP.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ft.FIELDTYPEMAP.Item(i).Target.ID.ToString = tid Then
                '      If ft.TypeStyle = TypeStyle_Perecislenie Then
                '        s = "enum" & MakeValidName(ft.name)
                '      Else
                'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                s = ft.FIELDTYPEMAP.Item(i).StoageType
                '      End If
                Exit For
            End If
		Next 
		'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		MapFT = s
		Exit Function
bye: 
		'log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
		'Stop
		'Resume
	End Function
	
	
    Public Function GetParameters(ByRef scol As MTZMetaModel.MTZMetaModel.SCRIPT_col, ByVal tid As String) As MTZMetaModel.MTZMetaModel.PARAMETERS_col
        Dim i As Integer

        On Error GoTo bye
        For i = 1 To scol.Count
            'UPGRADE_WARNING: Couldn't resolve default property of object scol.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If scol.Item(i).Target.ID.ToString = tid Then
                GetParameters = scol.Item(i).PARAMETERS
                Exit Function
            End If
        Next
        Exit Function
bye:
    End Function
	
    Public Sub AddProp(ByRef ctl As LATIRGenerator.ControlData, ByVal name As String, ByVal value As String)
        With ctl.Properties.Add()
            .name = name
            .PropValue = value
        End With
    End Sub


    Public Sub AddFProp(ByRef frm As LATIRGenerator.FormData, ByVal name As String, ByVal value As String)
        With frm.PropertyData.Add()
            .name = name
            .PropValue = value
        End With
    End Sub
End Module