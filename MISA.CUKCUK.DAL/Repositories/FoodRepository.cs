using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CUKCUK.Common.Entities;
using MISA.CUKCUK.Common.Entities.Others;
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
    /// Food Repository
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public FoodRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Lọc, tìm kiếm món ăn theo phân trang
        /// </summary>
        /// <param name="pageIndex">trang hiện tại</param>
        /// <param name="pageSize">só bản ghi trên 1 trang</param>
        /// <param name="whereClause">câu lệnh sql truy vấn</param>
        /// <param name="sortBy">sắp xếp theo cột nào</param>
        /// <param name="sortType">sắp xếp theo chiều nào</param>
        /// <returns>trả về dữ liệu theo yêu cầu, tổng số trang, ....</returns>
        /// Created by: PQKHANH(09/09/2022)
        public object GetPaging(int pageIndex, int pageSize, string whereClause, string sortBy, string sortType)
        {
            using (mySqlConnection = new MySqlConnection(ConnectionString))
            {
                var storeProc = "Proc_GetPagingFood";

                var parameters = new DynamicParameters();
                parameters.Add("pageIndex", pageIndex);
                parameters.Add("pageSize", pageSize);
                parameters.Add("whereClause", whereClause);
                parameters.Add("sortBy", sortBy);
                parameters.Add("sortType", sortType);

                var res = mySqlConnection.QueryMultiple(sql: storeProc, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                var data = new FilterRespond();

                data.CurrentPage = pageIndex;
                data.CurrentPageRecords = pageSize;

                /// lấy dữ liệu các bản ghi
                data.Data = (List<Food>)res.Read<Food>();
                
                /// Lấy tổng số bản ghi
                data.TotalRecord = (int)res.Read<long>().Single();
                
                /// lấy tổng số trang
                if (data.TotalRecord % pageSize == 0)
                {
                    data.TotalPage = data.TotalRecord / pageSize;
                }
                else
                {
                    data.TotalPage = 1 + (data.TotalRecord / pageSize);
                }
                return data;
            }
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// Lấy dữ liệu món ăn kèm theo các sở thích phục vụ
        /// </summary>
        /// <returns>Trả về tất cả bản ghi</returns>
        /// Created by: PQKHANH(09/09/2022)
        public override IEnumerable<Food> GetAll()
        {
            using (mySqlConnection = new MySqlConnection(ConnectionString))
            {
                var storeProc = "Proc_GetAll_Food";

                var res = mySqlConnection.Query<Food>(sql: storeProc, commandType: CommandType.StoredProcedure).ToList();
                foreach(Food food in res)
                {
                    storeProc = "Proc_GetByFoodId_ServiceHobby";
                    var parameters = new DynamicParameters();
                    parameters.Add("FoodId", food.FoodId);

                    food.ServiceHobbies = mySqlConnection.Query<FoodServiceHobby>(sql: storeProc, param: parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                return res;
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// Lấy dữ liệu món ăn kèm theo các sở thích phục vụ
        /// </summary>
        /// <param name="id">id bản ghi cần lấy</param>
        /// <returns>Trả về bản ghi tương ứng</returns>
        /// Created by: PQKHANH(09/09/2022)
        public override Food GetById(Guid id)
        {
            using (mySqlConnection = new MySqlConnection(ConnectionString))
            {
                var storeProc = "Proc_GetById_Food";

                var parameters = new DynamicParameters();
                parameters.Add("FoodId", id);

                var res = mySqlConnection.QueryFirstOrDefault<Food>(sql: storeProc, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                storeProc = "Proc_GetByFoodId_ServiceHobby";
                parameters = new DynamicParameters();
                parameters.Add("FoodId", res.FoodId);

                res.ServiceHobbies = mySqlConnection.Query<FoodServiceHobby>(sql: storeProc, param: parameters, commandType: CommandType.StoredProcedure).ToList();
                return res;
            }
        }

        /// <summary>
        /// Xóa dữ liệu bản ghi
        /// Xóa dữ liệu món ăn, đòng thời thêm tất cả các sở thích phục vụ tương ứng
        /// Tất cả diễn ra trong 1 transaction
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
                        var storeProc = "Proc_Delete_FoodServiceHobby_ByFoodId";

                        var parameters = new DynamicParameters();
                        parameters.Add("Id", id);

                        var isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);

                        if (isSuccess > 0)
                        {
                            
                            storeProc = "Proc_Delete_Food";

                            isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
                            if (isSuccess < 0)
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

        /// <summary>
        /// Thêm dữ liệu bản ghi
        /// Thêm dữ liệu món ăn, đòng thời thêm tất cả các sở thích phục vụ tương ứng
        /// Tất cả diễn ra trong 1 transaction
        /// </summary>
        /// <param name="entity">dữ liệu bản ghi cần thêm</param>
        /// <returns>Thành công - trả về id của bản ghi vừa thêm, không thành công - trả về Guid.Empty</returns>
        /// Created by: PQKHANH(09/09/2022)
        public override Guid Insert(Food entity)
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
                        var storeProc = "Proc_Insert_Food";

                        Guid newId = Guid.NewGuid();
                        var parameters = new DynamicParameters(entity);
                        parameters.Add("FoodId", newId);

                        var serviceHobbies = entity.ServiceHobbies;
                        entity.ServiceHobbies = null;

                        var isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);

                        if (isSuccess > 0)
                        {
                            if(serviceHobbies != null)
                            {
                                storeProc = "Proc_Insert_FoodServiceHobby";

                                foreach(var foodServiceHobby in serviceHobbies)
                                {
                                    parameters = new DynamicParameters();
                                    parameters.Add("FoodId", newId);
                                    parameters.Add("ServiceHobbyId", foodServiceHobby.ServiceHobbyId);

                                    isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
                                    if(isSuccess < 0)
                                    {
                                        transaction.Rollback();
                                        return Guid.Empty;
                                    }
                                }
                            }
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
        /// Sửa dữ liệu bản ghi
        /// Sửa dữ liệu món ăn, đòng thời thêm tất cả các sở thích phục vụ tương ứng
        /// Tất cả diễn ra trong 1 transaction
        /// </summary>
        /// <param name="id">id bản ghi cần sửa</param>
        /// <param name="entity">dữ liệu của bản ghi cần sửa</param>
        /// <returns>Thành công - trả về id của bản ghi vừa sửa, không thành công - trả về Guid.Empty<</returns>
        /// Created by: PQKHANH(09/09/2022)
        public override Guid Update(Food entity, Guid id)
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
                        var storeProc = "Proc_Update_Food";
                        var parameters = new DynamicParameters(entity);
                        parameters.Add("FoodId", id);

                        var serviceHobbies = entity.ServiceHobbies;
                        entity.ServiceHobbies = null;

                        var isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);

                        if (isSuccess > 0)
                        {
                            if (serviceHobbies != null)
                            {
                                foreach (var foodServiceHobby in serviceHobbies)
                                {
                                    storeProc = "Proc_Delete_FoodServiceHobby_ByFoodId";
                                    parameters = new DynamicParameters();
                                    parameters.Add("Id", id);

                                    isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
                                    if (isSuccess < 0)
                                    {
                                        transaction.Rollback();
                                        return Guid.Empty;
                                    }
                                }

                                foreach(var foodServiceHobby in serviceHobbies)
                                {
                                    storeProc = "Proc_Insert_FoodServiceHobby";
                                    parameters = new DynamicParameters();
                                    parameters.Add("FoodId", id);
                                    parameters.Add("ServiceHobbyId", foodServiceHobby.ServiceHobbyId);

                                    isSuccess = mySqlConnection.Execute(sql: storeProc, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
                                    if (isSuccess < 0)
                                    {
                                        transaction.Rollback();
                                        return Guid.Empty;
                                    }
                                }
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
