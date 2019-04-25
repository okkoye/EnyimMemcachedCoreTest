using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enyim.Caching;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace memcached_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMemcachedClient _client;
        private readonly static string TEST_CACHE_KEY = "TEST_CACHE_KEY";
        private readonly static int TEST_CACHE = 1111;
        public ValuesController(IMemcachedClient client)
        {
            _client = client;
        }

        [HttpGet]
        public IActionResult GetCache()
        {
            var value = _client.Get<int>(TEST_CACHE_KEY);
            if (value != TEST_CACHE)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok();
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetCacheAsync()
        {
            var cache = await _client.GetAsync<int>(TEST_CACHE_KEY);
            if (cache.Value != TEST_CACHE)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _client.AddAsync(TEST_CACHE_KEY, TEST_CACHE, 3600 * 24);
            return Ok();
        }
    }
}
