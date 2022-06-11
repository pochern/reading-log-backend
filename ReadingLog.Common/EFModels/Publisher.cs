using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ReadingLog.Common.EFModels
{
    public partial class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the publisher of the book.
        /// </summary>
        /// <example>Smith, Elder and Co.</example>
        public string Name { get; set; }

        /// <summary>
        /// The city where the publisher headquarter is located.
        /// </summary>
        /// <example>London</example>
        public string City { get; set; }

        /// <summary>
        /// The state where the publisher headquarter is located.
        /// </summary>
        /// <example></example>
        public string State { get; set; }

        /// <summary>
        /// The country where the publisher's headquarter is located.
        /// </summary>
        /// <example>United Kingdom</example>
        public string Country { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
