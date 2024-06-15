using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace toshokan.Models
{
    public class Book
    {

        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3), Required]
        public string Title { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string Author { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(30)]
        public string Genre { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        public string ImgURL { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal RentCost { get; set; }
    }
}
