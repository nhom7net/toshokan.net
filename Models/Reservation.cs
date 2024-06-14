using System;
using System.ComponentModel.DataAnnotations;

namespace toshokan.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        [Required(ErrorMessage = "Reservation date is required.")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "Expiration date is required.")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Expiration date must be in the future.")]
        public DateTime ExpirationDate { get; set; }

        [StringLength(20, ErrorMessage = "Status cannot be longer than 20 characters.")]
        public string Status { get; set; }

  
        public Book Book { get; set; }

    
        public Member Member { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            bool parsed = DateTime.TryParse(value.ToString(), out dateTime);
            return parsed && dateTime > DateTime.Now;
        }
    }
}