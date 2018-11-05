using COSXML.Model.Tag;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace COSXMLTest
{
    
    
    /// <summary>
    ///This is a test class for CORSConfigurationTest and is intended
    ///to contain all CORSConfigurationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CORSConfigurationTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CORSConfiguration Constructor
        ///</summary>
        [TestMethod()]
        public void CORSConfigurationConstructorTest()
        {
            CORSConfiguration target = new CORSConfiguration();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetInfo
        ///</summary>
        [TestMethod()]
        public void GetInfoTest()
        {
            CORSConfiguration target = new CORSConfiguration(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetInfo();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        public void testCORSConfig()
        {
            CORSConfiguration corsConfig = new CORSConfiguration();
            corsConfig.corsRules = new System.Collections.Generic.List<CORSConfiguration.CORSRule>();
            for (int i = 0; i < 3; i++)
            {
                CORSConfiguration.CORSRule corsRule = new CORSConfiguration.CORSRule();
                corsRule.id = String.Format("the {0}th", i + 1);
                corsRule.maxAgeSeconds = 5000;
                corsRule.allowedMethods = new System.Collections.Generic.List<string>();
                corsRule.allowedMethods.Add("PUT");
                corsRule.allowedMethods.Add("DELETE");

                corsRule.allowedHeaders = new System.Collections.Generic.List<string>();
                corsRule.allowedHeaders.Add("Host");
                corsRule.allowedHeaders.Add("Authorization");

                corsRule.exposeHeaders = new System.Collections.Generic.List<string>();
                corsRule.exposeHeaders.Add("X-COS-Meta1");
                corsRule.exposeHeaders.Add("X-COS-Meta2");

                corsConfig.corsRules.Add(corsRule);
            }
        }
    }
}
