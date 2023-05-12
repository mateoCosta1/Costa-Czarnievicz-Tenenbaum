using ArenaGestor.API.Filters;
using ArenaGestor.APIContracts;
using ArenaGestor.APIContracts.Snack;
using ArenaGestor.BusinessInterface;
using ArenaGestor.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ArenaGestor.API.Controllers
{
    [Route("shopp/snack")]
    [ApiController]
    [ExceptionFilter]
    public class SnackController : ControllerBase, ISnackAppService
    {
        private readonly ISnackService _snackService;
        public SnackController(ISnackService service) 
        {
            _snackService = service;
        }

        [HttpPost]
        public IActionResult PostPurchaseSnacks([FromBody]PurchaseSnacksDto purchase)
        {
            SnackPurchase mappedPurchase = purchase.ToDomain();
            SnackPurchase result = _snackService.PurchaseSnacks(mappedPurchase);
            PurchaseSnacksResponseDto mappedResult = new PurchaseSnacksResponseDto(result);
            return Ok(mappedResult);
        }
    }
}
