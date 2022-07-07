namespace TaskManually.Data
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public DateTime Created_at { get; set; }
        public int UserId { get; set; }
    }
}
