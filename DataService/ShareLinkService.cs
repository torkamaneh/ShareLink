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
    }
}
