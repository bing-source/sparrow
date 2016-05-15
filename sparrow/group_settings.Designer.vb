<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class group_settings
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
        Me.txt_sort = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_hostGroup = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "排序ID："
        '
        'txt_sort
        '
        Me.txt_sort.BackColor = System.Drawing.SystemColors.Info
        Me.txt_sort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sort.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_sort.Location = New System.Drawing.Point(100, 19)
        Me.txt_sort.MaxLength = 2
        Me.txt_sort.Name = "txt_sort"
        Me.txt_sort.Size = New System.Drawing.Size(54, 21)
        Me.txt_sort.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "组名称："
        '
        'txt_hostGroup
        '
        Me.txt_hostGroup.BackColor = System.Drawing.SystemColors.Info
        Me.txt_hostGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_hostGroup.Location = New System.Drawing.Point(100, 54)
        Me.txt_hostGroup.MaxLength = 20
        Me.txt_hostGroup.Name = "txt_hostGroup"
        Me.txt_hostGroup.Size = New System.Drawing.Size(160, 21)
        Me.txt_hostGroup.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(37, 101)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 32)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(183, 101)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 32)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'group_settings
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(302, 156)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_hostGroup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_sort)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "group_settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "修改组参数"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_sort As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_hostGroup As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
