Imports System
Imports System.IO
Imports LATIRGenerator

Public Class Convertors

    Public Shared Sub MakeProjectBlocks(ByVal xmlfile As String, ByRef path As String)

        Dim prj As LATIRGenerator.ProjectHolder = Nothing
        Dim m As LATIRGenerator.ModuleHolder
        Dim b As LATIRGenerator.BlockHolder
        Dim res As LATIRGenerator.Response
        res = New LATIRGenerator.Response
        prj = res.Project
        prj.Load(xmlfile)

        If Not path.EndsWith("\") Then
            path = path + "\"
        End If
        Dim i As Long, j As Long
        For i = 1 To prj.Modules.Count
            m = prj.Modules(i)

            If (File.Exists(path + m.File)) Then
                File.Delete(path + m.File)
            End If
            'Dim trycnt As Integer
            'trycnt = 10
            'While Not File.Exists(path + m.File) And trycnt > 0
            '    File.Create(path + m.File)
            '    trycnt -= 1
            'End While

            Dim output As System.IO.TextWriter
            

            output = New System.IO.StreamWriter(path + m.File)
            For j = 1 To m.Blocks.Count
                b = m.Blocks(j)
                output.Write(b.BlockCode)
            Next
            output.Close()
        Next

        res = Nothing
        prj = Nothing
    End Sub
End Class
