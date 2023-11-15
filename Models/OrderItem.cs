﻿namespace Nirsman.Models
{
    public class OrderItem
    {
        public long Id { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }


        // Дополнительные поля элемента заказа, если необходимо
    }
}
