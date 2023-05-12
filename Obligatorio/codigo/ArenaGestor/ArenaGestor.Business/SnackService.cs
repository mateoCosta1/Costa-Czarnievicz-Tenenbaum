using ArenaGestor.BusinessInterface;
using ArenaGestor.DataAccessInterface;
using ArenaGestor.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.Business
{
    public class SnackService : ISnackService
    {
        private ISnackManagement snackPurchaseManager;
        public SnackService(ISnackManagement snackPurchaseManager)
        {
            this.snackPurchaseManager = snackPurchaseManager;
        }

        public SnackPurchase PurchaseSnacks(SnackPurchase purchaseSnack)
        {
            AssertProperFormat(purchaseSnack);
            purchaseSnack.Snacks = CombineDuplicates(purchaseSnack.Snacks);
            purchaseSnack.TotalPrice = CountTotalPrice(purchaseSnack);
            snackPurchaseManager.InsertSnackPurchase(purchaseSnack);
            return purchaseSnack;
        }

        private void AssertProperFormat(SnackPurchase purchaseSnack)
        {
            if (purchaseSnack.Snacks is null || purchaseSnack.Snacks.Count == 0)
            {
                throw new ArgumentException("Tiene que seleccionar al menos un snack");
            }
            foreach(var s in purchaseSnack.Snacks)
            {
                s.Snack = snackPurchaseManager.GetSnack(s.Snack.SnackId) ?? 
                    throw new ArgumentException($"El snack {s.Snack.SnackId} no existe");
                if (s.Amount <= 0)
                {
                    throw new ArgumentException("No se puede comprar una cantidad de snacks menor o igual a 0");
                }
            }
        }

        private double CountTotalPrice(SnackPurchase purchaseSnack)
        {
            double totalPrice = 0;
            foreach(var purchase in purchaseSnack.Snacks)
            {
                totalPrice += purchase.Snack.Price * purchase.Amount;
            }
            return totalPrice;
        }

        private SnackPurchaseItem[] CombineDuplicates(ICollection<SnackPurchaseItem> source)
        {
            List<SnackPurchaseItem> result = new();
            foreach (var snackAmount in source)
            {
                bool added = false;
                for(int i=0; i<result.Count;i++)
                {
                    var anotherSA = result[i];
                    if (snackAmount.Snack.SnackId.Equals(anotherSA.Snack.SnackId))
                    {
                        added = true;
                        anotherSA.Amount += snackAmount.Amount;
                    }
                }
                if (!added)
                {
                    result.Add(snackAmount);
                }
            }
           
            return result.ToArray();
        }

        
    }
}
