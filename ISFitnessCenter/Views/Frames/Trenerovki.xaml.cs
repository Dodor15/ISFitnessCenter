using ISFitnessCenter.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для Trenerovki.xaml
    /// </summary>
    public partial class Trenerovki : Page
    {
        public ObservableCollection<Specialyty_Trener> ST { get; set; }
        public Client _client = new Client();
        public Trenerovki(Specialtiy specialtiy, Client client)
        {
            _client = client;
            ST = new();
            using (var context = new FitnessContext())
            {
                foreach (var st in context.specialyty_Treners.Include(c => c.trenerId).Include(c=>c.trenerId.AdressTrener).Where(c => c.SpecialtiyId == specialtiy))
                {
                    ST.Add(st);
                }
            }
            InitializeComponent();
            trenersLV.ItemsSource = ST;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void trenersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ZapicTrenirovki ZT = new((Specialyty_Trener)trenersLV.SelectedItem, _client);
            ZT.ShowDialog();
            NavigationService.GoBack();

        }
    }
}
