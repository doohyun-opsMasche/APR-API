using APPROVAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APPROVAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Approver> Approvers { get; set; }
    }
}