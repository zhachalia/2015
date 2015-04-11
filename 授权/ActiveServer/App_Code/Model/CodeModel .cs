using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// ResultModel 的摘要说明
/// </summary>
[DataContract]
public class CodeModel
{
    public CodeModel()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    [DataMember(Order = 0)]
    public string code_str { get; set; }//注册码

    [DataMember(Order = 1)]
    public int code_type { get; set; }//注册码类型

    [DataMember(Order =2)]
    public int code_valid { get; set; }//是否有效，1-有效，0无效

    [DataMember(Order = 3)]
    public int code_date_len { get; set; }//月份数量

    [DataMember(Order = 4)]
    public DateTime code_date_start { get; set; }//有效期，开始

    [DataMember(Order = 5)]
    public DateTime code_date_end { get; set; }//有效期，结束

    [DataMember(Order = 6)]
    public string code_desc { get; set; }//描述

    [DataMember(Order = 7)]
    public int code_enable_computers { get; set; }//允许的计算机数量

    [DataMember(Order = 8)]
    public int code_used_computers { get; set; }//已经使用的数量
}