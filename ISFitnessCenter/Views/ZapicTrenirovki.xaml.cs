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
    /// Логика взаимодействия для ZapicTrenirovki.xaml
    /// </summary>
    public partial class ZapicTrenirovki : Window
    {
        public Trener _trener = new ();
        public List<Week> _week = new();
        public List<Time> times = new();
        public Client _client = new();
        public ZapicTrenirovki(Specialyty_Trener trener, Client client)
        {
            _client = client;
            using (var context = new FitnessContext())
            {
                _trener = context.treners.Where(t => t == trener.trenerId).First();
                _week = context.weeks.ToList();
                Schedule schedule = context.schedules.Where(s => s.trenerId == _trener).First();
                for (int i = _week.Count - 1; i >= 0; i--)
                {
                    if (schedule.Mondeay == false && _week[i].weekName == "Понедельник")
                    {
                            _week.RemoveAt(i);   
                    }
                    if (schedule.Tuesday == false && _week[i].weekName == "Вторник")
                    {
                            _week.RemoveAt(i);
                    }
                    if (schedule.Wednesday == false && _week[i].weekName == "Среда")
                    {
                            _week.RemoveAt(i);   
                    }
                    if (schedule.Thursday == false && _week[i].weekName == "Четверг")
                    {
                            _week.RemoveAt(i);   
                    }
                    if (schedule.Ftiday == false && _week[i].weekName == "Пятница")
                    {
                            _week.RemoveAt(i);   
                    }
                    if (schedule.Saturday == false && _week[i].weekName == "Суббота")
                    {
                            _week.RemoveAt(i);   
                    }
                    if (schedule.Sunday == false && _week[i].weekName == "Воскресенье")
                    {
                            _week.RemoveAt(i);
                    }
                }
               
                
            }
            
            InitializeComponent();
            Weeks.ItemsSource = _week;
        }

        private void Weeks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Smena_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Times.IsEnabled = true;
            using (var context = new FitnessContext())
            {
                switch (Smena.SelectedIndex)
                {
                    case 0:
                        times = context.times.Where(c => c.shift == 1).ToList();
                        Times.ItemsSource = times;
                        break;
                    case 1:
                        times = context.times.Where(c => c.shift == 2).ToList();
                        Times.ItemsSource = times;
                        break;
                    case 2:
                        times = context.times.Where(c => c.shift == 3).ToList();
                        Times.ItemsSource = times;
                        break;

                }
            }
        }

        private void Zapic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new FitnessContext())
                {
                    DateTime today = DateTime.Now;
                    today.AddMonths(1);
                    Time t = context.times.Where(c => c == (Time)Times.SelectedItem).First();
                    Week w = context.weeks.Where(c => c == (Week)Weeks.SelectedItem).First();
                    Trener_Client TC = new()
                    {
                        clientID = context.clients.Find(_client.ClientId),
                        time = context.times.Find(t.TimeId),
                        trenerID = context.treners.Find(_trener.TrenerId),
                        week = context.weeks.Find(w.weekId),
                        EndTime = today
                    };
                    try
                    {
                        Trener_Client check = context.trener_Clients.Where(c=>c.trenerID == TC.trenerID && c.clientID == TC.clientID && c.week == TC.week).First();
                        MessageBox.Show("Такая тренировка уже есть");
                        Close();
                        
                    }
                    catch
                    {
                        context.trener_Clients.Add(TC);
                        context.SaveChanges();
                        MessageBox.Show("Тренеровка добавлена");
                        Close();
                    }
                    
                    
                   
                }
                
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
