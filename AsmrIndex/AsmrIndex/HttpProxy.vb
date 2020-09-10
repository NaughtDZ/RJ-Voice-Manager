Imports System.Runtime.InteropServices
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.WebClient
Module HttpProxy
    Public Const INTERNET_OPTION_TYPE_PROXY = 38
    Public Const INTERNET_OPEN_TYPE_PROXY = 3
    Public Const INTERNET_OPTION_SETTINGS_CHANGED = 39
    '调用API函数
    <DllImport("wininet.dll", SetLastError:=True)>
    Public Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr, ByVal lpdwBufferLength As Integer) As Boolean
        '窗口调用请把上面代码替换为下面的这行代码,或直接将Public  与 Function 中间加一个Shared 就可以在窗体重使用了 在模块中就用上面的代码'很多网上给的API函数都是VB6或VB2005用的 在2010就不能正常调用了
        'Public Shared Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr, ByVal lpdwBufferLength As Integer) As Boolean
    End Function
    Structure INTERNET_PROXY_INFO
        Public dwAccessType As Integer
        Public proxy As IntPtr
        Public proxyBypass As IntPtr
    End Structure
    Public Sub SetProxy(ByVal StrProxy As String)
        Dim _IP As INTERNET_PROXY_INFO
        _IP.dwAccessType = INTERNET_OPEN_TYPE_PROXY
        _IP.proxy = Marshal.StringToHGlobalAnsi(StrProxy)
        _IP.proxyBypass = Marshal.StringToHGlobalAnsi("local")
        Dim Inpt As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(_IP))
        Marshal.StructureToPtr(_IP, Inpt, True)
        InternetSetOption(IntPtr.Zero, INTERNET_OPTION_TYPE_PROXY, Inpt, Marshal.SizeOf(_IP))
    End Sub
End Module
