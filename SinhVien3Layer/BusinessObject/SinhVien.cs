using System;
using System.Collections.Generic;
using System.Text;

namespace SinhVien3Layer.BusinessObject
{
    /// <summary>
    /// Lớp sinh viên
    /// Thuộc tính
    /// - Mã Sinh viên
    /// - Họ và tên
    /// </summary>
    class SinhVien
    {
        private string MaSV;
        private string TenSV;
        private DateTime NgaySinh;
        private int GioiTinh;
        private string Tinh;
        private string DiaChi;
        private string MaKhoa;

        public string MaKhoa
        {
            get { return MaKhoa; }
            set { MaKhoa = value; }
        }
	

        public string DiaChi
        {
            get { return DiaChi; }
            set { DiaChi = value; }
        }
	

        public string Tinh
        {
            get { return Tinh; }
            set { Tinh = value; }
        }
	

        public int GioiTinh
        {
            get { return GioiTinh; }
            set { GioiTinh = value; }
        }
	

        public DateTime NgaySinh
        {
            get { return NgaySinh; }
            set { NgaySinh = value; }
        }
	

        public string TenSV
        {
            get { return TenSV; }
            set { TenSV = value; }
        }
	

        public string MaSV
        {
            get { return MaSV; }
            set { MaSV = value; }
        }
	 
    }
}
