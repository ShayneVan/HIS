using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace HIS.TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Program test = new Program();
            Console.WriteLine(count());
        }

        
        /// <summary>
        /// 数据库连接测试
        /// </summary>
        public void testConn()
        {
            string ConnectionString = "Server=(Local);pwd=sa;uid=sa;database=HIS";
            //string ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        Console.WriteLine("当前数据库已连接！");
                        Console.WriteLine("连接字符串为：" + conn.ConnectionString);
                    }
                    conn.Close();
                }
                catch
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        Console.WriteLine("未连接数据库！");
                    }
                }
            }
        }

        /// <summary>
        /// 读取数据库信息
        /// </summary>
        public void Read()
        {
            string ConnectionString = "Server=(Local);pwd=sa;uid=sa;database=HIS";
            string queryString = "select * from [PatientInfo]";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 15;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = queryString;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine(reader[0]);
                    Console.WriteLine(reader[1]);
                    Console.WriteLine(reader[2]);
                    Console.WriteLine(reader[3]);
                }
                conn.Close();

            }
        }

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

        public void Add(string name)
        {
            string ConnectionString = "Server=(Local);pwd=sa;uid=sa;database=HIS";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                int count = 4;
                string sql = "insert into PatientInfo (PatientName,Id) values('" + name + "','" + count + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //try
                //{
                //    conn.Open();
                //    cmd.ExecuteNonQuery();
                //    conn.Close();
                //}
                //catch(Exception ex)
                //{
                //    throw ex;
                //}
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                count++;
            }
        }
        public static int count()
        {
            string ConnectionString = "Server=(Local);pwd=sa;uid=sa;database=HIS";
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
