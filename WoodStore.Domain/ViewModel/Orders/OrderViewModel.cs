using System;
using System.Collections.Generic;
using System.Text;

namespace WoodStore.Domain.ViewModel.Orders
{
    public class OrderViewModel
    {

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal OrderPrice { get; set; }

        public string ClientsComment { get; set; }

        public int СourierID { get; set; }

        public int PickerID { get; set; }

        public int ClientID { get; set; }

        public int SalesManagerID { get; set; }
    }
}
