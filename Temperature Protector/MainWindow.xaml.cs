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
using System.Threading;
using LibreHardwareMonitor.Hardware;


namespace Temperature_Protector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string title = "123";
        private string message = "321";

        private string tmpInfo = string.Empty;
         
        

        public MainWindow()
        {
            InitializeComponent();
            var notificationManager = new NotificationManager();
            notificationManager.Show(title, message, Notification.Wpf.NotificationType.Warning, onClick: () => SomeAction());

            Monitor();

            /// залупа и хуета ебаная пошла нахуй
            //taskbar.IconSource = "Icon.ico";
        } // при загрузке окна

        private void SomeAction()
        {
            MessageBox.Show("A");
  
        } // действие по нажатию на тестовое уведомление

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            this.Show();
        } // клин по иконке в трее разворачивает окно

        private void MinBut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        } // тестовое нажатие на кнопку свернуть приложение


        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Monitor();
            MessageBox.Show("update");
        }

        public void Monitor()
        {
            tmpInfo = string.Empty;

            Computer computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsControllerEnabled = true,
                IsNetworkEnabled = true,
                IsStorageEnabled = true
            };

            computer.Open();
            computer.Accept(new UpdateVisitor());

            foreach (IHardware hardware in computer.Hardware)
            {
                foreach (ISensor sensor in hardware.Sensors)
                {
                    //foreach ()
                    //{
                        

                    //}
                    Console.WriteLine("\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
                    tmpInfo += sensor.Name + " : " + sensor.Value + "\n";
                }
            }

            temptextblock.Text = tmpInfo;

            computer.Close();
        }
    }
}
