using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Nirsman.Models
{
    public class AppUser : IdentityUser
    {

        [Required(ErrorMessage = "Пароль обязателен")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public ICollection<CartItem> CartItems { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
