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
    /// FoodUnit Servicve
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class FoodUnitService : BaseService<FoodUnit>, IFoodUnitService
    {
        /// <summary>
        /// Khai báo biến
        /// </summary>
        IFoodUnitRepository _repository;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="repository"></param>
        public FoodUnitService(IFoodUnitRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Validate đầu vào
        /// </summary>
        /// <param name="entity">dữ liệu của bản ghi cần validate</param>
        /// <returns>NoError - nếu không có lỗi, Nếu có lỗi trả về các mã còn lại</returns>
        /// Created by: PQKHANH(09/09/2022)
        public override ErrorCode Validate(FoodUnit entity)
        {
            /// Kiểm tra tên đơn vị có tróng hay không
            if(string.IsNullOrEmpty(entity.FoodUnitName))
            {
                return ErrorCode.EmptyUnitName;
            }
            /// Kiểm tra tên dơn vị có trùng hay không
            if (_repository.CheckDuplicate(entity.FoodUnitId, entity.FoodUnitName, "FoodUnitName", "FoodUnit"))
            {
                return ErrorCode.DuplicateUnitName;
            }
            return ErrorCode.NoError;
        }
    }
}
