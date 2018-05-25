using Xamarin.Forms;

namespace BouquetOfPain
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page aboutPage;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    aboutPage.Icon = "tab_about.png";
                    break;

                default:
                    aboutPage = new AboutPage
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}