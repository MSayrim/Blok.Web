﻿using Blok.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(a => a.ID);

            builder
                .Property(m => m.ID)
                .UseIdentityColumn();

            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Categories");
        }

    }
}
