using COSXML.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using COSXML.Mdel.Tag;

namespace COSXMLTest
{
    
    
    /// <summary>
    ///This is a test class for GrantAccountTest and is intended
    ///to contain all GrantAccountTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GrantAccountTest
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
        ///A test for GrantAccount Constructor
        ///</summary>
        [TestMethod()]
        public void GrantAccountConstructorTest()
        {
            GrantAccount target = new GrantAccount();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddGrantAccount
        ///</summary>
        [TestMethod()]
        public void AddGrantAccountTest()
        {
            GrantAccount target = new GrantAccount(); // TODO: Initialize to an appropriate value
            string ownerUin = string.Empty; // TODO: Initialize to an appropriate value
            string subUin = string.Empty; // TODO: Initialize to an appropriate value
            target.AddGrantAccount(ownerUin, subUin);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetGrantAccounts
        ///</summary>
        [TestMethod()]
        public void GetGrantAccountsTest()
        {
            GrantAccount target = new GrantAccount(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetGrantAccounts();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
        [TestMethod]
        public void testGrantAccount()
        {
            GrantAccount grantAccount = new GrantAccount();
            grantAccount.AddGrantAccount("1131975903", "1131975903");


        }
    }
}
