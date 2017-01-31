using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PL.Integritas.Application.Interfaces;
using PL.Integritas.Application.ViewModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Integritas.Services.RESTCore.Controllers
{
    [Route("api/[controller]")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseAppService _purchaseAppService;

        public PurchaseController(IPurchaseAppService purchaseAppService)
        {
            _purchaseAppService = purchaseAppService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<PurchaseViewModel> Get()
        {
            return _purchaseAppService.GetAll();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]PurchaseViewModel purchaseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _purchaseAppService.Add(purchaseViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtRoute(new { id = purchaseViewModel.Id }, purchaseViewModel);
        }
    }
}
