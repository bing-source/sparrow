<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scan_devices
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.txt_startIP = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_IPPoolSize = New System.Windows.Forms.TextBox()
        Me.Scan = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "开始IP地址："
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(140, 107)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 31)
        Me.Cancel.TabIndex = 1
        Me.Cancel.Text = "取消"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'txt_startIP
        '
        Me.txt_startIP.BackColor = System.Drawing.SystemColors.Info
        Me.txt_startIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_startIP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_startIP.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_startIP.Location = New System.Drawing.Point(106, 23)
        Me.txt_startIP.MaxLength = 15
        Me.txt_startIP.Name = "txt_startIP"
        Me.txt_startIP.Size = New System.Drawing.Size(109, 21)
        Me.txt_startIP.TabIndex = 3
        Me.txt_startIP.Text = "192.168."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "数量："
        '
        'txt_IPPoolSize
        '
        Me.txt_IPPoolSize.BackColor = System.Drawing.SystemColors.Info
        Me.txt_IPPoolSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_IPPoolSize.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_IPPoolSize.Location = New System.Drawing.Point(106, 61)
        Me.txt_IPPoolSize.MaxLength = 3
        Me.txt_IPPoolSize.Name = "txt_IPPoolSize"
        Me.txt_IPPoolSize.Size = New System.Drawing.Size(36, 21)
        Me.txt_IPPoolSize.TabIndex = 4
        Me.txt_IPPoolSize.Text = "10"
        '
        'Scan
        '
        Me.Scan.Location = New System.Drawing.Point(25, 107)
        Me.Scan.Name = "Scan"
        Me.Scan.Size = New System.Drawing.Size(75, 27)
        Me.Scan.TabIndex = 5
        Me.Scan.Text = "扫描"
        Me.Scan.UseVisualStyleBackColor = True
        '
        'scan_devices
        '
        Me.AcceptButton = Me.Scan
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(248, 159)
        Me.Controls.Add(Me.Scan)
        Me.Controls.Add(Me.txt_IPPoolSize)
        Me.Controls.Add(Me.txt_startIP)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "scan_devices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "扫描添加设备"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Cancel As Button
    Friend WithEvents txt_startIP As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_IPPoolSize As TextBox
    Friend WithEvents Scan As Button
End Class
