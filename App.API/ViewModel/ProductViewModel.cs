namespace App.API.ViewModels
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int CategoryId { get; set; }
        public int CategoryName { get; set; }
    }
}
