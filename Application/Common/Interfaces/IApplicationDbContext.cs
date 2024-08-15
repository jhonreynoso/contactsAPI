using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        Task<int> SaveChangesAsync();
    }
}

