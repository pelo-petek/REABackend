using Infrastructure.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.HasIndex(x => x.AccountNumber).IsUnique();
            builder.Property(x => x.AccountType).IsRequired();
            builder.Property(x => x.Balance).IsRequired();

            // Define the many-to-one relationship between Account and Customer
            builder.HasOne(a => a.User)
                   .WithMany(c => c.Accounts)
                   .HasForeignKey(a => a.UserId);

        

        }
    }
}
