namespace Nirsman.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public decimal GrandTotal { get; set; }

        public string UserId { get; set; }  // Добавьте UserId для связи с пользователем
    }
}
