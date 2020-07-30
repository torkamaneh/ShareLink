using DataAccess.IRepositories;
using DataService.IDataService;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class ShareLinkService : BaseService<LinkModel>, IShareLinkService
    {
        private IShareLinkRepository _linkModelRepository;
        public ShareLinkService(IShareLinkRepository linkModelRepository)
          : base(linkModelRepository)
        {
            _linkModelRepository = linkModelRepository;
        }
        public async Task<LinkModelRes> AddUrl(LinkModelReq model)
        {
            var linkModel = new LinkModel();
            linkModel.Url = model.Url;
            linkModel.ShortLink = Guid.NewGuid();
            await base.Add(linkModel);
            return new LinkModelRes
            {
                ShortLink = linkModel.ShortLink
            };
         }
        public async Task<RedirectResModel> RedirectUrl(RedirectReqModel model)
        {
            RedirectResModel result = new RedirectResModel();
               var linkModel = await _linkModelRepository.GetUrlByShortLink(model.ShortLink);
            if(linkModel != null)
            {
                linkModel.VisitorCount++;
               await base.Update(linkModel);
                result.Url = linkModel.Url;
            }
            else
            {
                result.Status = HttpStatusEnum.NotFound;
            }
            return result;
        }
}
}
