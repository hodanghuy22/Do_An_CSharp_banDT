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
    public partial class frmHOADONNHAP : Form
    {
        public frmHOADONNHAP()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet dsCTHDB, dsHDB;
        DataSet dsCNHDTHEOKH, dsCNCTHDTHEOKH;
        DataSet dsMaSP, dsMaNV, dsmaNCC;
        int sttDSSP;
        Boolean co = false;
        int flag = 0;
        int soLuongTrcKhiSua, thanhTienTrcKhiSua;

        void capNhatTongTien(DataGridView dgv, TextBox txt)
        {
            int tongTien = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    tongTien += int.Parse(row.Cells["thanhTien"].Value.ToString());
                }
            }
            txt.Text = tongTien.ToString();
        }

        private void frmHOADONNHAP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                DialogResult kq;
                kq = MessageBox.Show("DỮ LIỆU CHƯA ĐƯỢC LƯU", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void themMoi(DataSet ds, TextBox a, DataGridView dgv, string tenCot, string tenDat, int soLuong)
        {
            int lastRowIndex = 0;
            //int lastRowIndex = dgv.RowCount - 2;
            DataGridViewRow dong = dgv.Rows[lastRowIndex];
            int tt = Convert.ToInt32(ds.Tables[0].Rows[lastRowIndex][tenCot].ToString().Substring(soLuong)) + 1;
            a.Text = tenDat + tt.ToString();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            loadPhimChucNang(false);
            flag = 1;
            themMoi(dsHDB, txtMaHD, dgvHDNhap, "maHD", "HDB", 3);
            txtNgayNhap.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int bang = 0;
                int dong = 0;
                loadPhimChucNang(true);
                string sql = "";
                Console.WriteLine("flag: " + flag + " co: = " + co + " dgvDSSP: " + (dgvDSSP.RowCount > 0));
                if (flag == 1 && co == true && dgvDSSP.RowCount > 0)
                {
                    Console.WriteLine("ASDASDASDSD");
                    if (txtMaHD.Text != "")
                    {
                        Console.WriteLine("=========ASDSAD=========");
                        sql = "insert into HOADONNHAP values('" + txtMaHD.Text + "','" + cboMaNV.SelectedValue + "'," +
                            "'" + cboMaNCC.SelectedValue + "','" + txtNgayNhap.Text + "','" + txtTongTien.Text + "'," +
                            "'" + txtGhiChu.Text + "', '" + cboTrangThai.SelectedIndex.ToString() + "')";
                        Console.WriteLine("Bang: " + sql);
                        try
                        {
                            bang += c.capNhatDuLieu(sql);
                            foreach (DataGridViewRow row in dgvDSSP.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    sql = "insert into CTHOADONNHAP values('" + row.Cells["maHD"].Value.ToString() + "'," +
                                        "'" + row.Cells["maSP"].Value.ToString() + "'," +
                                        "'" + row.Cells["soLuong"].Value.ToString() + "'," +
                                        "'" + row.Cells["donGia"].Value.ToString() + "'," +
                                        "'" + row.Cells["thanhTien"].Value.ToString() + "'," +
                                        "'" + row.Cells["ghiChu"].Value.ToString() + "')";
                                    Console.WriteLine("Dong: " + sql);
                                    try
                                    {
                                        dong += c.capNhatDuLieu(sql);
                                        DataSet dsSP = c.layDuLieu("select * from CTSANPHAM where maSP = '" + row.Cells["maSP"].Value.ToString() + "'");
                                        int soLuongSPConLai = int.Parse(dsSP.Tables[0].Rows[0]["soLuong"].ToString())
                                            + int.Parse(row.Cells["soLuong"].Value.ToString());

                                        Console.WriteLine("SOLUONGCONLAI: " + soLuongSPConLai);

                                        sql = "update CTSANPHAM set soLuong = '" + soLuongSPConLai + "' where maSP = '" + row.Cells["maSP"].Value.ToString() + "'";
                                        c.capNhatDuLieu(sql);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                if (bang > 0)
                {
                    MessageBox.Show("LUU OKE");
                    //frmCTHOADONNHAP_Load(sender, e);
                    frmHOADONNHAP_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Bang: " + bang + " Dong: " + dong);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmHOADONNHAP_Load(sender, e);
        }

        private void dgvCTHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCTHDNhap.Rows.Count - 1)
            {
                int stt = e.RowIndex;
                txtMaHD.Text = dsCTHDB.Tables[0].Rows[stt]["maHD"].ToString();
                txtDonGia.Text = dsCTHDB.Tables[0].Rows[stt]["donGia"].ToString();
                cboMaSP.SelectedValue = dsCTHDB.Tables[0].Rows[stt]["maSP"].ToString();
                txtSoLuong.Text = dsCTHDB.Tables[0].Rows[stt]["soLuong"].ToString();
                txtThanhTien.Text = dsCTHDB.Tables[0].Rows[stt]["tongTien"].ToString();
                txtGhiChu.Text = dsCTHDB.Tables[0].Rows[stt]["ghiChu"].ToString();

                soLuongTrcKhiSua = int.Parse(txtSoLuong.Text);
                thanhTienTrcKhiSua = int.Parse(txtThanhTien.Text);

                danhsach_datagridview(dgvHDNhap, "select * from HOADONNHAP where maHD = '" + txtMaHD.Text + "'", ref dsHDB);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                frmLuaChonHDHoacCTHD chooseForm = new frmLuaChonHDHoacCTHD();
                DialogResult result = chooseForm.ShowDialog();
                int cthd = 0, hd = 0;

                if (result == DialogResult.OK)
                {
                    int choice = (int)chooseForm.Tag;

                    switch (choice)
                    {
                        case 1:
                            string sql = "";
                            Console.WriteLine("++++++++");
                            try
                            {
                                if (co == true)
                                {
                                    Console.WriteLine("ADASDSDSAD");
                                    if (txtMaHD.Text != "")
                                    {
                                        foreach (DataGridViewRow row in dgvCTHDNhap.Rows)
                                        {
                                            if (!row.IsNewRow)
                                            {
                                                if (row.Cells["maHD"].Value.ToString() == txtMaHD.Text)
                                                {
                                                    DataSet dsSP = c.layDuLieu("select * from CTSANPHAM where maSP = '" + row.Cells["maSP"].Value.ToString() + "'");
                                                    int soLuongSPConLai = int.Parse(dsSP.Tables[0].Rows[0]["soLuong"].ToString())
                                                        - int.Parse(row.Cells["soLuong"].Value.ToString());

                                                    Console.WriteLine("SOLUONGCONLAI: " + soLuongSPConLai);

                                                    sql = "update CTSANPHAM set soLuong = '" + soLuongSPConLai + "' where maSP = '" + row.Cells["maSP"].Value.ToString() + "'";
                                                    c.capNhatDuLieu(sql);
                                                    sql = "delete from CTHOADONNHAP where maHD = '" + txtMaHD.Text + "'";
                                                    Console.WriteLine("CTHD: " + sql);

                                                    try
                                                    {
                                                        cthd += c.capNhatDuLieu(sql);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show(ex.Message);
                                                    }
                                                }
                                            }
                                        }

                                        try
                                        {
                                            sql = "delete from HOADONNHAP where maHD = '" + txtMaHD.Text + "'";
                                            Console.WriteLine("HD: " + sql);
                                            try
                                            {
                                                hd += c.capNhatDuLieu(sql);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                }
                                if (hd > 0)
                                {
                                    MessageBox.Show("XOA OKE");
                                    frmHOADONNHAP_Load(sender, e);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case 2:
                            string sql2 = "";
                            Console.WriteLine("=====asdasdas=======");
                            try
                            {
                                if (co == true)
                                {
                                    Console.WriteLine("bgbgbgbgb");
                                    if (txtMaHD.Text != "")
                                    {
                                        DataSet dsSP = c.layDuLieu("select * from CTSANPHAM where maSP = '" + cboMaSP.SelectedValue.ToString() + "'");
                                        int soLuongSPConLai = int.Parse(dsSP.Tables[0].Rows[0]["soLuong"].ToString())
                                            - int.Parse(txtSoLuong.Text);

                                        Console.WriteLine("SOLUONGCONLAI: " + soLuongSPConLai);

                                        sql = "update CTSANPHAM set soLuong = '" + soLuongSPConLai + "' where maSP = '" + cboMaSP.SelectedValue.ToString() + "'";
                                        Console.WriteLine("update CTSP: " + sql);
                                        c.capNhatDuLieu(sql);

                                        DataSet dsTongTien = c.layDuLieu("select * from HOADONNHAP where maHD = '" + txtMaHD.Text + "'");
                                        int tongTien = int.Parse(dsTongTien.Tables[0].Rows[0]["tongTien"].ToString())
                                            - int.Parse(txtThanhTien.Text);

                                        Console.WriteLine("tongTien: " + tongTien);

                                        sql = "update HOADONNHAP set tongTien = '" + tongTien + "' where maHD = '" + txtMaHD.Text + "'";
                                        Console.WriteLine("update tongTien: " + sql);
                                        c.capNhatDuLieu(sql);

                                        sql = "delete CTHOADONNHAP where maHD = '" + txtMaHD.Text + "' and maSP = '" + cboMaSP.SelectedValue.ToString() + "'";
                                        Console.WriteLine("update CTHB: " + sql);
                                        cthd += c.capNhatDuLieu(sql);
                                    }
                                }
                                if (cthd > 0)
                                {
                                    MessageBox.Show("XOA OKE");
                                    frmHOADONNHAP_Load(sender, e);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
                
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmLuaChonHDHoacCTHD chooseForm = new frmLuaChonHDHoacCTHD();
            DialogResult result = chooseForm.ShowDialog();
            int cthd = 0, hd = 0;

            if (result == DialogResult.OK)
            {
                int choice = (int)chooseForm.Tag;

                switch (choice)
                {
                    case 1:
                        string sql = "";
                        Console.WriteLine("++++++++");
                        try
                        {
                            if (co == true)
                            {
                                Console.WriteLine("ADASDSDSAD");
                                if (txtMaHD.Text != "")
                                {

                                    sql = "update HOADONNHAP set maNV = '" + cboMaNV.SelectedValue.ToString() + "'," +
                                        " ngayNhap = '" + txtNgayNhap.Text + "', tongTien = '" + txtTongTien.Text + "', trangThai = '" + cboTrangThai.SelectedIndex.ToString() + "' " +
                                        " where maHD = '" + txtMaHD.Text + "' ";
                                    Console.WriteLine("HD: " + sql);
                                    try
                                    {
                                        hd += c.capNhatDuLieu(sql);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }


                                }
                            }
                            if (hd > 0)
                            {
                                MessageBox.Show("CAP NHAT OKE");
                                frmHOADONNHAP_Load(sender, e);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case 2:
                        string sql2 = "";
                        Console.WriteLine("=====asdasdas=======");
                        try
                        {
                            if (co == true)
                            {
                                Console.WriteLine("bgbgbgbgb");
                                if (txtMaHD.Text != "")
                                {
                                    Console.WriteLine("RTERERERE");
                                    if (soLuongTrcKhiSua > int.Parse(txtSoLuong.Text))
                                    {
                                        DataSet dsSP = c.layDuLieu("select * from CTSANPHAM where maSP = '" + cboMaSP.SelectedValue.ToString() + "'");

                                        int soLuongSPConLai = int.Parse(dsSP.Tables[0].Rows[0]["soLuong"].ToString())
                                            - (soLuongTrcKhiSua - int.Parse(txtSoLuong.Text));

                                        Console.WriteLine("SOLUONGCONLAI: " + soLuongSPConLai);

                                        sql = "update CTSANPHAM set soLuong = '" + soLuongSPConLai + "' where maSP = '" + cboMaSP.SelectedValue.ToString() + "'";
                                        Console.WriteLine("update CTSP: " + sql);
                                        c.capNhatDuLieu(sql);
                                    }

                                    if (soLuongTrcKhiSua < int.Parse(txtSoLuong.Text))
                                    {
                                        DataSet dsSP = c.layDuLieu("select * from CTSANPHAM where maSP = '" + cboMaSP.SelectedValue.ToString() + "'");

                                        int soLuongSPConLai = int.Parse(dsSP.Tables[0].Rows[0]["soLuong"].ToString())
                                            + (int.Parse(txtSoLuong.Text) - soLuongTrcKhiSua);

                                        Console.WriteLine("SOLUONGCONLAI: " + soLuongSPConLai);

                                        sql = "update CTSANPHAM set soLuong = '" + soLuongSPConLai + "' where maSP = '" + cboMaSP.SelectedValue.ToString() + "'";
                                        Console.WriteLine("update CTSP: " + sql);
                                        c.capNhatDuLieu(sql);
                                    }

                                    sql2 = "update CTHOADONNHAP set soLuong = '" + txtSoLuong.Text + "', donGia = '" + txtDonGia.Text + "', " +
                                        "tongTien = '" + txtThanhTien.Text + "', ghiChu = '" + txtGhiChu.Text + "' " +
                                        "where maHD = '" + txtMaHD.Text + "' and maSP = '" + cboMaSP.SelectedValue.ToString() + "'";
                                    Console.WriteLine("CTHD: " + sql2);
                                    try
                                    {
                                        cthd += c.capNhatDuLieu(sql2);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }

                                    if (thanhTienTrcKhiSua > int.Parse(txtThanhTien.Text))
                                    {
                                        DataSet dsTongTien = c.layDuLieu("select * from HOADONNHAP where maHD = '" + txtMaHD.Text + "'");
                                        int tongTien = int.Parse(dsTongTien.Tables[0].Rows[0]["tongTien"].ToString())
                                            - (thanhTienTrcKhiSua - int.Parse(txtThanhTien.Text));
                                        Console.WriteLine("tongTienGOC: " + int.Parse(dsTongTien.Tables[0].Rows[0]["tongTien"].ToString()));
                                        Console.WriteLine("tongTienTrc: " + thanhTienTrcKhiSua);
                                        Console.WriteLine("tongTienTru: " + int.Parse(txtThanhTien.Text));
                                        Console.WriteLine("tongTien: " + tongTien);

                                        sql = "update HOADONNHAP set tongTien = '" + tongTien + "' where maHD = '" + txtMaHD.Text + "'";
                                        Console.WriteLine("update tongTien: " + sql);
                                        c.capNhatDuLieu(sql);
                                    }

                                    if (thanhTienTrcKhiSua < int.Parse(txtThanhTien.Text))
                                    {
                                        DataSet dsTongTien = c.layDuLieu("select * from HOADONNHAP where maHD = '" + txtMaHD.Text + "'");
                                        int tongTien = int.Parse(dsTongTien.Tables[0].Rows[0]["tongTien"].ToString())
                                            + (int.Parse(txtThanhTien.Text) - thanhTienTrcKhiSua);
                                        Console.WriteLine("tongTienGOC: " + int.Parse(dsTongTien.Tables[0].Rows[0]["tongTien"].ToString()));
                                        Console.WriteLine("tongTienTrc: " + thanhTienTrcKhiSua);
                                        Console.WriteLine("tongTienTru: " + int.Parse(txtThanhTien.Text));
                                        Console.WriteLine("tongTien: " + tongTien);

                                        sql = "update HOADONNHAP set tongTien = '" + tongTien + "' where maHD = '" + txtMaHD.Text + "'";
                                        Console.WriteLine("update tongTien: " + sql);
                                        c.capNhatDuLieu(sql);
                                    }


                                }
                            }
                            if (cthd > 0)
                            {
                                MessageBox.Show("CAP NHAT OKE");
                                frmHOADONNHAP_Load(sender, e);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGia.Text != "" && txtSoLuong.Text != "")
            {
                txtThanhTien.Text = (Convert.ToInt32(txtDonGia.Text) * Convert.ToInt32(txtSoLuong.Text)).ToString();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTK.Text != "")
            {
                dsmaNCC = null;
                dsmaNCC = c.layDuLieu("select * from NHACUNGCAP where taiKhoan = '" + txtTK.Text + "'");
                if(dsmaNCC != null && dsmaNCC.Tables[0].Rows.Count > 0)
                {
                    cboMaNCC.Text = dsmaNCC.Tables[0].Rows[0]["hoTen"].ToString();
                }
                else
                {
                    MessageBox.Show("KHONG TIM THAY");
                    txtTK.Clear();
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void btnThemDSSP_Click(object sender, EventArgs e)
        {
            object[] sp = new object[7];
            sp[0] = txtMaHD.Text;
            sp[1] = cboMaSP.Text;
            sp[2] = txtSoLuong.Text;
            sp[3] = txtDonGia.Text;
            sp[4] = txtThanhTien.Text;
            sp[5] = txtGhiChu.Text;
            sp[6] = cboMaSP.SelectedValue.ToString();
            dgvDSSP.Rows.Add(sp);

            capNhatTongTien(dgvDSSP, txtTongTien);
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGia.Text != "" && txtSoLuong.Text != "")
            {
                txtThanhTien.Text = (Convert.ToInt32(txtDonGia.Text) * Convert.ToInt32(txtSoLuong.Text)).ToString();
            }
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSP.SelectedIndex != -1)
            {
                DataSet dsDonGia = c.layDuLieu("select * from CTSANPHAM where maSP = '" + cboMaSP.SelectedValue + "'");
                if (dsDonGia != null && dsDonGia.Tables.Count > 0 && dsDonGia.Tables[0].Rows.Count > 0)
                {
                    txtDonGia.Text = dsDonGia.Tables[0].Rows[0]["giaBan"].ToString();
                }
            }
        }

        private void btnXoaDSSP_Click(object sender, EventArgs e)
        {
            if (sttDSSP >= 0 && sttDSSP < dgvDSSP.Rows.Count - 1)
            {
                dgvDSSP.Rows.RemoveAt(sttDSSP);
                capNhatTongTien(dgvDSSP, txtTongTien);
            }
        }

        private void dgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sttDSSP = e.RowIndex;
            // Đảm bảo chắc chắn rằng chỉ số hàng hợp lệ được chọn
            if (e.RowIndex >= 0 && e.RowIndex < dgvDSSP.Rows.Count - 1)
            {
                int stt = e.RowIndex;
                txtMaHD.Text = dgvDSSP.Rows[stt].Cells[0].Value.ToString();
                cboMaSP.Text = dgvDSSP.Rows[stt].Cells[1].Value.ToString();
                txtSoLuong.Text = dgvDSSP.Rows[stt].Cells[2].Value.ToString();
                txtDonGia.Text = dgvDSSP.Rows[stt].Cells[3].Value.ToString();
                txtThanhTien.Text = dgvDSSP.Rows[stt].Cells[4].Value.ToString();
                txtGhiChu.Text = dgvDSSP.Rows[stt].Cells[5].Value.ToString();
            }
        }

        private void btnSuaDSSP_Click(object sender, EventArgs e)
        {
            dgvDSSP.Rows[sttDSSP].Cells[0].Value = txtMaHD.Text;
            dgvDSSP.Rows[sttDSSP].Cells[1].Value = cboMaSP.Text;
            dgvDSSP.Rows[sttDSSP].Cells[2].Value = txtSoLuong.Text;
            dgvDSSP.Rows[sttDSSP].Cells[3].Value = txtDonGia.Text;
            dgvDSSP.Rows[sttDSSP].Cells[4].Value = txtThanhTien.Text;
            dgvDSSP.Rows[sttDSSP].Cells[5].Value = txtGhiChu.Text;
            dgvDSSP.Rows[sttDSSP].Cells[6].Value = cboMaSP.SelectedValue.ToString();
            capNhatTongTien(dgvDSSP, txtTongTien);
        }

        private void dgvDSSP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Chỉnh sửa danh sách các cột chỉ được phép đọc
            int[] readOnlyColumns = new int[] { 0, 1, 3, 4, 6 };

            if (readOnlyColumns.Contains(e.ColumnIndex))
            {
                dgvDSSP.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            }
            else
            {
                dgvDSSP.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            }
            dgvDSSP.Rows[sttDSSP].Cells[4].Value = int.Parse(dgvDSSP.Rows[sttDSSP].Cells[2].Value.ToString()) * int.Parse(dgvDSSP.Rows[sttDSSP].Cells[3].Value.ToString());
            capNhatTongTien(dgvDSSP, txtTongTien);
        }

        private void btnLocTheoMaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMaNV.SelectedIndex != -1)
                {
                    danhsach_datagridview(dgvCTHDNhap, "select b.* from HOADONNHAP a, CTHOADONNHAP b where a.maHD = b.maHD and a.maNV = '" + cboMaNV.SelectedValue.ToString() + "'", ref dsCTHDB);
                    danhsach_datagridview(dgvHDNhap, "select * from HOADONNHAP where maNV = '" + cboMaNV.SelectedValue.ToString() + "'", ref dsHDB);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvCTHDNhap, "select * from dbo.CTHOADONNHAP", ref dsCTHDB);
            danhsach_datagridview(dgvHDNhap, "select * from HOADONNHAP", ref dsHDB);
        }

        private void dgvHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvHDNhap.Rows.Count - 1)
            {
                int stt = e.RowIndex;
                txtMaHD.Text = dsHDB.Tables[0].Rows[stt]["maHD"].ToString();
                cboMaNV.SelectedValue = dsHDB.Tables[0].Rows[stt]["maNV"].ToString();
                cboMaNCC.SelectedValue = dsHDB.Tables[0].Rows[stt]["maNCC"].ToString();
                txtNgayNhap.Text = dsHDB.Tables[0].Rows[stt]["ngayNhap"].ToString();
                txtTongTien.Text = dsHDB.Tables[0].Rows[stt]["tongTien"].ToString();
                cboTrangThai.SelectedIndex = int.Parse(dsHDB.Tables[0].Rows[stt]["trangThai"].ToString());

                danhsach_datagridview(dgvCTHDNhap, "select * from CTHOADONNHAP where maHD = '" + txtMaHD.Text + "'", ref dsCTHDB);
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
        public void capNhatNCCKhiThemMoi()
        {
            loadComboBox(cboMaNCC, dsmaNCC, "select * from NHACUNGCAP", "tenNCC", "maNCC");
        }
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            frmNHACUNGCAP ncc = new frmNHACUNGCAP();
            ncc.frmHOADONNHAP = this;
            ncc.ShowDialog();
        }
        public void capNhatSPKhiThemMoi()
        {
            loadComboBox(cboMaSP, dsMaSP, "select * from CTSANPHAM", "tenSP", "maSP");
        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmSANPHAM ncc = new frmSANPHAM();
            ncc.ShowDialog();
        }


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
        private void loadComboBox(ComboBox cb, DataSet dt, string sql, string ten, string giatri)
        {
            dt = c.layDuLieu(sql);
            cb.DataSource = dt.Tables[0];
            cb.DisplayMember = ten;
            cb.ValueMember = giatri;
            cb.SelectedIndex = -1;

        }
        private void frmHOADONNHAP_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvCTHDNhap, "select *, CONVERT(INT, SUBSTRING(maHD, 4, LEN(maHD)-3)) AS ColPhu from dbo.CTHOADONNHAP ORDER BY ColPhu DESC", ref dsCTHDB);
            danhsach_datagridview(dgvHDNhap, "select *, CONVERT(INT, SUBSTRING(maHD, 4, LEN(maHD)-3)) AS ColPhu from HOADONNHAP ORDER BY ColPhu DESC ;", ref dsHDB);
            loadPhimChucNang(true);

            //dsMaHD = c.layDuLieu("select * from HOADONNHAP");
            //cboMaHD.DataSource = dsMaHD.Tables[0];
            //cboMaHD.DisplayMember = "maHD";
            //cboMaHD.ValueMember = "maHD";
            //cboMaHD.SelectedIndex = -1;

            loadComboBox(cboMaSP, dsMaSP, "select * from CTSANPHAM", "tenSP", "maSP");
            //dsMaSP = c.layDuLieu("select * from CTSANPHAM");
            //cboMaSP.DataSource = dsMaSP.Tables[0];
            //cboMaSP.DisplayMember = "tenSP";
            //cboMaSP.ValueMember = "maSP";f
            //cboMaSP.SelectedIndex = -1;

            loadComboBox(cboMaNV, dsMaNV, "select * from NHANVIEN", "hoTen", "maNV");
            loadComboBox(cboMaNCC, dsmaNCC, "select * from NHACUNGCAP", "tenNCC", "maNCC");

            themCotTrongDataGridView("MaHD", "maHD", dgvDSSP);
            themCotTrongDataGridView("TenSP", "tenSP", dgvDSSP);
            themCotTrongDataGridView("SoLuong", "soLuong", dgvDSSP);
            themCotTrongDataGridView("DonGia", "donGia", dgvDSSP);
            themCotTrongDataGridView("ThanhTien", "thanhTien", dgvDSSP);
            themCotTrongDataGridView("GhiChu", "ghiChu", dgvDSSP);
            themCotTrongDataGridView("MaSP", "maSP", dgvDSSP);

            dgvDSSP.Rows.Clear();
            txtMaHD.Clear();
            cboMaNV.Text = "";
            txtTK.Text = "";
            cboMaNCC.Text = "";
            txtNgayNhap.Clear();
            txtTongTien.Clear();
            cboTrangThai.Text = "";

            cboMaSP.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtThanhTien.Clear();
            txtGhiChu.Text = "";

            co = true;
            flag = 0;
        }
        private void themCotTrongDataGridView(string name, string tieude, DataGridView dgv)
        {
            DataGridViewColumn newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = tieude;
            newCol.Name = name;

            dgv.Columns.Add(newCol);
        }


    }
}
