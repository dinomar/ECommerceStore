using System.ComponentModel.DataAnnotations;

namespace ECommerceStore.Models
{
    public class Catagory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a catagory name")]
        public string Name { get; set; }
    }
}
