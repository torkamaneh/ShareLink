﻿using AutoMapper;
using DataService.IDataService;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareLink.Dto;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShareLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareLinkController: ControllerBase
    {
        private IShareLinkService _shareLinkService;
        private IMapper _mapper;
        public ShareLinkController(IShareLinkService shareLinkService, IMapper mapper)
        {
            _shareLinkService = shareLinkService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<LinkResDto>> Add(LinkReqDto param)
        {
            var model = _mapper.Map<LinkModelReq>(param);
            var result = await _shareLinkService.AddUrl(model);
            var resProfile = _mapper.Map<LinkResDto>(result);
            return resProfile;
        }
        [HttpGet("{shortLink}")]
        public async Task<ActionResult> RedirectUrl(string shortLink)
        {
           
                var model = new RedirectReqModel
                {
                    ShortLink = shortLink//new Guid(shortLink)
                };
            
            var result = await _shareLinkService.RedirectUrl(model);
            if(result.Status == ExceptionEnum.NotFound)
            {
                return NotFound();
            }
            else if(result.Status == ExceptionEnum.InvalidParameter)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, "لینک ارسالی نادرست می باشد.");
              //  return HttpStatusCode.BadRequest;
            }
            return Redirect(result.Url);
        }
    }
}
