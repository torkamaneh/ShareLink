using DataAccess.IRepositories;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class ShareLinkRepository : Repository<LinkModel>, IShareLinkRepository
    {
        public ShareLinkRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public LinkModel GetUrlByShortLink(Guid shortLink)
        {
            var entity = _entities.FirstOrDefault(x => x.ShortLink == shortLink);
            return entity;
        }
    }
}
