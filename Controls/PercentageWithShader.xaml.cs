using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BouquetOfPain.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PercentageWithShader : ContentView
    {
        public static BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(PercentageWithShader));

        public string Text
        {
            get => GetValue(TextProperty) as string;
            set => SetValue(TextProperty, value);
        }

        public PercentageWithShader()
        {
            InitializeComponent();
        }
    }
}