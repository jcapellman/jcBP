using System;
using System.Collections.Generic;
using System.Linq;

using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Posts.DataLayer.Entities;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.BusinessLogic.Managers {
    public class PostManager {
        public ReturnSet<PostResponseItem> GetPost(int id) {
            using (var eFactory = new EFModel()) {
                var post = eFactory.Posts.FirstOrDefault(a => a.ID == id);

                if (post == null) {
                    throw new Exception($"Could not get Post {id}");
                }

                return new ReturnSet<PostResponseItem>(new PostResponseItem {
                    Body = post.PostContent,
                    Title = post.Title,
                    PostDate = post.Created.DateTime,
                    Tags = new List<TagResponseItem>()
                });
            }
        }

        public ReturnSet<PostResponseItem> GetPost(int year, int month, int day, string posturl) {
            using (var eFactory = new EFModel()) {
                var postKey = $"{year}_{month}_{day}_{posturl}";

                var post = eFactory.PostKeys.FirstOrDefault(a => a.PostKey == postKey);

                if (post == null) {
                    throw new Exception($"Could not get Post {postKey}");
                }

                return GetPost(post.PostID);
            }
        }
    }
}