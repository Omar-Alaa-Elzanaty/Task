namespace Task.Models
{
    public class CustomerDetailsViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public DateTime DateOfRegistration { get; set; }

        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}