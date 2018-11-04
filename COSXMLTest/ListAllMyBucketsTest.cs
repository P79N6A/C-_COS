using COSXML.Model.Tag;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.IO;
using COSXML.Transfer;
using COSXML.Log;

namespace COSXMLTest
{
    
    
    /// <summary>
    ///This is a test class for ListAllMyBucketsTest and is intended
    ///to contain all ListAllMyBucketsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ListAllMyBucketsTest
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
        ///A test for ListAllMyBuckets Constructor
        ///</summary>
        [TestMethod()]
        public void ListAllMyBucketsConstructorTest()
        {
            ListAllMyBuckets target = new ListAllMyBuckets();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetInfo
        ///</summary>
        [TestMethod()]
        public void GetInfoTest()
        {
            ListAllMyBuckets target = new ListAllMyBuckets(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetInfo();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod]
        public void testParse()
        {
            string content = "<ListAllMyBucketsResult>"
                        + "<Owner>"
                        + " <ID>qcs::cam::uin/1147518609:uin/1147518609</ID>"
                        + "<DisplayName>1147518609</DisplayName>"
                        +" </Owner>"
                        + "<Buckets>"
                            + "<Bucket>"
                                + "<Name>01</Name>"
                                + "<Location>ap-beijing</Location>"
                                + "<CreateDate>2016-09-13 15:20:15</CreateDate>"
                            + "</Bucket>"
                            + "<Bucket>"
                                + "<Name>0111</Name>"
                                + "<Location>ap-hongkong</Location>"
                                + "<CreateDate>2017-01-11 17:23:51</CreateDate>"
                            + "</Bucket>"
                            + "<Bucket>"
                                + "<Name>1201new</Name>"
                                + "<Location>eu-frankfurt</Location>"
                                + "<CreateDate>2016-12-01 09:45:02</CreateDate>"
                            + "</Bucket>"
                        + "</Buckets>"
                    + "</ListAllMyBucketsResult>";

            byte[] bytes = Encoding.ASCII.GetBytes(content);
            MemoryStream memoryStream = new MemoryStream(bytes);
            ListAllMyBuckets result = new ListAllMyBuckets();
            XmlParse.ParseListAllMyBucketsResult(memoryStream, result);
            Assert.AreEqual("qcs::cam::uin/1147518609:uin/1147518609", result.owner.id);
            Assert.AreEqual(3, result.buckets.Count);
 
        }
    }
}
