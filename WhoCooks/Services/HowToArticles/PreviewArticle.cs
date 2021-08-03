namespace WhoCooks.Services.HowToArticles
{
    using System.Collections.Generic;
    using WhoCooks.Data;
    public class PreviewArticle:IPreviewArticle
    {
        public IEnumerable<string> PreviewArticleContent(IEnumerable<HowToArticle> articles)
        {

           var preview = new List<string>();

            foreach (var article in articles)
            {
                const int allowedPreviewChar = 503;

                var content = article.Content;
                var previewContent = string.Empty;

                var charNumInContent = 0;

                for (int i = 0; i < content.Length; i++)
                {
                    charNumInContent += 1;
                }

                if (charNumInContent > allowedPreviewChar)
                {
                    for (int i = 0; i < allowedPreviewChar; i++)
                    {

                        var cChar = content[i];
                        previewContent += cChar;

                    }
                   
                } 
                preview.Add(previewContent);
            }

            return preview;
        }
    }
}
