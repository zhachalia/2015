using ActiveClient.Common;
using ActiveClient.Model;
using ActiveSoft.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveSoft
{
    public partial class FormActive : Form
    {
        public FormActive()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("注册码不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("姓名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("组织不能为空！");
                return;
            }

            try
            {
                string codeStr = textBox1.Text.Trim();
                //获取电脑信息和电脑指纹
                UserInfoModel userInfo = new UserInfoModel();
                userInfo.code_str = codeStr;
                userInfo.reg_computer_ip = ComputerHelper.Instance().IpAddress;
                userInfo.reg_computer_name = ComputerHelper.Instance().ComputerName;
                userInfo.reg_desc = "";
                userInfo.reg_state = 0;
                userInfo.reg_time = DateTime.Now;
                userInfo.user_name = textBox2.Text.Trim();
                userInfo.user_org = textBox3.Text.Trim();
                userInfo.ClientDate = DateTime.Now;

                ComputerInfoModel computerInfo = BllComputerInfo.GetCurentComputerInfo();
               
                userInfo.computer_info_model = computerInfo;

                userInfo.user_computer = BllComputerInfo.GetComputerIntoStr(computerInfo);

                //JSON
                string jsonData = JSONHelper.stringify(userInfo);

                //加密
                SecurityUtil su = new SecurityUtil();
                string jsonDataEncode = su.Base64Encode(jsonData);

                //请求
                WebRequestUtil wr = new WebRequestUtil();
                string serverUrl = ConfigurationManager.AppSettings["server1"];
                string reStr = wr.webquers2(serverUrl+"/Active1.ashx", jsonDataEncode);

                if (string.IsNullOrEmpty(reStr) || reStr == "NULL" || reStr == "ERROR")
                {
                    MessageBox.Show("程序异常2："+reStr);
                }
                else
                { 
                    //解密
                    string reJsonData = su.Base64Decode(reStr);

                    //json
                    ResultModel result = JSONHelper.parse<ResultModel>(reJsonData);
                    if (result == null)
                    {
                        MessageBox.Show("程序异常3：NULL");
                    }
                    else
                    {
                        if (result.Success == 1)//成功
                        { 
                            //写入注册文件
                            BllLicenseFile.WriteFile(codeStr,result);
                            MessageBox.Show("注册成功！");
                        }
                        else//失败
                        {
                            MessageBox.Show("注册失败：" + result.InfoCode + "，" + result.Info);
                        }
                    }
                }
            }
            catch (Exception se)
            {
                MessageBox.Show("程序异常1："+se.Message);
            }

            ShowActiveInfo();

        }

        private void FormActive_Load(object sender, EventArgs e)
        {
            ShowActiveInfo();
        }

        void ShowActiveInfo()
        {
            string reInfo = "";
            bool isActive = BllLicenseFile.IsActive(ref reInfo);
            if (isActive)
            {
                label7.Text = "此软件已经注册！";
                label7.ForeColor = Color.Green;
                //button1.Enabled = false;
            }
            else
            {
                label7.Text = reInfo;
                label7.ForeColor = Color.Red;
            }
        }
        
    }
}
