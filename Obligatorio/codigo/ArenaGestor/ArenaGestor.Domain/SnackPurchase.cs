using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.Domain
{
    public class SnackPurchase
    {
        public Guid TicketId { get; set; }
        public ICollection<SnackPurchaseItem> Snacks { get; set; }
        public double TotalPrice { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SnackPurchase other &&
                other.TicketId == TicketId;
        }
    }

    public class SnackPurchaseItem
    {
        public Snack Snack { get; set; }
        public int Amount { get; set; }
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SnackPurchaseItem other &&
                other.Snack.SnackId.Equals(Snack.SnackId) && other.Amount.Equals(Amount);
        }

    }
}
