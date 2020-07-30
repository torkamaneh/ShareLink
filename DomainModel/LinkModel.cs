using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class LinkModel :BaseEntity
    {
        public string Url { get; set; }
        public Guid ShortLink { get; set; }
        public int VisitorCount { get; set; }
    }
}
