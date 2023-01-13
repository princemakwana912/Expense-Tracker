using Expense_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker
{
    public class ApplicationDbContext:DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Expense_Tracker.Models.Limit> Limit { get; set; }

    }
}
