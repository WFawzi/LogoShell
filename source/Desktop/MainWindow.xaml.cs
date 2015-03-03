using Engine;
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

namespace Logo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var size = 10;
            //var square = new Polygon();
            //square.Stroke = Brushes.Green;
            //square.Points.Add(new Point(20, 20));
            //square.Points.Add(new Point(20+size/2, 20+size/2));
            //square.Points.Add(new Point(20-size/2, 20+size/2));
            //square.RenderTransformOrigin = new Point(20, 20);
            //square.RenderTransform = new RotateTransform(90);
            
            
            //square.Fill = Brushes.Green;
            //LogoCanvas.Children.Add(square);
            
            //var line = new Polyline();
            //line.Points.Add(new Point(0,0));
            //line.Points.Add(new Point(800,800));
            //line.StrokeThickness = 3;
            //line.Stroke = Brushes.Green;
            //LogoCanvas.Children.Add(line);

            var turtle = new Turtle(200, 200);

            var path = new Polyline();

            path.Points.Add(new Point(turtle.X, turtle.Y));

            turtle.MoveForward(100);
            path.Points.Add(new Point(turtle.X, turtle.Y));
            turtle.Turn(45);
            turtle.MoveForward(100);
            path.Points.Add(new Point(turtle.X, turtle.Y));
            turtle.Turn(45);
            turtle.MoveForward(100);
            path.Points.Add(new Point(turtle.X, turtle.Y));
            turtle.Turn(45);
            turtle.MoveForward(100);
            path.Points.Add(new Point(turtle.X, turtle.Y));
            turtle.Turn(45);
            turtle.MoveForward(100);
            path.Points.Add(new Point(turtle.X, turtle.Y));
            turtle.Turn(45);
            turtle.MoveForward(100);
            path.Points.Add(new Point(turtle.X, turtle.Y));
            turtle.Turn(45);
            turtle.MoveForward(100);
            path.Points.Add(new Point(turtle.X, turtle.Y));
            turtle.Turn(45);
            turtle.MoveForward(100);
            path.Points.Add(new Point(turtle.X, turtle.Y));
            path.StrokeThickness = 2;
            path.Stroke = Brushes.Black;
            LogoCanvas.Children.Add(path);
        }
    }
}
