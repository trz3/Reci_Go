using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Models
{
    public class RecipeIngredients
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Recipes Recipes { get; set; }
        public Ingredients Ingredients { get; set; }
        public Measures Measures { get; set; }

    }
}
