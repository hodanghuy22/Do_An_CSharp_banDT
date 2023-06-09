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
    public partial class frmTraHang : Form
    {
        public frmTraHang()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet dsCTTraHang, dsTraHang;
        DataSet dsMaSP, dsMaHD, dsMaKH;
        int sttDSSP;
        Boolean co = false;
        int flag = 0;
        int soLuongTrcKhiSua, thanhTienTrcKhiSua;
        int tongTienHDB = 0;
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
            txt.Text = (tongTienHDB - tongTien).ToString();
        }
        void themMoi(DataSet ds, TextBox a, DataGridView dgv, string tenCot, string tenDat, int soLuong)
        {
            int lastRowIndex = 0;
            DataGridViewRow dong = dgv.Rows[lastRowIndex];
            int tt = Convert.ToInt32(ds.Tables[0].Rows[lastRowIndex][tenCot].ToString().Substring(soLuong)) + 1;
            a.Text = tenDat + tt.ToString();
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            xoaDl();
            loadPhimChucNang(false);
            flag = 1;
            themMoi(dsTraHang, txtMaTraHang, dgvTraHangBan, "maTraHang", "TH", 2);
        }

        void xoaDl()
        {
            txtMaTraHang.Clear();
            cboMaHD.SelectedIndex = -1;
            txtMaKH.Clear();
            txtThoiGianTra.Clear();
            txtPhuongThucXuLy.Clear();
            txtTongTien.Clear();

            cboMaSP.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtLyDo.Clear();
            txtMoTa.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();

            dgvDSSP.Rows.Clear();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            xoaDl();
            loadPhimChucNang(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTraHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                DialogResult kq;
                kq = MessageBox.Show("DỮ LIỆU CHƯA ĐƯỢC LƯU", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        void danhsach_datagridview(DataGridView d, string sql, ref DataSet ds)
        {
            ds = c.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }

        private void dgvTraHangBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTraHangBan.Rows.Count - 1)
            {
                int stt = e.RowIndex;
                txtMaTraHang.Text = dsTraHang.Tables[0].Rows[stt]["maTraHang"].ToString();
                cboMaHD.SelectedValue = dsTraHang.Tables[0].Rows[stt]["maHD"].ToString();
                txtMaKH.Text = dsTraHang.Tables[0].Rows[stt]["maKH"].ToString();
                txtThoiGianTra.Text = dsTraHang.Tables[0].Rows[stt]["thoigiantra"].ToString();
                txtPhuongThucXuLy.Text = dsTraHang.Tables[0].Rows[stt]["phuongThucXuLy"].ToString();
                txtTongTien.Text = dsTraHang.Tables[0].Rows[stt]["tongTien"].ToString();
            }
        }

        private void dgvCTTraHangBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTraHangBan.Rows.Count - 1)
            {
                int stt = e.RowIndex;
                txtMaTraHang.Text = dsCTTraHang.Tables[0].Rows[stt]["maTraHang"].ToString();
                cboMaHD.SelectedValue = dsCTTraHang.Tables[0].Rows[stt]["maHD"].ToString();
                cboMaSP.SelectedValue = dsCTTraHang.Tables[0].Rows[stt]["maSP"].ToString();
                txtSoLuong.Text = dsCTTraHang.Tables[0].Rows[stt]["soluong"].ToString();
                txtLyDo.Text = dsCTTraHang.Tables[0].Rows[stt]["lyDo"].ToString();
                txtMoTa.Text = dsCTTraHang.Tables[0].Rows[stt]["moTa"].ToString();
                txtDonGia.Text = dsCTTraHang.Tables[0].Rows[stt]["donGia"].ToString();
                txtThanhTien.Text = dsCTTraHang.Tables[0].Rows[stt]["thanhTien"].ToString();

                soLuongTrcKhiSua = int.Parse(txtSoLuong.Text);
                thanhTienTrcKhiSua = int.Parse(txtThanhTien.Text);
            }
        }

        private void cboMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(co == true && cboMaHD.SelectedIndex != -1)
            {
                loadComboBox(cboMaSP, dsMaSP, "select a.* from CTSANPHAM a, CTHOADONBAN b where b.maHD = '"+cboMaHD.SelectedValue+"' and a.maSP = b.maSP", "tenSP", "maSP");
                
                DataSet dsTongTien = c.layDuLieu("select * from HOADONBAN where maHD = '" + cboMaHD.SelectedValue + "'");
                txtTongTien.Text = dsTongTien.Tables[0].Rows[0]["tongTien"].ToString();
                tongTienHDB = int.Parse(dsTongTien.Tables[0].Rows[0]["tongTien"].ToString());

                DataSet dsTenKH = c.layDuLieu("select a.* from KHACHHANG a, HOADONBAN b where b.maKH = a.maKH and b.maHD = '" + cboMaHD.SelectedValue + "'");
                txtMaKH.Text = dsTenKH.Tables[0].Rows[0]["maKH"].ToString();
            }
        }

        private void btnLocTheoMaKH_Click(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvTraHangBan, "select a.*,b.tongTien,CONVERT(INT, SUBSTRING(a.maTraHang, 3, 1)) AS ColPhu  from TRAHANGBAN a, HOADONBAN b where a.maHD = b.maHD and a.maKH = '"+txtMaKH.Text+"' order by ColPhu desc", ref dsTraHang);
            danhsach_datagridview(dgvCTTraHangBan, "select a.*,CONVERT(INT, SUBSTRING(a.maTraHang, 3, 1)) AS ColPhu  from CTTRAHANGBAN a, TRAHANGBAN b where a.maTraHang = b.maTraHang and b.maKH = 'KH1' order by ColPhu desc", ref dsCTTraHang);
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvTraHangBan, "select a.*,b.tongTien,CONVERT(INT, SUBSTRING(a.maTraHang, 3, 1)) AS ColPhu  from TRAHANGBAN a, HOADONBAN b where a.maHD = b.maHD order by ColPhu desc", ref dsTraHang);
            danhsach_datagridview(dgvCTTraHangBan, "select *,CONVERT(INT, SUBSTRING(maTraHang, 3, 1)) AS ColPhu  from CTTRAHANGBAN order by ColPhu desc", ref dsCTTraHang);
        }

        private void btnThemDSSP_Click(object sender, EventArgs e)
        {
            object[] sp = new object[11];
            sp[0] = txtMaTraHang.Text;
            sp[1] = cboMaHD.SelectedValue;
            sp[2] = cboMaSP.Text;
            sp[3] = txtSoLuong.Text;
            sp[4] = txtDonGia.Text;
            sp[5] = txtThanhTien.Text;
            sp[6] = txtLyDo.Text;
            sp[7] = txtMoTa.Text;
            sp[8] = cboMaSP.SelectedValue.ToString();
            dgvDSSP.Rows.Add(sp);

            capNhatTongTien(dgvDSSP, txtTongTien);
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (co==true && cboMaSP.SelectedIndex != -1)
            {
                DataSet dsDonGiaSp = c.layDuLieu("select * from CTSANPHAM where maSP = '"+cboMaSP.SelectedValue+"'");
                txtDonGia.Text = dsDonGiaSp.Tables[0].Rows[0]["giaBan"].ToString();
            }
            
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "" || txtSoLuong.Text == "")
            {
                txtThanhTien.Text = "";
            }
            if (txtDonGia.Text != "" && txtSoLuong.Text != "")
            {
                txtThanhTien.Text = (Convert.ToInt32(txtDonGia.Text) * Convert.ToInt32(txtSoLuong.Text)).ToString();
                if (cboMaHD.SelectedIndex != -1 && cboMaSP.SelectedIndex != -1)
                {
                    DataSet dsSoLuong = c.layDuLieu("select * from CTHOADONBAN where maSP = '" + cboMaSP.SelectedValue + "' and maHD = '" + cboMaHD.SelectedValue + "'");
                    int slThat = int.Parse(dsSoLuong.Tables[0].Rows[0]["soLuong"].ToString());
                    if (int.Parse(txtSoLuong.Text) > slThat)
                    {
                        txtSoLuong.Text = "";
                        MessageBox.Show("KHONG NHAP SO LUONG LON HON " + slThat.ToString());
                    }
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
            if (e.RowIndex >= 0 && e.RowIndex < dgvDSSP.Rows.Count - 1)
            {
                sttDSSP = e.RowIndex;
                int stt = e.RowIndex;
  
                txtMaTraHang.Text = dgvDSSP.Rows[stt].Cells[0].Value.ToString();
                cboMaHD.SelectedValue = dgvDSSP.Rows[stt].Cells[1].Value.ToString();
                cboMaSP.Text = dgvDSSP.Rows[stt].Cells[2].Value.ToString();
                txtSoLuong.Text = dgvDSSP.Rows[stt].Cells[3].Value.ToString();
                txtDonGia.Text = dgvDSSP.Rows[stt].Cells[4].Value.ToString();
                txtThanhTien.Text = dgvDSSP.Rows[stt].Cells[5].Value.ToString();
                txtLyDo.Text = dgvDSSP.Rows[stt].Cells[6].Value.ToString();
                txtMoTa.Text = dgvDSSP.Rows[stt].Cells[7].Value.ToString();
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "" || txtSoLuong.Text == "")
            {
                txtThanhTien.Text = "";
            }
            if (txtDonGia.Text != "" && txtSoLuong.Text != "")
            {
                txtThanhTien.Text = (Convert.ToInt32(txtDonGia.Text) * Convert.ToInt32(txtSoLuong.Text)).ToString();
            }
        }

        private void btnSuaDSSP_Click(object sender, EventArgs e)
        {
            //sp[0] = txtMaTraHang.Text;
            //sp[1] = cboMaHD.SelectedValue;
            //sp[2] = cboMaSP.Text;
            //sp[3] = txtSoLuong.Text;
            //sp[4] = txtDonGia.Text;
            //sp[5] = txtThanhTien.Text;
            //sp[6] = txtLyDo.Text;
            //sp[7] = txtMoTa.Text;
            //sp[8] = cboMaSP.SelectedValue.ToString();

            dgvDSSP.Rows[sttDSSP].Cells[0].Value = txtMaTraHang.Text;
            dgvDSSP.Rows[sttDSSP].Cells[1].Value = cboMaHD.SelectedValue;
            dgvDSSP.Rows[sttDSSP].Cells[2].Value = cboMaSP.Text;
            dgvDSSP.Rows[sttDSSP].Cells[3].Value = txtSoLuong.Text;
            dgvDSSP.Rows[sttDSSP].Cells[4].Value = txtDonGia.Text;
            dgvDSSP.Rows[sttDSSP].Cells[5].Value = txtThanhTien.Text;
            dgvDSSP.Rows[sttDSSP].Cells[6].Value = txtLyDo.Text;
            dgvDSSP.Rows[sttDSSP].Cells[7].Value = txtMoTa.Text;
            dgvDSSP.Rows[sttDSSP].Cells[8].Value = cboMaSP.SelectedValue.ToString();
            capNhatTongTien(dgvDSSP, txtTongTien);
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
                    if (txtMaTraHang.Text != "")
                    {
                        Console.WriteLine("=========ASDSAD=========");
                        sql = "insert into TRAHANGBAN values('"+txtMaTraHang.Text+"','"+cboMaHD.SelectedValue+"','"+txtMaKH.Text+"',N'"+txtThoiGianTra.Text+"',N'"+txtPhuongThucXuLy.Text+"')";
                        Console.WriteLine("Bang: " + sql);
                        try
                        {
                            bang += c.capNhatDuLieu(sql);
                            foreach (DataGridViewRow row in dgvDSSP.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    sql = "insert into CTTRAHANGBAN values('" + row.Cells["maTraHang"].Value.ToString() + "'," +
                                        "'" + row.Cells["maHD"].Value.ToString() + "','" + row.Cells["maSP"].Value.ToString() + "'," +
                                        "'" + row.Cells["lyDo"].Value.ToString() + "','" + row.Cells["moTa"].Value.ToString() + "'," +
                                        "'" + row.Cells["soLuong"].Value.ToString() + "','" + row.Cells["donGia"].Value.ToString() + "'," +
                                        "'" + row.Cells["thanhTien"].Value.ToString() + "')";
                                    
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

                                        DataSet dsSLCTHDB = c.layDuLieu("select * from CTHOADONBAN where maHD = '" + row.Cells["maHD"].Value.ToString() + "' and maSP = '"+ row.Cells["maSP"].Value.ToString() + "'");
                                        int soLuongSPCTHD = int.Parse(dsSLCTHDB.Tables[0].Rows[0]["soLuong"].ToString()) - int.Parse(row.Cells["soLuong"].Value.ToString());
                                        sql = "update CTHOADONBAN set soLuong = '"+soLuongSPCTHD+ "', tongTien = '" + row.Cells["thanhTien"].Value.ToString() + "' where maHD = '" + row.Cells["maHD"].Value.ToString() + "' and maSP = '"+ row.Cells["maSP"].Value.ToString() + "'";
                                        c.capNhatDuLieu(sql);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                            sql = "update HOADONBAN set tongTien = '"+txtTongTien.Text+ "', traHang = 1 where maHD = '" + cboMaHD.SelectedValue+"'";
                            c.capNhatDuLieu(sql);
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
                    //frmCTHOADONBAN_Load(sender, e);
                    frmTraHang_Load(sender, e);
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
                                    if (txtMaTraHang.Text != "")
                                    {
                                        int tongTienHDB = 0;
                                        foreach (DataGridViewRow row in dgvCTTraHangBan.Rows)
                                        {
                                            if (!row.IsNewRow)
                                            {
                                                if (row.Cells["maTraHang"].Value.ToString() == txtMaTraHang.Text)
                                                {
                                                    DataSet dsSP = c.layDuLieu("select * from CTSANPHAM where maSP = '" + row.Cells["maSP"].Value.ToString() + "'");
                                                    int soLuongSPConLai = int.Parse(dsSP.Tables[0].Rows[0]["soLuong"].ToString())
                                                        - int.Parse(row.Cells["soLuong"].Value.ToString());
                                                    Console.WriteLine("SOLUONGCONLAI: " + soLuongSPConLai);
                                                    sql = "update CTSANPHAM set soLuong = '" + soLuongSPConLai + "' where maSP = '" + row.Cells["maSP"].Value.ToString() + "'";
                                                    Console.WriteLine(sql);
                                                    c.capNhatDuLieu(sql);


                                                    DataSet dsSLCTHDB = c.layDuLieu("select * from CTHOADONBAN where maHD = '" + row.Cells["maHD"].Value.ToString() + "' and maSP = '" + row.Cells["maSP"].Value.ToString() + "'");
                                                    int soLuongSPCTHD = int.Parse(dsSLCTHDB.Tables[0].Rows[0]["soLuong"].ToString()) + int.Parse(row.Cells["soLuong"].Value.ToString());
                                                    int thanhTienMoi = int.Parse(dsSLCTHDB.Tables[0].Rows[0]["tongTien"].ToString()) + int.Parse(row.Cells["thanhTien"].Value.ToString());
                                                    Console.WriteLine("tien: " + dsSLCTHDB.Tables[0].Rows[0]["tongTien"].ToString() + " " + row.Cells["thanhTien"].Value.ToString());
                                                    tongTienHDB += thanhTienMoi;

                                                    sql = "update CTHOADONBAN set soLuong = '" + soLuongSPCTHD + "', tongTien = '" + thanhTienMoi + "' where maHD = '" + row.Cells["maHD"].Value.ToString() + "' and maSP = '" + row.Cells["maSP"].Value.ToString() + "'";
                                                    Console.WriteLine(sql);
                                                    c.capNhatDuLieu(sql);

                                                    sql = "delete from CTTRAHANGBAN where maTraHang = '"+ row.Cells["maTraHang"].Value.ToString() + "' and maSP = '"+ row.Cells["maSP"].Value.ToString() + "'";
                                                    Console.WriteLine(sql);
                                                    c.capNhatDuLieu(sql);
                                                }
                                            }
                                        }
                                        sql = "update HOADONBAN set tongTien = '" + tongTienHDB.ToString() + "', traHang = 0 where maHD = '" + cboMaHD.SelectedValue + "'";
                                        c.capNhatDuLieu(sql);
                                        try
                                        {
                                            sql = "delete from TRAHANGBAN where maTraHang = '"+txtMaTraHang.Text+"'";
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
                                    frmTraHang_Load(sender, e);
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
                                    if (txtMaTraHang.Text != "")
                                    {
                                        int tongTienHDB = int.Parse(txtTongTien.Text);
                                        DataSet dsSP = c.layDuLieu("select * from CTSANPHAM where maSP = '" + cboMaSP.SelectedValue + "'");
                                        int soLuongSPConLai = int.Parse(dsSP.Tables[0].Rows[0]["soLuong"].ToString())
                                            - int.Parse(txtSoLuong.Text);
                                        Console.WriteLine("SOLUONGCONLAI: " + soLuongSPConLai);
                                        sql = "update CTSANPHAM set soLuong = '" + soLuongSPConLai + "' where maSP = '" + cboMaSP.SelectedValue + "'";
                                        Console.WriteLine(sql);
                                        c.capNhatDuLieu(sql);


                                        DataSet dsSLCTHDB = c.layDuLieu("select * from CTHOADONBAN where maHD = '" + cboMaHD.SelectedValue + "' and maSP = '" + cboMaSP.SelectedValue + "'");
                                        int soLuongSPCTHD = int.Parse(dsSLCTHDB.Tables[0].Rows[0]["soLuong"].ToString()) + int.Parse(txtSoLuong.Text);
                                        int thanhTienMoi = int.Parse(dsSLCTHDB.Tables[0].Rows[0]["tongTien"].ToString()) + int.Parse(txtThanhTien.Text);
                                        Console.WriteLine("tien: " + dsSLCTHDB.Tables[0].Rows[0]["tongTien"].ToString() + " " + txtThanhTien.Text);
                                        tongTienHDB += int.Parse(txtThanhTien.Text);

                                        sql = "update CTHOADONBAN set soLuong = '" + soLuongSPCTHD + "', tongTien = '" + thanhTienMoi + "' where maHD = '" + cboMaHD.SelectedValue + "' and maSP = '" + cboMaSP.SelectedValue + "'";
                                        Console.WriteLine(sql);
                                        c.capNhatDuLieu(sql);

                                        sql = "delete from CTTRAHANGBAN where maTraHang = '" + txtMaTraHang.Text + "' and maSP = '" + cboMaSP.SelectedValue + "'";
                                        Console.WriteLine(sql);
                                        cthd = c.capNhatDuLieu(sql);

                                        sql = "update HOADONBAN set tongTien = '" + tongTienHDB.ToString() + "' where maHD = '" + cboMaHD.SelectedValue + "'";
                                        c.capNhatDuLieu(sql);
                                    }
                                }
                                if (cthd > 0)
                                {
                                    MessageBox.Show("XOA OKE");
                                    frmTraHang_Load(sender, e);
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
                                if (txtMaTraHang.Text != "")
                                {

                                    sql = "update TRAHANGBAN set thoigiantra = N'"+txtThoiGianTra.Text+"', " +
                                        "phuongThucXuLy = N'"+txtPhuongThucXuLy.Text+"' where maTraHang = '"+txtMaTraHang.Text+"'";
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
                                frmTraHang_Load(sender, e);
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
                                if (txtMaTraHang.Text != "")
                                {
                                    if (soLuongTrcKhiSua > int.Parse(txtSoLuong.Text))
                                    {
                                        int tongTienHDB = 0;
                                        DataSet dsSP = c.layDuLieu("select * from CTSANPHAM where maSP = '" + cboMaSP.SelectedValue + "'");
                                        int soLuongSPConLai = int.Parse(dsSP.Tables[0].Rows[0]["soLuong"].ToString())
                                            - (- int.Parse(txtSoLuong.Text) + soLuongTrcKhiSua);
                                        Console.WriteLine("SOLUONGCONLAI: " + soLuongSPConLai);
                                        sql = "update CTSANPHAM set soLuong = '" + soLuongSPConLai + "' where maSP = '" + cboMaSP.SelectedValue + "'";
                                        Console.WriteLine(sql);
                                        c.capNhatDuLieu(sql);


                                        DataSet dsSLCTHDB = c.layDuLieu("select * from CTHOADONBAN where maHD = '" + cboMaHD.SelectedValue + "' and maSP = '" + cboMaSP.SelectedValue + "'");
                                        int soLuongSPCTHD = int.Parse(dsSLCTHDB.Tables[0].Rows[0]["soLuong"].ToString()) + (- int.Parse(txtSoLuong.Text) + soLuongTrcKhiSua);
                                        int thanhTienMoi = int.Parse(dsSLCTHDB.Tables[0].Rows[0]["tongTien"].ToString()) + (- int.Parse(txtThanhTien.Text) + thanhTienTrcKhiSua);
                                        Console.WriteLine("tien: " + dsSLCTHDB.Tables[0].Rows[0]["tongTien"].ToString() + " " + txtThanhTien.Text);
                                        tongTienHDB = int.Parse(txtTongTien.Text) + (thanhTienTrcKhiSua - int.Parse(txtThanhTien.Text));

                                        sql = "update CTHOADONBAN set soLuong = '" + soLuongSPCTHD + "', tongTien = '" + thanhTienMoi + "' where maHD = '" + cboMaHD.SelectedValue + "' and maSP = '" + cboMaSP.SelectedValue + "'";
                                        Console.WriteLine(sql);
                                        c.capNhatDuLieu(sql);

                                        sql = "update CTTRAHANGBAN set lyDo = N'"+txtLyDo.Text+"', moTa = N'"+txtMoTa.Text+"', " +
                                            "soluong = '"+txtSoLuong.Text+"', donGia = '"+txtDonGia.Text+"', thanhTien = '"+txtThanhTien.Text+"' " +
                                            "where maTraHang = '"+txtMaTraHang.Text+"' and maSP = '"+cboMaSP.SelectedValue+"'";
                                        Console.WriteLine(sql);
                                        cthd = c.capNhatDuLieu(sql);

                                        sql = "update HOADONBAN set tongTien = '" + tongTienHDB.ToString() + "' where maHD = '" + cboMaHD.SelectedValue + "'";
                                        c.capNhatDuLieu(sql);
                                    }
                                    if (soLuongTrcKhiSua < int.Parse(txtSoLuong.Text))
                                    {
                                        int tongTienHDB = 0;
                                        DataSet dsSP = c.layDuLieu("select * from CTSANPHAM where maSP = '" + cboMaSP.SelectedValue + "'");
                                        int soLuongSPConLai = int.Parse(dsSP.Tables[0].Rows[0]["soLuong"].ToString())
                                            + (int.Parse(txtSoLuong.Text) - soLuongTrcKhiSua);
                                        Console.WriteLine("SOLUONGCONLAI: " + soLuongSPConLai);
                                        sql = "update CTSANPHAM set soLuong = '" + soLuongSPConLai + "' where maSP = '" + cboMaSP.SelectedValue + "'";
                                        Console.WriteLine(sql);
                                        c.capNhatDuLieu(sql);


                                        DataSet dsSLCTHDB = c.layDuLieu("select * from CTHOADONBAN where maHD = '" + cboMaHD.SelectedValue + "' and maSP = '" + cboMaSP.SelectedValue + "'");
                                        int soLuongSPCTHD = int.Parse(dsSLCTHDB.Tables[0].Rows[0]["soLuong"].ToString()) - (int.Parse(txtSoLuong.Text) - soLuongTrcKhiSua);
                                        int thanhTienMoi = int.Parse(dsSLCTHDB.Tables[0].Rows[0]["tongTien"].ToString()) - (int.Parse(txtThanhTien.Text) - thanhTienTrcKhiSua);
                                        Console.WriteLine("tien: " + dsSLCTHDB.Tables[0].Rows[0]["tongTien"].ToString() + " " + txtThanhTien.Text);
                                        tongTienHDB = int.Parse(txtTongTien.Text) - (-thanhTienTrcKhiSua + int.Parse(txtThanhTien.Text));

                                        sql = "update CTHOADONBAN set soLuong = '" + soLuongSPCTHD + "', tongTien = '" + thanhTienMoi + "' where maHD = '" + cboMaHD.SelectedValue + "' and maSP = '" + cboMaSP.SelectedValue + "'";
                                        Console.WriteLine(sql);
                                        c.capNhatDuLieu(sql);

                                        sql = "update CTTRAHANGBAN set lyDo = N'" + txtLyDo.Text + "', moTa = N'" + txtMoTa.Text + "', " +
                                            "soluong = '" + txtSoLuong.Text + "', donGia = '" + txtDonGia.Text + "', thanhTien = '" + txtThanhTien.Text + "' " +
                                            "where maTraHang = '" + txtMaTraHang.Text + "' and maSP = '" + cboMaSP.SelectedValue + "'";
                                        Console.WriteLine(sql);
                                        cthd = c.capNhatDuLieu(sql);

                                        sql = "update HOADONBAN set tongTien = '" + tongTienHDB.ToString() + "' where maHD = '" + cboMaHD.SelectedValue + "'";
                                        c.capNhatDuLieu(sql);
                                    }

                                }
                            }
                            if (cthd > 0)
                            {
                                MessageBox.Show("CAP NHAT OKE");
                                frmTraHang_Load(sender, e);
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
        private void themCotTrongDataGridView(string name, string tieude, DataGridView dgv)
        {
            DataGridViewColumn newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = tieude;
            newCol.Name = name;

            dgv.Columns.Add(newCol);
        }
        private void frmTraHang_Load(object sender, EventArgs e)
        {
            danhsach_datagridview(dgvTraHangBan, "select a.*,b.tongTien,CONVERT(INT, SUBSTRING(a.maTraHang, 3, 1)) AS ColPhu  from TRAHANGBAN a, HOADONBAN b where a.maHD = b.maHD order by ColPhu desc", ref dsTraHang);
            danhsach_datagridview(dgvCTTraHangBan, "select *,CONVERT(INT, SUBSTRING(maTraHang, 3, 1)) AS ColPhu  from CTTRAHANGBAN order by ColPhu desc", ref dsCTTraHang);
            loadPhimChucNang(true);

            loadComboBox(cboMaHD, dsMaHD, "select * from HOADONBAN", "maHD", "maHD");
            loadComboBox(cboMaSP, dsMaSP, "select a.* from CTSANPHAM a, HOADONBAN b, CTTRAHANGBAN c where b.maHD = '"+cboMaHD.SelectedValue+"' and a.maSP = c.maSP and b.maHD = c.maHD and b.traHang = 1", "tenSP", "maSP");

            themCotTrongDataGridView("MaTraHang", "maTraHang", dgvDSSP);
            themCotTrongDataGridView("MaHD", "maHD", dgvDSSP);
            themCotTrongDataGridView("TenSP", "tenSP", dgvDSSP);
            themCotTrongDataGridView("SoLuong", "soLuong", dgvDSSP);
            themCotTrongDataGridView("DonGia", "donGia", dgvDSSP);
            themCotTrongDataGridView("ThanhTien", "thanhTien", dgvDSSP);
            themCotTrongDataGridView("LyDo", "lyDo", dgvDSSP);
            themCotTrongDataGridView("MoTa", "moTa", dgvDSSP);
            themCotTrongDataGridView("MaSP", "maSP", dgvDSSP);

            dgvDSSP.Rows.Clear();

            xoaDl();
            co = true;
            flag = 0;
        }
    }
}
