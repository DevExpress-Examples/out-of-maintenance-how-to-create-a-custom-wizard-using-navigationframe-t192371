using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationFrameWizard {
    public class Order : INotifyPropertyChanged {

        protected DateTime _Date;

        public DateTime Date {
            get {
                return this._Date;
            }

            set {
                if(this._Date != value) {
                    this._Date = value;
                    this.OnPropertyChanged("Date");
                }
            }
        }
        
        protected string _Description;

        public string Description {
            get {
                return this._Description;
            }

            set {
                if(this._Description != value) {
                    this._Description = value;
                    this.OnPropertyChanged("Description");
                }
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
