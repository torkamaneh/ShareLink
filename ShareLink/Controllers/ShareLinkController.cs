using AutoMapper;
using DataService.IDataService;
using DomainModel;
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
        [HttpPost("AddUrl")]
        public async Task<LinkResDto> AddUrl(LinkReqDto param)
        {
            var model = _mapper.Map<LinkModelReq>(param);
            var result = await _shareLinkService.AddUrl(model);
            var resProfile = _mapper.Map<LinkResDto>(result);
            return resProfile;
        }
        [HttpGet("Redirect/{shortLink}")]
        public async Task<IActionResult> RedirectUrl(string shortLink)
        {
            var model = new RedirectReqModel
            {
                ShortLink = new Guid(shortLink)
        };
            var result = await _shareLinkService.RedirectUrl(model);
            if(result.Status == HttpStatusEnum.NotFound)
            {
                return NotFound();
               // return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return Redirect(result.Url);
        }
    }
}
