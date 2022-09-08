using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Interfaces.Services
{
    /// <summary>
    /// Class cơ sở của các interface service
    /// </summary>
    /// <typeparam name="T">tên bản trong database</typeparam>
    /// Created by: PQKHANH(29/08/2022)
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Trả về tất cả bản ghi</returns>
        /// Created by: PQKHANH(29/08/2022)
        public IEnumerable<T> GetAllService();

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns>Trả về bản ghi có Id tương ứng</returns>
        /// Created by: PQKHANH(29/08/2022)
        public T GetByIdService(Guid id);

        /// <summary>
        /// Thêm bản ghi dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu bản ghi cần thêm</param>
        /// <returns>Trả về số bản ghi đã thêm</returns>
        /// Created by: PQKHANH(29/08/2022)
        public int InsertService(T entity);

        /// <summary>
        /// Sửa bản ghi dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu bản ghi cần sửa</param>
        /// <param name="id">id bản ghi cần sửa</param>
        /// <returns>Trả về số bản ghi đã sửa</returns>
        /// Created by: PQKHANH(29/08/2022)
        public int UpdateService(T entity, Guid id);

        /// <summary>
        /// Xóa bản ghi dữ liệu
        /// </summary>
        /// <param name="id">Id của bản ghi cần xóa</param>
        /// <returns>Trả về số bản ghi đã xóa</returns>
        /// Created by: PQKHANH(29/08/2022)
        public int DeleteService(Guid id);
    }
}
