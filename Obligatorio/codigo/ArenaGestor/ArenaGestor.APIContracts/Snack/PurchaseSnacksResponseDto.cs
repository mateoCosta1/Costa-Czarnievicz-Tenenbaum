using ArenaGestor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts.Snack
{
    public class PurchaseSnacksResponseDto
    {
        public PurchaseSnacksResponseDto(SnackPurchase source)
        {
            TicketId = source.TicketId;
            TotalPrice = source.TotalPrice;
            Snacks = TransformSnacks(source.Snacks);
        }

        private SnackPurchaseResponseDto[] TransformSnacks(ICollection<SnackPurchaseItem> source)
        {
            SnackPurchaseResponseDto[] res = new SnackPurchaseResponseDto[source.Count];
            int i = 0;
            foreach(var item in source)
            {
                res[i] = new SnackPurchaseResponseDto(item);
                i++;
            }
            return res;
        }

        public Guid TicketId { get; set; }
        public SnackPurchaseResponseDto[] Snacks { get; set; }
        public double TotalPrice { get; set; }
    }
}
