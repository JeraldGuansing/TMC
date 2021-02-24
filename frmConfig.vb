Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.Net
Imports System.IO
Public Class frmConfig


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
#Region "SDK"
            'Dim oCompany As SAPbobsCOM.Company = New SAPbobsCOM.Company
            'With oCompany
            '    .DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB
            '    .Server = txthanaserver.Text
            '    .CompanyDB = txtdbname.Text
            '    .DbUserName = txthanauser.Text
            '    .DbPassword = txthanapassword.Text
            '    .language = SAPbobsCOM.BoSuppLangs.ln_English
            '    '.LicenseServer = txtlicserver.Text
            '    .UserName = txtsapuser.Text
            '    .Password = txtsappw.Text
            '    .APIserver = txtAPI.Text
            '    .APIuserName = APIUserN.Text
            '    .APIPassword = APIPassW.Text


            '    If Not .Connect = 0 Then
            '        oWriteText(lstvw, oCompany.GetLastErrorDescription, Color.Red, False)
            '        oWriteText(lstvw, "....................")
            '        Return
            '    End If
            'End With
#End Region
            Dim oLogin As New LoginClass

            oLogin.CompanyDB = txtdbname.Text
            oLogin.UserName = txtsapuser.Text
            oLogin.Password = txtsappw.Text

            Dim LoginStr = JsonConvert.SerializeObject(oLogin)
            Dim URI As New Uri("https://" & txtserver.Text & ":50000/b1s/v1/Login")
            Dim result = SLLogin(URI, LoginStr)
            oWriteText(lstvw, result, Color.Green)

            ManualINI(txtserver.Text, txtdbname.Text, txtsapuser.Text, AppTech.Encrypt(txtsappw.Text), txthanaserver.Text, txthanauser.Text, AppTech.Encrypt(txthanapassword.Text), txtAPI.Text, APIUserN.Text, APIPassW.Text)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstvw.Items.Clear()
        lstvw.Columns.Clear()
        lstvw.Columns.Add("Log", 300, HorizontalAlignment.Left)

        Try
            txtserver.Text = Split(GetInfo("ServerName", 0), "|")(0)
            txtdbname.Text = Split(GetInfo("Database", 0), "|")(1)
            txtsapuser.Text = Split(GetInfo("SAPUser", 0), "|")(2)
            txtsappw.Text = AppTech.Decrypt(Split(GetInfo("SAPPassword", 0), "|")(3))
            txthanaserver.Text = Split(GetInfo("HanaServer", 0), "|")(4)
            txthanauser.Text = Split(GetInfo("HanaUser", 0), "|")(5)
            txthanapassword.Text = AppTech.Decrypt(Split(GetInfo("HanaPassword", 0), "|")(6))
            txtAPI.Text = Split(GetInfo("APIserver", 0), "|")(7)
            APIUserN.Text = Split(GetInfo("APIuserKey", 0), "|")(8)
            APIPassW.Text = Split(GetInfo("APIpassKey", 0), "|")(9)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub header_Click(sender As Object, e As EventArgs) Handles header.Click

    End Sub
End Class