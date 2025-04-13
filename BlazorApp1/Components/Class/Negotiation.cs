namespace BlazorApp1.Components.Class
{
    public class Negotiation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime EndDate { get; set; }

        public bool isAccepted { get; set; }    

    }
}
