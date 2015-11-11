using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// thao tac với lớp DataAccessLayer
using SinhVien3Layer.DataAccess;


namespace SinhVien3Layer.BusinessLogic
{
    class SinhVienBUS
    {
        ConnectData connData = new ConnectData();

        // hàm truy vấn lấy danh sách sinh viên

        public DataTable LayDanhSachSinhVien()
        {
            string sql = "select MaSV,TenSV,NgaySinh,GioiTinh,DiaChi,Tinh,MaKhoa from SINHVIEN ";
            return connData.GetDataTable(sql);// lấy dữ liệu DataTable

        }

        // hàm lấy combox giới tính sinh viên

        public DataTable LayDSGioiTinh()
        {

            //string sql = "select distinct GioiTinh from SINHVIEN";

            // cải tiến: giới tính thành nam hoặc nữ sử dụng case
            string sql = "select distinct GioiTinh,"
                         + "NameGT= case GioiTinh when 0 then N'Nam' "
                         + "when 1 then N'Nữ' end from SINHVIEN";
                      
            return connData.GetDataTable(sql);        
        }

    }
}
