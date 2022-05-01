using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System.Net;
using UrlShortner.Common;
using UrlShortner.Models;
using System;
using UrlShortner.Service.Database;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortner.Service.Controllers
{
    [Route("/")]
    [ApiController]
    public class UriController : ControllerBase
    {
        private readonly IContextTest _mongoContext;


        public UriController(IContextTest mongoDBContext)
        {
            _mongoContext = mongoDBContext;

        }

        //public UriController(TestDBContext mongoDBContext)
        //{
        //    _mongoContext = mongoDBContext;

        //}


        private static string MakeToken()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }

        private bool ValidateToken(string token)
        {
            if (token.Length != 11)
            {
                return false;
            }

            else return true;
        }
        
        [HttpGet("uri/{token}")]
        public async Task<ActionResult<string>> GetRedirectUri(string token)
        {
            if (token != "")
            {
                if (ValidateToken(token))
                {
                    try
                    {
                        var url = await _mongoContext.GetAsync(token);
                        return (url.url);
                    }
                    catch (Exception ex)
                    {
                        return (ex.Message);
                    }
                }
            }
            return "null token";
        }


        // GET /token
        [HttpGet("{token}")]
        public async Task<ActionResult> RedirectMe(string token)
        {
           if (token != "")
            {
                if (ValidateToken(token))
                {
                    try
                    {
                        var url = await _mongoContext.GetAsync(token);
                        return Redirect(url.url);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            return BadRequest();
        }

        // POST api/<UriController>
        [HttpPost("shorten")]
        public async Task<string> ShortenUrl([FromBody] string value)
        {
            if (value.ToLower().StartsWith("http") == false)
                value = $"http://{value}";



            var shortUrl = new ShortenedUrl()
            {
                url = value,
                token = MakeToken()
            };

            await _mongoContext.InsertAsync(shortUrl);

            return shortUrl.token;
            
        }


    }
}
