using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace CSDLNCProject
{
    public partial class FormMain : Form
    {
        public bool isExit = true;
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public event EventHandler Logout;

        public FormMain()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void loadNhanVien()
        {

            dgvNhanVien.DataSource = nhanVienBLL.GetAllNhanVien();

            dgvNhanVien.Columns[1].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Họ và tên";
            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[5].HeaderText = "Email";
            dgvNhanVien.Columns[6].HeaderText = "Giới tính";
            dgvNhanVien.Columns[7].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[8].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[10].HeaderText = "Phòng ban";
            dgvNhanVien.Columns[12].HeaderText = "Thời gian bắt đầu hợp đồng";
            dgvNhanVien.Columns[13].HeaderText = "Thời gian kết thúc hợp đồng";
            dgvNhanVien.Columns[9].HeaderText = "Lương cơ bản";
            dgvNhanVien.Columns["ngaysinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns["thoigianbatdauhopdong"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns["thoigianketthuchopdong"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvNhanVien.Columns["_id"] != null)
            {
                dgvNhanVien.Columns["_id"].Visible = false;
            }
            if (dgvNhanVien.Columns["songaynghi"] != null)
                dgvNhanVien.Columns["songaynghi"].Visible = false;

            

            if (dgvNhanVien.Columns["luongnhanduoc"] != null)
                dgvNhanVien.Columns["luongnhanduoc"].Visible = false;

            if (dgvNhanVien.Columns["thuong"] != null)
                dgvNhanVien.Columns["thuong"].Visible = false;

            if (dgvNhanVien.Columns["thangnhanluong"] != null)
                dgvNhanVien.Columns["thangnhanluong"].Visible = false;

            if (dgvNhanVien.Columns["maphongban"] != null)
                dgvNhanVien.Columns["maphongban"].Visible = false;
        }

        private void FormMain_Load_1(object sender, EventArgs e)
        {
            loadNhanVien();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isExit)
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout(this, new EventArgs());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = textTimKiem.Text.Trim(); // Lấy từ khóa nhập vào

            // Gọi hàm tìm kiếm từ BLL
            var searchResult = nhanVienBLL.SearchNhanVien(keyword).Select(nv => new {
                nv.manhanvien,
                nv.hoten,
                nv.ngaysinh,
                nv.diachi,
                nv.email,
                nv.gioitinh,
                nv.sodienthoai,
                nv.chucvu,
                nv.phongban,
                nv.thoigianbatdauhopdong,
                nv.thoigianketthuchopdong
            }).ToList();

            // Hiển thị kết quả tìm kiếm trên DataGridView
            dgvNhanVien.DataSource = searchResult;

            if (searchResult.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddNhanVien_Click(object sender, EventArgs e)
        {
            FormAddNewEmployee formAddNewEmployee = new FormAddNewEmployee(this,null);
            formAddNewEmployee.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                var selectedRow = dgvNhanVien.CurrentRow;
                var nhanVien = new NhanVienDTO
                {
                    manhanvien = int.Parse(selectedRow.Cells["manhanvien"].Value.ToString()),
                    hoten = selectedRow.Cells["hoten"].Value.ToString(),
                    ngaysinh = DateTime.Parse(selectedRow.Cells["ngaysinh"].Value.ToString()),
                    diachi = selectedRow.Cells["diachi"].Value.ToString(),
                    email = selectedRow.Cells["email"].Value.ToString(),
                    gioitinh = selectedRow.Cells["gioitinh"].Value.ToString(),
                    sodienthoai = selectedRow.Cells["sodienthoai"].Value.ToString(),
                    chucvu = selectedRow.Cells["chucvu"].Value.ToString(),
                    luongcoban = long.Parse(selectedRow.Cells["luongcoban"].Value.ToString()),
                    phongban = selectedRow.Cells["phongban"].Value.ToString(),
                    thoigianbatdauhopdong = DateTime.Parse(selectedRow.Cells["thoigianbatdauhopdong"].Value.ToString()),
                    thoigianketthuchopdong = DateTime.Parse(selectedRow.Cells["thoigianketthuchopdong"].Value.ToString())
                };

                FormAddNewEmployee formAddNewEmployee = new FormAddNewEmployee(this,nhanVien);
                formAddNewEmployee.ShowDialog();
                loadNhanVien(); // Reload lại dữ liệu
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
{
    if (dgvNhanVien.CurrentRow != null)
    {
        int manhanvien = int.Parse(dgvNhanVien.CurrentRow.Cells["manhanvien"].Value.ToString());

        if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            try
            {
                UpdateNhanVienBLL bll = new UpdateNhanVienBLL();
                bll.DeleteNhanVien(manhanvien);
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadNhanVien(); // Reload lại dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    else
    {
        MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadNhanVien();
        }

        private void tínhLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Luong luong = new Luong();
            luong.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe thongKe = new ThongKe();
            thongKe.Show();
        }
    }
}
