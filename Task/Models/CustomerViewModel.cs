using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        public string Code { get; set; } = default!;

        [Required(ErrorMessage = "Customer Name is required.")]
        public string CustomerName { get; set; } = default!;

        public DateTime DateOfRegistration { get; set; }

        // List to hold selected product IDs
        public List<int> SelectedProductIds { get; set; } = new List<int>();
    }
}