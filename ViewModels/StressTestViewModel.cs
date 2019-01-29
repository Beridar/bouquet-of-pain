using BouquetOfPain.Models;

namespace BouquetOfPain
{
    public class StressTestViewModel : BaseViewModel
    {
        private readonly Roller randomNumberGenerator;

        public StressTestViewModel()
        {
            randomNumberGenerator = new Roller();
        }
    }
}