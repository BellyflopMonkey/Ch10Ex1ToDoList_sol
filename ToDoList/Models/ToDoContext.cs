﻿using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options) { }

        public DbSet<ToDo> ToDos { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        // Add your new entities here
        public DbSet<FamilyAccount> FamilyAccounts { get; set; } = null!;
        public DbSet<FamilyMember> FamilyMembers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "work", Name = "Work" },
                new Category { CategoryId = "home", Name = "Home" },
                new Category { CategoryId = "ex", Name = "Exercise" },
                new Category { CategoryId = "shop", Name = "Shopping" },
                new Category { CategoryId = "call", Name = "Contact" }
            );
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "open", Name = "Open" },
                new Status { StatusId = "closed", Name = "Completed" }
            );

            modelBuilder.Entity<FamilyAccount>().HasData(
                new FamilyAccount { Id = 1, FamilyName = "Bolfert", Password = "password1" },
                new FamilyAccount { Id = 2, FamilyName = "Tisai", Password = "password2" },
                new FamilyAccount { Id = 3, FamilyName = "Cupery", Password = "password3" }
            );
        }
    }
}
// Stupid fat hobbit ruins it! Give it to us raw, and wriggling!