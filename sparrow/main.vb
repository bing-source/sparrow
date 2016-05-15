Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Text
Imports System.Threading
Imports SHDocVw
Public Class main
    Sub loadHostGroup() '载入组
        MyCls.load_hostGroup()
        Dim tb_hostGroup As DataTable = MyCls.hostDataSet.Tables("hostGroup")
        If tb_hostGroup Is Nothing Then Return
        Dim hg_id As Integer, hg_groupName As String
        TreeView1.Nodes.Add(0, "[Default]")
        For i = 0 To tb_hostGroup.Rows.Count - 1
            hg_id = tb_hostGroup.Rows(i)("id")
            hg_groupName = tb_hostGroup.Rows(i)("groupName")
            TreeView1.Nodes.Add(hg_id.ToString, hg_groupName, 0)
        Next
    End Sub
    Sub loadwebHost() '载入主机
        MyCls.load_webHostp()
        Dim tb_webHost As DataTable = MyCls.hostDataSet.Tables("webHost")
        Dim h_id, h_HostGroup, hgIdx As Integer, h_hostName As String
        For i = 0 To tb_webHost.Rows.Count - 1
            h_id = tb_webHost.Rows(i)("id")
            h_hostName = tb_webHost.Rows(i)("hostName")
            h_HostGroup = tb_webHost.Rows(i)("HostGroup")
            If h_HostGroup = 0 Then
                hgIdx = 0
            Else
                hgIdx = getHgIdx(h_HostGroup)
            End If
            TreeView1.Nodes.Item(hgIdx).Nodes.Add(h_id.ToString, h_hostName, 2, 2)
        Next
    End Sub
    Function getHgIdx(ByVal hg_id As Integer) As Integer
        Dim hgIdx As Integer = 0
        For i = 0 To TreeView1.Nodes.Count - 1
            If Convert.ToInt32(TreeView1.Nodes.Item(i).Name) = hg_id Then
                hgIdx = i
                Exit For
            End If
        Next
        Return hgIdx
    End Function
    Public int_icmp As Integer = My.MySettings.Default.int_icmp
    Public int_timeOut As Integer = My.MySettings.Default.int_timeOut
    Public int_retry As Integer = My.MySettings.Default.int_retry
    Public str_centerIP As String = My.MySettings.Default.str_centerIP
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        BackgroundWorker1.CancelAsync()
    End Sub
    Sub Load_WelCome() '载入欢迎页
        Dim fullPath As String = Application.StartupPath & "/welcome.html"
        Dim WebBrowser1 As Windows.Forms.WebBrowser = CType(TabControl1.SelectedTab.Controls.Item(0), Windows.Forms.WebBrowser)
        If IO.File.Exists(fullPath) = True Then
            WebBrowser1.Navigate("file:///" & fullPath)
        Else
            WebBrowser1.Document.Write("<div style=""text-align:center; padding-top:50px;""><h1>Welcome</h1></div>")
        End If
    End Sub
    Dim trap_process As New Process
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Icon = My.Resources.app_ico
        ' MyCls.findDB()
        Call loadHostGroup()
        Call loadwebHost()
        TreeView1.SelectedNode = TreeView1.Nodes(0)
        TreeView1.Nodes(0).Expand() '默认展开 [Default] 分组
        Call Load_WelCome()
        If int_icmp = 1 Then
            'Timer1.Enabled = False
            If BackgroundWorker1.IsBusy = False Then BackgroundWorker1.RunWorkerAsync()
        Else
            'Timer1.Enabled = True
        End If
        Try
            Dim plugin_dir As String = Application.StartupPath & "\plugin\"
            With trap_process.StartInfo
                .WorkingDirectory = plugin_dir
                .FileName = "trapReceiver.exe"
                .WindowStyle = ProcessWindowStyle.Hidden
            End With
            trap_process.Start()
        Catch ex As Exception
            MessageBox.Show("trapReceiver 调用失败，请检查 plugin 目录的完整性。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.Width > 800 Then
            TabControl1.Width = Me.Width - 200
            lv_alarm.Width = Me.Width - 200
        Else
            TabControl1.Width = 600
            lv_alarm.Width = 600
        End If
        If Me.Height > 520 Then
            TabControl1.Height = Me.Height - 150
            TreeView1.Height = Me.Height - 93
        Else
            TabControl1.Height = 432
            TreeView1.Height = 427
        End If
        If Me.Height > 300 Then
            lv_alarm.Top = Me.Height - 125
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

        Dim tc As Integer = TreeView1.Nodes.Count
        If tc <= 0 Then
            menu_delHost.Enabled = False
            menu_clearHost.Enabled = False
        Else
            menu_delHost.Enabled = True
            menu_clearHost.Enabled = True
        End If
        Dim t_level As Integer = TreeView1.SelectedNode.Level
        Dim t_id As Integer = TreeView1.SelectedNode.Name
        If t_level = 0 Then
            menu_delHost.Visible = False
            menu_addHost.Visible = True
            menu_delGroup.Visible = True
            menu_modHost.Visible = False
            If t_id = 0 Then
                menu_modGroup.Visible = False
            Else
                menu_modGroup.Visible = True
            End If
            menu_outTools.Visible = False  '隐藏外部工具
            ToolStripMenuItem3.Visible = False
        Else
            menu_delHost.Visible = True
            menu_addHost.Visible = False
            menu_delGroup.Visible = False
            menu_modHost.Visible = True
            menu_modGroup.Visible = False
            menu_outTools.Visible = True '显示外部工具
            ToolStripMenuItem3.Visible = True
        End If

    End Sub

    Private Sub menu_addHost_Click(sender As Object, e As EventArgs) Handles menu_addHost.Click
        device_settings.Text = "添加设备"
        device_settings.ShowDialog()
    End Sub

    Sub gotoUrl(ByVal id As Integer, ByVal idx As Integer)
        Dim str_hostName, str_IPAddr, str_Port, str_UserName, str_Password As String
        Dim str_Url, str_GetPara, str_PostPara As String
        Dim int_HostGroup, int_Auth As Integer
        Dim tb_webhost() As DataRow
        tb_webhost = MyCls.hostDataSet.Tables("webhost").Select(" id=" & id)
        If tb_webhost.GetUpperBound(0) >= 0 Then
            str_hostName = tb_webhost(0)("hostName")
            int_HostGroup = tb_webhost(0)("HostGroup")
            str_IPAddr = tb_webhost(0)("IPAddr")
            str_IPAddr = str_IPAddr.ToLower.Replace("http://", "")
            str_Port = tb_webhost(0)("Port")
            str_UserName = tb_webhost(0)("UserName")
            str_Password = MyCls.FromBase64(tb_webhost(0)("Password"))
            int_Auth = tb_webhost(0)("Auth")
            str_Url = tb_webhost(0)("Url")
            str_GetPara = tb_webhost(0)("GetPara")
            str_PostPara = tb_webhost(0)("PostPara")
            Dim str_Nav As String = ""
            'TabControl1.SelectedTab.Text = str_hostName
            If int_Auth = 1 Then
                str_Nav = "http://" & str_UserName & ":" & str_Password & "@" & str_IPAddr & ":" & str_Port & str_Url
                Try
                    'Debug.Print(str_Nav)
                    'AccessUrl("http://" & str_IPAddr & ":" & str_Port, str_UserName, str_Password, str_IPAddr)
                    CType(TabControl1.SelectedTab.Controls.Item(0), Windows.Forms.WebBrowser).Navigate(str_Nav)
                Catch ex As System.UriFormatException
                    Return
                End Try
            Else
                str_Nav = "http://" & str_IPAddr
                If str_Port <> "" Then str_Nav = str_Nav & ":" & str_Port
                str_Nav = str_Nav & str_Url
                str_GetPara = str_GetPara.Replace("$user", str_UserName)
                str_GetPara = str_GetPara.Replace("$pwd", str_Password)
                If str_GetPara <> "" Then
                    str_Nav = str_Nav & "?" & str_GetPara
                End If

                If str_PostPara <> "" Then
                    'str_PostPara = str_PostPara.Replace("{", "")
                    'str_PostPara = str_PostPara.Replace("}", "")
                    'str_PostPara = str_PostPara.Replace(":", "=")
                    'str_PostPara = str_PostPara.Replace(",", "&")
                    str_PostPara = str_PostPara.Replace("$user", str_UserName)
                    str_PostPara = str_PostPara.Replace("$pwd", str_Password)
                    Dim postData As Byte() = UTF8Encoding.UTF8.GetBytes(str_PostPara)
                    Dim sHeaders As String = "Content-Type: application/x-www-form-urlencoded" + Chr(10) + Chr(13)
                    '   axWeb.Navigate(str_Nav, Nothing, Nothing, postData, sHeaders)
                    CType(TabControl1.SelectedTab.Controls.Item(0), Windows.Forms.WebBrowser).Navigate(str_Nav, Nothing, postData, sHeaders)
                Else
                    CType(TabControl1.SelectedTab.Controls.Item(0), Windows.Forms.WebBrowser).Navigate(str_Nav)
                End If
            End If
        End If
    End Sub
    Private Sub menu_reLoadHost_Click(sender As Object, e As EventArgs) Handles menu_reLoadHost.Click
        Call reloadhost_tree()
    End Sub
    Public Sub reloadhost_tree()
        TreeView1.Nodes.Clear()
        MyCls.hostDataSet.Tables.Remove("hostGroup")
        MyCls.hostDataSet.Tables.Remove("webHost")
        Call loadHostGroup()
        Call loadwebHost()
        TreeView1.SelectedNode = TreeView1.Nodes(0)
        TreeView1.Nodes(0).Expand() '默认展开 [Default] 分组
    End Sub


    Private Sub menu_modGroup_Click(sender As Object, e As EventArgs) Handles menu_modGroup.Click
        group_settings.ShowDialog()
    End Sub

    Private Sub menu_delHost_Click(sender As Object, e As EventArgs) Handles menu_delHost.Click
        Dim t_id As Integer = TreeView1.SelectedNode.Name
        Dim t_name As String = TreeView1.SelectedNode.Text
        Dim t_level As Integer = TreeView1.SelectedNode.Level
        If t_level = 0 Then Exit Sub
        Dim retMsg As Integer, outMsg As String
        outMsg = "你确定要删除 [" & t_name & "] 设备吗？"
        retMsg = MessageBox.Show(outMsg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If retMsg = 6 Then
            Dim tb_webhost() As DataRow
            Dim sql As String = ""
            sql = " id=" & t_id
            tb_webhost = MyCls.hostDataSet.Tables("webhost").Select(sql)
            For i = 0 To tb_webhost.GetUpperBound(0)
                tb_webhost(i).Delete()
            Next
            MyCls.hostDataSet.Tables("webhost").AcceptChanges()
            TreeView1.SelectedNode.Remove()
            sql = "delete from webHost where id=" & t_id & " ;"
            MyCls.setValue(sql)
        End If
    End Sub

    Private Sub menu_delGroup_Click(sender As Object, e As EventArgs) Handles menu_delGroup.Click
        Dim t_id As Integer = TreeView1.SelectedNode.Name
        Dim t_name As String = TreeView1.SelectedNode.Text
        Dim retMsg As Integer, outMsg As String
        If t_id = 0 Then
            outMsg = "你确定要删除 [Default] 组的所有设备吗？"
        Else
            outMsg = "你确定要删除 [" & t_name & "] 组的所有设备吗？"
        End If
        retMsg = MessageBox.Show(outMsg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If retMsg = 6 Then
            Dim t_idx As Integer = TreeView1.SelectedNode.Index
            If t_id = 0 Then    '删除Default下所有主机
                Dim tb_webhost() As DataRow
                Dim sql As String = ""
                sql = " HostGroup=0 "
                tb_webhost = MyCls.hostDataSet.Tables("webhost").Select(sql)
                For i = 0 To tb_webhost.GetUpperBound(0)
                    tb_webhost(i).Delete()
                Next
                MyCls.hostDataSet.Tables("webhost").AcceptChanges()
                'TreeView1.Nodes.Item(0).Nodes.Clear()
                sql = "delete from webHost where hostgroup=0 ;"
                MyCls.setValue(sql)
            Else
                Dim tb_webhost() As DataRow
                Dim sql As String = ""
                sql = " HostGroup=" & t_id
                tb_webhost = MyCls.hostDataSet.Tables("webhost").Select(sql)
                For i = 0 To tb_webhost.GetUpperBound(0)
                    tb_webhost(i).Delete()
                Next
                MyCls.hostDataSet.Tables("webhost").AcceptChanges()
                sql = "delete from webHost where HostGroup=" & t_id & " ;"
                sql = sql & "delete from hostGroup where id=" & t_id & " ;"
                MyCls.setValue(sql)
                'TreeView1.SelectedNode.Remove()
            End If
            Call reloadhost_tree()
        End If
    End Sub

    Private Sub menu_modHost_Click(sender As Object, e As EventArgs) Handles menu_modHost.Click
        device_settings.Text = "修改设备参数"
        device_settings.ShowDialog()
    End Sub


    Private Sub tool_addHost_Click(sender As Object, e As EventArgs) Handles tool_addHost.Click
        Dim i_lv As Integer = TreeView1.SelectedNode.Level
        If i_lv > 0 Then
            Dim i_idx As Integer = TreeView1.SelectedNode.Parent.Index
            TreeView1.SelectedNode = TreeView1.Nodes.Item(i_idx)
        End If
        device_settings.Text = "添加设备"
        device_settings.ShowDialog()
    End Sub

    Private Sub tool_systemSet_Click(sender As Object, e As EventArgs) Handles tool_systemSet.Click
        settings.ShowDialog()
        settings.Dispose()
    End Sub

    Private Sub TreeView1_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCollapse
        e.Node.ImageIndex = 0
        e.Node.SelectedImageIndex = 0
    End Sub

    Private Sub TreeView1_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterExpand
        e.Node.ImageIndex = 1
        e.Node.SelectedImageIndex = 1
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        Dim i_lv As Integer = TreeView1.SelectedNode.Level
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If i_lv > 0 Then
                Dim t_id As Integer = TreeView1.SelectedNode.Name
                If TabControl1.TabPages(t_id.ToString) IsNot Nothing Then
                    Exit Sub
                End If

                TabControl1.TabPages.Add(t_id, TreeView1.SelectedNode.Text)
                Call isShowOrHideTab()  '调用显示或隐藏欢迎选项卡

                Dim a_tab As Integer = TabControl1.TabPages.Count
                Dim idx As Integer = TabControl1.SelectedIndex
                Dim Browse As Windows.Forms.WebBrowser = New Windows.Forms.WebBrowser
                TabControl1.TabPages(t_id.ToString).Controls.Add(Browse)
                Browse.Dock = DockStyle.Fill
                Browse.ScriptErrorsSuppressed = True
                Browse.IsWebBrowserContextMenuEnabled = False
                Browse.Navigate("about:blank")
                AddHandler DirectCast(Browse.ActiveXInstance, SHDocVw.WebBrowser).NewWindow2, AddressOf NewWindow2
                AddHandler DirectCast(Browse.ActiveXInstance, SHDocVw.WebBrowser).NewWindow3, AddressOf NewWindow3


                'AddHandler Browse.DocumentCompleted, AddressOf WindowUnload
                TabControl1.SelectedIndex = a_tab - 1

                Call gotoUrl(t_id, a_tab - 1)  '打开页面
            End If
        End If
    End Sub
    Dim NavErr As Integer = 0
    Private Sub Svd_NavigateError(ByVal pDisp As Object, ByRef URL As Object, ByRef Frame As Object, ByRef StatusCode As Object, ByRef Cancel As Boolean)
        Debug.Print("error" & StatusCode.ToString)
        Debug.Print("[Open URL error：]" & URL.ToString)
        Select Case StatusCode
            Case 500
                If NavErr < 5 Then
                    NavErr = NavErr + 1
                Else
                    Debug.Print("[Loading page error：]Code：500，retry times：" & NavErr & "，clear proxy")
                End If
            Case -2146697211
        End Select
        Cancel = True
    End Sub
    Private Sub NewWindow2(ByRef ppDisp As Object, ByRef Cancel As Boolean)
        Dim xPage As TabPage = New TabPage
        xPage.Text = "Loading..."
        TabControl1.TabPages.Add(xPage)
        TabControl1.SelectedTab = xPage
        Call isShowOrHideTab()  '调用显示或隐藏欢迎选项卡

        Dim x As New Windows.Forms.WebBrowser
        x.Navigate("about:blank")
        xPage.Controls.Add(x)
        x.Dock = DockStyle.Fill
        x.Visible = True
        x.ScriptErrorsSuppressed = True
        x.IsWebBrowserContextMenuEnabled = False
        ppDisp = x.ActiveXInstance
        AddHandler x.DocumentCompleted, AddressOf DocumentComplete
        AddHandler DirectCast(x.ActiveXInstance, SHDocVw.WebBrowser).NewWindow2, AddressOf NewWindow2
        AddHandler DirectCast(x.ActiveXInstance, SHDocVw.WebBrowser).NewWindow3, AddressOf NewWindow3
        'DirectCast(x.ActiveXInstance, SHDocVw.WebBrowser).RegisterAsBrowser = True

    End Sub
    Private Sub DocumentComplete(sender As Object, e As EventArgs)
        Dim x As Windows.Forms.WebBrowser = CType(sender, Windows.Forms.WebBrowser)
        If x.ReadyState = WebBrowserReadyState.Complete Then
            Dim tab As Control = x.Parent
            If x.DocumentTitle.Trim <> "" Then tab.Text = x.DocumentTitle
        End If
    End Sub
    Private Sub NewWindow3(ByRef pDisp As Object, ByRef cancel As Boolean, ByVal flags As Integer,
                          ByVal URLContext As String, ByVal URL As String)

        MessageBox.Show(URL)
        ' clickWebB.Url = New Uri(URL)
        ' using webbrowser control to open the url
        cancel = True

    End Sub


    Private Sub menu_sysBrower_Click(sender As Object, e As EventArgs) Handles menu_sysBrower.Click
        Dim t_id As Integer = TreeView1.SelectedNode.Name
        Dim tb_webHost() As DataRow
        tb_webHost = MyCls.hostDataSet.Tables("webHost").Select("id=" & t_id)
        Dim s_Url As String = "", s_IPAddr As String = "", s_Port As String = ""
        For i = 0 To tb_webHost.GetUpperBound(0)
            s_IPAddr = tb_webHost(i)("IPAddr")
            s_Port = tb_webHost(i)("Port")
            s_Url = "http://" & s_IPAddr & ":" & s_Port
            Exit For
        Next
        If s_Url <> "" Then
            System.Diagnostics.Process.Start(s_Url)
        End If
    End Sub
    Private Sub TreeView1_MouseDown(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseDown
        Dim node As TreeNode = TreeView1.GetNodeAt(e.X, e.Y)
        TreeView1.ContextMenuStrip = Nothing
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If node Is Nothing Then
                TreeView1.ContextMenuStrip = Nothing
                Return
            Else
                TreeView1.SelectedNode = node
                TreeView1.ContextMenuStrip = ContextMenuStrip1
            End If
        End If
    End Sub

    Private Sub menu_ping_Click(sender As Object, e As EventArgs) Handles menu_ping.Click
        Dim t_id As Integer = TreeView1.SelectedNode.Name
        Dim tb_webHost() As DataRow
        tb_webHost = MyCls.hostDataSet.Tables("webHost").Select("id=" & t_id)
        Dim s_IPAddr As String = ""
        For i = 0 To tb_webHost.GetUpperBound(0)
            s_IPAddr = tb_webHost(i)("IPAddr")
            Exit For
        Next
        If s_IPAddr <> "" Then
            Try
                System.Diagnostics.Process.Start("ping", s_IPAddr)
            Catch ex As Exception
                MyCls.WriteLog("Ping 调用失败，请检查系统文件。")
                MessageBox.Show("Ping 调用失败，请检查系统文件。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub menu_telnet_Click(sender As Object, e As EventArgs) Handles menu_telnet.Click
        Dim t_id As Integer = TreeView1.SelectedNode.Name
        Dim tb_webHost() As DataRow
        tb_webHost = MyCls.hostDataSet.Tables("webHost").Select("id=" & t_id)
        Dim s_IPAddr As String = ""
        For i = 0 To tb_webHost.GetUpperBound(0)
            s_IPAddr = tb_webHost(i)("IPAddr")
            Exit For
        Next
        If s_IPAddr <> "" Then
            Try
                System.Diagnostics.Process.Start("telnet", s_IPAddr)
            Catch ex As Exception
                MyCls.WriteLog("Telnet 调用失败，请检查目录的完整性。")
                MessageBox.Show("Telnet 调用失败，请检查目录的完整性。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If int_icmp = 0 Then
            BackgroundWorker1.CancelAsync()
        End If
        Dim poller_process As New Process
        Try
            Dim plugin_dir As String = Application.StartupPath & "\plugin\"
            With poller_process.StartInfo
                .WorkingDirectory = plugin_dir
                .Arguments = " -r " & int_retry & " -t 3 -f ./trap-pdu.json " & str_centerIP
                .FileName = plugin_dir & "poller.exe "
                .WindowStyle = ProcessWindowStyle.Hidden
                .RedirectStandardOutput = True
                .UseShellExecute = False
                .CreateNoWindow = True
            End With
            poller_process.Start()
            Dim reader As IO.StreamReader = poller_process.StandardOutput
            Dim line As String = reader.ReadLine()

            If line <> "" Then
                Dim Thread1 As New System.Threading.Thread(AddressOf ret_list_host)
                Thread1.Start(line)
            End If
            poller_process.WaitForExit()
            poller_process.Close()
        Catch ex As Exception
            MyCls.WriteLog("poller 调用失败，请检查 plugin 目录的完整性。")
            MessageBox.Show("poller 调用失败，请检查 plugin 目录的完整性。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If int_timeOut > 0 Then Threading.Thread.Sleep(int_timeOut * 1000) '调延时时间
        'Call update_icon()
    End Sub
    Sub ret_list_host(ByVal hostls As String)
        Dim tmpdr() As DataRow
        tmpdr = MyCls.hostDataSet.Tables("webHost").Select("isicmp=1")
        Dim arr_host = hostls.Split(" ")
        Dim vid, hostgroup, hostname, ipaddr, Sql As String
        Sql = ""
        For i = 0 To tmpdr.GetUpperBound(0)
            With tmpdr(i)
                vid = .Item("id")
                hostname = .Item("hostname")
                hostgroup = .Item("hostgroup")
                ipaddr = .Item("ipaddr")
            End With
            setTreeIcon(vid, hostgroup, 1)
            For j = 0 To arr_host.GetUpperBound(0)
                If arr_host(j) = ipaddr Then
                    setTreeIcon(vid, hostgroup, 0)
                    'Sql += "insert into polling_logs(hostid,logtxt)values(" & vid & ",'" & MyCls.get_hostGroup_name(hostgroup) & " 分组的 " & hostname & " PING检测无应答');"
                    Sql += "insert into polling_logs(hostid,logtxt)values(" & vid & ",'The " & hostname & " device in " & MyCls.get_hostGroup_name(hostgroup) & " group ping no response.');"
                    Exit For
                End If
            Next
        Next
        If Sql <> "" Then
            MyCls.setValue_batch(Sql.Split(";"))
        End If

    End Sub
    Delegate Sub setTreeIconCallback(id As String, g_id As String, i_type As Integer)
    Sub setTreeIcon(ByVal id As String, ByVal g_id As String, ByVal i_type As Integer)
        If Me.TreeView1.InvokeRequired Then
            Dim d As New setTreeIconCallback(AddressOf setTreeIcon)
            Me.Invoke(d, New Object() {id, g_id, i_type})
        Else
            If i_type = 1 Then  '绿
                Me.TreeView1.Nodes(g_id).Nodes(id).ImageIndex = 3
                Me.TreeView1.Nodes(g_id).Nodes(id).SelectedImageIndex = 3
            Else    '红
                Me.TreeView1.Nodes(g_id).Nodes(id).ImageIndex = 4
                Me.TreeView1.Nodes(g_id).Nodes(id).SelectedImageIndex = 4
            End If
        End If
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If int_icmp = 1 Then
            BackgroundWorker1.RunWorkerAsync()
        Else
            BackgroundWorker1.CancelAsync()
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            menu_reLoadHost_Click(sender, e)
        End If
    End Sub

    Private Sub Form1_KeyDown2(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            cmb_seo.Focus()
        End If
    End Sub

    Private Sub TabControl1_DoubleClick(sender As Object, e As EventArgs) Handles TabControl1.DoubleClick

        Dim t_key As String = TabControl1.SelectedTab.Name
        If t_key <> "TabPage1" Then
            Dim idx As Integer = TabControl1.SelectedIndex
            Dim web As Windows.Forms.WebBrowser = CType(TabControl1.SelectedTab.Controls.Item(0), Windows.Forms.WebBrowser)
            Dim ret As Integer = 0
            If web.Document Is Nothing Then
                ret = 6
            Else
                ret = MessageBox.Show("你确定要关闭这个选项卡吗？", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If
            If ret = 6 Then
                Dim a_idx As Integer = TabControl1.TabPages.Count - 1
                If a_idx = idx Then
                    TabControl1.SelectedIndex = idx - 1
                Else
                    TabControl1.SelectedIndex = idx + 1
                End If
                TabControl1.TabPages.RemoveAt(idx)
                Call isShowOrHideTab()  '调用显示或隐藏欢迎选项卡
            End If
        End If

    End Sub

    Private Sub TabControl1_MouseDown(sender As Object, e As MouseEventArgs) Handles TabControl1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Middle Then
            Dim p As Point = e.Location
            For i = 0 To TabControl1.TabPages.Count - 1
                If TabControl1.GetTabRect(i).Contains(p) Then
                    Dim t_key As String = TabControl1.TabPages.Item(i).Name
                    If t_key <> "TabPage1" Then
                        TabControl1.TabPages.RemoveAt(i)
                        Call isShowOrHideTab()  '调用显示或隐藏欢迎选项卡
                    End If
                    Exit For
                End If
            Next
        End If
    End Sub
    Sub isShowOrHideTab()
        Dim t_count As Integer = TabControl1.TabPages.Count

        If t_count > 0 Then
            TabControl1.TabPages.RemoveByKey("TabPage1")
        Else
            TabControl1.TabPages.Add("TabPage1", "Welcome")
            Dim WebBrowser1 As Windows.Forms.WebBrowser = New Windows.Forms.WebBrowser
            TabControl1.TabPages("TabPage1").Controls.Add(WebBrowser1)
            WebBrowser1.Dock = DockStyle.Fill
            WebBrowser1.ScriptErrorsSuppressed = True
            WebBrowser1.IsWebBrowserContextMenuEnabled = False
            WebBrowser1.Navigate("about:blank")
            Call Load_WelCome()
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Hide()
        BackgroundWorker1.CancelAsync()
        If trap_process.HasExited = False Then
            trap_process.Kill()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        update_icon()
    End Sub

    Delegate Sub set_lvalarmCallback(istype As Integer, items As ListViewItem)
    Sub set_lvalarm(ByVal istype As Integer, ByVal items As ListViewItem)
        If Me.lv_alarm.InvokeRequired Then
            Dim d As New set_lvalarmCallback(AddressOf set_lvalarm)
            Me.Invoke(d, New Object() {istype, items})
        Else
            If istype = 0 Then
                If Me.lv_alarm.Items.Count > 0 Then Me.lv_alarm.Items.Clear()
            Else
                Me.lv_alarm.Items.Add(items)
            End If
        End If
    End Sub
    Delegate Sub set_alarm_tipCallback(num As Integer)
    Sub set_alarm_tip(ByVal num As Integer)
        If Me.ToolStrip1.InvokeRequired Then
            Dim d As New set_alarm_tipCallback(AddressOf set_alarm_tip)
            Me.Invoke(d, New Object() {num})
        Else
            Me.tool_alarm_tip.Text = num
        End If
    End Sub
    Sub update_icon()
        Dim sql As String = "select count(id)num from trap_messages where confirmed=0 and level>0;select id,create_at,ipaddr,hostname,case when level=0 then '信息' when level=1 then '警告' when level=2 then '严重' end aslevel,message from trap_messages where confirmed=0 and level>0 order by create_at desc,id desc limit 20;"
        Dim tmpDs As DataSet = MyCls.FillDataset("tmptb", sql)
        If tmpDs Is Nothing Then Return
        If tmpDs.Tables(0) IsNot Nothing Then
            Dim num As Integer = 0
            num = tmpDs.Tables(0).Rows(0)("num")
            set_alarm_tip(num)
        End If

        set_lvalarm(0, Nothing)
        Dim vid, ipaddr, hostname, aslevel, message, create_at As String
        For i = 0 To tmpDs.Tables(1).Rows.Count - 1
            With tmpDs.Tables(1).Rows(i)
                vid = .Item("id")
                create_at = .Item("create_at")
                ipaddr = .Item("ipaddr")
                hostname = .Item("hostname")
                aslevel = .Item("aslevel")
                message = .Item("message")
            End With
            Dim items As New ListViewItem({vid, create_at, ipaddr, hostname, aslevel, message})
            set_lvalarm(1, items)
        Next
    End Sub

    Private Sub tool_hostlog_Click(sender As Object, e As EventArgs) Handles tool_hostlog.Click
        polling_logs.ShowDialog()
    End Sub

    Private Sub cmb_seo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_seo.SelectedIndexChanged
        If cmb_seo.Items.Count > 0 Then
            Dim vid As Integer, hostname As String, HostGroup As Integer
            vid = CType(cmb_seo.SelectedItem, item).id
            hostname = CType(cmb_seo.SelectedItem, item).text
            MyCls.load_webHostp()
            Dim tmpDr() As DataRow = MyCls.hostDataSet.Tables("webHost").Select("id=" & vid)
            If tmpDr.Length > 0 Then
                HostGroup = tmpDr(0)("HostGroup")
            End If
            TreeView1.SelectedNode = TreeView1.Nodes.Item(HostGroup.ToString)
            TreeView1.SelectedNode.Expand()
            TreeView1.SelectedNode = TreeView1.Nodes.Item(HostGroup.ToString).Nodes.Item(vid.ToString)
            TreeView1.Focus()
        End If
    End Sub
    Private Sub cmb_seo_KeyUp(sender As Object, e As KeyEventArgs) Handles cmb_seo.KeyUp
        cmb_seo.DroppedDown = False
        If e.KeyCode = 13 Then
            Dim kw As String = Trim(cmb_seo.Text)
            If kw <> "" Then
                MyCls.load_webHostp()
                Dim tmpDr() As DataRow = MyCls.hostDataSet.Tables("webHost").Select("hostName like '%" & kw & "%'")
                cmb_seo.Items.Clear()
                For i = 0 To tmpDr.GetUpperBound(0)
                    Dim vid As Integer, hostname As String
                    With tmpDr(i)
                        vid = .Item("id")
                        hostname = .Item("hostname")
                    End With
                    cmb_seo.Items.Add(New item(vid, hostname))
                Next
                cmb_seo.SelectionStart = cmb_seo.Text.Length
                cmb_seo.DroppedDown = True
                Me.Cursor = Cursors.Default
            Else
                cmb_seo.DroppedDown = False
                cmb_seo.Items.Clear()
            End If
        End If
    End Sub

    Private Sub tool_alarm_Click(sender As Object, e As EventArgs) Handles tool_alarm.Click
        trap_messages.ShowDialog()
    End Sub
End Class
