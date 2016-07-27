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
    /// Interaction logic for ListControl.xaml
    /// </summary>
    public partial class ListControl : UserControl, INotifyPropertyChanged
    {
        public ListControl()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = this;
                Loaded += ListControl_Loaded;
            }
        }

        Customer[] _list = new Customer[] { };
        public Customer[] List
        {
            get
            {
                return _list;
            }
        }

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
                _switchboard.OnCustomerInserted += _switchboard_OnCustomerInserted;
            }
        }

        private void _switchboard_OnCustomerInserted(object sender, EventArgs e)
        {
            Reload();
        }

        private void ListControl_Loaded(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            var factory = new ManagerFactory();
            var customerManager = factory.Create<ICustomerManager>();
            _list = customerManager.All();
            RaisePropertyChanged("List");    
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
