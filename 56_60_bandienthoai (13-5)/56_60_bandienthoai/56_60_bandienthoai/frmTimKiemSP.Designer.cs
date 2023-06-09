namespace _56_60_bandienthoai
{
    partial class frmTimKiemSP
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
            this.cboMa = new System.Windows.Forms.ComboBox();
            this.cboDS = new System.Windows.Forms.ComboBox();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTen = new System.Windows.Forms.ComboBox();
            this.btnTatCa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMa
            // 
            this.cboMa.FormattingEnabled = true;
            this.cboMa.Location = new System.Drawing.Point(347, 77);
            this.cboMa.Margin = new System.Windows.Forms.Padding(2);
            this.cboMa.Name = "cboMa";
            this.cboMa.Size = new System.Drawing.Size(108, 21);
            this.cboMa.TabIndex = 3;
            this.cboMa.SelectedIndexChanged += new System.EventHandler(this.cboMa_SelectedIndexChanged);
            // 
            // cboDS
            // 
            this.cboDS.FormattingEnabled = true;
            this.cboDS.Items.AddRange(new object[] {
            "Theo Tên",
            "Theo Mã"});
            this.cboDS.Location = new System.Drawing.Point(121, 37);
            this.cboDS.Margin = new System.Windows.Forms.Padding(2);
            this.cboDS.Name = "cboDS";
            this.cboDS.Size = new System.Drawing.Size(110, 21);
            this.cboDS.TabIndex = 0;
            this.cboDS.SelectedIndexChanged += new System.EventHandler(this.cboDS_SelectedIndexChanged);
            // 
            // dgvSP
            // 
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Location = new System.Drawing.Point(35, 119);
            this.dgvSP.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.RowHeadersWidth = 51;
            this.dgvSP.RowTemplate.Height = 24;
            this.dgvSP.Size = new System.Drawing.Size(420, 169);
            this.dgvSP.TabIndex = 9;
            this.dgvSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSP_CellClick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label3.Location = new System.Drawing.Point(249, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tìm theo mã";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.Location = new System.Drawing.Point(32, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tìm theo tên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tìm theo: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTen
            // 
            this.cboTen.FormattingEnabled = true;
            this.cboTen.Location = new System.Drawing.Point(121, 74);
            this.cboTen.Margin = new System.Windows.Forms.Padding(2);
            this.cboTen.Name = "cboTen";
            this.cboTen.Size = new System.Drawing.Size(110, 21);
            this.cboTen.TabIndex = 1;
            this.cboTen.SelectedIndexChanged += new System.EventHandler(this.cboTen_SelectedIndexChanged);
            // 
            // btnTatCa
            // 
            this.btnTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnTatCa.Location = new System.Drawing.Point(347, 32);
            this.btnTatCa.Margin = new System.Windows.Forms.Padding(2);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(108, 30);
            this.btnTatCa.TabIndex = 2;
            this.btnTatCa.Text = "&Tất Cả";
            this.btnTatCa.UseVisualStyleBackColor = true;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // frmTimKiemSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 310);
            this.Controls.Add(this.btnTatCa);
            this.Controls.Add(this.cboMa);
            this.Controls.Add(this.cboDS);
            this.Controls.Add(this.dgvSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTen);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTimKiemSP";
            this.Text = "frmTimKiemSP";
            this.Load += new System.EventHandler(this.frmTimKiemSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMa;
        private System.Windows.Forms.ComboBox cboDS;
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTen;
        private System.Windows.Forms.Button btnTatCa;
    }
}