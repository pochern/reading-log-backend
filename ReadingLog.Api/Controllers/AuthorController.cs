using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadingLog.Common.Models;
using ReadingLog.Common.Models.DAL;

namespace ReadingLog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorRepository _repository;

        public AuthorController(ILogger<AuthorController> logger, IAuthorRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Adds an author to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Newly added author</returns>
        [HttpPost]
        public IActionResult AddAuthor(AuthorModel model)
        {
            _logger.LogInformation($"Adding {model.FirstName} {model.LastName} to the database");
            if (_repository.AuthorExists(model))
            {
                return BadRequest($"An author with first name {model.FirstName} and last name {model.LastName} already exists.");
            }
            _repository.AddAuthor(model);
            return Ok(model);
        }

        /// <summary>
        /// Gets all authors from the database.
        /// </summary>
        /// <returns>List of authors in the database</returns>
        [HttpGet]
        public IActionResult GetAuthors()
        {
            _logger.LogInformation("Getting all authors from the database");
            var authors = _repository.GetAuthors();
            return Ok(authors);
        }
    }
}
