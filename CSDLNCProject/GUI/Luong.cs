using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace CSDLNCProject
{
    public partial class Luong : Form
    {
        private LuongBLL luongBLL = new LuongBLL();
        private List<NhanVienDTO> danhSachNhanVien;

        public Luong()
        {
            InitializeComponent();
            LoadData(); // Load dữ liệu nhân viên khi mở form
        }

        // Load danh sách nhân viên chưa nhận lương
        private void LoadData()
        {
            DateTime selectedMonth = dateNgayNhanLuong.Value;

            // Lấy danh sách nhân viên chưa nhận lương
            var danhSachNhanVien = luongBLL.GetNhanVienChuaNhanLuong(selectedMonth);

            dgvLuong.DataSource = danhSachNhanVien.Select(nv => new
            {
                nv.manhanvien,
                nv.hoten,
                nv.chucvu,
                nv.phongban,
                nv.luongcoban
            }).ToList();
        }

        // Sự kiện click vào DataGridView để hiển thị thông tin nhân viên
        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvLuong.Rows[e.RowIndex];

                // Gán thông tin lên các ô text
                textMaNhanVien.Text = selectedRow.Cells["manhanvien"].Value.ToString();
                textTenNhanVien.Text = selectedRow.Cells["hoten"].Value.ToString();
                textLuongCoBan.Text = selectedRow.Cells["luongcoban"].Value.ToString();
                textThuong.Text = "0"; // Giá trị mặc định
                textSoNgayNghi.Text = "0"; // Giá trị mặc định
                dateNgayNhanLuong.Value = DateTime.Now; // Ngày nhận lương mặc định
            }
        }

        // Nút Tính Lương
        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các ô nhập liệu
                int manhanvien = int.Parse(textMaNhanVien.Text);
                long luongCoBan = long.Parse(textLuongCoBan.Text);
                long thuong = long.Parse(textThuong.Text);
                int soNgayNghi = int.Parse(textSoNgayNghi.Text);
                DateTime thangNhanLuong = dateNgayNhanLuong.Value;

                // Tính lương
                long luongNhanDuoc = luongBLL.TinhLuongNhanDuoc(luongCoBan, thuong, soNgayNghi);

                // Cập nhật hoặc thêm dữ liệu lương vào database
                luongBLL.CapNhatLuong(manhanvien, luongNhanDuoc, thangNhanLuong);

                // Hiển thị lương nhận được trong ô TextBox
                textLuongNhanDuoc.Text = luongNhanDuoc.ToString();

                // Reload lại danh sách nhân viên
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Sự kiện Tìm Nhân Viên theo tháng
        private void btnTimNhanVien_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = textTimKiem.Text.Trim();
                DateTime selectedMonth = dateNgayNhanLuong.Value;

                if (string.IsNullOrEmpty(keyword))
                {
                    LoadData(); // Nếu từ khóa trống, load lại danh sách chưa nhận lương
                    return;
                }

                var searchResult = luongBLL.SearchNhanVien(keyword, selectedMonth);

                dgvLuong.DataSource = searchResult.Select(nv => new
                {
                    nv.manhanvien,
                    nv.hoten,
                    nv.chucvu,
                    nv.phongban,
                    nv.luongcoban
                }).ToList();

                if (searchResult.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
