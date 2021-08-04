
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
        public  string Title { get; init; }
        
        [Required]
        public int Difficulty { get; init; }
        [Required]
        public  int Servings { get; init; }
        [Required]
        public double CookTime { get; init; }

        [Required]
        public string Ingredients { get; init; } 

        [Required]
        public DateTime TimeStamp { get; set; }
        [Required]
        public string ImageUrl { get; init; }
        [Required]
        public string Directions { get; init; }
        [Required]
        public int CategoryId { get; init; }

        public Category Category { get; init; }
        public int ChefId { get; init; }
        public Chef Chef { get; init; }
    }
}
