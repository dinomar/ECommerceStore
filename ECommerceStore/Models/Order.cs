using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a zip code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }
    }
}
