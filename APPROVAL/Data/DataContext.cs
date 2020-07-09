using APPROVAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APPROVAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Approver> Approvers { get; set; }
        public DbSet<FormFileGroup> FormFileGroups { get; set; }
        public DbSet<FormFile> FormFiles { get; set; }
        public DbSet<FormCategory> FormCategorys { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormDisplayAuth> FormDisplayAuths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 아래 테이블은 Key가 혼합키로 생성이 되어 있어 아래 설정을 해줘야 DB 마이그레이션 파일이
            // 정상 생성이 됩니다.
            modelBuilder.Entity<FormDisplayAuth>()
                        .HasKey(c => new { c.authId, c.formId });
        }
    }
}