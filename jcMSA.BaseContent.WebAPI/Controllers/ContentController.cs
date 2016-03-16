using System;
using System.Collections.Generic;
using jcMSA.BaseContent.BusinessLogic.Managers;
using jcMSA.BaseContent.PCL.Transports;
using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Common.WebAPI;

namespace jcMSA.BaseContent.WebAPI.Controllers {
    public class ContentController : BaseController {
        public ReturnSet<GlobalContentResponseItem> GET() {
            var globalContent = new GlobalContentResponseItem();

            var linkResult = new LinkManager(APIWrapper).GetLinks();

            if (linkResult.HasError) {
                throw new Exception(linkResult.Exception);
            }

            globalContent.Links = linkResult.ReturnValue;

            globalContent.ArchiveList = new List<ArchiveResponseItem>();
            globalContent.TagCloud = new List<TagCloudResponseItem>();

            return new ReturnSet<GlobalContentResponseItem>(globalContent);
        }
    }
}