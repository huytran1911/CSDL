using DAL;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class LuongBLL
    {
        private LuongDAL luongDAL = new LuongDAL();

        // Lấy danh sách nhân viên chưa nhận lương trong tháng cụ thể
        public List<NhanVienDTO> GetNhanVienChuaNhanLuong(DateTime selectedMonth)
        {
            return luongDAL.GetNhanVienChuaNhanLuong(selectedMonth);
        }

        // Kiểm tra xem nhân viên đã được tính lương trong tháng hay chưa
        public bool KiemTraNhanVienDaNhanLuong(int manhanvien, DateTime selectedMonth)
        {
            return luongDAL.KiemTraNhanVienDaNhanLuong(manhanvien, selectedMonth);
        }


        // Tính lương nhận được cho nhân viên
        public long TinhLuongNhanDuoc(long luongCoBan, long thuong, int soNgayNghi)
        {
            if (luongCoBan < 0 || thuong < 0 || soNgayNghi < 0)
                throw new ArgumentException("Lương cơ bản, thưởng và số ngày nghỉ không được là số âm.");

            return luongCoBan + thuong - (soNgayNghi * 200000);
        }

        // Cập nhật lương nhận được và ngày nhận lương của nhân viên
        public void CapNhatLuongNhanVien(int manhanvien, long luongNhanDuoc, DateTime thangNhanLuong)
        {
            if (manhanvien <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ.");

            if (luongNhanDuoc < 0)
                throw new ArgumentException("Lương nhận được không được là số âm.");

            luongDAL.UpdateLuongNhanVien(manhanvien, luongNhanDuoc, thangNhanLuong);
        }



        public List<NhanVienDTO> SearchNhanVien(string keyword, DateTime selectedMonth)
        {
            // Lấy danh sách nhân viên chưa nhận lương
            var danhSachNhanVienChuaNhanLuong = GetNhanVienChuaNhanLuong(selectedMonth);

            // Lọc danh sách theo từ khóas
            return danhSachNhanVienChuaNhanLuong.FindAll(nv =>
                nv.manhanvien.ToString().Contains(keyword) ||
                nv.hoten.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        public void CapNhatLuong(int manhanvien, long luongNhanDuoc, DateTime thangNhanLuong)
        {
            if (manhanvien <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ.");
            if (luongNhanDuoc < 0)
                throw new ArgumentException("Lương nhận được không được là số âm.");

            luongDAL.UpdateOrInsertLuongNhanVien(manhanvien, luongNhanDuoc, thangNhanLuong);
        }

    }
}
