using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationFrameWizard {
    public class Customer : INotifyPropertyChanged {

        
        protected string _FirstName;

        public string FirstName {
            get {
                return this._FirstName;
            }

            set {
                if(this._FirstName != value) {
                    this._FirstName = value;
                    this.OnPropertyChanged("FirstName");
                }
            }
        }

        
        protected string _SecondName;

        public string SecondName {
            get {
                return this._SecondName;
            }

            set {
                if(this._SecondName != value) {
                    this._SecondName = value;
                    this.OnPropertyChanged("SecondName");
                }
            }
        }

        
        protected DateTime _Birthday;

        public DateTime Birthday {
            get {
                return this._Birthday;
            }

            set {
                if(this._Birthday != value) {
                    this._Birthday = value;
                    this.OnPropertyChanged("Birthday");
                }
            }
        }

        protected ObservableCollection<Order> _Orders;

        public ObservableCollection<Order> Orders {
            get {
                if(this._Orders == null) {
                    this._Orders = new ObservableCollection<Order>();
                }

                return this._Orders;
            }
        }

        public void OnPropertyChanged(string info) {
            if(this.PropertyChanged != null) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
