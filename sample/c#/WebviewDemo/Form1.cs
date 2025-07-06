using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Drawing.Imaging;

namespace WebviewDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2InitializationCompleted += (s, e) =>
            {
                webView.CoreWebView2.WebMessageReceived += WebMessageReceived;
                webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                    "oq.dev", @"C:\Dev\Oq\temp\html", CoreWebView2HostResourceAccessKind.Allow
                );

                //string currentDir = Directory.GetCurrentDirectory();
                //string path = Path.Combine(currentDir, @"c:/Dev/Oq/temp/html/oq_order.html");
                //path = Path.GetFullPath(path);
                //webView.Source = new Uri(path);
            };
        }

        private void WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string message = e.WebMessageAsJson;
            MessageBox.Show("Received from WebView2: " + message);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            string currentDir = Directory.GetCurrentDirectory();
            //string path = Path.Combine(currentDir, "../Contents/message_demo.html");
            string path = Path.Combine(currentDir, @"c:/Dev/Oq/temp/html/oq_order.html");
            path = Path.GetFullPath(path);
            //path = $"file://{path}";



            //string path = "https://oq-dev.vercel.app/auth/sign-in";
            webView.Source = new Uri(path);

            //string htmlContent = File.ReadAllText(@"c:/Dev/Oq/temp/html/oq_order.html");
            //webView.NavigateToString(htmlContent);
            //webView.CoreWebView2.NavigationCompleted += (s, e1) =>
            //{
            //};
        }

        private async void OnClickSendToWeb(object sender, EventArgs e)
        {
            //// WebBrowser 컨트롤에 JavaScript 함수 실행
            //string message = "Hello from C#";
            ////await webView.ExecuteScriptAsync($"receiveDataFromCSharp('{message}')");
            //await webView.ExecuteScriptAsync($"window.handleMessageFromFlutter('{message}')");

            ////string htmlContent = "<html><body><h1>Hello, WebView2!</h1><p>This is a test content.</p></body></html>";
            ///
            //await RenderUrlToImage(@"file://c:/Dev/Oq/temp/html/oq_receipt.html");

            //await Helper.HeadlessHtmlRenderer.RenderToImage(@"file://c:/Dev/Oq/temp/html/oq_receipt.html", 500, @"c:\Temp\output_html.png");
            bool result = await Helper.HeadlessHtmlRenderer.RenderHtmlToImage(@"c:/Dev/Oq/temp/html/oq_order_allinone.html", 500, @"c:\Temp\output_html2.png");
            //MessageBox.Show($"이미지가 저장되었습니다.\n{outputPath}\n크기: {image.Width}x{image.Height}");
        }

        private async Task RenderUrlToImage(string url)
        {
            // 백그라운드 WebView2 생성 (화면에 표시하지 않음)
            using (var webViewBackground = new WebView2())
            {
                // WebView2 초기화
                await webViewBackground.EnsureCoreWebView2Async(null);

                // 지정된 URL로 이동
                webViewBackground.Source = new Uri(url);

                // 페이지 로드가 완료될 때까지 대기
                var tcs = new TaskCompletionSource<bool>();
                webViewBackground.CoreWebView2.NavigationCompleted += (s, e) =>
                {
                    if (e.IsSuccess)
                        tcs.SetResult(true);
                    else
                        tcs.SetException(new Exception("Navigation failed"));
                };

                await tcs.Task;

                // 렌더링이 완료될 시간을 확보하기 위해 약간 대기 (필요 시 조정)
                //await Task.Delay(1000);

                // 웹페이지의 전체 높이 계산
                //string script = "Math.max(document.body.scrollHeight, document.documentElement.scrollHeight, document.body.offsetHeight, document.documentElement.offsetHeight, document.body.clientHeight, document.documentElement.clientHeight);";
                string script = "document.getElementById('mainmenu').offsetHeight;";
                string heightResult = await webViewBackground.CoreWebView2.ExecuteScriptAsync(script);
                int pageHeight = (int)double.Parse(heightResult.Trim('"')) ; // JSON 문자열에서 숫자 파싱

                // WebView2 크기 설정: 너비는 500px로 고정, 높이는 페이지 높이에 맞게 설정
                int fixedWidth = 500;
                webViewBackground.Size = new Size(fixedWidth, pageHeight);

                webViewBackground.Refresh();

                // WebView2의 뷰포트 크기 조정 (CSS 너비 고정)
                //await webViewBackground.CoreWebView2.ExecuteScriptAsync($"document.body.style.width = '{fixedWidth}px';");

                // 스크린샷 캡처
                using (var stream = new MemoryStream())
                {
                    await webViewBackground.CoreWebView2.CapturePreviewAsync(
                        Microsoft.Web.WebView2.Core.CoreWebView2CapturePreviewImageFormat.Png, stream);

                    // 이미지로 변환
                    stream.Position = 0;
                    using (var image = Image.FromStream(stream))
                    {
                        // 파일로 저장
                        image.Save(@"c:\Temp\output_html.png", ImageFormat.Png);
                        MessageBox.Show($"이미지가 'output.png'로 저장되었습니다. 크기: {image.Width}x{image.Height}");
                    }
                }
            }
        }

        //private async Task RenderUrlToImage(string url)
        //{
        //    // 백그라운드 WebView2 생성 (화면에 표시하지 않음)
        //    using (var webViewBackground = new WebView2())
        //    {
        //        // WebView2 초기화
        //        await webViewBackground.EnsureCoreWebView2Async(null);

        //        // 지정된 URL로 이동
        //        webViewBackground.Source = new Uri(url);

        //        // 페이지 로드가 완료될 때까지 대기
        //        var tcs = new TaskCompletionSource<bool>();
        //        webViewBackground.CoreWebView2.NavigationCompleted += (s, e) =>
        //        {
        //            if (e.IsSuccess)
        //                tcs.SetResult(true);
        //            else
        //                tcs.SetException(new Exception("Navigation failed"));
        //        };

        //        await tcs.Task;

        //        // 렌더링이 완료될 시간을 확보하기 위해 약간 대기 (필요 시 조정)
        //        await Task.Delay(1000);

        //        // WebView2 크기 설정 (이미지 크기 조정 가능)
        //        webViewBackground.Size = new Size(1280, 720);

        //        // 스크린샷 캡처
        //        using (var stream = new MemoryStream())
        //        {
        //            await webViewBackground.CoreWebView2.CapturePreviewAsync(
        //                Microsoft.Web.WebView2.Core.CoreWebView2CapturePreviewImageFormat.Png, stream);

        //            // 이미지로 변환
        //            stream.Position = 0;
        //            using (var image = Image.FromStream(stream))
        //            {
        //                // 파일로 저장
        //                image.Save(@"c:\Temp\output_html.png", ImageFormat.Png);
        //                MessageBox.Show("이미지가 'output.png'로 저장되었습니다.");
        //            }
        //        }
        //    }
        //}
    }   
}
