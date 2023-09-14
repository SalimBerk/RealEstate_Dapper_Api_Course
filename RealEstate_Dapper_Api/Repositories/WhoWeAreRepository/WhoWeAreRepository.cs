using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }
        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail (Title,Subtitle,Description1,Description2) values (@title,@subtitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title",createWhoWeAreDetailDto.Title);
            parameters.Add("@Subtitle",createWhoWeAreDetailDto.SubTitle);
            parameters.Add("@Description1", createWhoWeAreDetailDto.Description1);
            parameters.Add("@Description2", createWhoWeAreDetailDto.Description2);
            using (var conn = _context.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var conn = _context.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var conn = _context.CreateConnection())
            {
                var values = await conn.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDto> getByIDWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var conn = _context.CreateConnection())
            {
                var value = await conn.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDto>(query, parameters);
                return value;

            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDto updateWhoWeAreDto)
        {
            string query = "Update WhoWeAreDetail Set Title=@title,Subtitle=@subtitle,Description1=@description1,Description2=@description2 Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDto.Title);
            parameters.Add("@subtitle", updateWhoWeAreDto.SubTitle);
            parameters.Add("@description1",updateWhoWeAreDto.Description1);
            parameters.Add("@description2",updateWhoWeAreDto.Description2);
            parameters.Add("@whoWeAreDetailID", updateWhoWeAreDto.WhoWeAreDetailID);
            using (var conn = _context.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }
        }
    }
}
