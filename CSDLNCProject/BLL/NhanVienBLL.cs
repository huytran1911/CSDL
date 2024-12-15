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
                luong = nv.luong,
                phongban = nv.phongban,
                trangthai = nv.trangthai,
                phucap = nv.phucap
            }).ToList();

            return nhanVienDTOs;
        }
    }
}
