using ArenaGestor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.DataAccessInterface
{
    public interface ISnackManagement
    {
        void InsertSnackPurchase(SnackPurchase purchase);
        SnackPurchase? GetPurchaseById(Guid TicketId);
        Snack? GetSnack(int snackId);
        IEnumerable<Snack> GetAllSnacks();
    }
}
