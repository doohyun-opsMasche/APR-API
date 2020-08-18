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
        public DbSet<ApprovalReference> ApprovalReferences { get; set; }
        public DbSet<ApprovalRequestUser> ApprovalRequestUsers { get; set; }
        public DbSet<ApprovalUser> ApprovalUsers { get; set; }
        public DbSet<AttachFile> AttachFiles { get; set; }
        public DbSet<DelegationUser> DelegationUsers { get; set; }
        public DbSet<ProcessInstance> ProcessInstances { get; set; }
        public DbSet<DelegateProvision> DelegateProvisions { get; set; }
        public DbSet<DelegateProvisionCategory> DelegateProvisionCategorys { get; set; }
        public DbSet<DelegateProvisionLine> DelegateProvisionLines { get; set; }
        public DbSet<DelegateProvisionLineDetail> DelegateProvisionLineDetails { get; set; }
        public DbSet<Code> Codes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 아래 테이블은 Key가 혼합키로 생성이 되어 있어 아래 설정을 해줘야 DB 마이그레이션 파일이
            // 정상 생성이 됩니다.
            modelBuilder.Entity<FormDisplayAuth>(entity =>
            {
                entity.HasKey(e => new { e.authId, e.formId })
                    .HasName("PK_TB_FORM_DISPLAY_AUTH")
                    .IsClustered(false);
            });
        }
    }
}