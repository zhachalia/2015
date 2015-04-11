using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// DAReg 的摘要说明
/// </summary>
public class DAUserInfo
{
	public DAUserInfo()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static int Insert(UserInfoModel userInfo)
    {
        string sql = @"insert into t_userinfo(code_str,user_computer,user_name,user_org,reg_time,reg_computer_ip,reg_computer_name,reg_state,reg_desc)
            values(@code_str,@user_computer,@user_name,@user_org,@reg_time,@reg_computer_ip,@reg_computer_name,@reg_state,@reg_desc);";
        MySqlParameter[] ps = new MySqlParameter[9];
        MySqlParameter p0 = new MySqlParameter("@code_str", MySqlDbType.Text);
        p0.Value = userInfo.code_str;

        MySqlParameter p1 = new MySqlParameter("@user_computer", MySqlDbType.Text);
        p1.Value = userInfo.user_computer;

        MySqlParameter p2 = new MySqlParameter("@user_name", MySqlDbType.Text);
        p2.Value = userInfo.user_name;

        MySqlParameter p3 = new MySqlParameter("@user_org", MySqlDbType.Text);
        p3.Value = userInfo.user_org;

        MySqlParameter p4 = new MySqlParameter("@reg_time", MySqlDbType.Datetime);
        p4.Value = userInfo.reg_time;

        MySqlParameter p5 = new MySqlParameter("@reg_computer_ip", MySqlDbType.Text);
        p5.Value = userInfo.reg_computer_ip;

        MySqlParameter p6 = new MySqlParameter("@reg_computer_name", MySqlDbType.Text);
        p6.Value = userInfo.reg_computer_name;

        MySqlParameter p7 = new MySqlParameter("@reg_state", MySqlDbType.Int32);
        p7.Value = 1;//成功注册

        MySqlParameter p8 = new MySqlParameter("@reg_desc", MySqlDbType.Text);
        p8.Value = userInfo.reg_desc;

        ps[0] = p0;
        ps[1] = p1;
        ps[2] = p2;
        ps[3] = p3;
        ps[4] = p4;
        ps[5] = p5;
        ps[6] = p6;
        ps[7] = p7;
        ps[8] = p8;

        return MySqlHelper1.ExecuteNonQuery(sql, ps);

    }

    /// <summary>
    /// 获取已经注册成功的用户reg_state=1
    /// </summary>
    /// <param name="codeStr"></param>
    /// <returns></returns>
    public static DataTable GetUserInfo(string codeStr)
    {
        string sql = "select * from t_userinfo where code_str=@code_str and reg_state=1";
        MySqlParameter[] ps = new MySqlParameter[1];
        MySqlParameter p0 = new MySqlParameter("@code_str", MySqlDbType.Text);
        p0.Value = codeStr;
        ps[0] = p0;

        return MySqlHelper1.GetDataTable(sql, ps);
    }
   

}