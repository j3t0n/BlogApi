using BlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Slug)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(p => p.Author)
                   .WithMany(u=>u.Posts) 
                   .HasForeignKey(p => p.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
