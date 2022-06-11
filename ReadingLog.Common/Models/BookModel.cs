using System;
using ReadingLog.Common.EFModels;
using ReadingLog.Common.Models.Enums;

namespace ReadingLog.Common.Models
{
    public partial class BookModel
    {
        /// <summary>
        /// Title of the book.
        /// </summary>
        /// <example>Jane Eyre</example>
        public string Title { get; set; }

        public Author Author { get; set; }

        /// <summary>
        /// Genre of the book.
        /// </summary>
        /// <example>Classics</example>
        public Genre Genre { get; set; }

        /// <summary>
        /// Date the book was published in MM/DD/YYYY format.
        /// </summary>
        /// <example>10/16/1847</example>
        public DateTime PublishedDate { get; set; }


        public Publisher Publisher { get; set; }
    }
}
