using KovanCaseStudy.Domain.Aggregates.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KovanCaseStudy.Infrastructure.EfCore.EntityConfigurations;

public class UserEntityConfigurations: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(b => b.Id); //PK

        builder.Property(p => p.Username).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Password).IsRequired().HasMaxLength(50);
        
        builder.HasData(new User("1","admin", "admin"));
    }
}