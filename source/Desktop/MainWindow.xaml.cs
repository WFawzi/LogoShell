using Engine;
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

namespace Logo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        double _x = 0.0d;
        double _y = 0.0d;
        double _direction = 0.0d;

        SolidColorBrush colour = Brushes.Black;

        public MainWindow()
        {
            InitializeComponent();
            UserScriptBox.Text =
@"#You can access the cursor using $turtle.
#Move the cursor forward by pixels with $turtle.MoveForward(pixelCount)
#Turn the cursor by degress with $turtle.Turn(degrees)

$i = 0;

while($i -lt 4) {
  $turtle.MoveForward(100);
  $turtle.Turn(90);
  $i = $i + 1;
}
";
        }

        private void ExecuteDrawing(object sender, RoutedEventArgs e)
        {
            var width = LogoCanvas.ActualWidth;
            var height = LogoCanvas.ActualHeight;

            var turtle = PowerShellEnvironment.ExecuteTurtleScript(_x, _y, _direction, UserScriptBox.Text);

            var path = new Polyline();

            foreach (var point in turtle.Path)
            {
                //translate Turtle coordinate system to Canvas coordinates
                //Turtle(0,0) == Canvas(width/2, height/2)
                var canvasX = (width / 2) + point.X;
                var canvasY = (height / 2) - point.Y;

                path.Points.Add(new Point(canvasX, canvasY));
            }
            path.StrokeThickness = 2;

            path.Stroke = colour;

            LogoCanvas.Children.Add(path); //add new drawing

            _x = turtle.Position.X;
            _y = turtle.Position.Y;
            _direction = turtle.Direction;
        }

        private void ExecuteClearCanvas(object sender, RoutedEventArgs e)
        {
            LogoCanvas.Children.Clear(); //remove all previous drawings

            _x = 0;
            _y = 0;
            _direction = 0;
        }

        private void ExecuteChangeBrushColour(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            switch (comboBox.SelectedItem as string)
            {
                case "Black":
                    {
                        colour = Brushes.Black;
                        break;
                    }
                case "Blue":
                    {
                        colour = Brushes.Blue;
                        break;
                    }
                case "Green":
                    {
                        colour = Brushes.Green;
                        break;
                    }
                default:
                    {
                        colour = Brushes.Black;
                        break;
                    }
            }
        }

        private void LoadComboBox(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Black");
            data.Add("Blue");
            data.Add("Green");

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
    }
}
