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
    public partial class frmKHACHHANG : Form
    {
        public frmKHACHHANG()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet dsKhachHang = new DataSet();
        public frmHOADONBAN frmHOADONBAN { get; set; }
        int flag = 0;
        void danhsach_datagridview(DataGridView d, string sql, ref DataSet ds)
        {
            ds = c.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void loadPhimChucNang(bool status)
        {
            btnLuu.Enabled = !status;
            btnXoa.Enabled = status;
            btnSua.Enabled = status;
            btnMoi.Enabled = status;
        }

        private void frmKHACHHANG_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvKhachHang, "select *, CONVERT(INT" +
                ", SUBSTRING(maKH, 3, LEN(maKH)-2)) AS ColPhu  from KHACHHANG ORDER BY ColPhu ASC", ref dsKhachHang);
            loadPhimChucNang(true);
            flag = 2;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count - 1)
            {
                int stt = e.RowIndex;
                txtMaKH.Text = dsKhachHang.Tables[0].Rows[stt]["maKH"].ToString();
                txtTenKH.Text = dsKhachHang.Tables[0].Rows[stt]["hoTen"].ToString();
                txtEmail.Text = dsKhachHang.Tables[0].Rows[stt]["email"].ToString();
                txtDiaChi.Text = dsKhachHang.Tables[0].Rows[stt]["diaChi"].ToString();
                txtSDT.Text = dsKhachHang.Tables[0].Rows[stt]["dienThoai"].ToString();
                txtNgaySinh.Text = dsKhachHang.Tables[0].Rows[stt]["ngSinh"].ToString();
                cboGioiTinh.Text = dsKhachHang.Tables[0].Rows[stt]["gioiTinh"].ToString();
                txtGhiChu.Text = dsKhachHang.Tables[0].Rows[stt]["ghiChu"].ToString();
                cboTrangThai.SelectedIndex = Convert.ToInt32(dsKhachHang.Tables[0].Rows[stt]["trangThai"].ToString());
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
        //Dùng để tránh trường hợp dữ liệu bị mất ở khúc trên làm xáo trộn stt nên sẽ lấy stt ở cuối để cộng 1
        void themMoi(DataSet ds, TextBox a, DataGridView dgv, string tenCot, string tenDat, int soLuong)
        {
            int lastRowIndex = dgv.RowCount - 2;
            DataGridViewRow dong = dgv.Rows[lastRowIndex];
            int tt = Convert.ToInt32(ds.Tables[0].Rows[lastRowIndex][tenCot].ToString().Substring(soLuong)) + 1;
            a.Text = tenDat + tt.ToString();
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            xoaDL();
            themMoi(dsKhachHang, txtMaKH, dgvKhachHang, "maKH", "KH",2);
            flag = 1;
            loadPhimChucNang(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(flag == 1)
            {
                string sql = "";
                if(txtMaKH.Text != "")
                {
                    sql = "insert into KHACHHANG values('"+txtMaKH.Text+"','"+txtTenKH.Text+"','"+txtEmail.Text+"','"+txtDiaChi.Text+"','"+txtSDT.Text+"','"+txtNgaySinh.Text+"',N'"+cboGioiTinh.Text+"','"+txtGhiChu.Text+"','"+cboTrangThai.SelectedIndex.ToString()+"')";
                }
                try
                {
                    if (c.capNhatDuLieu(sql) > 0)
                    {
                        MessageBox.Show("LUU OKE");
                        frmKHACHHANG_Load(sender, e);
                        loadPhimChucNang(true);
                        flag = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }    
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "";
            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn có chắc chắc Xóa Khách Hàng này!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                sql = "update KHACHHANG set trangThai = 0 where maKH = '"+txtMaKH.Text+"'";
                try
                {
                    if (c.capNhatDuLieu(sql) > 0)
                    {
                        MessageBox.Show("XOA OKE");
                        frmKHACHHANG_Load(sender, e);
                        xoaDL();
                        loadPhimChucNang(true);
                        flag = 0;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtMaKH.Text != "")
            {
                sql = "update KHACHHANG set hoTen = '"+txtTenKH.Text+"', email = '"+txtEmail.Text+"', diaChi = '"+txtDiaChi.Text+"', dienThoai = '"+txtSDT.Text+"', ngSinh = '"+txtNgaySinh.Text+"', gioiTinh = N'"+cboGioiTinh.Text+"', ghiChu = '"+txtGhiChu.Text+"', trangThai = '"+cboTrangThai.SelectedIndex.ToString()+"' where maKH = '"+txtMaKH.Text+"'";
            }
            try
            {
                if (c.capNhatDuLieu(sql) > 0)
                {
                    MessageBox.Show("CAP NHAT OKE");
                    frmKHACHHANG_Load(sender, e);
                    xoaDL();
                    loadPhimChucNang(true);
                    flag = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message) ;
            }
            
        }
        private void xoaDL()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtNgaySinh.Text = "";
            cboGioiTinh.Text = "";
            txtGhiChu.Text = "";
            cboTrangThai.Text = "";
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            xoaDL();
            loadPhimChucNang(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKHACHHANG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                DialogResult kq;
                kq = MessageBox.Show("DỮ LIỆU CHƯA ĐƯỢC LƯU", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void dgvKhachHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flag == 2)
            {
                if (e.ColumnIndex == 1)
                {
                    string maKH = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                    string hoTen = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                    string email = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                    string diaChi = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
                    string sdt = dgvKhachHang.CurrentRow.Cells[4].Value.ToString();
                    string ngSinh = dgvKhachHang.CurrentRow.Cells[5].Value.ToString();
                    string gioiTinh = dgvKhachHang.CurrentRow.Cells[6].Value.ToString();
                    string ghiChu = dgvKhachHang.CurrentRow.Cells[7].Value.ToString();
                    string trangThai = dgvKhachHang.CurrentRow.Cells[8].Value.ToString();
                    string sql = "update KHACHHANG set hoTen = '"+ hoTen + "', email = '"+ email + "', " +
                        "diaChi = '"+ diaChi + "', dienThoai = '"+ sdt + "', ngSinh = '"+ ngSinh + "', gioiTinh = '"+ gioiTinh + "', " +
                        "ghiChu = '"+ ghiChu + "', trangThai = '"+ trangThai + "' where maKH = '"+ maKH + "'";
                    if (c.capNhatDuLieu(sql) > 0)
                    {
                        MessageBox.Show("CAP NHAT OKE");
                        frmKHACHHANG_Load(sender, e);
                    }
                }
            }
        }
        private void loadComboBox(ComboBox cb, DataSet dt, string sql, string ten, string giatri)
        {
            dt = c.layDuLieu(sql);
            cb.DataSource = dt.Tables[0];
            cb.DisplayMember = ten;
            cb.ValueMember = giatri;
            cb.SelectedIndex = -1;

        }
        private void frmKHACHHANG_FormClosed(object sender, FormClosedEventArgs e)
        {
           if(this.frmHOADONBAN != null)
            {
                this.frmHOADONBAN.loadcboKhachHangKhiThemMoi();
            }
        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
