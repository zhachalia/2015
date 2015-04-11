using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// BllUserInfo 的摘要说明
/// </summary>
public class BllUserInfo
{
    static int VALID_SAME_ITEMS_COUNT = 2;//五项中两项计算机指纹相同代表是同一台计算机，允许重复注册

	public BllUserInfo()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static UserInfoModel GetUserInfo(string jsonData)
    {
        //List<UserInfoModel> list = JSONHelper.parse<List<UserInfoModel>>(jsonData);
        //if (list != null && list.Count > 0)
        //{
        //    return list[0];
        //}
        //else
        //{
        //    return null;
        //}

        UserInfoModel userInfo= JSONHelper.parse<UserInfoModel>(jsonData);
        //if (list != null && list.Count > 0)
        //{
        //    return list[0];
        //}
        //else
        //{
        //    return null;
        //}
        return userInfo;
    }

    /// <summary>
    /// 根据错误编号返回错误信息
    /// </summary>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    public static string GetErrorInfo(int errorCode)
    {
        string errorInfo = "未知错误";
        switch (errorCode)
        {
            case -10: errorInfo = "本地日期设置不正确";
                break;
            case -11: errorInfo = "数据异常1";
                break;
            case -12: errorInfo = "数据异常2";
                break;
            case -13: errorInfo = "无效注册码1";//无此注册码
                break;
            case -14: errorInfo = "无效注册码2";//注册码失效
                break;
            case -15: errorInfo = "无效注册码3";//注册码有效期失效
                break;
            case -31: errorInfo = "无效注册码4";//此注册码已经注册
                break;
        }
        return errorInfo;
    }

    /// <summary>
    /// 校验注册码
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    public static int ValidCodeStr(UserInfoModel userInfo, out CodeModel cm)
    {
        cm = null;
        if (userInfo.ClientDate.Date != DateTime.Now.Date) return -10;//客户端日期设置不正确
        if (userInfo == null) return -11;//数据异常1
        if (string.IsNullOrEmpty(userInfo.code_str)) return -12;//数据异常2
        DataTable dt = DACodeStr.GetCodeStr(userInfo.code_str);
        if (dt == null || dt.Rows.Count == 0) return -13;//无此注册码

        cm = BllCode.GenCodeModel(dt.Rows[0]);

        //判断注册码有效性
        if (cm.code_valid != 1) return -14;//注册码失效

        //判断注册码有效期
        if (cm.code_date_end!=null && cm.code_date_end < DateTime.Now.AddDays(1))
        {
            return -15;//注册码有效期失效
        }

        //判断是否已有用户
        if (IsOldUser(userInfo))
        {
            //有效老用户

            //判断注册码类型10-正常；20-试用
            //int code_type = int.Parse(dt.Rows[0]["code_type"].ToString());
            //if (code_type == 20) return -21;//试用版不允许二次注册

            return 100;//允许正常注册
        }
        else
        { 
            //判断注册码注册次数是否已满
            if (cm.code_used_computers >= cm.code_enable_computers) return -31;//此注册码已经注册

            return 200;//有效新用户
        }
    }

    //判断是否已有用户
    private static bool IsOldUser(UserInfoModel userInfo)
    {
        bool r = false;
        DataTable dt = DAUserInfo.GetUserInfo(userInfo.code_str);
        if (dt != null&& dt.Rows.Count > 0)       
        {
            foreach (DataRow dr in dt.Rows)
            {
                string user_computer = dr["user_computer"].ToString();
                ComputerInfoModel computerInfoExisted = GenComputerInfo(user_computer);
                if (IsSameComputer(userInfo.computer_info_model, computerInfoExisted))//是老用户
                {
                    r = true;
                    break;
                }
            }
        }
        return r;
    }

    /// <summary>
    /// 从计算机指纹字符串提取数据
    /// </summary>
    /// <param name="user_computer"></param>
    /// <returns></returns>
    static ComputerInfoModel GenComputerInfo(string user_computer)
    {
        ComputerInfoModel computerInfo = new ComputerInfoModel();        
        //string[] strs = Regex.Split(user_computer, "$$", RegexOptions.IgnoreCase);

        string[] strs = user_computer.Split(new string[] { "$$" }, StringSplitOptions.None);
       // string[] strs = user_computer.Split("$$".ToArray());
        if (strs.Length >= 5)
        {
            computerInfo.CpuID = strs[0];
            computerInfo.DiskID = strs[1];
            computerInfo.MacAddress = strs[2];
            computerInfo.BaseBoardID = strs[3];
            computerInfo.BIOSID = strs[4];
        }
        return computerInfo;
    }

    /// <summary>
    /// 判断两个计算机指纹是否来自同一台计算机
    /// </summary>
    /// <param name="computerInfo1"></param>
    /// <param name="computerInfo2"></param>
    /// <returns></returns>
    static bool IsSameComputer(ComputerInfoModel computerInfo1, ComputerInfoModel computerInfo2)
    {
        int sameItems = 0;//相同项数量
        if (computerInfo1.CpuID == computerInfo2.CpuID) sameItems++;
        if (computerInfo1.DiskID == computerInfo2.DiskID) sameItems++;
        if (computerInfo1.MacAddress == computerInfo2.MacAddress) sameItems++;
        if (computerInfo1.BaseBoardID == computerInfo2.BaseBoardID) sameItems++;
        if (computerInfo1.BIOSID == computerInfo2.BIOSID) sameItems++;

        if (sameItems >= VALID_SAME_ITEMS_COUNT)//两项计算机指纹相同代表是同一台计算机，允许重复注册
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 获得结果的json
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static string GetResultJsonStr(ResultModel result)
    {
        return JSONHelper.stringify(result);
    }
}