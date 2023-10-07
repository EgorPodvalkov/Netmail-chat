using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;

namespace PL.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleBS;
        private readonly IEditorService _editorBS;
        public ArticleController(
            IMapper mapper,
            IArticleService articleBS,
            IEditorService editorBS
            )
        {
            _mapper = mapper;
            _articleBS = articleBS;
            _editorBS = editorBS;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await GetArticlesModel(null, null);
            return View("GetArticlesHTML", model);
        }

        [HttpPost("/AddArticle")]
        public async Task<IActionResult> AddArticle()
        {
            const string badJSON = "You need use json (string Pass, string Title, string Description).";
            try
            {
                if (!Request.HasJsonContentType())
                    throw new Exception(badJSON);

                var request = await Request.ReadFromJsonAsync<AddArticleRequestModel>();
                if (request is null
                    || string.IsNullOrEmpty(request.Pass)
                    || string.IsNullOrEmpty(request.Title)
                    || string.IsNullOrEmpty(request.Description))
                    throw new Exception(badJSON);

                var editor = await _editorBS.GetEditorIDByPassAsync(request.Pass)
                    ?? throw new Exception("Bad Pass");

                var article = new ArticleDTO
                {
                    EditorID = editor.ID,
                    Title = request.Title,
                    Description = request.Description,
                };

                await _articleBS.AddArticleAsync(article);

                var responce = new BaseResponceModel
                {
                    Message = $"Your article has successfully posted by name {editor.Name}"
                };
                return Ok(responce);
            }
            catch (Exception ex)
            {
                var responce = new BaseResponceModel
                {
                    Error = ex.Message
                };
                return Ok(responce);
            }
        }

        private async Task<ArticlesModel> GetArticlesModel(int? skip, int? take)
        {
            var dtos = await _articleBS.GetArticlesWithEditorsAsync(skip ?? 0, take);
            var totalArticlesAmount = await _articleBS.GetArticlesAmountAsync();
            return new ArticlesModel
            {
                TotalArticlesAmount = totalArticlesAmount,
                ArticlesAmount = dtos.Count(),
                Articles = _mapper.Map<IEnumerable<ArticleModel>>(dtos),
            };
        }

        [HttpGet("/GetArticlesJSON")]
        public async Task<IActionResult> GetArticlesJSON(int? skip, int? take)
        {
            var model = await GetArticlesModel(skip, take);
            return Ok(model);
        }

        [HttpGet("/GetArticlesHTML")]
        public async Task<IActionResult> GetArticlesHTML(int? skip, int? take)
        {
            var model = await GetArticlesModel(skip, take);
            return View(model);
        }
    }
}
