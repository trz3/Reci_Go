using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Models
{
    public class Favourites
    {
        public int Id { get; set; }
        public Users Users { get; set; }
        public Recipes Recipes { get; set; }
    }
}
