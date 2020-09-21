using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNewsChallenge.Services
{
    public class StoryService
    {

        private HttpClient _client = new HttpClient();
        private readonly string _baseAddress = "https://hacker-news.firebaseio.com/v0/";
        private readonly string _printPretty = ".json?print=pretty";



        public StoryService()
        {
            _client.BaseAddress = new Uri(_baseAddress);
        }

        public async Task<StoryDetails[]> getStories()
        {
            int[] storyIDs = null;
            List<StoryDetails> stories = new List<StoryDetails>();


            HttpResponseMessage response = await _client.GetAsync($"newstories{_printPretty}");
            if (response.IsSuccessStatusCode)
            {
                storyIDs = await response.Content.ReadAsAsync<int[]>();
            }

            int storyCount = 0;


            foreach (int id in storyIDs)
            {
                storyCount++;
                HttpResponseMessage storyResponse = await _client.GetAsync($"item/{id}{_printPretty}");
  
                try
                {
                    var jsonString = await storyResponse.Content.ReadAsStringAsync();
                    StoryDetails storyObj = JsonConvert.DeserializeObject<StoryDetails>(jsonString);
                    stories.Add(storyObj);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
                if (storyCount >= 200) break;

            }

            return stories.ToArray();
        }

        public async Task<string> getStoryIds()
        {
            HttpResponseMessage response = await _client.GetAsync($"newstories{_printPretty}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> getSingleStoryDetails(int id)
        {
            HttpResponseMessage storyResponse = await _client.GetAsync($"item/{id}{_printPretty}");
            return await storyResponse.Content.ReadAsStringAsync();
        }
    }
}
