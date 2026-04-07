namespace CRM.Application.Requests.Products
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class UpdateProductRequest : CreateProductRequest { }
}
