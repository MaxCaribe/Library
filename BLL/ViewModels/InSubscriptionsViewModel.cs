using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class InSubscriptionsViewModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Book")]
        public string ISBN { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfReceipt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ReturnDate { get; set; }

        [Required]
        public bool IsInUse { get; set; }

        [Required]
        public bool IsAccepted { get; set; }

        public Book Book { get; set; }

        public ApplicationUser User { get; set; }
    }
}