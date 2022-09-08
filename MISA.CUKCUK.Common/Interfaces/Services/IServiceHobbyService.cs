using MISA.CUKCUK.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Interfaces.Services
{
    /// <summary>
    /// interface cho service service hobby
    /// </summary>
    /// Created by: PQKHANH(29/08/2022)
    public interface IServiceHobbyService : IBaseService<ServiceHobby>
    {
        /// <summary>
        /// Đưa ra id các sở thích phục vụ của món ăn
        /// </summary>
        /// <param name="FoodId">id món ăn đang xét</param>
        /// <returns> danh sách các sở thích theo món ăn</returns>
        public IEnumerable<ServiceHobby> GetServiceHobbiesByFoodIdService(Guid FoodId);
    }
}
