namespace CSDLNCProject
{
    partial class Luong
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.textTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textMaNhanVien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textTenNhanVien = new System.Windows.Forms.TextBox();
            this.textThuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textLuongCoBan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textSoNgayNghi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateNgayNhanLuong = new System.Windows.Forms.DateTimePicker();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textLuongNhanDuoc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bảng tính lương nhân viên";
            // 
            // dgvLuong
            // 
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuong.Location = new System.Drawing.Point(0, 166);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.RowHeadersWidth = 51;
            this.dgvLuong.RowTemplate.Height = 24;
            this.dgvLuong.Size = new System.Drawing.Size(1002, 253);
            this.dgvLuong.TabIndex = 1;
            this.dgvLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLuong_CellClick);
            // 
            // textTimKiem
            // 
            this.textTimKiem.Location = new System.Drawing.Point(130, 128);
            this.textTimKiem.Name = "textTimKiem";
            this.textTimKiem.Size = new System.Drawing.Size(346, 22);
            this.textTimKiem.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(632, 127);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(161, 25);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm nhân viên";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã nhân viên";
            // 
            // textMaNhanVien
            // 
            this.textMaNhanVien.Location = new System.Drawing.Point(168, 445);
            this.textMaNhanVien.Name = "textMaNhanVien";
            this.textMaNhanVien.Size = new System.Drawing.Size(226, 22);
            this.textMaNhanVien.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên nhân viên";
            // 
            // textTenNhanVien
            // 
            this.textTenNhanVien.Location = new System.Drawing.Point(168, 485);
            this.textTenNhanVien.Name = "textTenNhanVien";
            this.textTenNhanVien.Size = new System.Drawing.Size(226, 22);
            this.textTenNhanVien.TabIndex = 7;
            // 
            // textThuong
            // 
            this.textThuong.Location = new System.Drawing.Point(168, 561);
            this.textThuong.Name = "textThuong";
            this.textThuong.Size = new System.Drawing.Size(226, 22);
            this.textThuong.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 561);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Thưởng";
            // 
            // textLuongCoBan
            // 
            this.textLuongCoBan.Location = new System.Drawing.Point(168, 521);
            this.textLuongCoBan.Name = "textLuongCoBan";
            this.textLuongCoBan.Size = new System.Drawing.Size(226, 22);
            this.textLuongCoBan.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 524);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lương cơ bản";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 482);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ngày nhận lương";
            // 
            // textSoNgayNghi
            // 
            this.textSoNgayNghi.Location = new System.Drawing.Point(567, 442);
            this.textSoNgayNghi.Name = "textSoNgayNghi";
            this.textSoNgayNghi.Size = new System.Drawing.Size(226, 22);
            this.textSoNgayNghi.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(427, 445);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Số ngày nghỉ";
            // 
            // dateNgayNhanLuong
            // 
            this.dateNgayNhanLuong.CustomFormat = "dd/MM/yyyy";
            this.dateNgayNhanLuong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayNhanLuong.Location = new System.Drawing.Point(567, 480);
            this.dateNgayNhanLuong.MaxDate = new System.DateTime(9998, 12, 1, 0, 0, 0, 0);
            this.dateNgayNhanLuong.Name = "dateNgayNhanLuong";
            this.dateNgayNhanLuong.Size = new System.Drawing.Size(226, 22);
            this.dateNgayNhanLuong.TabIndex = 20;
            this.dateNgayNhanLuong.Value = new System.DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Location = new System.Drawing.Point(476, 531);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(167, 46);
            this.btnTinhLuong.TabIndex = 21;
            this.btnTinhLuong.Text = "Tính lương";
            this.btnTinhLuong.UseVisualStyleBackColor = true;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(662, 546);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Lương nhận được";
            // 
            // textLuongNhanDuoc
            // 
            this.textLuongNhanDuoc.Location = new System.Drawing.Point(777, 543);
            this.textLuongNhanDuoc.Name = "textLuongNhanDuoc";
            this.textLuongNhanDuoc.Size = new System.Drawing.Size(158, 22);
            this.textLuongNhanDuoc.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(941, 546);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "VNĐ";
            // 
            // Luong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 595);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textLuongNhanDuoc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnTinhLuong);
            this.Controls.Add(this.dateNgayNhanLuong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textSoNgayNghi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textThuong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textLuongCoBan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textTenNhanVien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textMaNhanVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.textTimKiem);
            this.Controls.Add(this.dgvLuong);
            this.Controls.Add(this.label1);
            this.Name = "Luong";
            this.Text = "Luong";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.TextBox textTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textMaNhanVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTenNhanVien;
        private System.Windows.Forms.TextBox textThuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textLuongCoBan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textSoNgayNghi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateNgayNhanLuong;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textLuongNhanDuoc;
        private System.Windows.Forms.Label label9;
    }
}