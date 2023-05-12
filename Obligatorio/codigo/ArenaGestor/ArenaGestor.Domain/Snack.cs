using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.Domain
{
    public class Snack
    {
        public int SnackId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public Snack() { }
        public override bool Equals(object obj)
        {
            return obj is Snack other &&
                other.SnackId==SnackId && other.Price==Price 
                && other.Description.Equals(Description);
        }
        public override int GetHashCode()
        {
            return SnackId + Price + Description.GetHashCode();
        }
    }
}
