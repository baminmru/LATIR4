Imports System.Windows.Forms

Public Class Constants

    Public Const FIELD_ID As String = "ID"
    Public Const MSG_WAIT As String = "�����, ��� ��������..."
    Public Const FIELD_CAPTION As String = "Caption"
    Public Const FIELD_NAME As String = "Name"


    Public Shared Function ButtonName(ByVal ButtonTag As String) As String
        ButtonName = String.Empty
        ButtonTag = ButtonTag.ToLower.Trim()
        Select Case ButtonTag
            Case "new" : Return "&��������"
            Case "newroot" : Return "&� ������"
            Case "prop" : Return "&��������"
            Case "delete" : Return "&�������"
            Case "find" : Return "&�����"
            Case "config" : Return "&���������"
            Case "refresh" : Return "&��������"
            Case "run" : Return "&�������"
            Case "print" : Return "&������"
        End Select
    End Function

    Public Shared Sub ButtonToolTip(ByRef ToolTip As ToolTip, ByRef Button As System.Windows.Forms.Button)
        Dim ButtonTag As String

        If (ToolTip Is Nothing Or Button Is Nothing) Then
            Return
        End If
        ButtonTag = Button.Tag.ToLower.Trim()
        Select Case ButtonTag
            Case "new" : ToolTip.SetToolTip(Button, "��������")
            Case "newroot" : ToolTip.SetToolTip(Button, "�������� � ������")
            Case "prop" : ToolTip.SetToolTip(Button, "��������")
            Case "delete" : ToolTip.SetToolTip(Button, "�������")
            Case "find" : ToolTip.SetToolTip(Button, "�����")
            Case "config" : ToolTip.SetToolTip(Button, "���������")
            Case "refresh" : ToolTip.SetToolTip(Button, "��������")
            Case "run" : ToolTip.SetToolTip(Button, "�������")
            Case "print" : ToolTip.SetToolTip(Button, "������")
        End Select
    End Sub

End Class
