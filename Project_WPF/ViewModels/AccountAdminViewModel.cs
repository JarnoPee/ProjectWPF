using Project_DAL.DomainModels;
using Project_WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_WPF.ViewModels
{
    public class AccountAdminViewModel: BasisViewModel
    {
        private Customer customer;
        private Customer _selectedCustomer;
        public string Foutmelding { get; set; }
        public ObservableCollection<Customer> Customer { get; set; }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                // NotifyPropertyChanged(); Niet meer nodig door fody weavers
            }

        }
        public override string this[string columnName] => throw new NotImplementedException();

        public AccountAdminViewModel(Customer customer) : base()
        {
            this.customer = customer;
            Customer = new ObservableCollection<Customer>(unitOfWork.CustomerRepo.Ophalen());

        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": return true;
                case "CustomerVerwijderen": return true;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": OpenDashboard(); break;
                case "CustomerVerwijderen": CustomerVerwijderen(); break;
            }
        }
        public void OpenDashboard()
        {
                DashboardViewModel vm = new DashboardViewModel(customer);
                DashboardAdminView view = new DashboardAdminView();
                view.DataContext = vm;
                view.Show();
                Application.Current.Windows[0].Close();
        }
        private void CustomerVerwijderen()
        {
            if (SelectedCustomer != null)
            {
                unitOfWork.CustomerRepo.Verwijderen(SelectedCustomer.CustomerID);
                int ok = unitOfWork.Save();
                if (ok > 0)
                {
                    RefreshData();
                }
            }
            else
            {
                Foutmelding = "Gelieve een locatie te selecteren!";
            }
        }
        private void RefreshData()
        {
            Customer = new ObservableCollection<Customer>(unitOfWork.CustomerRepo.Ophalen());
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
