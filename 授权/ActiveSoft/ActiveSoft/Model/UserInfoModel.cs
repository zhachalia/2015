using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ActiveClient.Model
{
    /// <summary>
    /// UserInfoModel 的摘要说明
    /// </summary>
    [DataContract]
    public class UserInfoModel
    {
        [DataMember(Order = 0, IsRequired = true)]
        public string code_str { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public string user_computer { get; set; }

        [DataMember(Order = 2)]
        public string user_name { get; set; }

        [DataMember(Order = 3)]
        public string user_org { get; set; }

        [DataMember(Order = 4)]
        public DateTime reg_time { get; set; }

        [DataMember(Order = 5)]
        public string reg_computer_ip { get; set; }

        [DataMember(Order = 6)]
        public string reg_computer_name { get; set; }

        [DataMember(Order = 7)]
        public int reg_state { get; set; }

        [DataMember(Order = 8)]
        public string reg_desc { get; set; }

        [DataMember(Order = 9)]
        public ComputerInfoModel computer_info_model { get; set; }

        [DataMember(Order = 10)]
        public DateTime ClientDate { get; set; }

    }
}