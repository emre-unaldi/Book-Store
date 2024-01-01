using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entities
{
    public class Book
    {
        // Auto Increment
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; } // Fk
        public Genre Genre { get; set; } // Navigation
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
