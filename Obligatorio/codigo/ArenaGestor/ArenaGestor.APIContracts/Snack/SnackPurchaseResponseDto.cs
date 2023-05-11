using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts.Snack
{
    public class SnackPurchaseResponseDto
    {
        public int snackId { get; set; }
        public int amount { get; set; }
        public int priceByUnit { get; set; }
        public int totalSnackCost { get; set; }
    }
}
