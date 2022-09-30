namespace API.Models.DTO
{
    public class ItemRequestDTO
    {
    }

    public class MomoItemRequestDTO : ItemRequestDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Category { get; set; } 
        public string ImageUrl { get; set; } = String.Empty;
        public string Manufacturer { get; set; } = String.Empty;
        public long Price { get; set; }
        public string Currency { get; set; } = "VND";
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public long TotalPrice { get; set; }
        public long TaxAmount { get; set; }
    }
}
