using ActiveClient.Common;
using ActiveClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveSoft.BLL
{
    public class BllComputerInfo
    {
        public static ComputerInfoModel GetCurentComputerInfo()
        {
            ComputerInfoModel computerInfo = new ComputerInfoModel();
            computerInfo.BaseBoardID = ComputerHelper.Instance().BaseBoardID;
            computerInfo.BIOSID = ComputerHelper.Instance().BIOSID;
            computerInfo.ComputerName = ComputerHelper.Instance().ComputerName;
            computerInfo.CpuID = ComputerHelper.Instance().CpuID;
            computerInfo.DiskID = ComputerHelper.Instance().DiskID;
            computerInfo.IpAddress = ComputerHelper.Instance().IpAddress;
            computerInfo.LoginUserName = ComputerHelper.Instance().LoginUserName;
            computerInfo.MacAddress = ComputerHelper.Instance().MacAddress;
            computerInfo.TotalPhysicalMemory = ComputerHelper.Instance().TotalPhysicalMemory;
            return computerInfo;
        }

        public static string GetComputerIntoStr(ComputerInfoModel computerInfo)
        {
            return string.Format("{0}$${1}$${2}$${3}$${4}", computerInfo.CpuID, computerInfo.DiskID, computerInfo.MacAddress, computerInfo.BaseBoardID, computerInfo.BIOSID);
        }
    }
}
