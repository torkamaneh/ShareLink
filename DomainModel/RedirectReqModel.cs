using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
   public class RedirectReqModel
    {
        public Guid ShortLink { get; set; }
    }
    public class RedirectResModel
    {
        public string Url { get; set; }
        public HttpStatusEnum Status { get; set; }
    }
}
