using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIS.Models
{
    public class PatientInfo
    {
        /// <summary>
        /// 以下信息为预约登记信息
        /// </summary>
        //预约姓名
        public string PatientName { get; set; }
        //身份证号
        public string PatientID { get; set; }
        //联系电话
        public string PatientPhone { get; set; }
        //性别
        public char PatientSex { get; set; }
        //病情简单描述
        public string Patient_Conditon { get; set; }
        //预约的部门
        public string Deparment { get; set; }
        //请求查看的疾病
        public string Disease { get; set;}

    }
}