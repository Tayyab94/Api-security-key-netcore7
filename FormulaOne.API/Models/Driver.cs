namespace FormulaOne.API.Models
{
    public class Driver:BaseEntity
    {        public string Name { get; set; } = "";
        public int DriverNumber { get; set; }


        public ICollection<Acheivement> Acheivements { get; set;}
    }
}
