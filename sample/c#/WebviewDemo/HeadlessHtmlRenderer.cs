using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    
using Microsoft.Web.WebView2.WinForms;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace Helper
{
    class HeadlessHtmlRenderer
    {
        public static async Task<bool> RenderHtmlToImage(string filePath, int width, string outputPath)
        {
            // 백그라운드 WebView2 생성 (화면에 표시하지 않음)
            using (var mHeadlessWebView = new WebView2())
            {
                // WebView2 초기화
                await mHeadlessWebView.EnsureCoreWebView2Async(null);

                // 지정된 URL로 이동
                string htmlContent = File.ReadAllText(filePath);
                mHeadlessWebView.NavigateToString(htmlContent);

                // 페이지 로드가 완료될 때까지 대기
                var tcs = new TaskCompletionSource<bool>();
                mHeadlessWebView.CoreWebView2.NavigationCompleted += (s, e) =>
                {
                    if (e.IsSuccess)
                        tcs.SetResult(true);
                    else
                        tcs.SetException(new Exception("Navigation failed"));
                };

                await tcs.Task;

                string script = "document.getElementById('mainmenu').offsetHeight;";
                string heightResult = await mHeadlessWebView.CoreWebView2.ExecuteScriptAsync(script);
                int pageHeight = (int)double.Parse(heightResult.Trim('"')); // JSON 문자열에서 숫자 파싱

                // WebView2 크기 설정: 너비는 입력된 크기로 고정, 높이는 페이지 높이에 맞게 설정
                mHeadlessWebView.Size = new Size(width, pageHeight);

                mHeadlessWebView.Refresh();

                // 스크린샷 캡처
                using (var stream = new MemoryStream())
                {
                    await mHeadlessWebView.CoreWebView2.CapturePreviewAsync(
                            Microsoft.Web.WebView2.Core.CoreWebView2CapturePreviewImageFormat.Png, stream);

                    // 이미지로 변환
                    stream.Position = 0;
                    using (var image = Image.FromStream(stream))
                    {
                        // 파일로 저장
                        image.Save(outputPath, ImageFormat.Bmp);
                        MessageBox.Show($"이미지가 저장되었습니다.\n{outputPath}\n크기: {image.Width}x{image.Height}");
                        return true;
                    }
                }
            }

            return false;

        }

        public static async Task<bool> RenderToImage(string url, int width, string outputPath)
        {
            try
            {
                // 백그라운드 WebView2 생성 (화면에 표시하지 않음)
                using (var mHeadlessWebView = new WebView2())
                {
                    // WebView2 초기화
                    await mHeadlessWebView.EnsureCoreWebView2Async(null);

                    //mHeadlessWebView.CoreWebView2InitializationCompleted += (s, e) =>
                    //{
                    //    // "oq.dev" 가상 도메인을 "C:/Dev/Oq/temp/html" 폴더로 매핑
                    //    mHeadlessWebView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                    //        "oq.dev", @"C:\Dev\Oq\temp\html", CoreWebView2HostResourceAccessKind.Allow
                    //    );

                    //    //string currentDir = Directory.GetCurrentDirectory();
                    //    //string path = Path.Combine(currentDir, @"c:/Dev/Oq/temp/html/oq_order.html");
                    //    //path = Path.GetFullPath(path);
                    //    //webView.Source = new Uri(path);
                    //};

                    // 지정된 URL로 이동
                    mHeadlessWebView.Source = new Uri(url);

                    // 페이지 로드가 완료될 때까지 대기
                    var tcs = new TaskCompletionSource<bool>();
                    mHeadlessWebView.CoreWebView2.NavigationCompleted += (s, e) =>
                    {
                        if (e.IsSuccess)
                            tcs.SetResult(true);
                        else
                            tcs.SetException(new Exception("Navigation failed"));
                    };

                    await tcs.Task;

                    string script = "document.getElementById('mainmenu').offsetHeight;";
                    string heightResult = await mHeadlessWebView.CoreWebView2.ExecuteScriptAsync(script);
                    int pageHeight = (int)double.Parse(heightResult.Trim('"')); // JSON 문자열에서 숫자 파싱

                    // WebView2 크기 설정: 너비는 입력된 크기로 고정, 높이는 페이지 높이에 맞게 설정
                    mHeadlessWebView.Size = new Size(width, pageHeight);

                    mHeadlessWebView.Refresh();

                    // 스크린샷 캡처
                    using (var stream = new MemoryStream())
                    {
                        await mHeadlessWebView.CoreWebView2.CapturePreviewAsync(
                                Microsoft.Web.WebView2.Core.CoreWebView2CapturePreviewImageFormat.Png, stream);

                        // 이미지로 변환
                        stream.Position = 0;
                        using (var image = Image.FromStream(stream))
                        {
                            // 파일로 저장
                            image.Save(outputPath, ImageFormat.Bmp);
                            MessageBox.Show($"이미지가 저장되었습니다.\n{outputPath}\n크기: {image.Width}x{image.Height}");
                            return true;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }

    }
}

