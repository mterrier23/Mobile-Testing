using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void WelcomeTextIsDisplayed2()
        {
            app.WaitForElement(c => c.Marked("Add"));
            app.Tap(c => c.Marked("Add"));
            app.WaitForElement(c => c.Marked("Cancel"));
            app.Tap(c => c.Marked("Cancel"));
        }

        [Test]
        public void Enter_Creds_And_Tap_Ok()
        {
            app.EnterText(c => c.Marked("username"), "PaulP");
            app.EnterText(c => c.Marked("password"), "test password");
            app.DismissKeyboard();

            app.Tap(c => c.Marked("loginButton"));

            app.WaitForElement(c => c.Marked("Logged In"), "Timed out waiting for Logged In popup");

            app.Tap(c => c.Marked("OK"));
        }
    }
}
