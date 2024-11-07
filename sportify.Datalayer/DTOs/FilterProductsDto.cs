namespace sportify.Datalayer.DTOs
{
    public class FilterProductsDto
    {
        public string? Input { get; set; }

        public long? Categoryid { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }
        public string? sortby { get; set; }
    }
}
