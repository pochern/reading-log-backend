using System.Collections.Generic;
using ReadingLog.Common.EFModels;

namespace ReadingLog.Common.Models.DAL
{
    public interface IAuthorRepository
    {
        public void AddAuthor(AuthorModel author);

        public List<Author> GetAuthors();

        bool AuthorExists(AuthorModel model);
    }
}