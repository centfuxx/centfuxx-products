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
    }
}
