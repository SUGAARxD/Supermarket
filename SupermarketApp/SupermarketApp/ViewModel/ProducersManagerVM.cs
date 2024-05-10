using SupermarketApp.Model;
using SupermarketApp.Model.BusinessLogicLayer;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    internal class ProducersManagerVM : BaseNotify
    {
        public ProducersManagerVM()
        {
        }

        public ProducersManagerVM(Theme myTheme)
        {
            MyTheme = myTheme;
        }

        #region Properties and members

        readonly ProducersBLL _producersBLL = new ProducersBLL();

        public ObservableCollection<Producer> Producers { get; set; } = new ObservableCollection<Producer>();

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

        private Producer _selectedProducer;
        public Producer SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;

                if (_selectedProducer != null)
                {
                    DummyProducer.Id = _selectedProducer.Id;
                    DummyProducer.Name = _selectedProducer.Name;
                    DummyProducer.Country = _selectedProducer.Country;
                }

                NotifyPropertyChanged(nameof(SelectedProducer));
            }
        }

        private Producer _dummyProducer = new Producer();
        public Producer DummyProducer
        {
            get => _dummyProducer;
            set
            {
                _dummyProducer = value;
                NotifyPropertyChanged(nameof(DummyProducer));
            }
        }

        #endregion

        #region Commands

        private ICommand _getActiveProducersCommand;
        public ICommand GetActiveProducersCommand
        {
            get
            {
                if (_getActiveProducersCommand == null)
                    _getActiveProducersCommand = new RelayCommand(GetActiveProducers);
                return _getActiveProducersCommand;
            }
        }
        private void GetActiveProducers(object parameter)
        {
            try
            {
                Clear();
                _producersBLL.GetAllActiveProducers(Producers);
                ActiveOrInactive = "Active";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _getInctiveProducersCommand;
        public ICommand GetInactiveProducersCommand
        {
            get
            {
                if (_getInctiveProducersCommand == null)
                    _getInctiveProducersCommand = new RelayCommand(GetInactiveProducers);
                return _getInctiveProducersCommand;
            }
        }
        private void GetInactiveProducers(object parameter)
        {
            try
            {
                Clear();
                _producersBLL.GetAllInactiveProducers(Producers);
                ActiveOrInactive = "Inactive";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _modifyCommand;
        public ICommand ModifyCommand
        {
            get
            {
                if (_modifyCommand == null)
                    _modifyCommand = new RelayCommand(Modify, CanModify);
                return _modifyCommand;
            }
        }
        private void Modify(object parameter)
        {
            try
            {
                _producersBLL.UpdateProducer(DummyProducer);
                SelectedProducer.Name = DummyProducer.Name;
                SelectedProducer.Country = DummyProducer.Country;
                Clear();
                MessageBox.Show("Update successfully!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool CanModify(object parameter)
        {
            return SelectedProducer != null
                && !string.IsNullOrEmpty(DummyProducer.Name);
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

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(AddCategory);
                return _addCommand;
            }
        }
        private void AddCategory(object parameter)
        {
            try
            {
                _producersBLL.AddProducer(DummyProducer);
                MessageBox.Show("Producer added successfully!");
                if (ActiveOrInactive.Equals("Active"))
                    _producersBLL.GetAllActiveProducers(Producers);
                else if (ActiveOrInactive.Equals("Inactive"))
                    _producersBLL.GetAllInactiveProducers(Producers);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(DeleteProducer, CanDelete);
                return _deleteCommand;
            }
        }
        private void DeleteProducer(object parameter)
        {
            _producersBLL.DeleteProducer(SelectedProducer);
            Producers.Remove(SelectedProducer);
        }

        private bool CanDelete(object parameter)
        {
            return SelectedProducer != null && ActiveOrInactive.Equals("Active");
        }

        private ICommand _showReportCommand;
        public ICommand ShowReportCommand
        {
            get
            {
                if (_showReportCommand == null)
                    _showReportCommand = new RelayCommand(ShowProductsReport);
                return _showReportCommand;
            }
        }
        private void ShowProductsReport(object parameter)
        {
            try
            {
                ObservableCollection<Product> products = _producersBLL.GetProductsReport(SelectedProducer);
                ProductsReportWindow productsReportWindow = new ProductsReportWindow(products);
                productsReportWindow.ShowDialog();
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
            SelectedProducer = null;
            DummyProducer.Name = "";
            DummyProducer.Country = "";
        }

        #endregion

    }
}
