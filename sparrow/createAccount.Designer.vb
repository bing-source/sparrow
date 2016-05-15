<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class createAccount
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
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rePasswordTextBox = New System.Windows.Forms.TextBox()
        Me.lab_tip = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.Location = New System.Drawing.Point(21, 76)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(59, 13)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "用户名："
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.Location = New System.Drawing.Point(21, 146)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(46, 13)
        Me.PasswordLabel.TabIndex = 0
        Me.PasswordLabel.Text = "密码："
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameTextBox.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.UsernameTextBox.Location = New System.Drawing.Point(24, 92)
        Me.UsernameTextBox.MaxLength = 50
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(193, 22)
        Me.UsernameTextBox.TabIndex = 1
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.PasswordTextBox.Location = New System.Drawing.Point(24, 162)
        Me.PasswordTextBox.MaxLength = 50
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(193, 22)
        Me.PasswordTextBox.TabIndex = 2
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(57, 289)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(120, 46)
        Me.OK.TabIndex = 4
        Me.OK.Text = "确定"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(82, 266)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(59, 25)
        Me.Cancel.TabIndex = 0
        Me.Cancel.Text = "取消"
        Me.Cancel.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 217)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "确认密码："
        '
        'rePasswordTextBox
        '
        Me.rePasswordTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.rePasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rePasswordTextBox.Location = New System.Drawing.Point(24, 233)
        Me.rePasswordTextBox.MaxLength = 50
        Me.rePasswordTextBox.Name = "rePasswordTextBox"
        Me.rePasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.rePasswordTextBox.Size = New System.Drawing.Size(193, 22)
        Me.rePasswordTextBox.TabIndex = 3
        '
        'lab_tip
        '
        Me.lab_tip.AutoSize = True
        Me.lab_tip.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lab_tip.ForeColor = System.Drawing.Color.Yellow
        Me.lab_tip.Location = New System.Drawing.Point(11, 27)
        Me.lab_tip.Name = "lab_tip"
        Me.lab_tip.Size = New System.Drawing.Size(234, 21)
        Me.lab_tip.TabIndex = 8
        Me.lab_tip.Text = "第一次使用需要创建一个账户。"
        '
        'createAccount
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Highlight
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(251, 347)
        Me.Controls.Add(Me.lab_tip)
        Me.Controls.Add(Me.rePasswordTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.SystemColors.Window
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "createAccount"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "创建新账户"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rePasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lab_tip As System.Windows.Forms.Label

End Class
