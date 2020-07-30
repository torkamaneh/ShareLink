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
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public class LinkModelReq
    {
        public string Url { get; set; }
    }
    public class LinkModelRes
    {
        public Guid ShortLink { get; set; }
    }
}
