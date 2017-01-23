Imports System.IO
Public Class clsPSite
    Public name As String
    Public serverDB, nameDB, nameProvider As String
    Public time As String
    Public NTsecurity, ARM As Boolean
    Public SQLuser, SQLpassword As String
    Public prfParam, prfFunction, prfSubType, prfSubKernel As String
    Public pathImage, pathLayouts, pathTemp As String
End Class

Public Class clsSite
#Region "CONST SETTING XML FOR SITE"
  Private Const CRegion = "SITE"
  Private Const CName = "Name"
  Private Const CServerDB = "Server"
  Private Const CNameDB = "DB"
  Private Const CNameProvider = "PROVIDER"
  Private Const CTime = "TIMEOUT"

  Private Const CNTSecurity = "INTEGRATED"
  Private Const CARM = "INTEGRATEDARM"

  Private Const CSQLuser = "USER"
  Private Const CSQLpassword = "PASSWORD"

  Private Const CPrfParam = "AT"
  Private Const CPrfFunction = "FUNC"
  Private Const CPrfSubType = "PROC"
  Private Const CPrfSubKernel = "KERNEL"

  Private Const CpathImage = "IMAGES"
  Private Const CpathLayouts = "LAYOUTS"
  Private Const CpathTemp = "TEMP"
#End Region

  Public c As Collection
  Public err As String
  Public working As Boolean = False

    Public Sub Clear()
        If c Is Nothing Then c = New Collection
        c.Clear()
    End Sub
    Public Sub createFile(ByVal fName As String)
    Dim obj As New clsPSite
    c = New Collection
    obj.name = "NEW SITE"
    c.Add(obj)
    obj = Nothing
    saveSites(fName)
  End Sub

  Public Sub loadSites(ByVal fName As String)
    If Not System.IO.File.Exists(fName) Then
      MsgBox("Файл конфигурации сайтов не найден", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, My.Application.Info.AssemblyName)
      Exit Sub
    End If
    If c Is Nothing Then c = New Collection
    c.Clear()
    err = ""
        working = False
        Dim crypted As Boolean = False
        Dim s As String
        If fName.EndsWith(".zzz") Then

            s = File.ReadAllText(fName)
            s = CryptoZ.Decrypt(s, "LATIR4")
            File.WriteAllText(fName.Replace(".zzz", ""), s)
            fName = fName.Replace(".zzz", "")
            crypted = True
        End If



        Dim r As Xml.XmlReader = Xml.XmlReader.Create(fName)
    While r.Read
      If r.Name = CRegion Then
        Dim obj As New clsPSite
        obj.name = r.Item(CName)
        obj.serverDB = r.Item(CServerDB)
        obj.nameDB = r.Item(CNameDB)
        obj.nameProvider = r.Item(CNameProvider)
        obj.time = r.Item(CTime)
        obj.NTsecurity = r.Item(CNTSecurity)
        obj.ARM = r.Item(CARM)
        obj.SQLuser = r.Item(CSQLuser)
        obj.SQLpassword = r.Item(CSQLpassword)
        obj.prfParam = r.Item(CPrfParam)
        obj.prfFunction = r.Item(CPrfFunction)
        obj.prfSubType = r.Item(CPrfSubType)
        obj.prfSubKernel = r.Item(CPrfSubKernel)
        obj.pathImage = r.Item(CpathImage)
        obj.pathLayouts = r.Item(CpathLayouts)
        obj.pathTemp = r.Item(CpathTemp)
        c.Add(obj)

        working = True
      End If
    End While
        r.Close()
        If crypted Then
            Try
                's = File.ReadAllText(fName)
                's = CryptoZ.Encrypt(s, "LATIR4")
                'File.WriteAllText(fName & ".zzz", s)
                File.Delete(fName)
            Catch ex As Exception

            End Try

        End If

    End Sub
    Public Sub saveSites(ByVal fName As String)
        Dim crypted As Boolean = False
        If c.Count = 0 Then Exit Sub


        If fName.EndsWith(".zzz") Then
            fName = fName.Replace(".zzz", "")
            crypted = True
        End If
        Dim w As Xml.XmlWriter = Xml.XmlWriter.Create(fName)
        w.WriteStartElement("root")

        For i As Integer = 1 To c.Count
            w.WriteStartElement(CRegion)

            Dim obj As clsPSite = c.Item(i)
            With obj
                w.WriteAttributeString(CName, .name)
                w.WriteAttributeString(CServerDB, .serverDB)
                w.WriteAttributeString(CNameDB, .nameDB)
                w.WriteAttributeString(CSQLuser, .SQLuser)
                w.WriteAttributeString(CSQLpassword, .SQLpassword)
                w.WriteAttributeString(CTime, .time)
                w.WriteAttributeString(CNameProvider, .nameProvider)
                w.WriteAttributeString(CPrfParam, .prfParam)
                w.WriteAttributeString(CNTSecurity, .NTsecurity)
                w.WriteAttributeString(CARM, .ARM)
                w.WriteAttributeString(CpathImage, .pathImage)
                w.WriteAttributeString(CpathLayouts, .pathLayouts)
                w.WriteAttributeString(CpathTemp, .pathTemp)
                w.WriteAttributeString(CPrfFunction, .prfFunction)
                w.WriteAttributeString(CPrfSubType, .prfSubType)
                w.WriteAttributeString(CPrfSubKernel, .prfSubKernel)
            End With

            w.WriteEndElement()
        Next

        w.WriteEndElement()
        w.Close()

        If crypted Then
            Try
                Dim s As String
                Dim xdoc As Xml.XmlDocument
                xdoc = New Xml.XmlDocument
                xdoc.Load(fName)
                s = xdoc.OuterXml
                s = CryptoZ.Encrypt(s, "LATIR4")
                File.WriteAllText(fName & ".zzz", s)
                File.Delete(fName)
            Catch ex As Exception

            End Try
        Else
            Dim s As String
            Dim xdoc As Xml.XmlDocument
            xdoc = New Xml.XmlDocument
            xdoc.Load(fName)
            s = xdoc.OuterXml
            s = CryptoZ.Encrypt(s, "LATIR4")
            File.WriteAllText(fName & ".zzz", s)

        End If



    End Sub
    Public Function formatFile(ByVal fName As String) As Boolean
    On Error Resume Next
    formatFile = False
        If fName = "" Then
            MsgBox("Файл конфигурации сайтов не определен", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.AssemblyName)
            Exit Function
        End If

        '    Dim r As Xml.XmlReader = Xml.XmlReader.Create(fName)
        'While r.Read
        '  If r.Name = CRegion Then formatFile = True
        'End While
        'r.Close()
        formatFile = True
    End Function
End Class