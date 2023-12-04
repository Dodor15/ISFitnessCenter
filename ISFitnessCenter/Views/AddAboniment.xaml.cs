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
using System.Windows.Shapes;

namespace ISFitnessCenter.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAboniment.xaml
    /// </summary>
    public partial class AddAboniment : Window
    {
        bool edit = true;
        public AddAboniment(Client clients)
        {
            edit = false;
            InitializeComponent();
            fioBox.Text = clients.FIOclient;
            phoneBox.Text = clients.NumberPhone;
            if (clients.Pool is true)
                pool.IsChecked = true;
            if (clients.Ring is true)
                ring.IsChecked = true;
            if (clients.Aerobic is true)
                aerobic.IsChecked = true;
            if (clients.Dance is true)
                dance.IsChecked = true;
            if (clients.trampoline is true)
                trampline.IsChecked = true;
            addClient.Content = "Изменить";

        }
        public AddAboniment()
        {
            InitializeComponent();
        }

        private void addClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
