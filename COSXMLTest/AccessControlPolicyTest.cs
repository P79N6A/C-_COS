using COSXML.Model.Tag;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace COSXMLTest
{
    
    
    /// <summary>
    ///This is a test class for AccessControlPolicyTest and is intended
    ///to contain all AccessControlPolicyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccessControlPolicyTest
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
        ///A test for AccessControlPolicy Constructor
        ///</summary>
        [TestMethod()]
        public void AccessControlPolicyConstructorTest()
        {
            AccessControlPolicy target = new AccessControlPolicy();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetInfo
        ///</summary>
        [TestMethod()]
        public void GetInfoTest()
        {
            AccessControlPolicy target = new AccessControlPolicy(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetInfo();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod]
        public void testAccessControlPolicy()
        {
            AccessControlPolicy accessControlPolicy = new AccessControlPolicy();
            accessControlPolicy.owner = new AccessControlPolicy.Owner();
            accessControlPolicy.accessControlList = new AccessControlPolicy.AccessControlList();
            accessControlPolicy.accessControlList.grants = new List<AccessControlPolicy.Grant>();
            accessControlPolicy.owner.id = "qcs::cam::uin/<OwnerUin>:uin/<SubUin>";
            accessControlPolicy.owner.displayName = "qcs::cam::uin/<OwnerUin>:uin/<SubUin>";
            for (int i = 0; i < 3; i++)
            {
                AccessControlPolicy.Grant grant = new AccessControlPolicy.Grant();
                grant.grantee = new AccessControlPolicy.Grantee();
                grant.grantee.id = "qcs::cam::uin/<OwnerUin>:uin/<SubUin>";
                grant.grantee.displayName = "qcs::cam::uin/<OwnerUin>:uin/<SubUin>";
                grant.permission = "permission";
                accessControlPolicy.accessControlList.grants.Add(grant);
            }

        }
    }
}
