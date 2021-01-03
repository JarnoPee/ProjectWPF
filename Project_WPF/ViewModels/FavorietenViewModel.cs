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
    class FavorietenViewModel : BasisViewModel
    {
        private Customer customer;
        public LocationCustomer SelectedLocationCustomer { get; set; }
        public Location Location { get; set; }
        public ObservableCollection<LocationCustomer> LocationCustomer { get; set; }
        public ObservableCollection<Location> Locations { get; set; }


        public FavorietenViewModel(Customer customer)
        {
            this.customer = customer;
            Locations = new ObservableCollection<Location>(unitOfWork.LocationRepo.Ophalen(x => x.Category, x => x.Preview).Where(x => x.LocationCustomers == customer.LocationCustomers));
        }   

        public override string this[string columnName]
        {
            get { return ""; }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": return true;
                case "VerwijderenLocationCustomer": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": OpenDashboard(); break;
                case "VerwijderenLocationCustomer": VerwijderenLocationCustomer(); break;
            }
        }
        public void OpenDashboard()
        {
            DashboardViewModel vm = new DashboardViewModel(customer);
            DashboardView view = new DashboardView();
            view.DataContext = vm;
            view.Show();
            Application.Current.Windows[0].Close();
        }
        public void VerwijderenLocationCustomer()
        {
            if (SelectedLocationCustomer != null)
            {
                unitOfWork.LocationCustomerRepo.Verwijderen(SelectedLocationCustomer.LocationCustomerID);
                int ok = unitOfWork.Save();
                if (ok > 0)
                {
                    RefreshData();
                }
            }
        }
        private void RefreshData()
        {
            LocationCustomer = new ObservableCollection<LocationCustomer>(Location.LocationCustomers);
        }

    }
}
