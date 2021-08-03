namespace WhoCooks.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WhoCooks.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using WhoCooks.Services.HowToArticles;
    using Microsoft.AspNetCore.Mvc;
    using WhoCooks.Models.HowToArticles;

    public class ArticleController: Controller
    {
     
        private readonly IArticleData articleData;
        private readonly IPreviewArticle preview;
        private readonly IHttpContextAccessor httpContext;
        private WhoCooksDbContext data;
      

        public ArticleController(IArticleData articleData,
            IHttpContextAccessor context,
            WhoCooksDbContext data,
            IPreviewArticle preview
        )
        {
            this.articleData = articleData;
           
            this.httpContext = context;
            this.data = data;
            this.preview = preview;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var article = articleData.GetArticle(id);
            //var comments = _commentData.GetComments(id).ToList();

            //var pagedList =  PagingList.Create(comments, 2, page);

            var model = new ArticleViewModel();
            model.Id = id;
            model.Title = article.Title;
            model.Author = article.Author;
            model.Date = article.Date;
            model.Content = article.Content;


            return View(model);
        }
      
        [HttpPost]
        public IActionResult DeleteArticle(int id)
        {
            articleData.DeleteArticle(id);
            return RedirectToAction(nameof(Index), "Article");
        }

     
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = articleData.GetArticle(id);

            return View(model);
        }

    
        [HttpPost]
        public IActionResult Edit(HowToArticle model)
        {
            if (ModelState.IsValid)
            {
                var updatedArticle = new HowToArticle();
              
                updatedArticle.Title = model.Title;
                updatedArticle.Author = model.Author;
                updatedArticle.Content = model.Content;
                updatedArticle.Date = DateTime.Now;

                updatedArticle = articleData.EditArticle(updatedArticle);

                return RedirectToAction("Details", "Article", new { id = updatedArticle.Id });
            }
            else
            {
                return View();
            }
        }

       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(HowToArticle model)
        {
            if (ModelState.IsValid)
            {
                var newArticle = new HowToArticle();
                newArticle.Title = model.Title;
                newArticle.Author = model.Author;
                newArticle.Content = model.Content;
                newArticle.Date = DateTime.Now;

                articleData.PostArticle(newArticle);

                return RedirectToAction("Details", "Article", new { id = newArticle.Id });
            }
            else
            {
                return View();
            }
        }
        
        [HttpGet]
        public IActionResult Index()
        {
           var query = httpContext.HttpContext.Request.Headers.FirstOrDefault(r => r.Key.Contains("Referer"));

            var model = new ArticleIndexViewModel();
          
            IEnumerable<HowToArticle> articles = model.Articles;

            model.Preview= preview.PreviewArticleContent(articles).ToList();

            return View(model);
        }

    }
}
