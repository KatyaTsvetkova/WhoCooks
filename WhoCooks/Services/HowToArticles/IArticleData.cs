namespace WhoCooks.Services.HowToArticles
{
    using System.Collections.Generic;
    using WhoCooks.Data;
    public interface IArticleData
    {
        IEnumerable<HowToArticle> GetArticles();
        HowToArticle GetArticle(int id);
        HowToArticle PostArticle(HowToArticle article);
        HowToArticle EditArticle(HowToArticle article);
        HowToArticle DeleteArticle(int id);
    }
}
