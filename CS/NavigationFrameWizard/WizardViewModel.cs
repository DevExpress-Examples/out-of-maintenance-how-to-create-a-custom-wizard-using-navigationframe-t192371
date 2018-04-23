using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationFrameWizard {
    public class WizardViewModel : ViewModelBase{
        
        protected virtual ICurrentWindowService CurrentWindowService { get { return this.GetService<ICurrentWindowService>(); } }
        
        protected Customer _Customer;
        public Customer Customer {
            get {
                if(this._Customer == null) {
                    this._Customer = new Customer();
                }

                return this._Customer; 
            }
            set { this.SetProperty(ref this._Customer, value, "Customer"); }
        }


        protected bool? _DialogResult;
        public bool? DialogResult {
            get { return this._DialogResult; }
            set { this.SetProperty(ref this._DialogResult, value, "DialogResult"); }
        }

        #region Done

        protected DelegateCommand _Done;

        public DelegateCommand Done {
            get {
                if(this._Done == null) {
                    this._Done = new DelegateCommand(this.DoneExecute);
                }

                return this._Done;
            }
        }

        protected void DoneExecute() {
            this.DialogResult = true;
            this.CurrentWindowService.Close();
        }

        #endregion Done

        #region Cancel

        protected DelegateCommand _Cancel;

        public DelegateCommand Cancel {
            get {
                if(this._Cancel == null) {
                    this._Cancel = new DelegateCommand(this.CancelExecute);
                }

                return this._Cancel;
            }
        }

        protected void CancelExecute() {
            this.DialogResult = false;
            this.CurrentWindowService.Close();
        }

        #endregion Cancel
    }
}
