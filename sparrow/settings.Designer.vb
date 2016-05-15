<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class settings
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
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rePasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.oldPasswordTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_centerIP = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_retry = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_timeOut = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ckb_Icmp = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(27, 300)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 30)
        Me.OK.TabIndex = 8
        Me.OK.Text = "确定"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(166, 300)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 30)
        Me.Cancel.TabIndex = 7
        Me.Cancel.Text = "取消"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rePasswordTextBox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PasswordTextBox)
        Me.GroupBox1.Controls.Add(Me.oldPasswordTextBox)
        Me.GroupBox1.Controls.Add(Me.PasswordLabel)
        Me.GroupBox1.Controls.Add(Me.UsernameLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 151)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 128)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "修改密码"
        '
        'rePasswordTextBox
        '
        Me.rePasswordTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.rePasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rePasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.rePasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.rePasswordTextBox.Location = New System.Drawing.Point(98, 90)
        Me.rePasswordTextBox.MaxLength = 50
        Me.rePasswordTextBox.Name = "rePasswordTextBox"
        Me.rePasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.rePasswordTextBox.Size = New System.Drawing.Size(140, 21)
        Me.rePasswordTextBox.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "确认密码："
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.PasswordTextBox.Location = New System.Drawing.Point(98, 59)
        Me.PasswordTextBox.MaxLength = 50
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(140, 21)
        Me.PasswordTextBox.TabIndex = 5
        '
        'oldPasswordTextBox
        '
        Me.oldPasswordTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.oldPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.oldPasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.oldPasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.oldPasswordTextBox.Location = New System.Drawing.Point(98, 28)
        Me.oldPasswordTextBox.MaxLength = 50
        Me.oldPasswordTextBox.Name = "oldPasswordTextBox"
        Me.oldPasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.oldPasswordTextBox.Size = New System.Drawing.Size(140, 21)
        Me.oldPasswordTextBox.TabIndex = 4
        '
        'PasswordLabel
        '
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.Location = New System.Drawing.Point(20, 62)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(53, 12)
        Me.PasswordLabel.TabIndex = 0
        Me.PasswordLabel.Text = "新密码："
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.Location = New System.Drawing.Point(20, 31)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(53, 12)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "旧密码："
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txt_centerIP)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txt_retry)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txt_timeOut)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ckb_Icmp)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 123)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "设备状态检查"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DarkGray
        Me.Label5.Location = New System.Drawing.Point(13, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(245, 12)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "* Use space key to separata multiple NMS"
        Me.Label5.Visible = False
        '
        'txt_centerIP
        '
        Me.txt_centerIP.Location = New System.Drawing.Point(103, 110)
        Me.txt_centerIP.MaxLength = 100
        Me.txt_centerIP.Name = "txt_centerIP"
        Me.txt_centerIP.Size = New System.Drawing.Size(154, 21)
        Me.txt_centerIP.TabIndex = 0
        Me.txt_centerIP.Text = "127.0.0.1"
        Me.txt_centerIP.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Center NMS(&N):"
        Me.Label4.Visible = False
        '
        'txt_retry
        '
        Me.txt_retry.BackColor = System.Drawing.SystemColors.Info
        Me.txt_retry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_retry.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_retry.Location = New System.Drawing.Point(120, 84)
        Me.txt_retry.MaxLength = 1
        Me.txt_retry.Name = "txt_retry"
        Me.txt_retry.Size = New System.Drawing.Size(27, 21)
        Me.txt_retry.TabIndex = 3
        Me.txt_retry.Text = "3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ping重试次数："
        '
        'txt_timeOut
        '
        Me.txt_timeOut.BackColor = System.Drawing.SystemColors.Info
        Me.txt_timeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_timeOut.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_timeOut.Location = New System.Drawing.Point(120, 52)
        Me.txt_timeOut.MaxLength = 3
        Me.txt_timeOut.Name = "txt_timeOut"
        Me.txt_timeOut.Size = New System.Drawing.Size(43, 21)
        Me.txt_timeOut.TabIndex = 2
        Me.txt_timeOut.Text = "300"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "间隔（秒）："
        '
        'ckb_Icmp
        '
        Me.ckb_Icmp.AutoSize = True
        Me.ckb_Icmp.Checked = True
        Me.ckb_Icmp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckb_Icmp.Location = New System.Drawing.Point(25, 25)
        Me.ckb_Icmp.Name = "ckb_Icmp"
        Me.ckb_Icmp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ckb_Icmp.Size = New System.Drawing.Size(48, 16)
        Me.ckb_Icmp.TabIndex = 1
        Me.ckb_Icmp.Text = "开启"
        Me.ckb_Icmp.UseVisualStyleBackColor = True
        '
        'settings
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(292, 347)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "settings"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "设置"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rePasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents oldPasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_timeOut As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ckb_Icmp As System.Windows.Forms.CheckBox
    Friend WithEvents txt_retry As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_centerIP As TextBox
    Friend WithEvents Label5 As Label
End Class
