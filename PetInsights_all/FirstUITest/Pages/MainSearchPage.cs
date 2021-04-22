using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUITest.Pages
{
    public class MainSearchPage : BasePage
    {
        public MainSearchPage()
        {

        }

        protected override PlatformQuery Trait => new
               PlatformQuery
        {
            Android = x => x.Marked("mainSearchPage")
        };

    }
}
