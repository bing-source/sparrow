<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class polling_logs
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.meu_ref = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.meu_ok = New System.Windows.Forms.ToolStripMenuItem()
        Me.meu_excvs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.meu_del = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tool_start = New System.Windows.Forms.ToolStripButton()
        Me.tool_prev = New System.Windows.Forms.ToolStripButton()
        Me.tool_pagetxt = New System.Windows.Forms.ToolStripLabel()
        Me.tool_next = New System.Windows.Forms.ToolStripButton()
        Me.tool_end = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tool_gobox = New System.Windows.Forms.ToolStripTextBox()
        Me.tool_goto = New System.Windows.Forms.ToolStripButton()
        Me.btn_excvs = New System.Windows.Forms.ToolStripButton()
        Me.btn_del = New System.Windows.Forms.ToolStripButton()
        Me.btn_ok = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tool_Keywords = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.tool_ischk = New System.Windows.Forms.ToolStripComboBox()
        Me.tool_search = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(748, 362)
        Me.DataGridView1.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.meu_ref, Me.ToolStripMenuItem2, Me.meu_ok, Me.meu_excvs, Me.ToolStripMenuItem1, Me.meu_del})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 104)
        '
        'meu_ref
        '
        Me.meu_ref.Name = "meu_ref"
        Me.meu_ref.Size = New System.Drawing.Size(135, 22)
        Me.meu_ref.Text = "刷新(&R)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(132, 6)
        '
        'meu_ok
        '
        Me.meu_ok.Name = "meu_ok"
        Me.meu_ok.Size = New System.Drawing.Size(135, 22)
        Me.meu_ok.Text = "确认(&O)"
        '
        'meu_excvs
        '
        Me.meu_excvs.Name = "meu_excvs"
        Me.meu_excvs.Size = New System.Drawing.Size(135, 22)
        Me.meu_excvs.Text = "导出到&CVS"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(132, 6)
        '
        'meu_del
        '
        Me.meu_del.Name = "meu_del"
        Me.meu_del.Size = New System.Drawing.Size(135, 22)
        Me.meu_del.Text = "删除(&D)"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 31)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(754, 368)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'tool_start
        '
        Me.tool_start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_start.Image = Global.sparrow.My.Resources.Resources.icon_first
        Me.tool_start.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_start.Name = "tool_start"
        Me.tool_start.Size = New System.Drawing.Size(23, 28)
        Me.tool_start.Text = "First"
        '
        'tool_prev
        '
        Me.tool_prev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_prev.Image = Global.sparrow.My.Resources.Resources.icon_prev
        Me.tool_prev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_prev.Name = "tool_prev"
        Me.tool_prev.Size = New System.Drawing.Size(23, 28)
        Me.tool_prev.Text = "Pre"
        '
        'tool_pagetxt
        '
        Me.tool_pagetxt.AutoSize = False
        Me.tool_pagetxt.ForeColor = System.Drawing.Color.Black
        Me.tool_pagetxt.Name = "tool_pagetxt"
        Me.tool_pagetxt.Size = New System.Drawing.Size(100, 22)
        Me.tool_pagetxt.Text = "0/0"
        '
        'tool_next
        '
        Me.tool_next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_next.Image = Global.sparrow.My.Resources.Resources.icon_next
        Me.tool_next.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_next.Name = "tool_next"
        Me.tool_next.Size = New System.Drawing.Size(23, 28)
        Me.tool_next.Text = "Next"
        '
        'tool_end
        '
        Me.tool_end.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_end.Image = Global.sparrow.My.Resources.Resources.icon_last
        Me.tool_end.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_end.Name = "tool_end"
        Me.tool_end.Size = New System.Drawing.Size(23, 28)
        Me.tool_end.Text = "Last"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.AutoSize = False
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripLabel2.Text = "&GO:"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tool_gobox
        '
        Me.tool_gobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tool_gobox.MaxLength = 5
        Me.tool_gobox.Name = "tool_gobox"
        Me.tool_gobox.Size = New System.Drawing.Size(50, 31)
        Me.tool_gobox.Text = "1"
        Me.tool_gobox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tool_goto
        '
        Me.tool_goto.ForeColor = System.Drawing.Color.White
        Me.tool_goto.Image = Global.sparrow.My.Resources.Resources.button_blue_90
        Me.tool_goto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tool_goto.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tool_goto.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.tool_goto.Name = "tool_goto"
        Me.tool_goto.Size = New System.Drawing.Size(94, 28)
        Me.tool_goto.Text = "Jump(&J)"
        Me.tool_goto.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btn_excvs
        '
        Me.btn_excvs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_excvs.ForeColor = System.Drawing.Color.White
        Me.btn_excvs.Image = Global.sparrow.My.Resources.Resources.button_blue_90
        Me.btn_excvs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_excvs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_excvs.Name = "btn_excvs"
        Me.btn_excvs.Size = New System.Drawing.Size(94, 28)
        Me.btn_excvs.Text = "Export to CSV"
        Me.btn_excvs.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btn_del
        '
        Me.btn_del.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_del.ForeColor = System.Drawing.Color.White
        Me.btn_del.Image = Global.sparrow.My.Resources.Resources.button_blue_90
        Me.btn_del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_del.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.btn_del.Name = "btn_del"
        Me.btn_del.Size = New System.Drawing.Size(94, 28)
        Me.btn_del.Text = "Delete(&E)"
        Me.btn_del.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btn_del.ToolTipText = "Delete(E)"
        '
        'btn_ok
        '
        Me.btn_ok.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_ok.ForeColor = System.Drawing.Color.White
        Me.btn_ok.Image = Global.sparrow.My.Resources.Resources.button_blue_90
        Me.btn_ok.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_ok.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.btn_ok.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(94, 28)
        Me.btn_ok.Text = "Confirm(&O)"
        Me.btn_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_start, Me.tool_prev, Me.tool_pagetxt, Me.tool_next, Me.tool_end, Me.ToolStripLabel2, Me.tool_gobox, Me.tool_goto, Me.btn_excvs, Me.btn_del, Me.btn_ok})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 399)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(754, 31)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.TabStop = True
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(93, 28)
        Me.ToolStripLabel1.Text = "Keywords(&K)："
        '
        'tool_Keywords
        '
        Me.tool_Keywords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tool_Keywords.Margin = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.tool_Keywords.MaxLength = 100
        Me.tool_Keywords.Name = "tool_Keywords"
        Me.tool_Keywords.Size = New System.Drawing.Size(120, 31)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(96, 28)
        Me.ToolStripLabel4.Text = "Confirmed(&T)："
        '
        'tool_ischk
        '
        Me.tool_ischk.AutoSize = False
        Me.tool_ischk.BackColor = System.Drawing.SystemColors.Window
        Me.tool_ischk.DropDownHeight = 100
        Me.tool_ischk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tool_ischk.DropDownWidth = 80
        Me.tool_ischk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tool_ischk.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tool_ischk.IntegralHeight = False
        Me.tool_ischk.Items.AddRange(New Object() {"No", "Yes"})
        Me.tool_ischk.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.tool_ischk.Name = "tool_ischk"
        Me.tool_ischk.Size = New System.Drawing.Size(80, 25)
        '
        'tool_search
        '
        Me.tool_search.ForeColor = System.Drawing.Color.White
        Me.tool_search.Image = Global.sparrow.My.Resources.Resources.button_blue_90
        Me.tool_search.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tool_search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_search.Margin = New System.Windows.Forms.Padding(20, 1, 0, 2)
        Me.tool_search.Name = "tool_search"
        Me.tool_search.Size = New System.Drawing.Size(94, 28)
        Me.tool_search.Text = "Search(&S)"
        Me.tool_search.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.tool_Keywords, Me.ToolStripLabel4, Me.tool_ischk, Me.tool_search})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(754, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.TabStop = True
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'logForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 430)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "logForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Polling Logs"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents meu_ok As ToolStripMenuItem
    Friend WithEvents meu_excvs As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents meu_del As ToolStripMenuItem
    Friend WithEvents meu_ref As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents tool_start As ToolStripButton
    Friend WithEvents tool_prev As ToolStripButton
    Friend WithEvents tool_pagetxt As ToolStripLabel
    Friend WithEvents tool_next As ToolStripButton
    Friend WithEvents tool_end As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents tool_gobox As ToolStripTextBox
    Friend WithEvents tool_goto As ToolStripButton
    Friend WithEvents btn_excvs As ToolStripButton
    Friend WithEvents btn_del As ToolStripButton
    Friend WithEvents btn_ok As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tool_Keywords As ToolStripTextBox
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents tool_ischk As ToolStripComboBox
    Friend WithEvents tool_search As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
End Class
