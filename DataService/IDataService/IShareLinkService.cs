using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.IDataService
{
    public interface IShareLinkService : IBaseService<LinkModel>
    {
        LinkModelRes AddUrl(LinkModelReq model);
        RedirectResModel RedirectUrl(RedirectReqModel model);
    }
}
