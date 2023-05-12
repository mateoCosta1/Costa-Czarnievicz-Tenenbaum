using ArenaGestor.API.Filters;
using ArenaGestor.APIContracts;
using ArenaGestor.APIContracts.Snack;
using ArenaGestor.BusinessInterface;
using ArenaGestor.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace ArenaGestor.API.Controllers
{
    
    [ApiController]
    [ExceptionFilter]
    public class SnackController : ControllerBase, ISnackAppService
    {
        private readonly ISnackService _snackService;
        public SnackController(ISnackService service) 
        {
            _snackService = service;
        }

        [HttpGet]
        [Route("snack")]
        public IActionResult GetAllSnacks()
        {
            ICollection<Snack> result = _snackService.GetAllSnacks();
            List<SnackGetDto> resultDto = new List<SnackGetDto>();
            foreach (var snack in result)
            {
                resultDto.Add(new SnackGetDto(snack));
            }
            return Ok(resultDto);
        }

        [HttpPost]
        [Route("shopp/snack")]
        public IActionResult PostPurchaseSnacks([FromBody]PurchaseSnacksDto purchase)
        {
            SnackPurchase mappedPurchase = purchase.ToDomain();
            SnackPurchase result = _snackService.PurchaseSnacks(mappedPurchase);
            PurchaseSnacksResponseDto mappedResult = new PurchaseSnacksResponseDto(result);
            return Ok(mappedResult);
        }
    }
}
