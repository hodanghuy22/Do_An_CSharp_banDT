using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_FORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }
       
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            //if (true)
            //{
            //    Nếu không còn form con nào đang mở, hiển thị thông báo.
            //   DialogResult result = MessageBox.Show("Bạn có muốn đóng cả chương trình không?", "Xác nhận", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes)
            //    {
            //        Đóng tất cả form con và form cha.
            //        foreach (Form form in this.MdiChildren)
            //        {
            //            form.Close();
            //        }
            //        this.Close();
            //    }
            //}
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }
    }
}
