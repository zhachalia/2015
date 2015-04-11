using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";

            for (int i = 0; i < int.Parse(textBox1.Text); i++)
            {
                textBox2.Text += GenOne()+"\r\n";
            }                  
        }

        string GenOne()
        {
            string codes = "ABCDEFGHJKMNPKRSTUVWXYZ23456789";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int index = r.Next(0, 31);
                    sb.Append(codes[index]);
                }
                if (i < 4)
                {
                    sb.Append("-");
                }
            }
            return sb.ToString();
        }
    }
}
