using GoodReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure.Persistence.Configuration
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasMany(b => b.Reviews)
                .WithOne(r => r.Book)
                .HasForeignKey(b => b.IdBook)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
