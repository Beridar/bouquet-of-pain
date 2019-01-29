using System.Linq;
using BouquetOfPain.Views;
using Xamarin.Forms;

namespace BouquetOfPain
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page aboutPage;
            Page rollerPage;

            aboutPage = new AboutPage
            {
                Title = "About"
            };

            rollerPage = new Roller
            {
                Title = "Roll them bones"
            };

            var allPages = new[]
            {
                aboutPage,
                rollerPage,
            };

            if (Device.RuntimePlatform == Device.iOS)
                allPages = allPages.Select(x => (Page)new NavigationPage(x) {Title = x.Title}).ToArray();

            foreach (var child in allPages)
                Children.Add(child);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}