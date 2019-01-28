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
using RobotLib;

namespace Homework01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Robot rob;

        public MainWindow()
        {
            InitializeComponent();
            rob = new Robot();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            canvasMain.Width = gridMain.ActualWidth;
            canvasMain.Height = gridMain.ActualHeight;
            Drawer.DrawField(canvasMain, fieldX, fieldY);
            Drawer.DrawRobot(canvasMain, fieldX, fieldY, posX, posY);
        }

        int fieldX, fieldY;
        int posX, posY;

        private void TextBox_TextChanged_Field_X(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text != "")
                fieldX = int.Parse(((TextBox)sender).Text);
        }

        private void TextBox_TextChanged_Field_Y(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text != "")
                fieldY = int.Parse(((TextBox)sender).Text);
        }

        private void TextBox_TextChanged_Field_posX(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text != "")
                posX = int.Parse(((TextBox)sender).Text);
        }

        private void TextBox_TextChanged_Field_posY(object sender, TextChangedEventArgs e)
        {

            if (((TextBox)sender).Text != "")
                posY = int.Parse(((TextBox)sender).Text);
        }
    }

    public class Drawer
    {
        public static void DrawField(Canvas canvas, int x, int y)
        {
            canvas.Background = Brushes.WhiteSmoke;
            double width = canvas.ActualWidth;
            double height = canvas.ActualHeight;
            for (double i = 0; i <= x; ++i)
            {
                canvas.Children.Add(GetLine(0, i / x * height, width, i / x * height));
            }
            for (double i = 0; i <= y; ++i)
            {
                canvas.Children.Add(GetLine(i / y * width, 0, i / y * width, height));
            }
        }
        
        public static void DrawRobot(Canvas canvas, int x, int y, int posX, int posY)
        {
            double width = canvas.ActualWidth / x;
            double height = canvas.ActualHeight / y;
            Ellipse ellipse = new Ellipse();
            ellipse.Margin = new Thickness(posX * width, posY * height, 0, 0);
            ellipse.Height = height;
            ellipse.Width = width;
            ellipse.Fill = Brushes.MediumVioletRed;
            canvas.Children.Add(ellipse);
        }

        public static Line GetLine(double x1, double y1, double x2, double y2)
        {
            Line line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 2;
            line.HorizontalAlignment = HorizontalAlignment.Left;
            line.VerticalAlignment = VerticalAlignment.Center;
            return line;
        }
    }
}
