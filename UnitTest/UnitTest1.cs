using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackerNewsChallenge.Services;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        StoryService storyService = new StoryService();


        [TestMethod]
        public void TestStoryList()
        {
            var testResponse = storyService.getStoryIds();
            Assert.IsTrue(testResponse != null);
        }

        [TestMethod]
        public void TestStoryDetails()
        {
            var testResponse = storyService.getSingleStoryDetails(1);
            Assert.IsTrue(testResponse != null);
        }

    }
}
