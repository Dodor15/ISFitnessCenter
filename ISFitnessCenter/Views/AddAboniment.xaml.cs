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
        public AddAboniment(Client clients)
        {
            InitializeComponent();
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
