using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery,
    Xamarin.UITest.Queries.AppQuery>;

namespace FirstUITest.Pages
{
    public class HomePage : BasePage
    {
        //readonly Query deleteButton;
        //readonly Func<string, Query> checkMarkForTask;

        protected override PlatformQuery Trait => new
            PlatformQuery
        {
            Android = x => x.Marked("MiniPlayer")
        };

        public HomePage()
        {
            if (OnAndroid)
            {

            }
        }
    }
}
