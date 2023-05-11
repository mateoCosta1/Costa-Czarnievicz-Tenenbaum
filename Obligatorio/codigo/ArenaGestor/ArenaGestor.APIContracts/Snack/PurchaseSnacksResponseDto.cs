using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts.Snack
{
    public class PurchaseSnacksResponseDto
    {
        public Guid ticketId { get; set; }
        public SnackPurchaseResponseDto[] snacks { get; set; }
        public int totalPrice { get; set; }
    }
}
