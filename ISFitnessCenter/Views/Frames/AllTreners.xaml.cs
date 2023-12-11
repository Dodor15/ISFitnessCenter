using ISFitnessCenter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для AllTreners.xaml
    /// </summary>
    public partial class AllTreners : Page
    {
        List<TrenerLog> trenerLog { get; set; } = new();
        public AllTreners()
        {
            using (var context = new FitnessContext())
            {
                List<Trener> treners = context.treners.ToList();
                foreach (var tr in treners)
                {
                    int nag = 0;
                    try
                    {
                        nag = context.trener_Clients.Where(c => c.trenerID == tr).Count();//
                    }
                    catch { }
                    
                    TrenerLog tl = new()
                    {
                        trener = tr,
                        Nagruz = nag
                    };
                    trenerLog.Add(tl);
                }
            }
            InitializeComponent();
            trList.ItemsSource = trenerLog;

        }

        private void trList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditTrener.IsEnabled = true;
            TrenerLog tg = (TrenerLog)trList.SelectedItem;
            if (tg.Nagruz != 0)
            {
                ShowTrenirovki.IsEnabled = true;
            }
            else
            {
                ShowTrenirovki.IsEnabled = false;
            }
        }

        private void EditTrener_Click(object sender, RoutedEventArgs e)
        {
            EditTrener et = new((TrenerLog)trList.SelectedItem);
            et.ShowDialog();
        }

        private void ShowTrenirovki_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllTrenirovki((TrenerLog)trList.SelectedItem));
        }
    }
}
