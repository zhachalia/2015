using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
/// <summary>
/// Log 的摘要说明
/// </summary>
public class LogHelper
{
    public LogHelper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static void  WriteLog(string userInfo,string str)
    {
        try
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log\\log"+DateTime.Now.ToString("yyyy-MM-dd")+".txt");
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            using (TextWriter tw = new StreamWriter(fileName, true))
            {
                tw.WriteLine(DateTime.Now.ToString() + ":" + userInfo);
                tw.WriteLine(str);
                tw.Close();
            }
        }
        finally { }
    }
}