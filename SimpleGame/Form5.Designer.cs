namespace SimpleGame
{
    partial class Form5
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
            this.bt_xoa = new System.Windows.Forms.Button();
            this.bt_them = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_diem = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_ma = new System.Windows.Forms.TextBox();
            this.tb_stt = new System.Windows.Forms.TextBox();
            this.lb_stt = new System.Windows.Forms.Label();
            this.lb_ma = new System.Windows.Forms.Label();
            this.lb_diem = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_xoa
            // 
            this.bt_xoa.Location = new System.Drawing.Point(480, 417);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(127, 67);
            this.bt_xoa.TabIndex = 10;
            this.bt_xoa.Text = "Xóa";
            this.bt_xoa.UseVisualStyleBackColor = true;
            this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
            // 
            // bt_them
            // 
            this.bt_them.Location = new System.Drawing.Point(480, 312);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(127, 72);
            this.bt_them.TabIndex = 8;
            this.bt_them.Text = "Thêm";
            this.bt_them.UseVisualStyleBackColor = true;
            this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_diem);
            this.groupBox2.Controls.Add(this.tb_name);
            this.groupBox2.Controls.Add(this.tb_ma);
            this.groupBox2.Controls.Add(this.tb_stt);
            this.groupBox2.Controls.Add(this.lb_stt);
            this.groupBox2.Controls.Add(this.lb_ma);
            this.groupBox2.Controls.Add(this.lb_diem);
            this.groupBox2.Controls.Add(this.lb_name);
            this.groupBox2.Location = new System.Drawing.Point(98, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 294);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Điền thông tin";
            // 
            // tb_diem
            // 
            this.tb_diem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_diem.Enabled = false;
            this.tb_diem.Location = new System.Drawing.Point(140, 206);
            this.tb_diem.Name = "tb_diem";
            this.tb_diem.Size = new System.Drawing.Size(167, 22);
            this.tb_diem.TabIndex = 7;
            // 
            // tb_name
            // 
            this.tb_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_name.Location = new System.Drawing.Point(140, 158);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(167, 22);
            this.tb_name.TabIndex = 6;
            // 
            // tb_ma
            // 
            this.tb_ma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ma.Location = new System.Drawing.Point(140, 106);
            this.tb_ma.Name = "tb_ma";
            this.tb_ma.Size = new System.Drawing.Size(167, 22);
            this.tb_ma.TabIndex = 5;
            // 
            // tb_stt
            // 
            this.tb_stt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_stt.Location = new System.Drawing.Point(140, 59);
            this.tb_stt.Name = "tb_stt";
            this.tb_stt.Size = new System.Drawing.Size(167, 22);
            this.tb_stt.TabIndex = 4;
            // 
            // lb_stt
            // 
            this.lb_stt.AutoSize = true;
            this.lb_stt.Location = new System.Drawing.Point(61, 62);
            this.lb_stt.Name = "lb_stt";
            this.lb_stt.Size = new System.Drawing.Size(34, 16);
            this.lb_stt.TabIndex = 3;
            this.lb_stt.Text = "STT";
            // 
            // lb_ma
            // 
            this.lb_ma.AutoSize = true;
            this.lb_ma.Location = new System.Drawing.Point(31, 112);
            this.lb_ma.Name = "lb_ma";
            this.lb_ma.Size = new System.Drawing.Size(89, 16);
            this.lb_ma.TabIndex = 2;
            this.lb_ma.Text = "MaNguoiChoi";
            // 
            // lb_diem
            // 
            this.lb_diem.AutoSize = true;
            this.lb_diem.Location = new System.Drawing.Point(36, 212);
            this.lb_diem.Name = "lb_diem";
            this.lb_diem.Size = new System.Drawing.Size(59, 16);
            this.lb_diem.TabIndex = 1;
            this.lb_diem.Text = "So Diem";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(31, 161);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(94, 16);
            this.lb_name.TabIndex = 0;
            this.lb_name.Text = "TenNguoiChoi";
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(40, 21);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(534, 159);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Location = new System.Drawing.Point(58, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 208);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 715);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bt_xoa);
            this.Controls.Add(this.bt_them);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin người chơi";
            this.Load += new System.EventHandler(this.Form5_Load_1);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Button bt_them;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_diem;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_ma;
        private System.Windows.Forms.TextBox tb_stt;
        private System.Windows.Forms.Label lb_stt;
        private System.Windows.Forms.Label lb_ma;
        private System.Windows.Forms.Label lb_diem;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}