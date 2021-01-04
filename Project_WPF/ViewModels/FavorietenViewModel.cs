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
        private Location _selectedLocation;
        public Location Location { get; set; }
        public ObservableCollection<LocationCustomer> LocationCustomer { get; set; }
        public ObservableCollection<Location> Locations { get; set; }

        public Location SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;
                // NotifyPropertyChanged(); Niet meer nodig door fody weavers
            }

        }
        public FavorietenViewModel(Customer customer)
        {
            this.customer = customer;
            Locations = new ObservableCollection<Location>(unitOfWork.LocationRepo.Ophalen(x => x.Category, x => x.Preview, x => x.LocationCustomers.Select(y => y.Location))); //.Where(x => x.LocationCustomers == customer.LocationCustomers)
            //LocationCustomer = new ObservableCollection<LocationCustomer>(Location.LocationCustomers);
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
                case "LocatieBekijken": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": OpenDashboard(); break;
                case "VerwijderenLocationCustomer": VerwijderenLocationCustomer(); break;
                case "LocatieBekijken": DuiklocatieBekijken(); break;
            }
        }
        public void OpenDashboard()
        {
            if (customer.IsAdmin == true)
            {
                DashboardAdminViewModel vm = new DashboardAdminViewModel(customer);
                DashboardAdminView view = new DashboardAdminView();
                view.DataContext = vm;
                view.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                DashboardViewModel vm = new DashboardViewModel(customer);
                DashboardView view = new DashboardView();
                view.DataContext = vm;
                view.Show();
                Application.Current.Windows[0].Close();
            }
        }
        public void VerwijderenLocationCustomer()
        {
            if (SelectedLocation != null)
            {
                unitOfWork.LocationCustomerRepo.Verwijderen(SelectedLocation.LocationCustomers);
                int ok = unitOfWork.Save();
                if (ok > 0)
                {
                    RefreshData();
                }
            }
        }
        private void DuiklocatieBekijken()
        {
            if (SelectedLocation != null)
            {
                GekozenDuiklocatieView location = new GekozenDuiklocatieView();
                GekozenDuiklocatieViewModel gekozenDuiklocatieViewModel = new GekozenDuiklocatieViewModel(SelectedLocation.LocationID, customer);
                location.DataContext = gekozenDuiklocatieViewModel;
                location.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                MessageBox.Show("Gelieve een locatie te selecteren!");
            }
        }
        private void RefreshData()
        {
            LocationCustomer = new ObservableCollection<LocationCustomer>(Location.LocationCustomers);
        }

    }
}
