Imports System.IO


Public Class Utils

    Public Shared Function Int2GUID(ByVal intID As Int32) As Guid
        Return New Guid(intID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    End Function

    Public Shared Function GUID2Int(ByVal ID As Guid) As Int32
        Dim seed() As Byte = ID.ToByteArray()
        Dim i As Integer
        For i = 4 To 15
            seed(i) = 0
        Next

        Dim seedInt As Int32 = BitConverter.ToInt32(seed, 0)
        Return seedInt
    End Function

    Public Shared Function GUID2String(ByVal aSession As LATIR2.Session, ByVal gIn As System.Guid) As String
        'If gIn.Equals(System.Guid.Empty) Then
        '    Return ""
        'Else
        '    Return "{" + gIn.ToString().ToUpper() + "}"
        'End If

        Return aSession.GetProvider.ID2Const(gIn)
    End Function

    Public Shared Function GUID2String(ByVal gIn As System.Guid) As String
        If gIn.Equals(System.Guid.Empty) Then
            Return ""
        Else
            Return "{" + gIn.ToString().ToUpper() + "}"
        End If
    End Function

    Public Shared Function ID2String(ByVal sIn As String) As String
        If Len(sIn) <= 0 Then Return ""

        If (Not Left(sIn, 1) = "{") And (Len(sIn) = 36) Then
            sIn = "{" + sIn + "}"
        End If
        Return sIn.ToUpper()
    End Function

    Public Shared Function MakeMSSQLDate(ByVal d As Date, Optional ByVal FullDate As Boolean = True) As String
        If IsDBNull(d) Then
            Return "NULL"
        Else
            If FullDate Then
                Return "convert(datetime,'" & MakeODBCDate(d) & "',120)"
            Else
                d = DateSerial(Year(d), Month(d), Day(d))
                Return "convert(datetime,'" & MakeODBCDate(d) & "',120)"
            End If
        End If
    End Function

    Public Shared Function MakeORACLEDate(ByVal d As Date, Optional ByVal FullDate As Boolean = True) As String
        If IsDBNull(d) Then
            Return "NULL"
        Else
            If Not FullDate Then
                d = DateSerial(Year(d), Month(d), Day(d))
                Return "to_date('" & MakeODBCDate(d) & "','YYYY-MM-DD HH24:MI:SS')"
            Else
                Return "to_date('" & MakeODBCDate(d) & "','YYYY-MM-DD HH24:MI:SS')"
            End If
        End If
    End Function

    Public Shared Function MakeMySQLDate(ByVal d As Date, Optional ByVal FullDate As Boolean = True) As String
        If IsDBNull(d) Then
            Return "NULL"
        Else
            If Not FullDate Then
                d = DateSerial(Year(d), Month(d), Day(d))
                Return "str_to_date('" & MakeODBCDate(d) & "','%Y-%m-%d %H:%i:%s')"
            Else
                Return "str_to_date('" & MakeODBCDate(d) & "','%Y-%m-%d %H:%i:%s')"
            End If
        End If
    End Function

    Public Shared Function MakeODBCDate(ByVal d As Date) As String
        'yyyy-mm-dd hh:mi:ss(24h)
        If IsDBNull(d) Then
            Return "NULL"
        Else
            Return Right("0000" & Year(d), 4) & "-" & Right("00" & Month(d), 2) & "-" & Right("00" & d.Day(), 2) & " " & Right("00" & Hour(d), 2) & ":" & Right("00" & Minute(d), 2) & ":" & Right("00" & Second(d), 2)
        End If
    End Function

   

    Public Shared Function IsNULL_SQL(ByVal G_ProviderType As DBProvider.DBProviderType, ByVal ValName As String, ByVal ValReplace As String) As String
        If G_ProviderType = DBProvider.DBProviderType.ORACLE Then
            Return " nvl(" + ValName + "," + ValReplace + ") "
        End If

        If G_ProviderType = DBProvider.DBProviderType.MSSQL Then
            Return " IsNUll(" + ValName + "," + ValReplace + ") "
        End If

        If G_ProviderType = DBProvider.DBProviderType.MYSQL Then
            Return " IFNUll(" + ValName + "," + ValReplace + ") "
        End If
        If G_ProviderType = DBProvider.DBProviderType.POSTGRESQL Then
            Return " IsNUll(" + ValName + "," + ValReplace + ") "
        End If
        
        Return ""
    End Function

    Public Function FormatDT(ByVal G_ProviderType As DBProvider.DBProviderType, ByVal value As Date, Optional ByVal bFull As Boolean = False) As String
        Dim tmpDateTime As Date
        If G_ProviderType = DBProvider.DBProviderType.ORACLE Then
            'TO_DATE('2005-08-15','YYYY-MM-DD')
            If bFull Then
                Return MakeORACLEDate(value)
            Else
                tmpDateTime = DateSerial(Year(value), Month(value), Day(value))
                Return MakeORACLEDate(tmpDateTime)
            End If

        Else

            If bFull Then
                Return MakeMSSQLDate(value)

            Else
                tmpDateTime = DateSerial(Year(value), Month(value), Day(value))
                Return MakeMSSQLDate(tmpDateTime)
            End If
        End If
    End Function

    Public Shared Function CopyObject(ByRef ObjectIn As Document.Doc_Base, ByRef Manager As LATIR2.Manager) As Document.Doc_Base
        Try
            Dim ObjectOut As Document.Doc_Base
            Dim IID As Guid
            Dim i As Long
            IID = Guid.NewGuid
            ObjectOut = Manager.NewInstance(IID, ObjectIn.TypeName, ObjectIn.Name, String.Empty)
            For i = 1 To ObjectIn.CountOfParts
                CopyPart(ObjectIn.GetDocCollection_Base(i), ObjectOut.GetDocCollection_Base(i))
            Next
            ObjectOut.Save()
            Return ObjectOut
        Catch
            Return Nothing
        End Try
    End Function

    Public Shared Sub CopyPart(ByRef ObjectPartIn As Document.DocCollection_Base, ByRef ObjectPartOut As Document.DocCollection_Base)
        Try
            Dim i As Long
            Dim j As Long
            For i = 1 To ObjectPartIn.Count
                Dim pRowOut As Document.DocRow_Base
                Dim pRowIn As Document.DocRow_Base
                pRowIn = ObjectPartIn.Item(i)
                pRowOut = ObjectPartOut.Add("")

                For j = 1 To pRowIn.Count
                    pRowOut.Value(j) = pRowIn.Value(j)
                Next
                pRowOut.Save()

                For j = 1 To pRowIn.CountOfParts
                    CopyPart(pRowIn.GetDocCollection_Base(j), pRowOut.GetDocCollection_Base(j))
                Next
            Next
        Catch
        End Try
    End Sub


    Public Shared Function GetFile(ByVal filePath As String) As Byte()
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim data() As Byte = br.ReadBytes(CInt(fs.Length))

        br.Close()
        fs.Close()

        Return data
    End Function

End Class
