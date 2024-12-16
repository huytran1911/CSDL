using BLL;
using DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CSDLNCProject
{
    public partial class ThongKe : Form
    {
        private ThongKeBLL thongKeBLL = new ThongKeBLL();

        public ThongKe()
        {
            InitializeComponent();
        }

        // Load dữ liệu khi form mở
        private void ThongKe_Load(object sender, EventArgs e)
        {
            LoadThongKeData();
        }

        // Hàm load dữ liệu thống kê từ BLL
        private void LoadThongKeData()
        {
            try
            {
                dgvThongKe.DataSource = thongKeBLL.GetThongKeNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện CellClick để hiển thị dữ liệu chi tiết lên TextBox
        private void dgvThongKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvThongKe.Rows[e.RowIndex];

                // Gán dữ liệu vào các ô TextBox
                textMaNhanVien.Text = selectedRow.Cells["manhanvien"].Value.ToString();
                textTenNhanVien.Text = selectedRow.Cells["hoten"].Value.ToString();
                textLuongCoBan.Text = selectedRow.Cells["luongcoban"].Value.ToString();
                textThuong.Text = selectedRow.Cells["thuong"].Value.ToString();
                textSoNgayNghi.Text = selectedRow.Cells["songaynghi"].Value.ToString();

                // Đổi ngày nhận lương
                if (DateTime.TryParseExact(selectedRow.Cells["ThangNhanLuong"].Value.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime thangNhanLuong))
                {
                    dateNgayNhanLuong.Value = thangNhanLuong;
                }
                else
                {
                    dateNgayNhanLuong.Value = DateTime.Now;
                }

                textLuongNhanDuoc.Text = selectedRow.Cells["luongnhanduoc"].Value.ToString();
            }
        }
    }
}
