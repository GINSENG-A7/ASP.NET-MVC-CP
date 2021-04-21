namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.enteringFromFile = new System.Windows.Forms.Button();
            this.startProcess = new System.Windows.Forms.Button();
            this.richTextBoxInPut = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // enteringFromFile
            // 
            this.enteringFromFile.Location = new System.Drawing.Point(11, 533);
            this.enteringFromFile.Name = "enteringFromFile";
            this.enteringFromFile.Size = new System.Drawing.Size(95, 28);
            this.enteringFromFile.TabIndex = 0;
            this.enteringFromFile.Text = "Ввести";
            this.enteringFromFile.UseVisualStyleBackColor = true;
            this.enteringFromFile.Click += new System.EventHandler(this.enteringFromFile_Click);
            // 
            // startProcess
            // 
            this.startProcess.Location = new System.Drawing.Point(813, 533);
            this.startProcess.Name = "startProcess";
            this.startProcess.Size = new System.Drawing.Size(250, 28);
            this.startProcess.TabIndex = 1;
            this.startProcess.Text = "Обработать";
            this.startProcess.UseVisualStyleBackColor = true;
            this.startProcess.Click += new System.EventHandler(this.startProcess_Click);
            // 
            // richTextBoxInPut
            // 
            this.richTextBoxInPut.Location = new System.Drawing.Point(11, 7);
            this.richTextBoxInPut.Name = "richTextBoxInPut";
            this.richTextBoxInPut.Size = new System.Drawing.Size(1052, 91);
            this.richTextBoxInPut.TabIndex = 2;
            this.richTextBoxInPut.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(813, 104);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(250, 423);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 534);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Сканировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(642, 119);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(165, 168);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(642, 308);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(165, 168);
            this.richTextBox3.TabIndex = 8;
            this.richTextBox3.Text = "";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(471, 119);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(165, 168);
            this.richTextBox4.TabIndex = 9;
            this.richTextBox4.Text = "";
            // 
            // richTextBox5
            // 
            this.richTextBox5.Location = new System.Drawing.Point(471, 308);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(165, 168);
            this.richTextBox5.TabIndex = 10;
            this.richTextBox5.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Индетификаторы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ключевые слова";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Литералы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(639, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Разделители";
            // 
            // richTextBox6
            // 
            this.richTextBox6.Location = new System.Drawing.Point(204, 104);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.Size = new System.Drawing.Size(261, 423);
            this.richTextBox6.TabIndex = 15;
            this.richTextBox6.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 573);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.richTextBoxInPut);
            this.Controls.Add(this.startProcess);
            this.Controls.Add(this.enteringFromFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enteringFromFile;
        private System.Windows.Forms.Button startProcess;
        private System.Windows.Forms.RichTextBox richTextBoxInPut;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox6;
    }
}

