using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly DbSet<Snack> snacks;
        private readonly DbContext context;

        public SnackManagement(DbContext context)
        {
            this.purchases = context.Set<SnackPurchase>();
            this.snacks = context.Set<Snack>();
            this.context = context;
        }
        public void InsertSnackPurchase(SnackPurchase purchase)
        {
            this.purchases.Add(purchase);
            this.context.SaveChanges();
        }

        public SnackPurchase? GetPurchaseById(Guid TicketId)
        {
            return this.purchases.AsNoTracking()
                .Include("SnackPurchaseItem")
                .Include("SnackPurchaseItem.Snack")
                .FirstOrDefault(x => x.TicketId==TicketId)
                ;
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
