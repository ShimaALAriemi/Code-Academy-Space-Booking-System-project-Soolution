

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Code_Academy_Space_Booking_System_project.Model
{
    internal class Space
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Space_ID { get; set; }
        public string Space_Status { get; set; }

        public string Location { get; set; }
        public double Hight { get; set; }
        public double Width { get; set; }
        public string Building_Name { get; set; }
        public string Image { get; set; }

        [ForeignKey("BookID")]
        public int? BookID { get; set; }
        public Booking Books { get; set; }
    }
}
