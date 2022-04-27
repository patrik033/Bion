using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bion.Models
{
    public class TicketOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Range(1,12)]
        public int Seats { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string MovieTitle { get; set; }
        public string? BookingNumber { get; set; }
        public string SalongName { get; set; }
        public string Time { get; set; }


    }
}
