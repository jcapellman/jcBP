using System;
using System.Collections.Generic;
using System.Linq;

using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Posts.DataLayer.Entities;
using jcMSA.Posts.PCL.Transports;
using Microsoft.Data.Entity;

namespace jcMSA.Posts.BusinessLogic.Managers {
    public class PostListingManager {
        public ReturnSet<List<PostListingResponseItem>> GetPostListing() {
            using (var eFactory = new EFModel()) {
                var postListing = eFactory.Set<PostListing>().FromSql("POSTS_getPostListingSP").ToList();

                if (postListing == null) {
                    throw new Exception("SP in getting posts returned null");
                }

                return new ReturnSet<List<PostListingResponseItem>>(postListing.Select(a => new PostListingResponseItem {
                    PostDate = a.Created.DateTime, Title = a.Title, URL = a.SafeURL
                }).ToList());
            }
        }
    }
}