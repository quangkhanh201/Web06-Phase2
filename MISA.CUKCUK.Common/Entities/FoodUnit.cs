using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Entities
{
    /// <summary>
    /// Đơn vị tính
    /// </summary>
    /// CreatedBy: PQKHANH(29/08/2022)
    public class FoodUnit : BaseEntity
    {
        /// <summary>
        /// id đơn vị tính
        /// </summary>
        public Guid FoodUnitId { get; set; }

        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        public string? FoodUnitName { get; set; }

        /// <summary>
        /// Mô tả đơn vị tính
        /// </summary>
        public string? Description { get; set; }
    }
}
