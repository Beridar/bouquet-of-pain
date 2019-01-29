using BouquetOfPain.Views;
using Xamarin.Forms;

namespace BouquetOfPain
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page aboutPage;
            Page roller;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    aboutPage.Icon = "tab_about.png";

                    roller = new NavigationPage(new Roller())
                    {
                        Title = "Roll them bones"
                    };
                    break;

                default:
                    aboutPage = new AboutPage
                    {
                        Title = "About"
                    };

                    roller = new Roller
                    {
                        Title = "Roll them bones"
                    };
                    break;
            }

            Children.Add(aboutPage);
            Children.Add(roller);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}