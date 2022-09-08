using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Entities
{
    /// <summary>
    /// Nhóm thực đơn
    /// </summary>
    /// CreatedBy: PQKHANH(29/08/2022)
    public class FoodGroup : BaseEntity
    {
        /// <summary>
        /// id nhóm thực đơn
        /// </summary>
        public Guid FoodGroupId { get; set; }

        /// <summary>
        /// mã nhóm thực đơn
        /// </summary>
        public string? FoodGroupCode { get; set; }

        /// <summary>
        /// tên nhóm thực đơn
        /// </summary>
        public string? FoodGroupName { get; set; }

        /// <summary>
        /// mô tả nhóm thực đơn
        /// </summary>
        public string? Description { get; set; }
    }
}
