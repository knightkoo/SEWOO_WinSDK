using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LKCSTest
{
    public partial class Form1 : Form
    {
        private bool useprinterdriver;
        private string m_strPrinter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Add extra initialization here
            for (int i = 1; i < 5; i++)
            {
                portNameCBox.Items.Add("COM" + i);
            }

            for (int i = 1; i < 4; i++)
            {
                portNameCBox.Items.Add("LPT" + i);
            }
            
            portNameCBox.Items.Add("USB");
            portNameCBox.Items.Add("TCP/IP");
            portNameCBox.SelectedIndex = 0;
            // BaudRate
            baudRateCBox.Items.Add("115200");
            baudRateCBox.Items.Add("57600");
            baudRateCBox.Items.Add("38400");
            baudRateCBox.Items.Add("19200");
            baudRateCBox.Items.Add("9600");
            baudRateCBox.Items.Add("4800");
            baudRateCBox.SelectedIndex = 2;

            useprinterdriver = false;
            pDriverNameTextBox.Enabled = false;
            closeButton.Enabled = false;
            cashDrawerOpenButton.Enabled = false;
            getCashDrawerStatusButton.Enabled = false;
            printStringButton.Enabled = false;
            printNormalButton.Enabled = false;
            printTextButton.Enabled = false;
            printSampleButton.Enabled = false;
            getPrinterStatusButton.Enabled = false;
            printQRCodeCmdButton.Enabled = false;
            saveQRCodeButton.Enabled = false;
            printQRCodeGenButton.Enabled = false;
            printQRCodeFileButton.Enabled = false;
            printPDF417Button.Enabled = false;

            txtIP.Text = "192.168.1.192";
            txtIP.Enabled = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            LKPrint.ClosePort();
            this.Close();
        }

        private void portNameCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sIndex = portNameCBox.SelectedIndex;
            if (sIndex == 8)
            {
                baudRateCBox.Enabled = false;
                txtIP.Enabled = true;
            }
            else
            {
                baudRateCBox.Enabled = true;
                txtIP.Enabled = false;
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            string port;
            long lResult = 0;
            Int32 baudRate = 0;

            int sIndex = portNameCBox.SelectedIndex;
            if (sIndex == 8)
            {
                // connect network
                lResult = LKPrint.OpenPort(txtIP.Text, 9100);
            }
            else
            {
                // connect other Interface 
                port = portNameCBox.SelectedItem.ToString();
                baudRate = Int32.Parse(baudRateCBox.SelectedItem.ToString());
                lResult = LKPrint.OpenPort(port, baudRate);
            }
            if (lResult != 0)
            {
                MessageBox.Show("Open Port Failed", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                useDriverCheckBox.Enabled = false;
                pDriverNameTextBox.Enabled = false;
                portNameCBox.Enabled = false;
                baudRateCBox.Enabled = false;
                openButton.Enabled = false;
                closeButton.Enabled = true;
                cashDrawerOpenButton.Enabled = true;
                getCashDrawerStatusButton.Enabled = true;
                printStringButton.Enabled = true;
                printNormalButton.Enabled = true;
                printTextButton.Enabled = true;
                printSampleButton.Enabled = true;
                getPrinterStatusButton.Enabled = true;
                printQRCodeCmdButton.Enabled = true;
                saveQRCodeButton.Enabled = true;
                printQRCodeGenButton.Enabled = true;
                printQRCodeFileButton.Enabled = true;
                printPDF417Button.Enabled = true;
                
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            long lResult = LKPrint.ClosePort();
            if (lResult != 0)
            {
                MessageBox.Show("Close Port Failed", "Error", MessageBoxButtons.OK);
            }
            else
            {
                int sIndex = portNameCBox.SelectedIndex;
                if (sIndex > 8)
                {
                    baudRateCBox.Enabled = false;
                }
                else
                    baudRateCBox.Enabled = true;

                useDriverCheckBox.Enabled = true;
                pDriverNameTextBox.Enabled = true;
                portNameCBox.Enabled = true;
                openButton.Enabled = true;
                closeButton.Enabled = false;
                cashDrawerOpenButton.Enabled = false;
                getCashDrawerStatusButton.Enabled = false;
                printStringButton.Enabled = false;
                printNormalButton.Enabled = false;
                printTextButton.Enabled = false;
                printSampleButton.Enabled = false;
                getPrinterStatusButton.Enabled = false;
                printQRCodeCmdButton.Enabled = false;
                saveQRCodeButton.Enabled = false;
                printQRCodeGenButton.Enabled = false;
                printQRCodeFileButton.Enabled = false;
                printPDF417Button.Enabled = false;
                
            }
        }

        private void cashDrawerOpenButton_Click(object sender, EventArgs e)
        {
            //Helper.PrintHelper.PrintBuffer();
            Helper.PrintHelper.PrintHtml();

            //long lResult;
            //if (useprinterdriver)
            //{
            //    // Text Box 로 부터 받음
            //    m_strPrinter = pDriverNameTextBox.Text.ToString();
            //    lResult = LKPrint.OpenPort(m_strPrinter, 1);
            //    if (lResult != 0)
            //    {
            //        MessageBox.Show("OpenPrinter Failed","Error",MessageBoxButtons.OK);
            //        return;
            //    }
            //}

            //LKPrint.OpenDrawer(LKPrint.LK_CD_PIN_TWO, 400, 400);

            //if (useprinterdriver)
            //{
            //    lResult = LKPrint.ClosePort();
            //    if (lResult != 0)
            //    {
            //        MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
            //    }
            //} 
        }

        private void getCashDrawerStatusButton_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
            long lResult = LKPrint.DrawerSts();
            switch (lResult)
            {
                case LKPrint.LK_CD_STS_CLOSED:
                    MessageBox.Show("Cash Drawer Closed", "Cash Drawer Status", MessageBoxButtons.OK);
                    break;
                case LKPrint.LK_CD_STS_OPENED:
                    MessageBox.Show("Cash Drawer Opened", "Cash Drawer Status", MessageBoxButtons.OK);
                    break;
            }

        }

        private void printStringButton_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
            string	TempStr;
	        string strCenter = "\x1B\x61\x31"; // 중앙정렬
            //unsigned char strLeftPrintData[10] = "\x1B\x61\x00"; // 왼쪽정렬
            //string strLeftPrintData = "\x1B\x61\x00"; // 왼쪽정렬
//            string strLeft = "\x1B\x61\x30"; // 왼쪽정렬
            string strRight = "\x1B\x61\x32"; // 오른쪽정렬

            string strDouble = "\x1B\x21\x20"; // Horizontal Double
            string strUnderline = "\x1B\x21\x80"; // underline
            string strDoubleBold = "\x1B\x21\x28"; // Emphasize
            string strNormal = "\x1B\x21\x02"; // 중앙정렬
            string PartialCut = "\x1D\x56\x42\x01"; // Partial Cut.

            
            string BarCodeHeight = "\x1D\x68\x50"; // 바코드 높이
            string BarCodeWidth = "\x1D\x77\x02"; // 바코드 폭
            string SetHRI = "\x1D\x48\x02"; // HRI문자 인쇄위치 아래인쇄지정
            string SetCode128B = "\x1D\x6B\x49"; // Code128

	        long lResult;

            TempStr = "";
            TempStr = TempStr + strDouble;
            TempStr = TempStr + strCenter;
            TempStr = TempStr + "Receipt List\r\n\r\n\r\n";
            TempStr = TempStr + strNormal;
            TempStr = TempStr + strRight;
            TempStr = TempStr + "Right Alignment\r\n";
            TempStr = TempStr + strCenter;
            TempStr = TempStr + "Thank you for coming to our shop!\r\n";
            TempStr = TempStr + "==========================================\r\n";
            TempStr = TempStr + "Chicken                             $10.00\r\n";
            TempStr = TempStr + "Hamburger                           $20.00\r\n";
            TempStr = TempStr + "Pizza                               $30.00\r\n";
            TempStr = TempStr + "Lemons                              $40.00\r\n";
            TempStr = TempStr + "Drink                               $50.00\r\n\r\n";
            TempStr = TempStr + "Excluded tax                       $150.00\r\n";
            TempStr = TempStr + strUnderline;
            TempStr = TempStr + "Tax(5%)                              $7.50\r\n";
            TempStr = TempStr + strDoubleBold;
            TempStr = TempStr + "Total         $157.50\r\n\r\n";
            TempStr = TempStr + strNormal;
            TempStr = TempStr + "Payment                            $200.00\r\n";
            TempStr = TempStr + "Change                              $42.50\r\n\r\n";
            TempStr = TempStr + "==========================================\r\n";
            TempStr = TempStr + strNormal + strCenter;
            TempStr = TempStr + BarCodeHeight; // 바코드 높이
            TempStr = TempStr + BarCodeWidth; // 바코드 폭
            TempStr = TempStr + SetHRI; // HRI문자 인쇄위치 아래인쇄지정
            
            TempStr = TempStr + SetCode128B + "\x0e" + "\x7B\x42"; //14 => 인쇄할 바코드 자리수 + Code128b선택
            TempStr = TempStr + "abc456789012" + "\x0A"; // 인쇄할 바코드 데이타

            
            if(useprinterdriver)
	        {
		        m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
		        if(lResult != 0)
		        {
			        MessageBox.Show("OpenPrinter Failed","Error",MessageBoxButtons.OK);		
			        return;
		        }
	        }
            
            LKPrint.PrintStart();
            //LKPrint.PrintString(TempStr);
            LKPrint.PrintBitmap(".\\Logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, 0, 5, 0);

        //    PrintString(strCenter + "Test for PrintData Function\n");
        //    PrintData(strLeftPrintData, 3);
        //    PrintString("Test for PrintData Function\n");

            LKPrint.PrintString(PartialCut);

            LKPrint.PrintStop();
            
            if(useprinterdriver)
	        {
                lResult = LKPrint.ClosePort();
		        if(lResult != 0)
		        {
			        MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
		        }
	        }
        }

        private void printNormalButton_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
            long lResult;

            if (useprinterdriver)
            {
                m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
                if (lResult != 0)
                {
                    MessageBox.Show("OpenPrinter Failed","Error",MessageBoxButtons.OK);
                    return;
                }
            }
            
            LKPrint.PrintStart();

            LKPrint.PrintBitmap(".\\Logo.bmp", 1, 0, 5, 0); // Print Bitmap

            LKPrint.PrintNormal("\x1b|rATEL (123)-456-7890\n\n\n");
            LKPrint.PrintNormal("\x1b|cAThank you for coming to our shop!\n");
            LKPrint.PrintNormal("\x1b|cADate\n\n");
            LKPrint.PrintNormal("Chicken                             $10.00\n");
            LKPrint.PrintNormal("Hamburger                           $20.00\n");
            LKPrint.PrintNormal("Pizza                               $30.00\n");
            LKPrint.PrintNormal("Lemons                              $40.00\n");
            LKPrint.PrintNormal("Drink                               $50.00\n");
            LKPrint.PrintNormal("Excluded tax                       $150.00\n");
            LKPrint.PrintNormal("\x1b|uCTax(5%)                              $7.50\n");
            LKPrint.PrintNormal("\x1b|bC\x1b|2CTotal         $157.50\n\n");
            LKPrint.PrintNormal("Payment                            $200.00\n");
            LKPrint.PrintNormal("Change                              $42.50\n\n");
            LKPrint.PrintBarCode("1234567890", 109, 40, 512, 1, 2); // Print Barcode

            LKPrint.PrintBitmap(".\\LUKHAN-logo.bmp", 1, 0, 5, 1); // Print Bitmap

            LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.

            LKPrint.PrintStop();

            if (useprinterdriver)
            {
                lResult = LKPrint.ClosePort();
                if (lResult != 0)
                {
                    MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void printTextButton_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
            string BarData = "0123456789";
            long lResult;

            if (useprinterdriver)
            {
                m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
                if (lResult != 0)
                {
                    MessageBox.Show("Open Port Failed","Error",MessageBoxButtons.OK);
                    return;
                }
            }

            LKPrint.PrintStart();

            LKPrint.PrintText("Receipt\r\n\r\n\r\n", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_2WIDTH);
            LKPrint.PrintText("TEL (123)-456-7890\r\n", LKPrint.LK_ALIGNMENT_RIGHT, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintText("Thank you for coming to our shop!\r\n", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintText("Chicken                             $10.00\r\n", LKPrint.LK_ALIGNMENT_LEFT, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintText("Hamburger                           $20.00\r\n", LKPrint.LK_ALIGNMENT_LEFT, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintText("Pizza                               $30.00\r\n", LKPrint.LK_ALIGNMENT_LEFT, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintText("Lemons                              $40.00\r\n", LKPrint.LK_ALIGNMENT_LEFT, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintText("Drink                               $50.00\r\n\r\n", LKPrint.LK_ALIGNMENT_LEFT, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintText("Excluded tax                       $150.00\r\n", LKPrint.LK_ALIGNMENT_LEFT, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintText("Tax(5%)                              $7.50\r\n", LKPrint.LK_ALIGNMENT_LEFT, LKPrint.LK_FNT_UNDERLINE, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintText("Total         $157.50\r\n\r\n", LKPrint.LK_ALIGNMENT_LEFT, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_2WIDTH);
            LKPrint.PrintText("Payment                            $200.00\r\n", LKPrint.LK_ALIGNMENT_LEFT, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintText("Change                              $42.50\r\n\r\n", LKPrint.LK_ALIGNMENT_LEFT, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_1WIDTH);
            LKPrint.PrintBarCode(BarData, LKPrint.LK_BCS_Code39, 40, 512, LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_HRI_TEXT_BELOW);
            LKPrint.PrintBitmap(".\\Logo.bmp", LKPrint.LK_ALIGNMENT_RIGHT, LKPrint.LK_BITMAP_NORMAL, 5, 1);
            LKPrint.CutPaper();

            LKPrint.PrintStop();
            if (useprinterdriver)
            {
                lResult = LKPrint.ClosePort();
                if (lResult != 0)
                {
                    MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void printSampleButton_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
            long lResult;
            
            if (useprinterdriver)
            {
                m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
                if (lResult != 0)
                {
                    MessageBox.Show("OpenPrinter Failed","Error",MessageBoxButtons.OK);
                    return;
                }
            }

            LKPrint.PrintStart();

            LKPrint.PrintNormal("\x1b|cA\x1b|bC\x1b|2CLUKHAN\n");
            LKPrint.PrintNormal("Homepage : http://www.miniprinter.com\n");
            LKPrint.PrintNormal("==========================================\n");
            LKPrint.PrintNormal("Chicken                             $10.00\n");
            LKPrint.PrintNormal("Hamburger                           $20.00\n");
            LKPrint.PrintNormal("Pizza                               $30.00\n");
            LKPrint.PrintNormal("Lemons                              $40.00\n");
            LKPrint.PrintNormal("Drink                               $50.00\n");
            LKPrint.PrintNormal("Excluded tax                       $150.00\n");
            LKPrint.PrintNormal("\x1b|uCTax(5%)                              $7.50\n");
            LKPrint.PrintNormal("\x1b|bC\x1b|2CTotal         $157.50\n\n");
            LKPrint.PrintNormal("Payment                            $200.00\n");
            LKPrint.PrintNormal("Change                              $42.50\n\n");
            LKPrint.PrintNormal("------------------------------------------\n");
           

            // TTF Print
            LKPrint.PrintingWidth(512);
            LKPrint.SetMasterUnit(0);            
            LKPrint.SetLabelSize(512, 264); // height = 35mm = 248 + 16(QR Code Guard)
            LKPrint.PrintTTFAlign(1, 0, "Arial", 2, 32, "Center Alignment", 0); // TTF, 32-dot. Center align
            LKPrint.PrintTTFAlign(1, 50, "Arial", 1, 32, "101-01-02月TTF Font", 0); // TTF, 32-dot.
            LKPrint.PrintTTFXY(0, 100, "Arial", 2, 32, "AB-45627120", 0); // TTF, 32-dot.
            LKPrint.PrintTTFXY(0, 150, "Arial", 2, 24, "2012-02-03 00:00:04", 0); // TTF, 32-dot.
            LKPrint.PrintTTFXY(0, 186, "Arial", 2, 24, "test : 9999", 0); // TTF, 32-dot.
            LKPrint.PrintTTFXY(0, 222, "Arial", 2, 24, "Qty : 20", 0); // TTF, 32-dot.
            LKPrint.PrintQRCodeAlign(2, 150, "QRCode Test Right Alignment", 0, 4, 0, 0, -1); // auto version.
            LKPrint.PrintLabel();
            // end TTF Print

            // 
            LKPrint.PrintBarCode("1234567890", 109, 40, 512, 1, 2); // POSPrinter
            LKPrint.PrintBitmap(".\\LUKHAN-logo.bmp", 1, 0, 5, 1);
            LKPrint.PrintNormal("\x1b|fP");

            LKPrint.PrintStop();
            
            if (useprinterdriver)
            {
                lResult = LKPrint.ClosePort();
                if (lResult != 0)
                {
                    MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
                }
            }
        }


        private void getPrinterStatusButton_Click(object sender, EventArgs e)
        {
            long lResult = LKPrint.PrinterSts();
            switch (lResult)
            {
                case LKPrint.LK_STS_NORMAL:
                    MessageBox.Show("No Error", "OK", MessageBoxButtons.OK);
                    break;
                case LKPrint.LK_STS_COVEROPEN:
                    MessageBox.Show("Cover Open", "ERROR", MessageBoxButtons.OK);
                    break;
                case LKPrint.LK_STS_PAPERNEAREMPTY:
                    MessageBox.Show("Paper Near Empty", "ERROR", MessageBoxButtons.OK);
                    break;
                case LKPrint.LK_STS_PAPEREMPTY:
                    MessageBox.Show("Paper Empty", "ERROR", MessageBoxButtons.OK);
                    break;
                case LKPrint.LK_STS_POWEROFF:
                    MessageBox.Show("Power Off", "ERROR", MessageBoxButtons.OK);
                    break;
            }
        }


        // Barcode 2D
        private void printQRCodeCmdButton_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
	        long lResult;
            string strQRCodeLeft = "QRCode Test Left Alignment";
            string strQRCodeCenter = "QRCode Test Center Alignment";
            string strQRCodeRight = "QRCode Test Right Alignment";

            if(useprinterdriver)
	        {
                m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
		        if(lResult != 0)
		        {
			        MessageBox.Show("OpenPrinter Failed","Error",MessageBoxButtons.OK);		
			        return;
		        }
	        }

	        LKPrint.PrintStart();

            LKPrint.PrintQRCode(strQRCodeLeft, 0, 3, 0, LKPrint.LK_ALIGNMENT_LEFT);
            LKPrint.PrintQRCode(strQRCodeCenter, 0, 3, 0, LKPrint.LK_ALIGNMENT_CENTER);
            LKPrint.PrintQRCode(strQRCodeRight, 0, 3, 0, LKPrint.LK_ALIGNMENT_RIGHT);

            LKPrint.PrintBarCode("1234567890", 109, 40, 512, 1, 2); // POSPrinter
            LKPrint.PrintNormal("\x1b|fP");

            LKPrint.PrintStop();
            
	        if(useprinterdriver)
	        {
                lResult = LKPrint.ClosePort();
		        if(lResult != 0)
		        {
			        MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
		        }
	        }
        }

        private void saveQRCodeButton_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
            long lResult;
            string strQRCodeLeft = "QRCode Test Left Alignment";
            string strQRCodeCenter = "QRCode Test Center Alignment";
            string strQRCodeRight = "QRCode Test Right Alignment";

            
            if(useprinterdriver)
            {
                m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
	            if(lResult != 0)
	            {
		            MessageBox.Show("OpenPrinter Failed","Error",MessageBoxButtons.OK);		
		            return;
	            }
            }

            LKPrint.PrintStart();

            LKPrint.MakeQRCodeBitmap(strQRCodeLeft, 0, 3, 0, 0, -1, ".\\Left.bmp");
            LKPrint.MakeQRCodeBitmap(strQRCodeCenter, 0, 3, 0, 0, -1, ".\\Center.bmp");
            LKPrint.MakeQRCodeBitmap(strQRCodeRight, 0, 3, 0, 0, -1, ".\\Right.bmp");

            LKPrint.PrintBarCode("1234567890", 109, 40, 512, 1, 2); // POSPrinter
            LKPrint.PrintNormal("\x1b|fP");

            LKPrint.PrintStop();

            
            if(useprinterdriver)
            {
                lResult = LKPrint.ClosePort();
	            if(lResult != 0)
	            {
		            MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
	            }
            }
        }

        private void printQRCodeGenButton_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
	        long lResult;
            string strQRCodeLeft = "QRCode Test Left Alignment";
            string strQRCodeCenter = "QRCode Test Center Alignment";
//            string strQRCodeRight = "QRCode Test Right Alignment";

            
	        if(useprinterdriver)
	        {
                m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
		        if(lResult != 0)
		        {
			        MessageBox.Show("OpenPrinter Failed","Error",MessageBoxButtons.OK);		
			        return;
		        }
	        }

	        LKPrint.PrintStart();

            LKPrint.PrintQRCodeGenerator(strQRCodeLeft, 0, 3, 0, 0, -1, LKPrint.LK_ALIGNMENT_LEFT);
            LKPrint.PrintQRCodeGenerator(strQRCodeCenter, 0, 3, 0, 0, -1, LKPrint.LK_ALIGNMENT_CENTER);
            LKPrint.PrintQRCodeGenerator("QRCode Test Right Alignment", 0, 3, 0, 0, -1, LKPrint.LK_ALIGNMENT_RIGHT);
            LKPrint.PrintQRCodeGenerator("SEWOO TECH CO.,LTD%0D%0AR & D Department / Senior Engineer%0D%0AJimmy Oh", 0, 3, 0, 0, -1, LKPrint.LK_ALIGNMENT_CENTER);

	        LKPrint.PrintBarCode("1234567890", 109, 40, 512, 1, 2); // POSPrinter
	        LKPrint.PrintNormal("\x1b|fP");

            LKPrint.PrintStop();
            
            if(useprinterdriver)
	        {
                lResult = LKPrint.ClosePort();
		        if(lResult != 0)
		        {
			        MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
		        }
	        }
        }

        private void printQRCodeFileButton_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
            long lResult;
            
            if (useprinterdriver)
            {
                m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
                if (lResult != 0)
                {
                    MessageBox.Show("OpenPrinter Failed","Error",MessageBoxButtons.OK);
                    return;
                }
            }

            LKPrint.PrintStart();

            LKPrint.PrintQRCodeFromFile(".\\Email.txt", 3, 0, 0, -1, LKPrint.LK_ALIGNMENT_CENTER);

            LKPrint.PrintBarCode("1234567890", 109, 40, 512, 1, 2); // POSPrinter
            LKPrint.PrintNormal("\x1b|fP");

            LKPrint.PrintStop();
            
            if (useprinterdriver)
            {
                lResult = LKPrint.ClosePort();
                if (lResult != 0)
                {
                    MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void printPDF417Button_Click(object sender, EventArgs e)
        {
            // TODO: Add your control notification handler code here
            long lResult;
            
            if (useprinterdriver)
            {
                m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
                if (lResult != 0)
                {
                    MessageBox.Show("OpenPrinter Failed","Error",MessageBoxButtons.OK);
                    return;
                }
            }

            LKPrint.PrintStart();

            LKPrint.PrintString("PDF417 Column=8, Cell Width=2\n");
            LKPrint.PrintPDF417("0123456789", 0, 8, 2, 1);
            LKPrint.PrintString("PDF417 Column=8, Cell Width=3\n");
            LKPrint.PrintPDF417("0123456789", 0, 8, 3, 1);
            LKPrint.PrintString("PDF417 Column=4, Cell Width=2\n");
            LKPrint.PrintPDF417("0123456789", 0, 4, 2, 2);
            LKPrint.PrintString("PDF417 Column=4, Cell Width=3\n");
            LKPrint.PrintPDF417("0123456789", 0, 4, 3, 2);

            LKPrint.PrintBarCode("1234567890", 109, 40, 512, 1, 2); // POSPrinter
            LKPrint.PrintNormal("\x1b|fP");

            LKPrint.PrintStop();
            
            if (useprinterdriver)
            {
                lResult = LKPrint.ClosePort();
                if (lResult != 0)
                {
                    MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void useDriverCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useDriverCheckBox.Checked)
            {
                useprinterdriver = true;
                pDriverNameTextBox.Enabled = true;
                portNameCBox.Enabled = false;
                baudRateCBox.Enabled = false;
                openButton.Enabled = false;
                closeButton.Enabled = false;
                cashDrawerOpenButton.Enabled = true;
                getCashDrawerStatusButton.Enabled = false;
                printStringButton.Enabled = true;
                printNormalButton.Enabled = true;
                printTextButton.Enabled = true;
                printSampleButton.Enabled = true;
                getPrinterStatusButton.Enabled = false;
                printQRCodeCmdButton.Enabled = true;
                saveQRCodeButton.Enabled = true;
                printQRCodeGenButton.Enabled = true;
                printQRCodeFileButton.Enabled = true;
                printPDF417Button.Enabled = true;

                txtIP.Enabled = false;
            }
            else 
            {
                useprinterdriver = false;
                pDriverNameTextBox.Enabled = false;
                portNameCBox.Enabled = true;
                openButton.Enabled = true;
                closeButton.Enabled = false;
                cashDrawerOpenButton.Enabled = false;
                getCashDrawerStatusButton.Enabled = false;
                printStringButton.Enabled = false;
                printNormalButton.Enabled = false;
                printTextButton.Enabled = false;
                printSampleButton.Enabled = false;
                getPrinterStatusButton.Enabled = false;
                printQRCodeCmdButton.Enabled = false;
                saveQRCodeButton.Enabled = false;
                printQRCodeGenButton.Enabled = false;
                printQRCodeFileButton.Enabled = false;
                printPDF417Button.Enabled = false;

                int sIndex = portNameCBox.SelectedIndex;
                if (sIndex == 8)
                {
                    baudRateCBox.Enabled = false;
                    txtIP.Enabled = true;
                }
                else
                {
                    baudRateCBox.Enabled = true;
                    txtIP.Enabled = false;
                }
            }
        }
                
    }
}
