using Dapper;
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
    /// <summary>
    /// Lớp cha cho các lớp repository
    /// </summary>
    /// <typeparam name="T">Tên bảng trong database</typeparam>
    /// Created by: PQKHANH(09/09/2022)
    public class BaseRepository<T> : IBaseRepository<T>
    {
        /// <summary>
        /// Khai báo biến
        /// </summary>
        protected string ConnectionString;
        protected MySqlConnection mySqlConnection;
        protected string Table;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="configuration"></param>
        public BaseRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("dataBase");
            Table = typeof(T).Name;
        }

        /// <summary>
        /// Kiểm tra trùng
        /// </summary>
        /// <param name="id">id bản ghi cần kiểm tra</param>
        /// <param name="text">dữ liệu cần kiểm tra</param>
        /// <param name="ColumnName">Cột cần so sánh</param>
        /// <param name="TableName">Bảng chứa cột cần so sánh</param>
        /// <returns>false- nếu không có bản ghi nào trùng, true- nếu có bản ghi bị trùng</returns>
        /// CreatedBy: PQKHANH(09/09/2022)
        public bool CheckDuplicate(Guid? id, string text, string ColumnName, string TableName)
        {
            using(mySqlConnection = new MySqlConnection(ConnectionString))
            {
                var storeProc = $"Proc_CheckDuplicate";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id);
                parameters.Add("Text", text);
                parameters.Add("ColumnName", ColumnName);
                parameters.Add("TableName", TableName);

                var res = mySqlConnection.QueryFirstOrDefault(sql: storeProc, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                
                if(res == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Xóa dữ liệu bản ghi
        /// </summary>
        /// <param name="id">id bản ghi cần xóa</param>
        /// <returns>Thành công - trả về id của bản ghi vừa xóa, không thành công - trả về Guid.Empty<</returns>
        /// Created by: PQKHANH(09/09/2022)
        public virtual Guid Delete(Guid id)
        {
            using (mySqlConnection = new MySqlConnection(ConnectionString))
            {
                if (mySqlConnection.State != ConnectionState.Open)
                {
                    mySqlConnection.Open();
                }

                using (var transaction = mySqlConnection.BeginTransaction())
                {
                    try
                    {
                        var storeProc = $"Proc_Delete_{Table}";

                        var parameters = new DynamicParameters();
                        parameters.Add("Id", id);

                        var isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);

                        if (isSuccess > 0)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            return Guid.Empty;
                        }
                        return id;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return Guid.Empty;
                    }
                    finally
                    {
                        if (mySqlConnection.State != ConnectionState.Closed)
                        {
                            mySqlConnection.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Trả về tất cả bản ghi</returns>
        /// Created by: PQKHANH(09/09/2022)
        public virtual IEnumerable<T> GetAll()
        {
            using (mySqlConnection = new MySqlConnection(ConnectionString))
            {
                var storeProc = $"Proc_GetAll_{Table}";

                var res = mySqlConnection.Query<T>(sql: storeProc, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return res;
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <param name="id">id bản ghi cần lấy</param>
        /// <returns>Trả về bản ghi tương ứng</returns>
        /// Created by: PQKHANH(09/09/2022)
        public virtual T GetById(Guid id)
        {
            using (mySqlConnection = new MySqlConnection(ConnectionString))
            {
                var storeProc = $"Proc_GetById_{Table}";

                var parameters = new DynamicParameters();
                parameters.Add($"{Table}Id", id);

                var res = mySqlConnection.QueryFirstOrDefault<T>(sql: storeProc, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Thêm bản ghi dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu bản ghi cần thêm</param>
        /// <returns>Trả về số bản ghi đã thêm</returns>
        /// Created by: PQKHANH(09/09/2022)
        public virtual Guid Insert(T entity)
        {
            using (mySqlConnection = new MySqlConnection(ConnectionString))
            {
                if (mySqlConnection.State != ConnectionState.Open)
                {
                    mySqlConnection.Open();
                }

                using (var transaction = mySqlConnection.BeginTransaction())
                {
                    try
                    {
                        var storeProc = $"Proc_Insert_{Table}";
                        Guid newId = Guid.NewGuid();
                        var parameters = new DynamicParameters(entity);
                        parameters.Add($"{Table}Id", newId);

                        var isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);

                        if (isSuccess > 0)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            return Guid.Empty;
                        }
                        return newId;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return Guid.Empty;
                    }
                    finally
                    {
                        if (mySqlConnection.State != ConnectionState.Closed)
                        {
                            mySqlConnection.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sửa bản ghi dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu bản ghi cần sửa bao gồm cả employeeId của bản ghi cần sửa được gửi từ client</param>
        /// <returns>Trả về số bản ghi đã sửa</returns>
        /// Created by: PQKHANH(09/09/2022)
        public virtual Guid Update(T entity, Guid id)
        {
            using (mySqlConnection = new MySqlConnection(ConnectionString))
            {
                if (mySqlConnection.State != ConnectionState.Open)
                {
                    mySqlConnection.Open();
                }

                using (var transaction = mySqlConnection.BeginTransaction())
                {
                    try
                    {
                        var storeProc = $"Proc_Update_{Table}";
                        var parameters = new DynamicParameters(entity);
                        parameters.Add($"{Table}Id", id);

                        var isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);

                        if (isSuccess > 0)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            return Guid.Empty;
                        }
                        return id;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return Guid.Empty;
                    }
                    finally
                    {
                        if (mySqlConnection.State != ConnectionState.Closed)
                        {
                            mySqlConnection.Close();
                        }
                    }
                }
            }
        }
    }
}
