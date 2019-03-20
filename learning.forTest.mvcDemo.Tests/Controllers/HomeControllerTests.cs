using learning.common.tests.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace learning.forTest.mvcDemo.Tests.Controllers
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            HttpTestsTool httpTestsTool = HttpTestsTool.GetInstance;
            httpTestsTool.Test("");
        }
    }
}