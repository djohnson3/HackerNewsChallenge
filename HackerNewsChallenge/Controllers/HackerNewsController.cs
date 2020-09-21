using System;
using System.Threading.Tasks;
using HackerNewsChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsChallenge.Controllers
{
    [Route("api/[controller]")]
    public class HackerNewsController : Controller
    {

        private IMemoryCache _cache;

        public HackerNewsController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        [HttpGet("[action]")]
        public async Task<StoryDetails[]> getStoryList()
        {
            StoryService storyService = new StoryService();
            StoryDetails[] stories= null;

            if (!_cache.TryGetValue(StoryCache.Id, out stories))
            {
                stories = await storyService.getStories();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(300));

                _cache.Set(StoryCache.Id, stories, cacheEntryOptions);
            }

            return stories;            
        }

    }
}
