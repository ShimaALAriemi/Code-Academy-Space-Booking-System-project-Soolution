using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Academy_Space_Booking_System_project.Model
{
    internal class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Customer_ID { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "First Name must be 10 characters or less"), MinLength(5)]
        public string FName { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Last Name must be 10 characters or less"), MinLength(5)]
        public string LName { get; set; }
        [Required]
        public string DoB { get; set; }
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Street { get; set; }
        
        [Required]
        public long House_Num { get; set; }
        [Phone]
        [Required(ErrorMessage = "Phone no. is required")]
        public string Phone { get; set; }
    }
}
