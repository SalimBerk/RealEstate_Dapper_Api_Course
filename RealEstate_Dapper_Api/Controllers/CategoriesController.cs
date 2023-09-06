using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryAdd(CreateCategoryDto categoryDto)
        {
            _categoryRepository.AddCategoryAsync(categoryDto);
            return Ok("Ekleme İşlemi Başarılı Bir Şekilde Gerçekleşti.");

        }
        [HttpDelete]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            _categoryRepository.DeleteCategoryAsync(id);
            return Ok("Silme İşlemi Başarılı Bir Şekilde Gerçekleşti.");

        }
        [HttpPut]
        public async Task<IActionResult> CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {
            _categoryRepository.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Güncelleme İşlemi Gerçekleşti");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCategory(int id)
        {
           var value=await _categoryRepository.GetByIdCategoryAsync(id);
            return Ok(value);
        }
    }
}
