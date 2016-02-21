using System;
using System.Collections.Generic;
using System.Linq;

using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Posts.DataLayer.Entities;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.BusinessLogic.Managers {
    public class PostListingManager {
        public ReturnSet<List<PostListingResponseItem>> GetPostListing() {
            using (var eFactory = new EFModel()) {
                var postListing = eFactory.Database.SqlQuery<PostListingResponseItem>("POSTS_getPostListingSP");

                if (postListing == null) {
                    throw new Exception("SP in getting posts returned null");
                }

                return new ReturnSet<List<PostListingResponseItem>>(postListing.Select(a => new PostListingResponseItem {
                    PostDate = a.PostDate,
                    Title = a.Title,
                    URL = a.URL,
                    Summary = a.Summary
                }).ToList());
            }
        }
    }
}