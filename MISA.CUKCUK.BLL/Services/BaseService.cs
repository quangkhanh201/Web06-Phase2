using MISA.CUKCUK.Common.Resources;
using MISA.CUKCUK.Common.Entities.Others;
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
    /// Base Servicve
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class BaseService<T> : IBaseService<T>
    {
        /// <summary>
        /// Khai báo biến
        /// </summary>
        IBaseRepository<T> _repository;

        /// <summary>
        /// Khởi tạo hàm
        /// </summary>
        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Xóa dữ liệu bản ghi
        /// </summary>
        /// <param name="id">id bản ghi cần xóa</param>
        /// <returns>Thành công - trả về id của bản ghi vừa xóa, không thành công - trả về Guid.Empty<</returns>
        /// Created by: PQKHANH(09/09/2022)
        public RespondObject DeleteService(Guid id)
        {
            var data = _repository.Delete(id);
            if(data == Guid.Empty)
            {
                return new RespondObject(null, false, ErrorCode.DeleteFailed, ResourceVN.ResourceManager.GetString(name: "DeleteFailed"), "");
            }
            return new RespondObject(data, true, ErrorCode.NoError, "", "");
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Trả về tất cả bản ghi</returns>
        /// Created by: PQKHANH(09/09/2022)
        public IEnumerable<T> GetAllService()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <param name="id">id bản ghi cần lấy</param>
        /// <returns>Trả về bản ghi tương ứng</returns>
        /// Created by: PQKHANH(09/09/2022)
        public T GetByIdService(Guid id)
        {
            return _repository.GetById(id);
        }

        /// <summary>
        /// Thêm dữ liệu bản ghi
        /// </summary>
        /// <param name="entity">dữ liệu bản ghi cần thêm</param>
        /// <returns>Thành công - trả về id của bản ghi vừa thêm, không thành công - trả về Guid.Empty</returns>
        /// Created by: PQKHANH(09/09/2022)
        public RespondObject InsertService(T entity)
        {
            if (entity == null)
            {
                return new RespondObject(null, false, ErrorCode.NoInput, ResourceVN.ResourceManager.GetString(name: "NoInput"), "");
            }
            var isValid = Validate(entity);
            if(isValid == ErrorCode.NoError)
            {
                var data = _repository.Insert(entity);
                if(data != Guid.Empty)
                {
                    return new RespondObject(data, true, ErrorCode.NoError, "", "");
                }
            }
            return new RespondObject(null, false, isValid, ResourceVN.ResourceManager.GetString(name: $"{isValid}"), "");
        }

        /// <summary>
        /// Sửa dữ liệu bản ghi
        /// </summary>
        /// <param name="id">id bản ghi cần sửa</param>
        /// <param name="entity">dữ liệu của bản ghi cần sửa</param>
        /// <returns>Thành công - trả về id của bản ghi vừa sửa, không thành công - trả về Guid.Empty<</returns>
        /// Created by: PQKHANH(09/09/2022)
        public RespondObject UpdateService(T entity, Guid id)
        {
            if (entity == null)
            {
                return new RespondObject(null, false, ErrorCode.NoInput, ResourceVN.ResourceManager.GetString(name: "NoInput"), "");
            }
            var isValid = Validate(entity);
            if (isValid == ErrorCode.NoError)
            {
                var data = _repository.Update(entity, id);
                if (data != Guid.Empty)
                {
                    return new RespondObject(data, true, ErrorCode.NoError, "", "");
                }
            }
            return new RespondObject(null, false, isValid, ResourceVN.ResourceManager.GetString(name: $"{isValid}"), "");
        }

        /// <summary>
        /// Validate đầu vào
        /// </summary>
        /// <param name="entity">dữ liệu của bản ghi cần validate</param>
        /// <returns>NoError - nếu không có lỗi, Nếu có lỗi trả về các mã còn lại</returns>
        /// Created by: PQKHANH(09/09/2022)
        public virtual ErrorCode Validate(T entity)
        {
            return ErrorCode.NoError;
        }
    }
}
