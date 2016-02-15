using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using jcMSA.BaseContent.PCL.Handlers;
using jcMSA.BaseContent.PCL.Transports;
using jcMSA.Client.MVC.Enums;
using jcMSA.Client.MVC.Helpers;
using jcMSA.Client.MVC.Managers;

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

            ViewBag.Title = SiteConfig.SITE_NAME;
        }

        private async void LoadData() {
            if (CacheManager.CheckIfExists(CacheItems.GLOBALCONTENT_DATA)) {
                ViewBag.GlobalContent = CacheManager.Get<GlobalContentResponseItem>(CacheItems.GLOBALCONTENT_DATA).ReturnValue;
            }

            var gcHandler = new GlobalContentHandler(SiteConfig.BASECONTENT_WEBAPI);

            var result = await gcHandler.GetGlobalContent();

            if (!result.HasValue) {
                throw new Exception(result.Exception);
            }

            CacheManager.Add(CacheItems.GLOBALCONTENT_DATA, result.ReturnValue);

            result.ReturnValue.TagCloud = processTagCloud(result.ReturnValue.TagCloud);

            ViewBag.GlobalContent = result.ReturnValue;
        }
    }
}