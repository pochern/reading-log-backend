using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

#nullable disable

namespace ReadingLog.Common.EFModels
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
