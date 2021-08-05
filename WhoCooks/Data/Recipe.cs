
using System.Collections.Generic;

namespace WhoCooks.Data
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class Recipe
    {

        public int Id { get; init; }
        [Required]
        public  string Title { get; set; }
        
        [Required]
        public int Difficulty { get; set; }
        [Required]
        public  int Servings { get; set; }
        [Required]
        public double CookTime { get; set; }

        [Required]
        public string Ingredients { get; set; } 

        [Required]
        public DateTime TimeStamp { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Directions { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; init; }
        public int ChefId { get; init; }
        public Chef Chef { get; init; }
    }
}
