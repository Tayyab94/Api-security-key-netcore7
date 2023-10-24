using System.ComponentModel.DataAnnotations.Schema;

namespace FormulaOne.API.Models
{
    public class Acheivement:BaseEntity
    {
        public string AcheivementName { get; set; }
        
        public int DriverId { get; set; }

        [ForeignKey(name: "DriverId")]
        public virtual Driver Driver { get; set; }
    }
}
