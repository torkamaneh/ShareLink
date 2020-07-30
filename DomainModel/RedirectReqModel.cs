using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
   public class RedirectReqModel
    {
        public string ShortLink { get; set; }
    }
    public class RedirectResModel
    {
        public string Url { get; set; }
        public ExceptionEnum Status { get; set; }
    }
}
