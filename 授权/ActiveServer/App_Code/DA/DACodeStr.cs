using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// DACodeStr 的摘要说明
/// </summary>
public class DACodeStr
{
	public DACodeStr()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 获取注册码
    /// </summary>
    /// <param name="codeStr"></param>
    /// <returns></returns>
    public static DataTable GetCodeStr(string codeStr)
    {
        string sql = "select * from t_code where code_str=@code_str";
        MySqlParameter[] ps = new MySqlParameter[1];
        MySqlParameter p0 = new MySqlParameter("@code_str", MySqlDbType.Text);
        p0.Value = codeStr;
        ps[0] = p0;

        return MySqlHelper1.GetDataTable(sql, ps);
    }

    /// <summary>
    /// 在CODE信息中增加一次注册
    /// </summary>
    /// <param name="codeStr"></param>
    public static void AddUsedTime(string codeStr)
    {
        string sql = "update t_code set code_used_computers=code_used_computers+1 where code_str=@code_str";
        MySqlParameter[] ps = new MySqlParameter[1];
        MySqlParameter p0 = new MySqlParameter("@code_str", MySqlDbType.Text);
        p0.Value = codeStr;
        ps[0] = p0;

        MySqlHelper1.ExecuteNonQuery(sql, ps);
    }
}