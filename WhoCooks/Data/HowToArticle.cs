namespace WhoCooks.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using static DataConstants;
    public class HowToArticle
    {
        public int Id { get; init; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(ArticleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(60)]
        public string Author { get; set; }
         

    }
}
