using System.ComponentModel;
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
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static BindableProperty ShaderBackgroundColorProperty = BindableProperty.Create(
            nameof(ShaderBackgroundColor),
            typeof(Color),
            typeof(PercentageWithShader));

        public Color ShaderBackgroundColor
        {
            get => (Color) GetValue(ShaderBackgroundColorProperty);
            set => SetValue(ShaderBackgroundColorProperty, value);
        }

        public static BindableProperty ShaderLayoutBoundsProperty = BindableProperty.Create(
            nameof(ShaderLayoutBounds),
            typeof(Rectangle),
            typeof(PercentageWithShader));

        public Rectangle ShaderLayoutBounds
        {
            get => (Rectangle)GetValue(ShaderLayoutBoundsProperty);
            set => SetValue(ShaderLayoutBoundsProperty, value);
        }

        public static BindableProperty PercentageProperty = BindableProperty.Create(
            nameof(Percentage),
            typeof(double),
            typeof(PercentageWithShader));

        public double Percentage
        {
            get => (double)GetValue(PercentageProperty);
            set => SetValue(PercentageProperty, value);
        }

        public const double MINIMUM_PERCENTAGE_TO_SHOW = 0.0495;
        public const double MAXIMUM_PERCENTAGE_TO_SHOW = 0.0505;

        public PercentageWithShader()
        {
            InitializeComponent();

            PropertyChanged += UpdateShadingWhenPercentageChanges;
        }

        private void UpdateShadingWhenPercentageChanges(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(Percentage)) return;

            if (double.IsNaN(Percentage) || Percentage < MINIMUM_PERCENTAGE_TO_SHOW)
            {
                ShaderLayoutBounds = new Rectangle(0, 0, 0, 1);
                ShaderBackgroundColor = Color.Transparent;
            }

            else if (Percentage > MAXIMUM_PERCENTAGE_TO_SHOW)
            {
                ShaderLayoutBounds = new Rectangle(0, 0, 1, 1);
                ShaderBackgroundColor = Color.Red;
            }

            else
            {
                var percentageToFill = (Percentage - MINIMUM_PERCENTAGE_TO_SHOW) /
                                       (MAXIMUM_PERCENTAGE_TO_SHOW - MINIMUM_PERCENTAGE_TO_SHOW);

                ShaderLayoutBounds = new Rectangle(0, 0, percentageToFill, 1);
                ShaderBackgroundColor = Color.Green;
            }
        }
    }
}