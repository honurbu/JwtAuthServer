using JwtAuthServer.Core.DTOs;
using JwtAuthServer.Core.Models;
using JwtAuthServer.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IServiceGeneric<Product, ProductDto> _serviceGeneric;

        public ProductController(IServiceGeneric<Product, ProductDto> serviceGeneric)
        {
            _serviceGeneric = serviceGeneric;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            return ActionResultInstance(await _serviceGeneric.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDto productDto)
        {
            return ActionResultInstance(await _serviceGeneric.AddAsync(productDto)); ;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto productDto, int id)
        {
            return ActionResultInstance(await _serviceGeneric.Update(productDto, id)); ;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return ActionResultInstance(await _serviceGeneric.Remove(id));
        }
    }
}
