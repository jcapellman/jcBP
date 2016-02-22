namespace jcMSA.BaseContent.DataLayer.Entities {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFModel : DbContext {
        public EFModel()
            : base("name=EFModel") {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        }
    }
}
