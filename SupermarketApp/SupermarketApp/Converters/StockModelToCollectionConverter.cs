using SupermarketApp.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace SupermarketApp.Converters
{
    internal class StockModelToCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<Stock> stocks = new ObservableCollection<Stock>();
            if (value is Stock stock)
            {
                if (stock != null)
                {
                    stocks.Add(stock);
                    return stocks;
                }
            }
            return stocks;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<Stock> stocks)
            {
                if (stocks != null && stocks.Count != 0)
                    return stocks[0];
            }
            return null;
        }
    }
}