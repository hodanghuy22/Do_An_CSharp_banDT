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
    public partial class frmTimKiemSP : Form
    {
        public frmTimKiemSP()
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

        private void frmTimKiemSP_Load(object sender, EventArgs e)
        {   cboTen.Enabled = false;
            cboMa.Enabled = false;   
            dsSP = c.layDuLieu("select * from SANPHAM a, CTSANPHAM b where a.maSP = b.maSP");
            dgvSP.DataSource = dsSP.Tables[0];
            cboDS.SelectedIndex = -1;
            ds = c.layDuLieu("select * from SANPHAM a, CTSANPHAM b where a.maSP = b.maSP");
        }

        private void cboDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDS.SelectedIndex == 0)
            {
                flag = false;
                cboTen.Enabled = true;
                cboMa.Text = "";
                cboMa.Enabled = false;
                loadComboBox(cboTen, dsSP, "select tenSP from CTSANPHAM group by tenSP", "tenSP", "tenSP");
                flag = true;
            }
            else
            {
                flag = false;
                cboMa.Enabled = true;
                cboTen.Text = "";
                cboTen.Enabled = false;
                loadComboBox(cboMa, dsSP, "select maSP from CTSANPHAM group by maSP", "maSP", "maSP");
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
                    DataSet laySP = c.layDuLieu("select * from SANPHAM a, CTSANPHAM b where a.maSP = b.maSP and b.tenSP = '" + ma+"'");
                    dgvSP.DataSource = laySP.Tables[0];
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
                    DataSet laySP = c.layDuLieu("select * from SANPHAM a, CTSANPHAM b where a.maSP = b.maSP and a.maSP = '" + ma + "'");
                    dgvSP.DataSource = laySP.Tables[0];
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
        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSP.Rows.Count - 1)
            {
                int vitri = e.RowIndex;

                if (cboDS.SelectedIndex == 0)
                {
                    cboTen.Text = ds.Tables[0].Rows[vitri]["tenSP"].ToString();
                    cboMa.Enabled = false;
                }
                if (cboDS.SelectedIndex == 1)
                {
                    cboMa.Text = ds.Tables[0].Rows[vitri]["maSP"].ToString();
                    cboTen.Enabled = false;
                }

                DataView dv1 = new DataView();
                updateComboBoxTheoDataGridView(dv1, ds, "maSP = '" + cboMa.Text + "'", cboTen, "tenSP", "tenSP");
                DataView dv2 = new DataView();
                updateComboBoxTheoDataGridView(dv2, ds, "maSP = '" + cboMa.Text + "'", cboMa, "maSP", "maSP");
            }
            
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            frmTimKiemSP_Load(sender, e);
        }
    }
}
