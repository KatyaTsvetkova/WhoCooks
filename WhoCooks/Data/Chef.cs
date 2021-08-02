namespace WhoCooks.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class Chef
    {
        public int Id { get; init; }

        [Required] 
        public string Name { get; set; }

        [Required] 
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<Recipe> Recipes { get; init; } = new List<Recipe>();
    }
}
