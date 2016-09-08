Public Class clsPServer
  Public name As String
  Public serverDB, nameProvider As String
  Public time As String
  Public NTsecurity, ARM As Boolean
  Public SQLuser, SQLpassword As String
  Public prfParam, prfFunction, prfSubType, prfSubKernel As String
End Class

Public Class clsServer
#Region "CONST SETTING XML FOR SERVER"
  Private Const CRegion = "SERVER"
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
#End Region

  Public c As Collection
  Public err As String
  Public working As Boolean = False

  Public Sub createFile(ByVal fName As String)
    Dim obj As New clsPServer
    c = New Collection
    obj.name = "NEW SERVER"
    c.Add(obj)
    obj = Nothing
    saveServers(fName)
  End Sub

  Public Sub loadServers(ByVal fName As String)
    If Not System.IO.File.Exists(fName) Then
      MsgBox("Файл конфигурации серверов не найден", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, My.Application.Info.AssemblyName)
      Exit Sub
    End If
    If c Is Nothing Then c = New Collection
    c.Clear()
    err = ""
    working = False

    Dim r As Xml.XmlReader = Xml.XmlReader.Create(fName)
    While r.Read
      If r.Name = CRegion Then
        Dim obj As New clsPServer
        obj.name = r.Item(CName)
        obj.serverDB = r.Item(CServerDB)
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
        c.Add(obj)

        working = True
      End If
    End While
    r.Close()
  End Sub
  Public Sub saveServers(ByVal fName As String)
    If c.Count = 0 Then Exit Sub

    Dim w As Xml.XmlWriter = Xml.XmlWriter.Create(fName)
    w.WriteStartElement("root")

    For i As Integer = 1 To c.Count
      w.WriteStartElement(CRegion)

      Dim obj As clsPServer = c.Item(i)
      With obj
        w.WriteAttributeString(CName, .name)
        w.WriteAttributeString(CServerDB, .serverDB)
        w.WriteAttributeString(CSQLuser, .SQLuser)
        w.WriteAttributeString(CSQLpassword, .SQLpassword)
        w.WriteAttributeString(CTime, .time)
        w.WriteAttributeString(CNameProvider, .nameProvider)
        w.WriteAttributeString(CPrfParam, .prfParam)
        w.WriteAttributeString(CNTSecurity, .NTsecurity)
        w.WriteAttributeString(CARM, .ARM)
        w.WriteAttributeString(CPrfFunction, .prfFunction)
        w.WriteAttributeString(CPrfSubType, .prfSubType)
        w.WriteAttributeString(CPrfSubKernel, .prfSubKernel)
      End With

      w.WriteEndElement()
    Next

    w.WriteEndElement()
    w.Close()
  End Sub
  Public Function formatFile(ByVal fName As String) As Boolean
    On Error Resume Next
    formatFile = False
    If fName = "" Then
      MsgBox("Файл конфигурации серверов не определен", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.AssemblyName)
      Exit Function
    End If
    Dim r As Xml.XmlReader = Xml.XmlReader.Create(fName)
    While r.Read
      If r.Name = CRegion Then formatFile = True
    End While
    r.Close()
  End Function
End Class
