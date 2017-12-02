using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.Models;
using System.Data;
using HIS.DAL;

namespace HIS.BLL
{
    public class BaseClass
    {

        //把预约信息存进数据库
        public void SaveReservation(PatientInfo ptinfo)
        {
            Base sr = new Base();
            sr.Add(ptinfo.PatientName);
            
        }
        
        //查询预约信息
        public DataSet SearchReservation(string name)
        {
            string sql = "select * from [PatientInfo] where PatientName ==" + name;
            Base sr = new Base();
            DataSet ds = new DataSet();
            ds = sr.Search(sql);
            return ds;          
        }
    }
}
