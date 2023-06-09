using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _56_60_bandienthoai
{
    public partial class frmThongKeNCC : Form
    {
        public frmThongKeNCC()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet dsNCC = new DataSet();
        private void frmThongKeNCC_Load(object sender, EventArgs e)
        {
            dsNCC = c.layDuLieu("select a.maNCC, a.tenNCC, a.email, SUM(c.soLuong) 'Tong So Luong Nhap', SUM(c.tongTien) 'Tong Tien Nhap'  " +
                "from NHACUNGCAP a, HOADONNHAP b, CTHOADONNHAP c " +
                "where a.maNCC = b.maNCC and b.maHD = c.maHD " +
                "group by a.maNCC, a.tenNCC, a.email " +
                "order by SUM(c.tongTien) desc");
            dgvNCC.DataSource = dsNCC.Tables[0];
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cboLoai.SelectedIndex == 0)
            {
                try
                {
                    string top = txtTop.Text;
                    string ngayBatDau = txtNgayBatDau.Text;
                    string ngayKetThuc = txtNgayKetThuc.Text;
                    string sql = "select " + (top != "" ? "top " + top + "" : "") + " a.maNCC, a.tenNCC, a.email, SUM(c.soLuong) 'Tong So Luong Nhap', SUM(c.tongTien) 'Tong Tien Nhap'  " +
                "from NHACUNGCAP a, HOADONNHAP b, CTHOADONNHAP c " +
                "where a.maNCC = b.maNCC and b.maHD = c.maHD " +
                (ngayBatDau != "" ? "and b.ngayNhap >= '" + ngayBatDau + "'" : "") +
                (ngayKetThuc != "" ? "and b.ngayNhap <= '" + ngayKetThuc + "'" : "") +
                "group by a.maNCC, a.tenNCC, a.email " +
                "order by SUM(c.tongTien) desc";
                    dsNCC = c.layDuLieu(sql);
                    dgvNCC.DataSource = dsNCC.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    string top = txtTop.Text;
                    string ngayBatDau = txtNgayBatDau.Text;
                    string ngayKetThuc = txtNgayKetThuc.Text;
                    string sql = "select " + (top != "" ? "top " + top + "" : "") + " a.maNCC, a.tenNCC, a.email, SUM(c.soLuong) 'Tong So Luong Nhap', SUM(c.tongTien) 'Tong Tien Nhap'  " +
                "from NHACUNGCAP a, HOADONNHAP b, CTHOADONNHAP c " +
                "where a.maNCC = b.maNCC and b.maHD = c.maHD " +
                (ngayBatDau != "" ? "and b.ngayNhap >= '" + ngayBatDau + "'" : "") +
                (ngayKetThuc != "" ? "and b.ngayNhap <= '" + ngayKetThuc + "'" : "") +
                "group by a.maNCC, a.tenNCC, a.email " +
                "order by SUM(c.tongTien) asc";
                    dsNCC = c.layDuLieu(sql);
                    dgvNCC.DataSource = dsNCC.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void frmThongKeNCC_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
