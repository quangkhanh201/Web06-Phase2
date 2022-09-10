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
    /// ProcesedPlace Servicve
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class ProcessedPlaceService : BaseService<ProcessedPlace>, IProcessedPlaceService
    {
        /// <summary>
        /// Khai báo biến
        /// </summary>
        IProcessedPlaceRepository _repository;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="repository"></param>
        public ProcessedPlaceService(IProcessedPlaceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Validate đầu vào
        /// </summary>
        /// <param name="entity">dữ liệu của bản ghi cần validate</param>
        /// <returns>NoError - nếu không có lỗi, Nếu có lỗi trả về các mã còn lại</returns>
        /// Created by: PQKHANH(09/09/2022)
        public override ErrorCode Validate(ProcessedPlace entity)
        {
            /// Kiểm tra địa điẻm chế biến có để trống không
            if (string.IsNullOrEmpty(entity.ProcessedPlaceName))
            {
                return ErrorCode.EmptyProcessedPlace;
            }
            /// Kiểm tra tên địa điểm có trùng hay không
            if (_repository.CheckDuplicate(entity.ProcessedPlaceId, entity.ProcessedPlaceName, "ProcessedPlaceName", "ProcessedPlace"))
            {
                return ErrorCode.DuplicateProcessedPlace;
            }
            return ErrorCode.NoError;
        }
    }
}
