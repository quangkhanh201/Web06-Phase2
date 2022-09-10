using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CUKCUK.Common.Entities;
using MISA.CUKCUK.Common.Interfaces.Services;

namespace MISA.CUKCUK.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    /// <summary>
    /// FoodGroup Controller
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class FoodGroupsController : BaseController<FoodGroup>
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public FoodGroupsController(IFoodGroupService service) : base(service)
        {
        }
    }
}
