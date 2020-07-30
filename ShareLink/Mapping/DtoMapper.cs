using AutoMapper;
using DomainModel;
using ShareLink.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Mapping
{
    public class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<LinkReqDto, LinkModelReq>();
            CreateMap<LinkModelRes, LinkResDto>();
        }
    }
}
