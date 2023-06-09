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
    public partial class frmTimHDBan : Form
    {
        public frmTimHDBan()
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
        private void frmTimHDBan_Load(object sender, EventArgs e)
        {
            dsSP = c.layDuLieu("select * from HOADONBAN a, CTHOADONBAN b where a.maHD = b.maHD");
            dgvHDB.DataSource = dsSP.Tables[0];
            ds = c.layDuLieu("select * from HOADONBAN a, CTHOADONBAN b where a.maHD = b.maHD");

            cboMa.Enabled = true;
            loadComboBox(cboMa, dsSP, "select maHD from HOADONBAN group by maHD", "maHD", "maHD");
            flag = true;
        }

        private void cboMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (cboMa.SelectedIndex != -1)
                {
                    string ma = cboMa.SelectedValue.ToString();
                    DataSet laySP = c.layDuLieu("select * from HOADONBAN a, CTHOADONBAN b where a.maHD = b.maHD and a.maHD = '" + ma + "'");
                    dgvHDB.DataSource = laySP.Tables[0];
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
        private void dgvHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvHDB.Rows.Count - 1)
            {
                int vitri = e.RowIndex;

                cboMa.Text = ds.Tables[0].Rows[vitri]["maHD"].ToString();

                DataView dv2 = new DataView();
                updateComboBoxTheoDataGridView(dv2, ds, "maHD = '" + cboMa.Text + "'", cboMa, "maHD", "maHD");
            }
            
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            dsSP = c.layDuLieu("select * from HOADONBAN a, CTHOADONBAN b where a.maHD = b.maHD");
            dgvHDB.DataSource = dsSP.Tables[0];
            ds = c.layDuLieu("select * from HOADONBAN a, CTHOADONBAN b where a.maHD = b.maHD");

            loadComboBox(cboMa, dsSP, "select maHD from HOADONBAN group by maHD", "maHD", "maHD");
        }
    }
}
