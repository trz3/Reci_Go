using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Models
{
    public class Recipes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PreparationMethod { get; set; }
        public Categories Categories { get; set; }
        public Difficulties Difficulties { get; set; }  
        public DateTime PreparationTime { get; set; }
        public Users Users { get; set; }
        public List<RecipeIngredients> RecipeIngredients { get; set; }
        public bool IsApproved { get; set; }
        
    }
}
