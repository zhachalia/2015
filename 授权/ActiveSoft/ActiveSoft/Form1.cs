using ActiveClient.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveClient.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string s = "";
            //s +=  ComputerInfo.Instance().CpuID + "$$";
            //s += ComputerInfo.Instance().DiskID + "$$";
            //s += ComputerInfo.Instance().MacAddress + "$$";
            //s += ComputerInfo.Instance().BaseBoardID + "$$";
            //s += ComputerInfo.Instance().BIOSID;
            //textBox1.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SecurityUtil su = new SecurityUtil();
            textBox2.Text = su.Base64Encode(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SecurityUtil su = new SecurityUtil();
            textBox3.Text = su.Base64Decode(textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SecurityUtil su = new SecurityUtil();
            textBox2.Text = su.EncryptDES(textBox1.Text,"zhang999");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SecurityUtil su = new SecurityUtil();
            textBox3.Text = su.DecryptDES(textBox2.Text, "zhang999");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SecurityUtil su = new SecurityUtil();
            textBox2.Text = su.SHA1_Hash(textBox1.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SecurityUtil su = new SecurityUtil();
            textBox3.Text = su.MD5_Hash(textBox1.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WebRequestUtil wr = new WebRequestUtil();
            textBox3.Text = wr.webquers2("http://localhost:13755/Active1.ashx", textBox2.Text);
        }
    }
}
