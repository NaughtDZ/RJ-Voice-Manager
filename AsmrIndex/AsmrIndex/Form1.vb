Imports System.ComponentModel

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
        MsgBox("请保证音声打包在压缩文件包或者放在RJ目录里" & vbCrLf & "请保证压缩包或文件夹为纯 RJ000000 这类形式" & vbCrLf & "批量请用批量按钮，通过树形管理获得的音声，如数据库没有，请手动点击添加按钮", , "注意事项")
    End Sub
    Private Sub GetAllFiles(ByVal strDirect As String)  '搜索所有目录下的文件
        ListBox2.CheckForIllegalCrossThreadCalls = False
        If Not (strDirect Is Nothing) Then
            Dim mFileInfo As IO.FileInfo '文件与文件夹的IO定义
            Dim mDir As IO.DirectoryInfo
            Dim mDirInfo As New IO.DirectoryInfo(strDirect)
            Dim Rjsplit(16) As String '不排除有憨憨的文件名里有好多.,尽管我说了命名为RJxxxx
            Try
                For Each mFileInfo In mDirInfo.GetFiles '获取文件路径
                    'Debug.Print(mFileInfo.FullName)
                    If Strings.Left(mFileInfo.Name, 2) = "RJ" Then
                        Rjsplit = Strings.Split(mFileInfo.Name, ".")
                        If Duplicatedetect(Rjsplit(0)) = False Then
                            Dbinsert("Rj,Shengyou,Fanshou,Shetuan,Fengmian,Bendimulu,Mingzi", "'" & Rjsplit(0) & "','','','','','" & mFileInfo.FullName & "',''")
                        End If
                    End If
                Next
                For Each mDir In mDirInfo.GetDirectories '获取文件夹路径
                    'Debug.Print("******目录回调*******")
                    If Strings.Left(mDir.Name, 2) = "RJ" Then
                        Rjsplit = Strings.Split(mDir.Name, ".")
                        If Duplicatedetect(Rjsplit(0)) = False Then
                            Dbinsert("Rj,Shengyou,Fanshou,Shetuan,Fengmian,Bendimulu,Mingzi", "'" & Rjsplit(0) & "','','','','','" & mDir.FullName & "',''")
                        End If
                    End If
                Next
            Finally
            End Try
        End If
    End Sub
    Private Function Duplicatedetect(ByVal predetect As String) As Boolean '判断库里是否有了
        Dim cmdline As New OleDb.OleDbCommand '初始化数据库命令行
        Dim dbreader As OleDb.OleDbDataReader '建立一个数据库读取器
        cmdline.Connection = Conn '指定命令行到对应数据库
        Dim commend As String = "select Rj From ASMRmanager Where Rj = '" & predetect & "'"
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
        If Duplicatedetect(ListBox1.SelectedItem.ToString) = True Then
            Try
                Rjdetailread(ListBox1.SelectedItem.ToString)
                If CheckBox1.Checked = True Then ButtonDL_Click(Nothing, Nothing)
            Catch ex As Exception
                MsgBox("别点那么快啊")
            End Try
        Else
            TextBox1.Text = ListBox1.SelectedItem.ToString
            TextBox6.Text = DirListBox1.Path & "\" & DirListBox1.SelectedItem & "\" & ListBox1.SelectedItem
            PictureBox1.ImageLocation = ""
            TextBoxName.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
        End If
    End Sub
    Private Sub Rjdetailread(rjchose As String) '读listbox1或2选中的RJ
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
        If Duplicatedetect(TextBox1.Text) = True Then
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
        isok = False
        WebBrowser1.ScriptErrorsSuppressed = True '禁止显示网页脚本错误
        ButtonDL.Enabled = False
        WebBrowser1.Navigate("https://www.dlsite.com/maniax/work/=/product_id/" & TextBox1.Text & ".html")
        '------注意！------以下为错误
        'Do
        'Application.DoEvents()
        'If WebBrowser1.IsBusy = 0 Then Exit Do  你不能用isBusy写成 Loop until，因为Doevent是非阻塞，程序会同时执行DO-Loop之后的代码,导致页面没加载完就开始读网页内容，会出BUG
        'Loop                                    所以你必须用DocumentCompleted这个事件，该事件内代码将在网页加载完毕后执行
        '------------------
    End Sub
    Public isok As Boolean = False
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If isok = False Then
            If InStr(WebBrowser1.Document.Body.InnerHtml, "itemprop=" & Chr(34) & "url" & Chr(34) & ">") + 15 > 30 Then
                isok = True '防止多元素加载导致的反复判定
                Dlupdate()
            End If
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        If TextBox6.Text Is Nothing Then Exit Sub
        Try
            Shell("explorer " & TextBox6.Text)
        Finally
        End Try
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If TextBox5.Text Is Nothing Then Exit Sub
        Try
            Shell("explorer " & TextBox5.Text)
        Finally
        End Try
    End Sub

    Private Sub DriveListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DriveListBox1.SelectedIndexChanged
        DirListBox1.Path = DriveListBox1.Drive
    End Sub

    Private Sub DirListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DirListBox1.SelectedIndexChanged
        ListBox1.Items.Clear()
        If Not (DirListBox1.Path Is Nothing) Then
            Try
                Dim mFileInfo As System.IO.FileInfo
                Dim mDirInfo As New System.IO.DirectoryInfo(DirListBox1.Path & "\" & DirListBox1.SelectedItem)
                Dim Rjsplit(16) As String
                For Each mFileInfo In mDirInfo.GetFiles()
                    'Debug.Print(mFileInfo.FullName)
                    If Strings.Left(mFileInfo.Name, 2) = "RJ" Then
                        Rjsplit = Strings.Split(mFileInfo.Name, ".")
                        ListBox1.Items.Add(Rjsplit(0))
                    End If
                Next
            Catch ex As Exception
                Debug.Print("目录没找到：" + ex.Message)
            End Try
        End If
    End Sub

    Private Sub Dlupdate()
        Dim wDoc As String, temptext As String
        wDoc = WebBrowser1.Document.Body.InnerHtml '若无法找到任何信息，而确定RJ没错误，且proxy可上网，那么应该是打开的默认网页语言不是日文版，请提交issue，我会考虑做多语言适配
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
        TextBox2.Text = Strings.Left(temptext, Ysnameend) '写适配规则找多声优好烦啊，等后面版本道长更新吧
        '社团 '
        Ysnamestart = InStr(wDoc, "<TH>作者</TH>") + 20
        temptext = Strings.Mid(wDoc, Ysnamestart)
        Ysnamestart = InStr(temptext, ">") + 1
        temptext = Strings.Mid(temptext, Ysnamestart)
        Ysnameend = InStr(temptext, "<") - 1
        TextBox4.Text = Strings.Left(temptext, Ysnameend)
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
        TextBox5.Text = Application.StartupPath & "\cover\" & TextBox1.Text & ".jpg"
        '下载图片
        Dim pcdwn As New Net.WebClient '定义一个web连接，别问我为啥不用pictruebox直接下图，pic似乎不能走我这里的http代理连接
        pcdwn.DownloadFile(temptext, "cover\" & TextBox1.Text & ".jpg")
        PictureBox1.ImageLocation = TextBox5.Text
        '------------
        Button5_Click(Nothing, Nothing)
        ButtonDL.Enabled = True
        Beep()
    End Sub
End Class
