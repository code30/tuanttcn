using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

// thao tac với lớp DataAccessLayer
using SinhVien3Layer.DataAccess;
using SinhVien3Layer.BusinessObject;



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


        /// <summary>
        /// Hàm thêm 1 sinh viên
        /// 
        /// </summary>
        /// <param name="sv">thêm đối tượng sinh viên</param>
        /// <remarks> Chưa hiểu rõ lắm</remarks>
        /// Created by Code30 - 12/11/2015: Thêm 1 đối tượng sinh viên vào bảng Sinh Viên
        /// Modified by Code30 --
        public bool ThemSV(SinhVien3Layer.BusinessObject.SinhVien sv)
        {
            if (KiemTraTruocKhiLuu(sv))
            {
                //string sql = string.Format("insert into SINHVIEN(MaSV,TenSV,NgaySinh,GioiTinh,DiaChi,Tinh,MaKhoa)"
                //                        + "Value('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", sv.MaSV, sv.TenSV, sv.NgaySinh.ToString("dd-MM-yyyy"), sv.GioiTinh, sv.DiaChi, sv.Tinh, sv.MaKhoa);
                string sql = string.Format("UPDATE SINHVIEN SET TenSV = '{0}', NgaySinh = '{1}', "
                                    + "GioiTinh = {2}, DiaChi = '{3}', Tinh = '{4}', MaKhoa = '{5}' WHERE MaSV = '{6}' ",
                      sv.TenSV, sv.NgaySinh.ToString("dd-MM-yyyy"), sv.GioiTinh, sv.DiaChi,
                            sv.Tinh, sv.MaKhoa, sv.MaSV);
               
                if (connData.ExecuteQuery(sql))
                {
                    MessageBox.Show("Thêm Sinh viên thành công!!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Hàm kiểm tra trước khi lưu 1 sinh viên
        /// </summary>
        /// <param name="sv">Đối tượng 1 sinh viên</param>
        /// <returns>true</returns>
        /// Created by Code30 - 12/11/2015: Viết hàm kiểm tra các control trước khi lưu vào data
        /// 
        public bool KiemTraTruocKhiLuu(SinhVien3Layer.BusinessObject.SinhVien sv)
        {
            if (sv.TenSV.Equals(""))
            {
                MessageBox.Show("Họ tên không hợp lệ");
                return false;
            }
            if (sv.Tinh.Equals(""))
            {
                MessageBox.Show("Tỉnh không hợp lệ");
                return false;
            }
            if (sv.DiaChi.Equals(""))
            {
                MessageBox.Show("Địa chỉ không hợp lệ");
                return false;
            }
            if (sv.NgaySinh.Year < 1900)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                return false;
            }
           return true;
          
        }
        /// <summary>
        /// Hàm lấy mã sinh viên kế tiếp
        /// </summary>
        /// <returns></returns>
        public string SinhVienNextID()
        {
            return Utilities.NextID(connData.GetLastID("SINHVIEN","MaSV"),"SV");
        }


    }
}
