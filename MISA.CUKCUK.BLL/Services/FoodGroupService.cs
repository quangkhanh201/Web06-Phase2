using MISA.CUKCUK.Common.Entities;
using MISA.CUKCUK.Common.Enum;
using MISA.CUKCUK.Common.Interfaces.Repositories;
using MISA.CUKCUK.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.BLL.Services
{
    /// <summary>
    /// FoodGroup Servicve
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class FoodGroupService : BaseService<FoodGroup>, IFoodGroupService
    {
        /// <summary>
        /// Khai báo biến
        /// </summary>
        IFoodGroupRepository _repository;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="repository"></param>
        public FoodGroupService(IFoodGroupRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Validate đầu vào
        /// </summary>
        /// <param name="entity">dữ liệu của bản ghi cần validate</param>
        /// <returns>NoError - nếu không có lỗi, Nếu có lỗi trả về các mã còn lại</returns>
        /// Created by: PQKHANH(09/09/2022)
        public override ErrorCode Validate(FoodGroup entity)
        {
            /// Kiểm tra code để trống hay không
            if (string.IsNullOrEmpty(entity.FoodGroupCode))
            {
                return ErrorCode.EmptyFoodGroupCode;
            }
            /// Kiểm tra tên để trống hay không
            if (string.IsNullOrEmpty(entity.FoodGroupName))
            {
                return ErrorCode.EmptyFoodGroupName;
            }
            /// Kiểm tra mã nhóm thực đơn có trùng hay không
            if (_repository.CheckDuplicate(entity.FoodGroupId, entity.FoodGroupCode, "FoodGroupCode", "FoodGroup"))
            {
                return ErrorCode.DuplicateFoodGroupCode;
            }
            return ErrorCode.NoError;
        }
    }
}