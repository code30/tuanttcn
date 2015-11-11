﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// Tầng này chỉ giao tiếp với BusinessLogic
using SinhVien3Layer.BusinessLogic;


namespace SinhVien3Layer
{
    public partial class SinhVien : Form
    {
        private SinhVienBUS svBUS=new SinhVienBUS(); //
        private KhoaBUS khoaBUS = new KhoaBUS();

        public SinhVien()
        {
            InitializeComponent();
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {
            
            //load combox khoa
            cboKhoa.DataSource = khoaBUS.LayDanhSachKhoa();
            cboKhoa.DisplayMember = "TenKhoa";// hiển thị thông tin tên khoa
            cboKhoa.ValueMember = "MaKhoa"; // lấy theo giá trị mã khoa

            // load combox giới tính
            cboGioiTinh.DataSource = svBUS.LayDSGioiTinh();
            cboGioiTinh.DisplayMember = "NameGT"; // hiện thị tên giới tính
            cboGioiTinh.ValueMember = "GioiTinh"; // lấy giá trị giới tính
           
            // load combox colum datagridviewSinhVien
            colGioiTinh.DataSource = svBUS.LayDSGioiTinh();
            colGioiTinh.DisplayMember = "NameGT";
            colGioiTinh.ValueMember = "GioiTinh";
            
            colMaKhoa.DataSource = khoaBUS.LayDanhSachKhoa();
            colMaKhoa.DisplayMember = "TenKhoa";
            colMaKhoa.ValueMember = "MaKhoa";



            // datagridview lúc nào cũng load sau cùng
            //load datagridview Sinh viên
            dataGridViewSinhVien.DataSource = svBUS.LayDanhSachSinhVien();
        }

  
    }
}