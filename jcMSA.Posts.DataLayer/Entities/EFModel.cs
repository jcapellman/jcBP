using System.Data.Entity;

namespace jcMSA.Posts.DataLayer.Entities {
    public class EFModel : DbContext {
        public EFModel() : base("EFModel") { }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual  DbSet<DGT_PostKeys> DGTPostKeys { get; set; }

        public virtual DbSet<Content> ContentPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

        }
    }
}