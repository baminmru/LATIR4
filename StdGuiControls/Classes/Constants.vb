Imports System.Windows.Forms

Public Class Constants

    Public Const FIELD_ID As String = "ID"
    Public Const MSG_WAIT As String = "Ждите, идёт загрузка..."
    Public Const FIELD_CAPTION As String = "Caption"
    Public Const FIELD_NAME As String = "Name"


    Public Shared Function ButtonName(ByVal ButtonTag As String) As String
        ButtonName = String.Empty
        ButtonTag = ButtonTag.ToLower.Trim()
        Select Case ButtonTag
            Case "new" : Return "&Добавить"
            Case "newroot" : Return "&В корень"
            Case "prop" : Return "&Изменить"
            Case "delete" : Return "&Удалить"
            Case "find" : Return "&Поиск"
            Case "config" : Return "&Настройка"
            Case "refresh" : Return "&Обновить"
            Case "run" : Return "&Открыть"
            Case "print" : Return "&Печать"
        End Select
    End Function

    Public Shared Sub ButtonToolTip(ByRef ToolTip As ToolTip, ByRef Button As System.Windows.Forms.Button)
        Dim ButtonTag As String

        If (ToolTip Is Nothing Or Button Is Nothing) Then
            Return
        End If
        ButtonTag = Button.Tag.ToLower.Trim()
        Select Case ButtonTag
            Case "new" : ToolTip.SetToolTip(Button, "Добавить")
            Case "newroot" : ToolTip.SetToolTip(Button, "Добавить в корень")
            Case "prop" : ToolTip.SetToolTip(Button, "Изменить")
            Case "delete" : ToolTip.SetToolTip(Button, "Удалить")
            Case "find" : ToolTip.SetToolTip(Button, "Поиск")
            Case "config" : ToolTip.SetToolTip(Button, "Настройка")
            Case "refresh" : ToolTip.SetToolTip(Button, "Обновить")
            Case "run" : ToolTip.SetToolTip(Button, "Открыть")
            Case "print" : ToolTip.SetToolTip(Button, "Печать")
        End Select
    End Sub

End Class
