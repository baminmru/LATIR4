Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmModeTools
	Inherits System.Windows.Forms.Form
	Dim pcol As MTZUtil.SortableCollection
	Dim fcol As MTZUtil.SortableCollection
	Dim i As Integer
	
	'UPGRADE_WARNING: Event cmbMode.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbMode_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbMode.SelectedIndexChanged
		grPart.ItemCount = 0
		grField.ItemCount = 0
		pcol = New MTZUtil.SortableCollection
		fcol = New MTZUtil.SortableCollection
		Dim i, j As Object
		Dim mi As ModeItem
		For i = 1 To model.ObjectType.item(cmbType.SelectedIndex + 1).PART.Count
			mi = New ModeItem
			mi.Obj1 = model.ObjectType.item(cmbType.SelectedIndex + 1).PART.item(i)
			mi.SName = model.ObjectType.item(cmbType.SelectedIndex + 1).PART.item(i).Caption
			mi.B1 = True
			mi.B2 = True
			mi.B3 = True
			mi.B4 = True
			pcol.AddItem(mi)
			
			For j = 1 To model.ObjectType.item(cmbType.SelectedIndex + 1).PART.item(i).Field.Count
				mi = New ModeItem
				mi.Obj1 = model.ObjectType.item(cmbType.SelectedIndex + 1).PART.item(i)
				mi.Obj2 = model.ObjectType.item(cmbType.SelectedIndex + 1).PART.item(i).Field.item(j)
				mi.SName = model.ObjectType.item(cmbType.SelectedIndex + 1).PART.item(i).Caption & "\" & model.ObjectType.item(cmbType.SelectedIndex + 1).PART.item(i).Field.item(j).Caption
				mi.B1 = True
				mi.B2 = True
				mi.B3 = True
				fcol.AddItem(mi)
			Next 
			CollectRows(model.ObjectType.item(cmbType.SelectedIndex + 1).PART.item(i))
		Next 
		
		' смотрим на ограничения режима и выставляем флажки
		With model.ObjectType.item(cmbType.SelectedIndex + 1).OBJECTMODE.item(cmbMode.SelectedIndex + 1)
			For i = 1 To .STRUCTRESTRICTION.Count
				For j = 1 To pcol.Count
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item(j).Obj1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If pcol.item(j).Obj1 Is .STRUCTRESTRICTION.item(i).struct Then
						'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item(j).B1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						pcol.item(j).B1 = .STRUCTRESTRICTION.item(i).AllowRead
						'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item(j).B2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						pcol.item(j).B2 = .STRUCTRESTRICTION.item(i).AllowAdd
						'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item(j).B3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						pcol.item(j).B3 = .STRUCTRESTRICTION.item(i).AllowDelete
						'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item(j).B4. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						pcol.item(j).B4 = .STRUCTRESTRICTION.item(i).AllowEdit
						'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().Obj3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						pcol.item(j).Obj3 = .STRUCTRESTRICTION.item(i)
					End If
				Next 
			Next 
			
			For i = 1 To .FIELDRESTRICTION.Count
				For j = 1 To fcol.Count
					'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item(j).Obj2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item(j).Obj1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If fcol.item(j).Obj1 Is .FIELDRESTRICTION.item(i).ThePart And fcol.item(j).Obj2 Is .FIELDRESTRICTION.item(i).TheField Then
						'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item(j).B1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						fcol.item(j).B1 = .FIELDRESTRICTION.item(i).AllowRead
						'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item(j).B2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						fcol.item(j).B2 = .FIELDRESTRICTION.item(i).AllowModify
						'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().Obj3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						fcol.item(j).Obj3 = .FIELDRESTRICTION.item(i)
					End If
				Next 
			Next 
		End With
		
		pcol.Sort("SName")
		fcol.Sort("SName")
		grPart.ItemCount = pcol.Count
		grField.ItemCount = fcol.Count
	End Sub
	
	Private Sub CollectRows(ByRef root As MTZMetaModel.PART)
		Dim i, j As Object
		Dim mi As ModeItem
		For i = 1 To root.PART.Count
			mi = New ModeItem
			mi.Obj1 = root.PART.item(i)
			mi.SName = root.PART.item(i).Caption
			mi.B1 = True
			mi.B2 = True
			mi.B3 = True
			mi.B4 = True
			
			pcol.AddItem(mi)
			For j = 1 To root.PART.item(i).Field.Count
				mi = New ModeItem
				mi.Obj1 = root.PART.item(i)
				mi.Obj2 = root.PART.item(i).Field.item(j)
				mi.SName = root.PART.item(i).Caption & "\" & root.PART.item(i).Field.item(j).Caption
				mi.B1 = True
				mi.B2 = True
				mi.B3 = True
				mi.B4 = True
				
				fcol.AddItem(mi)
			Next 
			CollectRows(root.PART.item(i))
		Next 
		
	End Sub
	
	'UPGRADE_WARNING: Event cmbType.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbType.SelectedIndexChanged
		cmbMode.Items.Clear()
		model.ObjectType.item(cmbType.SelectedIndex + 1).OBJECTMODE.Sort = "Name"
		For i = 1 To model.ObjectType.item(cmbType.SelectedIndex + 1).OBJECTMODE.Count
			cmbMode.Items.Add(model.ObjectType.item(cmbType.SelectedIndex + 1).OBJECTMODE.item(i).Name)
		Next 
		grPart.ItemCount = 0
		grField.ItemCount = 0
	End Sub
	
	Private Sub cmdAddMode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAddMode.Click
		Dim s As String
		
		If cmbType.SelectedIndex = -1 Then Exit Sub
		s = ""
		s = InputBox("Названеи режима (4 символа)", "Новый режим")
		If s = "" Then Exit Sub
		With model.ObjectType.item(cmbType.SelectedIndex + 1).OBJECTMODE.Add
			.Name = VB.Left(s, 4)
			.Save()
		End With
		cmbType_SelectedIndexChanged(cmbType, New System.EventArgs())
	End Sub
	
	Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
		Dim fr As MTZMetaModel.FIELDRESTRICTION
		Dim sr As MTZMetaModel.STRUCTRESTRICTION
		With model.ObjectType.item(cmbType.SelectedIndex + 1).OBJECTMODE.item(cmbMode.SelectedIndex + 1)
			For i = 1 To pcol.Count
				'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item(i).Obj3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not pcol.item(i).Obj3 Is Nothing Then
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().Obj3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sr = pcol.item(i).Obj3
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sr.AllowRead = pcol.item(i).B1
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sr.AllowAdd = pcol.item(i).B2
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sr.AllowDelete = pcol.item(i).B3
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B4. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sr.AllowEdit = pcol.item(i).B4
					sr.Save()
				Else
					sr = .STRUCTRESTRICTION.Add
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().Obj1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sr.struct = pcol.item(i).Obj1
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sr.AllowRead = pcol.item(i).B1
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sr.AllowAdd = pcol.item(i).B2
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sr.AllowDelete = pcol.item(i).B3
					'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B4. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sr.AllowEdit = pcol.item(i).B4
					sr.Save()
				End If
			Next 
			For i = 1 To fcol.Count
				'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item(i).Obj3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not fcol.item(i).Obj3 Is Nothing Then
					'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().Obj3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					fr = fcol.item(i).Obj3
					'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().B1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					fr.AllowRead = fcol.item(i).B1
					'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().B2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					fr.AllowModify = fcol.item(i).B2
					fr.Save()
				Else
					fr = .FIELDRESTRICTION.Add
					'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().Obj1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					fr.ThePart = fcol.item(i).Obj1
					'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().Obj2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					fr.TheField = fcol.item(i).Obj2
					'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().B1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					fr.AllowRead = fcol.item(i).B1
					'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().B2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					fr.AllowModify = fcol.item(i).B2
					fr.Save()
				End If
			Next 
		End With
		MsgBox("Изменения сохранены")
	End Sub
	
	Private Sub frmModeTools_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		cmbType.Items.Clear()
		cmbMode.Items.Clear()
		grPart.ItemCount = 0
		grField.ItemCount = 0
		model.ObjectType.Sort = "the_comment"
		For i = 1 To model.ObjectType.Count
			cmbType.Items.Add(model.ObjectType.item(i).the_comment & "(" & model.ObjectType.item(i).Name & ")")
		Next 
	End Sub
	
	
	Private Sub grField_AfterColEdit(ByVal eventSender As System.Object, ByVal eventArgs As AxGridEX20.__GridEX_AfterColEditEvent) Handles grField.AfterColEdit
		If grField.RowIndex(grField.Row) <= 0 Then Exit Sub
		'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item(grField.RowIndex(grField.Row)).B1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object grField.Value(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		fcol.item(grField.RowIndex(grField.Row)).B1 = grField.get_Value(2)
		'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item(grField.RowIndex(grField.Row)).B2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object grField.Value(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		fcol.item(grField.RowIndex(grField.Row)).B2 = grField.get_Value(3)
	End Sub
	
	Private Sub grField_UnboundReadData(ByVal eventSender As System.Object, ByVal eventArgs As AxGridEX20.__GridEX_UnboundReadDataEvent) Handles grField.UnboundReadData
		'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().SName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		eventArgs.Values(1) = fcol.item(eventArgs.RowIndex).SName
		'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().B1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		eventArgs.Values(2) = fcol.item(eventArgs.RowIndex).B1
		'UPGRADE_WARNING: Couldn't resolve default property of object fcol.item().B2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		eventArgs.Values(3) = fcol.item(eventArgs.RowIndex).B2
		
	End Sub
	
	Private Sub grPart_AfterColEdit(ByVal eventSender As System.Object, ByVal eventArgs As AxGridEX20.__GridEX_AfterColEditEvent) Handles grPart.AfterColEdit
		If grPart.RowIndex(grPart.Row) <= 0 Then Exit Sub
		'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item(grPart.RowIndex(grPart.Row)).B1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object grPart.Value(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		pcol.item(grPart.RowIndex(grPart.Row)).B1 = grPart.get_Value(2)
		'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item(grPart.RowIndex(grPart.Row)).B2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object grPart.Value(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		pcol.item(grPart.RowIndex(grPart.Row)).B2 = grPart.get_Value(3)
		'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item(grPart.RowIndex(grPart.Row)).B3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object grPart.Value(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		pcol.item(grPart.RowIndex(grPart.Row)).B3 = grPart.get_Value(4)
		'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item(grPart.RowIndex(grPart.Row)).B4. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object grPart.Value(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		pcol.item(grPart.RowIndex(grPart.Row)).B4 = grPart.get_Value(5)
		
	End Sub
	
	Private Sub grPart_UnboundReadData(ByVal eventSender As System.Object, ByVal eventArgs As AxGridEX20.__GridEX_UnboundReadDataEvent) Handles grPart.UnboundReadData
		'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().SName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		eventArgs.Values(1) = pcol.item(eventArgs.RowIndex).SName
		'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		eventArgs.Values(2) = pcol.item(eventArgs.RowIndex).B1
		'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		eventArgs.Values(3) = pcol.item(eventArgs.RowIndex).B2
		'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		eventArgs.Values(4) = pcol.item(eventArgs.RowIndex).B3
		'UPGRADE_WARNING: Couldn't resolve default property of object pcol.item().B4. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		eventArgs.Values(5) = pcol.item(eventArgs.RowIndex).B4
	End Sub
End Class