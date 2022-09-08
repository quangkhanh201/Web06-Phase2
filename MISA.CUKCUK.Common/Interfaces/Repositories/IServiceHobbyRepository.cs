using MISA.CUKCUK.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Interfaces.Repositories
{
    public interface IServiceHobby : IBaseRepository<ServiceHobby>
    {
        /// <summary>
        /// Đưa ra id các sở thích phục vụ của món ăn
        /// </summary>
        /// <param name="FoodId">id món ăn đang xét</param>
        /// <returns> danh sách các sở thích theo món ăn</returns>
        public IEnumerable<ServiceHobby> GetServiceHobbiesByFoodId(Guid FoodId);

    }
}
