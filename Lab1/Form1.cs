using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void enteringFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();
            string path = @"J:\Compilater2.txt";
            if (Open.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fstream = File.OpenRead(Open.FileName))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    richTextBoxInPut.Text = System.Text.Encoding.Default.GetString(array);
                }
            }
        }

        private void startProcess_Click(object sender, EventArgs e)
        {
            string mainText = richTextBoxInPut.Text.ToLower();
            Process prc = new Process();
            List<frame> res = prc.sytaxisAnalysis(mainText);
            foreach (frame elem in res)
            {
                richTextBox1.Text += elem.word + " " + elem.type + "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i= 0; i < Process.iCollection.Count; i++)
            {
                richTextBox4.Text += i + " " + Process.iCollection[i] + "\n";
            }
            for (int i = 0; i < Process.lCollection.Count; i++)
            {
                richTextBox5.Text += i + " " + Process.lCollection[i] + "\n";
            }
            for (int i = 0; i < Process.r.Length; i++)
            {
                richTextBox3.Text += i + " " + Process.r[i] + "\n";
            }
            for (int i = 0; i < Process.kw.Length; i++)
            {
                richTextBox2.Text += i + " " + Process.kw[i] + " встречено " + Process.countOfKW[i] + " раз" + "\n";
            }
            List<string> temp = new List<string>();
            temp = Process.scaning();
            for (int i = 0; i<temp.Count;i++)
            {
                richTextBox6.Text += temp[i] + "\n";
            }
        }
    }
}
