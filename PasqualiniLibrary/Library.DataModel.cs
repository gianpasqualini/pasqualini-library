using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasqualiniLibrary.DataModel
{
    [Table("Book", Schema = "dbo")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Book Id")]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Book title")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Book Author")]
        public string Author { get; set; }

        [Required]
        [Column]
        [Display(Name = "Book quantity")]
        public int Quantity { get; set; }
    }
}
