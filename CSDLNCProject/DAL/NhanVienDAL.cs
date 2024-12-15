using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVienDAL:DatabaseConnection
    {

        public static IMongoCollection<NhanVienDTO> GetNhanVienCollection()
        {
            var database = DatabaseConnection.ConnectToMongoService(); // Kết nối và lấy database
            return database.GetCollection<NhanVienDTO>("nhanvien");  // Lấy collection "nhanvien"
        }
        public List<NhanVienDTO> GetAllNhanVien()
        {
            var collection = GetNhanVienCollection();
            return collection.Find(nv => true).ToList(); // Trả về danh sách nhân viên
        }

        public NhanVienDTO GetNhanVienById(int manhanvien)
        {
            var collection = GetNhanVienCollection();
            return collection.Find(nv => nv.manhanvien == manhanvien).FirstOrDefault();
        }

        public void InsertNhanVien(NhanVienDTO nhanVien)
        {
            var collection = GetNhanVienCollection();
            collection.InsertOne(nhanVien);
        }
    }
}
