using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using jcMSA.BaseContent.PCL.Handlers;
using jcMSA.BaseContent.PCL.Transports;
using jcMSA.Client.MVC.Helpers;
using jcMSA.Client.MVC.PlatformImplementations;

namespace jcMSA.Client.MVC.Controllers {
    public class BaseController : Controller {
        protected WebCachePI _webCache;
               
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
            _webCache = new WebCachePI();

            LoadData();

            ViewBag.Title = SiteConfig.SITE_NAME;
        }

        private async void LoadData() {
            var gcHandler = new GlobalContentHandler(SiteConfig.BASECONTENT_WEBAPI_ADDRESS, _webCache);

            var result = await gcHandler.GetGlobalContent();

            if (result.HasError) {
                throw new Exception(result.Exception);
            }

            result.ReturnValue.TagCloud = processTagCloud(result.ReturnValue.TagCloud);

            ViewBag.GlobalContent = result.ReturnValue;
        }
    }
}