using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class UpdateNhanVienDAL : DatabaseConnection
    {
        private IMongoCollection<NhanVienDTO> collection = GetNhanVienCollection();

        public static IMongoCollection<NhanVienDTO> GetNhanVienCollection()
        {
            var database = DatabaseConnection.ConnectToMongoService();
            return database.GetCollection<NhanVienDTO>("nhanvien");
        }

        public void InsertNhanVien(NhanVienDTO nhanVien)
        {
            collection.InsertOne(nhanVien);
        }

        public void UpdateNhanVien(NhanVienDTO nhanVien)
        {
            var filter = Builders<NhanVienDTO>.Filter.Eq(x => x.manhanvien, nhanVien.manhanvien);
            var update = Builders<NhanVienDTO>.Update
                .Set(x => x.hoten, nhanVien.hoten)
                .Set(x => x.ngaysinh, nhanVien.ngaysinh)
                .Set(x => x.diachi, nhanVien.diachi)
                .Set(x => x.email, nhanVien.email)
                .Set(x => x.gioitinh, nhanVien.gioitinh)
                .Set(x => x.sodienthoai, nhanVien.sodienthoai)
                .Set(x => x.manhanvien, nhanVien.manhanvien)
                .Set(x => x.chucvu, nhanVien.chucvu)
                .Set(x => x.luongcoban, nhanVien.luongcoban)
                .Set(x => x.phongban, nhanVien.phongban)
                .Set(x => x.songaynghi, nhanVien.songaynghi)
                .Set(x => x.thoigianbatdauhopdong, nhanVien.thoigianbatdauhopdong)
                .Set(x => x.thoigianketthuchopdong, nhanVien.thoigianketthuchopdong)
               ;

            collection.UpdateOne(filter, update);
        }
        public void DeleteNhanVien(int manhanvien)
        {
            var collection = GetNhanVienCollection();
            var filter = Builders<NhanVienDTO>.Filter.Eq(x => x.manhanvien, manhanvien);
            collection.DeleteOne(filter);
        }
    }
}