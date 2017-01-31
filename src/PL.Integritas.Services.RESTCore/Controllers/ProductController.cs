using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PL.Integritas.Domain.Entities;
using PL.Integritas.Application.Interfaces;
using PL.Integritas.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Integritas.Services.RESTCore.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productAppService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productAppService.GetById(id));
        }
    }
}
