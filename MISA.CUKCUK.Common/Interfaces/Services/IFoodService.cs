using MISA.CUKCUK.Common.Entities;
using MISA.CUKCUK.Common.Entities.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Interfaces.Services
{
    /// <summary>
    /// interface cho service food
    /// </summary>
    /// Created by: PQKHANH(29/08/2022)
    public interface IFoodService : IBaseService<Food>
    {
        /// <summary>
        /// Lấy danh sách món ăn theo phân trang, lọc
        /// </summary>
        /// <param name="pageIndex">trang đang xét</param>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <param name="filterObject">object chứa các thuộc tính lọc</param>
        /// <param name="sortBy">sắp xếp theo cột nào</param>
        /// <param name="sortType">sắp xếp theo chiều nào</param>
        /// <returns> trả về danh sách món theo phân trang</returns>
        /// Created by: PQKHANH(29/08/2022)
        public object GetPagingFood(int pageIndex, int pageSize, FilterObject[] filterObject, string sortBy, string sortType);
    }
}
