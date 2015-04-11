using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// BllCode 的摘要说明
/// </summary>
public class BllCode
{
	public BllCode()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 组装注册码实体
    /// </summary>
    /// <param name="dr"></param>
    /// <returns></returns>
    public static CodeModel GenCodeModel(DataRow dr)
    {
        CodeModel cm = new CodeModel();
        if (dr != null)
        {
            if (dr["code_date_end"] != null && !string.IsNullOrEmpty(dr["code_date_end"].ToString()))
            {
                DateTime code_date_end;
                DateTime.TryParse(dr["code_date_end"].ToString(), out code_date_end);
                cm.code_date_end = code_date_end;
            }

            if (dr["code_date_len"] != null && !string.IsNullOrEmpty(dr["code_date_len"].ToString()))
            {
                int code_date_len=0;
                int.TryParse(dr["code_date_len"].ToString(), out code_date_len);
                cm.code_date_len = code_date_len;
            }

            if (dr["code_date_start"] != null && !string.IsNullOrEmpty(dr["code_date_start"].ToString()))
            {
                DateTime code_date_start;
                DateTime.TryParse(dr["code_date_start"].ToString(), out code_date_start);
                cm.code_date_start = code_date_start;
            }

            cm.code_desc = dr["code_desc"].ToString();

            if (dr["code_enable_computers"] != null && !string.IsNullOrEmpty(dr["code_enable_computers"].ToString()))
            {
                int code_enable_computers=0;
                int.TryParse(dr["code_enable_computers"].ToString(), out code_enable_computers);
                cm.code_enable_computers = code_enable_computers;
            }

            cm.code_str = dr["code_str"].ToString();

            if (dr["code_type"] != null && !string.IsNullOrEmpty(dr["code_type"].ToString()))
            {
                int code_type = 0;
                int.TryParse(dr["code_type"].ToString(), out code_type);
                cm.code_type = code_type;
            }

            if (dr["code_used_computers"] != null && !string.IsNullOrEmpty(dr["code_used_computers"].ToString()))
            {
                int code_used_computers = 0;
                int.TryParse(dr["code_used_computers"].ToString(), out code_used_computers);
                cm.code_used_computers = code_used_computers;
            }

            if (dr["code_valid"] != null && !string.IsNullOrEmpty(dr["code_valid"].ToString()))
            {
                int code_valid = 0;
                int.TryParse(dr["code_valid"].ToString(), out code_valid);
                cm.code_valid = code_valid;
            }
        }
        return cm;
    }
}