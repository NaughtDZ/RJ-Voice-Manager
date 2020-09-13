Imports System.ComponentModel
Imports System.IO
Imports RegExp = System.Text.RegularExpressions

Public Class Form1
    Public Conn As OleDb.OleDbConnection = New OleDb.OleDbConnection '添加一个新的数据库连接器
    Public pgpath As String '数据库路径，全局
    Private Sub Dbconect()
        pgpath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Chr(34) & Application.StartupPath & "\detailsDB.mdb" & Chr(34)
        'MsgBox(pgpath) 'debug 数据库路径
        '数据库就一张表 ASMRmanager
        Conn.ConnectionString = pgpath
        Try
            Conn.Open()
        Catch ex As Exception
            MsgBox("数据库连接失败！")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FolderDialog As New FolderBrowserDialog '文件夹选择对话框
        FolderDialog.ShowDialog()
        If FolderDialog.SelectedPath = "" Then Exit Sub
        Dim GAF_thread As Threading.Thread = New Threading.Thread(AddressOf GetAllFiles)
        GAF_thread.Start(FolderDialog.SelectedPath)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("请保证音声打包在压缩文件包或者放在RJ目录里" & vbCrLf & "请保证压缩包或文件夹含有RJ号且不在分区根目录" & vbCrLf & "批量请用批量按钮，通过树形管理获得的音声，如数据库没有，请手动点击添加按钮", , "注意事项")
    End Sub

    Private Sub GetAllFiles(ByVal strDirect As String)  '搜索所有目录下的文件
        ListBox2.CheckForIllegalCrossThreadCalls = False
        If Not (strDirect Is Nothing) Then
            Dim mFileInfo As IO.FileInfo '文件与文件夹的IO定义
            Dim mDir As IO.DirectoryInfo
            Dim mDirInfo As New IO.DirectoryInfo(strDirect)
            Dim rjReg As RegExp.Regex = New RegExp.Regex(pattern:="Rj[\d]+", options:=RegExp.RegexOptions.IgnoreCase) 'Rj号正则表达式，可提取xxRj00000xx,xx rj000 xx,等无视RJ号前后空格和rj大小写，而且，不会有人文件名为xxxRJ0000+其他数字吧
            Dim RJName As String
            Try
                For Each mFileInfo In mDirInfo.GetFiles '获取文件路径
                    If rjReg.IsMatch(input:=mFileInfo.Name) = True Then
                        RJName = UCase(rjReg.Match(input:=mFileInfo.Name).Value) 'dl上的RJ网页链接里的RJ都是大写的
                        If Duplicatedetect(RJName, "Rj") = False Then
                            Dbinsert("Rj,Shengyou,Fanshou,Shetuan,Fengmian,Bendimulu,Mingzi", "'" & RJName & "','','','','','" & mFileInfo.FullName & "',''")
                        End If
                    End If
                Next
                For Each mDir In mDirInfo.GetDirectories '获取文件夹路径
                    If rjReg.IsMatch(input:=mDir.Name) = True Then
                        RJName = UCase(rjReg.Match(input:=mDir.Name).Value)
                        If Duplicatedetect(RJName, "Rj") = False Then
                            Dbinsert("Rj,Shengyou,Fanshou,Shetuan,Fengmian,Bendimulu,Mingzi", "'" & RJName & "','','','','','" & mDir.FullName & "',''")
                        End If
                    End If
                Next
            Finally
            End Try
        End If
    End Sub

    Private Function Duplicatedetect(ByVal predetect As String, ziduan As String) As Boolean '判断库里是否有了
        Dim cmdline As New OleDb.OleDbCommand '初始化数据库命令行
        Dim dbreader As OleDb.OleDbDataReader '建立一个数据库读取器
        cmdline.Connection = Conn '指定命令行到对应数据库
        Dim commend As String = "select " & ziduan & " From ASMRmanager Where Rj = '" & predetect & "'"
        cmdline.CommandText = commend '给命令行输入命令
        dbreader = cmdline.ExecuteReader() '读取器让命令行工作
        dbreader.ReadAsync() '读取器读,读取器为数组！
        Try
            If dbreader(0) IsNot "" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dbconect()
        TreeView2.Size = New Size(166, 448)
        Proxyconfig.Close()
    End Sub
    Private Sub Dbinsert(ziduan As String, neirong As String) '数据库插入内容,需要单引号
        Try
            Dim commend As String   '数据库命令内容
            commend = "insert into ASMRmanager (" & ziduan & ") Values (" & neirong & ")" '添加内容
            Dim cmdline As New OleDb.OleDbCommand(commend, Conn) '初始化数据库命令行
            cmdline.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox("添加失败")
        End Try
    End Sub
    Public readlist As OleDb.OleDbDataReader, readCount As OleDb.OleDbDataReader
    Private Sub Dbreader(ziduan As String, mubiao As String) '建立一个数据库读取器,目标例如：Rj = 'Rj0001'，需要单引号
        Dim cmdline As New OleDb.OleDbCommand '初始化数据库命令行
        Try
            cmdline.Connection = Conn '指定命令行到对应数据库
            If mubiao = "*" Then
                cmdline.CommandText = "select " & ziduan & " From ASMRmanager"
                readlist = cmdline.ExecuteReader() '读取器让命令行工作
            Else
                cmdline.CommandText = "select " & ziduan & " From ASMRmanager Where " & mubiao  '给命令行输入命令
                readlist = cmdline.ExecuteReader()
            End If
        Catch ex As Exception
            MsgBox("读取失败")
        End Try
    End Sub
    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Conn.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text Is Nothing Then Exit Sub
        Rjdetaildel()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox1.CheckForIllegalCrossThreadCalls = False
        Dim selectNoDot As String        '去扩展名
        Dim rjReg As RegExp.Regex = New RegExp.Regex(pattern:="Rj[\d]+", options:=RegExp.RegexOptions.IgnoreCase)
        selectNoDot = UCase(rjReg.Match(ListBox1.SelectedItem.ToString).Value) '从listbox1里获得纯RJ号,是RJ ,必须大写!!!!!!
        Try
            If Duplicatedetect(selectNoDot, "Rj") = True Then
                Rjdetailread(selectNoDot)
                If CheckBox1.Checked = True Then ButtonDL_Click(Nothing, Nothing)
            Else
                TextBox1.Text = selectNoDot
                'MsgBox(TreeView1.SelectedNode.Name & "\" & ListBox1.SelectedItem.ToString)
                TextBox6.Text = TreeView1.SelectedNode.Name & "\" & ListBox1.SelectedItem.ToString
                PictureBox1.ImageLocation = ""
                TextBoxName.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
            End If
        Catch ex As Exception
            MsgBox("别点那么快啊")
        End Try
    End Sub
    Private Sub Rjdetailread(rjchose As String) '读listbox1或2选中的RJ
        '----请检查你输入的是不是RJxxxx，按道理说我listbox1和2里select中调用这个方法之前已经转换了，如有BUG，请上报
        TextBox1.Text = rjchose
        Dbreader("Shengyou,Fanshou,Shetuan,Fengmian,Bendimulu,Mingzi", "Rj='" & rjchose & "'")
        readlist.ReadAsync()
        TextBox2.Text = readlist(0).ToString
        TextBox3.Text = readlist(1).ToString
        TextBox4.Text = readlist(2).ToString
        TextBox5.Text = readlist(3).ToString
        TextBox6.Text = readlist(4).ToString
        TextBoxName.Text = readlist(5).ToString
        PictureBox1.ImageLocation = TextBox5.Text
        Button5.Enabled = True : Button6.Enabled = True
    End Sub
    Private Sub Rjdetailwrit(commend As String, mubiaorj As String) '手动更新数据按钮
        If TextBox1.Text Is Nothing Then Exit Sub '一切为了安全,总有憨憨会乱点东西
        If Duplicatedetect(TextBox1.Text, "Rj") = True Then
            Dim cmdline As New OleDb.OleDbCommand
            Try
                cmdline.Connection = Conn
                cmdline.CommandText = "Update ASMRmanager Set " & commend & " Where Rj=" & "'" & mubiaorj & "'"
                cmdline.ExecuteNonQueryAsync()
            Catch ex As Exception
                MsgBox("更新失败")
            End Try
        Else
            Dbinsert("Rj,Shengyou, Fanshou, Shetuan, Fengmian, Bendimulu,Mingzi", "'" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBoxName.Text & "'")
        End If
    End Sub
    Private Sub Rjdetaildel() '手动删除选择的音声数据
        If TextBox1.Text Is Nothing Then Exit Sub
        Dim comline As New OleDb.OleDbCommand
        comline.Connection = Conn
        Try
            comline.CommandText = "DELETE FROM ASMRmanager WHERE Rj='" & TextBox1.Text & "'"
            comline.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox("删除失败")
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text Is Nothing Then Exit Sub
        If MsgBox("确认要清空数据库吗", vbOKCancel) = 2 Then Exit Sub
        If MsgBox("删除只是抹去数据库内容，已下载图片不会自行删除", vbOKCancel) = 2 Then Exit Sub
        If MsgBox("再次重新添加又得重新获取音声内容，真的确认吗", vbOKCancel) = 2 Then Exit Sub
        Dim cmdline As New OleDb.OleDbCommand
        cmdline.Connection = Conn
        MsgBox("SQL:从删库到跑路")
        cmdline.CommandText = "DELETE FROM ASMRmanager"
        cmdline.ExecuteNonQueryAsync()
        Conn.Close()
        Conn.Open() '笨办法刷新一下
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim zhiling As String
        zhiling = "Shengyou='" & TextBox2.Text & "',Fanshou='" & TextBox3.Text & "',Shetuan='" & TextBox4.Text & "',Fengmian='" & TextBox5.Text & "',Bendimulu='" & TextBox6.Text & "',Mingzi='" & TextBoxName.Text & "'"
        Rjdetailwrit(zhiling, TextBox1.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, TextBoxName.TextChanged
        Button5.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ListBox2.Items.Clear()
        Dim CBziduan As String
        Select Case ComboBox1.SelectedIndex
            Case Is = 0
                CBziduan = "Rj"
            Case Is = 1
                CBziduan = "Shengyou"
            Case Is = 2
                CBziduan = "Fanshou"
            Case Is = 3
                CBziduan = "Shetuan"
            Case Is = 4
                CBziduan = "Mingzi"
            Case Else
                Exit Sub
        End Select
        Dbreader("*", CBziduan & "='" & TextBox7.Text & "'")
        While readlist.Read()
            ListBox2.Items.Add(readlist(0).ToString)
        End While
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Try
            Rjdetailread(ListBox2.SelectedItem.ToString)
            If CheckBox1.Checked = True Then ButtonDL_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("别点那么快啊")
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Proxyconfig.Show()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then ButtonDL.Enabled = False
        If CheckBox1.Checked = False Then ButtonDL.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click '刷新，读取
        ListBox2.Items.Clear()
        Dbreader("Rj", "*")
        While readlist.Read()
            ListBox2.Items.Add(readlist(0).ToString)
        End While
    End Sub

    Private Sub ButtonDL_Click(sender As Object, e As EventArgs) Handles ButtonDL.Click
        If TextBox1.Text = "" Then Exit Sub
        ButtonDL.Enabled = False
        WebBrowser1.ScriptErrorsSuppressed = True '禁止显示网页脚本错误
        WebBrowser1.Stop()
        WebBrowser1.Navigate("https://www.dlsite.com/maniax/work/=/product_id/" & TextBox1.Text & ".html")
        '------注意！------以下为错误
        'Do
        'Application.DoEvents()
        'If WebBrowser1.IsBusy = 0 Then Exit Do  你不能用isBusy写成 Loop until，因为Doevent是非阻塞，程序会同时执行DO-Loop之后的代码,导致页面没加载完就开始读网页内容，会出BUG
        'Loop                                    所以你必须用DocumentCompleted这个事件，该事件内代码将在网页加载完毕后执行
        '------------------
    End Sub

    Public wDoc As String '缓存浏览器读到的内容，以便释放浏览器
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If WebBrowser1.ReadyState < WebBrowserReadyState.Complete OrElse WebBrowser1.Url.ToString() = LastUrl Then Return
        LastUrl = WebBrowser1.Url.ToString()
        '以上代码可以确保你不会在未加载完毕时执行操作，
        'WebBrowser控件的DocumentCompleted事件一般就被认定为是在页面完全加载完毕后产生， 而注释中也是这么写的
        '但事实却并非如此。首先它不一定会在完全加载完毕时才触发， 有时就会在加载过程中就会触发。
        '其次按照“完全加载完毕后”来理解， 会认为通常一次页面跳转只会引发一次该事件， 事实也并非如此， 某些页面加载时会引发十多次乃至更多。
        If InStr(WebBrowser1.Document.Body.InnerHtml, "itemprop=" & Chr(34) & "url" & Chr(34) & ">") + 15 > 30 Then '这里是网页已经加载正确了
            WebBrowser1.Stop()
            wDoc = WebBrowser1.Document.Body.InnerHtml '若无法找到任何信息，而确定RJ没错误，且proxy可上网，那么应该是打开的默认网页语言不是日文版，请提交issue，我会考虑做多语言适配
            Dlupdate()
        End If
    End Sub

    Public Property LastUrl As String '严格检查Webbrowser的访问情况，具体原因看上面
        Get
            Return _LastUrl
        End Get
        Set(ByVal value As String)
            _LastUrl = value
        End Set
    End Property
    Private _LastUrl As String

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        If TextBox6.Text Is Nothing Then Exit Sub
        Try
            Shell("explorer " & TextBox6.Text, AppWinStyle.NormalFocus)
        Finally
        End Try
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If TextBox5.Text Is Nothing Then Exit Sub
        Try
            Shell("explorer " & TextBox5.Text, AppWinStyle.NormalFocus)
        Finally
        End Try
    End Sub

    Private Sub DriveListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DriveListBox1.SelectedIndexChanged
        TreeView1.Nodes.Clear()
        ListBox1.Items.Clear()
        Dim rootdir As String = Strings.Left(DriveListBox1.Drive, 2) & "\"
        If My.Computer.FileSystem.GetDriveInfo(rootdir).IsReady = False Then Exit Sub '防止有憨憨电脑里有打不开的分区
        Dim dirInroot = My.Computer.FileSystem.GetDirectories(rootdir) '听说这个名字超级长的方法效率比IO的GetDirectories高？
        Dim dirshow As String  '显示的节点名字，节点本身信息还是路径
        Dim nodnum As Integer = 0 '记录当前父节点序号
        For Each dirname As String In dirInroot
            If (My.Computer.FileSystem.GetDirectoryInfo(dirname).Attributes And FileAttribute.Hidden) <> FileAttribute.Hidden Then '去掉隐藏文件夹，因为这类东西大多需要提升权限,前面那一坨是获得文件夹隐藏的状态
                dirshow = My.Computer.FileSystem.GetName(dirname)
                TreeView1.Nodes.Add(dirname, dirshow)
                Dim SecDirInroot = My.Computer.FileSystem.GetDirectories(dirname)
                For Each secdirname As String In SecDirInroot '套娃获取二级目录，主要是为了获得那个小加号
                    dirshow = My.Computer.FileSystem.GetName(secdirname)
                    If (My.Computer.FileSystem.GetDirectoryInfo(secdirname).Attributes And FileAttribute.Hidden) <> FileAttribute.Hidden Then TreeView1.Nodes.Item(nodnum).Nodes.Add(secdirname, dirshow)
                Next
                nodnum = nodnum + 1
            End If
        Next
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        ListBox1.Items.Clear()
        Dim secrootnow As String
        Dim secrootDirColleection As Object, dirshow As String
        Dim rjReg As RegExp.Regex = New RegExp.Regex(pattern:="Rj[\d]+", options:=RegExp.RegexOptions.IgnoreCase)
        secrootnow = e.Node.Name  'Name就是带路径的那个，text就显示出来不带路径的那个 
        secrootDirColleection = My.Computer.FileSystem.GetDirectories(secrootnow)
        For Each secrootdir As String In secrootDirColleection
            If (My.Computer.FileSystem.GetDirectoryInfo(secrootdir).Attributes And FileAttribute.Hidden) <> FileAttribute.Hidden Then '去掉隐藏文件夹，因为这类东西大多需要提升权限,前面那一坨是获得文件夹隐藏的状态
                dirshow = My.Computer.FileSystem.GetName(secrootdir)
                If rjReg.IsMatch(input:=dirshow) = True Then ListBox1.Items.Add(dirshow)
            End If
        Next
        '读该目录里的文件
        secrootnow = e.Node.Name
        Dim filename As String
        For Each filepath In My.Computer.FileSystem.GetFiles(secrootnow)
            filename = My.Computer.FileSystem.GetName(filepath)
            If rjReg.IsMatch(input:=filename) = True Then
                ListBox1.Items.Add(filename)
            End If
        Next
    End Sub

    Private Sub Dlupdate()
        WebBrowser1.Stop()
        Dim temptext As String
        Dim Ysnamestart As Integer, Ysnameend As Integer '找音声名字的开头和结尾,其实可以在写道一个Function里，不过来来回回调回好烦人，我就直接写了，可读性还更强
        '---找音声名字---用html
        Ysnamestart = InStr(wDoc, "itemprop=" & Chr(34) & "url") + 15
        temptext = Strings.Mid(wDoc, Ysnamestart) '从上面找到的头找到尾巴，因为instr只能返回第一个找到的文本的位置
        Ysnameend = InStr(temptext, "</A>") - 1 '相对于Ysnamestart的结尾位置
        TextBoxName.Text = Strings.Left(temptext, Ysnameend)
        '声优
        Ysnamestart = InStr(wDoc, "<TH>声優</TH>") + 20
        temptext = Strings.Mid(wDoc, Ysnamestart)
        Ysnamestart = InStr(temptext, ">") + 1
        temptext = Strings.Mid(temptext, Ysnamestart)
        Ysnameend = InStr(temptext, "<") - 1
        If Strings.Left(temptext, Ysnameend) <> "" Then
            TextBox2.Text = Strings.Left(temptext, Ysnameend) '写适配规则找多声优好烦啊，等后面版本道长更新吧
        Else
            TextBox2.Text = "未知"
        End If
        '社团 '
        Ysnamestart = InStr(wDoc, "<TH>作者</TH>") + 20
        temptext = Strings.Mid(wDoc, Ysnamestart)
        Ysnamestart = InStr(temptext, ">") + 1
        temptext = Strings.Mid(temptext, Ysnamestart)
        Ysnameend = InStr(temptext, "<") - 1
        If Strings.Left(temptext, Ysnameend) <> "" Then
            TextBox4.Text = Strings.Left(temptext, Ysnameend)
        Else
            TextBox4.Text = "未知"
        End If
        '发售日期
        Ysnamestart = InStr(wDoc, "<TH>販売日</TH>") + 25
        temptext = Strings.Mid(wDoc, Ysnamestart)
        Ysnamestart = InStr(temptext, ">") + 1
        temptext = Strings.Mid(temptext, Ysnamestart)
        Ysnameend = InStr(temptext, "<") - 1
        TextBox3.Text = Strings.Left(temptext, Ysnameend)
        '找封面,存封面
        Ysnameend = InStr(wDoc, "_img_main.jpg")
        temptext = Strings.Left(wDoc, Ysnameend)
        Ysnamestart = InStrRev(temptext, "img.dlsite.jp") '倒着找
        temptext = "https://" & Strings.Mid(temptext, Ysnamestart, Ysnameend) & "img_main.jpg"
        Dim picuri As New Uri(temptext)
        TextBox5.Text = Application.StartupPath & "\cover\" & TextBox1.Text & ".jpg"
        '下载图片
        Dim Pcdwn As New Net.WebClient '定义一个web连接，别问我为啥不用pictruebox直接下图，pic似乎不能走我这里的http代理连接 这里是异步的，会导致点快了下载的图片是一样的，求解决方法
        Pcdwn.DownloadFileAsync(picuri, "cover\" & TextBox1.Text & ".jpg")
        Dim downloadCompleted As Threading.Thread = New Threading.Thread(AddressOf Dwcompleted)
        downloadCompleted.Start()
    End Sub

    Private Sub Dwcompleted() '下载完成事件
        WebBrowser1.Stop()
        Dim timeout As Integer = 0
        Do
            If timeout = 100 Then MsgBox("下载超时或图片加载失败") : Exit Do
            PictureBox1.ImageLocation = TextBox5.Text
            If PictureBox1.Image IsNot Nothing AndAlso PictureBox1.Image IsNot PictureBox1.ErrorImage Then Exit Do
            Threading.Thread.Sleep(100)
            timeout += 1
        Loop
        Button5_Click(Nothing, Nothing)
        ButtonDL.Enabled = True
        Beep()
    End Sub

    Private Sub TreeView1_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterExpand
        ListBox1.Items.Clear()
        Dim secrootnow As String
        Dim rootnowitemcount As Integer = e.Node.Nodes.Count, readcount As Integer
        Dim secrootDirColleection As Object, dirshow As String
        Dim rjReg As RegExp.Regex = New RegExp.Regex(pattern:="Rj[\d]+", options:=RegExp.RegexOptions.IgnoreCase)
        For readcount = 0 To rootnowitemcount - 1 '没办法Node.Nodes似乎没有获得内部节点集合的方法,只能靠计数器历遍 读取的是每个文件夹！或许tostring返回的能是字符串集合?
            secrootnow = e.Node.Nodes.Item(readcount).Name  'Name就是带路径的那个，text就显示出来不带路径的那个 
            If rjReg.IsMatch(input:=e.Node.Nodes.Item(readcount).Text) = True Then ListBox1.Items.Add(e.Node.Nodes.Item(readcount).Text) '读取过程中判断文件夹是否为音声的归宿
            secrootDirColleection = My.Computer.FileSystem.GetDirectories(secrootnow)
            For Each secrootdir As String In secrootDirColleection
                If (My.Computer.FileSystem.GetDirectoryInfo(secrootdir).Attributes And FileAttribute.Hidden) <> FileAttribute.Hidden Then '去掉隐藏文件夹，因为这类东西大多需要提升权限,前面那一坨是获得文件夹隐藏的状态
                    dirshow = My.Computer.FileSystem.GetName(secrootdir)
                    e.Node.Nodes.Item(readcount).Nodes.Add(secrootdir, dirshow)
                End If
            Next
        Next
        '读该目录里的文件
        secrootnow = e.Node.Name
        Dim filename As String
        For Each filepath In My.Computer.FileSystem.GetFiles(secrootnow)
            filename = My.Computer.FileSystem.GetName(filepath)
            If rjReg.IsMatch(input:=filename) = True Then
                ListBox1.Items.Add(filename)
            End If
        Next
    End Sub

    Private Sub RadioButton_FromLocal_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_FromLocal.CheckedChanged
        If RadioButton_FromLocal.Checked = False Then '我知道读取按声优日期社团分类的列表用listbox就行，但是，万一以后你们又想来个什么按照声优的不同时期的作品排序这种扯淡东西，treeview2就有用了
            TreeView1.Visible = False
            TreeView2.Visible = True
        Else
            TreeView1.Visible = True
            TreeView2.Visible = False
        End If
    End Sub

    Private Sub RadioButton_Shengyou_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Shengyou.CheckedChanged
        If RadioButton_Shengyou.Checked = True Then
            TreeView2.Nodes.Clear()
            Dbreader("Shengyou", "*")
            Dim checkin As New ObjectModel.Collection(Of String) '注意 Collection 起点为 1 ！！！！！！
            Dim alreayhave As Boolean = False
            While readlist.Read '读readlist的结果
                checkin.Add(readlist(0))
            End While
            For Each item As String In checkin
                If TreeView2.Nodes.Count > 0 Then '检测是否有必要检测重复项
                    For num As Integer = 0 To TreeView2.Nodes.Count - 1
                        If item = TreeView2.Nodes.Item(num).Text Then
                            alreayhave = True
                            Exit For
                        End If
                    Next
                    If alreayhave = False Then TreeView2.Nodes.Add(item)
                    alreayhave = False
                Else
                    TreeView2.Nodes.Add(item)
                End If
            Next
        End If
    End Sub

    Private Sub RadioButton_SellDate_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_SellDate.CheckedChanged
        If RadioButton_SellDate.Checked = True Then
            TreeView2.Nodes.Clear()
            Dbreader("Fanshou", "*")
            Dim checkin As New Collection '注意 Collection 起点为 1 ！！！！！！
            Dim alreayhave As Boolean = False
            While readlist.Read '读readlist的结果
                checkin.Add(readlist(0))
            End While
            For Each item As String In checkin
                If TreeView2.Nodes.Count > 0 Then '检测是否有必要检测重复项
                    For num As Integer = 0 To TreeView2.Nodes.Count - 1
                        If item = TreeView2.Nodes.Item(num).Text Then
                            alreayhave = True
                            Exit For
                        End If
                    Next
                    If alreayhave = False Then TreeView2.Nodes.Add(item)
                    alreayhave = False
                Else
                    TreeView2.Nodes.Add(item)
                End If
            Next
        End If
    End Sub

    Private Sub RadioButton_Shetuan_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Shetuan.CheckedChanged
        If RadioButton_Shetuan.Checked = True Then
            TreeView2.Nodes.Clear()
            Dbreader("Shetuan", "*")
            Dim checkin As New Collection '注意 Collection 起点为 1 ！！！！！！
            Dim alreayhave As Boolean = False
            While readlist.Read '读readlist的结果
                checkin.Add(readlist(0))
            End While
            For Each item As String In checkin
                If TreeView2.Nodes.Count > 0 Then '检测是否有必要检测重复项
                    For num As Integer = 0 To TreeView2.Nodes.Count - 1
                        If item = TreeView2.Nodes.Item(num).Text Then
                            alreayhave = True
                            Exit For
                        End If
                    Next
                    If alreayhave = False Then TreeView2.Nodes.Add(item)
                    alreayhave = False
                Else
                    TreeView2.Nodes.Add(item)
                End If
            Next
        End If
    End Sub

    Private Sub TreeView2_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView2.AfterSelect
        ListBox2.Items.Clear()
        ListBox1.Items.Clear() : ListBox1.Items.Add("分类查看的") : ListBox1.Items.Add("目标RJ会") : ListBox1.Items.Add("出现在") : ListBox1.Items.Add("搜索结果列表框中")
        Dim nowis As String = "Shengyou='" '默认选择声优
        If RadioButton_Shengyou.Checked = True Then nowis = "Shengyou='"
        If RadioButton_SellDate.Checked = True Then nowis = "Fanshou='"
        If RadioButton_Shetuan.Checked = True Then nowis = "Shetuan='"
        Dbreader("RJ", nowis & e.Node.Text & "'")
        While readlist.Read
            ListBox2.Items.Add(readlist(0))
        End While
    End Sub
End Class
