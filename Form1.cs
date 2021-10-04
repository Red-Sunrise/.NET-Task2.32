using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string name;

        private void openFile(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(name);
                SeparateButton.Enabled = true;
            }
        }
        private string processText()
        {
            string text = textBox1.Text;
            string result = "\r\nСанкция\r\n";
            result += text.Substring(text.IndexOf("наказыва", 0,StringComparison.CurrentCultureIgnoreCase));
            return result;
        }

        private void saveFile(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox1.Text);
            }
        }

        private void SeparateSanction(object sender, EventArgs e)
        {
            textBox1.Text += processText();
            SeparateButton.Enabled = false;
        }
    }
}
