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
    public partial class frmLuaChonHDHoacCTHD : Form
    {
        public frmLuaChonHDHoacCTHD()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int choice = 0;

            if (chkHD.Checked)
            {
                choice = 1;
            }
            else if (chkCTHD.Checked)
            {
                choice = 2;
            }

            this.DialogResult = DialogResult.OK;
            this.Tag = choice;
            this.Close();
        }

        private void frmLuaChonHDHoacCTHD_Load(object sender, EventArgs e)
        {

        }
    }
}
