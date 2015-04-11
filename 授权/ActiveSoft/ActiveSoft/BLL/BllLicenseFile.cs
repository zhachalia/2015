using ActiveClient.Common;
using ActiveClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveSoft.BLL
{
    public class BllLicenseFile
    {
        static string LicenseFileName = "log41net.dll";
        public static bool WriteFile(string codeStr,ResultModel result)
        {
            try
            {
                string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LicenseFileName);
                using (TextWriter tw = new StreamWriter(fileName, false))
                {
                    tw.WriteLine(EncodeLicense(codeStr));//注册码
                    tw.WriteLine(EncodeLicense(result.Info));
                    string allow_start_date = "";
                    if (result.AllowStartDate!=null)
                    {
                        allow_start_date = result.AllowStartDate.ToString("yyyy-MM-dd");
                    }
                    tw.WriteLine(EncodeLicense(allow_start_date));//开始日期

                    string allow_end_date = "";
                    if (result.AllowEndDate != null)
                    {
                        allow_end_date = result.AllowEndDate.ToString("yyyy-MM-dd");
                    }
                    tw.WriteLine(EncodeLicense(allow_end_date));//结束日期
                    tw.WriteLine(EncodeLicense(DateTime.Now.ToString("yyyy-MM-dd")));//当次日期
                }
                return true;
            }
            catch (Exception se)
            {
                return false;
            }
        }

        public static bool IsActive(ref string reInfo)
        { 
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LicenseFileName);
            if (!File.Exists(fileName))
            {
                reInfo = "软件未注册！";
                return false;
            }
            //读取License
            try
            {
                string codeStr = "";
                string license = "";
                string allow_start_date = "";
                string allow_end_date = "";
                string last_date_str;
                DateTime lastDate;

                
                using (TextReader tw = new StreamReader(fileName))
                {
                    codeStr = tw.ReadLine();
                    codeStr = DecodeLicense(codeStr);
                    license = tw.ReadLine();
                    license = DecodeLicense(license);

                    allow_start_date = tw.ReadLine();
                    allow_start_date = DecodeLicense(allow_start_date);

                    allow_end_date = tw.ReadLine();
                    allow_end_date = DecodeLicense(allow_end_date);

                    last_date_str=tw.ReadLine();
                    last_date_str = DecodeLicense(last_date_str);
                    lastDate = DateTime.Parse(last_date_str);
                }

                if (lastDate > DateTime.Now)
                {
                    reInfo = "本地系统日期不正确";
                    return false;
                }

                SecurityUtil su = new SecurityUtil();
                ComputerInfoModel computerInfo = BllComputerInfo.GetCurentComputerInfo();
                string user_computer = BllComputerInfo.GetComputerIntoStr(computerInfo);
                string activeLience = su.SHA1_Hash(user_computer);

                if( DateTime.Parse(allow_end_date) < DateTime.Now)
                {
                     reInfo = "软件有效期已过";
                    return false;
                }
                if (license == activeLience)
                {
                    return true;
                }
                else
                {
                    reInfo = "软件未正确注册";
                    return false;
                }              
            }
            catch (Exception se)
            {
                reInfo = "软件未正确注册";
                return false;
            }
        }

        const string PWD_KEY_LICENSE = "ZHANG1CL";
        public static string EncodeLicense(string str)
        {
            SecurityUtil su = new SecurityUtil();
            return su.EncryptDES(str, PWD_KEY_LICENSE);
        }

        public static string DecodeLicense(string str)
        {
            SecurityUtil su = new SecurityUtil();
            return su.DecryptDES(str, PWD_KEY_LICENSE);
        }
    }
}
