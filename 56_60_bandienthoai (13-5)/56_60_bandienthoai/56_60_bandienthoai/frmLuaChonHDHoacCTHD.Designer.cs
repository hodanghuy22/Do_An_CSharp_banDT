namespace _56_60_bandienthoai
{
    partial class frmLuaChonHDHoacCTHD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkHD = new System.Windows.Forms.CheckBox();
            this.chkCTHD = new System.Windows.Forms.CheckBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkHD
            // 
            this.chkHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHD.Location = new System.Drawing.Point(8, 34);
            this.chkHD.Margin = new System.Windows.Forms.Padding(2);
            this.chkHD.Name = "chkHD";
            this.chkHD.Size = new System.Drawing.Size(144, 40);
            this.chkHD.TabIndex = 1;
            this.chkHD.Text = "Chọn Hóa Đơn";
            this.chkHD.UseVisualStyleBackColor = true;
            // 
            // chkCTHD
            // 
            this.chkCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCTHD.Location = new System.Drawing.Point(156, 34);
            this.chkCTHD.Margin = new System.Windows.Forms.Padding(2);
            this.chkCTHD.Name = "chkCTHD";
            this.chkCTHD.Size = new System.Drawing.Size(135, 40);
            this.chkCTHD.TabIndex = 2;
            this.chkCTHD.Text = "Chọn CTHD";
            this.chkCTHD.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnXacNhan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(0, 89);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(291, 50);
            this.btnXacNhan.TabIndex = 3;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chọn 1 trong 2";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLuaChonHDHoacCTHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 139);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.chkCTHD);
            this.Controls.Add(this.chkHD);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLuaChonHDHoacCTHD";
            this.Text = "frmLuaChonHDHoacCTHD";
            this.Load += new System.EventHandler(this.frmLuaChonHDHoacCTHD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkHD;
        private System.Windows.Forms.CheckBox chkCTHD;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label label1;
    }
}