﻿using Microsoft.AspNetCore.Mvc;
using Products.Interface;
using System.Threading.Tasks;

namespace Products.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService service;

        public MovieController(IMovieService service)
        {
            this.service = service;
        }

        [HttpGet("{provider}")]
        public async Task<IActionResult> GetAll([FromRoute] string provider)
        {
            if (string.IsNullOrEmpty(provider))
                return BadRequest("Provider is required");

            var items = await service.GetAll(provider);

            return new OkObjectResult(items);
        }

        [HttpGet("{provider}/{id}")]
        public async Task<IActionResult> Get([FromRoute] string provider, [FromRoute] string id)
        {
            if (string.IsNullOrEmpty(provider))
                return BadRequest("Provider is required");

            if (string.IsNullOrEmpty(id))
                return BadRequest("Movie ID is required");

            var item = await service.Get(provider, id);

            return new OkObjectResult(item);
        }
    }
}