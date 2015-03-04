using Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
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
        double x = 0.0d;
        double y = 0.0d;
        double direction = 0.0d;

        string colour = "Black";
        //


        public MainWindow()
        {
            InitializeComponent();
            UserScriptBox.Text =
@"
#You can access the cursor using $input.
#Move the cursor forward by pixels with $input.MoveForward(pixelCount)
#Turn the cursor by degress with $input.Turn(degrees)

$input.MoveForward(100);
$input.Turn(90);
$input.MoveForward(100);
";
        }

        private void ExecuteDrawing(object sender, RoutedEventArgs e)
        {
            var width = LogoCanvas.ActualWidth;
            var height = LogoCanvas.ActualHeight;

            var turtle = RunPowerShellScript(UserScriptBox.Text);

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


            //
            switch (colour)
            {
                case "Black":
                    {
                        path.Stroke = Brushes.Black;
                        break;
                    }
                case "Blue":
                    {
                        path.Stroke = Brushes.Blue;
                        break;
                    }
                case "Green":
                    {
                        path.Stroke = Brushes.Green;
                        break;
                    }
                    path.Stroke = Brushes.Black;
            }

            //path.Stroke = Brushes.Black;

            //

            LogoCanvas.Children.Add(path); //add new drawing

            //
            x = turtle.Position.X;
            y = turtle.Position.Y;
            direction = turtle.Direction;
            //
        }

        private Turtle RunPowerShellScript(string script)
        {
            var turtle = new Turtle(x,y,direction);

            var iss = InitialSessionState.Create();
            iss.LanguageMode = PSLanguageMode.FullLanguage;

            using (var myRunSpace = RunspaceFactory.CreateRunspace(iss))
            {
                myRunSpace.Open();
                using (var powershell = PowerShell.Create())
                {
                    powershell.Runspace = myRunSpace;

                    foreach (var line in script.Split('\n'))
                    {
                        powershell.AddStatement().AddScript(line, true);
                    }

                    powershell.Invoke(new[] { turtle });
                }
            }
            return turtle;
        }

        private void ExecuteClearCanvas(object sender, RoutedEventArgs e)
        {
            LogoCanvas.Children.Clear(); //remove all previous drawings

            x = 0;
            y = 0;
            direction = 0;
        }

        private void ExecuteChangeBrushColour(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            colour = comboBox.SelectedItem as string;
        }

        private void LoadComboBox(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Black");
            data.Add("Blue");
            data.Add("Green");

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }
    }
}
