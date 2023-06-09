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
    public partial class frmThongKeHoaDon : Form
    {
        public frmThongKeHoaDon()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet dsHDB = new DataSet();
        DataSet dsHDN = new DataSet();
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cboLoai.SelectedIndex != -1)
            {


                if (cboLoai.SelectedIndex == 0)
                {
                    try
                    {
                        string ngayBatDau = txtNgayBatDau.Text, ngayKetThuc = txtNgayKetThuc.Text, top = txtTop.Text, sql, subsql = "";
                        if (radCuNhat.Checked) subsql = " ngayBan ASC";
                        if (radDoanhThu.Checked) subsql = " SUM(a.tongTien) DESC";
                        if (radMoiNhat.Checked) subsql = " ngayBan DESC";
                        sql = "select " + (top != "" ? "top " + top + "" : "") + " b.ngayBan,SUM(a.soLuong) N'Tổng số lượng', SUM(a.soLuong*donGia) N'Doanh thu' " +
                            "from CTHOADONBAN a, HOADONBAN b where  a.maHD=b.maHD " +
                (ngayBatDau != "" ? "and ngayBan >= '" + ngayBatDau + "'" : "") +
                (ngayKetThuc != "" ? "and ngayBan <= '" + ngayKetThuc + "'" : "") +
                " group by ngayBan " + (subsql == "" ? "" : "order by " + subsql);
                        dsHDB = c.layDuLieu(sql);
                        dgvHoaDon.DataSource = dsHDB.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                if (cboLoai.SelectedIndex == 1)
                {
                    try
                    {
                        string ngayBatDau = txtNgayBatDau.Text, ngayKetThuc = txtNgayKetThuc.Text, top = txtTop.Text, sql, subsql = "";
                        if (radCuNhat.Checked) subsql = " ngayNhap ASC";
                        if (radDoanhThu.Checked) subsql = " SUM(a.tongTien) DESC";
                        if (radMoiNhat.Checked) subsql = " ngayNhap DESC";
                        sql = "select " + (top != "" ? "top " + top + "" : "") + " b.ngayNhap,SUM(a.soLuong) N'Tổng số lượng', SUM(a.soLuong*donGia) N'Tổng Chi phí' " +
                            "from CTHOADONNHAP a, HOADONNHAP b " +
                        (ngayBatDau != "" ? "and b.ngayNhap >= '" + ngayBatDau + "'" : "") +
                        (ngayKetThuc != "" ? "and b.ngayNhap <= '" + ngayKetThuc + "'" : "") +
                            "where a.maHD=b.maHD group by ngayNhap " + (subsql == "" ? "" : " order by " + subsql);
                        dsHDB = c.layDuLieu(sql);
                        dgvHoaDon.DataSource = dsHDB.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa Chọn loại Hóa Đơn!!!");
            }
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnThongKe_Click(sender, e);
        }

        private void frmThongKeHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
