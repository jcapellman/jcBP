using System.Data.Entity;

namespace jcMSA.Posts.DataLayer.Entities {
    public class EFModel : DbContext {
        public EFModel() : base("EFModel") { }

        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Post>()
                .Property(e => e.Title);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostContent);

            modelBuilder.Entity<Post>()
                .Property(e => e.URL);

            modelBuilder.Entity<Post>()
                .Property(e => e.SafeURL);
        }
    }
}