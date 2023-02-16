﻿using InternationalizationApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace InternationalizationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IStringLocalizer<PostsController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;        
        public PostsController(IStringLocalizer<PostsController> stringLocalizer, IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _sharedResourceLocalizer = sharedResourceLocalizer;
        }
        [HttpGet]
        [Route("PostControllerResource")]
        public IActionResult GetUsingPostControllerResource()
        {
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? string.Empty;
            return Ok(new
            {
                PostType = article.Value,
                PostName=postName,
            });
        }
        [HttpGet]
        [Route("SharedResource")]
        public IActionResult GetUsingSharedResource()
        {
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? string.Empty;
            var todayIs = string.Format(_sharedResourceLocalizer.GetString("Fecha"), DateTime.Now.ToLongDateString());
            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
                Fecha = todayIs,
            });
        }


    }
}
