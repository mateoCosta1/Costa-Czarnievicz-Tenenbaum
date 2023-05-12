using ArenaGestor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts.Snack
{
    public class PurchaseSnacksDto
    {
        public Guid TicketId { get; set; }
        public SnackItemDto[] Snacks { get; set; }

        public SnackPurchase ToDomain()
        {
            SnackPurchase domain = new SnackPurchase();
            domain.TicketId = TicketId;
            domain.Snacks = ConvertToSnackPurchase(Snacks);
            return domain;
        }

        private SnackPurchaseItem[] ConvertToSnackPurchase(SnackItemDto[] source)
        {
            SnackPurchaseItem[] result = new SnackPurchaseItem[source.Length];
            for(int i=0; i< source.Length; i++)
            {
                result[i] = source[i].ToDomain();
            }
            return result;
        }
    }
}
