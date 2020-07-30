using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface IShareLinkRepository : IRepository<LinkModel>
    {
        Task<LinkModel> GetUrlByShortLink(Guid shortLink);
       
    }
}
