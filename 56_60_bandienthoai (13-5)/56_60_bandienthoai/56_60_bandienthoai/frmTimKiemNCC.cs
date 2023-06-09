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
    public partial class frmTimKiemNCC : Form
    {
        public frmTimKiemNCC()
        {
            InitializeComponent();
        }
        clsBanDienThoai c = new clsBanDienThoai();
        DataSet dsNCC = new DataSet();
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
        private void frmTimKiemNCCTheoTen_Load(object sender, EventArgs e)
        {
            cboTenNCC.Enabled = false;
            cboMaNCC.Enabled = false;
            //loadComboBox(cboMaNCC, dsNCC, "select * from NHACUNGCAP", "tenNCC", "maNCC");
            //flag = true;
            DataSet layNCC = c.layDuLieu("select * from NHACUNGCAP");
            dgvNCC.DataSource = layNCC.Tables[0];
            ds = c.layDuLieu("select * from NHACUNGCAP");
            cboDS.SelectedIndex = -1;
        }
        private void cboTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(flag == true)
            {
                if(cboTenNCC.SelectedIndex != -1)
                {
                    string maNCC = cboTenNCC.SelectedValue.ToString();
                    DataSet layNCC = c.layDuLieu("select * from NHACUNGCAP where maNCC = '" + maNCC + "'");
                    dgvNCC.DataSource = layNCC.Tables[0];
                }
            }
        }

        private void cboDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboDS.SelectedIndex == 0)
            {
                flag = false;
                cboTenNCC.Enabled = true;
                cboMaNCC.Text = "";
                cboMaNCC.Enabled = false;
                loadComboBox(cboTenNCC, dsNCC, "select * from NHACUNGCAP", "tenNCC", "maNCC");
                flag = true;    
            }
            else
            {
                flag = false;
                cboMaNCC.Enabled = true;
                cboTenNCC.Text = "";
                cboTenNCC.Enabled = false;
                loadComboBox(cboMaNCC, dsNCC, "select * from NHACUNGCAP", "maNCC", "maNCC");
                flag = true;
            }
        }

        private void cboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (cboMaNCC.SelectedIndex != -1)
                {
                    string maNCC = cboMaNCC.SelectedValue.ToString();
                    DataSet layNCC = c.layDuLieu("select * from NHACUNGCAP where maNCC = '" + maNCC + "'");
                    dgvNCC.DataSource = layNCC.Tables[0];
                }
            }
        }

        private void updateComboBoxTheoDataGridView(DataView dv, DataSet ds,string sql, ComboBox cbo, string hienthi, string giatri)
        {
            dv.Table = ds.Tables[0];
            dv.RowFilter = sql;
            cbo.DataSource = dv;
            cbo.DisplayMember = hienthi;
            cbo.ValueMember = giatri;
        }
        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNCC.Rows.Count - 1)
            {
                int vitri = e.RowIndex;

                if (cboDS.SelectedIndex == 0)
                {
                    cboTenNCC.Text = ds.Tables[0].Rows[vitri]["tenNCC"].ToString();
                    cboMaNCC.Text = "";
                }
                else
                {
                    cboMaNCC.Text = ds.Tables[0].Rows[vitri]["maNCC"].ToString();
                    cboTenNCC.Text = "";
                }

                DataView dvNCC1 = new DataView();
                updateComboBoxTheoDataGridView(dvNCC1, ds, "maNCC = '" + cboMaNCC.Text + "'", cboTenNCC, "tenNCC", "maNCC");
                DataView dvNCC2 = new DataView();
                updateComboBoxTheoDataGridView(dvNCC2, ds, "maNCC = '" + cboMaNCC.Text + "'", cboMaNCC, "maNCC", "maNCC");
            }
            
            //dvNCC.Table = ds.Tables[0];
            //dvNCC.RowFilter = "maNCC = '" + cboMaNCC.Text + "'";
            //cboMaNCC.DataSource = dvNCC;
            //cboMaNCC.DisplayMember = "tenNCC";
            //cboMaNCC.ValueMember = "maNCC";

        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            frmTimKiemNCCTheoTen_Load(sender, e);   
        }
    }
}
