Imports System.Threading
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Net
Public Class frmMain
    Dim thrd As Thread
    Dim thrd2 As Thread
    Dim thrd3 As Thread
    Dim Logincookie As CookieContainer
#Region "Connection"
    Dim oCompany As SAPbobsCOM.Company
    Public isConnected As Boolean
    Function oConnect() As Boolean
        Try
            Dim oCtr As Integer = 0
ConnectCompany:
            'oRegistry.GetKeyValue("ServerType"), oRegistry.GetKeyValue("ServerName"), oRegistry.GetKeyValue("UserName"), AppTech.Decrypt(oRegistry.GetKeyValue("Password")), sapDb, sapUser, sapPass, APP_DiServer.oLanguages.ln_English, oRegistry.GetKeyValue("LicenseServer"), ""
            'Connect to SERVER
            oCompany = New SAPbobsCOM.Company

            ''12/21/2013
            ''Change to RegistryKey
            oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB
            oCompany.Server = Split(GetInfo("HanaServer", 0), "|")(4)
            oCompany.CompanyDB = Split(GetInfo("Database", 0), "|")(1)
            oCompany.DbUserName = Split(GetInfo("HanaUser", 0), "|")(5)
            oCompany.DbPassword = AppTech.Decrypt(Split(GetInfo("HanaPassword", 0), "|")(6))
            oCompany.UserName = Split(GetInfo("SAPUser", 0), "|")(2)
            oCompany.Password = AppTech.Decrypt(Split(GetInfo("SAPPassword", 0), "|")(3))

            If Not oCompany.Connect = 0 Then
                'AppTech.SetMessage(oCompany.GetLastErrorDescription, APP_DotNet.App_DotNet.App_MessageType.oError)
                If oCompany.GetLastErrorCode = -131 Then
                    GC.Collect()
                    'oCompany.Disconnect()
                    Try
                        Marshal.FinalReleaseComObject(oCompany)
                        'Marshal.FinalReleaseComObject(oRec)
                    Catch ex As Exception
                    End Try
                    If oCtr = 0 Then
                        oCtr += 1
                        GoTo ConnectCompany
                    End If

                ElseIf oCompany.GetLastErrorDescription = "Connection with license server failed" Then
                    GC.Collect()
                    'oCompany.Disconnect()
                    Try
                        Marshal.FinalReleaseComObject(oCompany)
                        'Marshal.FinalReleaseComObject(oRec)
                    Catch ex As Exception
                    End Try
                    If oCtr = 0 Then
                        oCtr += 1
                        GoTo ConnectCompany
                    End If
                ElseIf oCompany.GetLastErrorDescription = " - The specified resource name cannot be found in the image file." Then
                    GC.Collect()
                    'oCompany.Disconnect()
                    Try
                        Marshal.FinalReleaseComObject(oCompany)
                        'Marshal.FinalReleaseComObject(oRec)
                    Catch ex As Exception
                    End Try
                    If oCtr = 0 Then
                        oCtr += 1
                        GoTo ConnectCompany
                    End If
                ElseIf oCompany.GetLastErrorDescription = "Unable to initialize OBServerDLL.dll" Then
                    GC.Collect()
                    'oCompany.Disconnect()
                    Try
                        Marshal.FinalReleaseComObject(oCompany)
                        'Marshal.FinalReleaseComObject(oRec)
                    Catch ex As Exception
                    End Try
                    If oCtr = 0 Then
                        oCtr += 1
                        GoTo ConnectCompany
                    End If
                End If
                isConnected = False

                oWriteText(impLog, Now & " - " & "[Err] - " & oCompany.GetLastErrorDescription, Color.Red, True)
                Return False
            End If

            isConnected = True
            'oRec = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)

            'MsgBox(Split(GetConn("Database"), "|")(1))
        Catch ex As Exception
            'oWriteText(frm_Import.lsViewIm, "[Err] - " & ex.ToString, Color.Red, True)
            Return False
        End Try
        Return True
    End Function

#End Region
    Private Sub DBConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DBConfigurationToolStripMenuItem.Click
        frmConfig.ShowDialog()
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Dim AppID As Integer, LastImportDateFrom As String, LastImportDateTo As String
    Private Sub OngetDateImport()

        Dim DpSURL As New Uri("https://" & Split(GetInfo("HanaServer", 0), "|")(4) & ":4300/app_xsjs/getDateFromTo.xsjs?UID=" & AppID)
        Dim DpSRes = XSJSGETRequest(DpSURL)
        Dim DsPJObject = JObject.Parse(DpSRes)
        Dim strLIDF As Date = DsPJObject.SelectToken("0.U_LastFromDate")
        Dim strLIDT As Date = DsPJObject.SelectToken("0.U_LastFromDate")
        LastImportDateFrom = strLIDF.ToString("yyyy-MM-dd") & "T" & strLIDF.ToString("HH:mm:ss tt")
        LastImportDateTo = strLIDT.ToString("yyyy-MM-dd") & "T" & strLIDT.ToString("HH:mm:ss tt")
    End Sub

    Private Sub get_ItemMasterData()
        AppID = 1
        OngetDateImport()
        Dim ITM As New Uri("http://" & Split(GetInfo("APIserver", 0), "|")(7) & "/secured/thirdparty/tmcinventoryinterface/getoutboundUOM?orgcode=TMC&fromdate=" & LastImportDateFrom & "&todate=" & LastImportDateTo)
        Dim oITM = AASLGETRequest(ITM)
        Dim oSaveFile As New System.IO.StreamWriter(Application.StartupPath + "\Inbound\Items\Items.json", True)
        oSaveFile.WriteLine(oITM)

        oSaveFile.Close()
        oSaveFile.Dispose()
    End Sub

    Private Sub GetUoMConvertion()
        AppID = 1
        OngetDateImport()
        Dim UoMC As New Uri("http://" & Split(GetInfo("APIserver", 0), "|")(7) & "/secured/thirdparty/tmcinventoryinterface/getoutboundUOMConversion?orgcode=TMC&fromdate=" & LastImportDateFrom & "&todate=" & LastImportDateTo)
        Dim oUoMC = AASLGETRequest(UoMC)
        Dim oSaveFile As New System.IO.StreamWriter(Application.StartupPath + "\Inbound\Items\Items.json", True)
        oSaveFile.WriteLine(oUoMC)

        oSaveFile.Close()
        oSaveFile.Dispose()
    End Sub

    Private Sub getUOM()
        AppID = 1
        OngetDateImport()
        Dim UoM As New Uri("http://" & Split(GetInfo("APIserver", 0), "|")(7) & "/secured/thirdparty/tmcinventoryinterface/getoutboundUOM?orgcode=TMC&fromdate=" & LastImportDateFrom & "&todate=" & LastImportDateTo)

        Dim oUoM = AASLGETRequest(UoM)
        Dim oSaveFile As New System.IO.StreamWriter(Application.StartupPath + "\Inbound\Items\Items.json", True)
        oSaveFile.WriteLine(oUoM)

        oSaveFile.Close()
        oSaveFile.Dispose()
    End Sub

    Private Sub Import_ItemMasterData()
        'Try
        Import_UnitOfMeasure()
            Import_UgpGroup()

            Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\Items\Items.json")
            Dim data = JArray.Parse(jsonstring)
            Dim maxbar As Integer = data.Count
            Dim vbar As Integer = 0
            ProgressBar1.Maximum = maxbar

            Dim isAdd As Boolean = False
            For Each oItems As JObject In data
                ProgressBar1.Value = Val(vbar) + 1
                Dim itmgrp As String = ""
                Dim count As Integer = 0
                Dim ITM As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/Items?$select=ItemCode,ItemsGroupCode&$filter=ItemCode eq '" & oItems("ItemCode").ToString & "'")
                Dim oITM = SLGETRequest(ITM)
                Dim myJObject = JObject.Parse(oITM)
                count = myJObject.SelectToken("value").Count

                If count = 0 Then
                    isAdd = True
                Else
                    isAdd = False
                End If

                Dim Items As New Items
                Items.ItemCode = oItems("ItemCode")
                Items.ItemName = oItems("ItemName")
                Items.ForeignName = oItems("ShortName")

                Dim oItGroup As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/ItemGroups?$select=Number&$filter=GroupName eq '" & oItems("ItemGroup").ToString & "'")
                Dim itGroup = SLGETRequest(oItGroup)
                Dim getGrp = JObject.Parse(itGroup)
                Dim grpResp = getGrp.SelectToken("value[0].Number")

                Items.ItemsGroupCode = grpResp
                Items.InventoryUOM = oItems("UomCode")
                Items.Frozen = IIf(oItems("Active") = "Y", "tNO", "tYES")
                Items.U_APPBrandName = oItems("BrandName")
                Items.U_APPGenericName = oItems("GenericName")
            Dim Warehouse = oItems("StoreCode").Values
            For Each oWarehouse As JValue In Warehouse
                Items.ItemWarehouseInfoCollection.Add(New ItemWarehouseInfoCollection() With {.WarehouseCode = oWarehouse.Value})
            Next

            Dim ItemStr = JsonConvert.SerializeObject(Items)

            If isAdd Then
                    Dim URI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/Items")
                    Dim result = SLPOSTRequest(URI, ItemStr)
                    oWriteText(impLog, oItems("ItemName").ToString & " - " & oItems("ItemCode").ToString & " is successfully Added", Color.Green)
                Else
                    Dim URI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/Items('" & oItems("ItemCode").ToString & "')")
                    Dim result = SLPatchRequest(URI, ItemStr)
                    oWriteText(impLog, oItems("ItemName").ToString & " - " & oItems("ItemCode").ToString & " is successfully Updated", Color.Green)
                End If
            Next
            ProgressBar1.Value = ProgressBar1.Maximum
        'Catch ex As Exception
        '    oWriteText(impLog, ex.Message, Color.Red)
        'End Try
    End Sub

    Private Sub Import_UnitOfMeasure()
        'Try
        Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\Uom\Uom.json")
            Dim data = JArray.Parse(jsonstring)
            Dim UoMMax As Integer = data.Count
            Dim vUoM As Integer = 0
            'ProgressBar2.Maximum = UoMMax
            Dim isAdd As Boolean = False

            For Each oUOM As JObject In data

                Dim UoMURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/UnitOfMeasurements?$select=Code&$filter=Name eq '" & oUOM("UomName").ToString & "'")
                Dim UOMRes = SLGETRequest(UoMURL)
                Dim UoMJObject = JObject.Parse(UOMRes)
                Dim UoMGet = UoMJObject.SelectToken("value").Count

                If UoMGet = 0 Then
                    isAdd = True
                Else
                    isAdd = False
                End If

                Dim UoMs As New UoM
                UoMs.Code = oUOM("UomCode")
                UoMs.Name = oUOM("UomName")
                'UoMs.IsActive = IIf(oUOM("Y") = "Y", "tNO", "tYES")

                Dim UoMStr = JsonConvert.SerializeObject(UoMs)

                If isAdd Then
                    Dim URI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/UnitOfMeasurements")
                    Dim result = SLPOSTRequest(URI, UoMStr)
                    oWriteText(impLog, oUOM("UomCode").ToString & " - " & oUOM("UomName").ToString & " is successfully Added", Color.Green)
                End If

            Next

        'Catch ex As Exception
        '    oWriteText(impLog, ex.Message, Color.Red)
        'End Try
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        impLog.Items.Clear()
        impLog.Columns.Clear()
        impLog.Columns.Add("Import-Log", 300, HorizontalAlignment.Left)
        impLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        'testAPI()
    End Sub

    Private Sub Import_UgpGroup()
        'Try
        Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\Uom\UomGrp.json")
            Dim data = JArray.Parse(jsonstring)
            Dim pdMax As Integer = data.Count
            Dim vPD As Integer = 0
          
            Dim isAdd As Boolean = False

            For Each oGrp As JObject In data
            Dim DpSURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/UnitOfMeasurementGroups?$select=Code&$filter=Code eq '" & oGrp("fromUomName").ToString & "'")
            Dim DpSRes = SLGETRequest(DpSURL)
                Dim DsPJObject = JObject.Parse(DpSRes)
                Dim DsPGet = DsPJObject.SelectToken("value").Count
                If DsPGet = 0 Then
                    isAdd = True
                Else
                    isAdd = False
                End If

            Dim uUOMGrp As New UomGroup
            uUOMGrp.Code = oGrp("fromUomCode")
            uUOMGrp.Name = oGrp("fromUomName")


            Dim UomArry = oGrp("conversionRatio")

            For Each AltQty In UomArry
                Dim oUoMURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/UnitOfMeasurements?$select=AbsEntry&$filter=Code eq '" & oGrp("fromUomCode").ToString & "'")
                Dim oUoMRes = SLGETRequest(oUoMURL)
                Dim oUoMJObject = JObject.Parse(oUoMRes)
                Dim oUoMPGet = oUoMJObject.SelectToken("value[0].AbsEntry")

                uUOMGrp.BaseUoM = oUoMPGet
                uUOMGrp.UoMGroupDefinitionCollection.Add(New UoMGroupDefinitionCollection() With {.AlternateUoM = oUoMPGet,
                                                                                                  .BaseQuantity = AltQty("conversionFactor"),
                                                                                                  .AlternateQuantity = AltQty("conversionFactor")})
            Next

            Dim oUOGrpStr = JsonConvert.SerializeObject(uUOMGrp)
            If isAdd Then
                Dim URI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/UnitOfMeasurementGroups")
                Dim result = SLPOSTRequest(URI, oUOGrpStr)
                'oWriteText(impLog, "UOMGRoup successfully Added", Color.Green)
            End If
            Next



        'Catch ex As Exception
        '    oWriteText(impLog, ex.Message, Color.Red)
        'End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnItems.Click
        Try
            thrd = New Thread(DirectCast(Sub() Import_ItemMasterData(), ThreadStart))
            thrd.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUOM_Click(sender As Object, e As EventArgs)
        'Try
        '    thrd2 = New Thread(DirectCast(Sub() Import_UnitOfMeasure(), ThreadStart))
        '    thrd2.Start()
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If chckPD.Checked Then
            import_downPayment()
        End If
    End Sub

    Sub Import_IncomingPay()
        'Try
        Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\Deposit\PatientDiposit.json")
        Dim data = JArray.Parse(jsonstring)
        Dim pdMax As Integer = data.Count
        Dim vPD As Integer = 0
        pgPDeposit.Maximum = pdMax
        Dim isAdd As Boolean = False

        For Each oDPS As JObject In data
            Dim DpSURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/IncomingPayments?$select=U_APPReference&$filter=U_APPReference eq '" & oDPS("InvoiceNo").ToString & "'")
            Dim DpSRes = SLGETRequest(DpSURL)
            Dim DsPJObject = JObject.Parse(DpSRes)
            Dim DsPGet = DsPJObject.SelectToken("value").Count
            If DsPGet = 0 Then
                Dim uICDs As New IncomingPayDep

                uICDs.CardCode = oDPS("CustomerCode")
                'uICDs.CardName = oDPS("PatientName")
                Dim dDate As String = oDPS("DocDate")
                Dim newDdate As String = dDate.Substring(0, 10)
                uICDs.DocDate = newDdate
                'uICDs.CounterReference = oDPS("CRNumber")
                uICDs.U_APPVistNumber = oDPS("VisitNumber")
                uICDs.U_APPReference = oDPS("InvoiceNo")
                uICDs.Remarks = oDPS("Comments")

                Dim PaymentMeans = oDPS("Payment")
                For Each PaymentMode In PaymentMeans
                    Dim checkPM = PaymentMode("PaymentMode")
                    If (PaymentMode("PaymentMode") = "Cash") Then
                        'Dim DatePay As String = PaymentMode("PaidDate")
                        'Dim NewDatePay As String = DatePay.Substring(0, 10)
                        'uICDs.DueDate = NewDatePay
                        uICDs.CashSum = PaymentMode("PaidAmount")
                        uICDs.CashSumSys = PaymentMode("PaidAmount")

                        Dim IncomePStr = JsonConvert.SerializeObject(uICDs)
                        Dim POSTIPURI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/IncomingPayments")
                        Dim resultPI = SLPOSTRequest(POSTIPURI, IncomePStr)
                    ElseIf (PaymentMode("PaymentMode") = "Card") Then
                        oWriteText(impLog, "Function not Working yet", Color.Orange)

                    Else

                    End If
                Next
                'Deposit here
                'Dim DpSStr = JsonConvert.SerializeObject(DPDs)
                'Dim URIPD As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/Deposits")
                'Dim resultPD = SLPOSTRequest(URIPD, DpSStr)
                'oWriteText(impLog, oDPS("PatientName").ToString & " - " & oDPS("InvoiceNo").ToString & " is successfully Added", Color.Green)
            End If
        Next
        'Catch ex As Exception
        '    oWriteText(impLog, ex.Message, Color.Red)
        'End Try
    End Sub

    Sub Import_downPayment()
        Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\Deposit\PatientDiposit.json")
        Dim data = JArray.Parse(jsonstring)
        Dim pdMax As Integer = data.Count
        Dim vPD As Integer = 0
        pgPDeposit.Maximum = pdMax
        Dim isAdd As Boolean = False

        For Each oDPS As JObject In data
            Dim DpSURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/DownPayments?$select=U_APPReference&$filter=U_APPReference eq '" & oDPS("InvoiceNo").ToString & "'")
            Dim DpSRes = SLGETRequest(DpSURL)
            Dim DsPJObject = JObject.Parse(DpSRes)
            Dim DsPGet = DsPJObject.SelectToken("value").Count
            If DsPGet = 0 Then
                Dim DPDs As New Deposit
                DPDs.U_APPReference = oDPS("InvoiceNo")
                DPDs.U_CANCELED = oDPS("Canceled")
                DPDs.U_APPAdmitDateFrom = oDPS("AdmissionDate")
                DPDs.U_APPCrNumber = oDPS("CRNumber")
                DPDs.U_APPVistNumber = oDPS("VisitNumber")
                DPDs.U_APPInvNumber = oDPS("InvoiceNo")
                DPDs.U_APPRefundNumber = oDPS("RefundNo")
                DPDs.U_APPPatientType = IIf(oDPS("PatientType") = "IPD", "In-Patient", "Out-Patient")
                DPDs.APPORNumber = oDPS("ORNumber")
                DPDs.U_APPSeniorId = oDPS("SeniorID")
                DPDs.U_APPPwdId = oDPS("PwdID")
                DPDs.U_APPPIN = oDPS("PIN")
                DPDs.CardCode = IIf(oDPS("PatientType") = "IPD", "C99998", "C99999")
                DPDs.CardName = oDPS("PatientName")
                DPDs.DocDate = oDPS("DocDate")
                DPDs.NumAtCard = oDPS("PatientName")
                DPDs.Comments = oDPS("Comments")

                Dim Payment = oDPS("Payment")

                For Each PaymentMode In Payment
                    DPDs.DocumentLines.Add(New CheckLines() With {.UnitPrice = PaymentMode("PaidAmount")})
                Next

                ''insert here
                Dim DpSStr = JsonConvert.SerializeObject(DPDs)
                Dim URIPD As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/DownPayments")
                Dim resultPD = SLPOSTRequest(URIPD, DpSStr)

                pgPDeposit.Value = Val(vPD) + 1

                Dim getDocEntry = JObject.Parse(resultPD)
                Dim DocEntry = getDocEntry.SelectToken("DocEntry")

                'Insert Incoming Payment
                Dim uICDs As New IncomingPayDep
                uICDs.CardCode = DPDs.CardCode
                'uICDs.CardName = oDPS("PatientName")
                Dim dDate As String = oDPS("DocDate")
                Dim newDdate As String = dDate.Substring(0, 10)
                uICDs.DocDate = newDdate
                'uICDs.CounterReference = oDPS("CRNumber")
                uICDs.U_APPVistNumber = oDPS("VisitNumber")
                uICDs.U_APPReference = oDPS("InvoiceNo")
                uICDs.Remarks = oDPS("Comments")

                Dim PaymentMeans = oDPS("Payment")
                For Each PaymentMode In PaymentMeans
                    Dim checkPM = PaymentMode("PaymentMode")
                    If (PaymentMode("PaymentMode") = "Cash") Then
                        uICDs.CashSum = PaymentMode("PaidAmount")
                        uICDs.CashSumSys = PaymentMode("PaidAmount")

                        uICDs.PaymentInvoices.Add(New IncomingPaymentInvoices() With {.DocEntry = DocEntry,
                                                                                      .SumApplied = PaymentMode("PaidAmount"),
                                                                                      .AppliedSys = PaymentMode("PaidAmount"),
                                                                                      .InvoiceType = "it_DownPayment"})

                    ElseIf (PaymentMode("PaymentMode") = "Card") Then
                        uICDs.PaymentInvoices.Add(New IncomingPaymentInvoices() With {.DocEntry = DocEntry,
                                                                                      .SumApplied = PaymentMode("PaidAmount"),
                                                                                      .AppliedSys = PaymentMode("PaidAmount"),
                                                                                      .InvoiceType = "it_DownPayment",
                                                                                      .InstallmentId = 1})

                        Dim CredCard = PaymentMode("CardDetails")
                        Dim CredURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/CreditCards?$select=CreditCardCode,GLAccount&$filter=CreditCardName eq '" & CredCard.Item("CardName").ToString() & "'")
                        Dim CredRes = SLGETRequest(CredURL)
                        Dim CredObject = JObject.Parse(CredRes)
                        Dim CredCode = CredObject.SelectToken("value[0].CreditCardCode")
                        Dim GLAccount = CredObject.SelectToken("value[0].GLAccount")

                        uICDs.PaymentCreditCards.Add(New PaymentCreditCards() With {.CreditCardNumber = CredCard.Item("CardNumber").ToString(),
                                                                                    .CreditCard = CredCode,
                                                                                    .CreditAcct = GLAccount,
                                                                                    .CardValidUntil = CredCard.Item("ValidUntill").ToString(),
                                                                                    .VoucherNum = CredCard.Item("ApprovalCode").ToString(),
                                                                                    .FirstPaymentSum = PaymentMode("PaidAmount"),
                                                                                    .CreditSum = PaymentMode("PaidAmount")})
                    ElseIf (PaymentMode("PaymentMode") = "Transfer") Then
                        uICDs.TransferAccount = PaymentMode("TransferAcct")
                        uICDs.TransferSum = PaymentMode("PaidAmount")
                        uICDs.TransferDate = PaymentMode("PaidDate")
                        uICDs.TransferReference = PaymentMode("Reference")

                        uICDs.PaymentInvoices.Add(New IncomingPaymentInvoices() With {.DocEntry = DocEntry,
                                                                                     .SumApplied = PaymentMode("PaidAmount"),
                                                                                     .AppliedSys = PaymentMode("PaidAmount"),
                                                                                     .InvoiceType = "it_DownPayment",
                                                                                     .InstallmentId = 1})

                    End If
                Next

                Dim IncomePStr = JsonConvert.SerializeObject(uICDs)
                Dim POSTIPURI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/IncomingPayments")
                Dim resultPI = SLPOSTRequest(POSTIPURI, IncomePStr)

                oWriteText(impLog, oDPS("PatientName").ToString & " - " & oDPS("InvoiceNo").ToString & " is successfully Added", Color.Green)
                pgPDeposit.Value = pgPDeposit.Maximum
            End If
        Next

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Import_IncomingPay()
        If PRchck.Checked Then
            Import_PurchaseRequest()
        End If
    End Sub

    Private Sub Import_PurchaseRequest()
        'Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\PurchaseRequest\PurchaseRequest.json")
        'Dim data = JArray.Parse(jsonstring)
        'Dim prMax As Integer = data.Count
        'Dim vPR As Integer = 0
        'Dim LogID = ""
        'Dim LogVendor = ""
        'ProgressBar4.Maximum = prMax
        ''Dim isAdd As Boolean = False

        'For Each oPurRq As JObject In data
        '    Dim prURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/PurchaseRequests?$select=U_APPReference&$filter=U_APPReference eq '" & oPurRq("ID").ToString & "' and U_Cancelled eq " & oPurRq("Canceled").ToString)
        '    Dim prRes = SLGETRequest(prURL)
        '    Dim prJObject = JObject.Parse(prRes)
        '    Dim prGet = prJObject.SelectToken("value").Count

        '    Dim uPurs As New PurchaseRequest
        '    uPurs.U_APPReference = oPurRq("ID")
        '    uPurs.U_CANCELED = oPurRq("Canceled")
        '    LogID = oPurRq("ID")

        '    Dim dDate As String = oPurRq("DocDate")
        '    Dim newDdate As String = dDate.Substring(0, 10)
        '    uPurs.DocDate = newDdate

        '    Dim RDate As String = oPurRq("PRApprovedDate")
        '    Dim newRdate As String = RDate.Substring(0, 10)
        '    uPurs.RequriedDate = newRdate

        '    uPurs.Comments = oPurRq("Comments")
        '    uPurs.RequesterEmail = oPurRq("RequestUser")

        '    Dim DetailsPR = oPurRq("Details")
        '    For Each ID In DetailsPR
        '        uPurs.WhsCode = ID("Section")
        '        uPurs.CardCode = ID("VendorCode")
        '        'uPurs.CardName = ID("VendorName")
        '        LogVendor = ID("VendorCode")
        '        Dim UoMURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/UnitOfMeasurements?$select=AbsEntry&$filter=Name eq '" & ID("UomCode").ToString & "' or Code eq '" & ID("UomCode").ToString & "'")
        '        Dim UoMRes = SLGETRequest(UoMURL)
        '        Dim UoMJObject = JObject.Parse(UoMRes)
        '        Dim UoMGet = UoMJObject.SelectToken("value[0].AbsEntry")

        '        Dim WhSURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/Warehouses?$select=WarehouseCode&$filter=WarehouseName eq '" & ID("Section").ToString & "'")
        '        Dim WhSARes = SLGETRequest(WhSURL)
        '        Dim WhSJObject = JObject.Parse(WhSARes)
        '        Dim WhseGet = WhSJObject.SelectToken("value[0].WarehouseCode")

        '        uPurs.DocumentLines.Add(New PR_DocLine() With {
        '                                .LineNum = ID("LineNo"),
        '                                .ItemCode = ID("ItemCode"),
        '                                .MeasureUnit = ID("UomCode"),
        '                                .UomEntry = UoMGet,
        '                                .Quantity = ID("Quantity"),
        '                                .PriceAfterVAT = ID("Amount"),
        '                                .WarehouseCode = WhseGet,
        '                                .RequriedDate = newRdate,
        '                                .LineVendor = ID("VendorCode"),
        '                                .Price = ID("Amount")
        '        })
        '    Next
        '    Dim PurchReqStr = JsonConvert.SerializeObject(uPurs)
        '    If prGet = 0 Then
        '        Dim URI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/PurchaseRequests")
        '        Dim result = SLPOSTRequest(URI, PurchReqStr)
        '        oWriteText(impLog, LogID & " - " & LogVendor & " is successfully Added in Purchase Order", Color.Green)
        '    End If

        'Next
    End Sub
    Private Sub Import_PB()
        'Try

        Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\Billing\PatientBilling.json")
            Dim data = JArray.Parse(jsonstring)
            Dim prMax As Integer = data.Count
            Dim vPR As Integer = 0
            ProgressBar5.Maximum = prMax
            'Dim isAdd As Boolean = False

            For Each oDPs As JObject In data
                Dim DpSURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/Invoices?$select=U_APPReference&$filter=U_APPReference eq '" & oDPs("InvoiceNo").ToString & "'")
                Dim DpSRes = SLGETRequest(DpSURL)
                Dim DsPJObject = JObject.Parse(DpSRes)
                Dim DsPGet = DsPJObject.SelectToken("value").Count
                If DsPGet = 0 Then
                    Dim uPBills As New PatientBill
                    Dim PFBills As New ProffesionalFees
                    Dim HMOBills As New hmos

                    uPBills.U_CANCELED = oDPs("Canceled")
                    uPBills.CardCode = IIf(oDPs("PatientType") = "IPD", "C99998", "C99999")
                    uPBills.CardName = oDPs("PatientName")
                    uPBills.NumAtCard = oDPs("PatientName")
                    uPBills.DocDate = oDPs("DocDate")
                    uPBills.U_APPPatient = oDPs("PIN")
                    uPBills.U_APPAdmitDateFrom = oDPs("AdmissionDate")
                    uPBills.U_APPAdmitDateTo = oDPs("DischargeDate")
                    uPBills.U_APPLocation = oDPs("Location")
                    uPBills.U_APPCrNumber = oDPs("CRNumber")
                    uPBills.U_APPPhicMember = oDPs("PHICName")
                    uPBills.U_APPPhicNumber = oDPs("PHICNumber")
                    uPBills.U_APPDiagnosis = oDPs("Diagnosis")
                    uPBills.U_APPVistNumber = oDPs("VisitNumber")
                    uPBills.U_APPInvNumber = oDPs("InvoiceNo")
                    uPBills.U_APPRefundNumber = oDPs("RefundNo")
                    uPBills.U_APPPatientType = IIf(oDPs("PatientType") = "IPD", "Out-Patient", "In-Patient")
                    uPBills.U_APPORNumber = oDPs("ORNumber")
                    uPBills.U_APPSeniorId = oDPs("SeniorID")
                    uPBills.U_APPPwdId = oDPs("PwdID")
                    'uPBills.Comments = oDPs("Comments")
                    uPBills.Comments = "Main Invoice"

                    PFBills.U_CANCELED = oDPs("Canceled")
                    PFBills.CardCode = oDPs("CustomerCode")
                    PFBills.CardName = oDPs("PatientName")
                    PFBills.NumAtCard = oDPs("PatientName")
                    PFBills.DocDate = oDPs("DocDate")
                    PFBills.U_APPPatient = oDPs("PIN")
                    PFBills.U_APPAdmitDateFrom = oDPs("AdmissionDate")
                    PFBills.U_APPAdmitDateTo = oDPs("DischargeDate")
                    PFBills.U_APPLocation = oDPs("Location")
                    PFBills.U_APPCrNumber = oDPs("CRNumber")
                    PFBills.U_APPPhicMember = oDPs("PHICName")
                    PFBills.U_APPPhicNumber = oDPs("PHICNumber")
                    PFBills.U_APPDiagnosis = oDPs("Diagnosis")
                    PFBills.U_APPVistNumber = oDPs("VisitNumber")
                    PFBills.U_APPInvNumber = oDPs("InvoiceNo")
                    PFBills.U_APPRefundNumber = oDPs("RefundNo")
                PFBills.U_APPPatientType = IIf(oDPs("PatientType") = "IPD", "In-Patient", "Out-Patient")
                PFBills.U_APPORNumber = oDPs("ORNumber")
                    PFBills.U_APPSeniorId = oDPs("SeniorID")
                    PFBills.U_APPPwdId = oDPs("PwdID")


                    HMOBills.U_CANCELED = oDPs("Canceled")
                    HMOBills.NumAtCard = oDPs("PatientName")
                    HMOBills.DocDate = oDPs("DocDate")
                    HMOBills.U_APPPatient = oDPs("PIN")
                    HMOBills.U_APPAdmitDateFrom = oDPs("AdmissionDate")
                    HMOBills.U_APPAdmitDateTo = oDPs("DischargeDate")
                    HMOBills.U_APPLocation = oDPs("Location")
                    HMOBills.U_APPCrNumber = oDPs("CRNumber")
                    HMOBills.U_APPPhicMember = oDPs("PHICName")
                    HMOBills.U_APPPhicNumber = oDPs("PHICNumber")
                    HMOBills.U_APPDiagnosis = oDPs("Diagnosis")
                    HMOBills.U_APPVistNumber = oDPs("VisitNumber")
                    HMOBills.U_APPInvNumber = oDPs("InvoiceNo")
                    HMOBills.U_APPRefundNumber = oDPs("RefundNo")
                    HMOBills.U_APPPatientType = IIf(oDPs("PatientType") = "IPD", "Out-Patient", "In-Patient")
                    HMOBills.U_APPORNumber = oDPs("ORNumber")
                    HMOBills.U_APPSeniorId = oDPs("SeniorID")
                    HMOBills.U_APPPwdId = oDPs("PwdID")
                    'HMOBills.Comments = oDPs("Comments")


                    Dim fileDetails = oDPs("Details")
                    For Each LineNo In fileDetails


                        Dim ITMURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/Items?$select=ItemsGroupCode&$filter=ItemCode eq '" & LineNo("ItemCode").ToString & "'")
                        Dim ITMRes = SLGETRequest(ITMURL)
                        Dim ITMJObject = JObject.Parse(ITMRes)
                        Dim ITMGet = ITMJObject.SelectToken("value[0].ItemsGroupCode")
                        ''//(137 - Doctor's Fee)

                        'get distribution role here
                        Dim disturl As New Uri("https://" & Split(GetInfo("servername", 0), "|")(0) & ":50000/b1s/v1/DistributionRules?$select=FactorCode&$filter=FactorDescription eq '" & LineNo("Section").ToString & "'")
                        Dim distres = SLGETRequest(disturl)
                        Dim distjobject = JObject.Parse(distres)
                        Dim distget = distjobject.SelectToken("value[0].FactorCode")

                        Dim dist1url As New Uri("https://" & Split(GetInfo("servername", 0), "|")(0) & ":50000/b1s/v1/ProfitCenters?$select=CostCenterType,U_App_GroupInstitute&$filter=CenterCode eq '" & distget.ToString & "'")
                        Dim dist1res = SLGETRequest(dist1url)
                        Dim dist1jobject = JObject.Parse(dist1res)
                        Dim costcencoget = dist1jobject.SelectToken("value[0].CostCenterType")
                        Dim groupget = dist1jobject.SelectToken("value[0].U_App_GroupInstitute")

                    If LineNo("GuarantorCode") = "" And ITMGet = "137" Then

                        Dim doctors = LineNo("Items")
                        For Each Item In doctors
                            PFBills.DocumentLines.Add(New DocLine1() With {.ItemCode = LineNo("ItemCode"),
                                                                              .U_APPReference = LineNo("ID"),
                                                                              .Quantity = LineNo("Quantity"),
                                                                              .MeasureUnit = LineNo("MeasureUnit"),
                                                                              .Price = Item("TotalAmount"),
                                                                               .COGSCostingCode = groupget,
                                                                              .CostingCode = groupget,
                                                                              .COGSCostingCode2 = distget,
                                                                              .COGSCostingCode3 = costcencoget,
                                                                              .COGSCostingCode4 = Item("DocCode")})
                        Next
                    Else

                        Dim disPercent = Val(LineNo("DiscountAmount")) / Val(LineNo("Amount"))
                        disPercent = Val(disPercent) * 100

                        Dim totalDiscount = Format(disPercent, "0.00")

                        uPBills.DocumentLines.Add(New Invoice_DocLine() With {.ItemCode = LineNo("ItemCode"),
                                                                                  .U_APPReference = LineNo("ID"),
                                                                                  .Quantity = LineNo("Quantity"),
                                                                                  .MeasureUnit = LineNo("UomCode"),
                                                                                  .Price = LineNo("Amount"),
                                                                                  .DiscountPercent = Val(totalDiscount),
                                                                                  .U_APPCCDiscount = LineNo("DiscountAmount"),
                                                                                  .COGSCostingCode = groupget,
                                                                                  .CostingCode = groupget,
                                                                                  .COGSCostingCode2 = distget,
                                                                                  .COGSCostingCode3 = costcencoget,
                                                                                  .COGSCostingCode4 = LineNo("GuarantorCode")})
                    End If

                    Next

                'payor here('Get All item for selected payor the post to b1 on loop)
                Dim PayorDetails = oDPs("Payor")
                    For Each Item In PayorDetails
                        HMOBills.CardCode = Item("PayorCode")
                        HMOBills.DocumentLines.Clear()
                        Dim oDetails = oDPs("Details")
                        For Each s In oDetails
                            Dim DistPURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/DistributionRules?$select=FactorCode&$filter=FactorDescription eq '" & s("Section").ToString & "'")
                            Dim DistPRes = SLGETRequest(DistPURL)
                            Dim DistPJObject = JObject.Parse(DistPRes)
                            Dim DistPGet = DistPJObject.SelectToken("value[0].FactorCode")

                            Dim Dist1PURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/ProfitCenters?$select=CostCenterType,U_App_GroupInstitute&$filter=CenterCode eq '" & DistPGet.ToString & "'")
                            Dim Dist1PRes = SLGETRequest(Dist1PURL)
                            Dim Dist1PJObject = JObject.Parse(Dist1PRes)
                            Dim CostCenCoPGet = Dist1PJObject.SelectToken("value[0].CostCenterType")
                            Dim GroupPGet = Dist1PJObject.SelectToken("value[0].U_App_GroupInstitute")

                        If s("GuarantorCode").ToString = Item("PayorCode").ToString Then
                            HMOBills.DocumentLines.Add(New DocLine2() With {.ItemCode = s("ItemCode"),
                                                                                  .U_APPReference = s("ID"),
                                                                                  .Quantity = s("Quantity"),
                                                                                  .MeasureUnit = s("UomCode"),
                                                                                  .Price = s("Amount"),
                                                                                  .COGSCostingCode = GroupPGet,
                                                                                  .CostingCode = GroupPGet,
                                                                                  .COGSCostingCode2 = DistPGet,
                                                                                  .COGSCostingCode3 = CostCenCoPGet})
                        End If
                    Next

                        Dim HMOBstr = JsonConvert.SerializeObject(HMOBills)
                        '//POST to SAP here the Payor
                        Dim POSTPAYORBURI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/Invoices")
                        Dim resultPAYOR = SLPOSTRequest(POSTPAYORBURI, HMOBstr)

                    Next

                    '//Post Professional Fees Here
                    Dim PFstr = JsonConvert.SerializeObject(PFBills)

                    Dim POSTPFBURI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/Invoices")
                    Dim resultPF = SLPOSTRequest(POSTPFBURI, PFstr)


                'get deposit if have
                Dim DPURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/DownPayments?$select=DocEntry,DocNum&$filter=U_APPVistNumber eq '" & oDPs("VisitNumber").ToString & "'")
                Dim DPRes = SLGETRequest(DPURL)
                Dim DwnPayment = JObject.Parse(DPRes)

                'For Each doc As JObject In DPRes
                '    Dim docEntrys = doc("DocEntry")
                '    Dim DocNum = doc("DocNumber")
                'Next

                For pd As Integer = 0 To DwnPayment.SelectToken("value").Count - 1
                    uPBills.DownPaymentsToDraw.Add(New PB_DownPaymentsToDraw() With {.DocEntry = DwnPayment.SelectToken("value[" & pd & "].DocEntry"),
                                                                                      .DocNumber = DwnPayment.SelectToken("value[" & pd & "].DocNum")})

                Next
                Dim PBstr = JsonConvert.SerializeObject(uPBills)


                    Dim POSTPBURI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/Invoices")
                    Dim resultPI = SLPOSTRequest(POSTPBURI, PBstr)
                    '''//get docEntry Here
                    Dim getDocEntry = JObject.Parse(resultPI)
                    Dim DocEntry = getDocEntry.SelectToken("DocEntry")

                    '''///InsertPayment Here
                    Dim uICDs As New IncomingPayDep
                    uICDs.CardCode = IIf(oDPs("PatientType") = "IPD", "C99998", "C99999")
                    uICDs.CardName = oDPs("PatientName")
                    Dim dDate As String = oDPs("DocDate")
                    Dim newDdate As String = dDate.Substring(0, 10)
                    uICDs.DocDate = newDdate
                    uICDs.U_APPVistNumber = oDPs("VisitNumber")
                    uICDs.Remarks = oDPs("Comments")

                    Dim PaymentMeans = oDPs("Payment")
                    For Each PaymentMode In PaymentMeans
                        Dim checkPM = PaymentMode("PaymentMode")
                        If (PaymentMode("PaymentMode") = "CASH") Then
                            uICDs.U_APPORNumber = PaymentMode("ORNumber")
                            uICDs.U_APPReference = PaymentMode("InvoiceNumber")

                            uICDs.CashSum = PaymentMode("PaidAmount")
                            uICDs.CashSumSys = PaymentMode("PaidAmount")

                            uICDs.PaymentInvoices.Add(New IncomingPaymentInvoices() With {.DocEntry = DocEntry,
                                                                                      .SumApplied = PaymentMode("PaidAmount"),
                                                                                      .AppliedSys = PaymentMode("PaidAmount")})


                        ElseIf (PaymentMode("PaymentMode") = "CARD") Then
                            uICDs.PaymentInvoices.Add(New IncomingPaymentInvoices() With {.DocEntry = DocEntry,
                                                                                      .SumApplied = PaymentMode("PaidAmount"),
                                                                                      .AppliedSys = PaymentMode("PaidAmount"),
                                                                                      .InvoiceType = "it_Invoice",
                                                                                      .InstallmentId = 1})

                            Dim CredCard = PaymentMode("CardDetails")
                            For Each card As JObject In CredCard
                                Dim CredURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/CreditCards?$select=CreditCardCode,GLAccount&$filter=CreditCardName eq '" & card("CardName").ToString() & "'")
                                Dim CredRes = SLGETRequest(CredURL)
                                Dim CredObject = JObject.Parse(CredRes)
                                Dim CredCode = CredObject.SelectToken("value[0].CreditCardCode")
                                Dim GLAccount = CredObject.SelectToken("value[0].GLAccount")

                                'credit card validity date
                                Dim validDate = card("ValidUntill").ToString()

                                Dim words As String() = validDate.Split(New Char() {"/"c})
                                Dim yy As String = Date.Today.Year
                                Dim yearStart = yy.Substring(0, 2)

                                Dim vYear = words(1)
                                Dim vMonth = words(0)
                                Dim validityYear = yearStart + vYear

                                Dim lastDayOfMonth = System.DateTime.DaysInMonth(validityYear, vMonth)
                                ''convert to year/month/day
                                Dim CardValidity = validityYear & "-" & vMonth & "-" & lastDayOfMonth
                                uICDs.PaymentCreditCards.Add(New PaymentCreditCards() With {.CreditCardNumber = card("CardNumber").ToString(),
                                                                                        .CreditCard = CredCode,
                                                                                        .CreditAcct = GLAccount,
                                                                                        .CardValidUntil = CardValidity,
                                                                                        .VoucherNum = card("ApprovalCode").ToString(),
                                                                                        .FirstPaymentSum = PaymentMode("PaidAmount"),
                                                                                        .CreditSum = PaymentMode("PaidAmount")})
                            Next
                        End If
                    Next


                    Dim IncomePStr = JsonConvert.SerializeObject(uICDs)
                    Dim POSTIPURI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/IncomingPayments")
                    Dim strPosting = SLPOSTRequest(POSTIPURI, IncomePStr)
                    oWriteText(impLog, oDPs("PatientName").ToString & " - " & oDPs("PIN").ToString & " is successfully Added", Color.Green)
                End If
            Next
        'Catch ex As Exception
        '    oWriteText(impLog, ex.Message, Color.Red)
        'End Try

    End Sub

    Dim IT_ItemCode, IT_Batch, IT_Expiry, IT_WhseCode As String
    Private Sub Import_IT()
        Try
            Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\InventoryTransfers\InventoryTransfer.json")
            Dim data = JArray.Parse(jsonstring)
            Dim ITMax As Integer = data.Count
            pbIT.Maximum = ITMax

            Dim oIT As InventoryTransfer_Header


            For Each oDr As JObject In data
                Dim ITUrl As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/StockTransfers?$select=U_APPReference&$filter=U_APPReference eq '" & oDr("ID").ToString & "'")
                Dim ITRes = SLGETRequest(ITUrl)
                Dim ITJobject = JObject.Parse(ITRes)
                Dim ITGet = ITJobject.SelectToken("value").Count

                oIT = New InventoryTransfer_Header
                With oIT
                    .U_APPReference = oDr("ID")
                    .DocDate = oDr("DocDate")
                    .FromWarehouse = oDr("FromWarehouse")
                    .ToWarehouse = oDr("ToWarehouse")
                    .Comments = oDr("Comments")

                    Dim Details = oDr("Details")
                    Dim l As Integer = 0
                    For Each oLines In Details
                        oIT.StockTransferLines.Add(New InventoryTransfer_Details() With {
                             .ItemCode = oLines("ItemCode"),
                             .Quantity = oLines("Quantity")
                    })

                        'put the batch here
                        Dim TQ As Integer = oLines("Quantity")
                        IT_ItemCode = oLines("ItemCode")
                        IT_Batch = oLines("BatchNo")
                        IT_WhseCode = oDr("FromWarehouse")

                        Dim iDate As String = oLines("BatchExpiry")
                        Dim oDate As DateTime = Convert.ToDateTime(iDate)
                        IT_Expiry = Format(oDate, "yyyy.MM.dd")


                        Dim btchURL As New Uri("https://" & Split(GetInfo("HanaServer", 0), "|")(4) & ":4300/app_xsjs/getBatch.xsjs?ItemCode=" & IT_ItemCode & "&BatchNum=" & IT_Batch & "&ExpDate=" & IT_Expiry & "&WhsCode=" & IT_WhseCode)
                        Dim btchResult = XSJSGETRequest(btchURL)
                        Dim btchJObject = JObject.Parse(btchResult)
                        Dim countBtc As Integer = btchJObject.Count

                        For i As Integer = 0 To countBtc - 1
                            Dim BQ As Integer = Val(btchJObject.SelectToken((i & ".Quantity")))
                            Do Until Val(TQ) = 0 Or Val(BQ) = 0
                                'Allocate Batch/Distribute batch 
                                If Val(TQ) >= Val(BQ) And Val(BQ) <> 0 And Val(TQ) <> 0 Then
                                    TQ = Val(TQ) - Val(BQ)
                                    oIT.StockTransferLines(l).BatchNumbers.Add(New InventoryTransfer_BatchDetails() With {
                                .BatchNumber = btchJObject.SelectToken((i & ".BatchNum")),
                                .Quantity = btchJObject.SelectToken((i & ".Quantity"))})
                                    BQ = 0
                                ElseIf Val(BQ) >= Val(TQ) And Val(BQ) <> 0 And Val(TQ) <> 0 Then
                                    BQ = Val(BQ) - Val(TQ)
                                    oIT.StockTransferLines(l).BatchNumbers.Add(New InventoryTransfer_BatchDetails() With {
                               .BatchNumber = btchJObject.SelectToken((i & ".BatchNum")),
                               .Quantity = TQ})
                                    TQ = 0
                                End If

                            Loop
                        Next
                        l = l + 1
                    Next
                End With

                Dim oITStr = JsonConvert.SerializeObject(oIT)
                If ITGet = 0 Then
                    Dim URI As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/StockTransfers")
                    Dim result = SLPOSTRequest(URI, oITStr)
                    oWriteText(impLog, oDr("ID").ToString & " - " & oDr("ToWarehouse").ToString & " is successfully Transferred", Color.Green)
                End If

NextTransaction:
            Next
        Catch ex As Exception
            oWriteText(impLog, ex.Message, Color.Red)
        End Try
    End Sub

    Private Sub Inventory_Transaction()
        'Try
        Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\InventoryTransaction\InventoryTransaction.json")
        Dim data = JArray.Parse(jsonstring)
        Dim invMax As Integer = data.Count
        For Each oPurRq As JObject In data
            Dim checkDocTyoe = oPurRq("DocumentType")

            Dim OIGN As New Dispense
            OIGN.U_APPReference = oPurRq("ID")
            OIGN.U_CANCELED = oPurRq("Canceled")
            OIGN.DocDate = oPurRq("DocDate")
            OIGN.Comments = oPurRq("Comments")
            OIGN.U_APPSeniorId = oPurRq("SeniorID")
            OIGN.U_APPPwdId = oPurRq("PwdID")

            Dim lineItem = oPurRq("Details")
            For Each items In lineItem

                Dim DistPURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/DistributionRules?$select=FactorCode&$filter=FactorDescription eq '" & items("Section").ToString & "'")
                Dim DistPRes = SLGETRequest(DistPURL)
                Dim DistPJObject = JObject.Parse(DistPRes)
                Dim DistPGet = DistPJObject.SelectToken("value[0].FactorCode")

                Dim Dist1PURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/ProfitCenters?$select=CostCenterType,U_App_GroupInstitute&$filter=CenterCode eq '" & DistPGet.ToString & "'")
                Dim Dist1PRes = SLGETRequest(Dist1PURL)
                Dim Dist1PJObject = JObject.Parse(Dist1PRes)
                Dim CostCenCoPGet = Dist1PJObject.SelectToken("value[0].CostCenterType")
                Dim GroupPGet = Dist1PJObject.SelectToken("value[0].U_App_GroupInstitute")

                Dim UntPrc = (Val(items("Amount")) / Val(items("Quantity")))
                OIGN.DocumentLines.Add(New Dispense_Line() With {
                                      .U_APPReference = items("ID"),
                                      .ItemCode = items("ItemCode"),
                                      .Quantity = items("Quantity"),
                                      .UnitPrice = UntPrc,
                                      .U_APP_BatchExpiry = items("BatchExpiry"),
                                      .U_APP_BatchNo = items("BatchNo"),
                                      .COGSCostingCode = GroupPGet,
                                      .CostingCode = GroupPGet,
                                      .COGSCostingCode2 = DistPGet,
                                      .CostingCode2 = DistPGet,
                                      .COGSCostingCode3 = CostCenCoPGet,
                                      .CostingCode3 = CostCenCoPGet
                    })
            Next

            Dim disStr = JsonConvert.SerializeObject(OIGN)

            If oPurRq("DocumentType") = "Dispensed" Then
                'Goods Issue
                Dim PostingURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/InventoryGenExits")
                Dim strPosting = SLPOSTRequest(PostingURL, disStr)
                oWriteText(impLog, "Dispense Complete", Color.Green)

            ElseIf oPurRq("DocumentType") = "Returns" Then
                'goods Receipt PO
                Dim PostingURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/InventoryGenEntries")
                Dim strPosting = SLPOSTRequest(PostingURL, disStr)
                oWriteText(impLog, "Dispense Complete", Color.Green)
            ElseIf oPurRq("DocumentType") = "Emergency" Or oPurRq("DocumentType") = "Consigment" Then
                'goods Receipt Without PO


            ElseIf oPurRq("DocumentType") = "Stock Adjustments" Then
                'Inventory Trransfer

            End If

        Next
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Import_CompanyPayment()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        import_readerFee()
    End Sub

    Private Sub import_readerFee()
        'Try

        Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\Billing\ReadersFee.json")
            Dim data = JArray.Parse(jsonstring)
            Dim ITMax As Integer = data.Count
            pbRDrs.Maximum = ITMax
            Dim oRF = New readersFee

        For Each fees As JObject In data
            'check if visitnumber exist
            Dim vRFUrl As New Uri("https://" & Split(GetInfo("HanaServer", 0), "|")(4) & ":4300/app_xsjs/CheckReadersFee.xsjs?vNum=" & fees("VisitNumber").ToString)
            Dim vRFRes = XSJSGETRequest(vRFUrl)
            Dim vRFobject = JObject.Parse(vRFRes).Count

            If Val(vRFobject) = 0 Then
                'xsjs post method using paremeter ReadersFee.xsjs'
                Dim rfCode = IIf(fees("PatientType") = "IPD", "C99998", "C99999")
                Dim rfPtype = IIf(fees("PatientType") = "IPD", "In-Patient", "Out-Patient")

                Dim URLStr = ("https://" & Split(GetInfo("HanaServer", 0), "|")(4) & ":4300/app_xsjs/ReadersFee.xsjs?Name=" & fees("PatientName").ToString & "&Code=" & rfCode & "&VisitNum=" & fees("VisitNumber").ToString & "&pName=" & fees("PatientName").ToString & "&DocCode=" & fees("DoctorCode").ToString & "&Amount=" & fees("ReadersFee").ToString & "&pType=" & rfPtype & "&PIN=" & fees("PatientMRN").ToString)
                Dim oRFUrl As New Uri(URLStr)
                Dim oRFRes = SXPOSTRequest(oRFUrl)
                oWriteText(impLog, "successfully Inserted", Color.Green)
            End If
        Next
        'Catch ex As Exception
        '    oWriteText(impLog, ex.Message.ToString(), Color.Red)
        'End Try
    End Sub


    Sub import_OvertheCounter()

    End Sub



    Private Sub Import_CompanyPayment()
        'try
        Dim jsonstring As String = File.ReadAllText(Application.StartupPath + "\Inbound\IncomingPayment\IncomingPaymentCompany.json")
        Dim data = JArray.Parse(jsonstring)
        Dim ITMax As Integer = data.Count
        pbIP.Maximum = ITMax

        Dim oIP As CompanyPatment_Header

        For Each oDr As JObject In data
            Dim IPUrl As New Uri("https: //" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/IncomingPayments?$select=U_APPReference&$filter=U_APPReference eq '" & oDr("ID").ToString & "'")
            Dim IPRes = SLGETRequest(IPUrl)
            Dim IPJobject = JObject.Parse(IPRes)
            Dim IPGet = IPJobject.SelectToken("value").Count

            oIP = New CompanyPatment_Header

            Dim docDate As String = oDr("DocDate")
            Dim newDocdate As String = docDate.Substring(0, 10)

            With oIP
                .U_APPReference = oDr("ID")
                .CardCode = oDr("CustomerCode")
                .CardName = oDr("CompanyName")
                .U_APPORNumber = oDr("ORNumber")
                .DocDate = newDocdate
                .U_APPVistNumber = oDr("VisitNumber")
                .Remarks = oDr("Comments")
                .CashSum = oDr("TotalCash")
                .CashSumSys = oDr("TotalCash")
            End With

            Dim CredCard = oDr("PaymentCard")
            For Each iLine In CredCard

                Dim CredURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/CreditCards?$select=CreditCardCode,GLAccount&$filter=CreditCardName eq '" & iLine("CreditCardName").ToString & "'")
                Dim CredRes = SLGETRequest(CredURL)
                Dim CredObject = JObject.Parse(CredRes)
                Dim CredCode = CredObject.SelectToken("value[0].CreditCardCode")
                Dim GLAccount = CredObject.SelectToken("value[0].GLAccount")


                oIP.PaymentCreditCards.Add(New CompanyPayment_CreditCards() With {
                           .CreditCard = CredCode,
                           .CreditCardNumber = iLine("CreditCardNo"),
                           .CreditAcct = GLAccount,
                           .CardValidUntil = iLine("ValidUntil"),
                           .CreditSum = iLine("CreditSum"),
                           .VoucherNum = iLine("Approval")
                  })
            Next

            Dim checkDetails = oDr("PaymentCheck")

            For Each cLine In checkDetails
                Dim dDate As String = cLine("CheckDate")
                Dim newdDate As String = dDate.Substring(0, 10)

                oIP.PaymentChecks.Add(New CompanyPayment_Check() With {
                           .DueDate = newdDate,
                           .BankCode = cLine("BankCode"),
                           .CheckSum = cLine("CheckSum"),
                           .CheckNumber = cLine("CheckNum")
                  })
            Next

            Dim IPStr = JsonConvert.SerializeObject(oIP)

            Dim PostingURL As New Uri("https://" & Split(GetInfo("ServerName", 0), "|")(0) & ":50000/b1s/v1/IncomingPayments")
            Dim strPosting = SLPOSTRequest(PostingURL, IPStr)
            oWriteText(impLog, oDr("ID").ToString & " successfully added", Color.Green)
        Next

        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Inventory_Transaction()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        oConnect()
        Dim oReconnect As SAPbobsCOM.Recordset = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        oReconnect.DoQuery("SELECT T1.[UomEntry], T1.[UomCode], T1.[UomName], T1.[Length1], T1.[Width1], T1.[Height1], T0.[CodeBars], T0.[ItemCode] FROM OITM T0  INNER JOIN OUOM T1 ON T0.[PUoMEntry] = T1.[UomEntry]")
        Dim count = oReconnect.RecordCount

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Import_PB()
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Import_IT()
    End Sub

End Class
