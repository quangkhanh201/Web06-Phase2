using MISA.CUKCUK.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Interfaces.Repositories
{
    /// <summary>
    /// interface cho repository Food
    /// </summary>
    /// Created by: PQKHANH(29/08/2022)
    public interface IFoodRepository : IBaseRepository<Food>
    {
        /// <summary>
        /// Lấy danh sách món ăn theo phân trang, lọc
        /// </summary>
        /// <param name="pageIndex">trang đang xét</param>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <param name="where">Câu lệnh điều kiện trong truy vấn sql</param>
        /// <returns> trả về danh sách món theo phân trang</returns>
        /// Created by: PQKHANH(29/08/2022)
        public object GetPagingFood(int pageIndex, int pageSize, string where);

        /// <summary>
        /// Kiểm tra trùng mã món ăn
        /// </summary>
        /// <param name="code">Mã cần kiểm tra trùng</param>
        /// <param name="foodId">id bản ghi chứa mã đang xét</param>
        /// <returns>true- đã tồn tại, false- chưa tồn tại</returns>
        /// Created by: PQKHANH(29/08/2022)
        public bool CheckDuplicateCode(string code, Guid foodId);
    }
}
