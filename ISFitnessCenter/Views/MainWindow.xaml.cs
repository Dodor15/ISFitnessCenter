using ISFitnessCenter.Models;
using ISFitnessCenter.Views;
using ISFitnessCenter.Views.Frames;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISFitnessCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    
    public partial class MainWindow : Window
    {
        public List<Client> Clients = new List<Client>();
        public MainWindow()
        {
            InitializeComponent();
            
        }
    }
}