using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts.Snack
{
    public class SnackPostDto
    {
        public string Description { get; set; }
        public int? Price { get; set; }

        public Domain.Snack ToDomain()
        {
            if (Description == null && Price==null)
            {
                throw new ArgumentException("Tiene que ingresar un precio y una descripción para el snack");
            }
            if (Description is null || Description.Length == 0)
            {
                throw new ArgumentException("Tiene que ingresar una descripción para el snack");
            }
            return new Domain.Snack()
            {
                Description = this.Description,
                Price = this.Price ?? throw new ArgumentException("Tiene que ingresar un precio para el snack")
            };
        }
    }
}
