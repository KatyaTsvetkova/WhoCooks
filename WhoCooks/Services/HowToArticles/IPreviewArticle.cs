namespace WhoCooks.Services.HowToArticles
{
    using System.Collections.Generic;
    using WhoCooks.Data;
    public interface IPreviewArticle
    {
        IEnumerable<string> PreviewArticleContent(IEnumerable<HowToArticle>articles);
    }
}
