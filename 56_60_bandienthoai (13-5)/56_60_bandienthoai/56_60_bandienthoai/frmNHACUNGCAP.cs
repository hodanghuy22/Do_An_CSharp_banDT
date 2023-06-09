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
    public partial class frmNHACUNGCAP : Form
    {
        public frmNHACUNGCAP()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet ds;
        public frmHOADONNHAP frmHOADONNHAP;
        Boolean flagCN = false;
        void danhsach_datagridview(DataGridView d, string sql)
        {
            ds = c.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }

        private void frmNHACUNGCAP_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvNCC, "select *, CONVERT(INT, SUBSTRING(maNCC, 4, LEN(maNCC)-3)) AS ColPhu from NHACUNGCAP ORDER BY ColPhu ASC;");
            loadPhimChucNang(true);
            flagCN = true;
        }
        private void loadPhimChucNang(bool status)
        {
            btnLuu.Enabled = !status;
            btnXoa.Enabled = status;
            btnSua.Enabled = status;
            btnMoi.Enabled = status;
        }
        private void frmNHACUNGCAP_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int flag = 0;
        private void btnMoi_Click(object sender, EventArgs e)
        {
            flag = 1;
            loadPhimChucNang(false);
            themMoi(ds, txtMaNCC, dgvNCC, "maNCC", "NCC", 3);
        }
        //Dùng để tránh trường hợp dữ liệu bị mất ở khúc trên làm xáo trộn stt nên sẽ lấy stt ở cuối để cộng 1
        void themMoi(DataSet ds, TextBox a, DataGridView dgv, string tenCot, string tenDat, int soLuong)
        {
            int lastRowIndex = dgv.RowCount - 2;
            DataGridViewRow dong = dgv.Rows[lastRowIndex];
            int tt = Convert.ToInt32(ds.Tables[0].Rows[lastRowIndex][tenCot].ToString().Substring(soLuong)) + 1;
            a.Text = tenDat + tt.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            loadPhimChucNang(true);
            string sql = "";
            if (flag == 1)
            {
                sql = "insert into NHACUNGCAP values('" + txtMaNCC.Text + "','" + txtTenNCC.Text + "','" + txtSTK.Text + "','" + txtNganHang.Text + "','" + txtEmail.Text + "','" + rtxtGhiChu.Text + "','" + cboTrangThai.SelectedIndex.ToString() + "')";
            }
            try
            {
                if (c.capNhatDuLieu(sql) > 0)
                {
                    MessageBox.Show("LUU OKE");
                    xoaDL();
                    frmNHACUNGCAP_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void xoaDL()
        {
            txtMaNCC.Clear();
            txtNganHang.Clear();
            txtSTK.Clear();
            txtTenNCC.Clear();
            cboTrangThai.Text = cboTrangThai.Items[1].ToString();
            rtxtGhiChu.Clear();
            txtEmail.Clear();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            xoaDL();
            flag = 0;
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNCC.Rows.Count - 1)
            {
                int stt = e.RowIndex;
                txtMaNCC.Text = ds.Tables[0].Rows[stt]["maNCC"].ToString();
                txtNganHang.Text = ds.Tables[0].Rows[stt]["tenNganHang"].ToString();
                txtSTK.Text = ds.Tables[0].Rows[stt]["taiKhoan"].ToString();
                txtTenNCC.Text = ds.Tables[0].Rows[stt]["tenNCC"].ToString();
                rtxtGhiChu.Text = ds.Tables[0].Rows[stt]["ghiChu"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[stt]["email"].ToString();
                int tt = Convert.ToInt32(ds.Tables[0].Rows[stt]["trangThai"].ToString());
                if (tt == 1)
                {
                    cboTrangThai.Text = "Hoạt động";
                }
                else
                {
                    cboTrangThai.Text = "Không hoạt động";
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtMaNCC.Text != "" && txtTenNCC.Text != "")
            {
                sql = "update NHACUNGCAP set trangThai = 0 where maNCC = '"+txtMaNCC.Text+"'";
            }
            try
            {
                if (c.capNhatDuLieu(sql) > 0)
                {
                    MessageBox.Show("XOA OKE");
                    frmNHACUNGCAP_Load(sender, e);
                    xoaDL();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvNCC_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flagCN)
            {
                if (e.ColumnIndex == 1)
                {
                    string maNCC = dgvNCC.CurrentRow.Cells[0].Value.ToString();
                    string tenNganHang = dgvNCC.CurrentRow.Cells[3].Value.ToString();
                    string stk = dgvNCC.CurrentRow.Cells[2].Value.ToString();
                    string tenNCC = dgvNCC.CurrentRow.Cells[1].Value.ToString();
                    string ghiChu = dgvNCC.CurrentRow.Cells[5].Value.ToString();
                    string email = dgvNCC.CurrentRow.Cells[4].Value.ToString();
                    string tt = dgvNCC.CurrentRow.Cells[6].Value.ToString();


                    string sql = "update NHACUNGCAP set tenNCC = '" + tenNCC + "', taiKhoan = '" + stk + "', tenNganHang='" + tenNganHang + "',email='" + email + "',ghiChu='" + ghiChu + "',trangThai='" + tt + "' where maNCC = '" + maNCC + "'";
                    if (c.capNhatDuLieu(sql) > 0)
                    {
                        MessageBox.Show("CAP NHAT OKE");
                        frmNHACUNGCAP_Load(sender, e);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtMaNCC.Text != "" && txtTenNCC.Text != "")
            {
                sql = "update NHACUNGCAP set tenNCC = '" + txtTenNCC.Text + "', taiKhoan = '" + txtSTK.Text + "', tenNganHang='" + txtNganHang.Text + "',email='" + txtEmail.Text + "',ghiChu='" + rtxtGhiChu.Text + "',trangThai='" + cboTrangThai.SelectedIndex.ToString() + "' where maNCC = '" + txtMaNCC.Text + "'";
            }
            try
            {
                if (c.capNhatDuLieu(sql) > 0)
                {
                    MessageBox.Show("CAP NHAT OKE");
                    frmNHACUNGCAP_Load(sender, e);
                    xoaDL();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmNHACUNGCAP_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmHOADONNHAP != null)
            {
                frmHOADONNHAP.capNhatNCCKhiThemMoi();
            }
        }
    }
}
