using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModel
{
    [Table("LinkModel")]
    public class LinkModel :BaseEntity
    {
        [Column(TypeName = "varchar(400)")]
        public string Url { get; set; }
        public Guid ShortLink { get; set; }
        public int VisitorCount { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
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
