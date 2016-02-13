namespace jcMSA.Posts.DataLayer.Entities {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFModel : DbContext {
        public EFModel()
            : base("name=EFModel1") {
        }

        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Post>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PostContent)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.SafeURL)
                .IsUnicode(false);
        }
    }
}
