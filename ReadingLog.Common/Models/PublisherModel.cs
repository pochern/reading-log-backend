using System.Collections.Generic;
using ReadingLog.Common.EFModels;

#nullable disable

namespace ReadingLog.Common.Models
{
    public partial class PublisherModel
    {
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
