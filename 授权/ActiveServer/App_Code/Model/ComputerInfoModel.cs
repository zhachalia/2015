using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// ComputerInfoModel 的摘要说明
/// </summary>
[DataContract]
public class ComputerInfoModel
{
	public ComputerInfoModel()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//

	}
    [DataMember(Order = 0)]
    public string CpuID { get; set; }

    [DataMember(Order = 1)]
    public string MacAddress { get; set; }

    [DataMember(Order = 2)]
    public string DiskID { get; set; }

    [DataMember(Order = 3)]
    public string IpAddress { get; set; }

    [DataMember(Order = 4)]
    public string LoginUserName { get; set; }

    [DataMember(Order = 5)]
    public string ComputerName { get; set; }

    [DataMember(Order = 6)]
    public string SystemType { get; set; }

    [DataMember(Order = 7)]
    public string TotalPhysicalMemory { get; set; }//单位：M

    [DataMember(Order = 8)]
    public string BaseBoardID { get; set; }

    [DataMember(Order = 9)]
    public string BIOSID { get; set; }


}