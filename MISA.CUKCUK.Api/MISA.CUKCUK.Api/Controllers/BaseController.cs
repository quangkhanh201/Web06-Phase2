using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CUKCUK.Common.Resources;
using MISA.CUKCUK.Common.Entities.Others;
using MISA.CUKCUK.Common.Enum;
using MISA.CUKCUK.Common.Interfaces.Services;
using Newtonsoft.Json;

namespace MISA.CUKCUK.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    /// <summary>
    /// BaseController
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class BaseController<T> : ControllerBase
    {
        /// <summary>
        /// Khai báo biến
        /// </summary>
        IBaseService<T> _service;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Trả về tất cả bản ghi</returns>
        /// Created by: PQKHANH(09/09/2022)
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _service.GetAllService();
                RespondObject res = new(data, true, ErrorCode.NoError, "", "");
                return Ok(JsonConvert.SerializeObject(res, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <param name="id">id bản ghi cần lấy</param>
        /// <returns>Trả về bản ghi tương ứng</returns>
        /// Created by: PQKHANH(09/09/2022)
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _service.GetByIdService(id);
                RespondObject res = new(data, true, ErrorCode.NoError, "", "");
                return Ok(JsonConvert.SerializeObject(res, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Thêm dữ liệu bản ghi
        /// </summary>
        /// <param name="entity">dữ liệu bản ghi cần thêm</param>
        /// <returns>Thành công - trả về id của bản ghi vừa thêm, không thành công - trả về Guid.Empty</returns>
        /// Created by: PQKHANH(09/09/2022)
        [HttpPost]
        public IActionResult Insert(T entity)
        {
            try
            {
                var res = _service.InsertService(entity);
                return Ok(JsonConvert.SerializeObject(res, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
         }

        /// <summary>
        /// Sửa dữ liệu bản ghi
        /// </summary>
        /// <param name="id">id bản ghi cần sửa</param>
        /// <param name="entity">dữ liệu của bản ghi cần sửa</param>
        /// <returns>Thành công - trả về id của bản ghi vừa sửa, không thành công - trả về Guid.Empty<</returns>
        /// Created by: PQKHANH(09/09/2022)
        [HttpPut("{id}")]
        public IActionResult Update(T entity, Guid id)
        {
            try
            {
                var res = _service.UpdateService(entity, id);
                return Ok(JsonConvert.SerializeObject(res, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xóa dữ liệu bản ghi
        /// </summary>
        /// <param name="id">id bản ghi cần xóa</param>
        /// <returns>Thành công - trả về id của bản ghi vừa xóa, không thành công - trả về Guid.Empty<</returns>
        /// Created by: PQKHANH(09/09/2022)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var res = _service.DeleteService(id);
                return Ok(JsonConvert.SerializeObject(res, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xử lý ngoại lệ
        /// </summary>
        /// <param name="ex">ngoại lệ</param>
        /// <returns>Nếu có ngoại lệ sẽ trả về theo đúng định dạng</returns>
        /// Created by: PQKHANH(09/09/2022)
        protected IActionResult HandleException(Exception ex)
        {
            RespondObject res = new RespondObject(null, false, ErrorCode.ServerInternal, ResourceVN.ResourceManager.GetString(name: "ServerInternal"), ex.Message);
            return Ok(JsonConvert.SerializeObject(res, Formatting.Indented));
        }
    }
}
