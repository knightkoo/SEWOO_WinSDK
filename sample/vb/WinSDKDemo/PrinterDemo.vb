Imports System.Runtime.InteropServices

Module PrinterDemo

    Public Const POSPRINTERR As String = "printer.sdk.dll"

    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrinterCreator(ByRef printer As IntPtr, model As String) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function OpenPort(printer As IntPtr, setting As String) As Integer

    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ClosePort(printer As IntPtr) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ReleasePrinter(printer As IntPtr) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ReadData(printer As IntPtr, buffer As Byte(), size As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function WriteData(printer As IntPtr, buffer As Byte(), size As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrinterInitialize(printer As IntPtr) As Integer
    End Function


    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrintTextS(printer As IntPtr, data As String) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrintAndFeedLine(printer As IntPtr) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrintBarCode(printer As IntPtr, bcType As Integer, data As String, width As Integer, height As Integer, alignment As Integer, hriPosition As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CutPaperWithDistance(printer As IntPtr, distance As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrintSymbol(printer As IntPtr, type As Integer, data As String, errLevel As Integer, width As Integer, height As Integer, alignment As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GetPrinterState(printer As IntPtr, ByRef intValue As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetRelativeHorizontal(printer As IntPtr, position As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function OpenCashDrawer(printer As IntPtr, pinMode As Integer, onTime As Integer, ofTime As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrintImageW(printer As IntPtr, imagePath As String, scaleMode As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetAlign(printer As IntPtr, align As Integer) As Integer
    End Function

    Private Sub PaperStatus(printer, tb_Msg)
        Dim status = 4
        Dim ret = GetPrinterState(printer, status)
        If ret = 0 Then
            If (status And &HC) > 0 Then
                tb_Msg.Text += DateTime.Now.ToString("MM-dd HH:mm:ss") + " The printer status is Paper near end" + vbCrLf
            Else
                tb_Msg.Text += DateTime.Now.ToString("MM-dd HH:mm:ss") + " The printer status is Ready" + vbCrLf
            End If
        Else
            tb_Msg.Text += DateTime.Now.ToString("MM-dd HH:mm:ss") + " " + "Get Error, Code is: " + ret + vbCrLf
        End If
    End Sub


    Private Function ParseStatus(status) As String
        Dim text
        If (status And &B100) > 0 Then
            text = "Cover opened"
        ElseIf (status And &B1000) > 0 Then
            text = "Feed button has been pressed"
        ElseIf (status And &B100000) > 0 Then
            text = "Out of paper"
        ElseIf (status And &B1000000) > 0 Then
            text = "Error condition"
        Else
            text = "Error"
        End If

        Return text
    End Function

    Public Sub GetStatus(printer, tb_Msg)
        Dim status = 2
        Dim ret = GetPrinterState(printer, status)
        If ret = 0 Then
            If status = &H12 Then
                PaperStatus(printer, tb_Msg)
            Else
                tb_Msg.Text += DateTime.Now.ToString("MM-dd HH:mm:ss") + " The printer status is " + ParseStatus(status) + vbCrLf
            End If
        Else
            tb_Msg.Text += DateTime.Now.ToString("MM-dd HH:mm:ss") + " " + "Get Error, Code is: " + ret + vbCrLf
        End If
    End Sub

    Public Sub PrintSample(printer)
        PrinterInitialize(printer)
        SetRelativeHorizontal(printer, 180)
        PrintTextS(printer, "Las vegas,NV5208" & Chr(10))
        PrintAndFeedLine(printer)
        PrintAndFeedLine(printer)
        PrintTextS(printer, "Ticket #30-57320             User:HAPPY" & Chr(10))
        PrintTextS(printer, "Station:52-102          Sales Rep HAPPY" & Chr(10))
        PrintTextS(printer, "10/10/2019 3:55:01PM" & Chr(10))
        PrintTextS(printer, "---------------------------------------" & Chr(10))
        PrintTextS(printer, "Item         QTY         Price    Total" & Chr(10))
        PrintTextS(printer, "Description" & Chr(10))
        PrintTextS(printer, "---------------------------------------" & Chr(10))
        PrintTextS(printer, "100328       1           7.99      7.99" & Chr(10))
        PrintTextS(printer, "MAGARITA MIX 7           7.99      3.96" & Chr(10))
        PrintTextS(printer, "680015       1          43.99     43.99" & Chr(10))
        PrintTextS(printer, "LIME" & Chr(10))
        PrintTextS(printer, "102501       1          43.99     43.99" & Chr(10))
        PrintTextS(printer, "V0DKA" & Chr(10))
        PrintTextS(printer, "021048       1           3.99      3.99" & Chr(10))
        PrintTextS(printer, "ORANGE 3200Z" & Chr(10))
        PrintTextS(printer, "---------------------------------------" & Chr(10))
        PrintTextS(printer, "Subtobal                          60.93" & Chr(10))
        PrintTextS(printer, "8.1% Sales Tax                     3.21" & Chr(10))
        PrintTextS(printer, "2% Concession Recov                1.04" & Chr(10))
        PrintTextS(printer, "---------------------------------------" & Chr(10))
        PrintTextS(printer, "Total                             66.18" & Chr(10))
        PrintBarCode(printer, 73, "1234567890", 3, 150, 0, 2)
        CutPaperWithDistance(printer, 10)
    End Sub

    Public Sub PrintQRCode(printer)
        PrinterInitialize(printer)
        PrintTextS(printer, "Example qrcode." & Chr(10))
        PrintSymbol(printer, 49, "https://www.miniprinter.com/", 48, 10, 10, 1)
        SetAlign(printer, 0)
        PrintTextS(printer, "Example PDF417." & Chr(10))
        PrintSymbol(printer, 48, "SEWOO Printer(C)2023-4C6565", 48, 10, 8, 1)
        SetAlign(printer, 0)
        CutPaperWithDistance(printer, 10)
    End Sub

    Public Sub PrintBarCode(printer)
        PrinterInitialize(printer)
        PrintTextS(printer, "Example UPC_A." & Chr(10))
        PrintBarCode(printer, 65, "614141999996", 3, 150, 0, 2)
        PrintTextS(printer, "Example UPC_E." & Chr(10))
        PrintBarCode(printer, 66, "040100002931", 3, 150, 0, 2)
        PrintTextS(printer, "Example JAN13(EAN13)." & Chr(10))
        PrintBarCode(printer, 67, "2112345678917", 3, 150, 0, 2)
        PrintTextS(printer, "Example JAN8(EAN8)." & Chr(10))
        PrintBarCode(printer, 68, "21234569", 3, 150, 0, 2)
        PrintTextS(printer, "Example CODE39." & Chr(10))
        PrintBarCode(printer, 69, "12345678", 3, 150, 0, 2)
        PrintTextS(printer, "Example ITF." & Chr(10))
        PrintBarCode(printer, 70, "10614141999993", 3, 150, 0, 2)
        PrintTextS(printer, "Example CODABAR." & Chr(10))
        PrintBarCode(printer, 71, "B1234567890B", 3, 150, 0, 2)
        PrintTextS(printer, "Example CODE93." & Chr(10))
        PrintBarCode(printer, 72, "12345678", 3, 150, 0, 2)
        PrintTextS(printer, "Example barcode 128." & Chr(10))
        PrintBarCode(printer, 73, "1234567890", 3, 150, 0, 2)
        CutPaperWithDistance(printer, 10)
    End Sub

    Public Sub PrintImage(printer, path)
        PrinterInitialize(printer)
        PrintImageW(printer, path, 0)
        CutPaperWithDistance(printer, 10)
    End Sub

End Module
