using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class BookViewModel
    {
        [Required(ErrorMessage = "Book should have ISBN.")]
        [Key]
        [MaxLength(13, ErrorMessage = "ISBN has less digits"), MinLength(13, ErrorMessage = "ISBN has more digits")]
        [RegularExpression(@"\d+", ErrorMessage = "ISBN consists of digits")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Book should have name.")]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Book should have at least one author.")]
        [MaxLength(256)]
        public string Author { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Book should have publisher.")]
        [MaxLength(128)]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "We need to know what language is used in book.")]
        [MaxLength(32, ErrorMessage = "Language name can't be so long.")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Book should be hardback/paperback.")]
        [RegularExpression("(hard|paper)back")]
        public string Format { get; set; }

        [Required(ErrorMessage = "Book should have number of pages.")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "Book publish date must be.")]
        public DateTime PublicationDate { get; set; }

        [RegularExpression(@"[\d]{1,3}", ErrorMessage = "Incorrect quantity.")]
        public int Quantity { get; set; }

        public byte[] Image { get; set; }

        public string ImageMime { get; set; }
    }
}