﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CUKCUK.Common.Entities;
using MISA.CUKCUK.Common.Interfaces.Services;

namespace MISA.CUKCUK.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    /// <summary>
    /// FoodUnit Controller
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class FoodUnitsController : BaseController<FoodUnit>
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public FoodUnitsController(IFoodUnitService service) : base(service)
        {
        }
    }
}
