using Notification.Wpf;
using System;
using System.Collections.Generic;
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

namespace Temperature_Protector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string title = "123";
        private string message = "321";
         
        

        public MainWindow()
        {
            InitializeComponent();
            var notificationManager = new NotificationManager();
            notificationManager.Show(title, message, NotificationType.Warning, onClick: () => SomeAction());

        }

        private void SomeAction()
        {
            MessageBox.Show("A");
        }
    }
}
