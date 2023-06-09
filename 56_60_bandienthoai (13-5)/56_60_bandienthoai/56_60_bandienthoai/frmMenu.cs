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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        
        private void mnuNhapHDB_Click(object sender, EventArgs e)
        {
            Form childForm = new frmHOADONBAN();
            childForm.MdiParent = this;
            childForm.Text = "Hóa Đơn ";
            childForm.Show();
        }

        private void mnuNhapHDN_Click(object sender, EventArgs e)
        {
            Form childForm = new frmHOADONNHAP();
            childForm.MdiParent = this;
            childForm.Text = "Sản Phẩm ";
            childForm.Show();
        }

        private void mnuNhapSP_Click(object sender, EventArgs e)
        {
            Form childForm = new frmSANPHAM();
            childForm.MdiParent = this;
            childForm.Text = "Nhập Sản Phẩm";
            childForm.Show();
        }
        private void mnuNhapNV_Click(object sender, EventArgs e)
        {
            Form childForm = new frmNHANVIEN();
            childForm.MdiParent = this;
            childForm.Text = "Nhập Nhân Viên";
            childForm.Show();
        }

        private void mnuNhapKH_Click(object sender, EventArgs e)
        {
            Form childForm = new frmKHACHHANG();
            childForm.MdiParent = this;
            childForm.Text = "Nhập Khách Hàng";
            childForm.Show();
        }

        private void mnuNhapNCC_Click(object sender, EventArgs e)
        {
            Form childForm = new frmNHACUNGCAP();
            childForm.MdiParent = this;
            childForm.Text = "Nhập Nhà Cung Cấp";
            childForm.Show();
        }

        private void tìmHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmTimHDBan();
            childForm.MdiParent = this;
            childForm.Text = "Tìm kiếm hóa đơn Bán";
            childForm.Show();
        }

        private void tìmHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmTimKiemHDNhap();
            childForm.MdiParent = this;
            childForm.Text = "Tìm kiếm hóa đơn Nhập";
            childForm.Show();
        }

        private void tìmNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmTimKiemNCC();
            childForm.MdiParent = this;
            childForm.Text = "Tìm kiếm nhà cung cấp";
            childForm.Show();
        }

        private void tìmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmTimKiemSP();
            childForm.MdiParent = this;
            childForm.Text = "Tìm kiếm sản phẩm";
            childForm.Show();
        }

        private void tìmNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmTimKiemNhanVien();
            childForm.MdiParent = this;
            childForm.Text = "Tìm kiếm nhân viên";
            childForm.Show();
        }

        private void tìmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmTimKiemKhachHang();
            childForm.MdiParent = this;
            childForm.Text = "Tìm kiếm khách hàng";
            childForm.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void thôngKêNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmThongKeNCC();
            childForm.MdiParent = this;
            childForm.Text = "Thống kê nhà cung cấp";
            childForm.Show();
        }

        private void thôngKêSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmThongKeSP();
            childForm.MdiParent = this;
            childForm.Text = "Thống kê sản phẩm";
            childForm.Show();
        }

        private void trảHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmTraHang();
            childForm.MdiParent = this;
            childForm.Text = "Trả Hàng" ;
            childForm.Show();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            foreach (Form child in this.MdiChildren)
            {
                // Xác định xem có form con nào đang được hiển thị hay không.
                if (!child.Visible)
                {
                    return;
                }
            }

            // Nếu không có form con nào đang hiển thị, hỏi người dùng xác nhận trước khi thoát.
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, cho phép form đóng.
                e.Cancel = false;
            }
            else
            {
                // Ngăn chặn việc đóng form nếu người dùng chọn No.
                e.Cancel = true;
            }
        }

        private void thốngKêHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmThongKeHoaDon();
            childForm.MdiParent = this;
            childForm.Text = "Thống kê Hóa Đơn";
            childForm.Show();
        }

        private void đóngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
