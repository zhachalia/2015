<%@ WebHandler Language="C#" Class="Active1" %>

using System;
using System.Web;
using System.IO;
using System.Collections.Generic;

public class Active1 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        try
        {
            StreamReader sr = new StreamReader(context.Request.InputStream);
            string input = sr.ReadToEnd();
            if (!string.IsNullOrEmpty(input))
            {
                SecurityUtil su = new SecurityUtil();
                string jsonData = su.Base64Decode(input);//解密

                LogHelper.WriteLog(context.Request.UserHostAddress + ";" + context.Request.UserHostName, jsonData);//写日志

                //获取信息
                CodeModel cm = null;
                UserInfoModel userInfo = BllUserInfo.GetUserInfo(jsonData);
                int re = BllUserInfo.ValidCodeStr(userInfo, out cm);

                ResultModel result = new ResultModel();
                result.InfoCode = re;
                if (re == 100 || re == 200)//有效老用户,//有效新用户
                {
                    result.Success = 1;
                    //写入注册信息

                    result.Info = su.SHA1_Hash(userInfo.user_computer);

                    result.AllowStartDate = cm.code_date_start;
                    result.AllowDateLen = cm.code_date_len;
                    result.AllowEndDate = cm.code_date_end;
                }
                else
                {
                    result.Success = -1;
                    result.Info = BllUserInfo.GetErrorInfo(re);
                    result.AllowStartDate = DateTime.Now;
                    result.AllowDateLen = 0;
                    result.AllowEndDate = DateTime.Now;
                }

                if (re == 200)//新用户
                { 
                    //写入用户信息表
                    DAUserInfo.Insert(userInfo);
                    DACodeStr.AddUsedTime(userInfo.code_str);
                }
                
                //JSON转换
                string jsonResultStr = BllUserInfo.GetResultJsonStr(result);

                //加密
                string jsonResultStrEncode = su.Base64Encode(jsonResultStr);
              
                context.Response.Write(jsonResultStrEncode);
            }
            else
            {
                
                context.Response.Write("NULL");
            }
        }
        catch (Exception se)
        {
            LogHelper.WriteLog("ERROR", se.Message+se.StackTrace);
            context.Response.Write("ERROR");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}