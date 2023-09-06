
using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void AddCategoryAsync(CreateCategoryDto createCategoryDto)
        { 
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            parameters.Add("@categoryStatus", createCategoryDto.CategoryStatus);
            using(var conn=_context.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategoryAsync(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using(var conn=_context.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using (var conn = _context.CreateConnection())
            {
                var values = await conn.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            string query = "Select * From Category Where CategoryID=@categoryId";
            var parameters= new DynamicParameters();
            parameters.Add("@categoryId", id);
            using (var conn = _context.CreateConnection())
            {
                var value=await conn.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return value;

            }
        }

        public async void UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus Where CategoryID=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName",updateCategoryDto.CategoryName);
            parameters.Add("@categoryStatus",updateCategoryDto.CategoryStatus);
            parameters.Add("@categoryId", updateCategoryDto.CategoryID);
            using (var conn = _context.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }

        }
    }
}
