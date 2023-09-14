using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateServiceAsync(CreateServiceDto createServiceDto);
        void DeleteServiceAsync(int id);
        void UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task<GetByIdServiceDto> GetByIdServiceAsync(int id);
    }
}
