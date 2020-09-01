using Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Api
{
    public class AccountStoreContext : DbContext
    {
        public DbSet<Account> Accounts { get; internal set; }

        public AccountStoreContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

    }
}