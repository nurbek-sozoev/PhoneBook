﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PhoneBook.ViewModels;

namespace PhoneBook.Data
{
    public partial class PhoneBookDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<User> Users { get; set; }

        public PhoneBookDbContext()
        {
        }

        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=phone_book;UserId=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
