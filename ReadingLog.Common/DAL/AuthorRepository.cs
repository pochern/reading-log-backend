using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ReadingLog.Common.EFModels;

namespace ReadingLog.Common.Models.DAL
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ReadingLogDBContext _dbContext;
        private readonly ILogger<AuthorRepository> _logger;

        public AuthorRepository(ReadingLogDBContext dbContext, ILogger<AuthorRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void AddAuthor(AuthorModel model)
        {
            var author = new Author()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            try
            {
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Adding author {author.FirstName} {author.LastName} failed with = {ex}");
                throw new Exception($"Adding author {author.FirstName} {author.LastName} failed with = {ex}");
            }
        }

        public List<Author> GetAuthors()
        {
            return _dbContext.Authors.ToList();
        }

        public bool AuthorExists(AuthorModel model)
        {
            return _dbContext.Authors.Where(a => a.FirstName == model.FirstName && a.LastName == model.LastName).Any();
        }
    }
}