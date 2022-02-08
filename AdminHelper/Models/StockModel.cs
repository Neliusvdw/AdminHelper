namespace AdminHelper.Pages.Models
{
    public class StockModel
    {
        public int ID { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Supplier { get; set; } = string.Empty;

    }
}
