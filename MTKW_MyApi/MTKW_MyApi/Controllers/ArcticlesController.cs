using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTKW_MyApi.Data;
using MTKW_MyApi.Data.Repository;
using MTKW_MyApi.DataAccess;

namespace MTKW_MyApi.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArcticlesController : ControllerBase
    {
        private readonly ILogger<ArcticlesController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ArcticlesController(ILogger<ArcticlesController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id:int}", Name = "GetArticleById")]
        public async Task<ActionResult<Article>> Get(int id)
        {
            var article = await _unitOfWork.Articles.Get(x => x.ID == id);
            if(article == null)
            {
                return NotFound("Article not found");
            }
            return Ok(article);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var articles = await _unitOfWork.Articles.GetAllAsync();
                if (articles == null || !articles.Any())
                {
                    return NotFound("No articles found");
                }
                return Ok(articles);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest("Article cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.Articles.AddAsync(article);
                await _unitOfWork.SaveAsync();
                return CreatedAtRoute("GetArticleById", new {id = article.ID}, article);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating article");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var articleToDelete = await _unitOfWork.Articles.GetAsync(a => a.ID == id);

            if (articleToDelete == null)
            {
                return NotFound("Article not found");
            }
            _unitOfWork.Articles.Remove(articleToDelete);
            await _unitOfWork.SaveAsync();
            return Ok("Article deleted successfully");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest("Article cannot be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingArticle = await _unitOfWork.Articles.GetAsync(a => a.ID == article.ID);
                if (existingArticle == null)
                {
                    return NotFound("Article not found");
                }

                existingArticle.TITLE = article.TITLE;
                existingArticle.CATEGORY_ID = article.CATEGORY_ID;
                existingArticle.AUTHOR_ID = article.AUTHOR_ID;
                existingArticle.CREATED_AT = article.CREATED_AT;

                _unitOfWork.Articles.Update(existingArticle);
                await _unitOfWork.SaveAsync();
                return Ok("Article updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating article");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
