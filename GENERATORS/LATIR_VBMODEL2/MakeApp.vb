Option Strict Off
Option Explicit On
Imports LATIR2Framework.StringHelper
Module MakeApp

    Public Sub MakeApps(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef o As LATIRGenerator.Response)
        Dim s As String = String.Empty
        Dim i As Integer
        Dim n1 As String


        s = s & vbCrLf & "Option Explicit On"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "Imports System.xml"
        s = s & vbCrLf & "Imports LATIR2"
        s = s & vbCrLf & "Imports LATIR2.Document"
        s = s & vbCrLf & "Imports System.Diagnostics"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "Namespace " & ot.name
        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeEnums(m)
        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Реализация документа " & ot.TheComment, ot.the_Comment)
        s = s & vbCrLf & "    Public Class Application"
        s = s & vbCrLf & "        Inherits LATIR2.Document.Doc_Base"
        s = s & vbCrLf & ""


        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Название типа документа")
        s = s & vbCrLf & "        Protected Overrides Function MyTypeName() As String"
        s = s & vbCrLf & "            MyTypeName = """ & ot.name & """"
        s = s & vbCrLf & "        End Function"
        s = s & vbCrLf & ""


        Dim lPartRealCount As Long
        lPartRealCount = 0
        For i = 1 To ot.PART.Count
            If ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Or _
                ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy Or _
                ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie_s_dannimi Or _
                ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                lPartRealCount = lPartRealCount + 1


                n1 = ot.PART.Item(i).Name
                s = s & vbCrLf & MakeComment(" Внутренняя переменная для раздела " & ot.PART.Item(i).Caption)
                s = s & vbCrLf & "  Private m_" & n1 & " As " & n1 & "_col"

                s = s & vbCrLf & MakeComment("Свойство для доступа к строкам раздела " & ot.PART.Item(i).Caption)
                s = s & vbCrLf & "        Public ReadOnly Property " & n1 & "() As " & n1 & "_col"
                s = s & vbCrLf & "            Get"
                s = s & vbCrLf & "                If m_" & n1 & " Is Nothing Then"
                s = s & vbCrLf & "                    m_" & n1 & " = New " & n1 & "_col"
                s = s & vbCrLf & "                    m_" & n1 & ".Application = Me"
                s = s & vbCrLf & "                    m_" & n1 & ".Parent = Me"
                s = s & vbCrLf & "                    m_" & n1 & ".Refresh()"
                s = s & vbCrLf & "                End If"
                s = s & vbCrLf & "                " & n1 & " = m_" & n1 & ""
                s = s & vbCrLf & "            End Get"
                s = s & vbCrLf & "        End Property"
            End If
        Next

        s = s & vbCrLf & MakeComment("Количество разделов в объекте")
        s = s & vbCrLf & "        Public Overrides ReadOnly Property CountOfParts() As Long"
        s = s & vbCrLf & "            Get"
        s = s & vbCrLf & "                CountOfParts = " + CStr(lPartRealCount)
        s = s & vbCrLf & "            End Get"
        s = s & vbCrLf & "        End Property"
        s = s & vbCrLf & ""

        s = s & vbCrLf & MakeComment("Получить раздел по номеру")
        s = s & vbCrLf & "        Public Overrides Function GetDocCollection_Base(ByVal Index As Long) As DocCollection_Base"
        s = s & vbCrLf & "            Select Case Index"
        Dim lTemp As Long
        lTemp = 1
        ot.PART.Sort = "sequence"
        For i = 1 To ot.PART.Count
            If ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Or _
                ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy Or _
                ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie_s_dannimi Or _
                ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                s = s & vbCrLf & "         Case " + CStr(lTemp)
                s = s & vbCrLf & "            return " + ot.PART.Item(i).Name
                lTemp = lTemp + 1
            End If
        Next
        s = s & vbCrLf & "            End Select"
        s = s & vbCrLf & "            return nothing"
        s = s & vbCrLf & "        End Function"

        s = s & vbCrLf & ""
        s = s & vbCrLf & "        Public Overrides Sub Dispose()"

        For i = 1 To ot.PART.Count

            If ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Or _
                            ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy Or _
                            ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie_s_dannimi Or _
                            ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                n1 = ot.PART.Item(i).Name
                s = s & vbCrLf & "            " & n1 & ".Dispose()"
            End If
        Next
        s = s & vbCrLf & "        End Sub"
        s = s & vbCrLf & ""

        s = s & vbCrLf & MakeComment("Поиск элемента в коллекции")
        s = s & vbCrLf & "        Protected Overrides Function FindInCollections(ByVal Table As String, ByVal InstID As String) As LATIR2.Document.DocRow_Base"
        s = s & vbCrLf & "        FindInCollections = Nothing"
        s = s & vbCrLf & "            dim mFindInCollections As LATIR2.Document.DocRow_Base"
        For i = 1 To ot.PART.Count
            If ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Or _
                           ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy Or _
                           ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie_s_dannimi Or _
                           ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                n1 = ot.PART.Item(i).Name
                s = s & vbCrLf & "            mFindInCollections = " & n1 & ".FindObject(Table, InstID)"
                s = s & vbCrLf & "            if not mFindInCollections is nothing then return mFindInCollections"
            End If
        Next

        s = s & vbCrLf & "        End Function"


        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Загрузка данных из XML  файла")
        s = s & vbCrLf & "        Protected Overrides Sub XMLLoadCollections(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)"
        s = s & vbCrLf & "            Dim e_list As XmlNodeList"
        s = s & vbCrLf & "           try"
        For i = 1 To ot.PART.Count
            n1 = ot.PART.Item(i).Name
            If ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Or
                                       ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy Or
                                       ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie_s_dannimi Or
                                       ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                s = s & vbCrLf & "            e_list = node.SelectNodes(""" & n1 & "_COL"")"
                s = s & vbCrLf & "            " & n1 & ".XMLLoad(e_list, LoadMode)"
            End If
        Next

        s = s & vbCrLf & "catch ex as System.Exception"
        s = s & vbCrLf & " Debug.Print( ex.Message + "" >> "" + ex.StackTrace)"
        s = s & vbCrLf & "end try"
        s = s & vbCrLf & "        End Sub"
        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Сохранение данных в XML  файле")
        s = s & vbCrLf & "        Public Overrides Sub XMLSaveCollections(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)"
        For i = 1 To ot.PART.Count
            If ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Or _
                                       ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy Or _
                                       ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie_s_dannimi Or _
                                       ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then

                n1 = ot.PART.Item(i).Name

                s = s & vbCrLf & "            " & n1 & ".XMLSave(node, Xdom)"
            End If
        Next
        s = s & vbCrLf & "        End Sub"



        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Сохранение изменений в базе данных")
        s = s & vbCrLf & "Public Overrides Sub BatchUpdate()"
        For i = 1 To ot.PART.Count
            If ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Or _
                           ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy Or _
                           ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie_s_dannimi Or _
                           ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                s = s & vbCrLf & "    " & ot.PART.Item(i).Name & ".BatchUpdate"
            End If
        Next
        s = s & vbCrLf & "End Sub"


        s = s & vbCrLf & "    End Class"
        s = s & vbCrLf & "End Namespace"

        LATIR2Framework.StringHelper.SetExt(o, "Application", "vb")

        o.Block = "code"
        o.OutNL(s)

    End Sub


    Public Function MakeEnums(ByRef m As MTZMetaModel.MTZMetaModel.Application) As String
        Dim i, j As Integer
        Dim s As String = String.Empty

        For i = 1 To m.FIELDTYPE.Count
            With m.FIELDTYPE.Item(i)
                If .TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                    s = s & vbCrLf & MakeComment("Перечисление " & .the_Comment)
                    s = s & vbCrLf & "public enum enum" & LATIR2Framework.FieldTypesHelper.MakeValidName(.Name) & "'" & LATIR2Framework.StringHelper.NoLF(.the_Comment)
                    For j = 1 To .ENUMITEM.Count
                        s = s & vbCrLf & "  " & LATIR2Framework.FieldTypesHelper.MakeValidName(.Name) & "_" & LATIR2Framework.FieldTypesHelper.MakeValidName(.ENUMITEM.Item(j).Name) & "=" & .ENUMITEM.Item(j).NameValue & "' " & .ENUMITEM.Item(j).Name
                    Next
                    s = s & vbCrLf & "end enum "
                End If
            End With
        Next

        MakeEnums = s

    End Function
End Module