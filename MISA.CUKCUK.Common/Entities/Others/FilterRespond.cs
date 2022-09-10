using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Entities.Others
{
    /// <summary>
    /// Object trả dữ liệu phân trang về front end
    /// </summary>
    /// CreatedBy: PQKHANH(08/09/2022)
    public class FilterRespond
    {
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int TotalRecord { get; set; }
        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Tổng số bản ghi trên trang hiện tại
        /// </summary>
        public int CurrentPageRecords { get; set; }
        /// <summary>
        /// Danh sách các bản ghi hợp lệ
        /// </summary>
        public List<Food> Data { get; set; } = new List<Food>();
    }
}