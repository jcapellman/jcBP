using System.Linq;

using jcMSA.Common.PCL.Enums;
using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Posts.DataLayer.Entities;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.BusinessLogic.Managers {
    public class ContentPostManager {
        public ReturnSet<ContentResponseItem> GetContentPost(string postname) {
            using (var eFactory = new EFModel()) {                
                var result = eFactory.ContentPosts.FirstOrDefault(a => a.URLSafename == postname);

                if (result == null) {
                    return new ReturnSet<ContentResponseItem>(ErrorCodes.UNCATEGORIZED);
                }

                var response = new ContentResponseItem {
                    Body = result.Body,
                    Title = result.Title
                };

                return new ReturnSet<ContentResponseItem>(response);
            }
        }
    }
}