using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Entities
{
    /// <summary>
    /// Thực đơn mán ăn
    /// </summary>
    /// CreatedBy: PQKHANH(29/08/2022)
    public class Food : BaseEntity
    {
        /// <summary>
        /// id thực đơn món ăn
        /// </summary>
        public Guid FoodId { get; set; }

        /// <summary>
        /// mã món ăn
        /// </summary>
        public string? FoodCode { get; set; }

        /// <summary>
        /// tên món ăn
        /// </summary>
        public string? FoodName { get; set; }

        /// <summary>
        /// id đơn vị tính
        /// </summary>
        public Guid? FoodUnitId { get; set; }

        /// <summary>
        /// id nhóm thực đơn
        /// </summary>
        public Guid? FoodGroupId { get; set; }

        /// <summary>
        /// id địa điểm chế biến
        /// </summary>
        public Guid? ProcessedPlaceId { get; set; }

        /// <summary>
        /// tên đơn vị tính
        /// </summary>
        public string? FoodUnitName { get; set; }
        
        /// <summary>
        /// tên nhóm thực dơn
        /// </summary>
        public string? FoodGroupName { get; set; }
        
        /// <summary>
        /// tên địa điểm chế biến
        /// </summary>
        public string? ProcessedPlaceName { get; set; }

        /// <summary>
        /// giá bán
        /// </summary>
        public long? FoodPrice { get; set; }

        /// <summary>
        /// giá vốn
        /// </summary>
        public long? FoodInvest { get; set; }
        
        /// <summary>
        /// mô tả món ăn
        /// </summary>
        public string? Description  { get; set; }

        /// <summary>
        /// hiển thị trên màn hình menu
        /// </summary>
        public int? ShowOnMenu { get; set; }

        /// <summary>
        /// url ảnh đại diện
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// list danh sách các sở thích phục vụ
        /// </summary>
        public List<FoodServiceHobby>? ServiceHobbies { get; set; }
    }
}
