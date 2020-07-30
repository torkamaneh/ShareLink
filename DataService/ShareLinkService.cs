using DataAccess.IRepositories;
using DataService.IDataService;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

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
        public LinkModelRes AddUrl(LinkModelReq model)
        {
            var linkModel = new LinkModel();
            linkModel.Url = model.Url;
            linkModel.ShortLink = Guid.NewGuid();
            base.Add(linkModel);
            return new LinkModelRes
            {
                ShortLink = linkModel.ShortLink
            };
         }
        public RedirectResModel RedirectUrl(RedirectReqModel model)
        {
            RedirectResModel result = null;
               var linkModel = _linkModelRepository.GetUrlByShortLink(model.ShortLink);
            if(linkModel != null)
            {
                linkModel.VisitorCount++;
                base.Update(linkModel);
                result = new RedirectResModel
                {
                    Url = linkModel.Url
                };
                return result;
            }
            else
            {
                return null;
            }
        }
}
}
