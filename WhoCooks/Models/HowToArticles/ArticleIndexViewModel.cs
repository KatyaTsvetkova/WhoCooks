namespace WhoCooks.Models.HowToArticles
{
    using System.Collections.Generic;
    using WhoCooks.Data;

    public class ArticleIndexViewModel
    {
        public List<string> Preview { get; set; }

        public IEnumerable<HowToArticle> Articles { get; set; }
         
    }
}
