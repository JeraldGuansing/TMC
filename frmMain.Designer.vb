<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.header = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DBConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.impLog = New System.Windows.Forms.ListView()
        Me.btnItems = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chckPD = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pgPDeposit = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ProgressBar3 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PRchck = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ProgressBar4 = New System.Windows.Forms.ProgressBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ProgressBar5 = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ChbpbIT = New System.Windows.Forms.CheckBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.pbIT = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.pbIP = New System.Windows.Forms.ProgressBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.pbRDrs = New System.Windows.Forms.ProgressBar()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.Dock = System.Windows.Forms.DockStyle.Top
        Me.header.Image = CType(resources.GetObject("header.Image"), System.Drawing.Image)
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(729, 37)
        Me.header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.header.TabIndex = 87
        Me.header.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DarkGray
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(11, 5)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 19)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "TMC - SAP Integration Utility"
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(704, 9)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(19, 20)
        Me.btnclose.TabIndex = 91
        Me.btnclose.Text = "x"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 37)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(729, 24)
        Me.MenuStrip1.TabIndex = 93
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DBConfigurationToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'DBConfigurationToolStripMenuItem
        '
        Me.DBConfigurationToolStripMenuItem.Name = "DBConfigurationToolStripMenuItem"
        Me.DBConfigurationToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.DBConfigurationToolStripMenuItem.Text = "DB Configuration"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 71)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Order Item (Item Master)"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(156, 66)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(157, 19)
        Me.ProgressBar1.TabIndex = 95
        '
        'impLog
        '
        Me.impLog.FullRowSelect = True
        Me.impLog.HideSelection = False
        Me.impLog.Location = New System.Drawing.Point(402, 49)
        Me.impLog.Margin = New System.Windows.Forms.Padding(2)
        Me.impLog.Name = "impLog"
        Me.impLog.Size = New System.Drawing.Size(321, 392)
        Me.impLog.TabIndex = 97
        Me.impLog.UseCompatibleStateImageBehavior = False
        Me.impLog.View = System.Windows.Forms.View.Details
        '
        'btnItems
        '
        Me.btnItems.Location = New System.Drawing.Point(345, 68)
        Me.btnItems.Margin = New System.Windows.Forms.Padding(2)
        Me.btnItems.Name = "btnItems"
        Me.btnItems.Size = New System.Drawing.Size(50, 19)
        Me.btnItems.TabIndex = 96
        Me.btnItems.Text = "Manual"
        Me.btnItems.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(322, 68)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 98
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chckPD
        '
        Me.chckPD.AutoSize = True
        Me.chckPD.Location = New System.Drawing.Point(322, 93)
        Me.chckPD.Margin = New System.Windows.Forms.Padding(2)
        Me.chckPD.Name = "chckPD"
        Me.chckPD.Size = New System.Drawing.Size(15, 14)
        Me.chckPD.TabIndex = 110
        Me.chckPD.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(345, 93)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 19)
        Me.Button1.TabIndex = 109
        Me.Button1.Text = "Manual"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pgPDeposit
        '
        Me.pgPDeposit.Location = New System.Drawing.Point(156, 91)
        Me.pgPDeposit.Margin = New System.Windows.Forms.Padding(2)
        Me.pgPDeposit.Name = "pgPDeposit"
        Me.pgPDeposit.Size = New System.Drawing.Size(157, 19)
        Me.pgPDeposit.TabIndex = 108
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 96)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Patient Diposit"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(322, 116)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox3.TabIndex = 114
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(345, 116)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(50, 19)
        Me.Button2.TabIndex = 113
        Me.Button2.Text = "Manual"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ProgressBar3
        '
        Me.ProgressBar3.Location = New System.Drawing.Point(156, 114)
        Me.ProgressBar3.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar3.Name = "ProgressBar3"
        Me.ProgressBar3.Size = New System.Drawing.Size(157, 19)
        Me.ProgressBar3.TabIndex = 112
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 119)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "Patient Diposit(Transfer)"
        '
        'PRchck
        '
        Me.PRchck.AutoSize = True
        Me.PRchck.Location = New System.Drawing.Point(322, 139)
        Me.PRchck.Margin = New System.Windows.Forms.Padding(2)
        Me.PRchck.Name = "PRchck"
        Me.PRchck.Size = New System.Drawing.Size(15, 14)
        Me.PRchck.TabIndex = 118
        Me.PRchck.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(345, 139)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 19)
        Me.Button3.TabIndex = 117
        Me.Button3.Text = "Manual"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ProgressBar4
        '
        Me.ProgressBar4.Location = New System.Drawing.Point(156, 137)
        Me.ProgressBar4.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar4.Name = "ProgressBar4"
        Me.ProgressBar4.Size = New System.Drawing.Size(157, 19)
        Me.ProgressBar4.TabIndex = 116
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 142)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "Purchase Request"
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(322, 162)
        Me.CheckBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox5.TabIndex = 122
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(345, 162)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(50, 19)
        Me.Button4.TabIndex = 121
        Me.Button4.Text = "Manual"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ProgressBar5
        '
        Me.ProgressBar5.Location = New System.Drawing.Point(156, 160)
        Me.ProgressBar5.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar5.Name = "ProgressBar5"
        Me.ProgressBar5.Size = New System.Drawing.Size(157, 19)
        Me.ProgressBar5.TabIndex = 120
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 165)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "Patient Billing"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(345, 420)
        Me.Button5.Margin = New System.Windows.Forms.Padding(2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(50, 19)
        Me.Button5.TabIndex = 123
        Me.Button5.Text = "Test"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ChbpbIT
        '
        Me.ChbpbIT.AutoSize = True
        Me.ChbpbIT.Location = New System.Drawing.Point(322, 185)
        Me.ChbpbIT.Margin = New System.Windows.Forms.Padding(2)
        Me.ChbpbIT.Name = "ChbpbIT"
        Me.ChbpbIT.Size = New System.Drawing.Size(15, 14)
        Me.ChbpbIT.TabIndex = 127
        Me.ChbpbIT.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(345, 185)
        Me.Button6.Margin = New System.Windows.Forms.Padding(2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(50, 19)
        Me.Button6.TabIndex = 126
        Me.Button6.Text = "Manual"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'pbIT
        '
        Me.pbIT.Location = New System.Drawing.Point(156, 183)
        Me.pbIT.Margin = New System.Windows.Forms.Padding(2)
        Me.pbIT.Name = "pbIT"
        Me.pbIT.Size = New System.Drawing.Size(157, 19)
        Me.pbIT.TabIndex = 125
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 188)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Inventory Transfer"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(322, 208)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox2.TabIndex = 135
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(345, 208)
        Me.Button8.Margin = New System.Windows.Forms.Padding(2)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(50, 19)
        Me.Button8.TabIndex = 134
        Me.Button8.Text = "Manual"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(156, 206)
        Me.ProgressBar2.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(157, 19)
        Me.ProgressBar2.TabIndex = 133
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 211)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 13)
        Me.Label9.TabIndex = 132
        Me.Label9.Text = "Inventort Transaction"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(322, 231)
        Me.CheckBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox4.TabIndex = 139
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(345, 231)
        Me.Button7.Margin = New System.Windows.Forms.Padding(2)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(50, 19)
        Me.Button7.TabIndex = 138
        Me.Button7.Text = "Manual"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'pbIP
        '
        Me.pbIP.Location = New System.Drawing.Point(156, 229)
        Me.pbIP.Margin = New System.Windows.Forms.Padding(2)
        Me.pbIP.Name = "pbIP"
        Me.pbIP.Size = New System.Drawing.Size(157, 19)
        Me.pbIP.TabIndex = 137
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 234)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 136
        Me.Label8.Text = "Incoming Payment"
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(322, 254)
        Me.CheckBox6.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox6.TabIndex = 143
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(345, 254)
        Me.Button9.Margin = New System.Windows.Forms.Padding(2)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(50, 19)
        Me.Button9.TabIndex = 142
        Me.Button9.Text = "Manual"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'pbRDrs
        '
        Me.pbRDrs.Location = New System.Drawing.Point(156, 252)
        Me.pbRDrs.Margin = New System.Windows.Forms.Padding(2)
        Me.pbRDrs.Name = "pbRDrs"
        Me.pbRDrs.Size = New System.Drawing.Size(157, 19)
        Me.pbRDrs.TabIndex = 141
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 257)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 140
        Me.Label10.Text = "Reader fee"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 450)
        Me.Controls.Add(Me.CheckBox6)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.pbRDrs)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.pbIP)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ChbpbIT)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.pbIT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.CheckBox5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ProgressBar5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PRchck)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ProgressBar4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ProgressBar3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chckPD)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pgPDeposit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.impLog)
        Me.Controls.Add(Me.btnItems)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents header As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnclose As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DBConfigurationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents impLog As ListView
    Friend WithEvents btnItems As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents chckPD As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents pgPDeposit As ProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents ProgressBar3 As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents PRchck As CheckBox
    Friend WithEvents Button3 As Button
    Friend WithEvents ProgressBar4 As ProgressBar
    Friend WithEvents Label6 As Label
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents Button4 As Button
    Friend WithEvents ProgressBar5 As ProgressBar
    Friend WithEvents Label7 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents ChbpbIT As CheckBox
    Friend WithEvents Button6 As Button
    Friend WithEvents pbIT As ProgressBar
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Button8 As Button
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents Label9 As Label
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents Button7 As Button
    Friend WithEvents pbIP As ProgressBar
    Friend WithEvents Label8 As Label
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents Button9 As Button
    Friend WithEvents pbRDrs As ProgressBar
    Friend WithEvents Label10 As Label
End Class
