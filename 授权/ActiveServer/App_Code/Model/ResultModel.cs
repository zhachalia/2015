using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// ResultModel 的摘要说明
/// </summary>
[DataContract]
public class ResultModel
{
	public ResultModel()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    [DataMember(Order = 0)]
    public int Success { get; set; }//1成功，-1失败

    [DataMember(Order = 1)]
    public int InfoCode { get; set; }

    [DataMember(Order =2)]
    public string Info { get; set; }

    [DataMember(Order = 3)]
    public int AllowDateLen { get; set; }//允许的使用月数量

    [DataMember(Order = 4)]
    public DateTime AllowStartDate { get; set; }

    [DataMember(Order = 5)]
    public DateTime AllowEndDate { get; set; }
}