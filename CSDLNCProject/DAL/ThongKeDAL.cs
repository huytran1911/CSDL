using MongoDB.Driver;
using DTO;
using System.Collections.Generic;
using System;

namespace DAL
{
    public class ThongKeDAL : DatabaseConnection
    {
        private readonly IMongoCollection<NhanVienDTO> collection;

        public ThongKeDAL()
        {
            collection = GetNhanVienCollection();
        }

        private static IMongoCollection<NhanVienDTO> GetNhanVienCollection()
        {
            var database = DatabaseConnection.ConnectToMongoService();
            return database.GetCollection<NhanVienDTO>("nhanvien");
        }

        // Đổi tên hàm để lấy toàn bộ nhân viên
        public List<NhanVienDTO> GetThongKeNhanVien()
        {
            try
            {
                return collection.Find(nv => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi truy xuất MongoDB: {ex.Message}");
                return new List<NhanVienDTO>();
            }
        }
    }
}
