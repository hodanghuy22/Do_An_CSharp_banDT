namespace _56_60_bandienthoai
{
    partial class frmThongKeHoaDon
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
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.txtNgayKetThuc = new System.Windows.Forms.TextBox();
            this.txtNgayBatDau = new System.Windows.Forms.TextBox();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radMoiNhat = new System.Windows.Forms.RadioButton();
            this.radCuNhat = new System.Windows.Forms.RadioButton();
            this.radDoanhThu = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(57, 253);
            this.dgvHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.Size = new System.Drawing.Size(563, 159);
            this.dgvHoaDon.TabIndex = 24;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(354, 129);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(108, 31);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "&Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(183, 135);
            this.txtTop.Margin = new System.Windows.Forms.Padding(2);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(144, 20);
            this.txtTop.TabIndex = 3;
            // 
            // txtNgayKetThuc
            // 
            this.txtNgayKetThuc.Location = new System.Drawing.Point(499, 93);
            this.txtNgayKetThuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtNgayKetThuc.Name = "txtNgayKetThuc";
            this.txtNgayKetThuc.Size = new System.Drawing.Size(144, 20);
            this.txtNgayKetThuc.TabIndex = 2;
            // 
            // txtNgayBatDau
            // 
            this.txtNgayBatDau.Location = new System.Drawing.Point(183, 86);
            this.txtNgayBatDau.Margin = new System.Windows.Forms.Padding(2);
            this.txtNgayBatDau.Name = "txtNgayBatDau";
            this.txtNgayBatDau.Size = new System.Drawing.Size(144, 20);
            this.txtNgayBatDau.TabIndex = 1;
            // 
            // cboLoai
            // 
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Items.AddRange(new object[] {
            "Hóa Đơn Bán",
            "Hóa Đơn Nhập"});
            this.cboLoai.Location = new System.Drawing.Point(218, 31);
            this.cboLoai.Margin = new System.Windows.Forms.Padding(2);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(144, 21);
            this.cboLoai.TabIndex = 0;
            this.cboLoai.SelectedIndexChanged += new System.EventHandler(this.cboLoai_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 32);
            this.label4.TabIndex = 15;
            this.label4.Text = "Chọn Top:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(345, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 32);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nhập ngày kết thúc";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 32);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nhập ngày bắt đầu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 37);
            this.label1.TabIndex = 18;
            this.label1.Text = "Chọn loại Hóa Đơn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radMoiNhat);
            this.groupBox1.Controls.Add(this.radCuNhat);
            this.groupBox1.Controls.Add(this.radDoanhThu);
            this.groupBox1.Location = new System.Drawing.Point(37, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 47);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sắp Xếp";
            // 
            // radMoiNhat
            // 
            this.radMoiNhat.AutoSize = true;
            this.radMoiNhat.Location = new System.Drawing.Point(261, 30);
            this.radMoiNhat.Name = "radMoiNhat";
            this.radMoiNhat.Size = new System.Drawing.Size(68, 17);
            this.radMoiNhat.TabIndex = 2;
            this.radMoiNhat.TabStop = true;
            this.radMoiNhat.Text = "Mới Nhất";
            this.radMoiNhat.UseVisualStyleBackColor = true;
            // 
            // radCuNhat
            // 
            this.radCuNhat.AutoSize = true;
            this.radCuNhat.Location = new System.Drawing.Point(159, 30);
            this.radCuNhat.Name = "radCuNhat";
            this.radCuNhat.Size = new System.Drawing.Size(64, 17);
            this.radCuNhat.TabIndex = 1;
            this.radCuNhat.TabStop = true;
            this.radCuNhat.Text = "Cũ Nhất";
            this.radCuNhat.UseVisualStyleBackColor = true;
            // 
            // radDoanhThu
            // 
            this.radDoanhThu.AutoSize = true;
            this.radDoanhThu.Location = new System.Drawing.Point(20, 30);
            this.radDoanhThu.Name = "radDoanhThu";
            this.radDoanhThu.Size = new System.Drawing.Size(107, 17);
            this.radDoanhThu.TabIndex = 0;
            this.radDoanhThu.TabStop = true;
            this.radDoanhThu.Text = "Theo Doanh Thu";
            this.radDoanhThu.UseVisualStyleBackColor = true;
            // 
            // frmThongKeHoaDon
            // 
            this.AcceptButton = this.btnThongKe;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.txtTop);
            this.Controls.Add(this.txtNgayKetThuc);
            this.Controls.Add(this.txtNgayBatDau);
            this.Controls.Add(this.cboLoai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmThongKeHoaDon";
            this.Text = "frmThongKeHoaDon";
            this.Load += new System.EventHandler(this.frmThongKeHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.TextBox txtNgayKetThuc;
        private System.Windows.Forms.TextBox txtNgayBatDau;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radMoiNhat;
        private System.Windows.Forms.RadioButton radCuNhat;
        private System.Windows.Forms.RadioButton radDoanhThu;
    }
}