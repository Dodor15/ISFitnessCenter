using ISFitnessCenter.Classes;
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
        
        public Client client = new Client();
        public AddAboniment(Client clients)
        {
            
            edit = false;
            client = clients;
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
            
            using (var context = new FitnessContext())
            {
                client.NumberPhone = phoneBox.Text.ToString();
                client.FIOclient = fioBox.Text.ToString();
                if (pool.IsChecked == true)
                {
                    client.Pool = true;
                }
                else
                    client.Pool = false;
                if (ring.IsChecked == true)
                {
                    client.Ring = true;
                }
                else
                    client.Ring = false;
                if (dance.IsChecked == true)
                {
                    client.Dance = true;
                }
                else
                    client.Dance = false;
                if (aerobic.IsChecked == true)
                {
                    client.Aerobic = true;
                }
                else
                    client.Aerobic = false;
                if (trampline.IsChecked == true)
                {
                    client.trampoline = true;
                }
                else
                    client.trampoline = false;
                if (edit)
                {
                    ClientDataManagementClass clients = new();
                    clients.DataCollection.Add(client);
                    Close();
                }
                else
                {
                    context.clients.Update(client);
                    try
                    {

                        context.SaveChanges();
                        MessageBox.Show("Saved");
                        Close();
                    }
                    catch
                    {
                        MessageBox.Show("Not saved");
                    }
                }



            }


        }
    }
}
