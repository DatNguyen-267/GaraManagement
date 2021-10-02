using GaraManagement.View;
using GaraManagement.View.Gara;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace GaraManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private MainWindow mainWindow { get; set; }

        private Reception_Manager _Reception_Manager { get; set; }
        public Reception_Manager Reception_Manager { get => _Reception_Manager; set { this._Reception_Manager = value; OnPropertyChanged(); } }
        public ICommand ReceptionManager_Command { get; set; }
        public MainViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitTab();
            AddTabIntoContainer();
            Command();

        }
        private void AddTabIntoContainer()
        {
            mainWindow.Container.Children.Add(Reception_Manager);
        }
        private void InitTab()
        {
            Reception_Manager = new Reception_Manager() { Visibility = System.Windows.Visibility.Collapsed};
        }
        private void HidenAllTab()
        {
            Reception_Manager.Visibility = System.Windows.Visibility.Collapsed;
        }
        public void Command()
        {
            ReceptionManager_Command = new RelayCommand<Button>((p) => true, (p) => CallReceptionManager(p));
        }
        private void CallReceptionManager (Button ReceptionManagerButton)
        {
            HidenAllTab();
            Reception_Manager.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
