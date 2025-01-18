namespace Project.APIS.Models
{
    public class ProductV1
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ProductV2
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ProductPrice ProductPrice { get; set; }
    }

    public class ProductPrice
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
