using ISFitnessCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
    /// Логика взаимодействия для Treners.xaml
    /// </summary>

    
    public partial class Treners : Page
    {
        public ObservableCollection<Specialtiy> trenerList { get; set; }
        public Treners()
        {
            trenerList = new ObservableCollection<Specialtiy>();
            using (var context = new FitnessContext())
            {
                foreach (var cl in context.specialtiys.Include(c=>c.zalsId).ToList())
                {
                    trenerList.Add(cl);
                }
            
            }
                
            InitializeComponent();
            spec.ItemsSource = trenerList;

        }

        private void spec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
