using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// Tầng này chỉ giao tiếp với BusinessLogic
using SinhVien3Layer.BusinessLogic;
using SinhVien3Layer.BusinessObject;


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

        private void dataGridViewSinhVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // đặt dòng hiện tại
            int dong = e.RowIndex;
            // thực hiện binding data lên các control khi kích chuột vào dòng Datagridview
            // Cells phải trùng với name colum
            txtMaSV.Text = dataGridViewSinhVien.Rows[dong].Cells["MaSV"].Value.ToString();
            txtHoTen.Text = dataGridViewSinhVien.Rows[dong].Cells["TenSV"].Value.ToString();
            txtTinh.Text = dataGridViewSinhVien.Rows[dong].Cells["Tinh"].Value.ToString();
            dtPickerNgaySinh.Text = dataGridViewSinhVien.Rows[dong].Cells["NgaySinh"].Value.ToString();
            txtDiaChi.Text = dataGridViewSinhVien.Rows[dong].Cells["DiaChi"].Value.ToString();
            cboGioiTinh.SelectedValue = dataGridViewSinhVien.Rows[dong].Cells["colGioiTinh"].Value.ToString();
            cboKhoa.SelectedValue = dataGridViewSinhVien.Rows[dong].Cells["colMaKhoa"].Value.ToString();

        }
        /// <summary>
        /// Hàm dùng để Enable các button
        /// </summary>
        /// <param name="editing"></param>
        /// Created by Code30 - 12/11/2015
        /// 
        private void EnableButton(bool editing)
        {
            //button
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnKhongLuu.Enabled = editing;

            //textbox, combobox
            txtHoTen.Enabled = editing;
            txtDiaChi.Enabled = editing;
            txtTinh.Enabled = editing;
            cboGioiTinh.Enabled = editing;
            cboKhoa.Enabled = editing;
        }

        /// <summary>
        /// Hàm sự kiện thêm
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            EnableButton(true);
            //Load LastID lên mã sinh viên
            txtMaSV.Text = svBUS.SinhVienNextID();

        }

  
    }
}