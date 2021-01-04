using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Project_DAL;
using Project_DAL.Data.UnitOfWork;
using Project_DAL.DomainModels;
using Project_WPF.Views;

namespace Project_WPF.ViewModels
{
    public class DuiklocatieViewModel : BasisViewModel, ICommand,  IDisposable
    {
        private Customer customer;
        private Location _selectedLocation;
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
        public override string this[string columnName] => throw new NotImplementedException();
        public DuiklocatieViewModel(Customer customer) : base()
        {
            this.customer = customer;
            Locations = new ObservableCollection<Location>(unitOfWork.LocationRepo.Ophalen(x => x.Category, x => x.Preview));

        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": return true;
                case "DuiklocatieBekijken": return true;
                case "DuiklocatieWijzigenOfToevoegen": return true;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": OpenDashboard(); break;
                case "DuiklocatieBekijken": DuiklocatieBekijken(); break;
                case "DuiklocatieWijzigenOfToevoegen": DuiklocatieWijzigenOfToevoegen(); break;
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
        public void DuiklocatieWijzigenOfToevoegen()
        {
            if (SelectedLocation != null)
            {
                DuiklocatieToevoegenViewModel vm = new DuiklocatieToevoegenViewModel(SelectedLocation.LocationID, customer);
                DuiklocatieToevoegenView view = new DuiklocatieToevoegenView();
                view.DataContext = vm;
                view.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                DuiklocatieToevoegenViewModel vm = new DuiklocatieToevoegenViewModel(null, customer);
                DuiklocatieToevoegenView view = new DuiklocatieToevoegenView();
                view.DataContext = vm;
                view.Show();
                Application.Current.Windows[0].Close();

            }


        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
