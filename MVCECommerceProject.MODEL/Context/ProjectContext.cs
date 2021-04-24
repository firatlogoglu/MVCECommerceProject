using MVCECommerceProject.CORE.Entity;
using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MODEL.Map;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVCECommerceProject.MODEL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            //TODO: SQL Connection bağlatsı varsayılan olarak tanımlanmıştır. Varsayılanın dışında bir bağlantı için, kendi SQL Server name'nizi ". (nokta)" yerine yazın, database ismini varsayılan olarak MVCECommerceProjectDB tanımlanmıştır. sa'nın yerine kullanıcı adınızı ve 123 yerine şifrenizi girebilirisiniz.
            Database.Connection.ConnectionString = "server=.;database=MVCECommerceProjectDB;uid=sa;pwd=123";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public override int SaveChanges()
        {
            var modifedEntry = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            string user = "Visitor";
            string ip = "";

            if (HttpContext.Current == null)
            {
                ip = "192.168.1.1";
            }
            else
            {
                ip = HttpContext.Current.Request.UserHostAddress.ToString();
            }

            foreach (var item in modifedEntry)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedADUsername = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = dateTime;
                        if (entity.CreatedBy == null)
                        {
                            entity.CreatedBy = user;
                        }
                        entity.CreatedIP = ip;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedADUsername = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = dateTime;
                        if (entity.ModifiedBy == null)
                        {
                            entity.ModifiedBy = user;
                        }
                        entity.ModifiedIP = ip;
                    }
                }
            }

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
        //public System.Data.Entity.DbSet<MVCECommerceProject.MODEL.CartModel.CartItem> CartItems { get; set; }
    }
}