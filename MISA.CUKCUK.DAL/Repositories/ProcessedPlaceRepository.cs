using Microsoft.Extensions.Configuration;
using MISA.CUKCUK.Common.Entities;
using MISA.CUKCUK.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.DAL.Repositories
{
    /// <summary>
    /// ProcessedPlace Repository
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class ProcessedPlaceRepository : BaseRepository<ProcessedPlace>, IProcessedPlaceRepository
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public ProcessedPlaceRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
