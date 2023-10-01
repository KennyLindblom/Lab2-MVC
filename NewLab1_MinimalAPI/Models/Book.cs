using System.ComponentModel.DataAnnotations;

namespace NewLab1_MinimalAPI.Models
{
    public class Book
    {

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public bool IsAvaliabel { get; set; }

        public int ReleaseYear { get; set; }

        public string Description { get; set; }
    }
}
