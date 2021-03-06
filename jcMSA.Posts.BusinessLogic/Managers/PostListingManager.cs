﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Common.PCL.Transports.Internal;
using jcMSA.Common.WebAPI;
using jcMSA.Posts.DataLayer.Entities;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.BusinessLogic.Managers {
    public class PostListingManager : BaseManager {
        public ReturnSet<List<PostListingResponseItem>> GetPostListing(int pageSize, int? pageNumber = null) {
            using (var eFactory = new EFModel()) {
                var postListing = eFactory.Database.SqlQuery<PostListing>("POSTS_getPostListingSP @pageSize, @pageNumber", new SqlParameter("@pageSize", pageSize), new SqlParameter("@pageNumber", pageNumber.HasValue ? pageNumber.ToString() : ""));

                if (postListing == null) {
                    throw new Exception("SP in getting posts returned null");
                }

                return new ReturnSet<List<PostListingResponseItem>>(postListing.Select(a => new PostListingResponseItem {
                    ID = a.ID,
                    PostDate = a.Created,
                    Title = a.Title,
                    URL = a.SafeURL,
                    Summary = a.Summary
                }).ToList());
            }
        }

        public PostListingManager(APIRequestWrapper requestWrapper) : base(requestWrapper) { }
    }
}