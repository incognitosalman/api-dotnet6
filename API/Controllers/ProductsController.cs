using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Errors;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
            [FromQuery] ProductSpecParams productSpecParams)
        {
            var countSpec = new ProductsWithFiltersForCountSpecification(productSpecParams);
            var totalItems = await _productRepository.CountAsync(countSpec);
            
            var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);
            var products = await _productRepository.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(
                productSpecParams.PageIndex,
                productSpecParams.PageSize,
                totalItems,
                data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepository.GetEntityWithSpec(spec);

            if(product == null) return NotFound(new ApiResponse(StatusCodes.Status404NotFound));
            
            return Ok(_mapper.Map<ProductToReturnDto>(product));
        }
    }
}
