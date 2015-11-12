using System;
using System.Collections.Generic;
using System.Text;
using System.Data; // làm việc với csdl
using System.Data.SqlClient; 
using System.Windows.Forms; // làm việc với winform


namespace SinhVien3Layer.DataAccess
{
    class ConnectData
    {
        private SqlConnection conn;
        private SqlDataAdapter dataAd;
        private DataTable dataTable;

        
        // tạo contrustor khi kết nối lớp ConnectData
        public ConnectData()
        {
            Connect();
        }
        
        
        
        // hàm kết nối
        public void Connect()
        {
            string strConn = @"Data Source=2-PC\SQLEXPRESS;Initial Catalog=SinhVienDB;User ID=sa;Password=sa";

            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
                
            }
        }

        //hàm lấy dữ liệu DataTable từ câu truy vấn truyền vào 
        public DataTable GetDataTable(string sql)
        {
            //tạo dataAdapter, thực hiện câu query
            dataAd = new SqlDataAdapter(sql, conn);
            dataTable = new DataTable();
            dataAd.Fill(dataTable);
            return dataTable;
        }

        //hàm thực hiện câu lệnh truy vấn (insert, update, delete) trả về thực hiện thành công hay không?

        public bool ExecuteQuery(string sql)
        {
            int numRecordEffect = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                numRecordEffect = cmd.ExecuteNonQuery();
                            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " +ex.Message);
            }

            if (numRecordEffect > 0)
                return true;
            return false;
        }

        // Hàm lấy mã cuối cùng
        public string GetLastID(string nameTable, string nameField)
        {
            string sql = "SELECT TOP 1 " + nameField + " FROM " + nameTable + " ORDER BY " + nameField + " DESC";
            //string sql = "SELECT TOP 1 " + nameField + " FROM " + nameTable + " ORDER BY " + nameField + " DESC";

            //thực hiện câu truy vấn trên
            GetDataTable(sql);
            return dataTable.Rows[0][nameField].ToString();//
        }

    }
}
