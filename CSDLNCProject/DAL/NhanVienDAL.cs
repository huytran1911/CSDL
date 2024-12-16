using MongoDB.Driver;
using DTO;
using System.Collections.Generic;

namespace DAL
{
    public class NhanVienDAL : DatabaseConnection
    {
        private readonly IMongoCollection<NhanVienDTO> collection;

        // Constructor khởi tạo collection
        public NhanVienDAL()
        {
            collection = GetNhanVienCollection();
        }

        private static IMongoCollection<NhanVienDTO> GetNhanVienCollection()
        {
            var database = DatabaseConnection.ConnectToMongoService();
            return database.GetCollection<NhanVienDTO>("nhanvien");
        }

        // Lấy danh sách tất cả nhân viên
        public List<NhanVienDTO> GetAllNhanVien()
        {
            return collection.Find(nv => true).ToList();
        }
    }
}
