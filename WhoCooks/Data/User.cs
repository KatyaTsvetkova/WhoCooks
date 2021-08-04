namespace WhoCooks.Data
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class User:IdentityUser
    {
        [MaxLength(NameMaxLength)]
        public string FullName { get; set; }
    }
}
