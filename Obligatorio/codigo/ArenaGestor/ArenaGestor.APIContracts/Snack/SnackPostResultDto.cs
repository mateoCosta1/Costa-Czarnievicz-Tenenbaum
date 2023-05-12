using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.APIContracts.Snack
{
    public class SnackPostResultDto
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
        public SnackPostResultDto(Domain.Snack source) 
        {
            Description = source.Description;
            Price = source.Price;
            Id = source.SnackId;
        }
    }
}
