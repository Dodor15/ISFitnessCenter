using ISFitnessCenter.Models;
using System;
using System.Collections.Generic;
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
        public ClientsPage()
        {
            InitializeComponent();
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
    }
}
