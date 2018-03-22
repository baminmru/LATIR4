Public Class frmNG2BKN2

    Private Function BuildCN() As String
        BuildCN = "Database=" & txtNGDB.Text & ";Server=" & txtNGSrv.Text & ";User ID=" & txtNGUsr.Text & ";Pwd=" & txtNGPass.Text & ";"
    End Function
    Dim cn As SqlClient.SqlConnection
    Dim dd As B2D.B2D.Application

    Private Sub cmdStart_Click(sender As System.Object, e As System.EventArgs) Handles cmdStart.Click
        Dim rs As DataTable
        Dim id As Guid
        rs = Manager.Session.GetData("select  * from instance where objtype='B2D'")
        id = rs.Rows(0)("InstanceID")
        dd = Manager.GetInstanceObject(id)

        cn = New SqlClient.SqlConnection(BuildCN())
        cn.Open()
        If cn.State = ConnectionState.Open Then
            Dim x As Integer
            Dim s As String = ""
            For x = 0 To chkImport.CheckedItems.Count - 1
                Select Case chkImport.CheckedItems(x).ToString
                    Case "Справочники"
                        LoadDict()
                    Case "Адресная база"
                        LoadAddr()
                    Case "Фирмы"
                        LoadFirms()
                    Case "Новостройки"
                        LoadNB()

                    Case "Вторичное жилье"
                        LoadSec(txtFirmID.Text)
                    Case "Загародное жилье"
                        LoadCountry(txtFirmID.Text)
                    Case "Коммерческие объекты"
                        LoadCom()
                    Case "Зарубежные объекты"
                        LoadForeign()

                End Select
            Next x




            cn.Close()
        Else
            MsgBox("Error open NG base")
        End If
    End Sub


    Private Sub LoadDict()
        Dim rs As DataTable
        rs = New DataTable
        Dim da As SqlClient.SqlDataAdapter
        Dim cmd As SqlClient.SqlCommand
        Dim i As Integer



        cmd = New SqlClient.SqlCommand("select * from AddressObj where objecttype in(5,6) and  Name is not null and ShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTSubway(rs.Rows(i)("Name"), rs.Rows(i)("ShortName"), rs.Rows(i)("ObjectId"))
        Next

                                                                                                                                                                                                                                                                         
                                                                                                                                                                                                                                                                                                                 


        cmd = New SqlClient.SqlCommand("select * from TAmountType where AmountTypeShortName is not null and AmountTypeName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTAmountType(rs.Rows(i)("AmountTypeName"), rs.Rows(i)("AmountTypeShortName"), rs.Rows(i)("AmountTypeId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TBalcony where BalcName is not null and BalcShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTBalcony(rs.Rows(i)("BalcName"), rs.Rows(i)("BalcShortName"), rs.Rows(i)("BalconyId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TCategoryLiving where CategoryLivShortName is not null and CategoryLivName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTCategoryLiving(rs.Rows(i)("CategoryLivName"), rs.Rows(i)("CategoryLivShortName"), rs.Rows(i)("CategoryLivId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TCurrency where CurName is not null and CurShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTCurrency(rs.Rows(i)("CurName"), rs.Rows(i)("CurShortName"), rs.Rows(i)("CurrencyId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TDecorationNB where Name is not null and ShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTDecorationNB(rs.Rows(i)("Name"), rs.Rows(i)("ShortName"), rs.Rows(i)("Id"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TDegreeBuild where DegreeName is not null and DegreeShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTDegreeBuild(rs.Rows(i)("DegreeName"), rs.Rows(i)("DegreeShortName"), rs.Rows(i)("DegreeBuildId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TEnterHouse where EnterName is not null and EnterShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTEnterHouse(rs.Rows(i)("EnterName"), rs.Rows(i)("EnterShortName"), rs.Rows(i)("EnterHouseId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TFloor where FloorShortName is not null and FloorName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTFloor(rs.Rows(i)("FloorName"), rs.Rows(i)("FloorShortName"), rs.Rows(i)("FloorId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TFridge where FridgeName is not null and FridgeShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTFridge(rs.Rows(i)("FridgeName"), rs.Rows(i)("FridgeShortName"), rs.Rows(i)("FridgeId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TFrontDoor where FDoorName is not null and FDoorShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTFrontDoor(rs.Rows(i)("FDoorName"), rs.Rows(i)("FDoorShortName"), rs.Rows(i)("FrontDoorId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TFurniture where FurnName is not null and FurnShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTFurniture(rs.Rows(i)("FurnName"), rs.Rows(i)("FurnShortName"), rs.Rows(i)("FurnitureId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TGas where GasName is not null and GasShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTGas(rs.Rows(i)("GasName"), rs.Rows(i)("GasShortName"), rs.Rows(i)("GasId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TGuard where GuardName is not null and GuardShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTGuard(rs.Rows(i)("GuardName"), rs.Rows(i)("GuardShortName"), rs.Rows(i)("GuardId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from THeating where HeatingName is not null and HeatingShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTHeating(rs.Rows(i)("HeatingName"), rs.Rows(i)("HeatingShortName"), rs.Rows(i)("HeatingId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from THotWater where HotWName is not null and HotWShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTHotWater(rs.Rows(i)("HotWName"), rs.Rows(i)("HotWShortName"), rs.Rows(i)("HotWaterId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from THouse where HouseName is not null and HouseShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTHouse(rs.Rows(i)("HouseName"), rs.Rows(i)("HouseShortName"), rs.Rows(i)("HouseId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TInet where InetName is not null and InetShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTInet(rs.Rows(i)("InetName"), rs.Rows(i)("InetShortName"), rs.Rows(i)("InetId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TKitchenFurniture where Name is not null and ShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTKitchenFurniture(rs.Rows(i)("Name"), rs.Rows(i)("ShortName"), rs.Rows(i)("Id"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TLandContent where LContName is not null and LContShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTLandContent(rs.Rows(i)("LContName"), rs.Rows(i)("LContShortName"), rs.Rows(i)("LandContentId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TLease where LeaseName is not null and LeaseShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTLease(rs.Rows(i)("LeaseName"), rs.Rows(i)("LeaseShortName"), rs.Rows(i)("LeaseId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TLift where LiftName is not null and LiftShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTLift(rs.Rows(i)("LiftName"), rs.Rows(i)("LiftShortName"), rs.Rows(i)("LiftId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TOven where OvenName is not null and OvenShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTOven(rs.Rows(i)("OvenName"), rs.Rows(i)("OvenShortName"), rs.Rows(i)("OvenId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TParking where ParkName is not null and ParkShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTParking(rs.Rows(i)("ParkName"), rs.Rows(i)("ParkShortName"), rs.Rows(i)("ParkingId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TParkingCapacity where ParkingCapacityName is not null and ParkingCapacityShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable

        For i = 0 To rs.Rows.Count - 1
            FindTParkingCapacity(rs.Rows(i)("ParkingCapacityName"), rs.Rows(i)("ParkingCapacityShortName"), rs.Rows(i)("ParkingCapacityId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TPaymentMethod where ShortName is not null and Name is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTPaymentMethod(rs.Rows(i)("Name"), rs.Rows(i)("ShortName"), rs.Rows(i)("Id"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TPhone where FoneName is not null and FoneShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTPhone(rs.Rows(i)("FoneName"), rs.Rows(i)("FoneShortName"), rs.Rows(i)("PhoneId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TPlanning where PlanName is not null and PlanShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTPlanning(rs.Rows(i)("PlanName"), rs.Rows(i)("PlanShortName"), rs.Rows(i)("PlanningId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TPower where PowerName is not null and PowerShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTPower(rs.Rows(i)("PowerName"), rs.Rows(i)("PowerShortName"), rs.Rows(i)("PowerId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TProperty where PropName is not null and PropShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTProperty(rs.Rows(i)("PropName"), rs.Rows(i)("PropShortName"), rs.Rows(i)("PropertyId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TRoad where RoadName is not null and RoadShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTRoad(rs.Rows(i)("RoadName"), rs.Rows(i)("RoadShortName"), rs.Rows(i)("RoadId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TRoof where RoofName is not null and RoofShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTRoof(rs.Rows(i)("RoofName"), rs.Rows(i)("RoofShortName"), rs.Rows(i)("RoofId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TSewer where SewerName is not null and SewerShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTSewer(rs.Rows(i)("SewerName"), rs.Rows(i)("SewerShortName"), rs.Rows(i)("SewerId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TSLand where SLandName is not null and SlandShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTSLand(rs.Rows(i)("SLandName"), rs.Rows(i)("SlandShortName"), rs.Rows(i)("SLandId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TStateObj where StateObjName is not null and StateObjShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTStateObj(rs.Rows(i)("StateObjName"), rs.Rows(i)("StateObjShortName"), rs.Rows(i)("StateObjId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TStatus where StatusName is not null and StatusShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTStatus(rs.Rows(i)("StatusName"), rs.Rows(i)("StatusShortName"), rs.Rows(i)("StatusId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TStore where StoreName is not null and StoreShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTStore(rs.Rows(i)("StoreName"), rs.Rows(i)("StoreShortName"), rs.Rows(i)("StoreId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TSubTypeCommerc where SubTypeName is not null and SubTypeShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTSubTypeCommerc(rs.Rows(i)("SubTypeName"), rs.Rows(i)("SubTypeShortName"), rs.Rows(i)("SubTypeId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TTV where TVName is not null and TVShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTTV(rs.Rows(i)("TVName"), rs.Rows(i)("TVShortName"), rs.Rows(i)("TVId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TTypeObjCommerc where TypeObjName is not null and TypeObjShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTTypeObjCommerc(rs.Rows(i)("TypeObjName"), rs.Rows(i)("TypeObjShortName"), rs.Rows(i)("TypeObjId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TTypeObjSecond where TObjSecName is not null and TObjSecShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTTypeObjSecond(rs.Rows(i)("TObjSecName"), rs.Rows(i)("TObjSecShortName"), rs.Rows(i)("TypeObjSecondId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TTypeObjZagorod where TypeObjZagorodName is not null and TypeObjZagorodShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable

        For i = 0 To rs.Rows.Count - 1
            FindTTypeObjZagorod(rs.Rows(i)("TypeObjZagorodName"), rs.Rows(i)("TypeObjZagorodShortName"), rs.Rows(i)("TypeObjZagorodId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TUrStatus where UrStatusName is not null and UrStatusShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTUrStatus(rs.Rows(i)("UrStatusName"), rs.Rows(i)("UrStatusShortName"), rs.Rows(i)("UrStatusId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TUrStatusLand where TUrStatusLandShortName is not null and TUrStatusLandName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTUrStatusLand(rs.Rows(i)("TUrStatusLandName"), rs.Rows(i)("TUrStatusLandShortName"), rs.Rows(i)("TUrStatusLandId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TWalls where WallsName is not null and WallsShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTWalls(rs.Rows(i)("WallsName"), rs.Rows(i)("WallsShortName"), rs.Rows(i)("WallsId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TWashingMachine where WashingMachineName is not null and WashingMachineShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable

        For i = 0 To rs.Rows.Count - 1
            FindTWashingMachine(rs.Rows(i)("WashingMachineName"), rs.Rows(i)("WashingMachineShortName"), rs.Rows(i)("WashingMachineId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TWater where WaterName is not null and WaterShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTWater(rs.Rows(i)("WaterName"), rs.Rows(i)("WaterShortName"), rs.Rows(i)("WaterId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TWC where WCName is not null and WCShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTWC(rs.Rows(i)("WCName"), rs.Rows(i)("WCShortName"), rs.Rows(i)("WCId"))
        Next



        cmd = New SqlClient.SqlCommand("select * from TWindowView where WindName is not null and WindShortName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindTWindowView(rs.Rows(i)("WindName"), rs.Rows(i)("WindShortName"), rs.Rows(i)("WindowViewId"))
        Next





    End Sub

    Private Sub LoadAddr()

    End Sub
    '            Case "Фирмы"
    Private Sub LoadFirms()
        Dim rs As DataTable
        rs = New DataTable
        Dim da As SqlClient.SqlDataAdapter
        Dim cmd As SqlClient.SqlCommand
        Dim i As Integer



        cmd = New SqlClient.SqlCommand("select * from FirmRemote where FirmShortName is not null and FirmName is not null ")
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        For i = 0 To rs.Rows.Count - 1
            FindFirm(rs.Rows(i)("FirmName"), rs.Rows(i)("FirmShortName"), rs.Rows(i)("FirmId"))
        Next
    End Sub
    '            Case "Новостройки"
    Private Sub LoadNB()

    End Sub

    '            Case "Вторичное жилье"
    Private Sub LoadSec(ByVal firmid As String)
        Dim rs As DataTable

        Dim da As SqlClient.SqlDataAdapter
        Dim cmd As SqlClient.SqlCommand
        Dim obj As B2S.B2S.Application
        Dim inf As B2S.B2S.B2S_INFO
       
        Dim cmd2 As SqlClient.SqlCommand
        Dim rs2 As DataTable
        rs2 = New DataTable
        Dim da2 As SqlClient.SqlDataAdapter
        Dim i As Integer
        Dim cnt As Integer

        cmd = New SqlClient.SqlCommand("select * from SecondRemote where Firmid=" & firmid)
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        pb.Minimum = 0
        pb.Maximum = rs.Rows.Count
        pb.Value = 0
        For i = 0 To rs.Rows.Count - 1
            pb.Value = i
            Application.DoEvents()
            rs2 = Manager.Session.GetData("select count(*) cnt from B2S_INFO where B2S_INFOid='" + rs.Rows(i)("RowGUID").ToString() + "'")
            
            If rs2.Rows(0)("cnt") = 0 Then
                obj = Manager.NewInstance(Guid.NewGuid, "B2S", rs.Rows(i)("AddressString") & "")
                inf = obj.B2S_INFO.Add(rs.Rows(i)("RowGUID").ToString())

            Else
                rs2 = Manager.Session.GetData("select instanceid  from B2S_INFO where B2S_INFOid='" + rs.Rows(i)("RowGUID").ToString() + "'")
                obj = Manager.GetInstanceObject(New Guid(rs2.Rows(0)("instanceid").ToString))
                inf = obj.B2S_INFO.Item(1)
            End If


            With inf


                '.SecondId = rs.Rows(i)("SecondId")
                '.ListingId = rs.Rows(i)("ListingId")
                Try


                    If TypeName(rs.Rows(i)("TTypeObjSecondId")) <> "DBNull" Then .TTypeObjSecondId = FindByIdTTypeObjSecond(rs.Rows(i)("TTypeObjSecondId"))
                Catch ex As Exception

                End Try
                If TypeName(rs.Rows(i)("SaleRooms")) <> "DBNull" Then .SaleRooms = rs.Rows(i)("SaleRooms")
                If TypeName(rs.Rows(i)("Rooms")) <> "DBNull" Then .Rooms = rs.Rows(i)("Rooms")
                If TypeName(rs.Rows(i)("Amount")) <> "DBNull" Then .Amount = rs.Rows(i)("Amount")
                If TypeName(rs.Rows(i)("TCurrencyId")) <> "DBNull" Then .TCurrencyId = FindByIdTCurrency(rs.Rows(i)("TCurrencyId"))
                If TypeName(rs.Rows(i)("Floor")) <> "DBNull" Then .Floor = rs.Rows(i)("Floor")
                If TypeName(rs.Rows(i)("Floors")) <> "DBNull" Then .Floors = rs.Rows(i)("Floors")
                '.SharedPercent = rs.Rows(i)("SharedPercent")
                Try
                    If TypeName(rs.Rows(i)("TPropertyId")) <> "DBNull" Then .TPropertyId = FindByIdTProperty(rs.Rows(i)("TPropertyId")).ID.ToString()
                Catch ex As Exception

                End Try
                '.TOperationId = rs.Rows(i)("TOperationId")
                If TypeName(rs.Rows(i)("Exclusive")) <> "DBNull" Then .Exclusive = IIf(rs.Rows(i)("Exclusive") = 0, B2S.B2S.enumBoolean.Boolean_Net, B2S.B2S.enumBoolean.Boolean_Da)
                Try
                    If TypeName(rs.Rows(i)("RegionId")) <> "DBNull" Then .RegionID = FindByIdAddr(rs.Rows(i)("RegionId"))
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("DistrictId")) <> "DBNull" Then .DistrictID = FindByIdAddr(rs.Rows(i)("DistrictId"))
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("CityId")) <> "DBNull" Then .CityID = FindByIdAddr(rs.Rows(i)("CityId"))
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("StreetId1")) <> "DBNull" Then .StreetId1 = FindByIdAddr(rs.Rows(i)("StreetId1"))
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("StreetId2")) <> "DBNull" Then .StreetId2 = FindByIdAddr(rs.Rows(i)("StreetId2"))
                Catch ex As Exception

                End Try
                'If TypeName(rs.Rows(i)("TAddressTypeId")) <> "DBNull" Then .AType = FindByIdTadrType(rs.Rows(i)("TAddressTypeId"))
                .House = rs.Rows(i)("House") & ""
                .Block = rs.Rows(i)("Block") & ""
                .addressString = rs.Rows(i)("AddressString") & ""
                Try
                    If TypeName(rs.Rows(i)("Subway")) <> "DBNull" Then .Subway = FindByIdTSubway(rs.Rows(i)("Subway")).ID.ToString
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("TStyleId")) <> "DBNull" Then .TStyleId = FindByIdTTime(rs.Rows(i)("TStyleId"))
                Catch ex As Exception

                End Try
                Try
                    .FromSubway = rs.Rows(i)("FromSubway") & ""
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TPhoneId")) <> "DBNull" Then .TPhoneId = FindByIdTPhone(rs.Rows(i)("TPhoneId")).ID.ToString
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TBalconyId")) <> "DBNull" Then .TBalconyId = FindByIdTBalcony(rs.Rows(i)("TBalconyId")).ID.ToString()
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TStoreId")) <> "DBNull" Then .TStoreId = FindByIdTStore(rs.Rows(i)("TStoreId")).ID.ToString
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TWCId")) <> "DBNull" Then .TWCId = FindByIdTWC(rs.Rows(i)("TWCId")).ID.ToString
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("THotWaterId")) <> "DBNull" Then .THotWaterId = FindByIdTHotWater(rs.Rows(i)("THotWaterId")).ID.ToString
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TLiftId")) <> "DBNull" Then .TLiftId = FindByIdTLift(rs.Rows(i)("TLiftId")).ID.ToString
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TEnterHouseId")) <> "DBNull" Then .TEnterHouseId = FindByIdTEnterHouse(rs.Rows(i)("TEnterHouseId")).ID.ToString
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TWindowViewId")) <> "DBNull" Then .TWindowViewId = FindByIdTWindowView(rs.Rows(i)("TWindowViewId")).ID.ToString
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TFrontDoorId")) <> "DBNull" Then .TFrontDoorId = rs.Rows(i)("TFrontDoorId")
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TOvenId")) <> "DBNull" Then .TOvenId = FindByIdTOven(rs.Rows(i)("TOvenId")).ID.ToString
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SAll")) <> "DBNull" Then .SAll = rs.Rows(i)("SAll")
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SLiving")) <> "DBNull" Then .SLiving = rs.Rows(i)("SLiving")
                Catch ex As Exception

                End Try
                Try

                    .SRooms = rs.Rows(i)("SRooms") & ""
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SKitchen")) <> "DBNull" Then .SKitchen = rs.Rows(i)("SKitchen")
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SBath")) <> "DBNull" Then .SBath = rs.Rows(i)("SBath")
                Catch ex As Exception

                End Try
                Try

                    .SBathDetail = rs.Rows(i)("SBathDetail") & ""
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SHall")) <> "DBNull" Then .SHall = rs.Rows(i)("SHall")
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SWC")) <> "DBNull" Then .SWC = rs.Rows(i)("SWC")
                Catch ex As Exception

                End Try
                Try

                    .SWCDetail = rs.Rows(i)("SWCDetail") & ""
                Catch ex As Exception

                End Try
                Try




                    If TypeName(rs.Rows(i)("THouseId")) <> "DBNull" Then .THouseId = FindByIdTHouse(rs.Rows(i)("THouseId")).ID.ToString
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("DateBuilding")) <> "DBNull" Then .DateBuilding = rs.Rows(i)("DateBuilding")
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("DateRepair")) <> "DBNull" Then .DateRepair = rs.Rows(i)("DateRepair")
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TPlanning")) <> "DBNull" Then .TPlanning = FindByIdTPlanning(rs.Rows(i)("TPlanning")).ID.ToString
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("CeilingHeight")) <> "DBNull" Then .CeilingHeight = rs.Rows(i)("CeilingHeight")
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TStateObjId")) <> "DBNull" Then .TStateObjId = FindByIdTStateObj(rs.Rows(i)("TStateObjId"))
                    '.Surveyors = rs.Rows(i)("Surveyors")
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("Flatmates")) <> "DBNull" Then .Flatmates = rs.Rows(i)("Flatmates")
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("Kids")) <> "DBNull" Then .Kids = rs.Rows(i)("Kids")
                Catch ex As Exception

                End Try
                Try

                    .Note1 = rs.Rows(i)("Note1") & ""
                Catch ex As Exception

                End Try
                Try

                    .Note2 = rs.Rows(i)("Note2") & ""
                Catch ex As Exception

                End Try
                Try

                    .Note3 = rs.Rows(i)("Note3") & ""
                Catch ex As Exception

                End Try
                Try

                    '.DateBegin = rs.Rows(i)("DateBegin")
                    '.DateUpdate = rs.Rows(i)("DateUpdate")
                    If TypeName(rs.Rows(i)("IsIpoteka")) <> "DBNull" Then .IsIpoteka = IIf(rs.Rows(i)("IsIpoteka") = 0, B2S.B2S.enumBoolean.Boolean_Net, B2S.B2S.enumBoolean.Boolean_Da)
                Catch ex As Exception

                End Try
                Try

                    '.Status = rs.Rows(i)("Status")
                    '.WebElit = rs.Rows(i)("WebElit")
                    '.AdditionalInfo = rs.Rows(i)("AdditionalInfo")

                    '.Owner = rs.Rows(i)("Owner")
                    '.OwnerContact = rs.Rows(i)("OwnerContact")
                    '.RowStatus = rs.Rows(i)("RowStatus")
                    '.SourceId = rs.Rows(i)("SourceId")
                    .FirmId = FindByIdFirm(rs.Rows(i)("FirmId"))
                Catch ex As Exception

                End Try
                Try

                    '.ServerId = rs.Rows(i)("ServerId")
                    '.RowGUID = rs.Rows(i)("RowGUID")
                    .AgreementId = rs.Rows(i)("AgreementId") & ""
                Catch ex As Exception

                End Try
                Try

                    .NegotiatedPrice = IIf(rs.Rows(i)("NegotiatedPrice") = 0, B2S.B2S.enumBoolean.Boolean_Net, B2S.B2S.enumBoolean.Boolean_Da)
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("IsPrivate")) <> "DBNull" Then .IsPrivate = IIf(rs.Rows(i)("IsPrivate") = 0, B2S.B2S.enumBoolean.Boolean_Net, B2S.B2S.enumBoolean.Boolean_Da)
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("IsElite")) <> "DBNull" Then .IsElite = IIf(rs.Rows(i)("IsElite") = 0, B2S.B2S.enumBoolean.Boolean_Net, B2S.B2S.enumBoolean.Boolean_Da)
                    '.DateInput = rs.Rows(i)("DateInput")
                    '.ManagerId = rs.Rows(i)("ManagerId")
                Catch ex As Exception

                End Try


                .Save()
            End With





        Next
    End Sub
    'Case "Загародное жилье"
    Private Sub LoadCountry(ByVal firmid As String)
        Dim rs As DataTable

        Dim da As SqlClient.SqlDataAdapter
        Dim cmd As SqlClient.SqlCommand
        Dim obj As B2Z.B2Z.Application
        Dim inf As B2Z.B2Z.B2Z_INFO


        Dim rs2 As DataTable


        Dim i As Integer


        cmd = New SqlClient.SqlCommand("select * from ZagorodRemote where Firmid=" & firmid)
        cmd.Connection = cn
        da = New SqlClient.SqlDataAdapter(cmd)
        rs = New DataTable
        da.Fill(rs)
        pb.Minimum = 0
        pb.Maximum = rs.Rows.Count
        pb.Value = 0
        For i = 0 To rs.Rows.Count - 1
            pb.Value = i
            Application.DoEvents()
            rs2 = Manager.Session.GetData("select count(*) cnt from B2Z_INFO where B2Z_INFOid='" + rs.Rows(i)("RowGUID").ToString() + "'")

            If rs2.Rows(0)("cnt") = 0 Then
                obj = Manager.NewInstance(Guid.NewGuid, "B2Z", rs.Rows(i)("AddressString") & "")
                inf = obj.B2Z_INFO.Add(rs.Rows(i)("RowGUID").ToString())
            Else
                rs2 = Manager.Session.GetData("select instanceid  from B2Z_INFO where B2Z_INFOid='" + rs.Rows(i)("RowGUID").ToString() + "'")
                obj = Manager.GetInstanceObject(New Guid(rs2.Rows(0)("instanceid").ToString))
                inf = obj.B2Z_INFO.Item(1)
            End If

            With inf




                Try

                    If TypeName(rs.Rows(i)("FirmId")) <> "DBNull" Then
                        .FirmId = rs.Rows(i)("FirmId")
                    End If
                Catch ex As Exception

                End Try
                'Try

                '    If TypeName(rs.Rows(i)("ServerId")) <> "DBNull" Then
                '        .ServerId = rs.Rows(i)("ServerId")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("SourceId")) <> "DBNull" Then
                '        .SourceId = rs.Rows(i)("SourceId")
                '    End If
                'Catch ex As Exception

                'End Try
                Try

                    If TypeName(rs.Rows(i)("TTypeObjZagorodId")) <> "DBNull" Then
                        .TTypeObjZagorodId = FindByIdTTypeObjZagorod(rs.Rows(i)("TTypeObjZagorodId"))
                    End If
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("RegionId")) <> "DBNull" Then .RegionID = FindByIdAddr(rs.Rows(i)("RegionId"))
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("DistrictId")) <> "DBNull" Then .DistrictID = FindByIdAddr(rs.Rows(i)("DistrictId"))
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("CityId")) <> "DBNull" Then .CityID = FindByIdAddr(rs.Rows(i)("CityId"))
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("StreetId1")) <> "DBNull" Then .StreetId1 = FindByIdAddr(rs.Rows(i)("StreetId1"))
                Catch ex As Exception

                End Try
                Try
                    If TypeName(rs.Rows(i)("StreetId2")) <> "DBNull" Then .StreetId2 = FindByIdAddr(rs.Rows(i)("StreetId2"))
                Catch ex As Exception

                End Try

                Try

                    If TypeName(rs.Rows(i)("House")) <> "DBNull" Then
                        .House = rs.Rows(i)("House") & ""
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("Block")) <> "DBNull" Then
                        .Block = rs.Rows(i)("Block") & ""
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("AddressString")) <> "DBNull" Then
                        .addressString = rs.Rows(i)("AddressString") & ""
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TUrStatusId")) <> "DBNull" Then
                        .TUrStatusId = FindByIdTUrStatus(rs.Rows(i)("TUrStatusId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TransportationId")) <> "DBNull" Then
                        .TransportationId = FindByIdTTransportation(rs.Rows(i)("TransportationId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("FromTransport")) <> "DBNull" Then
                        .FromTransport = rs.Rows(i)("FromTransport")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("FromCity")) <> "DBNull" Then
                        .FromCity = rs.Rows(i)("FromCity")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TRoadId")) <> "DBNull" Then
                        .TRoadId = FindByIdTRoad(rs.Rows(i)("TRoadId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("Amount")) <> "DBNull" Then
                        .Amount = rs.Rows(i)("Amount")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TCurrencyId")) <> "DBNull" Then
                        .TCurrencyId = FindByIdTCurrency(rs.Rows(i)("TCurrencyId"))
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("Rooms")) <> "DBNull" Then
                        .Rooms = rs.Rows(i)("Rooms")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SAll")) <> "DBNull" Then
                        .SAll = rs.Rows(i)("SAll")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SLiving")) <> "DBNull" Then
                        .SLiving = rs.Rows(i)("SLiving")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SKitchen")) <> "DBNull" Then
                        .SKitchen = rs.Rows(i)("SKitchen")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SRooms")) <> "DBNull" Then
                        .SRooms = rs.Rows(i)("SRooms")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("Floors")) <> "DBNull" Then
                        .Floors = rs.Rows(i)("Floors")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TDegreeBuildId")) <> "DBNull" Then
                        .TDegreeBuildId = FindByIdTDegreeBuild(rs.Rows(i)("TDegreeBuildId"))
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("DateBuild")) <> "DBNull" Then
                        .DateBuild = rs.Rows(i)("DateBuild")
                    End If
                Catch ex As Exception

                End Try
                'Try

                '    If TypeName(rs.Rows(i)("Size")) <> "DBNull" Then
                '        .Size = rs.Rows(i)("Size")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("TBasementId")) <> "DBNull" Then
                '        .TBasementId = rs.Rows(i)("TBasementId")
                '    End If
                'Catch ex As Exception

                'End Try
                Try

                    If TypeName(rs.Rows(i)("TWallsId")) <> "DBNull" Then
                        .TWallsId = FindByIdTWalls(rs.Rows(i)("TWallsId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TRoofId")) <> "DBNull" Then
                        .TRoofId = FindByIdTRoof(rs.Rows(i)("TRoofId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TDecorationId")) <> "DBNull" Then
                        .TDecorationId = FindByIdTDecorationNB(rs.Rows(i)("TDecorationId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("THeatingId")) <> "DBNull" Then
                        .THeatingId = FindByIdTHeating(rs.Rows(i)("THeatingId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TPowerId")) <> "DBNull" Then
                        .TPowerId = FindByIdTPower(rs.Rows(i)("TPowerId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TSewerId")) <> "DBNull" Then
                        .TSewerId = FindByIdTSewer(rs.Rows(i)("TSewerId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TWaterId")) <> "DBNull" Then
                        .TWaterId = FindByIdTWater(rs.Rows(i)("TWaterId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TGasId")) <> "DBNull" Then
                        .TGasId = FindByIdTGas(rs.Rows(i)("TGasId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TWCId")) <> "DBNull" Then
                        .TWCId = FindByIdTWC(rs.Rows(i)("TWCId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TPhoneId")) <> "DBNull" Then
                        .TPhoneId = FindByIdTPhone(rs.Rows(i)("TPhoneId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TStateObjId")) <> "DBNull" Then
                        .TStateObjId = FindByIdTStateObj(rs.Rows(i)("TStateObjId"))
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("SLand")) <> "DBNull" Then
                        .SLand = rs.Rows(i)("SLand")
                    End If
                Catch ex As Exception

                End Try
                'Try

                '    If TypeName(rs.Rows(i)("SLandType")) <> "DBNull" Then
                '        .SLandType =  FindByIdTL rs.Rows(i)("SLandType")
                '    End If
                'Catch ex As Exception

                'End Try
                Try

                    If TypeName(rs.Rows(i)("TLandContentId")) <> "DBNull" Then
                        .TLandContentId = FindByIdTLandContent(rs.Rows(i)("TLandContentId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("RegistrationAllowed")) <> "DBNull" Then
                        .RegistrationAllowed = IIf(rs.Rows(i)("RegistrationAllowed") = 0, B2Z.B2Z.enumBoolean.Boolean_Net, B2Z.B2Z.enumBoolean.Boolean_Da)
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("PrivateProperty")) <> "DBNull" Then
                        .PrivateProperty = IIf(rs.Rows(i)("PrivateProperty") = 0, B2Z.B2Z.enumBoolean.Boolean_Net, B2Z.B2Z.enumBoolean.Boolean_Da)
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("Documents")) <> "DBNull" Then
                        .Documents = rs.Rows(i)("Documents")
                    End If
                Catch ex As Exception

                End Try
                'Try

                '    If TypeName(rs.Rows(i)("TStatusId")) <> "DBNull" Then
                '        .TStatusId = rs.Rows(i)("TStatusId")
                '    End If
                'Catch ex As Exception

                'End Try
                Try

                    If TypeName(rs.Rows(i)("Note1")) <> "DBNull" Then
                        .Note1 = rs.Rows(i)("Note1")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("Note2")) <> "DBNull" Then
                        .Note2 = rs.Rows(i)("Note2")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("Note3")) <> "DBNull" Then
                        .Note3 = rs.Rows(i)("Note3")
                    End If
                Catch ex As Exception

                End Try
                'Try

                '    If TypeName(rs.Rows(i)("Owner")) <> "DBNull" Then
                '        .Owner = rs.Rows(i)("Owner")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("OwnerContact")) <> "DBNull" Then
                '        .OwnerContact = rs.Rows(i)("OwnerContact")
                '    End If
                'Catch ex As Exception

                'End Try

                Try

                    If TypeName(rs.Rows(i)("AdditionalInfo")) <> "DBNull" Then
                        .AdditionalInfo = rs.Rows(i)("AdditionalInfo")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TUrStatusLandId")) <> "DBNull" Then
                        .TUrStatusLandId = FindByIdTUrStatusLand(rs.Rows(i)("TUrStatusLandId")).ID.ToString
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("IsIpoteka")) <> "DBNull" Then
                        .IsIpoteka = IIf(rs.Rows(i)("IsIpoteka") = 0, B2Z.B2Z.enumBoolean.Boolean_Net, B2Z.B2Z.enumBoolean.Boolean_Da)
                    End If
                Catch ex As Exception

                End Try
                'Try

                '    If TypeName(rs.Rows(i)("SharedPercent")) <> "DBNull" Then
                '        .SharedPercent = rs.Rows(i)("SharedPercent")
                '    End If
                'Catch ex As Exception

                'End Try

                'Try

                '    If TypeName(rs.Rows(i)("RowStatus")) <> "DBNull" Then
                '        .RowStatus = rs.Rows(i)("RowStatus")
                '    End If
                'Catch ex As Exception

                'End Try

                Try

                    If TypeName(rs.Rows(i)("AgreementId")) <> "DBNull" Then
                        .AgreementId = rs.Rows(i)("AgreementId")
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("NegotiatedPrice")) <> "DBNull" Then
                        .NegotiatedPrice = IIf(rs.Rows(i)("NegotiatedPrice") = 0, B2Z.B2Z.enumBoolean.Boolean_Net, B2Z.B2Z.enumBoolean.Boolean_Da)
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("IsPrivate")) <> "DBNull" Then
                        .IsPrivate = IIf(rs.Rows(i)("IsPrivate") = 0, B2Z.B2Z.enumBoolean.Boolean_Net, B2Z.B2Z.enumBoolean.Boolean_Da)
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("IsExclusive")) <> "DBNull" Then
                        .IsExclusive = IIf(rs.Rows(i)("IsExclusive") = 0, B2Z.B2Z.enumBoolean.Boolean_Net, B2Z.B2Z.enumBoolean.Boolean_Da)
                    End If
                Catch ex As Exception

                End Try
                'Try

                '    If TypeName(rs.Rows(i)("FromAddress")) <> "DBNull" Then
                '        .FromAddress = rs.Rows(i)("FromAddress")
                '    End If
                'Catch ex As Exception

                'End Try
                Try

                    If TypeName(rs.Rows(i)("SellingPart")) <> "DBNull" Then
                        .SellingPart = IIf(rs.Rows(i)("SellingPart") = 0, B2Z.B2Z.enumBoolean.Boolean_Net, B2Z.B2Z.enumBoolean.Boolean_Da)
                    End If
                Catch ex As Exception

                End Try
                'Try

                '    If TypeName(rs.Rows(i)("AddbuildingIds")) <> "DBNull" Then
                '        .AddbuildingIds = rs.Rows(i)("AddbuildingIds")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("AddbuildingNames")) <> "DBNull" Then
                '        .AddbuildingNames = rs.Rows(i)("AddbuildingNames")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("LandscapeIds")) <> "DBNull" Then
                '        .LandscapeIds = rs.Rows(i)("LandscapeIds")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("LandscapeNames")) <> "DBNull" Then
                '        .LandscapeNames = rs.Rows(i)("LandscapeNames")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("InfrastructureIds")) <> "DBNull" Then
                '        .InfrastructureIds = rs.Rows(i)("InfrastructureIds")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("InfrastructureNames")) <> "DBNull" Then
                '        .InfrastructureNames = rs.Rows(i)("InfrastructureNames")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("THeatingIds")) <> "DBNull" Then
                '        .THeatingIds = rs.Rows(i)("THeatingIds")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("THeatingNames")) <> "DBNull" Then
                '        .THeatingNames = rs.Rows(i)("THeatingNames")
                '    End If
                'Catch ex As Exception

                'End Try
                Try

                    If TypeName(rs.Rows(i)("IsElite")) <> "DBNull" Then
                        .IsElite = IIf(rs.Rows(i)("IsElite") = 0, B2Z.B2Z.enumBoolean.Boolean_Net, B2Z.B2Z.enumBoolean.Boolean_Da)
                    End If
                Catch ex As Exception

                End Try
                Try

                    If TypeName(rs.Rows(i)("TStyleId")) <> "DBNull" Then
                        .TStyleId = FindByIdTTime(rs.Rows(i)("TStyleId"))
                    End If
                Catch ex As Exception

                End Try
                'Try

                '    If TypeName(rs.Rows(i)("TFunctionId")) <> "DBNull" Then
                '        .TFunctionId = rs.Rows(i)("TFunctionId")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("ParentId")) <> "DBNull" Then
                '        .ParentId = rs.Rows(i)("ParentId")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("ParentType")) <> "DBNull" Then
                '        .ParentType = rs.Rows(i)("ParentType")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("DateInput")) <> "DBNull" Then
                '        .DateInput = rs.Rows(i)("DateInput")
                '    End If
                'Catch ex As Exception

                'End Try
                'Try

                '    If TypeName(rs.Rows(i)("ManagerId")) <> "DBNull" Then
                '        .ManagerId = rs.Rows(i)("ManagerId")
                '    End If
                'Catch ex As Exception

                'End Try




                .Save()
            End With





        Next
    End Sub
    '            Case "Коммерческие объекты"
    Private Sub LoadCom()

    End Sub
    '           Case "Зарубежные объекты"
    Private Sub LoadForeign()

    End Sub



    '''''''''''''''''''''' support function

    Private Function FindTInfrastructure(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TInfrastructure
        Dim ot As B2D.B2D.TInfrastructure
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TInfrastructure where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TInfrastructure.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TInfrastructure.Item(rs.Rows(0)("TInfrastructureId").ToString)
        End If
        FindTInfrastructure = ot
    End Function
    Private Function FindTHotWater(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.THotWater
        Dim ot As B2D.B2D.THotWater
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from THotWater where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.THotWater.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.THotWater.Item(rs.Rows(0)("THotWaterId").ToString)
        End If
        FindTHotWater = ot
    End Function
    Private Function FindTStateObj(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TStateObj
        Dim ot As B2D.B2D.TStateObj
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TStateObj where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TStateObj.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TStateObj.Item(rs.Rows(0)("TStateObjId").ToString)
        End If
        FindTStateObj = ot
    End Function
    Private Function FindTTypeObjSecond(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TTypeObjSecond
        Dim ot As B2D.B2D.TTypeObjSecond
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TTypeObjSecond where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TTypeObjSecond.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TTypeObjSecond.Item(rs.Rows(0)("TTypeObjSecondId").ToString)
        End If
        FindTTypeObjSecond = ot
    End Function
    Private Function FindTHouse(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.THouse
        Dim ot As B2D.B2D.THouse
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from THouse where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.THouse.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.THouse.Item(rs.Rows(0)("THouseId").ToString)
        End If
        FindTHouse = ot
    End Function
    Private Function FindTTV(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TTV
        Dim ot As B2D.B2D.TTV
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TTV where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TTV.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TTV.Item(rs.Rows(0)("TTVId").ToString)
        End If
        FindTTV = ot
    End Function
    Private Function FindTWashingMachine(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TWashingMachine
        Dim ot As B2D.B2D.TWashingMachine
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TWashingMachine where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TWashingMachine.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TWashingMachine.Item(rs.Rows(0)("TWashingMachineId").ToString)
        End If
        FindTWashingMachine = ot
    End Function
    Private Function FindTWalls(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TWalls
        Dim ot As B2D.B2D.TWalls
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TWalls where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TWalls.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TWalls.Item(rs.Rows(0)("TWallsId").ToString)
        End If
        FindTWalls = ot
    End Function
    Private Function FindTFrontDoor(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TFrontDoor
        Dim ot As B2D.B2D.TFrontDoor
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TFrontDoor where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TFrontDoor.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TFrontDoor.Item(rs.Rows(0)("TFrontDoorId").ToString)
        End If
        FindTFrontDoor = ot
    End Function
    Private Function FindTKitchenFurniture(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TKitchenFurniture
        Dim ot As B2D.B2D.TKitchenFurniture
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TKitchenFurniture where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TKitchenFurniture.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TKitchenFurniture.Item(rs.Rows(0)("TKitchenFurnitureId").ToString)
        End If
        FindTKitchenFurniture = ot
    End Function
    Private Function FindTWindowView(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TWindowView
        Dim ot As B2D.B2D.TWindowView
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TWindowView where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TWindowView.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TWindowView.Item(rs.Rows(0)("TWindowViewId").ToString)
        End If
        FindTWindowView = ot
    End Function
    Private Function FindTfloorJoists(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TfloorJoists
        Dim ot As B2D.B2D.TfloorJoists
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TfloorJoists where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TfloorJoists.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TfloorJoists.Item(rs.Rows(0)("TfloorJoistsId").ToString)
        End If
        FindTfloorJoists = ot
    End Function
    Private Function FindTFurniture(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TFurniture
        Dim ot As B2D.B2D.TFurniture
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TFurniture where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TFurniture.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TFurniture.Item(rs.Rows(0)("TFurnitureId").ToString)
        End If
        FindTFurniture = ot
    End Function
    Private Function FindTPlanning(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TPlanning
        Dim ot As B2D.B2D.TPlanning
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TPlanning where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TPlanning.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TPlanning.Item(rs.Rows(0)("TPlanningId").ToString)
        End If
        FindTPlanning = ot
    End Function
    Private Function FindTSubFloor(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TSubFloor
        Dim ot As B2D.B2D.TSubFloor
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TSubFloor where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TSubFloor.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TSubFloor.Item(rs.Rows(0)("TSubFloorId").ToString)
        End If
        FindTSubFloor = ot
    End Function
    Private Function FindTStatus(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TStatus
        Dim ot As B2D.B2D.TStatus
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TStatus where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TStatus.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TStatus.Item(rs.Rows(0)("TStatusId").ToString)
        End If
        FindTStatus = ot
    End Function
    Private Function FindTPaymentMethod(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TPaymentMethod
        Dim ot As B2D.B2D.TPaymentMethod
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TPaymentMethod where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TPaymentMethod.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TPaymentMethod.Item(rs.Rows(0)("TPaymentMethodId").ToString)
        End If
        FindTPaymentMethod = ot
    End Function
    Private Function FindTCategoryLiving(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TCategoryLiving
        Dim ot As B2D.B2D.TCategoryLiving
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TCategoryLiving where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TCategoryLiving.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TCategoryLiving.Item(rs.Rows(0)("TCategoryLivingId").ToString)
        End If
        FindTCategoryLiving = ot
    End Function
    Private Function FindTUrStatus(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TUrStatus
        Dim ot As B2D.B2D.TUrStatus
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TUrStatus where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TUrStatus.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TUrStatus.Item(rs.Rows(0)("TUrStatusId").ToString)
        End If
        FindTUrStatus = ot
    End Function
    Private Function FindTAction(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TAction
        Dim ot As B2D.B2D.TAction
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TAction where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TAction.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TAction.Item(rs.Rows(0)("TActionId").ToString)
        End If
        FindTAction = ot
    End Function
    Private Function FindTLease(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TLease
        Dim ot As B2D.B2D.TLease
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TLease where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TLease.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TLease.Item(rs.Rows(0)("TLeaseId").ToString)
        End If
        FindTLease = ot
    End Function
    Private Function FindTProperty(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TProperty
        Dim ot As B2D.B2D.TProperty
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TProperty where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TProperty.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TProperty.Item(rs.Rows(0)("TPropertyId").ToString)
        End If
        FindTProperty = ot
    End Function
    Private Function FindTTime(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TTime
        Dim ot As B2D.B2D.TTime
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TTime where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TTime.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TTime.Item(rs.Rows(0)("TTimeId").ToString)
        End If
        FindTTime = ot
    End Function
    Private Function FindTFloor(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TFloor
        Dim ot As B2D.B2D.TFloor
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TFloor where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TFloor.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TFloor.Item(rs.Rows(0)("TFloorId").ToString)
        End If
        FindTFloor = ot
    End Function
    Private Function FindTAmountType(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TAmountType
        Dim ot As B2D.B2D.TAmountType
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TAmountType where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TAmountType.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TAmountType.Item(rs.Rows(0)("TAmountTypeId").ToString)
        End If
        FindTAmountType = ot
    End Function
    Private Function FindTDegreeBuild(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TDegreeBuild
        Dim ot As B2D.B2D.TDegreeBuild
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TDegreeBuild where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TDegreeBuild.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TDegreeBuild.Item(rs.Rows(0)("TDegreeBuildId").ToString)
        End If
        FindTDegreeBuild = ot
    End Function
    Private Function FindTSewer(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TSewer
        Dim ot As B2D.B2D.TSewer
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TSewer where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TSewer.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TSewer.Item(rs.Rows(0)("TSewerId").ToString)
        End If
        FindTSewer = ot
    End Function
    Private Function FindTReplaning(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TReplaning
        Dim ot As B2D.B2D.TReplaning
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TReplaning where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TReplaning.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TReplaning.Item(rs.Rows(0)("TReplaningId").ToString)
        End If
        FindTReplaning = ot
    End Function
    Private Function FindTGas(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TGas
        Dim ot As B2D.B2D.TGas
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TGas where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TGas.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TGas.Item(rs.Rows(0)("TGasId").ToString)
        End If
        FindTGas = ot
    End Function
    Private Function FindTBoot(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TBoot
        Dim ot As B2D.B2D.TBoot
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TBoot where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TBoot.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TBoot.Item(rs.Rows(0)("TBootId").ToString)
        End If
        FindTBoot = ot
    End Function
    Private Function FindTRoad(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TRoad
        Dim ot As B2D.B2D.TRoad
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TRoad where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TRoad.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TRoad.Item(rs.Rows(0)("TRoadId").ToString)
        End If
        FindTRoad = ot
    End Function
    Private Function FindTLift(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TLift
        Dim ot As B2D.B2D.TLift
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TLift where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TLift.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TLift.Item(rs.Rows(0)("TLiftId").ToString)
        End If
        FindTLift = ot
    End Function
    Private Function FindTRoof(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TRoof
        Dim ot As B2D.B2D.TRoof
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TRoof where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TRoof.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TRoof.Item(rs.Rows(0)("TRoofId").ToString)
        End If
        FindTRoof = ot
    End Function
    Private Function FindTParkingCapacity(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TParkingCapacity
        Dim ot As B2D.B2D.TParkingCapacity
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TParkingCapacity where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TParkingCapacity.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TParkingCapacity.Item(rs.Rows(0)("TParkingCapacityId").ToString)
        End If
        FindTParkingCapacity = ot
    End Function
    Private Function FindTPhone(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TPhone
        Dim ot As B2D.B2D.TPhone
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TPhone where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TPhone.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TPhone.Item(rs.Rows(0)("TPhoneId").ToString)
        End If
        FindTPhone = ot
    End Function
    Private Function FindTLandContent(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TLandContent
        Dim ot As B2D.B2D.TLandContent
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TLandContent where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TLandContent.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TLandContent.Item(rs.Rows(0)("TLandContentId").ToString)
        End If
        FindTLandContent = ot
    End Function
    Private Function FindTWindows(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TWindows
        Dim ot As B2D.B2D.TWindows
        Dim rs As Datatable

        rs = Manager.Session.GetData("select * from TWindows where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TWindows.Add
            With ot
                .Name = Name
                .ShortName = sName
                .ngid = ngid
                .save()
            End With

        Else
            ot = dd.TWindows.Item(rs.Rows(0)("TWindowsId").ToString)
        End If
        FindTWindows = ot
    End Function
    

    Private Function FindTOven(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TOven
        Dim ot As B2D.B2D.TOven
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TOven where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TOven.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TOven.Item(rs.Rows(0)("TOvenId").ToString)
        End If
        FindTOven = ot
    End Function
    Private Function FindTLandStatus(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TLandStatus
        Dim ot As B2D.B2D.TLandStatus
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TLandStatus where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TLandStatus.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TLandStatus.Item(rs.Rows(0)("TLandStatusId").ToString)
        End If
        FindTLandStatus = ot
    End Function
   
    Private Function FindTSLand(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TSLand
        Dim ot As B2D.B2D.TSLand
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TSLand where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TSLand.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TSLand.Item(rs.Rows(0)("TSLandId").ToString)
        End If
        FindTSLand = ot
    End Function
    Private Function FindTSubTypeCommerc(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TSubTypeCommerc
        Dim ot As B2D.B2D.TSubTypeCommerc
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TSubTypeCommerc where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TSubTypeCommerc.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TSubTypeCommerc.Item(rs.Rows(0)("TSubTypeCommercId").ToString)
        End If
        FindTSubTypeCommerc = ot
    End Function
    Private Function FindTGuard(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TGuard
        Dim ot As B2D.B2D.TGuard
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TGuard where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TGuard.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TGuard.Item(rs.Rows(0)("TGuardId").ToString)
        End If
        FindTGuard = ot
    End Function
    Private Function FindTTypeObjCommerc(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TTypeObjCommerc
        Dim ot As B2D.B2D.TTypeObjCommerc
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TTypeObjCommerc where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TTypeObjCommerc.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TTypeObjCommerc.Item(rs.Rows(0)("TTypeObjCommercId").ToString)
        End If
        FindTTypeObjCommerc = ot
    End Function
    Private Function FindTHeating(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.THeating
        Dim ot As B2D.B2D.THeating
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from THeating where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.THeating.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.THeating.Item(rs.Rows(0)("THeatingId").ToString)
        End If
        FindTHeating = ot
    End Function
    Private Function FindTBalcony(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TBalcony
        Dim ot As B2D.B2D.TBalcony
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TBalcony where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TBalcony.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TBalcony.Item(rs.Rows(0)("TBalconyId").ToString)
        End If
        FindTBalcony = ot
    End Function
    Private Function FindTOwnership(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TOwnership
        Dim ot As B2D.B2D.TOwnership
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TOwnership where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TOwnership.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TOwnership.Item(rs.Rows(0)("TOwnershipId").ToString)
        End If
        FindTOwnership = ot
    End Function
    Private Function FindTGarbageType(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TGarbageType
        Dim ot As B2D.B2D.TGarbageType
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TGarbageType where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TGarbageType.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TGarbageType.Item(rs.Rows(0)("TGarbageTypeId").ToString)
        End If
        FindTGarbageType = ot
    End Function
    Private Function FindTSubway(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TSubway
        Dim ot As B2D.B2D.TSubway
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TSubway where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TSubway.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TSubway.Item(rs.Rows(0)("TSubwayId").ToString)
        End If
        FindTSubway = ot
    End Function
    Private Function FindTStore(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TStore
        Dim ot As B2D.B2D.TStore
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TStore where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TStore.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TStore.Item(rs.Rows(0)("TStoreId").ToString)
        End If
        FindTStore = ot
    End Function
    Private Function FindTWater(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TWater
        Dim ot As B2D.B2D.TWater
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TWater where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TWater.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TWater.Item(rs.Rows(0)("TWaterId").ToString)
        End If
        FindTWater = ot
    End Function
    Private Function FindTDecorationNB(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TDecorationNB
        Dim ot As B2D.B2D.TDecorationNB
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TDecorationNB where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TDecorationNB.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TDecorationNB.Item(rs.Rows(0)("TDecorationNBId").ToString)
        End If
        FindTDecorationNB = ot
    End Function
    Private Function FindTTypeObjZagorod(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TTypeObjZagorod
        Dim ot As B2D.B2D.TTypeObjZagorod
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TTypeObjZagorod where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TTypeObjZagorod.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TTypeObjZagorod.Item(rs.Rows(0)("TTypeObjZagorodId").ToString)
        End If
        FindTTypeObjZagorod = ot
    End Function
    Private Function FindTFridge(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TFridge
        Dim ot As B2D.B2D.TFridge
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TFridge where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TFridge.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TFridge.Item(rs.Rows(0)("TFridgeId").ToString)
        End If
        FindTFridge = ot
    End Function
    Private Function FindTCurrency(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TCurrency
        Dim ot As B2D.B2D.TCurrency
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TCurrency where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TCurrency.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TCurrency.Item(rs.Rows(0)("TCurrencyId").ToString)
        End If
        FindTCurrency = ot
    End Function
    Private Function FindTTransportation(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TTransportation
        Dim ot As B2D.B2D.TTransportation
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TTransportation where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TTransportation.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TTransportation.Item(rs.Rows(0)("TTransportationId").ToString)
        End If
        FindTTransportation = ot
    End Function
    Private Function FindTLandscape(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TLandscape
        Dim ot As B2D.B2D.TLandscape
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TLandscape where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TLandscape.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TLandscape.Item(rs.Rows(0)("TLandscapeId").ToString)
        End If
        FindTLandscape = ot
    End Function
    Private Function FindTUrStatusLand(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TUrStatusLand
        Dim ot As B2D.B2D.TUrStatusLand
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TUrStatusLand where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TUrStatusLand.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TUrStatusLand.Item(rs.Rows(0)("TUrStatusLandId").ToString)
        End If
        FindTUrStatusLand = ot
    End Function
    Private Function FindTWC(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TWC
        Dim ot As B2D.B2D.TWC
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TWC where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TWC.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TWC.Item(rs.Rows(0)("TWCId").ToString)
        End If
        FindTWC = ot
    End Function
    Private Function FindTParking(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TParking
        Dim ot As B2D.B2D.TParking
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TParking where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TParking.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TParking.Item(rs.Rows(0)("TParkingId").ToString)
        End If
        FindTParking = ot
    End Function
    Private Function FindTPower(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TPower
        Dim ot As B2D.B2D.TPower
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TPower where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TPower.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TPower.Item(rs.Rows(0)("TPowerId").ToString)
        End If
        FindTPower = ot
    End Function
    Private Function FindTInet(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TInet
        Dim ot As B2D.B2D.TInet
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TInet where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TInet.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TInet.Item(rs.Rows(0)("TInetId").ToString)
        End If
        FindTInet = ot
    End Function
    Private Function FindTCliDog(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TCliDog
        Dim ot As B2D.B2D.TCliDog
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TCliDog where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TCliDog.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TCliDog.Item(rs.Rows(0)("TCliDogId").ToString)
        End If
        FindTCliDog = ot
    End Function
    Private Function FindTEnterHouse(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As B2D.B2D.TEnterHouse
        Dim ot As B2D.B2D.TEnterHouse
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TEnterHouse where name like '%" & Name & "%' or shortname like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            ot = dd.TEnterHouse.Add
            With ot
                .Name = Name
                .ShortName = sName
                .NGid = ngid
                .Save()
            End With

        Else
            ot = dd.TEnterHouse.Item(rs.Rows(0)("TEnterHouseId").ToString)
        End If
        FindTEnterHouse = ot

    End Function


    Private Function FindByIdTAction(ByVal id As Integer) As B2D.B2D.TAction
        Dim ot As B2D.B2D.TAction
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TAction where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TAction.Item(rs.Rows(0)("TActionId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTAmountType(ByVal id As Integer) As B2D.B2D.TAmountType
        Dim ot As B2D.B2D.TAmountType
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TAmountType where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TAmountType.Item(rs.Rows(0)("TAmountTypeId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTBalcony(ByVal id As Integer) As B2D.B2D.TBalcony
        Dim ot As B2D.B2D.TBalcony
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TBalcony where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TBalcony.Item(rs.Rows(0)("TBalconyId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTBoot(ByVal id As Integer) As B2D.B2D.TBoot
        Dim ot As B2D.B2D.TBoot
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TBoot where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TBoot.Item(rs.Rows(0)("TBootId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTCategoryLiving(ByVal id As Integer) As B2D.B2D.TCategoryLiving
        Dim ot As B2D.B2D.TCategoryLiving
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TCategoryLiving where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TCategoryLiving.Item(rs.Rows(0)("TCategoryLivingId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTCliDog(ByVal id As Integer) As B2D.B2D.TCliDog
        Dim ot As B2D.B2D.TCliDog
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TCliDog where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TCliDog.Item(rs.Rows(0)("TCliDogId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTCurrency(ByVal id As Integer) As B2D.B2D.TCurrency
        Dim ot As B2D.B2D.TCurrency
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TCurrency where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TCurrency.Item(rs.Rows(0)("TCurrencyId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTDecorationNB(ByVal id As Integer) As B2D.B2D.TDecorationNB
        Dim ot As B2D.B2D.TDecorationNB
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TDecorationNB where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TDecorationNB.Item(rs.Rows(0)("TDecorationNBId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTDegreeBuild(ByVal id As Integer) As B2D.B2D.TDegreeBuild
        Dim ot As B2D.B2D.TDegreeBuild
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TDegreeBuild where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TDegreeBuild.Item(rs.Rows(0)("TDegreeBuildId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTEnterHouse(ByVal id As Integer) As B2D.B2D.TEnterHouse
        Dim ot As B2D.B2D.TEnterHouse
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TEnterHouse where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TEnterHouse.Item(rs.Rows(0)("TEnterHouseId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTFloor(ByVal id As Integer) As B2D.B2D.TFloor
        Dim ot As B2D.B2D.TFloor
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TFloor where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TFloor.Item(rs.Rows(0)("TFloorId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTfloorJoists(ByVal id As Integer) As B2D.B2D.TfloorJoists
        Dim ot As B2D.B2D.TfloorJoists
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TfloorJoists where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TfloorJoists.Item(rs.Rows(0)("TfloorJoistsId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTFridge(ByVal id As Integer) As B2D.B2D.TFridge
        Dim ot As B2D.B2D.TFridge
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TFridge where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TFridge.Item(rs.Rows(0)("TFridgeId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTFrontDoor(ByVal id As Integer) As B2D.B2D.TFrontDoor
        Dim ot As B2D.B2D.TFrontDoor
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TFrontDoor where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TFrontDoor.Item(rs.Rows(0)("TFrontDoorId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTFurniture(ByVal id As Integer) As B2D.B2D.TFurniture
        Dim ot As B2D.B2D.TFurniture
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TFurniture where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TFurniture.Item(rs.Rows(0)("TFurnitureId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTGarbageType(ByVal id As Integer) As B2D.B2D.TGarbageType
        Dim ot As B2D.B2D.TGarbageType
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TGarbageType where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TGarbageType.Item(rs.Rows(0)("TGarbageTypeId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTGas(ByVal id As Integer) As B2D.B2D.TGas
        Dim ot As B2D.B2D.TGas
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TGas where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TGas.Item(rs.Rows(0)("TGasId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTGuard(ByVal id As Integer) As B2D.B2D.TGuard
        Dim ot As B2D.B2D.TGuard
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TGuard where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TGuard.Item(rs.Rows(0)("TGuardId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTHeating(ByVal id As Integer) As B2D.B2D.THeating
        Dim ot As B2D.B2D.THeating
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from THeating where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.THeating.Item(rs.Rows(0)("THeatingId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTHotWater(ByVal id As Integer) As B2D.B2D.THotWater
        Dim ot As B2D.B2D.THotWater
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from THotWater where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.THotWater.Item(rs.Rows(0)("THotWaterId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTHouse(ByVal id As Integer) As B2D.B2D.THouse
        Dim ot As B2D.B2D.THouse
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from THouse where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.THouse.Item(rs.Rows(0)("THouseId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTInet(ByVal id As Integer) As B2D.B2D.TInet
        Dim ot As B2D.B2D.TInet
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TInet where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TInet.Item(rs.Rows(0)("TInetId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTInfrastructure(ByVal id As Integer) As B2D.B2D.TInfrastructure
        Dim ot As B2D.B2D.TInfrastructure
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TInfrastructure where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TInfrastructure.Item(rs.Rows(0)("TInfrastructureId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTKitchenFurniture(ByVal id As Integer) As B2D.B2D.TKitchenFurniture
        Dim ot As B2D.B2D.TKitchenFurniture
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TKitchenFurniture where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TKitchenFurniture.Item(rs.Rows(0)("TKitchenFurnitureId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTLandContent(ByVal id As Integer) As B2D.B2D.TLandContent
        Dim ot As B2D.B2D.TLandContent
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TLandContent where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TLandContent.Item(rs.Rows(0)("TLandContentId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTLandscape(ByVal id As Integer) As B2D.B2D.TLandscape
        Dim ot As B2D.B2D.TLandscape
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TLandscape where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TLandscape.Item(rs.Rows(0)("TLandscapeId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTLandStatus(ByVal id As Integer) As B2D.B2D.TLandStatus
        Dim ot As B2D.B2D.TLandStatus
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TLandStatus where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TLandStatus.Item(rs.Rows(0)("TLandStatusId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTLease(ByVal id As Integer) As B2D.B2D.TLease
        Dim ot As B2D.B2D.TLease
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TLease where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TLease.Item(rs.Rows(0)("TLeaseId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTLift(ByVal id As Integer) As B2D.B2D.TLift
        Dim ot As B2D.B2D.TLift
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TLift where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TLift.Item(rs.Rows(0)("TLiftId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTOven(ByVal id As Integer) As B2D.B2D.TOven
        Dim ot As B2D.B2D.TOven
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TOven where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TOven.Item(rs.Rows(0)("TOvenId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTOwnership(ByVal id As Integer) As B2D.B2D.TOwnership
        Dim ot As B2D.B2D.TOwnership
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TOwnership where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TOwnership.Item(rs.Rows(0)("TOwnershipId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTParking(ByVal id As Integer) As B2D.B2D.TParking
        Dim ot As B2D.B2D.TParking
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TParking where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TParking.Item(rs.Rows(0)("TParkingId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTParkingCapacity(ByVal id As Integer) As B2D.B2D.TParkingCapacity
        Dim ot As B2D.B2D.TParkingCapacity
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TParkingCapacity where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TParkingCapacity.Item(rs.Rows(0)("TParkingCapacityId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTPaymentMethod(ByVal id As Integer) As B2D.B2D.TPaymentMethod
        Dim ot As B2D.B2D.TPaymentMethod
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TPaymentMethod where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TPaymentMethod.Item(rs.Rows(0)("TPaymentMethodId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTPhone(ByVal id As Integer) As B2D.B2D.TPhone
        Dim ot As B2D.B2D.TPhone
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TPhone where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TPhone.Item(rs.Rows(0)("TPhoneId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTPlanning(ByVal id As Integer) As B2D.B2D.TPlanning
        Dim ot As B2D.B2D.TPlanning
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TPlanning where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TPlanning.Item(rs.Rows(0)("TPlanningId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTPower(ByVal id As Integer) As B2D.B2D.TPower
        Dim ot As B2D.B2D.TPower
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TPower where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TPower.Item(rs.Rows(0)("TPowerId").ToString)
        End If
        Return ot
    End Function
 
    Private Function FindByIdTProperty(ByVal id As Integer) As B2D.B2D.TProperty
        Dim ot As B2D.B2D.TProperty
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TProperty where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TProperty.Item(rs.Rows(0)("TPropertyId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTReplaning(ByVal id As Integer) As B2D.B2D.TReplaning
        Dim ot As B2D.B2D.TReplaning
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TReplaning where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TReplaning.Item(rs.Rows(0)("TReplaningId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTRoad(ByVal id As Integer) As B2D.B2D.TRoad
        Dim ot As B2D.B2D.TRoad
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TRoad where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TRoad.Item(rs.Rows(0)("TRoadId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTRoof(ByVal id As Integer) As B2D.B2D.TRoof
        Dim ot As B2D.B2D.TRoof
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TRoof where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TRoof.Item(rs.Rows(0)("TRoofId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTSewer(ByVal id As Integer) As B2D.B2D.TSewer
        Dim ot As B2D.B2D.TSewer
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TSewer where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TSewer.Item(rs.Rows(0)("TSewerId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTSLand(ByVal id As Integer) As B2D.B2D.TSLand
        Dim ot As B2D.B2D.TSLand
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TSLand where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TSLand.Item(rs.Rows(0)("TSLandId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTStateObj(ByVal id As Integer) As B2D.B2D.TStateObj
        Dim ot As B2D.B2D.TStateObj
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TStateObj where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TStateObj.Item(rs.Rows(0)("TStateObjId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTStatus(ByVal id As Integer) As B2D.B2D.TStatus
        Dim ot As B2D.B2D.TStatus
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TStatus where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TStatus.Item(rs.Rows(0)("TStatusId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTStore(ByVal id As Integer) As B2D.B2D.TStore
        Dim ot As B2D.B2D.TStore
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TStore where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TStore.Item(rs.Rows(0)("TStoreId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTSubFloor(ByVal id As Integer) As B2D.B2D.TSubFloor
        Dim ot As B2D.B2D.TSubFloor
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TSubFloor where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TSubFloor.Item(rs.Rows(0)("TSubFloorId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTSubTypeCommerc(ByVal id As Integer) As B2D.B2D.TSubTypeCommerc
        Dim ot As B2D.B2D.TSubTypeCommerc
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TSubTypeCommerc where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TSubTypeCommerc.Item(rs.Rows(0)("TSubTypeCommercId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTSubway(ByVal id As Integer) As B2D.B2D.TSubway
        Dim ot As B2D.B2D.TSubway
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TSubway where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TSubway.Item(rs.Rows(0)("TSubwayId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTTime(ByVal id As Integer) As B2D.B2D.TTime
        Dim ot As B2D.B2D.TTime
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TTime where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TTime.Item(rs.Rows(0)("TTimeId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTTransportation(ByVal id As Integer) As B2D.B2D.TTransportation
        Dim ot As B2D.B2D.TTransportation
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TTransportation where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TTransportation.Item(rs.Rows(0)("TTransportationId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTTV(ByVal id As Integer) As B2D.B2D.TTV
        Dim ot As B2D.B2D.TTV
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TTV where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TTV.Item(rs.Rows(0)("TTVId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTTypeObjCommerc(ByVal id As Integer) As B2D.B2D.TTypeObjCommerc
        Dim ot As B2D.B2D.TTypeObjCommerc
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TTypeObjCommerc where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TTypeObjCommerc.Item(rs.Rows(0)("TTypeObjCommercId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTTypeObjSecond(ByVal id As Integer) As B2D.B2D.TTypeObjSecond
        Dim ot As B2D.B2D.TTypeObjSecond
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TTypeObjSecond where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TTypeObjSecond.Item(rs.Rows(0)("TTypeObjSecondId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTTypeObjZagorod(ByVal id As Integer) As B2D.B2D.TTypeObjZagorod
        Dim ot As B2D.B2D.TTypeObjZagorod
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TTypeObjZagorod where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TTypeObjZagorod.Item(rs.Rows(0)("TTypeObjZagorodId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTUrStatus(ByVal id As Integer) As B2D.B2D.TUrStatus
        Dim ot As B2D.B2D.TUrStatus
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TUrStatus where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TUrStatus.Item(rs.Rows(0)("TUrStatusId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTUrStatusLand(ByVal id As Integer) As B2D.B2D.TUrStatusLand
        Dim ot As B2D.B2D.TUrStatusLand
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TUrStatusLand where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TUrStatusLand.Item(rs.Rows(0)("TUrStatusLandId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTWalls(ByVal id As Integer) As B2D.B2D.TWalls
        Dim ot As B2D.B2D.TWalls
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TWalls where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TWalls.Item(rs.Rows(0)("TWallsId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTWashingMachine(ByVal id As Integer) As B2D.B2D.TWashingMachine
        Dim ot As B2D.B2D.TWashingMachine
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TWashingMachine where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TWashingMachine.Item(rs.Rows(0)("TWashingMachineId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTWater(ByVal id As Integer) As B2D.B2D.TWater
        Dim ot As B2D.B2D.TWater
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TWater where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TWater.Item(rs.Rows(0)("TWaterId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTWC(ByVal id As Integer) As B2D.B2D.TWC
        Dim ot As B2D.B2D.TWC
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TWC where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TWC.Item(rs.Rows(0)("TWCId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTWindows(ByVal id As Integer) As B2D.B2D.TWindows
        Dim ot As B2D.B2D.TWindows
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TWindows where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TWindows.Item(rs.Rows(0)("TWindowsId").ToString)
        End If
        Return ot
    End Function
    Private Function FindByIdTWindowView(ByVal id As Integer) As B2D.B2D.TWindowView
        Dim ot As B2D.B2D.TWindowView
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from TWindowView where ngid=" & id.ToString())
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            ot = dd.TWindowView.Item(rs.Rows(0)("TWindowViewId").ToString)
        End If
        Return ot
    End Function

    ' firm  tools
    Private Function FindFirm(ByVal Name As String, ByVal sName As String, ByVal ngid As Integer) As BFIRM.BFIRM.BFRM_DEF

        Dim ot As BFIRM.BFIRM.BFRM_DEF
        Dim cli As BFIRM.BFIRM.Application
        Dim rs As DataTable
        Dim id As Guid

        rs = Manager.Session.GetData("select * from BFRM_DEF where name like '%" & Name & "%' or nameshort like '%" & sName & "%'")
        If rs.Rows.Count = 0 Then
            id = Guid.NewGuid
            cli = Manager.NewInstance(id, "BFRM", Name)

            ot = cli.BFRM_DEF.Add
            With ot
                .Name = Name
                .NameShort = sName
                .theComment = ngid.ToString
                .Save()
            End With

        Else
            cli = Manager.GetInstanceObject(rs.Rows(0)("instanceid"))
            ot = cli.BFRM_DEF.Item(rs.Rows(0)("BFRM_DEFId").ToString)
        End If
        Return ot
    End Function

    Private Function FindByIdFirm(ByVal id As Integer) As BFIRM.BFIRM.BFRM_DEF
        Dim ot As BFIRM.BFIRM.BFRM_DEF
        Dim cli As BFIRM.BFIRM.Application
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from BFRM_DEF where convert(varchar(10),thecomment)='" & id.ToString() & "'")
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            cli = Manager.GetInstanceObject(rs.Rows(0)("InstanceId"))
            ot = cli.BFRM_DEF.Item(rs.Rows(0)("BFRM_DEFId").ToString)
        End If
        Return ot
    End Function

    Private Function FindByIdAddr(ByVal id As Integer) As B2G.B2G.B2G_Addr
        Dim ot As B2G.B2G.B2G_Addr
        Dim cli As B2G.B2G.Application
        Dim rs As DataTable

        rs = Manager.Session.GetData("select * from B2G_Addr where objectid=" & id.ToString() & "")
        If rs.Rows.Count = 0 Then
            Return Nothing

        Else
            cli = Manager.GetInstanceObject(rs.Rows(0)("InstanceId"))
            ot = cli.B2G_Addr.Item(rs.Rows(0)("B2G_AddrId").ToString)
        End If
        Return ot
    End Function

    'Private Function FindByIdB2G_ADRTYPE(ByVal id As Integer) As B2G.B2G.B2G_ADRTYPE
    '    Dim ot As B2D.B2D.TBoot
    '    Dim rs As DataTable

    '    rs = Manager.Session.GetData("select * from B2G_ADRTYPE where ngid=" & id.ToString())
    '    If rs.Rows.Count = 0 Then
    '        Return Nothing

    '    Else
    '        ot = dd.TBoot.Item(rs.Rows(0)("TBootId").ToString)
    '    End If
    '    Return ot
    'End Function
End Class