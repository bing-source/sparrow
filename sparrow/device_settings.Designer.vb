<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class device_settings
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_HostName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_HostGroup = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_IPAddr = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Port = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_UserName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Password = New System.Windows.Forms.TextBox()
        Me.rdb_Server = New System.Windows.Forms.RadioButton()
        Me.rdb_Session = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_Url = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_GetPara = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_PostPara = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ckb_isIcmp = New System.Windows.Forms.CheckBox()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(295, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "别名："
        '
        'txt_HostName
        '
        Me.txt_HostName.BackColor = System.Drawing.SystemColors.Info
        Me.txt_HostName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_HostName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_HostName.Location = New System.Drawing.Point(337, 8)
        Me.txt_HostName.MaxLength = 20
        Me.txt_HostName.Name = "txt_HostName"
        Me.txt_HostName.Size = New System.Drawing.Size(171, 21)
        Me.txt_HostName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "组："
        '
        'cmb_HostGroup
        '
        Me.cmb_HostGroup.BackColor = System.Drawing.SystemColors.Info
        Me.cmb_HostGroup.FormattingEnabled = True
        Me.cmb_HostGroup.Location = New System.Drawing.Point(107, 46)
        Me.cmb_HostGroup.MaxLength = 20
        Me.cmb_HostGroup.Name = "cmb_HostGroup"
        Me.cmb_HostGroup.Size = New System.Drawing.Size(171, 20)
        Me.cmb_HostGroup.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "IP地址："
        '
        'txt_IPAddr
        '
        Me.txt_IPAddr.BackColor = System.Drawing.SystemColors.Info
        Me.txt_IPAddr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_IPAddr.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_IPAddr.Location = New System.Drawing.Point(107, 8)
        Me.txt_IPAddr.MaxLength = 15
        Me.txt_IPAddr.Name = "txt_IPAddr"
        Me.txt_IPAddr.Size = New System.Drawing.Size(171, 21)
        Me.txt_IPAddr.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "HTTP端口："
        '
        'txt_Port
        '
        Me.txt_Port.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Port.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_Port.Location = New System.Drawing.Point(107, 83)
        Me.txt_Port.MaxLength = 5
        Me.txt_Port.Name = "txt_Port"
        Me.txt_Port.Size = New System.Drawing.Size(56, 21)
        Me.txt_Port.TabIndex = 4
        Me.txt_Port.Text = "80"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "HTTP用户名："
        '
        'txt_UserName
        '
        Me.txt_UserName.BackColor = System.Drawing.SystemColors.Info
        Me.txt_UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_UserName.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_UserName.Location = New System.Drawing.Point(107, 121)
        Me.txt_UserName.MaxLength = 50
        Me.txt_UserName.Name = "txt_UserName"
        Me.txt_UserName.Size = New System.Drawing.Size(171, 21)
        Me.txt_UserName.TabIndex = 5
        Me.txt_UserName.Text = "superuser"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "HTTP密码："
        '
        'txt_Password
        '
        Me.txt_Password.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Password.Location = New System.Drawing.Point(107, 159)
        Me.txt_Password.MaxLength = 50
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Password.Size = New System.Drawing.Size(171, 21)
        Me.txt_Password.TabIndex = 6
        Me.txt_Password.Text = "123"
        '
        'rdb_Server
        '
        Me.rdb_Server.AutoSize = True
        Me.rdb_Server.Checked = True
        Me.rdb_Server.Location = New System.Drawing.Point(11, 357)
        Me.rdb_Server.Name = "rdb_Server"
        Me.rdb_Server.Size = New System.Drawing.Size(155, 16)
        Me.rdb_Server.TabIndex = 12
        Me.rdb_Server.TabStop = True
        Me.rdb_Server.Text = "HTTP Authentication(&H)"
        Me.rdb_Server.UseVisualStyleBackColor = True
        Me.rdb_Server.Visible = False
        '
        'rdb_Session
        '
        Me.rdb_Session.AutoSize = True
        Me.rdb_Session.Location = New System.Drawing.Point(163, 357)
        Me.rdb_Session.Name = "rdb_Session"
        Me.rdb_Session.Size = New System.Drawing.Size(173, 16)
        Me.rdb_Session.TabIndex = 13
        Me.rdb_Session.TabStop = True
        Me.rdb_Session.Text = "Session Authentication(&S)"
        Me.rdb_Session.UseVisualStyleBackColor = True
        Me.rdb_Session.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(47, 205)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 12)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "URL："
        '
        'txt_Url
        '
        Me.txt_Url.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Url.Location = New System.Drawing.Point(107, 200)
        Me.txt_Url.MaxLength = 100
        Me.txt_Url.Name = "txt_Url"
        Me.txt_Url.Size = New System.Drawing.Size(308, 21)
        Me.txt_Url.TabIndex = 7
        Me.txt_Url.Text = "/"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "GET参数："
        '
        'txt_GetPara
        '
        Me.txt_GetPara.BackColor = System.Drawing.SystemColors.Info
        Me.txt_GetPara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_GetPara.Location = New System.Drawing.Point(107, 238)
        Me.txt_GetPara.MaxLength = 1000
        Me.txt_GetPara.Name = "txt_GetPara"
        Me.txt_GetPara.Size = New System.Drawing.Size(308, 21)
        Me.txt_GetPara.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 384)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 12)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "POST Parameters(&O):"
        Me.Label9.Visible = False
        '
        'txt_PostPara
        '
        Me.txt_PostPara.Location = New System.Drawing.Point(135, 379)
        Me.txt_PostPara.MaxLength = 1000
        Me.txt_PostPara.Name = "txt_PostPara"
        Me.txt_PostPara.Size = New System.Drawing.Size(84, 21)
        Me.txt_PostPara.TabIndex = 20
        Me.txt_PostPara.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label10.Location = New System.Drawing.Point(105, 262)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 12)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Example: user=$user&&pwd=$pwd"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(133, 400)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(173, 12)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Example: user=$user&&pwd=$pwd"
        Me.Label11.Visible = False
        '
        'ckb_isIcmp
        '
        Me.ckb_isIcmp.AutoSize = True
        Me.ckb_isIcmp.Checked = True
        Me.ckb_isIcmp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckb_isIcmp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ckb_isIcmp.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ckb_isIcmp.Location = New System.Drawing.Point(107, 292)
        Me.ckb_isIcmp.Name = "ckb_isIcmp"
        Me.ckb_isIcmp.Size = New System.Drawing.Size(78, 17)
        Me.ckb_isIcmp.TabIndex = 9
        Me.ckb_isIcmp.Text = "状态检查"
        Me.ckb_isIcmp.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(272, 315)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(94, 32)
        Me.OK_Button.TabIndex = 11
        Me.OK_Button.Text = "确定"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(404, 315)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(94, 32)
        Me.Cancel_Button.TabIndex = 10
        Me.Cancel_Button.Text = "取消"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label12.Location = New System.Drawing.Point(106, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(239, 12)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "空白即 [Default] 组，输入新组自动创建。"
        '
        'device_settings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(517, 362)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.ckb_isIcmp)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_PostPara)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_GetPara)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_Url)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.rdb_Session)
        Me.Controls.Add(Me.rdb_Server)
        Me.Controls.Add(Me.txt_Password)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_UserName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_Port)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_IPAddr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_HostGroup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_HostName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "device_settings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "修改设备参数"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_HostName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_HostGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_IPAddr As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Port As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_UserName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Password As System.Windows.Forms.TextBox
    Friend WithEvents rdb_Server As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_Session As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_Url As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_GetPara As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_PostPara As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ckb_isIcmp As CheckBox
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents Label12 As Label
End Class
