using FormDemo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace FormDemo.DAL
{
    public class FormContext : DbContext
    {

        public FormContext() : base("FormContext")
        {
        }

        public DbSet<FormModel> NewsletterSignUps { get; set; }

        public DbSet<HearAboutOptionModel> HearAboutOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}