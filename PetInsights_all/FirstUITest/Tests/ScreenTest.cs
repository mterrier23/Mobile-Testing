using System;
using System.Linq;
using FirstUITest.Pages;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery,
    Xamarin.UITest.Queries.AppQuery>;

namespace FirstUITest.Tests
{
    public class ScreenTest : BaseTestFixture
    {

        public ScreenTest(Platform platform) : base(platform)
        { 
        }

        [Test]
        public void Repl()
        {
            //if (TestEnvironment.IsTestCloud)
              //  Assert.Ignore("Local only");

            app.Repl();
        }

       // [TestCase("Settings")]
       // [TestCase("Artists")]
        //[Category("smoke")] // if you only want to run a certain category of tests


        [Test]
        public void ZipCodeTextIsDisplayed()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query zipCodeLabelQuery = x => x.Marked("GetZipCode");


            // Perform the Query.
            // `app.Query` will return an Array all UI Elements that use "HelloWorldLabel"
            AppResult[] helloWorldLabelQueryResults = app.Query(zipCodeLabelQuery);

            // Because we've only assigned "HelloWorldLabel" to one UI Element, we are confident that the first result in the
            string helloWorldLabelText = helloWorldLabelQueryResults?.FirstOrDefault()?.Text;
            Console.WriteLine("helloWorldLabelText is = " + helloWorldLabelText); // this is null

            // `Assert.AreEqual` tells Xamarin.UITest to compare the expected string, "Welcome to Xamarin Forms!", with the actual string in helloWorldLabelText
            // If the strings are equal, our test will pass.
            // If the strings are not equal, our test will fail.
            Assert.AreEqual("Enter your ZipCode", helloWorldLabelText);
        }

        [Test]
        public void InvalidZipEntered()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId GetZipCode
            Query zipCodeLabelQuery = x => x.Marked("GetZipCode");


            // Perform the Query.
            // `app.Query` will return an Array all UI Elements that use "GetZipCode" from the above query
            AppResult[] helloWorldLabelQueryResults = app.Query(zipCodeLabelQuery);
            app.Repl();
            string helloWorldLabelText = helloWorldLabelQueryResults?.FirstOrDefault()?.Text;

            var inputToValidate = "00000";
            app.EnterText("EnterLocation", inputToValidate);
            app.Tap("FindPetsButton");

            // `Assert.IsTrue` tells Xamarin.UITest to see if the element zipCodeLabelQuery exists 
            //  as user stays on GetZipCode page if invalid zipcode is entered
            Assert.IsTrue(app.Query(zipCodeLabelQuery).Any());
        }

        [Test]
        public void GoodZipEntered()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query zipCodeLabelQuery = x => x.Marked("GetZipCode");
            //Query mainPageLabelQuery = x => x.Marked("MainPageLabel");


            // Perform the Query.
            // `app.Query` will return an Array all UI Elements that use "HelloWorldLabel"
            AppResult[] helloWorldLabelQueryResults = app.Query(zipCodeLabelQuery);
            // Because we've only assigned "HelloWorldLabel" to one UI Element, we are confident that the first result in the
            string helloWorldLabelText = helloWorldLabelQueryResults?.FirstOrDefault()?.Text;


            Query mainPageLabelQuery = x => x.Marked("MainPageLabel");

            var inputToValidate = "45140";
            app.EnterText("EnterLocation", inputToValidate);
            app.Tap("FindPetsButton");

            app.Repl();

            Assert.IsTrue(app.Query(mainPageLabelQuery).Any());
        }

        [Test]
        public void ValidZipEntered()
        { 
            Query mainPageLabelQuery = x => x.Marked("MainPageLabel");

            var inputToValidate = "45140";
            app.EnterText("EnterLocation", inputToValidate);
            app.Tap("FindPetsButton");

            app.Repl();

            Assert.IsTrue(app.Query(mainPageLabelQuery).Any());
        }

        [Test]
        public void FavePageScroll()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query zipCodeLabelQuery = x => x.Marked("GetZipCode");
            Query favePageLabelQuery = x => x.Marked("FavePetsLabel");


            // Perform the Query.
            // `app.Query` will return an Array all UI Elements that use "HelloWorldLabel"
            AppResult[] helloWorldLabelQueryResults = app.Query(zipCodeLabelQuery);
            // Because we've only assigned "HelloWorldLabel" to one UI Element, we are confident that the first result in the
            string helloWorldLabelText = helloWorldLabelQueryResults?.FirstOrDefault()?.Text;

            var inputToValidate = "45140";
            app.EnterText("EnterLocation", inputToValidate);
            app.Repl();
            app.Tap("FindPetsButton");
            app.WaitForElement("MainPageLabel");
            app.SwipeRightToLeft();

            Assert.IsTrue(app.Query(favePageLabelQuery).Any());
        }

        [Test]
        public void BreedPageScroll()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query zipCodeLabelQuery = x => x.Marked("GetZipCode");
            Query breedPageLabelQuery = x => x.Marked("BreedsLabel");


            // Perform the Query.
            // `app.Query` will return an Array all UI Elements that use "HelloWorldLabel"
            AppResult[] helloWorldLabelQueryResults = app.Query(zipCodeLabelQuery);
            // Because we've only assigned "HelloWorldLabel" to one UI Element, we are confident that the first result in the
            string helloWorldLabelText = helloWorldLabelQueryResults?.FirstOrDefault()?.Text;

            var inputToValidate = "45140";
            app.EnterText("EnterLocation", inputToValidate);
            app.Repl();
            app.Tap("FindPetsButton");

            app.SwipeRightToLeft();
            app.SwipeRightToLeft();

            Assert.IsTrue(app.Query(breedPageLabelQuery).Any());
        }

     /*   [Test]
        public void FilterPopupShow()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query zipCodeLabelQuery = x => x.Marked("GetZipCode");
            Query FirstFilterLabelQuery = x => x.Marked("FirstFilterLabel");


            // Perform the Query.
            // `app.Query` will return an Array all UI Elements that use "HelloWorldLabel"
            AppResult[] helloWorldLabelQueryResults = app.Query(zipCodeLabelQuery);
            // Because we've only assigned "HelloWorldLabel" to one UI Element, we are confident that the first result in the
            string helloWorldLabelText = helloWorldLabelQueryResults?.FirstOrDefault()?.Text;

            var inputToValidate = "45140";
            app.EnterText("EnterLocation", inputToValidate);
            app.Repl();
            app.Tap("FindPetsButton");
            app.Tap("FilterButton");

            Assert.IsTrue(app.Query(FirstFilterLabelQuery).Any());
        }
     */

        [Test]
        public void PetListPage()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query PetPageLabelQuery = x => x.Marked("PetListPage");

            var inputToValidate = "45140";
            app.EnterText("EnterLocation", inputToValidate);
            app.Tap("FindPetsButton");
            app.Tap("FilterButton");
            app.WaitForElement(PetPageLabelQuery);
            Assert.IsTrue(app.Query(PetPageLabelQuery).Any());
        }

        [Test]
        public void ShelterListPage()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query zipCodeLabelQuery = x => x.Marked("GetZipCode");
            Query OrgLabelQuery = x => x.Marked("OrgListLabel");


            // Perform the Query.
            // `app.Query` will return an Array all UI Elements that use "HelloWorldLabel"
            AppResult[] helloWorldLabelQueryResults = app.Query(zipCodeLabelQuery);
            // Because we've only assigned "HelloWorldLabel" to one UI Element, we are confident that the first result in the
            string helloWorldLabelText = helloWorldLabelQueryResults?.FirstOrDefault()?.Text;

            var inputToValidate = "45140";
            app.EnterText("EnterLocation", inputToValidate);
            app.Repl();
            app.Tap("FindPetsButton");
            app.Tap("OrgPageButton");   // need to add to apk

            Assert.IsTrue(app.Query(OrgLabelQuery).Any());
        }

        [Test]
        public void VolunteerPage()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query zipCodeLabelQuery = x => x.Marked("GetZipCode");
            Query VolunteerLabelQuery = x => x.Marked("VolunteerLabel");


            // Perform the Query.
            // `app.Query` will return an Array all UI Elements that use "HelloWorldLabel"
            AppResult[] helloWorldLabelQueryResults = app.Query(zipCodeLabelQuery);
            // Because we've only assigned "HelloWorldLabel" to one UI Element, we are confident that the first result in the
            string helloWorldLabelText = helloWorldLabelQueryResults?.FirstOrDefault()?.Text;

            var inputToValidate = "45140";
            app.EnterText("EnterLocation", inputToValidate);
            app.Repl();
            app.Tap("FindPetsButton");
            app.Tap("VolunteerPageButton");   // need to add to apk

            Assert.IsTrue(app.Query(VolunteerLabelQuery).Any());
        }

     

        [Test]
        public void PetPage()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query PetDetailsQuery = x => x.Marked("PetDetailsPageId");

            var inputToValidate = "45140";
            app.EnterText("EnterLocation", inputToValidate);
            app.Tap("FindPetsButton");
            app.Tap("FilterButton");
            app.Tap(x => x.Marked("PetListCollectionView").Child());

            Assert.IsTrue(app.Query(PetDetailsQuery).Any());
        }

        [Test]
        public void MainFilterPopup()
        {
            // Create a Xamarin.UITest that will search for our Label based on its AutomationId
            Query zipCodeLabelQuery = x => x.Marked("GetZipCode");
            Query FilterPopupQuery = x => x.Marked("SecondFilterLabel");


            // Perform the Query.
            // `app.Query` will return an Array all UI Elements that use "HelloWorldLabel"
            AppResult[] helloWorldLabelQueryResults = app.Query(zipCodeLabelQuery);
            // Because we've only assigned "HelloWorldLabel" to one UI Element, we are confident that the first result in the
            string helloWorldLabelText = helloWorldLabelQueryResults?.FirstOrDefault()?.Text;

            var inputToValidate = "45140";
            app.EnterText("EnterLocation", inputToValidate);
            app.Repl();
            app.Tap("FindPetsButton");

            app.Tap("FilterButton");
            app.Tap("FilterButtonId");

            Assert.IsTrue(app.Query(FilterPopupQuery).Any());
        }

    }
}
