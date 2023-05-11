using ArenaGestor.APIContracts.Snack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts
{
    public interface ISnackAppService
    {
        IActionResult PostPurchaseSnacks(PurchaseSnacksDto purchase);
    }
}
