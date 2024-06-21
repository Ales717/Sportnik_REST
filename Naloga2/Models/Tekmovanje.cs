using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Naloga2.Models
{
    public class Tekmovanje
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
        public string ime { get; set; }
        public string leto_izvedbe { get; set; }
        public string tip { get; set; }
        //public List<Rezultati> rezultati { get; set; }
    }
}
