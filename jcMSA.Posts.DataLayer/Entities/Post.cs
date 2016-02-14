namespace jcMSA.Posts.DataLayer.Entities {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Post {
        public int ID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public int AuthorUserID { get; set; }

        [Required]
        public string PostContent { get; set; }

        [Required]
        [StringLength(255)]
        public string URL { get; set; }

        [Required]
        [StringLength(255)]
        public string SafeURL { get; set; }
    }
}
