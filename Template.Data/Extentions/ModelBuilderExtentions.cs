using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Extentions
{
    public static class ModelBuilderExtentions
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new User { Id = Guid.Parse("356efb5d-0d5e-48a3-a168-288ea68f5dab"), Name = "User Default", Email = "userdefault@template.com", DateCreated = new DateTime(2020,2,2), IsDeleted = false, DateUpdated = null}
                );

            return builder;
        }
    }
}
