using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using jcMSA.BaseContent.PCL.Transports;

namespace jcMSA.Client.MVC.Controllers {
    public class BaseController : Controller {
        protected GlobalContentResponseItem globalContent = new GlobalContentResponseItem();

        private List<TagCloudResponseItem> processTagCloud(List<TagCloudResponseItem> tagItems) {
            var startingLevel = 10;

            foreach (var tag in tagItems) {
                tag.CSSClassName = "TagItem" + startingLevel;

                if (startingLevel > 1) {
                    startingLevel--;
                }
            }

            return tagItems.OrderBy(a => a.DisplayName).ToList();
        }

        public BaseController() {
            ViewBag.GlobalContent = globalContent;
        }
    }
}