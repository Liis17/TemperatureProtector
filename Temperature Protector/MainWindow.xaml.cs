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
using OpenHardwareMonitor.Hardware;
using System.Threading;


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
            

            /// залупа и хуета ебаная пошла нахуй
            //taskbar.IconSource = "Icon.ico";
        }

        private void SomeAction()
        {
            MessageBox.Show("A");
  
        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            this.Show();
        }

        private void MinBut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void GetCPUTemperature()
        {
            tmpInfo = string.Empty;
            Visitor visitor = new Visitor();

            Computer computer = new Computer();
            computer.Open();
            computer.Accept(visitor);
            computer.CPUEnabled = true;
            computer.MainboardEnabled = true;
            //computer.Traverse(visitor);
            computer.RAMEnabled = true;
            computer.GPUEnabled = true;

            string st = "";

            for (int i = 0; i < computer.Hardware.Length; i++)
            {
                if (computer.Hardware[i].HardwareType == HardwareType.GpuNvidia)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        st += computer.Hardware[i].Sensors[j].Identifier + " : " + computer.Hardware[i].Sensors[j].Value.ToString() + "\n";
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                        {
                            tmpInfo += computer.Hardware[i].Sensors[j].Name + ": " +
                                computer.Hardware[i].Sensors[j].Value.ToString() + "\n";
                        }
                    }
                }
            }
            
            temptextblock.Text = st;

            computer.Close();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetCPUTemperature();
        }
    }
}
