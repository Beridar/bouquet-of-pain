using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using BouquetOfPain.Models;
using Xamarin.Forms;

namespace BouquetOfPain
{
    public class RollerViewModel : BaseViewModel
    {
        public List<int> DiceOptions { get; }
        public List<int> DiceSizes { get; }
        public ICommand Roll { get; }

        public int SelectedDice { get; set; }
        public int SelectedSize { get; set; }

        private string result;
        public string Result
        {
            get => result;
            private set => SetProperty(ref result, value);
        }

        private readonly Roller randomNumberGenerator;

        public RollerViewModel()
        {
            DiceOptions = Enumerable.Range(1, 100).ToList();
            DiceSizes = new List<int>
            {
                2, 3, 4, 6, 8, 10, 12, 20, 24, 30, 100
            };

            Roll = new Command(ExecuteRoll);

            randomNumberGenerator = new Roller();

            SelectedDice = DiceOptions.FirstOrDefault();
            SelectedSize = DiceSizes.FirstOrDefault();
        }

        private void ExecuteRoll()
        {
            Result = randomNumberGenerator.Roll(SelectedDice, SelectedSize).Total.ToString();
        }
    }
}