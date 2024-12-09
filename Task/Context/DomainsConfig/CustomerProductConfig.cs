using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Domains;

namespace Task.Context.DomainsConfig
{
    internal class CustomerProductConfig : IEntityTypeConfiguration<CustomerProduct>
    {
        public void Configure(EntityTypeBuilder<CustomerProduct> builder)
        {
            builder.HasKey(x => new {x.ProductId, x.CustomerId});
        }
    }
}
