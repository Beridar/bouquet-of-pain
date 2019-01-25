using System.Windows.Input;
using Xamarin.Forms;

namespace BouquetOfPain
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenUrl = new Command<string>(url => Device.OpenUri(new System.Uri(url)));
        }

        public ICommand OpenUrl { get; }
    }
}