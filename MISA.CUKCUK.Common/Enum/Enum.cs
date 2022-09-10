using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Enum
{
    /// <summary>
    /// Enum operator
    /// </summary>
    /// CreatedBy: PQKHANH(08/09/2022)
    public enum Operator
    {
        /// <summary>
        /// Chứa
        /// </summary>
        Contain = 0,

        /// <summary>
        /// Bằng
        /// </summary>
        Equal = 1,

        /// <summary>
        /// Bắt đầu bằng
        /// </summary>
        StartWith = 2,

        /// <summary>
        /// Kết thúc bằng
        /// </summary>
        EndWith = 3,

        /// <summary>
        /// Không chứa
        /// </summary>
        NotContain = 4,

        /// <summary>
        /// Nhỏ hơn
        /// </summary>
        Less = 5,

        /// <summary>
        /// Lớn hơn
        /// </summary>
        Bigger = 6,

        /// <summary>
        /// Nhỏ hơn hoặc bằng
        /// </summary>
        LessOrEqual = 7,

        /// <summary>
        /// Lớn hơn hoặc bằng
        /// </summary>
        BiggerOrEqual = 8
    }

    /// <summary>
    /// Enum kiểu dữ liệu đầu vào
    /// </summary>
    /// CreatedBy: PQKHANH(08/09/2022)
    public enum InputType
    {
        /// <summary>
        /// Dữ liệu text
        /// </summary>
        Text = 0,

        /// <summary>
        /// Dữ liệu số
        /// </summary>
        Number = 1,
    }

    /// <summary>
    /// Enum mã lỗi trả về
    /// </summary>
    /// CreatedBy: PQKHANH(08/09/2022)
    public enum ErrorCode
    {
        /// <summary>
        /// Không có lỗi
        /// </summary>
        NoError = 0,

        /// <summary>
        /// Không có dữ liệu đầu vào
        /// </summary>
        NoInput = 1,

        /// <summary>
        /// Tên món ăn để trống
        /// </summary>
        EmptyFoodName = 2,

        /// <summary>
        /// Mã món ăn để trống
        /// </summary>
        EmptyFoodCode = 3,

        /// <summary>
        /// Đơn vị tính để trống
        /// </summary>
        EmptyFoodUnit = 4,

        /// <summary>
        /// Giá bán để trống
        /// </summary>
        EmptyFoodPrice = 5,

        /// <summary>
        /// Trùng mã món ăn
        /// </summary>
        DuplicateFoodCode = 7,

        /// <summary>
        /// Mã nhóm thực đơn để trống
        /// </summary>
        EmptyFoodGroupCode = 8,

        /// <summary>
        /// Tên nhóm thực đơn để trống
        /// </summary>
        EmptyFoodGroupName = 9,

        /// <summary>
        /// Trùng tên nhóm thực đơn
        /// </summary>
        DuplicateFoodGroupCode = 10,

        /// <summary>
        /// Tên đơn vị để trống
        /// </summary>
        EmptyUnitName = 11,

        /// <summary>
        /// Trùng tên đơn vị
        /// </summary>
        DuplicateUnitName = 12,

        /// <summary>
        /// Tên địa điểm chế biến để trống
        /// </summary>
        EmptyProcessedPlace = 13,

        /// <summary>
        /// Trùng tên địa điểm chế biến
        /// </summary>
        DuplicateProcessedPlace = 14,

        /// <summary>
        /// Tên sở thích phục vụ để trống
        /// </summary>
        EmptyServiceHobby = 15,

        /// <summary>
        /// Trùng sở thích phục vụ
        /// </summary>
        DuplicateServiceHobby = 16,

        /// <summary>
        /// Lỗi server
        /// </summary>
        ServerInternal = 17,

        /// <summary>
        /// Ảnh quá kích thước quy định
        /// </summary>
        Oversize = 18,

        /// <summary>
        /// Xóa thất bại
        /// </summary>
        DeleteFailed = 19,
    }
}
