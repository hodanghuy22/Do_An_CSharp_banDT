namespace _56_60_bandienthoai
{
    partial class frmTimKiemHDNhap
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
            this.dgvHDN = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDN)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTatCa
            // 
            this.btnTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnTatCa.Location = new System.Drawing.Point(250, 28);
            this.btnTatCa.Margin = new System.Windows.Forms.Padding(2);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(107, 24);
            this.btnTatCa.TabIndex = 1;
            this.btnTatCa.Text = "&Tất Cả";
            this.btnTatCa.UseVisualStyleBackColor = true;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // cboMa
            // 
            this.cboMa.FormattingEnabled = true;
            this.cboMa.Location = new System.Drawing.Point(128, 28);
            this.cboMa.Margin = new System.Windows.Forms.Padding(2);
            this.cboMa.Name = "cboMa";
            this.cboMa.Size = new System.Drawing.Size(90, 21);
            this.cboMa.TabIndex = 0;
            this.cboMa.SelectedIndexChanged += new System.EventHandler(this.cboMa_SelectedIndexChanged);
            // 
            // dgvHDN
            // 
            this.dgvHDN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDN.Location = new System.Drawing.Point(23, 89);
            this.dgvHDN.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHDN.Name = "dgvHDN";
            this.dgvHDN.RowHeadersWidth = 51;
            this.dgvHDN.RowTemplate.Height = 24;
            this.dgvHDN.Size = new System.Drawing.Size(334, 192);
            this.dgvHDN.TabIndex = 22;
            this.dgvHDN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHDN_CellClick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label3.Location = new System.Drawing.Point(26, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 32);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tìm theo mã";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTimKiemHDNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 301);
            this.Controls.Add(this.btnTatCa);
            this.Controls.Add(this.cboMa);
            this.Controls.Add(this.dgvHDN);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTimKiemHDNhap";
            this.Text = "frmTimKiemHDNhap";
            this.Load += new System.EventHandler(this.frmTimKiemHDNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.ComboBox cboMa;
        private System.Windows.Forms.DataGridView dgvHDN;
        private System.Windows.Forms.Label label3;
    }
}