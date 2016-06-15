<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
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

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menu_addHost = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_modHost = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_modGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menu_delHost = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_delGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_clearHost = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.menu_reLoadHost = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.menu_scan = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_outTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_sysBrower = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_ping = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_telnet = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tool_systemSet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tool_addHost = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tool_hostlog = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tool_alarm = New System.Windows.Forms.ToolStripButton()
        Me.tool_alarm_tip = New System.Windows.Forms.ToolStripLabel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmb_seo = New System.Windows.Forms.ComboBox()
        Me.lv_alarm = New System.Windows.Forms.ListView()
        Me.lv_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lv_date = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lv_ip = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lv_host = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lv_level = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lv_content = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.ItemSize = New System.Drawing.Size(48, 18)
        Me.TabControl1.Location = New System.Drawing.Point(182, 33)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(600, 364)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.WebBrowser1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(592, 338)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Welcome"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Size = New System.Drawing.Size(584, 330)
        Me.WebBrowser1.TabIndex = 3
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.Beige
        Me.TreeView1.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(0, 52)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(180, 427)
        Me.TreeView1.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder")
        Me.ImageList1.Images.SetKeyName(1, "folder_open")
        Me.ImageList1.Images.SetKeyName(2, "default.png")
        Me.ImageList1.Images.SetKeyName(3, "ok.png")
        Me.ImageList1.Images.SetKeyName(4, "lost.png")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_addHost, Me.menu_modHost, Me.menu_modGroup, Me.ToolStripMenuItem1, Me.menu_delHost, Me.menu_delGroup, Me.menu_clearHost, Me.ToolStripMenuItem2, Me.menu_reLoadHost, Me.ToolStripMenuItem3, Me.menu_scan, Me.menu_outTools})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 220)
        '
        'menu_addHost
        '
        Me.menu_addHost.Name = "menu_addHost"
        Me.menu_addHost.Size = New System.Drawing.Size(181, 22)
        Me.menu_addHost.Text = "添加设备"
        '
        'menu_modHost
        '
        Me.menu_modHost.Name = "menu_modHost"
        Me.menu_modHost.Size = New System.Drawing.Size(181, 22)
        Me.menu_modHost.Text = "修改设备参数"
        '
        'menu_modGroup
        '
        Me.menu_modGroup.Name = "menu_modGroup"
        Me.menu_modGroup.Size = New System.Drawing.Size(181, 22)
        Me.menu_modGroup.Text = "修改组参数"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(178, 6)
        '
        'menu_delHost
        '
        Me.menu_delHost.Name = "menu_delHost"
        Me.menu_delHost.Size = New System.Drawing.Size(181, 22)
        Me.menu_delHost.Text = "删除设备"
        '
        'menu_delGroup
        '
        Me.menu_delGroup.Name = "menu_delGroup"
        Me.menu_delGroup.Size = New System.Drawing.Size(181, 22)
        Me.menu_delGroup.Text = "删除组"
        '
        'menu_clearHost
        '
        Me.menu_clearHost.Name = "menu_clearHost"
        Me.menu_clearHost.Size = New System.Drawing.Size(181, 22)
        Me.menu_clearHost.Text = "Delete all"
        Me.menu_clearHost.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(178, 6)
        '
        'menu_reLoadHost
        '
        Me.menu_reLoadHost.Name = "menu_reLoadHost"
        Me.menu_reLoadHost.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.menu_reLoadHost.Size = New System.Drawing.Size(181, 22)
        Me.menu_reLoadHost.Text = "重新加载设备树"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(178, 6)
        Me.ToolStripMenuItem3.Visible = False
        '
        'menu_scan
        '
        Me.menu_scan.Name = "menu_scan"
        Me.menu_scan.Size = New System.Drawing.Size(181, 22)
        Me.menu_scan.Text = "扫描添加设备"
        '
        'menu_outTools
        '
        Me.menu_outTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_sysBrower, Me.menu_ping, Me.menu_telnet})
        Me.menu_outTools.Name = "menu_outTools"
        Me.menu_outTools.Size = New System.Drawing.Size(181, 22)
        Me.menu_outTools.Text = "外部工具"
        Me.menu_outTools.Visible = False
        '
        'menu_sysBrower
        '
        Me.menu_sysBrower.Name = "menu_sysBrower"
        Me.menu_sysBrower.Size = New System.Drawing.Size(127, 22)
        Me.menu_sysBrower.Text = "IE 浏览器"
        '
        'menu_ping
        '
        Me.menu_ping.Name = "menu_ping"
        Me.menu_ping.Size = New System.Drawing.Size(127, 22)
        Me.menu_ping.Text = "Ping"
        '
        'menu_telnet
        '
        Me.menu_telnet.Name = "menu_telnet"
        Me.menu_telnet.Size = New System.Drawing.Size(127, 22)
        Me.menu_telnet.Text = "Telnet"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Pink
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(26, 26)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_systemSet, Me.ToolStripSeparator1, Me.tool_addHost, Me.ToolStripSeparator2, Me.tool_hostlog, Me.ToolStripSeparator3, Me.tool_alarm, Me.tool_alarm_tip})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 33)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.TabStop = True
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tool_systemSet
        '
        Me.tool_systemSet.Image = Global.sparrow.My.Resources.Resources.settings
        Me.tool_systemSet.Name = "tool_systemSet"
        Me.tool_systemSet.Size = New System.Drawing.Size(101, 30)
        Me.tool_systemSet.Text = "系统设置(&S)"
        Me.tool_systemSet.ToolTipText = "Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 33)
        '
        'tool_addHost
        '
        Me.tool_addHost.Image = Global.sparrow.My.Resources.Resources.plus
        Me.tool_addHost.Name = "tool_addHost"
        Me.tool_addHost.Size = New System.Drawing.Size(102, 30)
        Me.tool_addHost.Text = "添加设备(&A)"
        Me.tool_addHost.ToolTipText = "Add device"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 33)
        Me.ToolStripSeparator2.Visible = False
        '
        'tool_hostlog
        '
        Me.tool_hostlog.Image = Global.sparrow.My.Resources.Resources.journal
        Me.tool_hostlog.Name = "tool_hostlog"
        Me.tool_hostlog.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.tool_hostlog.Size = New System.Drawing.Size(119, 30)
        Me.tool_hostlog.Text = "Polling Logs"
        Me.tool_hostlog.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 33)
        '
        'tool_alarm
        '
        Me.tool_alarm.Image = Global.sparrow.My.Resources.Resources.journal
        Me.tool_alarm.Name = "tool_alarm"
        Me.tool_alarm.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.tool_alarm.Size = New System.Drawing.Size(109, 30)
        Me.tool_alarm.Text = "告警日志(&J)"
        Me.tool_alarm.ToolTipText = "alarms"
        '
        'tool_alarm_tip
        '
        Me.tool_alarm_tip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tool_alarm_tip.AutoSize = False
        Me.tool_alarm_tip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tool_alarm_tip.ForeColor = System.Drawing.SystemColors.Highlight
        Me.tool_alarm_tip.Image = Global.sparrow.My.Resources.Resources.warning
        Me.tool_alarm_tip.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.tool_alarm_tip.Name = "tool_alarm_tip"
        Me.tool_alarm_tip.Size = New System.Drawing.Size(80, 26)
        Me.tool_alarm_tip.Text = "0"
        Me.tool_alarm_tip.ToolTipText = "未确认的告警数量"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 3000
        '
        'cmb_seo
        '
        Me.cmb_seo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_seo.FormattingEnabled = True
        Me.cmb_seo.Location = New System.Drawing.Point(0, 31)
        Me.cmb_seo.MaxDropDownItems = 10
        Me.cmb_seo.MaxLength = 20
        Me.cmb_seo.Name = "cmb_seo"
        Me.cmb_seo.Size = New System.Drawing.Size(180, 20)
        Me.cmb_seo.TabIndex = 0
        '
        'lv_alarm
        '
        Me.lv_alarm.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
        Me.lv_alarm.BackColor = System.Drawing.SystemColors.Info
        Me.lv_alarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lv_alarm.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lv_id, Me.lv_date, Me.lv_ip, Me.lv_host, Me.lv_level, Me.lv_content})
        Me.lv_alarm.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lv_alarm.GridLines = True
        Me.lv_alarm.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lv_alarm.Location = New System.Drawing.Point(186, 393)
        Me.lv_alarm.MultiSelect = False
        Me.lv_alarm.Name = "lv_alarm"
        Me.lv_alarm.ShowGroups = False
        Me.lv_alarm.Size = New System.Drawing.Size(592, 84)
        Me.lv_alarm.TabIndex = 5
        Me.lv_alarm.UseCompatibleStateImageBehavior = False
        Me.lv_alarm.View = System.Windows.Forms.View.Details
        '
        'lv_id
        '
        Me.lv_id.Text = "id"
        Me.lv_id.Width = 0
        '
        'lv_date
        '
        Me.lv_date.Text = "date"
        Me.lv_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lv_date.Width = 140
        '
        'lv_ip
        '
        Me.lv_ip.Text = "ip"
        Me.lv_ip.Width = 120
        '
        'lv_host
        '
        Me.lv_host.Text = "host"
        Me.lv_host.Width = 160
        '
        'lv_level
        '
        Me.lv_level.Text = "level"
        Me.lv_level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lv_level.Width = 40
        '
        'lv_content
        '
        Me.lv_content.Text = "content"
        Me.lv_content.Width = 500
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 481)
        Me.Controls.Add(Me.lv_alarm)
        Me.Controls.Add(Me.cmb_seo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.TabControl1)
        Me.KeyPreview = True
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "交换机管理软件"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menu_addHost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menu_delHost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_clearHost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_modHost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menu_reLoadHost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_modGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_delGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menu_outTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_sysBrower As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_ping As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_telnet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tool_alarm_tip As ToolStripLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents tool_systemSet As ToolStripButton
    Friend WithEvents tool_addHost As ToolStripButton
    Friend WithEvents tool_hostlog As ToolStripButton
    Friend WithEvents tool_alarm As ToolStripButton
    Friend WithEvents cmb_seo As ComboBox
    Friend WithEvents lv_alarm As ListView
    Friend WithEvents lv_id As ColumnHeader
    Friend WithEvents lv_date As ColumnHeader
    Friend WithEvents lv_ip As ColumnHeader
    Friend WithEvents lv_host As ColumnHeader
    Friend WithEvents lv_level As ColumnHeader
    Friend WithEvents lv_content As ColumnHeader
    Friend WithEvents menu_scan As ToolStripMenuItem
End Class
