using DataAccess.IRepositories;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class LinkModelRepository : Repository<LinkModel>, ILinkModelRepository
    {
        public LinkModelRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public LinkModel GetUrlByShortLink(Guid shortLink)
        {
            throw new NotImplementedException();
        }
    }
}
