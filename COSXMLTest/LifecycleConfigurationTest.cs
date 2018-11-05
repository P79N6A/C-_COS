using COSXML.Model.Tag;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using COSXML.Common;
using COSXML.Utils;


namespace COSXMLTest
{
    
    
    /// <summary>
    ///This is a test class for LifecycleConfigurationTest and is intended
    ///to contain all LifecycleConfigurationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LifecycleConfigurationTest
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
        ///A test for LifecycleConfiguration Constructor
        ///</summary>
        [TestMethod()]
        public void LifecycleConfigurationConstructorTest()
        {
            LifecycleConfiguration target = new LifecycleConfiguration();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetInfo
        ///</summary>
        [TestMethod()]
        public void GetInfoTest()
        {
            LifecycleConfiguration target = new LifecycleConfiguration(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetInfo();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
        [TestMethod]
        public void testLifeCycleConfig()
        {
            LifecycleConfiguration lifeCycleConfig = new LifecycleConfiguration();
            lifeCycleConfig.rules = new System.Collections.Generic.List<LifecycleConfiguration.Rule>();
            for (int i = 0; i < 3; i++)
            {
                LifecycleConfiguration.Rule rule = new LifecycleConfiguration.Rule();
                rule.id = String.Format("the {0}th", i + 1);
                rule.filter = new LifecycleConfiguration.Filter();
                rule.filter.prefix = "filter prefix";
                rule.status = "Enabled";
                rule.abortIncompleteMultiUpload = new LifecycleConfiguration.AbortIncompleteMultiUpload();
                rule.abortIncompleteMultiUpload.daysAfterInitiation = 2;
                rule.expiration = new LifecycleConfiguration.Expiration();
                rule.expiration.date = DateTime.Now.ToString();
                rule.expiration.days = 2;
                rule.transition = new LifecycleConfiguration.Transition();
                rule.transition.date = DateTime.Now.ToString();
                rule.transition.days = 2;
                rule.noncurrentVersionExpiration = new LifecycleConfiguration.NoncurrentVersionExpiration();
                rule.noncurrentVersionExpiration.noncurrentDays = 2;
                rule.noncurrentVersionTransition = new LifecycleConfiguration.NoncurrentVersionTransition();
                rule.noncurrentVersionTransition.noncurrentDays = 2;
                rule.noncurrentVersionTransition.storageClass = EnumUtils.GetValue(CosStorageClass.STANDARD);
                lifeCycleConfig.rules.Add(rule);
            }
        }
    }
}
