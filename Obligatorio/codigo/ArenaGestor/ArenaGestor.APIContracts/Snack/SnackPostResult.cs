using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts.Snack
{
    public class SnackPostResult
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
        public SnackPostResult() { }
    }
}
