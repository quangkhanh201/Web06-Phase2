using MISA.CUKCUK.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Entities.Others
{
    /// <summary>
    /// Object trả dữ liệu về front end
    /// </summary>
    /// CreatedBy: PQKHANH(08/09/2022)
    public class RespondObject
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="data">Dữ liệu trả về</param>
        /// <param name="success">Trả về thành công hay không</param>
        /// <param name="errorCode">Mã lỗi</param>
        /// <param name="userMsg">Thông báo cho user</param>
        /// <param name="devMsg">Thoong báo cho dev</param>
        public RespondObject(object? data, bool success, ErrorCode? errorCode, string? userMsg, string? devMsg)
        {
            Data = data;
            Success = success;
            ErrorCode = errorCode;
            UserMsg = userMsg;
            DevMsg = devMsg;
        }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object? Data { get; set; }

        /// <summary>
        /// Trả về thành công hay không true-thành công, false-không thành công
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mã lỗi trả về
        /// </summary>
        public ErrorCode? ErrorCode { get; set; }

        /// <summary>
        /// Thông báo cho user
        /// </summary>
        public string? UserMsg { get; set; }

        /// <summary>
        /// Thông báo cho dev
        /// </summary>
        public string? DevMsg { get; set; }
    }
}
