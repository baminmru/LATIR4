Imports System.IO


Module Module1
    Public Manager As LATIR2.Manager
    Public guiManager As LATIR2GuiManager.LATIRGuiManager
    Public model As MTZMetaModel.MTZMetaModel.Application
    Public viCol As Collection
    Public NewViewName As String
    Public NewViewAlias As String
    Public NewForChoose As Boolean
    Public NewForChooseObject As Boolean
    Public DelOtherView As Boolean
    Public CreatedView As MTZMetaModel.MTZMetaModel.PARTVIEW
    Public BasePartID As Guid
    Public BasePart As MTZMetaModel.MTZMetaModel.PART
    Public ViewForChange As MTZMetaModel.MTZMetaModel.PARTVIEW
    Public BaseType As MTZMetaModel.MTZMetaModel.OBJECTTYPE

    Public Sub ReplaceInFile(ByVal FileName As String, ByVal Mask As String, ByVal Repl As String)
        FileName = FileName.Replace("\\", "\")
        FileName = FileName.Replace("\\", "\")
        Dim fs As FileStream = File.Open(FileName, FileMode.Open, FileAccess.Read)
        Dim sr As StreamReader = New StreamReader(fs)
        Dim filecontent As String = sr.ReadToEnd()
        filecontent = filecontent.Replace(Mask, Repl)
        sr.Close()
        fs.Close()
        File.Delete(FileName)
        fs = File.Open(FileName, FileMode.Create, FileAccess.Write)
        Dim sw As StreamWriter = New StreamWriter(fs)
        sw.Write(filecontent)
        sw.Close()
        fs.Close()
    End Sub

    Public Function CountOfID(ByVal ID As String, ByVal n As System.Windows.Forms.TreeNode) As Integer
        Dim nn As System.Windows.Forms.TreeNode
        Dim cnt As Integer
        cnt = 0
        nn = n
        While Not n Is Nothing
            If Left(n.Name, 38) = ID Then
                cnt = cnt + 1
            End If
            n = n.Parent
        End While
        CountOfID = cnt
    End Function


    Public Sub ExractLevel(ByVal Key As String, ByRef ID As String, ByRef Level As String)
        ID = Left(Key, 38)
        Level = Right(Key, 38)
    End Sub

    Public Function DeCap(ByVal s As String) As String

        'Dim sOut As String
        If s <> "" Then
            Return s
            'sOut = s.Substring(0, 1).ToLower() & s.Substring(1)
            'Return sOut
        Else
            Return s
        End If
    End Function


End Module
