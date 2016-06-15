<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class devices_settings
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

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.list_ips = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.ckb_isIcmp = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_GetPara = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Url = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_Password = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_UserName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Port = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_HostGroup = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'list_ips
        '
        Me.list_ips.BackColor = System.Drawing.SystemColors.Info
        Me.list_ips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.list_ips.FormattingEnabled = True
        Me.list_ips.ItemHeight = 12
        Me.list_ips.Location = New System.Drawing.Point(109, 24)
        Me.list_ips.Name = "list_ips"
        Me.list_ips.Size = New System.Drawing.Size(146, 62)
        Me.list_ips.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP地址列表："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label12.Location = New System.Drawing.Point(108, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(239, 12)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "空白即 [Default] 组，输入新组自动创建。"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(61, 406)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(94, 32)
        Me.Cancel_Button.TabIndex = 33
        Me.Cancel_Button.Text = "取消"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(263, 406)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(94, 32)
        Me.OK_Button.TabIndex = 35
        Me.OK_Button.Text = "确定"
        '
        'ckb_isIcmp
        '
        Me.ckb_isIcmp.AutoSize = True
        Me.ckb_isIcmp.Checked = True
        Me.ckb_isIcmp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckb_isIcmp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ckb_isIcmp.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ckb_isIcmp.Location = New System.Drawing.Point(109, 352)
        Me.ckb_isIcmp.Name = "ckb_isIcmp"
        Me.ckb_isIcmp.Size = New System.Drawing.Size(78, 17)
        Me.ckb_isIcmp.TabIndex = 32
        Me.ckb_isIcmp.Text = "状态检查"
        Me.ckb_isIcmp.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label10.Location = New System.Drawing.Point(107, 322)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 12)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Example: user=$user&&pwd=$pwd"
        '
        'txt_GetPara
        '
        Me.txt_GetPara.BackColor = System.Drawing.SystemColors.Info
        Me.txt_GetPara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_GetPara.Location = New System.Drawing.Point(109, 298)
        Me.txt_GetPara.MaxLength = 1000
        Me.txt_GetPara.Name = "txt_GetPara"
        Me.txt_GetPara.Size = New System.Drawing.Size(308, 21)
        Me.txt_GetPara.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 308)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "GET参数："
        '
        'txt_Url
        '
        Me.txt_Url.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Url.Location = New System.Drawing.Point(109, 260)
        Me.txt_Url.MaxLength = 100
        Me.txt_Url.Name = "txt_Url"
        Me.txt_Url.Size = New System.Drawing.Size(308, 21)
        Me.txt_Url.TabIndex = 29
        Me.txt_Url.Text = "/index.htm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(59, 265)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 12)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "URL："
        '
        'txt_Password
        '
        Me.txt_Password.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Password.Location = New System.Drawing.Point(109, 219)
        Me.txt_Password.MaxLength = 50
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Password.Size = New System.Drawing.Size(171, 21)
        Me.txt_Password.TabIndex = 28
        Me.txt_Password.Text = "123"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "HTTP密码："
        '
        'txt_UserName
        '
        Me.txt_UserName.BackColor = System.Drawing.SystemColors.Info
        Me.txt_UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_UserName.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_UserName.Location = New System.Drawing.Point(109, 181)
        Me.txt_UserName.MaxLength = 50
        Me.txt_UserName.Name = "txt_UserName"
        Me.txt_UserName.Size = New System.Drawing.Size(171, 21)
        Me.txt_UserName.TabIndex = 26
        Me.txt_UserName.Text = "superuser"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 12)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "HTTP用户名："
        '
        'txt_Port
        '
        Me.txt_Port.BackColor = System.Drawing.SystemColors.Info
        Me.txt_Port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Port.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_Port.Location = New System.Drawing.Point(109, 143)
        Me.txt_Port.MaxLength = 5
        Me.txt_Port.Name = "txt_Port"
        Me.txt_Port.Size = New System.Drawing.Size(56, 21)
        Me.txt_Port.TabIndex = 25
        Me.txt_Port.Text = "80"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "HTTP端口："
        '
        'cmb_HostGroup
        '
        Me.cmb_HostGroup.BackColor = System.Drawing.SystemColors.Info
        Me.cmb_HostGroup.FormattingEnabled = True
        Me.cmb_HostGroup.Location = New System.Drawing.Point(109, 106)
        Me.cmb_HostGroup.MaxLength = 20
        Me.cmb_HostGroup.Name = "cmb_HostGroup"
        Me.cmb_HostGroup.Size = New System.Drawing.Size(171, 20)
        Me.cmb_HostGroup.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "组："
        '
        'devices_settings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(440, 470)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.ckb_isIcmp)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_GetPara)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_Url)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_Password)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_UserName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_Port)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmb_HostGroup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.list_ips)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "devices_settings"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批量添加设备"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents list_ips As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents OK_Button As Button
    Friend WithEvents ckb_isIcmp As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_GetPara As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_Url As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_Password As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_UserName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_Port As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmb_HostGroup As ComboBox
    Friend WithEvents Label2 As Label
End Class
