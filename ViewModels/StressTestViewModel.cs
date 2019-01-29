using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using BouquetOfPain.Models;
using Xamarin.Forms;

namespace BouquetOfPain
{
    public class StressTestViewModel : BaseViewModel
    {
        private readonly Roller randomNumberGenerator;
        private Dictionary<int, int> allResults;

        public string Results_01 => allResults[01].ToString();
        public string Results_02 => allResults[02].ToString();
        public string Results_03 => allResults[03].ToString();
        public string Results_04 => allResults[04].ToString();
        public string Results_05 => allResults[05].ToString();
        public string Results_06 => allResults[06].ToString();
        public string Results_07 => allResults[07].ToString();
        public string Results_08 => allResults[08].ToString();
        public string Results_09 => allResults[09].ToString();
        public string Results_10 => allResults[10].ToString();
        public string Results_11 => allResults[11].ToString();
        public string Results_12 => allResults[12].ToString();
        public string Results_13 => allResults[13].ToString();
        public string Results_14 => allResults[14].ToString();
        public string Results_15 => allResults[15].ToString();
        public string Results_16 => allResults[16].ToString();
        public string Results_17 => allResults[17].ToString();
        public string Results_18 => allResults[18].ToString();
        public string Results_19 => allResults[19].ToString();
        public string Results_20 => allResults[20].ToString();

        public ICommand StartRolling { get; }
        public ICommand StopRolling { get; }

        private static readonly string[] nameOfAllProperties = new[]
        {
            nameof(Results_01), nameof(Results_02), nameof(Results_03), nameof(Results_04), nameof(Results_05),
            nameof(Results_06), nameof(Results_07), nameof(Results_08), nameof(Results_09), nameof(Results_10),
            nameof(Results_11), nameof(Results_12), nameof(Results_13), nameof(Results_14), nameof(Results_15),
            nameof(Results_16), nameof(Results_17), nameof(Results_18), nameof(Results_19), nameof(Results_20)
        };

        public StressTestViewModel()
        {
            randomNumberGenerator = new Roller();

            allResults = Enumerable.Range(1, 21)
                .ToDictionary(x => x, x => 0);

            StartRolling = new Command(ExecuteStartRolling);
            StopRolling = new Command(ExecuteStopRolling);
        }

        private void ExecuteStartRolling()
        {
            Task.Run(ExecuteStartRollingAsync);
        }

        private bool continueRolling;

        private async Task ExecuteStartRollingAsync()
        {
            continueRolling = true;

            while (continueRolling)
            {
                var nextResults = randomNumberGenerator.Roll(100, 20);

                foreach (var key in allResults.Keys.ToArray())
                    allResults[key] += nextResults.Rolls.Count(x => x == key);

                foreach (var updatedCount in nameOfAllProperties)
                    OnPropertyChanged(updatedCount);

                await Task.Delay(10);
            }
        }

        private void ExecuteStopRolling()
        {
            continueRolling = false;
        }
    }
}