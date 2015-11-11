using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using SinhVien3Layer.DataAccess;

namespace SinhVien3Layer.BusinessLogic
{
    class KhoaBUS
    {

        // tạo đối tượng kết nối data
        ConnectData conData = new ConnectData();

        // hàm lấy danh sách khoa
        public DataTable LayDanhSachKhoa()
        {
            //
            string sql = "select Makhoa,TenKhoa from Khoa";
            return conData.GetDataTable(sql);
        }
    }
}
