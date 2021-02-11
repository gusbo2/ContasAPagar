using ContasAPagar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContasAPagar.Data.EntityConfigurator
{
    public abstract class EntityConfiguratorBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired();
            AdvancedConfiguration(builder);
        }

        protected abstract void AdvancedConfiguration(EntityTypeBuilder<TEntity> builder);
    }
}