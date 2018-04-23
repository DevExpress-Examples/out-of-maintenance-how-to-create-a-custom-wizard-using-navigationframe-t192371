using DevExpress.Mvvm;
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

namespace NavigationFrameWizard {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DevExpress.Xpf.Core.DXWindow {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }

        protected ObservableCollection<Customer> _Customers;

        public ObservableCollection<Customer> Customers {
            get {
                if(this._Customers == null) {
                    this._Customers = new ObservableCollection<Customer>();
                    this._Customers.Add(new Customer() { FirstName = "John", SecondName = "Newman", Birthday = DateTime.Today.AddYears(-40) });
                    this._Customers.Add(new Customer() { FirstName = "Mark", SecondName = "Bisho", Birthday = DateTime.Today.AddYears(-35) });
                }

                return this._Customers;
            }
        }

        #region AddCommand

        protected DelegateCommand _AddCommand;

        public DelegateCommand AddCommand {
            get {
                if(this._AddCommand == null) {
                    this._AddCommand = new DelegateCommand(this.AddCommandExecute, this.AddCommandCanExecute);
                }

                return this._AddCommand;
            }
        }

        protected void AddCommandExecute() {
            WizardWindow wnd = new WizardWindow();
            wnd.Owner = this;
            wnd.ShowDialog();
            if((wnd.Tag as bool?).HasValue && (wnd.Tag as bool?).Value) {
                this.Customers.Add((wnd.DataContext as WizardViewModel).Customer);
            }
        }

        protected bool AddCommandCanExecute() {
            bool result = true;
            // Enter your checking of availability of comand here
            return result;
        }

        #endregion AddCommand
    }
}
