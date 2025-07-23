using ItemManagementSystem.Domain.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ItemManagementSystem.Domain.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ItemType> ItemTypes { get; set; }
    public DbSet<ItemModel> ItemModels { get; set; }
    public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
    public DbSet<ItemRequest> ItemRequests { get; set; }
    public DbSet<ItemRequestDetail> ItemRequestDetails { get; set; }
    public DbSet<ReturnRequest> ReturnRequests { get; set; }
    public DbSet<ReturnRequestDetail> ReturnRequestDetails { get; set; }
    public DbSet<PurchaseRequestDetail> PurchaseRequestDetails { get; set; }
    public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CreatedByUser)
                .WithMany()
                .HasForeignKey(u => u.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.ModifiedByUser)
                .WithMany()
                .HasForeignKey(u => u.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasOne(r => r.CreatedByUser)
                .WithMany()
                .HasForeignKey(r => r.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasOne(r => r.ModifiedByUser)
                .WithMany()
                .HasForeignKey(r => r.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemModel>()
                .HasOne(im => im.CreatedByUser)
                .WithMany()
                .HasForeignKey(im => im.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemModel>()
                .HasOne(im => im.ModifiedByUser)
                .WithMany()
                .HasForeignKey(im => im.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemType>()
               .HasOne(it => it.CreatedByUser)
               .WithMany()
               .HasForeignKey(it => it.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemType>()
                .HasOne(it => it.ModifiedByUser)
                .WithMany()
                .HasForeignKey(it => it.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemRequest>()
              .HasOne(ir => ir.CreatedByUser)
              .WithMany()
              .HasForeignKey(ir => ir.CreatedBy)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemRequest>()
                .HasOne(ir => ir.ModifiedByUser)
                .WithMany()
                .HasForeignKey(ir => ir.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseRequest>()
               .HasOne(pr => pr.CreatedByUser)
               .WithMany()
               .HasForeignKey(pr => pr.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseRequest>()
                .HasOne(pr => pr.ModifiedByUser)
                .WithMany()
                .HasForeignKey(pr => pr.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemRequestDetail>()
               .HasOne(ri => ri.CreatedByUser)
               .WithMany()
               .HasForeignKey(ri => ri.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemRequestDetail>()
                .HasOne(ri => ri.ModifiedByUser)
                .WithMany()
                .HasForeignKey(ri => ri.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReturnRequest>()
               .HasOne(rr => rr.CreatedByUser)
               .WithMany()
               .HasForeignKey(rr => rr.CreatedBy);

            modelBuilder.Entity<ReturnRequest>()
                .HasOne(rr => rr.ModifiedByUser)
                .WithMany()
                .HasForeignKey(rr => rr.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReturnRequestDetail>()
               .HasOne(rri => rri.CreatedByUser)
               .WithMany()
               .HasForeignKey(rri => rri.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReturnRequestDetail>()
                .HasOne(rri => rri.ModifiedByUser)
                .WithMany()
                .HasForeignKey(rri => rri.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<ItemModel>()
                .HasOne(im => im.ItemType)
                .WithMany()
                .HasForeignKey(im => im.ItemTypeId);

            modelBuilder.Entity<ItemRequest>()
                .HasOne(ir => ir.User)
                .WithMany()
                .HasForeignKey(ir => ir.UserId);

            modelBuilder.Entity<ItemRequest>()
                .HasOne(ir => ir.Status)
                .WithMany()
                .HasForeignKey(ir => ir.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemRequestDetail>()
                .HasOne(ri => ri.ItemRequest)
                .WithMany()
                .HasForeignKey(ri => ri.ItemRequestId);

            modelBuilder.Entity<ItemRequestDetail>()
                .HasOne(ri => ri.ItemModel)
                .WithMany()
                .HasForeignKey(ri => ri.ItemModelId);

            modelBuilder.Entity<ReturnRequest>()
                .HasOne(rr => rr.User)
                .WithMany()
                .HasForeignKey(rr => rr.UserId);

            modelBuilder.Entity<ReturnRequest>()
                .HasOne(rr => rr.Status)
                .WithMany()
                .HasForeignKey(rr => rr.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReturnRequestDetail>()
                .HasOne(rri => rri.ReturnRequest)
                .WithMany()
                .HasForeignKey(rri => rri.ReturnRequestId);

            modelBuilder.Entity<ReturnRequestDetail>()
                .HasOne(rri => rri.ItemModel)
                .WithMany()
                .HasForeignKey(rri => rri.ItemModelId);

            // Table renaming using Fluent API
            modelBuilder.Entity<ItemRequestDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ItemRequestId).HasColumnName("item_request_id");
                entity.Property(e => e.ItemModelId).HasColumnName("item_model_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.CreatedBy).HasColumnName("created_by");
                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<ReturnRequestDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ReturnRequestId).HasColumnName("return_request_id");
                entity.Property(e => e.ItemModelId).HasColumnName("item_model_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.CreatedBy).HasColumnName("created_by");
                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<PurchaseRequestDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PurchaseRequestId).HasColumnName("purchase_request_id");
                entity.Property(e => e.ItemModelId).HasColumnName("item_model_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            });

        modelBuilder.Entity<PurchaseRequest>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            // entity.Property(e => e.User).HasColumnName("user");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<ItemModel>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });
    }
}
