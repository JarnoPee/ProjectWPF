using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Project_DAL.DomainModels;
using Project_WPF.Views;

namespace Project_WPF.ViewModels
{
    public class DashboardViewModel : ICommand
    {
        private Customer customer;

        public DashboardViewModel(Customer customer)
        {
            this.customer = customer;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "DuiklocatiesBekijken": return true;
                case "AccountInstellingen": return true;
                case "Favorieten": return true;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "DuiklocatiesBekijken": OpenDuiklocaties(); break;
                case "AccountInstellingen": OpenAccount(); break;
                case "Favorieten": OpenFavorieten(); break;
            }
        }
        public void OpenDuiklocaties()
        {
            DuiklocatieViewModel vm = new DuiklocatieViewModel(customer);
            DuiklocatieView view = new DuiklocatieView();
            view.DataContext = vm;
            view.Show();
            Application.Current.Windows[0].Close();
        }
        public void OpenAccount()
        {
            AccountViewModel vm = new AccountViewModel(customer);
            AccountView view = new AccountView();
            view.DataContext = vm;
            view.Show();
            Application.Current.Windows[0].Close();

        }

        public void OpenFavorieten()
        {
            FavorietenViewModel vm = new FavorietenViewModel(customer);
            FavorietenView view = new FavorietenView();
            view.DataContext = vm;
            view.Show();
            Application.Current.Windows[0].Close();

        }

    }
}
