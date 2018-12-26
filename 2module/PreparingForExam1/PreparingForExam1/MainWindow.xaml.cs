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
using University;

namespace PreparingForExam1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The button has been pressed");
        }

        static double F(int a, int b) { return a + b; }            //1
        static double F(double a, double b) { return a + b; }      //2
        static double F(short a, double b) { return a + b; }       //3
        static double F(short a, int b) { return a + b; }          //4
        static int F(double a, double b) { return (int)(a + b); }  //5


    }
}
