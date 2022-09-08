using Microsoft.Extensions.Configuration;
using MISA.CUKCUK.Common.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        /// <summary>
        /// Khởi tạo variable
        /// </summary>
        protected string connectionString;
        protected MySqlConnection sqlConnection;
        protected string TableName;
        protected List<string> errorList;

        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <exception cref="ErrorException">Gọi đến khi lỗi kết nối database</exception>
        /// Createdby : PQKHANH(11/08/2022)
        public BaseRepository(IConfiguration configuration)
        {
            errorList = new List<string>();
            // Khai báo thông tin kết nối
            connectionString = configuration.GetConnectionString("dataBase");
            // Khai báo tên bảng
            TableName = typeof(T).Name;
            sqlConnection = new MySqlConnection(connectionString);
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            

        }

        /// <summary>
        /// Giải phóng bộ nhớ
        /// </summary>
        /// Createdby : PQKHANH(11/08/2022)
        public void Dispose()
        {
            sqlConnection.Dispose();
            sqlConnection.Close();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity, Guid id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
