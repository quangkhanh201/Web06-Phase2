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
    /// ServiceHobby Servicve
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class ServiceHobbyService : BaseService<ServiceHobby>, IServiceHobbyService
    {
        /// <summary>
        /// Khai báo biến
        /// </summary>
        IServiceHobbyRepository _repository;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="repository"></param>
        public ServiceHobbyService(IServiceHobbyRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Validate đầu vào
        /// </summary>
        /// <param name="entity">dữ liệu của bản ghi cần validate</param>
        /// <returns>NoError - nếu không có lỗi, Nếu có lỗi trả về các mã còn lại</returns>
        /// Created by: PQKHANH(09/09/2022)
        public override ErrorCode Validate(ServiceHobby entity)
        {
            /// Kiểm tra tên sở thích có để trống hay không
            if (string.IsNullOrEmpty(entity.ServiceHobbyName))
            {
                return ErrorCode.EmptyServiceHobby;
            }
            /// Kiểm tra sở thích có bị trùng hay không
            if (_repository.CheckDuplicate(entity.ServiceHobbyId, entity.ServiceHobbyName, "ServiceHobbyName", "ServiceHobby"))
            {
                return ErrorCode.DuplicateServiceHobby;
            }
            return ErrorCode.NoError;
        }
    }
}
