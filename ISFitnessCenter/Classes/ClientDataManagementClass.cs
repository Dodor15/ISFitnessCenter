using ISFitnessCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ISFitnessCenter.Classes
{
    public class ClientDataManagementClass
    {
        public ClientDataCollection DataCollection { get; set; }

        public ClientDataManagementClass()
        {
            DataCollection = new ClientDataCollection();
            DataCollection.DataAdded += HandleDataAddedEvent; //подписываемся на событие добавления данных
        }
        private void HandleDataAddedEvent(Client entity)
        {
            var context = new FitnessContext();
            context.clients.Add(entity);
            try
            {

                context.SaveChanges();
                MessageBox.Show("Saved");
                
            }
            catch
            {
                MessageBox.Show("Not saved");
            }




            //Обработка события добавления данных
            //добавьте здесь логику для обновления пользовательского интерфейса, возможно обновление ListView
        }
    }
}
