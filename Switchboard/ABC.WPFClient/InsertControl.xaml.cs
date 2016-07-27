using ABC.DataContracts;
using ABC.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ABC.WPFClient
{
    /// <summary>
    /// Interaction logic for InsertControl.xaml
    /// </summary>
    public partial class InsertControl : UserControl, INotifyPropertyChanged
    {
        public InsertControl()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = this;
            }
        }

        // All user controls get a switcboard.
        private Switchboard _switchboard = new Switchboard();
        public Switchboard Switchboard
        {
            get
            {
                return _switchboard;
            }
            set
            {
                _switchboard = value;
            }
        }

        Customer _customer = new Customer();

        public string First
        {
            get
            {
                return _customer.First;
            }
            set
            {
                _customer.First = value;
            }
        }

        public string Last
        {
            get
            {
                return _customer.Last;
            }
            set
            {
                _customer.Last = value; 
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            var factory = new ManagerFactory();
            var customerManager = factory.Create<ICustomerManager>();
            customerManager.Insert(_customer);
            _customer = new Customer();
            RaisePropertyChanged("First");
            RaisePropertyChanged("Last");

            // after we save, lets tell everyone
            Switchboard.FireOnCustomerInserted();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
