using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _56_60_bandienthoai
{
    public partial class frmNHANVIEN : Form
    {
        public frmNHANVIEN()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet ds;
        DataSet dsNhanVienAn;
        string[] tenCot = new string[] { "Mã Nhân Viên", "Tên Đăng Nhập", "Mật Khẩu", "Họ Tên", "Email", "Địa Chỉ", "Điện Thoại", "Ngày Sinh", "Giới Tính", "Ghi Chú", "Trạng Thái" };
        void danhsach_datagridview(DataGridView d, string sql)
        {
            ds = c.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void loadPhimChucNang(bool status)
        {
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            btnXoa.Enabled = status;
            btnSua.Enabled = status;
            btnThem.Enabled = status;
        }
       

        private void frmNHANVIEN_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvNhanVien, "Select * from dbo.NHANVIEN where trangThai=1");
            dsNhanVienAn = c.layDuLieu("Select * from dbo.NHANVIEN");
            dgvAn.DataSource = dsNhanVienAn.Tables[0];
            loadPhimChucNang(true);
            for (int i = 0; i < dgvNhanVien.Columns.Count; i++)
            {
                dgvNhanVien.Columns[i].HeaderText = tenCot[i];
            }
            vohieuhoa(false);

        }

        private void frmNHANVIEN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                DialogResult kq;
                kq = MessageBox.Show("DỮ LIỆU CHƯA ĐƯỢC LƯU", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
        //Dùng để tránh trường hợp dữ liệu bị mất ở khúc trên làm xáo trộn stt nên sẽ lấy stt ở cuối để cộng 1
        void themMoi(DataSet ds, TextBox a, DataGridView dgv, string tenCot, string tenDat, int soLuong)
        {
            int lastRowIndex = dgv.RowCount - 1;
            DataGridViewRow dong = dgv.Rows[lastRowIndex];
            int tt = Convert.ToInt32(ds.Tables[0].Rows[lastRowIndex][tenCot].ToString().Substring(soLuong)) + 1;
            a.Text = tenDat + tt.ToString();
        }
        //void themMoi()
        //{
        //    int stt = ds.Tables[0].Rows.Count;
        //    txtMa.Text = "NV" + (stt + 1).ToString();
        //}
        private void btnThem_Click(object sender, EventArgs e)
        {
            loadPhimChucNang(false);
            clear();
            themMoi(dsNhanVienAn,txtMa, dgvAn, "maNV", "NV", 2);
            vohieuhoa(true);

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            vohieuhoa(true);
            loadPhimChucNang(false);
            btnSua.Visible = false;
            btnOk.Visible = true;
            btnLuu.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "";
            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn có chắc chắc Xóa Nhân Viên này!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                sql = "update NHANVIEN set trangThai = '0' where maNV = '"+txtMa.Text+"'";
            try
            {
                if (c.capNhatDuLieu(sql) > 0)
                {
                    MessageBox.Show("Xóa Thành Công Nhân Viên");
                    frmNHANVIEN_Load(sender, e);
                    clear();
                    loadPhimChucNang(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

        }
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            loadPhimChucNang(true);
            clear();

        }
        int flag = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            loadPhimChucNang(true);
            string sql = "";
            if (flag == 0 && txtTen.Text!="" && txtDiaChi.Text != "" && txtEmail.Text != "" && txtMa.Text != "" && txtMatKhau.Text != "" && txtNgaySinh.Text != "" && txtSDT.Text != "" && txtTaiKhoan.Text != "")
            {   
                string trangthai = cboTrangThai.SelectedIndex == 0 ? "0" : "1";
                string gioitinh = radNam.Checked ? "Nam" : "Nữ";
                sql = "INSERT INTO NHANVIEN VALUES ('" + txtMa.Text + "','" + txtTaiKhoan.Text + "','" + txtMatKhau.Text + "',N'" + txtTen.Text + "',N'" + txtEmail.Text + "',N'" + txtDiaChi.Text + "','" + txtSDT.Text + "','" + txtNgaySinh.Text + "',N'" + gioitinh +"',N''," +trangthai +")";
               
                try
                {
                        c.capNhatDuLieu(sql);
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                        c.dongKetNoi();
                        frmNHANVIEN_Load(sender, e);
                
                }
                catch
                {
                    MessageBox.Show("Thông tin nhập không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Thông tin nhập không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dgvNhanVien_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int stt = e.RowIndex;
            txtMa.Text = ds.Tables[0].Rows[stt]["maNV"].ToString();
            txtTaiKhoan.Text = ds.Tables[0].Rows[stt]["tenDangNhap"].ToString();
            txtMatKhau.Text = ds.Tables[0].Rows[stt]["matKhau"].ToString();
            txtSDT.Text = ds.Tables[0].Rows[stt]["dienThoai"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[stt]["email"].ToString();
            txtTen.Text = ds.Tables[0].Rows[stt]["hoTen"].ToString();
            txtDiaChi.Text = ds.Tables[0].Rows[stt]["diaChi"].ToString();
            txtNgaySinh.Text = ds.Tables[0].Rows[stt]["ngSinh"].ToString();
   
            if (ds.Tables[0].Rows[stt]["gioiTinh"].ToString() == "Nam")
            {
                radNam.Checked = true;
            }
            else
            { 
                radNu.Checked = true; 
            }
            if(ds.Tables[0].Rows[stt]["trangThai"].ToString() == "0")
            {
                cboTrangThai.SelectedIndex = 0;
            }
            else
            {
                cboTrangThai.SelectedIndex =1;

            }
            vohieuhoa(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string sql = "";
            DialogResult dlg = new DialogResult();
            dlg=MessageBox.Show("Bạn có chắc thay đổi thông tin Nhân Viên","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                    string gioitinh = radNam.Checked ? "Nam" : "Nữ";
                    sql = "update NHANVIEN set tenDangNhap = '" + txtTaiKhoan.Text + "', matKhau = '" + txtMatKhau.Text + "', " +
                        "hoTen = '" + txtTen.Text + "', email = '" + txtEmail.Text + "', diaChi = '" + txtDiaChi.Text + "', dienThoai = '" + txtSDT.Text + "',  ngSinh = '" + txtNgaySinh.Text + "', " +
                        "gioiTinh = '" + gioitinh + "', trangThai = '" + cboTrangThai.SelectedIndex + "' where maNV = '" + txtMa.Text + "'";
                try
                {
                    if (c.capNhatDuLieu(sql) > 0)
                    {
                        MessageBox.Show("Thay đổi Thành Công");
                        frmNHANVIEN_Load(sender, e);
                        clear();
                        loadPhimChucNang(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        private void vohieuhoa(bool t)
        {
            txtMa.Enabled = t;
            txtTaiKhoan.Enabled = t;
            txtMatKhau.Enabled = t;
            txtTen.Enabled = t;
            txtEmail.Enabled = t;
            txtDiaChi.Enabled = t;
            txtSDT.Enabled = t;
            txtNgaySinh.Enabled = t;
            radNam.Enabled = t;
            radNu.Enabled = t;
            cboTrangThai.Enabled = t;
            
        }
        void clear()
        {
            btnSua.Visible = true;
            btnOk.Visible = false;
            txtMa.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtNgaySinh.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            cboTrangThai.SelectedIndex = -1;
        }
    }
}
