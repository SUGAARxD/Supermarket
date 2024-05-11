using System.Collections.ObjectModel;
using System;

namespace SupermarketApp.ViewModel
{
    internal class CashedAmountsVM
    {
        public CashedAmountsVM()
        {

        }

        public CashedAmountsVM(ObservableCollection<Tuple<string, double>> cashedAmounts)
        {
            CashedAmounts = new ObservableCollection<Tuple<string, double>>();
            foreach (var item in cashedAmounts)
            {
                CashedAmounts.Add(item);
            };
        }

        public ObservableCollection<Tuple<string, double>> CashedAmounts { get; set; }

    }
}
