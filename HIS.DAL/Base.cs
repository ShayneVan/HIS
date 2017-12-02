using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS;
using System.Configuration;

namespace HIS.DAL
{
    public class Base
    {     
        static string ConnectionString = "Server=(Local);pwd=sa;uid=sa;database=HIS";
       
        //查询预约记录
        public DataSet Search(string sql)
        {
            string ConnectionString = "Server=(Local);pwd=sa;uid=sa;database=HIS";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(sql, conn);
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                conn.Open();
                da.SelectCommand.ExecuteNonQuery();
                conn.Close();
                da.Fill(ds);
                return ds;
            }
        }

        //添加预约信息
        public void Add(string name)
        {
            string ConnectionString = "Server=(Local);pwd=sa;uid=sa;database=HIS";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                int cout = count() + 1;
                string sql = "insert into PatientInfo (PatientName,Id) values('" + name + "','" + cout + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        //更新预约信息
        public void Update(string name)
        {
            string ConnectionString = "Server=(Local);pwd=sa;uid=sa;database=HIS";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string sql = "Update PatientInfo set PatientName = '" + name + "'" + " where ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        //删除预约信息
        public void Delect(string name)
        {
            string ConnectionString = "Server=(Local);pwd=sa;uid=sa;database=HIS";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string sql = "delete from PatientInfo where name = '" + name + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static int count()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string sql = "select count(*) from PatientInfo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    return count;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        } 
            
    }
}
