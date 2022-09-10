using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CUKCUK.Common.Entities;
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
    /// ServiceHobby Repository
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class ServiceHobbyRepository : BaseRepository<ServiceHobby>, IServiceHobbyRepository
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public ServiceHobbyRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Xóa dữ liệu bản ghi sở thích phục vụ
        /// Khi xóa bản ghi sở thích phục vụ đồng thời phải xóa sở thích phục vụ đó tương ứng với các món ăn
        /// </summary>
        /// <param name="id">id bản ghi cần xóa</param>
        /// <returns>Thành công - trả về id của bản ghi vừa xóa, không thành công - trả về Guid.Empty<</returns>
        /// Created by: PQKHANH(09/09/2022)
        public override Guid Delete(Guid id)
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
                        var storeProc = "Proc_Delete_ServiceHobby";

                        var parameters = new DynamicParameters();
                        parameters.Add("Id", id);

                        var isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);

                        if (isSuccess > 0)
                        {
                            storeProc = "Proc_Delete_FoodServiceHobby_ByServiceHobbyId";

                            isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
                            if(isSuccess < 0)
                            {
                                transaction.Rollback();
                                return Guid.Empty;
                            }
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
