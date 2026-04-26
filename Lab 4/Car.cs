namespace Lab4
{
    // simple car class with brand and price
    public class Car
    {
        public string Brand { get; set; }
        public double Price { get; set; }

        public Car(string brand, double price)
        {
            Brand = brand;
            Price = price;
        }

        public override string ToString()
        {
            return Brand + " (" + Price + " PLN)";
        }
    }
}
