using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Entities
{
    /// <summary>
    /// Địa điểm chế biến
    /// </summary>
    /// CreatedBy: PQKHANH(29/08/2022)
    public class ProcessedPlace : BaseEntity
    {
        /// <summary>
        /// id địa điểm
        /// </summary>
        public Guid ProcessedPlaceId { get; set; }

        /// <summary>
        /// Tên địa điểm
        /// </summary>
        public string? ProcessedPlaceName { get; set; }
    }
}
