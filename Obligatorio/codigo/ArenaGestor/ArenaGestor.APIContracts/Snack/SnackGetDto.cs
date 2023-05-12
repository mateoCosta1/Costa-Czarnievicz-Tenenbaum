using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts.Snack
{
    public class SnackGetDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        public SnackGetDto(ArenaGestor.Domain.Snack source)
        {
            Id = source.SnackId;
            Description = source.Description;
            Price = source.Price;
        }

        public override bool Equals(object obj)
        {
            return obj is SnackGetDto other && other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id + Description.GetHashCode() + Price.GetHashCode();
        }
    }
}
