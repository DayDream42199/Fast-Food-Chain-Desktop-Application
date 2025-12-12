using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.TableHandler
{
    public class OrderItem : INotifyPropertyChanged
    {
        private uint _orderItemID;
        private string _itemName = string.Empty; // Give it a default value
        private int _quantity;
        private decimal _price;
        public uint MenuItemID
        {
            get { return _orderItemID; }
            set { _orderItemID = value; OnPropertyChanged(); }
        }
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; OnPropertyChanged(); }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(); } // and here
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
