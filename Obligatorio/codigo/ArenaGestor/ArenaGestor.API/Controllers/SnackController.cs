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
        private readonly IMapper _mapper;
        public SnackController(ISnackService service, IMapper mapper) 
        {
            _snackService = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostPurchaseSnacks(PurchaseSnacksDto purchase)
        {
            SnackPurchase mappedPurchase = _mapper.Map<SnackPurchase>(purchase);
            SnackPurchase result = _snackService.PurchaseSnacks(mappedPurchase);
            PurchaseSnacksResponseDto mappedResult = _mapper.Map<PurchaseSnacksResponseDto>(result);
            return Ok(mappedResult);
        }
    }
}
