using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Entities
{
    /// <summary>
    /// sở thích phục vụ với từng món ăn
    /// </summary>
    /// CreatedBy: PQKHANH(29/08/2022)
    public class FoodServiceHobby
    {
        /// <summary>
        /// id món ăn trong thực đơn
        /// </summary>
        public Guid? FoodId { get; set; }

        /// <summary>
        /// id sở thích
        /// </summary>
        public Guid? ServiceHobbyId { get; set; }
    }
}
