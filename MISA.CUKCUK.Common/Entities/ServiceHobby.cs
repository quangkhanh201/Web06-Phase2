using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Entities
{
    /// <summary>
    /// Sở thích phục vụ
    /// </summary>
    /// CreatedBy: PQKHANH(29/08/2022)
    public class ServiceHobby : BaseEntity
    {
        /// <summary>
        /// id sở thích phục vụ
        /// </summary>
        public Guid ServiceHobbyId { get; set; }

        /// <summary>
        /// Tên sở thích phục vụ
        /// </summary>
        public string? ServiceHobbyName { get; set; }

        /// <summary>
        /// Phí phục vụ
        /// </summary>
        public long? Fee { get; set; }
    }
}
