namespace LKCSTest
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.getCashDrawerStatusButton = new System.Windows.Forms.Button();
            this.cashDrawerOpenButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.printPDF417Button = new System.Windows.Forms.Button();
            this.printQRCodeFileButton = new System.Windows.Forms.Button();
            this.printQRCodeGenButton = new System.Windows.Forms.Button();
            this.saveQRCodeButton = new System.Windows.Forms.Button();
            this.printQRCodeCmdButton = new System.Windows.Forms.Button();
            this.getPrinterStatusButton = new System.Windows.Forms.Button();
            this.printSampleButton = new System.Windows.Forms.Button();
            this.printTextButton = new System.Windows.Forms.Button();
            this.printNormalButton = new System.Windows.Forms.Button();
            this.printStringButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.baudRateCBox = new System.Windows.Forms.ComboBox();
            this.portNameCBox = new System.Windows.Forms.ComboBox();
            this.pDriverNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.useDriverCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pDriverNameTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.useDriverCheckBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 415);
            this.panel1.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtIP);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(16, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 53);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ethernet";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(50, 20);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(155, 21);
            this.txtIP.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP : ";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(15, 355);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(227, 51);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.getCashDrawerStatusButton);
            this.groupBox3.Controls.Add(this.cashDrawerOpenButton);
            this.groupBox3.Location = new System.Drawing.Point(14, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 95);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cash Drawer";
            // 
            // getCashDrawerStatusButton
            // 
            this.getCashDrawerStatusButton.Location = new System.Drawing.Point(6, 56);
            this.getCashDrawerStatusButton.Name = "getCashDrawerStatusButton";
            this.getCashDrawerStatusButton.Size = new System.Drawing.Size(216, 30);
            this.getCashDrawerStatusButton.TabIndex = 1;
            this.getCashDrawerStatusButton.Text = "Get Cash Drawer Status";
            this.getCashDrawerStatusButton.UseVisualStyleBackColor = true;
            this.getCashDrawerStatusButton.Click += new System.EventHandler(this.getCashDrawerStatusButton_Click);
            // 
            // cashDrawerOpenButton
            // 
            this.cashDrawerOpenButton.Location = new System.Drawing.Point(6, 20);
            this.cashDrawerOpenButton.Name = "cashDrawerOpenButton";
            this.cashDrawerOpenButton.Size = new System.Drawing.Size(216, 30);
            this.cashDrawerOpenButton.TabIndex = 0;
            this.cashDrawerOpenButton.Text = "Cash Drawer Open";
            this.cashDrawerOpenButton.UseVisualStyleBackColor = true;
            this.cashDrawerOpenButton.Click += new System.EventHandler(this.cashDrawerOpenButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.printPDF417Button);
            this.groupBox2.Controls.Add(this.printQRCodeFileButton);
            this.groupBox2.Controls.Add(this.printQRCodeGenButton);
            this.groupBox2.Controls.Add(this.saveQRCodeButton);
            this.groupBox2.Controls.Add(this.printQRCodeCmdButton);
            this.groupBox2.Controls.Add(this.getPrinterStatusButton);
            this.groupBox2.Controls.Add(this.printSampleButton);
            this.groupBox2.Controls.Add(this.printTextButton);
            this.groupBox2.Controls.Add(this.printNormalButton);
            this.groupBox2.Controls.Add(this.printStringButton);
            this.groupBox2.Location = new System.Drawing.Point(261, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 354);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "POS Printer";
            // 
            // printPDF417Button
            // 
            this.printPDF417Button.Location = new System.Drawing.Point(6, 310);
            this.printPDF417Button.Name = "printPDF417Button";
            this.printPDF417Button.Size = new System.Drawing.Size(230, 30);
            this.printPDF417Button.TabIndex = 11;
            this.printPDF417Button.Text = "Print PDF417";
            this.printPDF417Button.UseVisualStyleBackColor = true;
            this.printPDF417Button.Click += new System.EventHandler(this.printPDF417Button_Click);
            // 
            // printQRCodeFileButton
            // 
            this.printQRCodeFileButton.Location = new System.Drawing.Point(6, 270);
            this.printQRCodeFileButton.Name = "printQRCodeFileButton";
            this.printQRCodeFileButton.Size = new System.Drawing.Size(230, 30);
            this.printQRCodeFileButton.TabIndex = 10;
            this.printQRCodeFileButton.Text = "Print QRCode from file(QR Generator)";
            this.printQRCodeFileButton.UseVisualStyleBackColor = true;
            this.printQRCodeFileButton.Click += new System.EventHandler(this.printQRCodeFileButton_Click);
            // 
            // printQRCodeGenButton
            // 
            this.printQRCodeGenButton.Location = new System.Drawing.Point(6, 238);
            this.printQRCodeGenButton.Name = "printQRCodeGenButton";
            this.printQRCodeGenButton.Size = new System.Drawing.Size(230, 30);
            this.printQRCodeGenButton.TabIndex = 9;
            this.printQRCodeGenButton.Text = "Print QRCode(QR Generator)";
            this.printQRCodeGenButton.UseVisualStyleBackColor = true;
            this.printQRCodeGenButton.Click += new System.EventHandler(this.printQRCodeGenButton_Click);
            // 
            // saveQRCodeButton
            // 
            this.saveQRCodeButton.Location = new System.Drawing.Point(6, 207);
            this.saveQRCodeButton.Name = "saveQRCodeButton";
            this.saveQRCodeButton.Size = new System.Drawing.Size(230, 30);
            this.saveQRCodeButton.TabIndex = 8;
            this.saveQRCodeButton.Text = "Save QRCode(QR Generator)";
            this.saveQRCodeButton.UseVisualStyleBackColor = true;
            this.saveQRCodeButton.Click += new System.EventHandler(this.saveQRCodeButton_Click);
            // 
            // printQRCodeCmdButton
            // 
            this.printQRCodeCmdButton.Location = new System.Drawing.Point(6, 176);
            this.printQRCodeCmdButton.Name = "printQRCodeCmdButton";
            this.printQRCodeCmdButton.Size = new System.Drawing.Size(230, 30);
            this.printQRCodeCmdButton.TabIndex = 7;
            this.printQRCodeCmdButton.Text = "Print QRCode(Command)";
            this.printQRCodeCmdButton.UseVisualStyleBackColor = true;
            this.printQRCodeCmdButton.Click += new System.EventHandler(this.printQRCodeCmdButton_Click);
            // 
            // getPrinterStatusButton
            // 
            this.getPrinterStatusButton.Location = new System.Drawing.Point(6, 140);
            this.getPrinterStatusButton.Name = "getPrinterStatusButton";
            this.getPrinterStatusButton.Size = new System.Drawing.Size(230, 30);
            this.getPrinterStatusButton.TabIndex = 6;
            this.getPrinterStatusButton.Text = "Get Printer Status";
            this.getPrinterStatusButton.UseVisualStyleBackColor = true;
            this.getPrinterStatusButton.Click += new System.EventHandler(this.getPrinterStatusButton_Click);
            // 
            // printSampleButton
            // 
            this.printSampleButton.Location = new System.Drawing.Point(6, 109);
            this.printSampleButton.Name = "printSampleButton";
            this.printSampleButton.Size = new System.Drawing.Size(230, 30);
            this.printSampleButton.TabIndex = 5;
            this.printSampleButton.Text = "Print Sample";
            this.printSampleButton.UseVisualStyleBackColor = true;
            this.printSampleButton.Click += new System.EventHandler(this.printSampleButton_Click);
            // 
            // printTextButton
            // 
            this.printTextButton.Location = new System.Drawing.Point(6, 78);
            this.printTextButton.Name = "printTextButton";
            this.printTextButton.Size = new System.Drawing.Size(230, 30);
            this.printTextButton.TabIndex = 4;
            this.printTextButton.Text = "Print Text";
            this.printTextButton.UseVisualStyleBackColor = true;
            this.printTextButton.Click += new System.EventHandler(this.printTextButton_Click);
            // 
            // printNormalButton
            // 
            this.printNormalButton.Location = new System.Drawing.Point(6, 47);
            this.printNormalButton.Name = "printNormalButton";
            this.printNormalButton.Size = new System.Drawing.Size(230, 30);
            this.printNormalButton.TabIndex = 3;
            this.printNormalButton.Text = "Print Normal";
            this.printNormalButton.UseVisualStyleBackColor = true;
            this.printNormalButton.Click += new System.EventHandler(this.printNormalButton_Click);
            // 
            // printStringButton
            // 
            this.printStringButton.Location = new System.Drawing.Point(6, 16);
            this.printStringButton.Name = "printStringButton";
            this.printStringButton.Size = new System.Drawing.Size(230, 30);
            this.printStringButton.TabIndex = 2;
            this.printStringButton.Text = "Print String";
            this.printStringButton.UseVisualStyleBackColor = true;
            this.printStringButton.Click += new System.EventHandler(this.printStringButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.closeButton);
            this.groupBox1.Controls.Add(this.openButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.baudRateCBox);
            this.groupBox1.Controls.Add(this.portNameCBox);
            this.groupBox1.Location = new System.Drawing.Point(14, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 134);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Information";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(123, 90);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(90, 31);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(20, 90);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(90, 31);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "BaudRate :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port Name :";
            // 
            // baudRateCBox
            // 
            this.baudRateCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRateCBox.FormattingEnabled = true;
            this.baudRateCBox.Location = new System.Drawing.Point(108, 53);
            this.baudRateCBox.Name = "baudRateCBox";
            this.baudRateCBox.Size = new System.Drawing.Size(105, 20);
            this.baudRateCBox.TabIndex = 1;
            // 
            // portNameCBox
            // 
            this.portNameCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portNameCBox.FormattingEnabled = true;
            this.portNameCBox.Location = new System.Drawing.Point(108, 20);
            this.portNameCBox.Name = "portNameCBox";
            this.portNameCBox.Size = new System.Drawing.Size(105, 20);
            this.portNameCBox.TabIndex = 0;
            this.portNameCBox.SelectedIndexChanged += new System.EventHandler(this.portNameCBox_SelectedIndexChanged);
            // 
            // pDriverNameTextBox
            // 
            this.pDriverNameTextBox.Location = new System.Drawing.Point(354, 18);
            this.pDriverNameTextBox.Name = "pDriverNameTextBox";
            this.pDriverNameTextBox.Size = new System.Drawing.Size(135, 21);
            this.pDriverNameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Printer Driver Name :";
            // 
            // useDriverCheckBox
            // 
            this.useDriverCheckBox.AutoSize = true;
            this.useDriverCheckBox.Location = new System.Drawing.Point(14, 18);
            this.useDriverCheckBox.Name = "useDriverCheckBox";
            this.useDriverCheckBox.Size = new System.Drawing.Size(151, 16);
            this.useDriverCheckBox.TabIndex = 0;
            this.useDriverCheckBox.Text = "Using the printer driver";
            this.useDriverCheckBox.UseVisualStyleBackColor = true;
            this.useDriverCheckBox.CheckedChanged += new System.EventHandler(this.useDriverCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 432);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "POS Printer TEST Program (C#)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox useDriverCheckBox;
        private System.Windows.Forms.TextBox pDriverNameTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button getCashDrawerStatusButton;
        private System.Windows.Forms.Button cashDrawerOpenButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button printSampleButton;
        private System.Windows.Forms.Button printTextButton;
        private System.Windows.Forms.Button printNormalButton;
        private System.Windows.Forms.Button printStringButton;
        private System.Windows.Forms.Button saveQRCodeButton;
        private System.Windows.Forms.Button printQRCodeCmdButton;
        private System.Windows.Forms.Button getPrinterStatusButton;
        private System.Windows.Forms.Button printPDF417Button;
        private System.Windows.Forms.Button printQRCodeFileButton;
        private System.Windows.Forms.Button printQRCodeGenButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox baudRateCBox;
        private System.Windows.Forms.ComboBox portNameCBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label4;
    }
}

