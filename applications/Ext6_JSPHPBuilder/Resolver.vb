Imports System.Web
Imports System.Xml
Imports System.IO

Public Class XY

    Public Address As String
    Public X As String
    Public Y As String
    Public Resolved As Boolean
    Public Function CheckCoords() As Boolean

        'AddressLat='30.314772' and AddressLong ='59.938189' Выборгский
        If (Me.X = "30.314772" And Me.Y = "59.938189") Then

            Return False
        End If

        '809	30.151521	59.770711 Красносельский
        If (Me.X = "30.151521" And Me.Y = "59.770711") Then

            Return False
        End If


        '1120	30.143284	60.023565  Приморский
        If (Me.X = "30.143284" And Me.Y = "60.023565") Then

            Return False
        End If


        '140	30.296554	59.918593 Адмиралтейский
        If (Me.X = "30.296554" And Me.Y = "59.918593") Then

            Return False
        End If
        '206	30.393105	60.005266 Калининский
        If (Me.X = "30.393105" And Me.Y = "60.005266") Then

            Return False
        End If

        '109	30.314027	60.055322 Выборгский СПб
        If (Me.X = "30.314027" And Me.Y = "60.055322") Then

            Return False
        End If

        '216	30.355654	59.935858 Центральный
        If (Me.X = "30.355654" And Me.Y = "59.935858") Then

            Return False
        End If
        '155	30.918009	60.328108 Всеволожский
        If (Me.X = "30.918009" And Me.Y = "60.328108") Then

            Return False
        End If
        '247	30.278678	59.963886 Петроградский
        If (Me.X = "30.278678" And Me.Y = "59.963886") Then

            Return False
        End If
        '415	30.290536	59.828826 Московский
        If (Me.X = "30.290536" And Me.Y = "59.828826") Then

            Return False
        End If

        '122	30.403966	59.866192 Фрунзенский
        If (Me.X = "30.403966" And Me.Y = "59.866192") Then

            Return False
        End If
        '379	30.465833	59.872218 Невский
        If (Me.X = "30.465833" And Me.Y = "59.872218") Then

            Return False
        End If

        '379	30.465833	59.872218 Василеостровский
        If (Me.X = "30.245243" And Me.Y = "59.940857") Then

            Return False
        End If

        If (Me.X = "30.650661" And Me.Y = "60.010587") Then

            Return False
        End If

        If (Me.X = "30.245243" And Me.Y = "59.940857") Then

            Return False
        End If
        Return True


    End Function

End Class

Public Class Resolver
    Public ResolvedCount As Integer
    Public Event Resolving(ByVal Addr As String, ByVal ok As Boolean)

    Private Function getCoords(ByVal address As String) As XY

        Dim myReq As System.Net.WebRequest
        Dim coords As XY = New XY()
        Dim xml_reader As XmlReader
        Dim resp As Stream
        Dim doc As XmlDocument = New System.Xml.XmlDocument()
        Dim hdoc As HtmlDocument
        Dim root As XmlNode
        Dim hroot As HtmlElement
        Dim myCoords As String
        Dim ind As Integer = 0
        Dim initial_str As String = "http://geocode-maps.yandex.ru/1.x/?geocode="
        Dim coda_str As String = "&results=1&key=AEXnz0wBAAAAuIknOwIAVCSGNcmL3JRmL4oleFvd4sUhi6gAAAAAAAAAAAC17rWD4CY5R4vkVh3Btj238dtOPg=="
        Try
            'DocOK = False
            'wb.Navigate(initial_str + address + coda_str)
            'While Not DocOK
            '    Application.DoEvents()
            'End While
            myReq = System.Net.WebRequest.Create(initial_str + address + coda_str)

            resp = myReq.GetResponse().GetResponseStream()

            xml_reader = XmlReader.Create(resp)
            doc.Load(xml_reader)
            'hdoc = wb.Document
            root = doc.ChildNodes(1)
            myCoords = root.ChildNodes(0).ChildNodes(1).ChildNodes(0).ChildNodes(3).InnerText
            'resp.Close()
            'xml_reader.Close()
            ind = myCoords.IndexOf(" ")
            coords.Address = address
            coords.X = myCoords.Substring(0, ind)
            coords.Y = myCoords.Substring(ind + 1, myCoords.Length - ind - 1)

            coords.Resolved = coords.CheckCoords()


        Catch ex As System.Exception
            ' MsgBox(ex.Message & " " & address)

            coords.Resolved = False
            coords.X = "0"
            coords.Y = "0"
            coords.Address = address
        End Try

        Return coords
    End Function


    Public Function ResolveAddresses(Session As LATIR2.Session, ByVal TName As String) As String

        Dim dt As DataTable
        ResolvedCount = 0
        Dim query As String
        query = "select  distinct top 500  instanceid,id," + TName + "_streetid1," + TName + "_house," + TName + "_block," + TName + "_REGIONID," + TName + "_CITYID ," + TName + "_DISTRICTID," + TName + "_addressstring ," + TName + "_longitude," + TName + "_latitude," + TName + "_MapOK," + TName + "_MappingError FROM V_AUTO" + TName + " where  " + TName + "_MapOK_Val=0 and " + TName + "_MappingError_Val=0"
        dt = Session.GetData(query)
        Dim i As Integer
        Dim res As XY = Nothing
        Dim tmp As String
        Dim sOut As String = ""
        For i = 0 To dt.Rows.Count - 1

            res = Nothing
            tmp = dt.Rows(i)(TName + "_" + "regionid") & ", "
            tmp = tmp & dt.Rows(i)(TName + "_" + "districtid") & " район,"
            If dt.Rows(i)(TName + "_" + "cityid") & "" <> "" And dt.Rows(i)(TName + "_" + "cityid") & "" <> dt.Rows(i)(TName + "_" + "regionid") & "" Then
                tmp = tmp & "  " & dt.Rows(i)(TName + "_" + "cityid") & ","
            End If


            If (dt.Rows(i)(TName + "_" + "addressstring") & "" <> "") Then
                If dt.Rows(i)(TName + "_" + "addressstring").ToString().IndexOf("/") >= 0 Then
                    tmp = tmp & " " & dt.Rows(i)(TName + "_" + "addressstring").ToString.Substring(0, dt.Rows(i)(TName + "_" + "addressstring").ToString().IndexOf("/") - 1)
                Else
                    tmp = tmp & " " & dt.Rows(i)(TName + "_" + "addressstring")
                End If

            Else
                tmp = tmp & " " & dt.Rows(i)(TName + "_" + "streetid1")
            End If
            If (dt.Rows(i)(TName + "_" + "house") & "" <> "") Then
                tmp = tmp & ", дом " & dt.Rows(i)(TName + "_" + "house")
            End If


            If (dt.Rows(i)(TName + "_" + "block") & "" <> "") Then
                tmp = tmp & ", к " & dt.Rows(i)(TName + "_" + "block")
            End If
            tmp = tmp.Replace(";", " ")

            sOut += vbCrLf & "  Resolving:" + tmp + ","
            res = getCoords(tmp)
            If Not (res Is Nothing) Then

                If (res.Resolved = True) Then

                    sOut += " Resolved to:" + res.X + "," + res.Y + ","
                    query = "update " + TName + " set MapOK=-1,MappingError=0, latitude='" + res.X + "',longitude='" + res.Y + "' where " + TName + "Id='" + dt.Rows(i)("ID").ToString() + "'"
                    Session.GetData(query)
                    ResolvedCount += 1

                    RaiseEvent Resolving(tmp, True)

                Else

                    sOut += " failed,"
                    query = "update " + TName + " set MapOK=0,MappingError=-1, latitude=0,longitude=0 where " + TName + "Id='" + dt.Rows(i)("ID").ToString() + "'"
                    Session.GetData(query)

                    RaiseEvent Resolving(tmp, False)
                End If

            Else

                sOut += "  error,"
            End If
        Next



        Return sOut




    End Function

   
End Class