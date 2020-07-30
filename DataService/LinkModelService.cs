using DataAccess.IRepositories;
using DataService.IDataService;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
    public class LinkModelService : BaseService<LinkModel>, ILinkModelService
    {
        private ILinkModelRepository _linkModelRepository;
        public LinkModelService(ILinkModelRepository linkModelRepository)
          : base(linkModelRepository)
        {
            _linkModelRepository = linkModelRepository;
        }
    }
}
