﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CentFuxx.Products.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace CentFuxx.Products.Api.Products
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(ProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<Product>>(products));
        }

        [HttpGet]
        [Route("{id:long}", Name = nameof(GetProduct))]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = await _repository.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            return  Ok(_mapper.Map<Product>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var productEntity = _mapper.Map<Domain.Products.Product>(product);
            productEntity = await _repository.Add(productEntity);

            return CreatedAtAction(nameof(GetProduct), 
                new { id = productEntity.Id}, 
                _mapper.Map<Product>(productEntity));
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<ActionResult<Product>> Update(long id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product missing");
            }

            if (product.Id != id)
            {
                return Conflict("Id mismatch");
            }

            var updatedProduct = await _repository.Update(_mapper.Map<Domain.Products.Product>(product));
            return Ok(_mapper.Map<Product>(updatedProduct));
        }
    }
}
