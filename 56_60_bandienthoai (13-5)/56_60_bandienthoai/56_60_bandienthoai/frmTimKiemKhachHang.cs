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
    public partial class frmTimKiemKhachHang : Form
    {
        public frmTimKiemKhachHang()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet dsSP = new DataSet();
        DataSet ds = new DataSet();
        Boolean flag = false;
        private void loadComboBox(ComboBox cb, DataSet dt, string sql, string ten, string giatri)
        {
            dt = c.layDuLieu(sql);
            cb.DataSource = dt.Tables[0];
            cb.DisplayMember = ten;
            cb.ValueMember = giatri;
            cb.SelectedIndex = -1;

        }

        private void frmTimKiemKhachHang_Load(object sender, EventArgs e)
        {
            cboTen.Enabled = false;
            cboMa.Enabled = false;
            cboSDT.Enabled = false; 
            dsSP = c.layDuLieu("select * from KHACHHANG");
            dgvKH.DataSource = dsSP.Tables[0];
            cboDS.SelectedIndex = -1;
            ds = c.layDuLieu("select * from KHACHHANG");
        }

        private void cboDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDS.SelectedIndex == 0)
            {
                flag = false;
                cboTen.Enabled = true;
                cboMa.Text = "";
                cboSDT.Text = "";
                cboMa.Enabled = false;
                cboSDT.Enabled=false;
                loadComboBox(cboTen, dsSP, "select hoTen from KHACHHANG group by hoTen", "hoTen", "hoTen");
                flag = true;
            }
            if (cboDS.SelectedIndex == 1)
            {
                flag = false;
                cboMa.Enabled = true;
                cboTen.Text = "";
                cboSDT.Text = "";
                cboTen.Enabled = false;
                cboSDT.Enabled = false;
                loadComboBox(cboMa, dsSP, "select maKH from KHACHHANG", "maKH", "maKH");
                flag = true;
            }
            if (cboDS.SelectedIndex == 2)
            {
                flag = false;
                cboSDT.Enabled = true;
                cboTen.Text = "";
                cboMa.Text = "";
                cboTen.Enabled = false;
                cboMa.Enabled = false;
                loadComboBox(cboMa, dsSP, "select dienThoai from KHACHHANG", "dienThoai", "dienThoai");
                flag = true;
            }
        }

        private void cboTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (cboTen.SelectedIndex != -1)
                {
                    string ma = cboTen.SelectedValue.ToString();
                    DataSet laySP = c.layDuLieu("select * from KHACHHANG where hoTen = N'"+ma+"'");
                    dgvKH.DataSource = laySP.Tables[0];
                }
            }
        }

        private void cboMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (cboMa.SelectedIndex != -1)
                {
                    string ma = cboMa.SelectedValue.ToString();
                    DataSet laySP = c.layDuLieu("select * from KHACHHANG where maKH = '" + ma + "'");
                    dgvKH.DataSource = laySP.Tables[0];
                }
            }
        }
        private void updateComboBoxTheoDataGridView(DataView dv, DataSet ds, string sql, ComboBox cbo, string hienthi, string giatri)
        {
            dv.Table = ds.Tables[0];
            dv.RowFilter = sql;
            cbo.DataSource = dv;
            cbo.DisplayMember = hienthi;
            cbo.ValueMember = giatri;
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKH.Rows.Count - 1)
            {
                int vitri = e.RowIndex;

                if (cboDS.SelectedIndex == 0)
                {
                    cboTen.Text = ds.Tables[0].Rows[vitri]["hoTen"].ToString();
                    cboMa.Enabled = false;
                    cboSDT.Enabled = false;
                }
                if (cboDS.SelectedIndex == 1)
                {
                    cboMa.Text = ds.Tables[0].Rows[vitri]["maKH"].ToString();
                    cboTen.Enabled = false;
                    cboSDT.Enabled = false;
                }
                if (cboDS.SelectedIndex == 2)
                {
                    cboSDT.Text = ds.Tables[0].Rows[vitri]["dienThoai"].ToString();
                    cboTen.Enabled = false;
                    cboMa.Enabled = false;
                }

                DataView dv1 = new DataView();
                updateComboBoxTheoDataGridView(dv1, ds, "maKH = '" + cboMa.Text + "'", cboTen, "hoTen", "hoTen");
                DataView dv2 = new DataView();
                updateComboBoxTheoDataGridView(dv2, ds, "maKH = '" + cboMa.Text + "'", cboMa, "maKH", "maKH");
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            frmTimKiemKhachHang_Load(sender, e);    
        }

        private void cboSDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (cboSDT.SelectedIndex != -1)
                {
                    string ma = cboSDT.SelectedValue.ToString();
                    DataSet laySP = c.layDuLieu("select * from KHACHHANG where dienThoai = '" + ma + "'");
                    dgvKH.DataSource = laySP.Tables[0];
                }
            }
        }
    }
}
