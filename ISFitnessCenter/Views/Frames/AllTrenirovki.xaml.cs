using ISFitnessCenter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
    /// Логика взаимодействия для AllTrenirovki.xaml
    /// </summary>
    public partial class AllTrenirovki : Page
    {
        public List<Trener_Client> trener_Clients = new();
        public AllTrenirovki(TrenerLog trenerLog)
        {
            using (var context = new FitnessContext())
            {
                trener_Clients = context.trener_Clients
                    .Include(c=>c.clientID)
                    .Include(c=>c.week)
                    .Include(c=>c.trenerID)
                    .Include(c=>c.time)
                    .Where(c => c.trenerID == trenerLog.trener).ToList();
            }
            InitializeComponent();
            AllList.ItemsSource = trener_Clients;
        }
    }
}
