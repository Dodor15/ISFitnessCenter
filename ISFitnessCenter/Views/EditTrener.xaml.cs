using ISFitnessCenter.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
using System.Windows.Shapes;

namespace ISFitnessCenter.Views
{
    /// <summary>
    /// Логика взаимодействия для EditTrener.xaml
    /// </summary>
    public partial class EditTrener : Window
    {
        public Trener trener = new Trener();
        public Schedule Sch = new();
        public List<Specialtiy> specialtiy = new();
        public EditTrener(TrenerLog trenerLog)
        {
            using (var context = new FitnessContext())
            {
                specialtiy = context.specialtiys.ToList();
                trener = context.treners.Where(c => c == trenerLog.trener).First();
                Sch = context.schedules.Where(c => c.trenerId == trener).First();
            }
            InitializeComponent();
            specCombo.ItemsSource = specialtiy;
            if (Sch.Mondeay)
                Mondeay.IsChecked = true;
            if (Sch.Tuesday)
                Tuesday.IsChecked = true;
            if (Sch.Wednesday)
                Wednesday.IsChecked = true;
            if (Sch.Thursday)
                Thursday.IsChecked = true;
            if (Sch.Ftiday)
                Ftiday.IsChecked = true;
            if (Sch.Saturday)
                Saturday.IsChecked = true;
            if (Sch.Sunday)
                Sunday.IsChecked = true;
            FioTrenerLabel.Content = trener.FIOtrener;
        }

        private void editTrenButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FitnessContext())
            {
                if (Mondeay.IsChecked == true)
                    Sch.Mondeay = true;
                else
                    Sch.Mondeay = false;
                if (Tuesday.IsChecked == true)
                {
                    Sch.Tuesday = true;
                }
                else
                    Sch.Tuesday = false;
                if (Wednesday.IsChecked == true)
                {
                    Sch.Wednesday = true;
                }
                else
                    Sch.Wednesday = false;
                if (Thursday.IsChecked == true)
                {
                    Sch.Thursday = true;
                }
                else
                    Sch.Thursday = false;
                if (Ftiday.IsChecked == true)
                {
                    Sch.Ftiday = true;
                }
                else
                    Sch.Ftiday = false;
                if (Saturday.IsChecked == true)
                {
                    Sch.Saturday = true;
                }
                else
                    Sch.Saturday = false;
                if (Sunday.IsChecked == true)
                {
                    Sch.Sunday = true;
                }
                else
                    Sch.Sunday = false;
                context.schedules.Update(Sch);
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

        private void AddSpecButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FitnessContext())
            {
                
                try
                {
                    Specialyty_Trener specialyty_Trener = context.specialyty_Treners.Where(c => c.trenerId == trener).First();
                    Specialyty_Trener check = context.specialyty_Treners.Where(c => c.trenerId == specialyty_Trener.trenerId && c.SpecialtiyId == (Specialtiy)specCombo.SelectedItem).First();
                    MessageBox.Show("Такая специальность уже есть");
                }
                catch
                {
                    Specialyty_Trener specialyty_Trener = new()
                    {
                        trenerId = trener,
                        SpecialtiyId = (Specialtiy)specCombo.SelectedItem
                    };
                    MessageBox.Show("Специальность добавлена");
                }
            }
        }
    }
}
