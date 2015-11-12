using System;
using System.Collections.Generic;
using System.Text;


namespace SinhVien3Layer.BusinessObject
{
    class SinhVien
    {
        //public string MaSV { [CompilerGenerated]get; [CompilerGenerated]set;}
        //public string TenSV { [CompilerGenerated]get; [CompilerGenerated]set;}
        //public DateTime NgaySinh { [CompilerGenerated]get; [CompilerGenerated]set;}
        //public int GioiTinh { [CompilerGenerated]get; [CompilerGenerated]set;}
        //public string Tinh { [CompilerGenerated]get; [CompilerGenerated]set;}
        //public string MaKhoa { [CompilerGenerated]get; [CompilerGenerated]set;}
        //public string DiaChi { [CompilerGenerated]get; [CompilerGenerated]set;}

        public string masv;
        public string hoten;
        public DateTime ngaysinh;
        public int gioitinh;
        public string tinh;
        public string diachi;

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
	
        private string makhoa;


        public string MaKhoa
        {
            get { return makhoa; }
            set { makhoa = value; }
        }
	

        public string Tinh
        {
            get { return tinh; }
            set { tinh = value; }
        }
	

        public int GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
	

        public DateTime NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
	
        public string MaSV
        {
            get { return masv; }
            set { masv = value; }
        }
        
        public string TenSV
        {
            get { return hoten; }
            set { hoten = value; }
        }
	
    }
}