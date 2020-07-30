﻿using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.IRepositories
{
    public interface IShareLinkRepository : IRepository<LinkModel>
    {
        LinkModel GetUrlByShortLink(Guid shortLink);
    }
}