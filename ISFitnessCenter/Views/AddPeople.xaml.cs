using Bogus;
using ISFitnessCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddPeople.xaml
    /// </summary>
    public partial class AddPeople : Window
    {
        List<Trener> trener;
        public Trener tr { get; set; }
        List<Client> clien;
        public Client cl { get; set; }
        /*Specialyty_Trener st1 = new Specialyty_Trener();*/
        public Specialyty_Trener st2 { get; set; }
        
        public AddPeople()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {

            switch (Who.SelectedIndex)
            {
                case 0:
                    List<Adress> adress;
                    using (var context = new FitnessContext())
                    {
                        adress = context.adresses.ToList();
                    }
                    var trenerTest = new Faker<Trener>(locale: "ru")
                        .RuleFor(t => t.FIOtrener, (f, t) => f.Name.FullName())
                        .RuleFor(t => t.AdressTrener, f => f.Random.ListItem(adress));

                    trener = trenerTest.Generate(Convert.ToInt32(countText.Text));
                    using (var context = new FitnessContext())
                    {
                        foreach (var tren in trener)
                        {
                            tr = tren;
                            context.Attach(tr.AdressTrener);
                            context.treners.Add(tr);
                            
                        }
                        context.SaveChanges();
                        MessageBox.Show("Сохраненно");
                    }
                    break;
                case 1:
                    var clientTest = new Faker<Client>(locale: "ru")
                        .RuleFor(c => c.FIOclient, (f, c) => f.Name.FullName())
                        .RuleFor(c => c.NumberPhone, (f, c) => f.Phone.PhoneNumber())
                        .RuleFor(c => c.Pool, f => f.Random.Bool())
                        .RuleFor(c => c.Ring, f => f.Random.Bool())
                        .RuleFor(c => c.Aerobic, f => f.Random.Bool())
                        .RuleFor(c => c.Dance, f => f.Random.Bool())
                        .RuleFor(c => c.trampoline, f => f.Random.Bool());
                    clien = clientTest.Generate(Convert.ToInt32(countText.Text));
                    using (var context = new FitnessContext())
                    {
                        foreach (var client in clien)
                        {
                            cl = client;
                            context.clients.Add(cl);
                        }
                        context.SaveChanges();
                    }
                    MessageBox.Show("Сохраненно");
                    break;
                case 2:
                   

                    using (var context = new FitnessContext())
                    {
                        List<Trener> treners = context.treners.ToList();
                        List<Specialtiy> specialtiy = context.specialtiys.ToList();

                        foreach (var ts in treners)
                        {
                            
                            Specialyty_Trener st1 = new Specialyty_Trener(); // Создаем новый объект при каждой итерации
                            st1.trenerId = ts;
                            st1.SpecialtiyId = GetRandovST(specialtiy);

                            context.specialyty_Treners.Add(st1);
                        }
                        context.SaveChanges();
                    }
                    MessageBox.Show("Сохранено");
                    break;
            }
        }
        Specialtiy GetRandovST(List<Specialtiy> st)
        {
            var rnd = new Random();
            return st[rnd.Next(st.Count-1)];
        }
    }
    
}
