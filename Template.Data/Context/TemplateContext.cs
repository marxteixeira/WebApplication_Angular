using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Template.Data.Extentions;
using Template.Data.Mappings;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class TemplateContext: DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> option)
            :base(option)
        {

        }

        #region "DbSets"
        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
