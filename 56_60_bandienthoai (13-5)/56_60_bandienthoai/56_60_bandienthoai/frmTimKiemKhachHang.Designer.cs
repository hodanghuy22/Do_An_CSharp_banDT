namespace _56_60_bandienthoai
{
    partial class frmTimKiemKhachHang
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
            this.btnTatCa = new System.Windows.Forms.Button();
            this.cboMa = new System.Windows.Forms.ComboBox();
            this.cboDS = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTen = new System.Windows.Forms.ComboBox();
            this.dgvKH = new System.Windows.Forms.DataGridView();
            this.cboSDT = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTatCa
            // 
            this.btnTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnTatCa.Location = new System.Drawing.Point(398, 89);
            this.btnTatCa.Margin = new System.Windows.Forms.Padding(2);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(118, 37);
            this.btnTatCa.TabIndex = 4;
            this.btnTatCa.Text = "&Tất Cả";
            this.btnTatCa.UseVisualStyleBackColor = true;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // cboMa
            // 
            this.cboMa.FormattingEnabled = true;
            this.cboMa.Location = new System.Drawing.Point(398, 43);
            this.cboMa.Margin = new System.Windows.Forms.Padding(2);
            this.cboMa.Name = "cboMa";
            this.cboMa.Size = new System.Drawing.Size(118, 21);
            this.cboMa.TabIndex = 3;
            this.cboMa.SelectedIndexChanged += new System.EventHandler(this.cboMa_SelectedIndexChanged);
            // 
            // cboDS
            // 
            this.cboDS.FormattingEnabled = true;
            this.cboDS.Items.AddRange(new object[] {
            "Theo Tên",
            "Theo Mã",
            "Theo SDT"});
            this.cboDS.Location = new System.Drawing.Point(152, 35);
            this.cboDS.Margin = new System.Windows.Forms.Padding(2);
            this.cboDS.Name = "cboDS";
            this.cboDS.Size = new System.Drawing.Size(110, 21);
            this.cboDS.TabIndex = 0;
            this.cboDS.SelectedIndexChanged += new System.EventHandler(this.cboDS_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label3.Location = new System.Drawing.Point(288, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tìm theo mã";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.Location = new System.Drawing.Point(27, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 41);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tìm theo tên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 41);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tìm theo: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTen
            // 
            this.cboTen.FormattingEnabled = true;
            this.cboTen.Location = new System.Drawing.Point(152, 72);
            this.cboTen.Margin = new System.Windows.Forms.Padding(2);
            this.cboTen.Name = "cboTen";
            this.cboTen.Size = new System.Drawing.Size(110, 21);
            this.cboTen.TabIndex = 1;
            this.cboTen.SelectedIndexChanged += new System.EventHandler(this.cboTen_SelectedIndexChanged);
            // 
            // dgvKH
            // 
            this.dgvKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKH.Location = new System.Drawing.Point(30, 160);
            this.dgvKH.Margin = new System.Windows.Forms.Padding(2);
            this.dgvKH.Name = "dgvKH";
            this.dgvKH.RowHeadersWidth = 51;
            this.dgvKH.RowTemplate.Height = 24;
            this.dgvKH.Size = new System.Drawing.Size(486, 145);
            this.dgvKH.TabIndex = 21;
            this.dgvKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKH_CellClick);
            // 
            // cboSDT
            // 
            this.cboSDT.FormattingEnabled = true;
            this.cboSDT.Location = new System.Drawing.Point(152, 105);
            this.cboSDT.Margin = new System.Windows.Forms.Padding(2);
            this.cboSDT.Name = "cboSDT";
            this.cboSDT.Size = new System.Drawing.Size(110, 21);
            this.cboSDT.TabIndex = 2;
            this.cboSDT.SelectedIndexChanged += new System.EventHandler(this.cboSDT_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label4.Location = new System.Drawing.Point(27, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 41);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tìm theo sdt";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTimKiemKhachHang
            // 
            this.AcceptButton = this.btnTatCa;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 323);
            this.Controls.Add(this.dgvKH);
            this.Controls.Add(this.btnTatCa);
            this.Controls.Add(this.cboMa);
            this.Controls.Add(this.cboDS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSDT);
            this.Controls.Add(this.cboTen);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTimKiemKhachHang";
            this.Text = "frmTimKiemKhachHang";
            this.Load += new System.EventHandler(this.frmTimKiemKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.ComboBox cboMa;
        private System.Windows.Forms.ComboBox cboDS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTen;
        private System.Windows.Forms.DataGridView dgvKH;
        private System.Windows.Forms.ComboBox cboSDT;
        private System.Windows.Forms.Label label4;
    }
}