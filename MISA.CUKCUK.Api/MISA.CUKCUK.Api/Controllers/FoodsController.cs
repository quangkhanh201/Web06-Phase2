using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CUKCUK.Common.Entities;
using MISA.CUKCUK.Common.Entities.Others;
using MISA.CUKCUK.Common.Enum;
using MISA.CUKCUK.Common.Interfaces.Services;
using MISA.CUKCUK.Common.Resources;
using Newtonsoft.Json;

namespace MISA.CUKCUK.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    /// <summary>
    /// Food Controller
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class FoodsController : BaseController<Food>
    {
        /// <summary>
        /// Khai báo biến
        /// </summary>
        IFoodService _service;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public FoodsController(IFoodService service) : base(service)
        {
            _service = service;
        }

        /// <summary>
        /// Tạo mã món ăn mới
        /// </summary>
        /// <param name="name">chuỗi đầu vào</param>
        /// <returns> trả về Chuỗi in hoa viết liền, tối đa 25 ký tự</returns>
        /// Created by: PQKHANH(09/09/2022)
        [HttpGet("NewCode")]
        public IActionResult GetNewCode(string name)
        {
            try
            {
                RespondObject res = _service.GenNewCode(name);
                return Ok(JsonConvert.SerializeObject(res, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Lọc, tìm kiếm món ăn theo phân trang
        /// </summary>
        /// <param name="pageIndex">trang hiện tại</param>
        /// <param name="pageSize">só bản ghi trên 1 trang</param>
        /// <param name="filterObjects">mảng chứa đầu vào lọc theo các trường</param>
        /// <param name="sortBy">sắp xếp theo cột nào</param>
        /// <param name="sortType">sắp xếp theo chiều nào</param>
        /// <returns>trả về dữ liệu theo yêu cầu, tổng số trang, ....</returns>
        /// Created by: PQKHANH(09/09/2022)
        [HttpPost("Filter")]
        public IActionResult GetFilter(int pageIndex, int pageSize, FilterObject[]? filterObjects, string? sortBy, string? sortType)
        {
            if(filterObjects == null)
            {
                return Ok(JsonConvert.SerializeObject(new RespondObject(null, false, ErrorCode.NoInput, ResourceVN.ResourceManager.GetString(name: "NoInput"), ""), Formatting.Indented));
            }
            try
            {
                var data = _service.ServiceGetPaging(pageIndex, pageSize, filterObjects, sortBy, sortType);
                RespondObject res = new(data, true, ErrorCode.NoError, "", "");
                return Ok(JsonConvert.SerializeObject(res, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xử lý upload ảnh lên backend
        /// </summary>
        /// <param name="code">mã món ăn của bản ghi ảnh tương ứng</param>
        /// <param name="image">ảnh cần xử lý</param>
        /// <returns>trả về đường dẫn thư mục chứa ảnh</returns>
        /// Created by: PQKHANH(09/09/2022)
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile image, string code)
        {
            try
            {
                var res = await _service.UploadImageService(image, code);
                
                return Ok(JsonConvert.SerializeObject(res, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
