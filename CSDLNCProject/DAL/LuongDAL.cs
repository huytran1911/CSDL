using MongoDB.Driver;
using DTO;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace DAL
{
    public class LuongDAL : DatabaseConnection
    {
        private readonly IMongoCollection<NhanVienDTO> collection;

        public LuongDAL()
        {
            collection = GetNhanVienCollection();
        }

        private static IMongoCollection<NhanVienDTO> GetNhanVienCollection()
        {
            var database = DatabaseConnection.ConnectToMongoService();
            return database.GetCollection<NhanVienDTO>("nhanvien");
        }

        // Lấy danh sách nhân viên chưa nhận lương
        public List<NhanVienDTO> GetNhanVienChuaNhanLuong(DateTime selectedMonth)
        {
            // Tạo khoảng thời gian từ ngày đầu tháng đến ngày cuối tháng
            DateTime startOfMonth = new DateTime(selectedMonth.Year, selectedMonth.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            var filter = Builders<NhanVienDTO>.Filter.Or(
                Builders<NhanVienDTO>.Filter.Eq(nv => nv.thangnhanluong, DateTime.MinValue), // Chưa nhận lương
                Builders<NhanVienDTO>.Filter.Lt(nv => nv.thangnhanluong, startOfMonth)       // Lương cũ hơn tháng hiện tại
            );

            return collection.Find(filter).ToList();
        }



        // Cập nhật lương cho nhân viên
        public void UpdateLuongNhanVien(int manhanvien, long luongNhanDuoc, DateTime thangNhanLuong)
        {
            var filter = Builders<NhanVienDTO>.Filter.Eq(nv => nv.manhanvien, manhanvien);
            var update = Builders<NhanVienDTO>.Update
                .Set(nv => nv.luongnhanduoc, luongNhanDuoc)
                .Set(nv => nv.thangnhanluong, thangNhanLuong);

            collection.UpdateOne(filter, update);
        }
        public bool KiemTraNhanVienDaNhanLuong(int manhanvien, DateTime selectedMonth)
        {
            var filter = Builders<NhanVienDTO>.Filter.And(
                Builders<NhanVienDTO>.Filter.Eq(nv => nv.manhanvien, manhanvien),
                Builders<NhanVienDTO>.Filter.Eq(nv => nv.thangnhanluong.Month, selectedMonth.Month),
                Builders<NhanVienDTO>.Filter.Eq(nv => nv.thangnhanluong.Year, selectedMonth.Year)
            );

            return collection.Find(filter).Any();
        }
        public List<NhanVienDTO> SearchNhanVien(string keyword)
        {
            var filter = Builders<NhanVienDTO>.Filter.Or(
                Builders<NhanVienDTO>.Filter.Regex(nv => nv.hoten, new BsonRegularExpression(keyword, "i")),
                Builders<NhanVienDTO>.Filter.Regex(nv => nv.manhanvien.ToString(), new BsonRegularExpression(keyword))
            );

            return collection.Find(filter).ToList();
        }
        public void UpdateOrInsertLuongNhanVien(int manhanvien, long luongNhanDuoc, DateTime thangNhanLuong)
        {
            var filter = Builders<NhanVienDTO>.Filter.Eq(nv => nv.manhanvien, manhanvien);
            var update = Builders<NhanVienDTO>.Update
                .Set(nv => nv.thangnhanluong, thangNhanLuong)
                .Set(nv => nv.luongnhanduoc, luongNhanDuoc);

            // Cập nhật nếu có dữ liệu; thêm mới nếu không có
            collection.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
        }
    }
}
