using System;

namespace jcMSA.Posts.DataLayer.Entities {
    public class PostListing {

        public DateTimeOffset Created { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string SafeURL { get; set; }

        public int ID { get; set; }
    }
}