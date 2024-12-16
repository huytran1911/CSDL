using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace CSDLNCProject
{
    public partial class FormAddNewEmployee : Form
    {
        private UpdateNhanVienBLL updateNhanVienBLL = new UpdateNhanVienBLL();
        private NhanVienDTO currentNhanVien; // Lưu trữ nhân viên cần sửa
       

        public FormAddNewEmployee(FormMain mainForm, NhanVienDTO nhanVien = null)
        {
            InitializeComponent();
            
            LoadComboBoxData(); // Load dữ liệu các ComboBox

            if (nhanVien != null)
            {
                currentNhanVien = nhanVien;
                LoadDataToForm(nhanVien);
            }
            else
            {
                textMaNhanVien.ReadOnly = false; // Cho phép nhập mã nhân viên khi thêm mới
            }
        }

        private bool ValidateContractDates(DateTime dateStart, DateTime dateEnd)
        {
            // Kiểm tra ngày kết thúc phải lớn hơn ngày bắt đầu ít nhất 1 tháng
            int differenceInMonths = ((dateEnd.Year - dateStart.Year) * 12) + (dateEnd.Month - dateStart.Month);
            return differenceInMonths > 1 || (differenceInMonths == 1 && dateEnd.Day >= dateStart.Day);
        }

        private void LoadComboBoxData()
        {
            // Dữ liệu sẵn cho ComboBox
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("Khác");

            cboPhongBan.Items.Add("Nhân viên");
            cboPhongBan.Items.Add("Trưởng phòng");
            cboPhongBan.Items.Add("Phó phòng");
            cboPhongBan.Items.Add("Giám đốc");
        }

        private void LoadDataToForm(NhanVienDTO nhanVien)
        {

            textMaNhanVien.Text = nhanVien.manhanvien.ToString();
            textMaNhanVien.ReadOnly = true; // Không cho phép sửa mã nhân viên

            textTen.Text = nhanVien.hoten;
            dateBirth.Value = nhanVien.ngaysinh;
            textDiaChi.Text = nhanVien.diachi;
            textEmail.Text = nhanVien.email;
            cboGioiTinh.Text = nhanVien.gioitinh;
            textSDT.Text = nhanVien.sodienthoai;
            cboPhongBan.Text = nhanVien.chucvu;
            textLuongCoBan.Text = nhanVien.luongcoban.ToString();
            cboPhongBan.Text = nhanVien.phongban;
            dateStart.Value = nhanVien.thoigianbatdauhopdong;
            dateEnd.Value = nhanVien.thoigianketthuchopdong;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dateStart.Value;
                DateTime endDate = dateEnd.Value;

                // Kiểm tra điều kiện ngày hợp đồng
                if (!ValidateContractDates(startDate, endDate))
                {
                    MessageBox.Show("Ngày bắt đầu hợp đồng phải nhỏ hơn ngày kết thúc hợp đồng ít nhất 1 tháng!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng thực thi nếu không thỏa điều kiện
                }
                var nhanVien = new NhanVienDTO
                {
                    manhanvien = int.Parse(textMaNhanVien.Text),
                    hoten = textTen.Text,
                    ngaysinh = dateBirth.Value,
                    diachi = textDiaChi.Text,
                    email = textEmail.Text,
                    gioitinh = cboGioiTinh.Text,
                    sodienthoai = textSDT.Text,
                    chucvu = cboPhongBan.Text,
                    luongcoban = long.Parse(textLuongCoBan.Text),
                    phongban = cboPhongBan.Text,
                    thoigianbatdauhopdong = dateStart.Value.Date, // Loại bỏ giờ
                    thoigianketthuchopdong = dateEnd.Value.Date  // Loại bỏ giờ
                };

                
                if (currentNhanVien == null)
                {
                    // Thêm mới nhân viên
                    updateNhanVienBLL.AddNhanVien(nhanVien);
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nhanVien.manhanvien = int.Parse(textMaNhanVien.Text);
                }
                else
                {
                    // Sửa nhân viên
                    updateNhanVienBLL.UpdateNhanVien(nhanVien);
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nhanVien.manhanvien = currentNhanVien.manhanvien; // Giữ nguyên mã nhân viên
                }

                // Reload dữ liệu MainForm trước khi đóng
               
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
