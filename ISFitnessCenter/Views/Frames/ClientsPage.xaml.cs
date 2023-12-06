using ISFitnessCenter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISFitnessCenter.Views.Frames
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ObservableCollection<Client> clientss { get; set; }
        
        public ClientsPage()
        {
            clientss = new ObservableCollection<Client>();
            using (var context = new FitnessContext())
            {
                foreach (var cl in context.clients.ToList())
                {
                    clientss.Add(cl);
                }
            }
            InitializeComponent();
            ClientsList.ItemsSource = clientss;
           
        }

     

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddAboniment aa = new AddAboniment();
            aa.ShowDialog();
           
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            AddAboniment aa = new AddAboniment((Client)ClientsList.SelectedItem);
            aa.ShowDialog();
        }

        private void treners_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new Treners());
        }

        private void addPeople_Click(object sender, RoutedEventArgs e)
        {
            AddPeople ap = new();
            ap.ShowDialog();
            
        }

        private void ClientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientsList.SelectedItem != null)
            {
                edit.IsEnabled = true;
                treners.IsEnabled = true;// Активация кнопки
            }
            else
            {

                edit.IsEnabled = false;
                treners.IsEnabled = false; // Деактивация кнопки
            }
        }
    }
}
