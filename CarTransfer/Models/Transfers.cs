namespace CarTransfer.Models
{
    public class Transfers
    {
        public int Id { get; set; } 
        public int CarId {  get; set; }
        public string CityFrom {  get; set; }
        public string CityTo {  get; set; }
        public double Price {  get; set; }
    }
}
