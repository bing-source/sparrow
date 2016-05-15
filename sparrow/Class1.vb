Imports System.Data
Imports System.Data.Common
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Configuration
Public Class MyCls
    Shared dataConn As String = ConfigurationManager.ConnectionStrings("MySqlConn").ToString
    Shared Sub load_accounts()
        Dim tabname = "", sql As String = ""
        tabname = "accounts"
        sql = "select id,username,password from accounts order by id desc limit 1;"
        loadHostDataSet(tabname, sql)
    End Sub
    Shared Sub load_hostGroup()
        Dim tabname = "", sql As String = ""
        tabname = "hostGroup"
        sql = "select id,groupName,sort from hostGroup order by sort asc"
        loadHostDataSet(tabname, sql)
    End Sub
    Shared Sub load_webHostp()
        Dim tabname = "", sql As String = ""
        tabname = "webHost"
        sql = "select id,hostName,HostGroup,IPAddr,Port,UserName,Password,Auth,Url,GetPara,PostPara,isicmp,0 pingcount from webHost order by HostGroup asc,create_at asc"
        loadHostDataSet(tabname, sql)
    End Sub
    Public Shared Function get_hostGroup_name(ByVal vid As String) As String
        Dim ret As String = "Default"
        Dim tmpdr() As DataRow
        tmpdr = hostDataSet.Tables("hostGroup").Select("id=" & vid)
        If tmpdr.Length >= 1 Then
            ret = tmpdr(0)("groupName")
        End If
        Return ret
    End Function
    Public Shared Function isUserPass() As Integer
        Dim ret As Integer = 0
        Dim tb_admin As DataTable = MyCls.hostDataSet.Tables("accounts")
        If tb_admin Is Nothing Then
            ret = 0 '无表
        Else
            If tb_admin.Rows.Count > 0 Then
                ret = 1 '有数据
            Else
                ret = 2 '无数据
            End If
        End If
        Return ret
    End Function
    Public Shared Function getValue(ByVal sSql As String) As MySqlDataReader
        If sSql.Trim = "" Then
            Return Nothing
        End If
        Try
            Dim tmpGetValue As MySqlDataReader
            Dim myconn As New MySqlConnection(dataConn)
            If myconn.State <> ConnectionState.Open Then myconn.Open()
            ' Dim trans As MySqlTransaction = myconn.BeginTransaction
            Dim myCommand As MySqlCommand = New MySqlCommand
            myCommand.Connection = myconn
            myCommand.CommandType = CommandType.Text
            'myCommand.Transaction = trans
            myCommand.CommandText = sSql
            tmpGetValue = myCommand.ExecuteReader(CommandBehavior.CloseConnection)
            ' trans.Commit()
            myCommand.Dispose()
            Return tmpGetValue
        Catch ex As Exception
            WriteLog(ex.Message & "[Loading ...]" & ex.ToString & "[SQL statements：]" & sSql)
            Return Nothing
        End Try
    End Function
    Public Shared Function setValue(ByVal sSql As String) As Integer
        If sSql.Trim = "" Then
            Return Nothing
        End If
        Try
            MySqlConnection.ClearAllPools()
            Dim tmpSetValue As Integer
            Using myconn As New MySqlConnection(dataConn)
                If myconn.State <> ConnectionState.Open Then myconn.Open()
                Dim trans As MySqlTransaction = myconn.BeginTransaction
                Dim myCommand As MySqlCommand = New MySqlCommand
                myCommand.Connection = myconn
                myCommand.CommandType = CommandType.Text
                myCommand.Transaction = trans
                myCommand.CommandText = sSql
                If sSql.IndexOf("insert") <> -1 Then
                    tmpSetValue = Convert.ToInt32(myCommand.ExecuteScalar())
                Else
                    tmpSetValue = myCommand.ExecuteNonQuery()
                End If
                trans.Commit()
                myCommand.Dispose()
                Return tmpSetValue
            End Using
        Catch ex As Exception
            WriteLog(ex.Message & "[Write data]" & ex.ToString & "[SQL语句：]" & sSql)
            Return Nothing
        End Try
    End Function
    Public Shared Function setValue_batch(ByVal sSql() As String)
        Dim tmpret As String = 0
        If sSql.Length = 0 Then Return tmpret
        Using myconn As New MySqlConnection(dataConn)
            If myconn.State <> ConnectionState.Open Then myconn.Open()
            Dim trans As MySqlTransaction = myconn.BeginTransaction
            Dim cmd As MySqlCommand = New MySqlCommand
            cmd.Connection = myconn
            cmd.CommandType = CommandType.Text
            cmd.Transaction = trans
            Try
                For i = 0 To sSql.Length - 1
                    If sSql(i) <> "" Then
                        cmd.CommandText = sSql(i)
                        tmpret += "," & cmd.ExecuteNonQuery()
                    End If
                Next
                trans.Commit()
            Catch ex As Exception
                trans.Rollback()
                WriteLog("Batch apply error：" & ex.Message & " SQL statements：" & Join(sSql, ";"))
            Finally
                cmd.Dispose()
            End Try
        End Using
        Return tmpret
    End Function
    Public Shared Sub write_polling_logs(ByVal hostid As Integer, ByVal logtxt As String)
        Dim sql As String = "insert into polling_logs(hostid,logtxt)values(" & hostid & ",'" & logtxt & "');"
        MyCls.setValue(sql)
    End Sub
    Public Shared Function ToBase64(ByVal str As String) As String
        Dim data As Byte() = Encoding.UTF8.GetBytes(str)
        If data Is Nothing Then Throw New ArgumentNullException("data")
        Return Convert.ToBase64String(data)
    End Function
   
    Public Shared Function FromBase64(ByVal base64 As String) As String
        Dim binaryData() As Byte
        If base64 Is Nothing Then Throw New ArgumentNullException("base64")
        binaryData = Convert.FromBase64String(base64)
        Return Encoding.UTF8.GetString(binaryData)
    End Function
    Public Shared Function md5(ByVal sMessage As String, Optional ByVal stype As Int16 = 16) As String
        Dim utf8 As Encoding = Encoding.UTF8
        Dim tmpMd5 As String = ""
        'Dim gb2312 As Encoding = Encoding.GetEncoding("gb2312")

        Dim tempMsg As New System.Security.Cryptography.MD5CryptoServiceProvider
        tmpMd5 = BitConverter.ToString(tempMsg.ComputeHash(utf8.GetBytes(sMessage))).Replace("-", "").ToLower

        If stype = 16 Then  '选择16位字符的加密结果
            tmpMd5 = Mid(tmpMd5, 9, 16)
        End If

        Return tmpMd5
    End Function


    Public Shared Function checkUser(ByVal str_user As String, ByVal str_pass As String) As Boolean
        Dim ret As Boolean = False
        Dim tb_admin As DataTable = MyCls.hostDataSet.Tables("accounts")
        If tb_admin Is Nothing Then
            Call load_accounts()
            tb_admin = MyCls.hostDataSet.Tables("accounts")
        End If
        If tb_admin.Rows.Count > 0 Then
            Dim tb_username, tb_password As String
            With MyCls.hostDataSet.Tables("accounts").Rows(0)
                tb_username = .Item("username")
                tb_password = .Item("password")
            End With
            If tb_username = str_user And tb_password = md5(str_pass) Then
                ret = True  '有数据
            End If
        End If
        Return ret
    End Function
    Public Shared hostDataSet As New DataSet
    Shared Sub clearHostDataSet(ByVal tabname As String)
        If hostDataSet.Tables(tabname) IsNot Nothing Then
            hostDataSet.Tables.Remove(tabname)
        End If
    End Sub
    Shared Sub loadHostDataSet(ByVal tabname As String, Sql As String)
        If hostDataSet Is Nothing Then   '无表数据，写数据
            newWriteDataset(tabname, Sql)
        Else
            If hostDataSet.Tables(tabname) Is Nothing Then
                newWriteDataset(tabname, Sql)
            End If
        End If
    End Sub
    Shared Sub newWriteDataset(ByVal tabname As String, sSql As String)
        If hostDataSet.Tables(tabname) IsNot Nothing Then
            hostDataSet.Tables.Remove(tabname)
        End If
        Dim tmpds As New DataSet
        tmpds = MyCls.FillDataset(tabname, sSql)
        If tmpds IsNot Nothing Then
            hostDataSet.Merge(tmpds)
            tmpds.Dispose()
        Else
            Debug.Print("system error， Please contact administrator")
        End If
    End Sub
    Public Shared Function FillDataset(ByVal tabName As String, ByVal sSql As String) As DataSet
        Try
            MySqlConnection.ClearAllPools()
            Using myconn As New MySqlConnection(dataConn)
                If myconn.State <> ConnectionState.Open Then myconn.Open()
                Dim tmpSDA As MySqlDataAdapter = New MySqlDataAdapter(sSql, myconn)
                Dim ds As New DataSet
                tmpSDA.Fill(ds, tabName)
                tmpSDA.Dispose()
                Return ds
            End Using
        Catch ex As MySqlException
            If ex.ErrorCode = "-2147467259" Then
                MessageBox.Show("连接 Mysql 数据库失败了，请联系管理员。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            Else
                WriteLog(ex.Message & "[Fill DateSet]" & ex.ToString & "[SQL statements：]" & sSql)
            End If
            Return Nothing
        End Try
    End Function
    Public Shared Function UpdataDataTab(ByVal sSql As String, ByVal DataTab As DataTable) As String
        Try
            MySqlConnection.ClearAllPools()
            Using myconn As New MySqlConnection(dataConn)
                If myconn.State <> ConnectionState.Open Then myconn.Open()
                Dim tmpSDA As MySqlDataAdapter = New MySqlDataAdapter(sSql, myconn)
                tmpSDA.SelectCommand = New MySqlCommand(sSql, myconn)
                Dim builder As MySqlCommandBuilder = New MySqlCommandBuilder(tmpSDA)
                builder.ConflictOption = ConflictOption.OverwriteChanges
                Dim ret As String = ""
                ret = tmpSDA.Update(DataTab)
                Return ret
            End Using
        Catch ex As Exception
            Return "Update table error:" & ex.Message
            WriteLog(ex.Message & "[Update tabel error]" & ex.ToString & "[SQL statements：]" & sSql)
        End Try
    End Function
    Shared Sub update_hostDataSet(ByVal tabname As String, ByVal strWhere As String, ByVal uptype As Byte, Optional ByVal upkey() As String = Nothing, Optional ByVal upvalue() As String = Nothing)
        '更新缓存
        'tabname  表名
        'strWhere 查询条件 规则：id=1 or username='test'
        'uptype 更新类型，0 更新/添加，1删除
        'upkey 更新字段，数组存放，规则：{"title","pid"}
        'upvalue 更新数据，数组存放，规则：{test,1}
        If Trim(tabname) = "" Then Return
        If hostDataSet.Tables(tabname) IsNot Nothing Then
            Select Case uptype
                Case 0  '更新/添加
                    Dim tmpDr() As DataRow
                    tmpDr = hostDataSet.Tables(tabname).Select(strWhere)
                    If tmpDr.Length = 0 Then    '不存在，添加记录
                        Dim newrow As DataRow = hostDataSet.Tables(tabname).NewRow
                        With newrow
                            For i = 0 To upkey.GetUpperBound(0)
                                .Item(upkey(i)) = upvalue(i)
                            Next
                        End With
                        hostDataSet.Tables(tabname).Rows.Add(newrow)
                    Else    '存在，更新记录
                        For Each rows In tmpDr
                            With rows
                                For i = 0 To upkey.GetUpperBound(0)
                                    .Item(upkey(i)) = upvalue(i)
                                Next
                            End With
                        Next
                    End If
                Case 1  '删除
                    Dim tmpDr() As DataRow = hostDataSet.Tables(tabname).Select(strWhere)
                    For Each rows In tmpDr
                        rows.Delete()
                    Next
            End Select
            hostDataSet.Tables(tabname).AcceptChanges()
        End If
    End Sub
    '写文件日志
    Public Shared Sub WriteLog(ByVal Msg As String)
        Dim varAppPath As String
        varAppPath = Application.StartupPath & "\log"
        System.IO.Directory.CreateDirectory(varAppPath)

        Dim head As String
        head = Now.ToString("HH:mm:ss:ffff")
        Msg = head & System.Environment.NewLine & Msg & System.Environment.NewLine

        Dim strDate As String
        strDate = Now.ToString("yyyyMMdd")
        Dim strFile As String
        strFile = varAppPath & "\" & strDate & ".log"
        Dim SW As StreamWriter
        SW = New StreamWriter(strFile, True)

        SW.WriteLine(Msg)
        SW.Flush()
        SW.Close()
        SW.Dispose()
    End Sub
    Public Shared Sub DataGridViewToExcel(ByVal dgv As DataGridView)
        Dim dlg As SaveFileDialog = New SaveFileDialog
        dlg.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xls)|*.xls|All files (*.*)|*.*"
        dlg.FilterIndex = 0
        dlg.RestoreDirectory = True
        dlg.CreatePrompt = True
        dlg.Title = "Save as CSV file..."
        If (dlg.ShowDialog = DialogResult.OK) Then
            Dim filepath As String = dlg.FileName
            Dim sw As StreamWriter
            Try
                sw = New StreamWriter(filepath, True, System.Text.Encoding.Unicode)
            Catch ex As Exception
                WriteLog(ex.Message)
                MessageBox.Show(ex.Message, "ERROR！", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            Dim columnTitle As String = ""
            Try
                Dim i As Integer = 0
                Do While (i < dgv.ColumnCount)
                    If (i > 0) Then
                        columnTitle = (columnTitle + "" & vbTab)
                    End If
                    columnTitle = (columnTitle + dgv.Columns(i).HeaderText)
                    i = (i + 1)
                Loop
                sw.WriteLine(columnTitle)
                Dim j As Integer = 0
                Do While (j < dgv.Rows.Count)
                    Dim columnValue As String = ""
                    Dim k As Integer = 0
                    Do While (k < dgv.Columns.Count)
                        If (k > 0) Then
                            columnValue = (columnValue & "" & vbTab)
                        End If
                        If (dgv.Rows(j).Cells(k).Value Is Nothing) Then
                            columnValue = (columnValue & "")
                        Else
                            columnValue = (columnValue & Trim(dgv.Rows(j).Cells(k).Value.ToString))
                        End If
                        k = (k + 1)
                    Loop
                    sw.WriteLine(columnValue)
                    j = (j + 1)
                Loop
                sw.Close()
            Catch e As Exception
                WriteLog(e.Message)
            Finally
                sw.Close()
                MessageBox.Show(Path.GetFileName(dlg.FileName) & " Save file success", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub
    Shared Function isIP(ByVal s As String) As Boolean
        Dim rets As Boolean = False
        If RegularExpressions.Regex.IsMatch(s, "^(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)$") = True Then
            rets = True
        End If
        Return rets
    End Function
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Struct_INTERNET_PROXY_INFO
        Public dwAccessType As Integer
        Public proxy As IntPtr
        Public proxyBypass As IntPtr
    End Structure
    <DllImport("wininet.dll ", SetLastError:=True)> _
    Private Shared Function InternetSetOption( _
             ByVal hInternet As IntPtr, _
             ByVal dwOption As Integer, _
             ByVal lpBuffer As IntPtr, _
             ByVal lpdwBufferLength As Integer) _
             As Boolean
    End Function
    Public Shared Function RefreshIESettings(ByVal strProxy As String) As Boolean
        Dim INTERNET_OPTION_PROXY As Integer = 38
        Dim INTERNET_OPEN_TYPE_PROXY As Integer = 3
        Dim INTERNET_OPEN_TYPE_DIRECT As Integer = 1

        Dim struct_IPI As Struct_INTERNET_PROXY_INFO

        'Filling   in   structure
        If strProxy.Trim = "" Or strProxy Is Nothing Then
            strProxy = ""
            struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_DIRECT
        Else
            struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY
        End If

        struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy)
        struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local ")

        'Allocating   memory   
        Dim intptrStruct As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI))

        'Converting   structure   to   IntPtr   
        Marshal.StructureToPtr(struct_IPI, intptrStruct, True)

        Return InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, Marshal.SizeOf(struct_IPI))
    End Function

End Class
Public Class item
    Public text As String
    Public id As Integer
    ' Methods
    Public Sub New(ByVal i As Integer, ByVal t As String)
        id = i
        text = t
    End Sub

    Public Overrides Function ToString() As String
        Return text
    End Function

End Class

