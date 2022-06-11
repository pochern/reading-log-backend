using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReadingLog.Common.Models;
using ReadingLog.Common.Models.Enums;

namespace ReadingLog.Common.EFModels
{
    public partial class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Title of the book.
        /// </summary>
        /// <example>Jane Eyre</example>
        public string Title { get; set; }

        /// <summary>
        /// Author of the book.
        /// </summary>
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

        /// <summary>
        /// Publisher of the book.
        /// </summary>
        public Publisher Publisher { get; set; }
    }
}
