namespace jcMSA.Posts.DataLayer.Entities {
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class Post {
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

        [Required]
        [StringLength(255)]
        public string Summary { get; set; }
    }
}