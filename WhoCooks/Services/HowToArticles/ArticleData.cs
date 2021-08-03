

namespace WhoCooks.Services.HowToArticles
{
    using System.Linq;
    using System.Collections.Generic;
    using WhoCooks.Data;
    using Microsoft.EntityFrameworkCore;

    public class ArticleData:IArticleData
    {
        private readonly WhoCooksDbContext data;

        public ArticleData(WhoCooksDbContext data)
        {
            this.data = data;
        }

        public HowToArticle DeleteArticle(int id)
        {
            this.data.Remove(data.Articles.SingleOrDefault(a => a.Id == id));
            this.data.SaveChanges();
            return new HowToArticle();
        }

        public HowToArticle EditArticle(HowToArticle article)
        {
           this.data.Attach(article).State = EntityState.Modified;
           this.data.SaveChanges();
            return article;
        }

        public HowToArticle GetArticle(int id)
        {
            return this.data.Articles.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<HowToArticle> GetArticles()
        {
            return this.data.Articles.OrderByDescending(a => a.Date);
        }

        public HowToArticle PostArticle(HowToArticle article)
        {
            this.data.Articles.Add(article);
            this.data.SaveChanges();
            return article;
        }
    }
}
