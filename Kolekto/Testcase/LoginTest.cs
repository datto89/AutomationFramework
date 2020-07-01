using AutomationFramework.Base;
using AutomationFramework.Reports;
using Kolekto.Module;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kolekto.Testcase
{
    [TestFixture]
    public class LoginTest : TestBase
    {
        private LoginModule loginModule = new LoginModule();

        [SetUp]
        public void Setup()
        {
            StartApplication(loginModule);
            LogInToSystem("dat.to@kolekto.nl", "Qe1982198");
        }

        [TearDown]
        public void TearDown()
        {
            LogOut();
            Reports.GenerateReport();
        }

        [Test]
        public void LogInTest()
        {
            Reports.CurrentTest.Info($"LoginTest");
        }
    }
}
