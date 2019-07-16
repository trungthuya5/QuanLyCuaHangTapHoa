using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DAL
{
    public class Database
    {
        string strConn = "Server=DESKTOP-454D525\\DUONG;Database=CHTapHoa;User Id=sa;pwd=25251325";
        SqlConnection conn = null;

        public Database()
        {
            if(conn == null)
            conn = new SqlConnection(strConn);
        }

        public void OpenConnection()
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối: " + ex.Message);
            }

            // MessageBox.Show("connection");
        }

        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            // MessageBox.Show("close");
        }

        public DataTable ExcuteQuery(string query)
        {
            DataTable data = new DataTable();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi truy vấn:" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }


            return data;
        }

        public void ExcuteNonQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi không truy vấn:" + ex.Message);
            }
            finally
            {
                CloseConnection();

                if(cmd != null)
                    cmd.Dispose();
            }
        }

        public object ExcuteScalar(string query)
        {
            object data = 0;

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                OpenConnection();
                data = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi ExecuteScalar: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return data;
        }

    }
}
