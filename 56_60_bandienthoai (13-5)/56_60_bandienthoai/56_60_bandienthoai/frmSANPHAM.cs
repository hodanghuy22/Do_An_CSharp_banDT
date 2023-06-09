using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace _56_60_bandienthoai
{
   

    public partial class frmSANPHAM : Form
    {
        public frmSANPHAM()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet dsCTSP,dsSP;
        DataSet dsNCC;
        DataSet dsTenLoaiSP;
        Boolean co = false;
        Boolean flagCN = false;
        string fileHinh="";
        int flag = 0;

        public class MyComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                int valueX = ((DataGridViewCell)((DataGridViewRow)x).Cells[0]).Tag == null ? 0 : (int)((DataGridViewCell)((DataGridViewRow)x).Cells[0]).Tag;
                int valueY = ((DataGridViewCell)((DataGridViewRow)y).Cells[0]).Tag == null ? 0 : (int)((DataGridViewCell)((DataGridViewRow)y).Cells[0]).Tag;
                return valueX.CompareTo(valueY);
            }
        }

        void danhsach_datagridview(DataGridView d, string sql, ref DataSet ds)
        {
            // Lấy danh sách dữ liệu từ câu truy vấn SQL
            ds = c.layDuLieu(sql);
            // Đưa dữ liệu vào DataGridView
            d.DataSource = ds.Tables[0];
            d.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


        }

        private void loadPhimChucNang(bool status)
        {
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            btnXoa.Enabled = status;
            btnSua.Enabled = status;
            btnMoi.Enabled = status;
        }
        private void loadComboBox(ComboBox cb, DataSet dt, string sql, string ten, string giatri)
        {
            dt = c.layDuLieu(sql);
            cb.DataSource = dt.Tables[0];
            cb.DisplayMember = ten;
            cb.ValueMember = giatri;
            cb.SelectedIndex = -1;

        }
        private void vohieuhoa(bool t)
        {
            cboMaNCC.Enabled = t;
            txtMauSac.Enabled = t;
            cboTenLoaiSP.Enabled = t;
            cboTrangThai.Enabled = t;
            txtGiaBan.Enabled = t;
            txtGiaNhap.Enabled = t;
            txtMaSP.Enabled = t;
            txtSoLuong.Enabled = t;
            txtTenSP.Enabled = t;
            rtxtMoTa.Enabled = t;
        }
        private void clear()
        {
            cboMaNCC.SelectedIndex=-1;
            txtMauSac.Text = "";
            cboTenLoaiSP.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            rtxtMoTa.Clear();
            picHinh.Image=null;
        }
        public void capNhatLSPKhiThemMoi()
        {
            loadComboBox(cboTenLoaiSP, dsCTSP, "select * from LOAISP", "ten", "ten");
        }
        private void frmCTSANPHAM_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvCTSP, "SELECT *,ten\r\nFROM CTSANPHAM,LOAISP\r\nWHERE maSP LIKE 'SP%' and CTSANPHAM.maLoaiSP=LOAISP.maLoaiSP\r\nORDER BY CAST(SUBSTRING(maSP, 3, LEN(maSP)) AS INT) DESC ;", ref dsCTSP);
            danhsach_datagridview(dgvSanPham, "SELECT *,NHACUNGCAP.tenNCC\r\nFROM SANPHAM ,NHACUNGCAP\r\nWHERE maSP LIKE 'SP%' and SANPHAM.maNCC=NHACUNGCAP.maNCC\r\nORDER BY CAST(SUBSTRING(maSP, 3, LEN(maSP)) AS INT) DESC;", ref dsSP);
            
            loadPhimChucNang(true);
            flagCN = true;
            loadComboBox(cboMaNCC, dsNCC, "select * from NHACUNGCAP", "tenNCC", "maNCC");
            loadComboBox(cboTenLoaiSP, dsNCC, "select * from LOAISP", "ten", "maLoaiSP");
            btnUpdate.Visible = true;
            co = true;
        }

        private void frmCTSANPHAM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                DialogResult kq;
                kq = MessageBox.Show("DỮ LIỆU CHƯA ĐƯỢC LƯU", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            loadPhimChucNang(true);
            string sql = "";
            string sql2="" ;
            if (flag == 1 && co == true)
            {
                if (cboTenLoaiSP.SelectedIndex != -1 && txtMaSP.Text != "")
                {
                    dsNCC = c.layDuLieu("select tenNCC,maNCC from NHACUNGCAP");
                    DataTable dtNCC = dsNCC.Tables[0];
                    DataRow[] rows = dtNCC.Select($"tenNCC = '{cboMaNCC.SelectedItem.ToString()}'");

                    dsTenLoaiSP = c.layDuLieu("select ten,maLoaiSP from LOAISP");
                    DataTable dtLoaiSP = dsTenLoaiSP.Tables[0];
                    DataRow[] rows1 = dtLoaiSP.Select($"ten = '{cboTenLoaiSP.SelectedItem.ToString()}'");

                    string maNCC = "";
                    if (rows.Length > 0)
                    {
                        maNCC = rows[0]["maNCC"].ToString();
                    }

                    string maLoaiSP = "";
                    if (rows1.Length > 0)
                    {
                        maLoaiSP = rows1[0]["maLoaiSP"].ToString();
                    }


                    // Lấy giá trị cột maNCC của hàng dữ liệu tìm được
                    sql = "insert into SANPHAM(maSP,moTa,trangThai,maNCC) VALUES('"+txtMaSP.Text+"',N'"+rtxtMoTa.Text+"','"+cboTrangThai.SelectedIndex.ToString()+"','"+cboMaNCC.SelectedValue.ToString()+"')";
                    sql2 = "insert into CTSANPHAM(maSP,maLoaiSP,tenSP,soLuong,giaNhap,giaBan,hinh,mauSac) VALUES('" + txtMaSP.Text + "','"+cboTenLoaiSP.SelectedValue.ToString()+"',N'" + txtTenSP.Text + "'," + txtSoLuong.Text + "," + txtGiaNhap.Text +","+txtGiaBan.Text+ ",N'" + fileHinh + "',N'" + txtMauSac.Text+"')";
                    label1.Text = cboTenLoaiSP.SelectedValue.ToString();

                }
                else
                {
                    MessageBox.Show("Thông tin nhập chưa hợp lệ, hoặc chưa đủ","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            if (c.capNhatDuLieu(sql) > 0)
            {
                c.capNhatDuLieu(sql2);
                MessageBox.Show("LUU OKE");
                frmCTSANPHAM_Load(sender, e);
                loadPhimChucNang(true);
                vohieuhoa(false);
                flag = 0;
            }
           
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
            btnUpdate.Visible = false;
            btnSua.Visible = true;
            vohieuhoa(false);
            loadPhimChucNang(true);
        }


        //Dùng để tránh trường hợp dữ liệu bị mất ở khúc trên làm xáo trộn stt nên sẽ lấy stt ở cuối để cộng 1
        void themMoi(DataSet ds, TextBox a, DataGridView dgv, string tenCot, string tenDat)
        {
            int maxSoThuTu = 0;

            // Tìm giá trị số thứ tự lớn nhất trong cột
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int soThuTu = Convert.ToInt32(row[tenCot].ToString().Substring(tenDat.Length));
                if (soThuTu > maxSoThuTu)
                {
                    maxSoThuTu = soThuTu;
                }
            }

            // Tạo chuỗi mã sản phẩm mới
            string maSPMoi = tenDat + (maxSoThuTu + 1);

            // Gán mã sản phẩm mới vào TextBox
            a.Text = maSPMoi;

            // Thêm sản phẩm mới vào DataGridView
            ds.Tables[0].Rows.Add(maSPMoi);
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            loadPhimChucNang(false);
            clear();
            themMoi(dsSP, txtMaSP, dgvSanPham, "maSP","SP");
            flag = 1;
            vohieuhoa(true);
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCTSP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flagCN)
            {
                if (e.ColumnIndex == 1)
                {
                    string maSP = dgvCTSP.CurrentRow.Cells[0].Value.ToString();
                    string maMau = dgvCTSP.CurrentRow.Cells[1].Value.ToString();
                    string maHinh = dgvCTSP.CurrentRow.Cells[0].Value.ToString();
                    string maLoaiSP = dgvCTSP.CurrentRow.Cells[1].Value.ToString();
                    string tenSP = dgvCTSP.CurrentRow.Cells[0].Value.ToString();
                    string soLuong = dgvCTSP.CurrentRow.Cells[1].Value.ToString();
                    string giaNhap = dgvCTSP.CurrentRow.Cells[0].Value.ToString();
                    string giaBan = dgvCTSP.CurrentRow.Cells[1].Value.ToString();
                    string ghiChu = dgvCTSP.CurrentRow.Cells[0].Value.ToString();
                    string tt = dgvCTSP.CurrentRow.Cells[1].Value.ToString();


                    string sql = "update CTSANPHAM set maSP = '"+ maSP + "', maMau = '"+ maMau + "', maHinh = '"+ maHinh + "', maLoaiSP = '"+ maLoaiSP + "', tenSP = '"+ tenSP + "', soLuong = '"+ soLuong + "', giaNhap = '"+ giaNhap + "',giaBan = '"+ giaBan + "', ghiChu = '"+ ghiChu + "', trangThai = '"+ tt + "'where maSP = '"+ maSP + "', maMau = '"+ maMau + "', maHinh = '"+ maHinh + "', maLoaiSP = '"+ maLoaiSP + "'";
                    if (c.capNhatDuLieu(sql) > 0)
                    {
                        MessageBox.Show("CAP NHAT OKE");
                        frmCTSANPHAM_Load(sender, e);
                    }
                }
            }
        }

       

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (co == true)
            {
                DialogResult d= MessageBox.Show("Bạn có chắc chắn muốn xóa SẢN PHẨM này","THÔNG BÁO",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (d==DialogResult.Yes)
                {
                    
                    sql = "update SANPHAM set trangThai = 0 where maSP = '"+txtMaSP.Text+ "' update CTSANPHAM set trangThai = 0 where maSP = '" + txtMaSP.Text + "'";
                    if (c.capNhatDuLieu(sql) > 0)
                    {
                        MessageBox.Show("XOA OKE");
                        frmCTSANPHAM_Load(sender, e);
                        vohieuhoa(true);
                    }
                }
            }
        }

        private void btnHinhDaiDien_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = Path.GetFullPath("Hinh") + @"\";
            o.ShowDialog();

            string tenFile = o.FileName;
            fileHinh = Path.GetFileName(tenFile);
            Bitmap hinh = new Bitmap(tenFile);
            picHinh.Image = hinh;
            picHinh.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void dgvCTSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                
            
            if (e.RowIndex >= 0 && e.RowIndex < dgvCTSP.Rows.Count - 1)
            {

                //dgvSanPham_CellClick(sender, e);
                int stt = e.RowIndex;
               
                txtGiaBan.Text = dsCTSP.Tables[0].Rows[stt]["giaBan"].ToString();
            txtGiaNhap.Text = dsCTSP.Tables[0].Rows[stt]["giaNhap"].ToString();
            txtSoLuong.Text = dsCTSP.Tables[0].Rows[stt]["soLuong"].ToString();
            txtMauSac.Text = dsCTSP.Tables[0].Rows[stt]["mauSac"].ToString();
            cboTenLoaiSP.Text = dsCTSP.Tables[0].Rows[stt]["ten"].ToString();
            txtTenSP.Text = dsCTSP.Tables[0].Rows[stt]["tenSP"].ToString();

            string imagePath = @"Hinh/" + dsCTSP.Tables[0].Rows[stt]["hinh"].ToString();
            Console.WriteLine("ASD: " + imagePath);
            picHinh.Load(imagePath);
            vohieuhoa(false);
            }


        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSanPham.Rows.Count - 1)
            {

                int stt = e.RowIndex;
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    // Lấy mã sản phẩm từ ô được chọn
                    string maSP = dgvSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();

                    // Lặp lại các hàng trong DataGridView2
                    foreach (DataGridViewRow row in dgvCTSP.Rows)
                    {
                        // Nếu hàng hiện tại có mã sản phẩm tương ứng, hãy chọn nó và thoát khỏi vòng lặp
                        if (row.Cells[0].Value.ToString() == maSP)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }



            txtMaSP.Text = dsSP.Tables[0].Rows[stt]["maSP"].ToString();
            rtxtMoTa.Text = dsSP.Tables[0].Rows[stt]["moTa"].ToString();
            cboMaNCC.Text = dsSP.Tables[0].Rows[stt]["maNCC"].ToString();
            cboTrangThai.Text = dsSP.Tables[0].Rows[stt]["trangThai"].ToString();
            cboMaNCC.Text = dsSP.Tables[0].Rows[stt]["tenNCC"].ToString() ;
            vohieuhoa(false);
            }

        }

        private void btnThemLoaiSP_Click(object sender, EventArgs e)
        {
            // Tạo mới đối tượng frmLOAISP
            frmLOAISP lsp = new frmLOAISP();

            // Gán giá trị cho thuộc tính ParentForm trên form con
            lsp.frmSANPHAM = this;

            // Hiển thị form con
            lsp.ShowDialog();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "";
            string sql2 = "";
            if (co == true)
            {
                    sql = "UPDATE SANPHAM SET moTa=N'"+rtxtMoTa.Text+"',trangThai='"+cboTrangThai.SelectedIndex.ToString()+"',maNCC='"+cboMaNCC.SelectedValue.ToString()+"' WHERE maSP='"+txtMaSP+"'";
                    sql2 = "UPDATE CTSANPHAM SET maLoaiSP='"+cboTenLoaiSP.SelectedValue.ToString()+"',tenSP=N'"+txtTenSP.Text+"',soLuong="+txtSoLuong.Text+",giaBan="+txtGiaBan.Text+",giaNhap="+txtGiaNhap.Text+",hinh=N'"+fileHinh+"',mauSac=N'"+txtMauSac.Text+"',ghiChu=N'"+rtxtMoTa.Text+"'  WHERE maSP='"+txtMaSP.Text+"'";
            }
            try
            {
                c.capNhatDuLieu(sql);
                c.capNhatDuLieu(sql2);
                MessageBox.Show("Cập nhật thành công");
                frmCTSANPHAM_Load(sender, e);
                vohieuhoa(true);
                loadPhimChucNang(true);
                btnSua.Visible = true;
                btnUpdate.Visible = false;
            }
            catch {
                MessageBox.Show("Cập nhật thất bại");

            }

        }
        string maSP = "";
        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                return;
            }

            // Lấy mã sản phẩm từ hàng được chọn trong DataGridView1
            maSP = dgvSanPham.SelectedRows[0].Cells[0].Value.ToString();

            // Cập nhật lại thông tin trên DataGridView2 dựa trên mã sản phẩm đã chọn
            foreach (DataGridViewRow row in dgvCTSP.Rows)
            {
                // Nếu hàng hiện tại có mã sản phẩm tương ứng, hãy cập nhật thông tin và thoát khỏi vòng lặp
                if (row.Cells[0].Value.ToString() == maSP)
                {
                    row.Selected = true;
                    txtGiaBan.Text = dsCTSP.Tables[0].Rows[row.Index]["giaBan"].ToString();
                    txtGiaNhap.Text = dsCTSP.Tables[0].Rows[row.Index]["giaNhap"].ToString();
                    txtSoLuong.Text = dsCTSP.Tables[0].Rows[row.Index]["soLuong"].ToString();
                    txtMauSac.Text = dsCTSP.Tables[0].Rows[row.Index]["mauSac"].ToString();
                    cboTenLoaiSP.Text = dsCTSP.Tables[0].Rows[row.Index]["ten"].ToString();
                    txtTenSP.Text = dsCTSP.Tables[0].Rows[row.Index]["tenSP"].ToString();

                    string imagePath = @"Hinh/" + dsCTSP.Tables[0].Rows[row.Index]["hinh"].ToString();
                    Console.WriteLine("ASD: " + imagePath);
                    picHinh.Load(imagePath);
                    vohieuhoa(false);

                    break;
                }
            }
            dgvCTSP.ClearSelection();

            // Đặt lại biến maSP thành rỗng
            maSP = "";

            // Gọi lại phương thức xử lý sự kiện RowEnter của DataGridView2
            dgvCTSP_RowEnter(null, null);
        }

        private void dgvCTSP_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCTSP.SelectedRows.Count == 0)
            {
                return;
            }

            // Lấy mã sản phẩm từ hàng được chọn trong DataGridView2
            string maSP = dgvCTSP.SelectedRows[0].Cells[0].Value.ToString();

            // Cập nhật lại thông tin trên các control dựa trên mã sản phẩm đã chọn
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                // Nếu hàng hiện tại có mã sản phẩm tương ứng, hãy chọn hàng đó và thoát khỏi vòng lặp
                if (row.Cells[0].Value.ToString() == maSP)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void dgvSanPham_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCTSP_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            vohieuhoa(true);
            loadPhimChucNang(false);
            btnSua.Visible = false;
            btnUpdate.Visible = true;
            btnLuu.Enabled= false;
        }

       
    }
}
