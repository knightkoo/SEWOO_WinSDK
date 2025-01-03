using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using TheArtOfDev.HtmlRenderer.WinForms;
using WinSDKDemo.Helper;

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

        public static void PrintBuffer(IntPtr printer)
        {
            try
            {
                // 이미지 크기 설정
                int width = CalcPrintWidth(paperWidth:72, dpi:208);
                int height = 400;

                string[] fontNames = { "굴림", "돋움", "맑은 고딕", "궁서체", "휴먼옛체" };

                // DrawingBuffer 인스턴스 생성
                using (DrawingCanvas canvas = new DrawingCanvas(width, height))
                {
                    // 텍스트 출력
                    int index = 0;
                    foreach (string fontName in fontNames)
                    {
                        Font font = new Font(fontName, 24, FontStyle.Bold);
                        Brush brush = Brushes.Black;
                        PointF textPosition = new PointF(20, 20 + index * 50);
                        canvas.DrawText($"{fontName} : 무궁화 꽃이 피었습니다.", font, brush, textPosition);
                        index++;
                    }

                    // 사각형 그리기
                    Pen rectPen = new Pen(Color.Black, 3);
                    Rectangle rectangle = new Rectangle(0, 0, width, 400 - 2);
                    canvas.DrawRectangle(rectPen, rectangle);

                    // 이미지 파일로 저장
                    string filePath = Path.Combine(Path.GetTempPath(), "temp_output.png");
                    canvas.SaveToFile(filePath, ImageFormat.Png);

                    PrintImage(printer, filePath);
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }

        public static void PrintHtml(IntPtr printer)
        {
            int width = CalcPrintWidth(paperWidth: 72, dpi: 208);

            using (var image = new Bitmap(10, 10))
            using (var graphics = Graphics.FromImage(image))
            {
                string html = System.IO.File.ReadAllText(@"..\Contents\receipt.html");
                //1. 출력될 Html 랜더링 영역을 계산한다.
                var size = HtmlRender.Measure(graphics, html, maxWidth: width);

                //2. 랜더링 크기 맞도록 출력 객체를 생성한다.
                using (var renderImage = new Bitmap(width, (int)size.Height + 10))
                using (var renderGraphics = Graphics.FromImage(renderImage))
                {
                    size = HtmlRender.Render(renderGraphics, html, maxWidth: width);
                    string filePath = Path.Combine(Path.GetTempPath(), "print_output.png");
                    renderImage.Save(filePath, ImageFormat.Png);

                    PrintImage(printer, filePath);

                    File.Delete(filePath);
                }
            }
        }

        /// <summary>
        /// 프린트 출력 넓이를 계산한다. ( 인치 * DPI )
        /// </summary>
        /// <param name="paperWidth">출력 영역 (mm)</param>
        /// <param name="dpi">DPI</param>
        /// <returns></returns>
        public static int CalcPrintWidth(int paperWidth = 72, int dpi = 208)
        {
            float inch = (float)paperWidth / 25.4f;
            return (int)( inch * (float)dpi);
        }
    }
}
