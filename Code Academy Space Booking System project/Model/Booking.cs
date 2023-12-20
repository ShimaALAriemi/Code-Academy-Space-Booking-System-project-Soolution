

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_Academy_Space_Booking_System_project.Model
{
    internal class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Book_ID { get; set; }
        public int? Duration { get; set; }
        [Required]
        public string Start_Day { get; set; }
        [Required]
        public string End_Day { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Cost { get; set; }

        [ForeignKey("SpaceID")]
        public int? SpaceID { get; set; }
        public Space Space { get; set; }

        [ForeignKey("BillID")]
        public int? BillID { get; set; }
        public Bill Bills { get; set; }

        [ForeignKey("CustomerID")]
        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }
       

        public static int countDuration(string start, string end)
        {
            int sDay = Convert.ToInt32(start.Substring(start.Length-2));
            int eDay = Convert.ToInt32(end.Substring(start.Length - 2));

            if (sDay > eDay) return sDay - eDay;
            else return eDay - sDay;
        }

        public static decimal countCost(int douration) => (decimal)douration * 12.3m;
    }
}
