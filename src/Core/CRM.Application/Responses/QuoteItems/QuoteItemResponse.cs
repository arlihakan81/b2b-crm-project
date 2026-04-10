using CRM.Application.Responses.Products;
using CRM.Application.Responses.Quotes;

namespace CRM.Application.Responses.QuoteItems
{
    public class QuoteItemResponse
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public ProductResponse Product { get; set; }
        public QuoteResponse Quote { get; set; }

    }
}
