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
            linkModel.CreateDate = DateTime.Now;
            await base.Add(linkModel);
            return new LinkModelRes
            {
                ShortLink = linkModel.ShortLink
            };
        }
        public async Task<RedirectResModel> RedirectUrl(RedirectReqModel model)
        {
            LinkModel linkModel = null;
            RedirectResModel result = new RedirectResModel();
            //var shortUrl = "";//new Guid(model.ShortLink);
            var isValid = Guid.TryParse(model.ShortLink, out Guid guid);
            if (isValid)
            {
                linkModel = await _linkModelRepository.GetUrlByShortLink(guid);

                if (linkModel != null)
                {
                    linkModel.VisitorCount++;
                    linkModel.UpdateDate = DateTime.Now;
                    await base.Update(linkModel);
                    result.Url = linkModel.Url;
                }
                else
                {
                    result.Status = ExceptionEnum.NotFound;
                }
            }

            else
            {
                result.Status = ExceptionEnum.InvalidParameter;
            }

            return result;
        }
    }
}
