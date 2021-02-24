<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfig
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.header = New System.Windows.Forms.PictureBox()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.lstvw = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txthanapassword = New System.Windows.Forms.TextBox()
        Me.txthanauser = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txthanaserver = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAPI = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtsappw = New System.Windows.Forms.TextBox()
        Me.txtsapuser = New System.Windows.Forms.TextBox()
        Me.txtdbname = New System.Windows.Forms.TextBox()
        Me.txtserver = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.APIPassW = New System.Windows.Forms.TextBox()
        Me.APIUserN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.Dock = System.Windows.Forms.DockStyle.Top
        Me.header.Image = CType(resources.GetObject("header.Image"), System.Drawing.Image)
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(536, 37)
        Me.header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.header.TabIndex = 78
        Me.header.TabStop = False
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(509, 7)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(19, 20)
        Me.btnclose.TabIndex = 79
        Me.btnclose.Text = "x"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.Gold
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Location = New System.Drawing.Point(457, 308)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(71, 25)
        Me.btnsave.TabIndex = 84
        Me.btnsave.Text = "Save Config"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'lstvw
        '
        Me.lstvw.AllowColumnReorder = True
        Me.lstvw.FullRowSelect = True
        Me.lstvw.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstvw.HideSelection = False
        Me.lstvw.LabelEdit = True
        Me.lstvw.Location = New System.Drawing.Point(268, 42)
        Me.lstvw.Margin = New System.Windows.Forms.Padding(2)
        Me.lstvw.Name = "lstvw"
        Me.lstvw.Size = New System.Drawing.Size(260, 262)
        Me.lstvw.TabIndex = 83
        Me.lstvw.UseCompatibleStateImageBehavior = False
        Me.lstvw.View = System.Windows.Forms.View.Details
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.APIPassW)
        Me.GroupBox1.Controls.Add(Me.APIUserN)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txthanapassword)
        Me.GroupBox1.Controls.Add(Me.txthanauser)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txthanaserver)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAPI)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtsappw)
        Me.GroupBox1.Controls.Add(Me.txtsapuser)
        Me.GroupBox1.Controls.Add(Me.txtdbname)
        Me.GroupBox1.Controls.Add(Me.txtserver)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 48)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(254, 285)
        Me.GroupBox1.TabIndex = 82
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuration SAP"
        '
        'txthanapassword
        '
        Me.txthanapassword.Location = New System.Drawing.Point(122, 145)
        Me.txthanapassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txthanapassword.Name = "txthanapassword"
        Me.txthanapassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txthanapassword.Size = New System.Drawing.Size(123, 19)
        Me.txthanapassword.TabIndex = 81
        '
        'txthanauser
        '
        Me.txthanauser.Location = New System.Drawing.Point(122, 124)
        Me.txthanauser.Margin = New System.Windows.Forms.Padding(2)
        Me.txthanauser.Name = "txthanauser"
        Me.txthanauser.Size = New System.Drawing.Size(123, 19)
        Me.txthanauser.TabIndex = 80
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 145)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 12)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "HANA Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 124)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 12)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "HANA User"
        '
        'txthanaserver
        '
        Me.txthanaserver.Location = New System.Drawing.Point(122, 103)
        Me.txthanaserver.Margin = New System.Windows.Forms.Padding(2)
        Me.txthanaserver.Name = "txthanaserver"
        Me.txthanaserver.Size = New System.Drawing.Size(123, 19)
        Me.txthanaserver.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 103)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 12)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "HANA Server:"
        '
        'txtAPI
        '
        Me.txtAPI.Location = New System.Drawing.Point(122, 169)
        Me.txtAPI.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAPI.Name = "txtAPI"
        Me.txtAPI.Size = New System.Drawing.Size(123, 19)
        Me.txtAPI.TabIndex = 75
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 174)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 12)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "API KEY:"
        '
        'txtsappw
        '
        Me.txtsappw.Location = New System.Drawing.Point(122, 81)
        Me.txtsappw.Margin = New System.Windows.Forms.Padding(2)
        Me.txtsappw.Name = "txtsappw"
        Me.txtsappw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtsappw.Size = New System.Drawing.Size(123, 19)
        Me.txtsappw.TabIndex = 67
        '
        'txtsapuser
        '
        Me.txtsapuser.Location = New System.Drawing.Point(122, 60)
        Me.txtsapuser.Margin = New System.Windows.Forms.Padding(2)
        Me.txtsapuser.Name = "txtsapuser"
        Me.txtsapuser.Size = New System.Drawing.Size(123, 19)
        Me.txtsapuser.TabIndex = 66
        '
        'txtdbname
        '
        Me.txtdbname.Location = New System.Drawing.Point(122, 40)
        Me.txtdbname.Margin = New System.Windows.Forms.Padding(2)
        Me.txtdbname.Name = "txtdbname"
        Me.txtdbname.Size = New System.Drawing.Size(123, 19)
        Me.txtdbname.TabIndex = 62
        '
        'txtserver
        '
        Me.txtserver.Location = New System.Drawing.Point(122, 20)
        Me.txtserver.Margin = New System.Windows.Forms.Padding(2)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(123, 19)
        Me.txtserver.TabIndex = 61
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 81)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 12)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "SAP Password:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 60)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "SAP Username:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 40)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Database Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SL Server:"
        '
        'APIPassW
        '
        Me.APIPassW.Location = New System.Drawing.Point(122, 213)
        Me.APIPassW.Margin = New System.Windows.Forms.Padding(2)
        Me.APIPassW.Name = "APIPassW"
        Me.APIPassW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.APIPassW.Size = New System.Drawing.Size(123, 19)
        Me.APIPassW.TabIndex = 85
        '
        'APIUserN
        '
        Me.APIUserN.Location = New System.Drawing.Point(122, 192)
        Me.APIUserN.Margin = New System.Windows.Forms.Padding(2)
        Me.APIUserN.Name = "APIUserN"
        Me.APIUserN.Size = New System.Drawing.Size(123, 19)
        Me.APIUserN.TabIndex = 84
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 213)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 12)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "API Password:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 192)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 12)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "API Username:"
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 341)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.lstvw)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmConfig"
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents header As PictureBox
    Friend WithEvents btnclose As Button
    Friend WithEvents btnsave As Button
    Friend WithEvents lstvw As ListView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtAPI As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtsappw As TextBox
    Friend WithEvents txtsapuser As TextBox
    Friend WithEvents txtdbname As TextBox
    Friend WithEvents txtserver As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txthanaserver As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txthanapassword As TextBox
    Friend WithEvents txthanauser As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents APIPassW As TextBox
    Friend WithEvents APIUserN As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
End Class
