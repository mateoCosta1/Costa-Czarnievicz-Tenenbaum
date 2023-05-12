using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ArenaGestor.DataAccessInterface;
using ArenaGestor.Domain;
using Microsoft.EntityFrameworkCore;

namespace ArenaGestor.DataAccess.Managements
{
    public class SnackManagement : ISnackManagement
    {
        private readonly DbSet<SnackPurchase> purchases;
        private readonly DbSet<SnackPurchaseItem> purchaseItems;
        private readonly DbSet<Snack> snacks;
        private readonly DbContext context;

        public SnackManagement(DbContext context)
        {
            this.purchases = context.Set<SnackPurchase>();
            this.snacks = context.Set<Snack>();
            this.purchaseItems = context.Set<SnackPurchaseItem>();
            this.context = context;
        }
        public void InsertSnackPurchase(SnackPurchase purchase)
        {
            this.purchases.Add(purchase);
            foreach(var item in purchase.Snacks)
            {
                this.context.Entry(item.Snack).State = EntityState.Unchanged; 
            }
            this.context.SaveChanges();
        }

        public SnackPurchase? GetPurchaseById(Guid TicketId)
        {
            var purchase = this.purchases.Include(x => x.Snacks).AsNoTracking()
                .FirstOrDefault(x => x.TicketId == TicketId);

            if (purchase == null) return null;
            List<SnackPurchaseItem> itemsWithSnacks = new List<SnackPurchaseItem> ();
            foreach(var snackItem in purchase.Snacks)
            {
                var itemWithSnack = this.purchaseItems.Include(x => x.Snack)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == snackItem.Id);
                itemsWithSnacks.Add(itemWithSnack);
            }
            purchase.Snacks = itemsWithSnacks;
            return purchase;
        }

        public Snack? GetSnack(int snackId)
        {
            return this.snacks.AsNoTracking().FirstOrDefault(x => x.SnackId == snackId);
        }

        public IEnumerable<Snack> GetAllSnacks()
        {
            return this.snacks.AsNoTracking();
        }
    }
}
