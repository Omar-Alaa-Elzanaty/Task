namespace Task.Models
{
    public class CustomerListViewModel
    {
        public IEnumerable<CustomerViewModel> Customers { get; set; } = new List<CustomerViewModel>();
    }
}