using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.IDataService
{
    public interface IShareLinkService : IBaseService<LinkModel>
    {
        Task<LinkModelRes> AddUrl(LinkModelReq model);
        Task<RedirectResModel> RedirectUrl(RedirectReqModel model);
    }
}
