using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace DTO
{
    public class NhanVienDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int manhanvien { get; set; }
        public string hoten { get; set; }
        public DateTime ngaysinh { get; set; }
        public string diachi { get; set; }
        public string email { get; set; }
        public string gioitinh { get; set; }
        public string sodienthoai { get; set; }
        public string chucvu { get; set; }
        public long luong { get; set; }  
        public string phongban { get; set; }
        public string trangthai { get; set; }
        public long phucap { get; set; } 
    }
}
