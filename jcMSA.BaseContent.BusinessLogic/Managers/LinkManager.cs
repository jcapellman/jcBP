using System.Collections.Generic;
using System.Linq;

using jcMSA.BaseContent.DataLayer.Entities;
using jcMSA.BaseContent.PCL.Transports;
using jcMSA.Common.PCL.Transports.Container;

namespace jcMSA.BaseContent.BusinessLogic.Managers {
    public class LinkManager {
        public ReturnSet<List<LinkResponseItem>> GetLinks() {
            using (var eFactory = new EFModel()) {
                var result = eFactory.Database.SqlQuery<BASECONTENT_getLinksSP>("BASECONTENT_getLinksSP").ToList();
                
                return new ReturnSet<List<LinkResponseItem>>(result.Select(a => new LinkResponseItem {
                    DisplayText = a.Description,
                    URL = a.URL
                }).ToList());
            }
        } 
    }
}