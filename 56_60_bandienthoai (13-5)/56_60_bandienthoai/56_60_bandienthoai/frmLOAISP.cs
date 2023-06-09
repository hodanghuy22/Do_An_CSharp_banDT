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
    public partial class frmLOAISP : Form
    {
        public frmSANPHAM frmSANPHAM;
        public frmLOAISP()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet dsLoaiSP = new DataSet();
        int flag = 0;
        void danhsach_datagridview(DataGridView d, string sql,ref DataSet ds)
        {
            ds = c.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void frmLoaiSP_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvLoaiSP, "select *, CONVERT(INT, SUBSTRING(maLoaiSP, 4, LEN(maLoaiSP)-3)) AS ColPhu from LOAISP ORDER BY ColPhu ASC;", ref dsLoaiSP);
            loadPhimChucNang(true);
            flag = 2;
        }
        private void loadPhimChucNang(bool status)
        {
            btnLuu.Enabled = !status;
            btnXoa.Enabled = status;
            btnSua.Enabled = status;
            btnMoi.Enabled = status;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoaiSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                DialogResult kq;
                kq = MessageBox.Show("DỮ LIỆU CHƯA ĐƯỢC LƯU,BẠN CÓ MUỐN THOÁT", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(kq==DialogResult.No)
                e.Cancel = true;
                else
                {
                    e.Cancel=false;
                }
            }
        }
        //Dùng để tránh trường hợp dữ liệu bị mất ở khúc trên làm xáo trộn stt nên sẽ lấy stt ở cuối để cộng 1
        void themMoi(DataSet ds, TextBox a, DataGridView dgv, string tenCot, string tenDat,int soLuong)
        {
            int lastRowIndex = dgv.RowCount - 2;
            DataGridViewRow dong = dgv.Rows[lastRowIndex];
            int tt = Convert.ToInt32(ds.Tables[0].Rows[lastRowIndex][tenCot].ToString().Substring(soLuong)) + 1;
            a.Text = tenDat + tt.ToString();
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            loadPhimChucNang(false);
            themMoi(dsLoaiSP, txtMaloai, dgvLoaiSP, "maLoaiSP", "LSP",3);
            flag = 1;
        }
        void xoaTextBox()
        {
            txtMaloai.Clear();
            txtTenLoai.Clear(); 
            txtGhiChu.Clear();
            cboTrangThai.Text = "";
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            xoaTextBox();
            loadPhimChucNang(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(flag == 1)
            {
                string sql = "";
                if(txtMaloai.Text != "")
                {
                    sql = "insert LOAISP values('"+txtMaloai.Text+"','"+txtTenLoai.Text+ "','"+txtGhiChu.Text+ "','"+cboTrangThai.SelectedIndex.ToString()+"')";
                }
                try
                {
                    if (c.capNhatDuLieu(sql) > 0)
                    {
                        MessageBox.Show("LUU OKE");
                        frmLoaiSP_Load(sender, e);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtMaloai.Text != "")
            {
                sql = "delete from LOAISP where maLoaiSP = '"+txtMaloai.Text+"'";
            }
            try
            {
                if (c.capNhatDuLieu(sql) > 0)
                {
                    MessageBox.Show("XOA OKE");
                    frmLoaiSP_Load(sender, e);
                    loadPhimChucNang(true);
                    flag = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dgvLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvLoaiSP.Rows.Count - 1)
            {
                int stt = e.RowIndex;
                txtMaloai.Text = dsLoaiSP.Tables[0].Rows[stt]["maLoaiSP"].ToString();
                txtTenLoai.Text = dsLoaiSP.Tables[0].Rows[stt]["ten"].ToString();
                txtGhiChu.Text = dsLoaiSP.Tables[0].Rows[stt]["ghiChu"].ToString();
                cboTrangThai.SelectedIndex = Convert.ToInt32(dsLoaiSP.Tables[0].Rows[stt]["trangThai"].ToString());
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtMaloai.Text != "")
            {
                sql = "update LOAISP set ten = '"+txtTenLoai.Text+"', ghiChu = '"+txtGhiChu.Text+"', trangThai = '"+cboTrangThai.SelectedIndex.ToString()+"' where maLoaiSP = '"+txtMaloai.Text+"'";
            }
            try
            {
                if (c.capNhatDuLieu(sql) > 0)
                {
                    MessageBox.Show("CAP NHAT OKE");
                    frmLoaiSP_Load(sender, e);
                    loadPhimChucNang(true);
                    flag = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dgvLoaiSP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flag == 2)
            {
                if (e.ColumnIndex == 1)
                {
                    string maLoai = dgvLoaiSP.CurrentRow.Cells[0].Value.ToString();
                    string ten = dgvLoaiSP.CurrentRow.Cells[1].Value.ToString();
                    string ghiChu = dgvLoaiSP.CurrentRow.Cells[2].Value.ToString();
                    string trangThai = dgvLoaiSP.CurrentRow.Cells[3].Value.ToString();
                    string sql = "update LOAISP set ten = '"+ten+"', ghiChu = '"+ghiChu+"', trangThai = '"+trangThai+"' where maLoaiSP = '"+maLoai+"'";
                    if (c.capNhatDuLieu(sql) > 0)
                    {
                        MessageBox.Show("CAP NHAT OKE");
                        frmLoaiSP_Load(sender, e);
                    }
                }
            }
        }

        private void frmLOAISP_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmSANPHAM != null)
            {
                frmSANPHAM.capNhatLSPKhiThemMoi();
            }
        }

        
    }
}
