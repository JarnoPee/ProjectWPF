﻿using System;
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
        public string Naam { get; set; }
        public string Foutmelding { get; set; }
        public ObservableCollection<Location> Locations { get; set; }
        public LocationCustomer SelectedLocationCustomer { get; set; }
        public Location Location { get; set; }
        public ObservableCollection<LocationCustomer> LocationCustomers { get; set; }

        public Location SelectedLocation 
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;
               // NotifyPropertyChanged(); Niet meer nodig door fody weavers
            }

        }
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }
        public DuiklocatieViewModel(Customer customer, string keuzeView) : base()
        {
            this.customer = customer;
            if (keuzeView == "DuiklocatieView")
            {
                Locations = new ObservableCollection<Location>(unitOfWork.LocationRepo.Ophalen(x => x.Category, x => x.Preview));
            }
            else
            {
                LocationCustomers = new ObservableCollection<LocationCustomer>(unitOfWork.LocationCustomerRepo.Ophalen(x => x.CustomerID == customer.CustomerID, x => x.Location, x => x.Location.Category, x => x.Location.Preview));
            }

        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TerugNaarDashboard": return true;
                case "DuiklocatieBekijken": return true;
                case "DuiklocatieWijzigenOfToevoegen": return true;
                case "Zoeken": return true;
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
                case "DuiklocatieBekijken": DuiklocatieBekijken(); break;
                case "DuiklocatieWijzigenOfToevoegen": DuiklocatieWijzigenOfToevoegen(); break;
                case "Zoeken": Zoeken(); break;
                case "VerwijderenLocationCustomer": VerwijderenLocationCustomer(); break;
                case "LocatieBekijken": DuiklocatieBekijkenFavorieten(); break;

            }
        }
        public void OpenDashboard()
        {
            if (customer.IsAdmin == true)
            {
                DashboardViewModel vm = new DashboardViewModel(customer);
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
            Foutmelding = "";
            if (SelectedLocation != null)
            {
                GekozenDuiklocatieView location = new GekozenDuiklocatieView();
                DuiklocatieToevoegenViewModel gekozenDuiklocatieViewModel = new DuiklocatieToevoegenViewModel(SelectedLocation.LocationID, customer);
                location.DataContext = gekozenDuiklocatieViewModel;
                location.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                Foutmelding= "Gelieve een locatie te selecteren!";
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
        public void Zoeken()
        {
            Foutmelding = "";
            if (IsGeldig())
            {
                RefreshLocations();
                if (Locations == null || Locations.Count <= 0)
                {
                    Locations = new ObservableCollection<Location>(unitOfWork.LocationRepo.Ophalen(x => x.Category, x => x.Preview));
                }
            }
            else
            {
                Foutmelding = "Geen locatie met deze naam gevonden!";
            }
        }
        private void RefreshLocations()
        {
            string i = Naam;
            List<Location> listLocation = unitOfWork.LocationRepo.Ophalen(x => x.Naam.Contains(i)).ToList();

            Locations = new ObservableCollection<Location>(listLocation);
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
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
            else
            {
                Foutmelding = "Gelieve een locatie te selecteren!";
            }
        }
        private void DuiklocatieBekijkenFavorieten()
        {
            if (SelectedLocationCustomer != null)
            {
                GekozenDuiklocatieView location = new GekozenDuiklocatieView();
                DuiklocatieToevoegenViewModel gekozenDuiklocatieViewModel = new DuiklocatieToevoegenViewModel(SelectedLocationCustomer.LocationID, customer);
                location.DataContext = gekozenDuiklocatieViewModel;
                location.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                Foutmelding = "Gelieve een locatie te selecteren!";
            }
        }
        private void RefreshData()
        {
            LocationCustomers = new ObservableCollection<LocationCustomer>(unitOfWork.LocationCustomerRepo.Ophalen(x => x.CustomerID == customer.CustomerID, x => x.Location, x => x.Location.Category, x => x.Location.Preview));
            Foutmelding = "";
        }

    }
}
