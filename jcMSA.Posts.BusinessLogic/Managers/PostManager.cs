using System;
using System.Collections.Generic;
using System.Linq;

using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Common.PCL.Transports.Internal;
using jcMSA.Common.WebAPI;
using jcMSA.Posts.DataLayer.Entities;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.BusinessLogic.Managers {
    public class PostManager : BaseManager {
        public ReturnSet<PostResponseItem> GetPost(int id) {
            using (var eFactory = new EFModel()) {
                var post = eFactory.Posts.FirstOrDefault(a => a.ID == id);

                if (post == null) {
                    throw new Exception($"Could not get Post {id}");
                }

                return new ReturnSet<PostResponseItem>(new PostResponseItem {
                    Body = post.Body,
                    Title = post.Title,
                    PostDate = post.Created,
                    Tags = new List<TagResponseItem>()
                });
            }
        }

        public ReturnSet<PostResponseItem> GetPost(int year, int month, int day, string posturl) {
            using (var eFactory = new EFModel()) {
                var postKey = $"{year}/{month}/{day}/{posturl}";

                var post = eFactory.DGTPostKeys.FirstOrDefault(a => a.PostKey == postKey);

                if (post == null) {
                    throw new Exception($"Could not get Post {postKey}");
                }

                return GetPost(post.PostID);
            }
        }

        public ReturnSet<bool> AddPost(PostCreationRequestItem requestItem) {
            using (var eFactory = new EFModel()) {
                var post = eFactory.Posts.Create();

                post.Active = true;
                post.Created = DateTime.Now;
                post.Modified = DateTime.Now;
                post.Body = requestItem.Body;
                post.Summary = requestItem.Body.Length > 255 ? requestItem.Body.Substring(0, 252) + "..." : requestItem.Body;
                post.Title = requestItem.Title;
                post.SafeURL = requestItem.Title.Replace(" ", "-");

                eFactory.Posts.Add(post);
                eFactory.SaveChanges();

                var key = eFactory.DGTPostKeys.Create();

                key.PostID = post.ID;
                key.PostKey = $"{post.Created.Year}_{post.Created.Month}_{post.Created.Day}_{post.SafeURL}";

                eFactory.DGTPostKeys.Add(key);
                eFactory.SaveChanges();

                return new ReturnSet<bool>(true);
            }
        }

        public PostManager(APIRequestWrapper requestWrapper) : base(requestWrapper) { }
    }
}