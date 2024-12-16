using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class ThongKeBLL
    {
        private ThongKeDAL thongKeDAL = new ThongKeDAL();

        // Hàm gọi từ DAL để lấy thống kê nhân viên
        public List<NhanVienDTO> GetThongKeNhanVien()
        {
            return thongKeDAL.GetThongKeNhanVien();
        }
    }
}
