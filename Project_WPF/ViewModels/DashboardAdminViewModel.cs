using Project_DAL.DomainModels;
using Project_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project_WPF.ViewModels
{
    public class DashboardAdminViewModel : ICommand
    {
        private Customer customer;

        public DashboardAdminViewModel(Customer customer)
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
                case "AccountAdmin": return true;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "DuiklocatiesBekijken": OpenDuiklocaties(); break;
                case "AccountInstellingen": OpenAccount(); break;
                case "AccountAdmin": AccountAdmin(); break;
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

        public void AccountAdmin()
        {
            AccountAdminViewModel vm = new AccountAdminViewModel(customer);
            AccountAdminView view = new AccountAdminView();
            view.DataContext = vm;
            view.Show();
            Application.Current.Windows[0].Close();
        }
    }
}

