using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MongoDB.Driver;

namespace BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();

        public List<NhanVienDTO> GetAllNhanVien()
        {
            var nhanVienEntities = nhanVienDAL.GetAllNhanVien();
            var nhanVienDTOs = nhanVienEntities.Select(nv => new NhanVienDTO
            {
                manhanvien = nv.manhanvien,
                hoten = nv.hoten,
                ngaysinh = nv.ngaysinh,
                diachi = nv.diachi,
                email = nv.email,
                gioitinh = nv.gioitinh,
                sodienthoai = nv.sodienthoai,
                chucvu = nv.chucvu,
                phongban = nv.phongban,
                thoigianbatdauhopdong = nv.thoigianbatdauhopdong,
                thoigianketthuchopdong = nv.thoigianketthuchopdong,
                thangnhanluong = nv.thangnhanluong,
                luongnhanduoc = nv.luongnhanduoc,
                thuong = nv.thuong,
                maphongban = nv.maphongban,
                luongcoban = nv.luongcoban,
                songaynghi = nv.songaynghi,

            }).ToList();

            return nhanVienDTOs;
        }

        public List<NhanVienDTO> SearchNhanVien(string keyword)
        {
            var allNhanVien = nhanVienDAL.GetAllNhanVien();

            var searchResult = allNhanVien
                .Where(nv => nv.manhanvien.ToString().Contains(keyword) ||
                             nv.hoten.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            return searchResult;
        }
    }
}
