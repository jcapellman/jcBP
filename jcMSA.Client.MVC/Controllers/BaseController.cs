using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using jcMSA.BaseContent.PCL.Handlers;
using jcMSA.BaseContent.PCL.Transports;
using jcMSA.Client.MVC.Helpers;

namespace jcMSA.Client.MVC.Controllers {
    public class BaseController : Controller {
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
            LoadData();
        }

        private async void LoadData() {
            var gcHandler = new GlobalContentHandler(RazorHelper.BASECONTENT_WEBAPI);

            var result = await gcHandler.GetGlobalContent();

            if (!result.HasValue) {
                throw new Exception(result.Exception);
            }

            ViewBag.GlobalContent = result.ReturnValue;
        }
    }
}