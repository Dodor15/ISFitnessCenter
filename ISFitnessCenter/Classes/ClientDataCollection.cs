using ISFitnessCenter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFitnessCenter.Classes
{
    public class ClientDataCollection : ObservableCollection<Client>
    {
        public delegate void DataAddedEventHandler(Client entity);
        public event DataAddedEventHandler DataAdded;

        protected override void InsertItem(int index, Client item)
        {
            base.InsertItem(index, item);
            DataAdded?.Invoke(item); // вызов события о добавлении нового элемента
        }
    }
}
