using SupermarketApp.Model;
using SupermarketApp.Model.BusinessLogicLayer;
using SupermarketApp.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    internal class ReceiptsManagerVM : BaseNotify
    {
        public ReceiptsManagerVM()
        {
        }
        public ReceiptsManagerVM(Theme myTheme)
        {
            MyTheme = myTheme;
        }

        #region Properties and members

        private ReceiptsBLL _receiptsBLL = new ReceiptsBLL();
        public ObservableCollection<Receipt> Receipts { get; set; } = new ObservableCollection<Receipt>();
        public ObservableCollection<StockReceipt> ProductsList { get; set; } = new ObservableCollection<StockReceipt>();
        
        private string ActiveOrInactive = " ";

        private Theme _myTheme;
        public Theme MyTheme
        {
            get => _myTheme;
            set
            {
                _myTheme = value;
                NotifyPropertyChanged(nameof(MyTheme));
            }
        }
        
        private Receipt _selectedReceipt;
        public Receipt SelectedReceipt
        {
            get => _selectedReceipt;
            set
            {
                _selectedReceipt = value;
                if (_selectedReceipt != null)
                {
                    _receiptsBLL.GetReceiptProducts(_selectedReceipt, ProductsList);
                }
                NotifyPropertyChanged(nameof(SelectedReceipt));
            }
        }

        private string _biggestReceiptDate;
        public string BiggestReceiptDate
        {
            get => _biggestReceiptDate;
            set
            {
                _biggestReceiptDate = value;
                NotifyPropertyChanged(nameof(BiggestReceiptDate));
            }
        }

        #endregion

        #region Commands

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(DropCurrentReceipt, CanDeleteReceipt);
                return _deleteCommand;
            }
        }
        private void DropCurrentReceipt(object parameter)
        {
            _receiptsBLL.DropReceipt(SelectedReceipt);
            Clear();
            Receipts.Remove(SelectedReceipt);
        }

        private bool CanDeleteReceipt(object parameter)
        {
            return SelectedReceipt != null && ActiveOrInactive.Equals("Active");
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                    _clearCommand = new RelayCommand(ClearFields);
                return _clearCommand;
            }
        }
        private void ClearFields(object parameter)
        {
            Clear();
        }

        private ICommand _clearDateCommand;
        public ICommand ClearDateCommand
        {
            get
            {
                if (_clearDateCommand == null)
                    _clearDateCommand = new RelayCommand(ClearDate);
                return _clearDateCommand;
            }
        }
        private void ClearDate(object parameter)
        {
            BiggestReceiptDate = null;
        }

        private ICommand _showBiggestReceiptCommand;
        public ICommand ShowBiggestReceiptCommand
        {
            get
            {
                if (_showBiggestReceiptCommand == null)
                    _showBiggestReceiptCommand = new RelayCommand(ShowBiggestReceipt);
                return _showBiggestReceiptCommand;
            }
        }

        private void ShowBiggestReceipt(object parameter)
        {
            try
            {
                _receiptsBLL.GetBiggestReceipt(BiggestReceiptDate, ProductsList);
                if (ProductsList.Count > 0)
                {
                    foreach (var receipt in Receipts)
                    {
                        if (receipt.Id == ProductsList[0].Receipt.Id)
                        {
                            foreach (var listElement in ProductsList)
                            {
                                listElement.Receipt = receipt;
                            }
                            break;
                        }
                    }
                    SelectedReceipt = ProductsList[0].Receipt;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _getActiveReceiptsCommand;
        public ICommand GetActiveReceiptsCommand
        {
            get
            {
                if (_getActiveReceiptsCommand == null)
                    _getActiveReceiptsCommand = new RelayCommand(GetActiveReceipts);
                return _getActiveReceiptsCommand;
            }
        }
        private void GetActiveReceipts(object parameter)
        {
            try
            {
                Clear();
                _receiptsBLL.GetAllActiveReceipts(Receipts);
                ActiveOrInactive = "Active";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _getInctiveReceiptsCommand;
        public ICommand GetInactiveReceiptsCommand
        {
            get
            {
                if (_getInctiveReceiptsCommand == null)
                    _getInctiveReceiptsCommand = new RelayCommand(GetInactiveReceipts);
                return _getInctiveReceiptsCommand;
            }
        }
        private void GetInactiveReceipts(object parameter)
        {
            try
            {
                Clear();
                _receiptsBLL.GetAllInactiveReceipts(Receipts);
                ActiveOrInactive = "Inactive";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        #region Methods

        private void Clear()
        {
            BiggestReceiptDate = null;
            SelectedReceipt = null;
            ProductsList.Clear();
        }

        #endregion

    }
}
