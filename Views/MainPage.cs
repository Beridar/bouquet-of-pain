using System.Linq;
using BouquetOfPain.Views;
using Xamarin.Forms;

namespace BouquetOfPain
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page rollerPage;
            Page stressTestPage;
            Page aboutPage;

            rollerPage = new Roller
            {
                Title = "Roll",
                Icon = "thrown_green_d6"
            };

            stressTestPage = new StressTestPage
            {
                Title = "Stress test",
                Icon = "pummeled-no-background"
            };

            aboutPage = new AboutPage
            {
                Title = "About"
            };

            var allPages = new[]
            {
                rollerPage,
                stressTestPage,
                aboutPage,
            };

            if (Device.RuntimePlatform == Device.iOS)
                allPages = allPages.Select(x => (Page)new NavigationPage(x) {Title = x.Title, Icon = x.Icon}).ToArray();

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