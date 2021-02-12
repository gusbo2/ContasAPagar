using ContasAPagar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContasAPagar.Data.EntityConfigurator
{
    public class BillConfiguration : EntityConfiguratorBase<Bill>
    {
        protected override void AdvancedConfiguration(EntityTypeBuilder<Bill> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Value).IsRequired();
            builder.Property(c => c.ExpirationDate).IsRequired();
            builder.Property(c => c.PayDate).IsRequired();

            builder.ToTable(nameof(Bill));
        }
    }
}