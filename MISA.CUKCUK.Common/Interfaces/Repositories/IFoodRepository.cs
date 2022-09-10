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
        /// <param name="whereClause">Câu lệnh điều kiện trong truy vấn sql</param>
        /// <param name="sortBy">sắp xếp theo cột</param>
        /// <param name="sortType">sắp xếp theo chiều nào</param>
        /// <returns> trả về danh sách món theo phân trang</returns>
        /// Created by: PQKHANH(29/08/2022)
        public object GetPaging(int pageIndex, int pageSize, string whereClause, string sortBy, string sortType);

    }
}
