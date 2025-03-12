using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Helper;
using System.IO;
using TheArtOfDev.HtmlRenderer.WinForms;
using LKCSTest;

namespace Helper
{
    class PrintHelper
    {
        static int DPI = 180;

        public static void PrintBuffer()
        {
            try
            {
                // 이미지 크기 설정
                int width = CalcPrintWidth(paperWidth: 72, dpi: DPI);
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
                    string filePath = Path.Combine(Path.GetTempPath(), "temp_output.bmp");
                    canvas.SaveToFile(filePath, ImageFormat.Bmp);

                    LKPrint.PrintStart();
                    LKPrint.PrintBitmap(filePath, LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_NORMAL, 5, LKPrint.LK_BITMAP_NO_DITHER);
                    LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.
                    LKPrint.PrintStop();
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }

        public static void PrintHtml()
        {
            int width = CalcPrintWidth(paperWidth: 72, dpi: DPI);

            using (var image = new Bitmap(10, 10))
            using (var graphics = Graphics.FromImage(image))
            {
                string html = System.IO.File.ReadAllText(@"..\Contents\receipt.html");
                //1. 출력될 Html 랜더링 영역을 계산한다.
                var size = HtmlRender.Measure(graphics, html, maxWidth: width);

                //2. 랜더링 크기 맞도록 출력 객체를 생성한다.
                using (var renderImage = new Bitmap(width, (int)size.Height))
                using (var renderGraphics = Graphics.FromImage(renderImage))
                {
                    using (SolidBrush brush = new SolidBrush(Color.White))
                    {
                        // 사각형을 흰색으로 채우기
                        renderGraphics.FillRectangle(brush, new Rectangle(0, 0, width, (int)size.Height));
                    }

                    size = HtmlRender.Render(renderGraphics, html, maxWidth: width);
                    string filePath = Path.Combine(Path.GetTempPath(), "print_output.bmp");
                    renderImage.Save(filePath, ImageFormat.Bmp);

                    LKPrint.PrintStart();
                    LKPrint.PrintBitmap(filePath, LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_NORMAL, 5, LKPrint.LK_BITMAP_NO_DITHER);
                    LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.
                    LKPrint.PrintStop();

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
            return (int)(inch * (float)dpi);
        }
    }
}
