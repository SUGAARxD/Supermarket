using SupermarketApp.Model;
using SupermarketApp.Model.BusinessLogicLayer;
using SupermarketApp.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    internal class CategoriesManagerVM : BaseNotify
    {
        public CategoriesManagerVM()
        {
        }

        public CategoriesManagerVM(Theme myTheme)
        {
            MyTheme = myTheme;
        }

        #region Properties and members

        readonly CategoriesBLL _categoriesBLL = new CategoriesBLL();

        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

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

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;

                if (_selectedCategory != null)
                {
                    DummyCategory.Id = _selectedCategory.Id;
                    DummyCategory.Name = _selectedCategory.Name;
                    CategoryValue = 0;
                }

                NotifyPropertyChanged(nameof(SelectedCategory));
            }
        }

        private Category _dummyCategory = new Category();
        public Category DummyCategory
        {
            get => _dummyCategory;
            set
            {
                _dummyCategory = value;
                NotifyPropertyChanged(nameof(DummyCategory));
            }
        }

        private double _categoryValue;
        public double CategoryValue
        {
            get => _categoryValue;
            set
            {
                _categoryValue = value;
                NotifyPropertyChanged(nameof(CategoryValue));
            }
        }

        #endregion

        #region Commands

        private ICommand _getCategoryValueCommand;
        public ICommand GetCategoryValueCommand
        {
            get
            {
                if (_getCategoryValueCommand == null)
                    _getCategoryValueCommand = new RelayCommand(GetCategoryValue, CanGetCategoryValue);
                return _getCategoryValueCommand;
            }
        }
        private void GetCategoryValue(object parameter)
        {
            CategoryValue = Math.Round(_categoriesBLL.GetCategoryValue(SelectedCategory), 2);
        }

        private bool CanGetCategoryValue(object parameter)
        {
            return SelectedCategory != null && ActiveOrInactive.Equals("Active");
        }

        private ICommand _getActiveCategoriesCommand;
        public ICommand GetActiveCategoriesCommand
        {
            get
            {
                if (_getActiveCategoriesCommand == null)
                    _getActiveCategoriesCommand = new RelayCommand(GetActiveCategories);
                return _getActiveCategoriesCommand;
            }
        }
        private void GetActiveCategories(object parameter)
        {
            try
            {
                Clear();
                _categoriesBLL.GetAllActiveCategories(Categories);
                ActiveOrInactive = "Active";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private ICommand _getInctiveCategoriesCommand;
        public ICommand GetInactiveCategoriesCommand
        {
            get
            {
                if (_getInctiveCategoriesCommand == null)
                    _getInctiveCategoriesCommand = new RelayCommand(GetInactiveCategories);
                return _getInctiveCategoriesCommand;
            }
        }
        private void GetInactiveCategories(object parameter)
        {
            try
            {
                Clear();
                _categoriesBLL.GetAllInactiveCategories(Categories);
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
                _categoriesBLL.UpdateCategory(DummyCategory);
                SelectedCategory.Name = DummyCategory.Name;
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
            return SelectedCategory != null
                && !string.IsNullOrEmpty(DummyCategory.Name);
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
                _categoriesBLL.AddCategory(DummyCategory);
                MessageBox.Show("Category added successfully!");
                if (ActiveOrInactive.Equals("Active"))
                    _categoriesBLL.GetAllActiveCategories(Categories);
                else if (ActiveOrInactive.Equals("Inactive"))
                    _categoriesBLL.GetAllInactiveCategories(Categories);
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
                    _deleteCommand = new RelayCommand(DeleteCategory, CanDelete);
                return _deleteCommand;
            }
        }
        private void DeleteCategory(object parameter)
        {
            _categoriesBLL.DeleteCategory(SelectedCategory);
            Categories.Remove(SelectedCategory);
        }

        private bool CanDelete(object parameter)
        {
            return SelectedCategory != null && ActiveOrInactive.Equals("Active");
        }

        #endregion

        #region Methods

        private void Clear()
        {
            SelectedCategory = null;
            DummyCategory.Name = "";
            DummyCategory.Id = -1;
            CategoryValue = 0;
        }

        #endregion

    }
}
