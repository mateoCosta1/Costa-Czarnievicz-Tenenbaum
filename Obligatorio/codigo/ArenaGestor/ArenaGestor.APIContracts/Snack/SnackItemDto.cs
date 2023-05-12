using ArenaGestor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts.Snack
{
    public class SnackItemDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public SnackPurchaseItem ToDomain()
        {
            return new SnackPurchaseItem
            {
                Snack = new Domain.Snack() { SnackId = Id}
                ,Amount = Amount
            };
        }
    }
}
