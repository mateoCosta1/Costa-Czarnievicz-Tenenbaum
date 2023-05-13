using ArenaGestor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts.Snack
{
    public class SnackPurchaseResponseDto
    {
        public SnackPurchaseResponseDto(SnackPurchaseItem snackPurchaseItem)
        {
            SnackId = snackPurchaseItem.Snack.SnackId;
            Amount = snackPurchaseItem.Amount;
            PriceByUnit = snackPurchaseItem.Snack.Price;
            TotalSnackCost = snackPurchaseItem.Amount * PriceByUnit;
        }

        public int SnackId { get; set; }
        public int Amount { get; set; }
        public int PriceByUnit { get; set; }
        public int TotalSnackCost { get; set; }
    }
}
