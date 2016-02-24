namespace jcMSA.Posts.DataLayer.Entities {
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class Post {
        public int ID { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public int PostedByUserID { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [StringLength(255)]
        public string SafeURL { get; set; }

        [Required]
        [StringLength(255)]
        public string Summary { get; set; }
    }
}