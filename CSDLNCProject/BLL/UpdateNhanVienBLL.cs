using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UpdateNhanVienBLL
    {
        private UpdateNhanVienDAL updateNhanVienDAL = new UpdateNhanVienDAL();

        public void AddNhanVien(NhanVienDTO nhanVien)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(nhanVien.hoten))
                throw new Exception("Họ tên không được để trống.");

            if (nhanVien.luongcoban <= 0)
                throw new Exception("Lương phải lớn hơn 0.");

            if (string.IsNullOrEmpty(nhanVien.email))
                throw new Exception("Email không được để trống.");

            // Gọi DAL để thêm nhân viên
            updateNhanVienDAL.InsertNhanVien(nhanVien);
        }

        public void UpdateNhanVien(NhanVienDTO nhanVien)
        {
            if (string.IsNullOrEmpty(nhanVien.hoten))
                throw new Exception("Họ tên không được để trống.");

            if (nhanVien.luongcoban <= 0)
                throw new Exception("Lương phải lớn hơn 0.");

            updateNhanVienDAL.UpdateNhanVien(nhanVien);
        }
        public void DeleteNhanVien(int manhanvien)
        {
            if (manhanvien <= 0)
                throw new Exception("Mã nhân viên không hợp lệ.");
            updateNhanVienDAL.DeleteNhanVien(manhanvien);
        }
    }
}