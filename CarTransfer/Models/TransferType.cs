namespace CarTransfer.Models
{
    public enum CarType
    {
        Sedan = 1,
        Jeep
    }
    public class TransferType
    {
        public CarType type {  get; set; }
        public bool IsOpenConteiner {  get; set; }
        public bool IsOperable {  get; set; }
        public double Price { get; set; } = 1500;
        public double Kayficent {  get; set; }

        public double Procent()
        {
            double x = 0;

            if (type == CarType.Sedan)
            {
                Price = Price;
            }
            if (type == CarType.Jeep)
            {
                x = Price * Kayficent - Price;
                Price = Price + x;
            }
            if (!IsOpenConteiner)
            {
                x = Price * Kayficent - Price;
                Price = Price + x;
            }
            if (!IsOperable)
            {
                x = Price * Kayficent - Price;
                Price = Price + x;
            }
            return Price;
        }
    }
}
