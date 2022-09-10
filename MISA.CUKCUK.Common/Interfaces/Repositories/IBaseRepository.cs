using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Interfaces.Repositories
{
    /// <summary>
    /// Class cơ sở của các interface repository
    /// </summary>
    /// <typeparam name="T">tên bản trong database</typeparam>
    /// Created by: PQKHANH(29/08/2022)
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Trả về tất cả bản ghi</returns>
        /// Created by: PQKHANH(29/08/2022)
        public IEnumerable<T> GetAll();

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns>Trả về bản ghi có Id tương ứng</returns>
        /// Created by: PQKHANH(29/08/2022)
        public T GetById(Guid id);

        /// <summary>
        /// Thêm bản ghi dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu bản ghi cần thêm</param>
        /// <returns>Trả về id bản ghi đã thêm</returns>
        /// Created by: PQKHANH(29/08/2022)
        public Guid Insert(T entity);

        /// <summary>
        /// Sửa bản ghi dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu bản ghi cần sửa</param>
        /// <returns>Trả về id bản ghi đã sửa</returns>
        /// Created by: PQKHANH(29/08/2022)
        public Guid Update(T entity, Guid id);

        /// <summary>
        /// Xóa bản ghi dữ liệu
        /// </summary>
        /// <param name="id">Id của bản ghi cần xóa</param>
        /// <returns>Trả về id bản ghi đã xóa</returns>
        /// Created by: PQKHANH(29/08/2022)
        public  Guid Delete(Guid id);

        /// <summary>
        /// Kiểm tra trùng
        /// </summary>
        /// <param name="id">id bản ghi cần kiển tra</param>
        /// <param name="text">bản ghi cần kiểm tra</param>
        /// <param name="ColumnName">Cột cần kiểm tra</param>
        /// <param name="TableName">bảng cần kiểm tra</param>
        /// <returns>true- đã tồn tại, false- chưa tồn tại</returns>
        /// Created by: PQKHANH(29/08/2022)
        public bool CheckDuplicate(Guid? id, string text, string ColumnName, string TableName);
    }
}
