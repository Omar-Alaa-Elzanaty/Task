using Microsoft.AspNetCore.Identity;

namespace Tasks.Domains
{
    public class Customer : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public List<CustomerProduct> Products { get; set; }
    }
}
