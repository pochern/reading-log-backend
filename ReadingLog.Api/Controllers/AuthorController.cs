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
            _repository.AddAuthor(model);
            return Ok(model);
        }

        /// <summary>
        /// Gets all authors from the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAuthors()
        {
            _logger.LogInformation("Getting all authors from the database");
            var authors = _repository.GetAuthors();
            return Ok(authors);
        }
        // get all authors
        //return context.Author.ToList();

        // add an author
        //Author author = new Author();
        //author.FirstName = "John";
        //author.LastName = "Smith";

        //context.Author.Add(author);

        // update author
        //Author author = context.Author.Where(auth => auth.FirstName == "John").FirstOrDefault();
        //// author instance from DB
        //author.Phone = "777-777-7777";

        // delete author
        // Author author = context.Authors.Where(auth => auth.FirstName == "John").FirstOrDefault();
        // context.Authors.Remove(author);
        //
        // context.SaveChanges();
        //
        // // get author by id
        // return context.Authors.Where(auth => auth.FirstName == "John").ToList();
    }
}
