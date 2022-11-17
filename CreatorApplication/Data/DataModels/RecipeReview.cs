using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.Data.DataModels
{
    public class RecipeReview
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }

    }
}
