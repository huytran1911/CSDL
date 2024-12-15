using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using DTO;

namespace DAL
{
    public class DatabaseConnection
    {
        // Khai báo client và database để kết nối MongoDB
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }

        // Chuỗi kết nối MongoDB
        public static string MongoConnection = "mongodb+srv://tranhuy19112004:oNwdjxBQ9Xcfzooi@cluster0.vvc3p.mongodb.net/";
        public static string MongoDatabase = "quanlynhanvien";

        // Hàm kết nối tới MongoDB
        public static IMongoDatabase ConnectToMongoService()
        {
            if (client == null)
            {
                client = new MongoClient(MongoConnection);
            }
            if (database == null)
            {
                database = client.GetDatabase("quanlynhanvien"); 
            }
            return database;
        }


    }
}
