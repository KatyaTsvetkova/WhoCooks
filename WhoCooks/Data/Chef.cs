namespace WhoCooks.Data
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class Chef : IdentityUser
    { 
        [Required] 
        public string Name { get; set; }
         
        [Required]
        public string UserId { get; set; }

        public IEnumerable<Recipe> Recipes { get; init; } 
    }
}
