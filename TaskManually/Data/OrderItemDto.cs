﻿namespace TaskManually.Data
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrdersId { get; set; }
    }
}
