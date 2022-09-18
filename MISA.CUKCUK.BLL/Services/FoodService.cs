using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MISA.CUKCUK.Common.Entities;
using MISA.CUKCUK.Common.Entities.Others;
using MISA.CUKCUK.Common.Enum;
using MISA.CUKCUK.Common.Interfaces.Repositories;
using MISA.CUKCUK.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.CUKCUK.BLL.Services
{
    /// <summary>
    /// Food Servicve
    /// </summary>
    /// Created by: PQKHANH(09/09/2022)
    public class FoodService : BaseService<Food>, IFoodService
    {
        /// <summary>
        /// Khai báo biến
        /// </summary>
        IFoodRepository _repository;
        IConfiguration _configuration;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="configuration"></param>
        public FoodService(IFoodRepository repository, IConfiguration configuration) : base(repository)
        {
            _repository = repository;
            _configuration = configuration;
        }

        /// <summary>
        /// Tạo mã món ăn mới
        /// </summary>
        /// <param name="name">chuỗi đầu vào</param>
        /// <returns> trả về Chuỗi in hoa viết liền, tối đa 25 ký tự</returns>
        /// Created by: PQKHANH(09/09/2022)
        public RespondObject GenNewCode(string name)
        {
            /// tách khoảng trắng
            var newCode = name.Replace(" ", string.Empty);
            newCode = newCode.ToLower();
            /// loại bỏ ký tự tiếng việt
            newCode = Regex.Replace(newCode, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            newCode = Regex.Replace(newCode, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
            newCode = Regex.Replace(newCode, "ì|í|ị|ỉ|ĩ|/g", "i");
            newCode = Regex.Replace(newCode, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
            newCode = Regex.Replace(newCode, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            newCode = Regex.Replace(newCode, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            newCode = Regex.Replace(newCode, "đ", "d");
            newCode = newCode.ToUpper();
            /// Mã tối đa 25 ký tự
            if(newCode.Length > 25)
            {
                newCode = newCode.Substring(0,25);        
            }

            return new RespondObject(newCode, true, ErrorCode.NoError, "", "");

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
        public object ServiceGetPaging(int pageIndex, int pageSize, FilterObject[] filterObjects, string? sortBy, string? sortType)
        {
            if(string.IsNullOrEmpty(pageIndex.ToString()) || pageIndex <= 0) {
                pageIndex = 1;
            }
            if (string.IsNullOrEmpty(pageSize.ToString()) || pageSize <= 0)
            {
                pageSize = 25;
            }

            /// Viết câu lệnh where trong sql
            var whereClause = "";
            for(int i = 0; i < filterObjects.Length; i++)
            {
                FilterObject filterObject = filterObjects[i];
                if(filterObject == null || string.IsNullOrEmpty(filterObject.Value) || filterObject.Value == "")
                {
                    continue;
                }
                if(!string.IsNullOrEmpty(whereClause))
                {
                    whereClause += "AND ";
                }
                
                if(filterObject.InputType == InputType.Text)
                {
                    if(filterObject.Operator == Operator.Contain)
                    {
                        whereClause += filterObject.ColumnFilter + " LIKE '%" + filterObject.Value + "%' ";
                    }
                    if(filterObject.Operator == Operator.Equal)
                    {
                        whereClause += filterObject.ColumnFilter + " LIKE '" + filterObject.Value + "' ";
                    }
                    if (filterObject.Operator == Operator.StartWith)
                    {
                        whereClause += filterObject.ColumnFilter + " LIKE '" + filterObject.Value + "%' ";
                    }
                    if (filterObject.Operator == Operator.EndWith)
                    {
                        whereClause += filterObject.ColumnFilter + " LIKE '%" + filterObject.Value + "' ";
                    }
                    if (filterObject.Operator == Operator.NotContain)
                    {
                        whereClause += filterObject.ColumnFilter + " NOT LIKE '%" + filterObject.Value + "%' ";
                    }
                }
                if(filterObject.InputType == InputType.Number)
                {
                    if (filterObject.Operator == Operator.Equal)
                    {
                        whereClause += filterObject.ColumnFilter + " = '" + filterObject.Value + "' ";
                    }
                    if (filterObject.Operator == Operator.Less)
                    {
                        whereClause += filterObject.ColumnFilter + " < '" + filterObject.Value + "' ";
                    }
                    if (filterObject.Operator == Operator.LessOrEqual)
                    {
                        whereClause += filterObject.ColumnFilter + " <= '" + filterObject.Value + "' ";
                    }
                    if (filterObject.Operator == Operator.Bigger)
                    {
                        whereClause += filterObject.ColumnFilter + " > '" + filterObject.Value + "' ";
                    }
                    if (filterObject.Operator == Operator.BiggerOrEqual)
                    {
                        whereClause += filterObject.ColumnFilter + " >= '" + filterObject.Value + "' ";
                    }
                }
            }
            if(filterObjects.Length != 0 && whereClause != "")
            {
                whereClause = "WHERE " + whereClause;
            }

            if(string.IsNullOrEmpty(sortBy))
            {
                sortBy = "CreatedDate";
            }
            if(string.IsNullOrEmpty(sortType))
            {
                sortType = "DESC";
            }
            return _repository.GetPaging(pageIndex, pageSize, whereClause, sortBy, sortType);
        }

        /// <summary>
        /// Xử lý upload ảnh lên backend
        /// </summary>
        /// <param name="code">id của bản ghi ảnh tương ứng</param>
        /// <param name="image">ảnh cần xử lý</param>
        /// <returns>trả về đường dẫn thư mục chứa ảnh</returns>
        /// Created by: PQKHANH(09/09/2022)
        public async Task<RespondObject> UploadImageService(IFormFile image, string code)
        {
            /// Trả về lỗi nếu ảnh lớn hơn 5Mb
            if(image.Length > 5 * 1024 * 1024)
            {
                return new RespondObject(null, false, ErrorCode.Oversize, "", "");
            }

            // Tạp tên file chứa ảnh
            string fileName = code + ".jpg";
            // Lấy đường dẫn tới thư mục chứa ảnh
            var pathFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration["StaticFolder:UploadPath"]);

            if(Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
            }

            /// Lấy đường dẫn trực tiếp đến ảnh
            var path = Path.Combine(pathFolder, fileName);

            /// truyền ảnh vào đường dẫn đã tạo
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            // Lấy đường dẫn ảnh gửi về cho client
            var imagePath = _configuration["StaticFolder:UploadLink"] + fileName;
            return new RespondObject(imagePath, true, ErrorCode.NoError, "", "");
        }

        /// <summary>
        /// Validate đầu vào
        /// </summary>
        /// <param name="entity">dữ liệu của bản ghi cần validate</param>
        /// <returns>NoError - nếu không có lỗi, Nếu có lỗi trả về các mã còn lại</returns>
        /// Created by: PQKHANH(09/09/2022)
        public override ErrorCode Validate(Food entity)
        {
            /// Kiểm tra tên món ăn có trống hay không
            if (string.IsNullOrEmpty(entity.FoodName))
            {
                return ErrorCode.EmptyFoodName;
            }
            /// Kiểm tra mã món ăn có trống hay không
            if (string.IsNullOrEmpty(entity.FoodCode))
            {
                return ErrorCode.EmptyFoodCode;
            }
            /// Kiểm tra đơn vị có trống hay không
            if (entity.FoodUnitId == Guid.Empty)
            {
                return ErrorCode.EmptyFoodUnit;
            }
            /// Kiểm tra giá bán có trống hay không
            if (!entity.FoodPrice.HasValue)
            {
                return ErrorCode.EmptyFoodPrice;
            }
            /// Kiểm tra xem mã món ăn có trùng hay không
            if (_repository.CheckDuplicate(entity.FoodId, entity.FoodCode, "FoodCode", "Food"))
            {
                return ErrorCode.DuplicateFoodCode;
            }
            return ErrorCode.NoError;
        }
    }
}
