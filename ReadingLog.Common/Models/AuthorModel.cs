using Newtonsoft.Json;

#nullable disable

namespace ReadingLog.Common.Models
{
    public class AuthorModel
    {
        /// <summary>
        /// First name of the author of the book.
        /// </summary>
        /// <example>Charlotte</example>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the author of the book.
        /// </summary>
        /// <example>Brontë</example>
        public string LastName { get; set; }
    }
}
