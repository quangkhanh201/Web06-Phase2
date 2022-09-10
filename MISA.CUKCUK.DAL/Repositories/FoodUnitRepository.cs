using Microsoft.Extensions.Configuration;
using MISA.CUKCUK.Common.Entities;
using MISA.CUKCUK.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.DAL.Repositories
{
    /// <summary>
    /// FoodUnit Repository
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class FoodUnitRepository : BaseRepository<FoodUnit>, IFoodUnitRepository
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public FoodUnitRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
