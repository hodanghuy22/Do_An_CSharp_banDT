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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        public int openForms = 0;
        public MDIParent1()
        {
            InitializeComponent();
            this.MdiChildActivate += new System.EventHandler(this.MDIParent1_MdiChildActivate);
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            openForms++;
            Form1 childForm = new Form1();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();



        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_MdiChildActivate(object sender, EventArgs e)
        {
            //if (this.ActiveMdiChild == null)
            //{
            //    return;
            //}

            //foreach (Form child in this.MdiChildren)
            //{
            //    Xác định xem có form con nào đang được hiển thị hay không.
            //    if (child.Visible)
            //    {
            //        return;
            //    }
            //}

            //Nếu không có form con nào đang hiển thị, hỏi người dùng xác nhận trước khi thoát.
            //DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
        }

        private void MDIParent1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this.ActiveMdiChild == null)
            //{
            //    return;
            //}

            //foreach (Form child in this.MdiChildren)
            //{
            //    // Xác định xem có form con nào đang được hiển thị hay không.
            //    if (!child.Visible)
            //    {
            //        return;
            //    }
            //}

            //// Nếu không có form con nào đang hiển thị, hỏi người dùng xác nhận trước khi thoát.
            //DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
          
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
