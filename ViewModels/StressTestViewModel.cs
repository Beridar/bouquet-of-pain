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
        private int totalResultCount;
        private Dictionary<int, int> allResults;

        public string Results_01 => CalculatePercentageTextFor(allResults[01]);
        public string Results_02 => CalculatePercentageTextFor(allResults[02]);
        public string Results_03 => CalculatePercentageTextFor(allResults[03]);
        public string Results_04 => CalculatePercentageTextFor(allResults[04]);
        public string Results_05 => CalculatePercentageTextFor(allResults[05]);
        public string Results_06 => CalculatePercentageTextFor(allResults[06]);
        public string Results_07 => CalculatePercentageTextFor(allResults[07]);
        public string Results_08 => CalculatePercentageTextFor(allResults[08]);
        public string Results_09 => CalculatePercentageTextFor(allResults[09]);
        public string Results_10 => CalculatePercentageTextFor(allResults[10]);
        public string Results_11 => CalculatePercentageTextFor(allResults[11]);
        public string Results_12 => CalculatePercentageTextFor(allResults[12]);
        public string Results_13 => CalculatePercentageTextFor(allResults[13]);
        public string Results_14 => CalculatePercentageTextFor(allResults[14]);
        public string Results_15 => CalculatePercentageTextFor(allResults[15]);
        public string Results_16 => CalculatePercentageTextFor(allResults[16]);
        public string Results_17 => CalculatePercentageTextFor(allResults[17]);
        public string Results_18 => CalculatePercentageTextFor(allResults[18]);
        public string Results_19 => CalculatePercentageTextFor(allResults[19]);
        public string Results_20 => CalculatePercentageTextFor(allResults[20]);

        public double Percentage_01 => CalculatePercentageFor(allResults[01]);
        public double Percentage_02 => CalculatePercentageFor(allResults[02]);
        public double Percentage_03 => CalculatePercentageFor(allResults[03]);
        public double Percentage_04 => CalculatePercentageFor(allResults[04]);
        public double Percentage_05 => CalculatePercentageFor(allResults[05]);
        public double Percentage_06 => CalculatePercentageFor(allResults[06]);
        public double Percentage_07 => CalculatePercentageFor(allResults[07]);
        public double Percentage_08 => CalculatePercentageFor(allResults[08]);
        public double Percentage_09 => CalculatePercentageFor(allResults[09]);
        public double Percentage_10 => CalculatePercentageFor(allResults[10]);
        public double Percentage_11 => CalculatePercentageFor(allResults[11]);
        public double Percentage_12 => CalculatePercentageFor(allResults[12]);
        public double Percentage_13 => CalculatePercentageFor(allResults[13]);
        public double Percentage_14 => CalculatePercentageFor(allResults[14]);
        public double Percentage_15 => CalculatePercentageFor(allResults[15]);
        public double Percentage_16 => CalculatePercentageFor(allResults[16]);
        public double Percentage_17 => CalculatePercentageFor(allResults[17]);
        public double Percentage_18 => CalculatePercentageFor(allResults[18]);
        public double Percentage_19 => CalculatePercentageFor(allResults[19]);
        public double Percentage_20 => CalculatePercentageFor(allResults[20]);

        public ICommand StartRolling { get; }
        public ICommand StopRolling { get; }

        private static readonly string[] nameOfAllProperties = new[]
        {
            nameof(Results_01), nameof(Results_02), nameof(Results_03), nameof(Results_04), nameof(Results_05),
            nameof(Results_06), nameof(Results_07), nameof(Results_08), nameof(Results_09), nameof(Results_10),
            nameof(Results_11), nameof(Results_12), nameof(Results_13), nameof(Results_14), nameof(Results_15),
            nameof(Results_16), nameof(Results_17), nameof(Results_18), nameof(Results_19), nameof(Results_20),

            nameof(Percentage_01), nameof(Percentage_02), nameof(Percentage_03), nameof(Percentage_04), nameof(Percentage_05),
            nameof(Percentage_06), nameof(Percentage_07), nameof(Percentage_08), nameof(Percentage_09), nameof(Percentage_10),
            nameof(Percentage_11), nameof(Percentage_12), nameof(Percentage_13), nameof(Percentage_14), nameof(Percentage_15),
            nameof(Percentage_16), nameof(Percentage_17), nameof(Percentage_18), nameof(Percentage_19), nameof(Percentage_20)
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
                var nextResults = randomNumberGenerator.Roll(1000, 20);

                totalResultCount += nextResults.Rolls.Length;

                foreach (var key in allResults.Keys.ToArray())
                    allResults[key] += nextResults.Rolls.Count(x => x == key);

                foreach (var updatedCount in nameOfAllProperties)
                    OnPropertyChanged(updatedCount);

                await Task.Delay(10);
            }
        }

        private string CalculatePercentageTextFor(int oneResultCount)
        {
            var percentage = CalculatePercentageFor(oneResultCount);

            return $"{oneResultCount:N0} ({percentage:P4})";
        }

        private float CalculatePercentageFor(int oneResultCount)
        {
            return 1.0f * oneResultCount / totalResultCount;
        }

        private void ExecuteStopRolling()
        {
            continueRolling = false;
        }
    }
}