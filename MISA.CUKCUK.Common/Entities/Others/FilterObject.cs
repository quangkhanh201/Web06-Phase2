using MISA.CUKCUK.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Entities.Others
{
    /// <summary>
    /// Object đối tượng lọc
    /// </summary>
    /// CreatedBy: PQKHANH(08/09/2022)
    public class FilterObject
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="columnFilter">Cột đang xét</param>
        /// <param name="value">Giá trị lọc</param>
        /// <param name="inputType">Kiểu dữ liẹu đầu vào</param>
        /// <param name="operator">Kiểu lọc</param>
        public FilterObject(string columnFilter, string value, InputType inputType, Operator @operator)
        {
            ColumnFilter = columnFilter;
            Value = value;
            InputType = inputType;
            Operator = @operator;
        }

        /// <summary>
        /// Cột đang xét
        /// </summary>
        public string ColumnFilter { get; set; }

        /// <summary>
        /// Giá trị lọc
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Kiểu dữ liệu đầu vào 0-Text, 1-Number,...
        /// </summary>
        public InputType InputType { get; set; }

        /// <summary>
        /// Kiểu lọc 1- Contain, 2-Equal,....
        /// </summary>
        public Operator Operator { get; set; }
    }
}
