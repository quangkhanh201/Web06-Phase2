using Microsoft.AspNetCore.Http;
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
        /// <param name="pageIndex">Số trang</param>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <param name="filterObjects">Mảng chứa các dữ liệu lọc</param>
        /// <param name="sortBy">Sắp xếp theo cột nào</param>
        /// <param name="sortType">Sắp xếp theo chiều nào</param>
        /// <returns> trả về danh sách món theo phân trang</returns>
        /// Created by: PQKHANH(29/08/2022)
        public object ServiceGetPaging(int pageIndex, int pageSize, FilterObject[] filterObjects, string? sortBy, string? sortType);


        /// <summary>
        /// Tự động sinh mã
        /// </summary>
        /// <param name="name">dữ liệu đầu vào</param>
        /// <returns>trả về mã code</returns>
        public RespondObject GenNewCode(string name);

        /// <summary>
        /// Service Upload ảnh
        /// </summary>
        /// <param name="image"> ảnh</param>
        /// <param name="id"> id bả ghi với anh tương ứng</param>
        /// <returns>trả về link ảnh cho front end</returns>
        public Task<RespondObject> UploadImageService(IFormFile image, Guid id);
    }
}
