using System;
using System.Runtime.InteropServices;

namespace WinSDKDemo
{
    public class PrinterDemo
    {
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern IntPtr PrinterCreator(ref IntPtr printer, string model);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ReleasePrinter(IntPtr intPtr);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int OpenPort(IntPtr intPtr, string port);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ClosePort(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int WriteData(IntPtr intPtr, byte[] buffer, int size);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int ReadData(IntPtr intPtr, byte[] buffer, int size);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int PrinterInitialize(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int SetTextLineSpace(IntPtr intPtr, int lineSpace);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int CancelPrintDataInPageMode(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetPrinterState(IntPtr intPtr, ref int printerStatus);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int SetCodePage(IntPtr intPtr, int characterSet);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int SetInternationalCharacter(IntPtr intPtr, int characterSet);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int CutPaper(IntPtr intPtr, int cutMode);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int CutPaperWithDistance(IntPtr intPtr, int distance);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int FeedLine(IntPtr intPtr, int lines);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int OpenCashDrawer(IntPtr intPtr, int pinMode, int onTime, int ofTime);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int PrintText(IntPtr intPtr, string data, int alignment, int textSize);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int PrintTextS(IntPtr intPtr, string data);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int PrintBarCode(IntPtr intPtr, int bcType, string bcData, int width, int height, int alignment, int hriPosition);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int PrintSymbol(IntPtr intPtr, int type, string data, int errLevel, int width, int height, int alignment);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int PrintImageW(IntPtr intPtr, string filePath, int scaleMode);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int PrintAndFeedLine(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int SetRelativeHorizontal(IntPtr intPtr, int position);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int SetAlign(IntPtr intPtr, int align);

        public delegate void MsgCallback(string message);

        private static void GetPaperStatus(IntPtr printer, MsgCallback callback)
        {
            int status = 4;
            int ret = PrinterDemo.GetPrinterState(printer, ref status);
            if (ret == 0)
            {
                if ((status & 0x0c) > 0)
                {
                    callback("The printer status is Paper near end.");
                }
                else
                {
                    callback("The printer status is Ready");
                }
            }
            else
            {
                callback($"Get Error, Code is: {ret}");
            }
        }

        private static string ParseStatus(int status)
        {
            if ((status & 0b100) > 0)
            {
                return "Cover opened";
            }
            else if ((status & 0b1000) > 0)
            {
                return "Feed button has been pressed";
            }
            else if ((status & 0b100000) > 0)
            {
                return "Out of paper";
            }
            else if ((status & 0b1000000) > 0)
            {
                return "Error condition";
            }
            else
            {
                return "Error";
            }
        }

        public static void GetStatus(IntPtr printer, MsgCallback callback)
        {
            int status = 2;
            int ret = PrinterDemo.GetPrinterState(printer, ref status);
            if (ret == 0)
            {
                if (status == 0x12)
                {
                    GetPaperStatus(printer, callback);
                }
                else
                {
                    callback($"The printer status is {ParseStatus(status)}");
                }
            }
            else
            {
                callback($"Get Error, Code is: {ret}");
            }
        }

        public static void PrintSample(IntPtr printer)
        {
            PrinterInitialize(printer);
            SetRelativeHorizontal(printer, 180);
            PrintTextS(printer, "Las vegas,NV5208\r\n");
            PrintAndFeedLine(printer);
            PrintAndFeedLine(printer);
            PrintTextS(printer, "Ticket #30-57320             User:HAPPY\r\n");
            PrintTextS(printer, "Station:52-102          Sales Rep HAPPY\r\n");
            PrintTextS(printer, "10/10/2019 3:55:01PM\r\n");
            PrintTextS(printer, "---------------------------------------\r\n");
            PrintTextS(printer, "Item         QTY         Price    Total\r\n");
            PrintTextS(printer, "Description\r\n");
            PrintTextS(printer, "---------------------------------------\r\n");
            PrintTextS(printer, "100328       1           7.99      7.99\r\n");
            PrintTextS(printer, "MAGARITA MIX 7           7.99      3.96\r\n");
            PrintTextS(printer, "680015       1          43.99     43.99\r\n");
            PrintTextS(printer, "LIME\r\n");
            PrintTextS(printer, "102501       1          43.99     43.99\r\n");
            PrintTextS(printer, "V0DKA\r\n");
            PrintTextS(printer, "021048       1           3.99      3.99\r\n");
            PrintTextS(printer, "ORANGE 3200Z\r\n");
            PrintTextS(printer, "---------------------------------------\r\n");
            PrintTextS(printer, "Subtobal                          60.93\r\n");
            PrintTextS(printer, "8.1% Sales Tax                     3.21\r\n");
            PrintTextS(printer, "2% Concession Recov                1.04\r\n");
            PrintTextS(printer, "---------------------------------------\r\n");
            PrintTextS(printer, "Total                             66.18\r\n");
            PrintBarCode(printer, 73, "1234567890", 3, 150, 0, 2);
            CutPaperWithDistance(printer, 10);
        }

        public static void PrintQRCode(IntPtr printer)
        {
            PrinterInitialize(printer);

            PrintTextS(printer, "Example qrcode.\r\n");
            PrintSymbol(printer, 49, "https://www.miniprinter.com/", 48, 10, 10, 1);
            SetAlign(printer, 0);

            PrintTextS(printer, "Example PDF417.\r\n");
            PrintSymbol(printer, 48, "SEWOO Printer(C)2023-4C6565", 48, 10, 8, 1);
            SetAlign(printer, 0);
            CutPaperWithDistance(printer, 10);
        }

        public static void PrintBarCode(IntPtr printer)
        {
            PrinterInitialize(printer);

            PrintTextS(printer, "Example UPC_A.\r\n");
            PrintBarCode(printer, 65, "614141999996", 3, 150, 0, 2);

            PrintTextS(printer, "Example UPC_E.\r\n");
            PrintBarCode(printer, 66, "040100002931", 3, 150, 0, 2);

            PrintTextS(printer, "Example JAN13(EAN13).\r\n");
            PrintBarCode(printer, 67, "2112345678917", 3, 150, 0, 2);

            PrintTextS(printer, "Example JAN8(EAN8).\r\n");
            PrintBarCode(printer, 68, "21234569", 3, 150, 0, 2);

            PrintTextS(printer, "Example CODE39.\r\n");
            PrintBarCode(printer, 69, "12345678", 3, 150, 0, 2);

            PrintTextS(printer, "Example ITF.\r\n");
            PrintBarCode(printer, 70, "10614141999993", 3, 150, 0, 2);

            PrintTextS(printer, "Example CODABAR.\r\n");
            PrintBarCode(printer, 71, "B1234567890B", 3, 150, 0, 2);

            PrintTextS(printer, "Example CODE93.\r\n");
            PrintBarCode(printer, 72, "12345678", 3, 150, 0, 2);

            PrintTextS(printer, "Example barcode 128.\r\n");
            PrintBarCode(printer, 73, "1234567890", 3, 150, 0, 2);
            CutPaperWithDistance(printer, 10);
        }

        public static void PrintImage(IntPtr printer, string path)
        {
            PrinterInitialize(printer);
            int ret = PrintImageW(printer, path, 0);
            CutPaperWithDistance(printer, 10);
        }
    }
}
