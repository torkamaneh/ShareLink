using DataAccess.IRepositories;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ShareLinkRepository : Repository<LinkModel>, IShareLinkRepository
    {
        public ShareLinkRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<LinkModel> GetUrlByShortLink(Guid shortLink)
        {
            var entity = await _entities.FirstOrDefaultAsync(x => x.ShortLink == shortLink);
            return entity;
        }
    }
}
