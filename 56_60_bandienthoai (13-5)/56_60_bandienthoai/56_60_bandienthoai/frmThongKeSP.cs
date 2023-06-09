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
    public partial class frmThongKeSP : Form
    {
        public frmThongKeSP()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet dsSP = new DataSet();
        private void frmThongKeSP_Load(object sender, EventArgs e)
        {
            dsSP = c.layDuLieu("select a.maSP, a.maNCC, b.giaBan, b.giaNhap, d.ten, SUM(c.soLuong) 'Tong So Luong Ban'" +
                " from SANPHAM a, CTSANPHAM b, CTHOADONBAN c, LOAISP d, HOADONBAN e " +
                "where a.maSP = b.maSP and a.maSP = c.maSP and d.maLoaiSP = b.maLoaiSP and c.maHD = e.maHD " +
                "group by a.maSP, a.maNCC, b.giaBan, b.giaNhap, d.ten " +
                "order by SUM(c.soLuong) desc ");
            dgvNCC.DataSource = dsSP.Tables[0];
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(cboLoai.SelectedIndex == 0)
            {
                try
                {
                    string top = txtTop.Text;
                    string ngayBatDau = txtNgayBatDau.Text;
                    string ngayKetThuc = txtNgayKetThuc.Text;
                    string sql = "select " + (top!="" ? "top " + top + "" : "" ) + "  a.maSP, a.maNCC, b.giaBan, b.giaNhap, d.ten, SUM(c.soLuong) 'Tong So Luong Ban' " +
                        "from SANPHAM a, CTSANPHAM b, CTHOADONBAN c, LOAISP d , HOADONBAN e " +
                        "where a.maSP = b.maSP and a.maSP = c.maSP and d.maLoaiSP = b.maLoaiSP and c.maHD = e.maHD " +
                        (ngayBatDau != "" ? "and e.ngayBan >= '" + ngayBatDau + "'" : "") +
                        (ngayKetThuc != "" ? "and e.ngayBan <= '" + ngayKetThuc + "'" : "") +
                        "group by a.maSP, a.maNCC, b.giaBan, b.giaNhap, d.ten " +
                        "order by SUM(c.soLuong) desc";
                    dsSP = c.layDuLieu(sql);
                    dgvNCC.DataSource = dsSP.Tables[0];
                }catch (Exception ex)
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
                    string sql = "select " + (top != "" ? "top " + top + "" : "") + "  a.maSP, a.maNCC, b.giaBan, b.giaNhap, d.ten, SUM(c.soLuong) 'Tong So Luong Ban' " +
                        "from SANPHAM a, CTSANPHAM b, CTHOADONBAN c, LOAISP d , HOADONBAN e " +
                        "where a.maSP = b.maSP and a.maSP = c.maSP and d.maLoaiSP = b.maLoaiSP and c.maHD = e.maHD " +
                        (ngayBatDau != "" ? "and e.ngayBan >= '" + ngayBatDau + "'" : "") +
                        (ngayKetThuc != "" ? "and e.ngayBan <= '" + ngayKetThuc + "'" : "") +
                        "group by a.maSP, a.maNCC, b.giaBan, b.giaNhap, d.ten " +
                        "order by SUM(c.soLuong) asc" ;
                    dsSP = c.layDuLieu(sql);
                    dgvNCC.DataSource = dsSP.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void frmThongKeSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
