using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Dto
{
    public class LinkReqDto
    {
        [Required(ErrorMessage = "فیلد آدرس خالی می باشد")]
        public string Url { get; set; }
    }
}
