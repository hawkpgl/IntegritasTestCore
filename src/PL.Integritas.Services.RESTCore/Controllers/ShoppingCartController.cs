using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PL.Integritas.Application.ViewModels;
using PL.Integritas.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Integritas.Services.RESTCore.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartAppService _shoppingCartAppService;

        public ShoppingCartController(IShoppingCartAppService shoppingCartAppService)
        {
            _shoppingCartAppService = shoppingCartAppService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<ShoppingCartItemViewModel> items = _shoppingCartAppService.GetItemsByCartNumber(id);

            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _shoppingCartAppService.AddItemToCart(value.CartNumber, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_shoppingCartAppService.GetAll().Any(x => x.Number == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
