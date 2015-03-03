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


            var turtle = new Turtle(width / 2, height / 2);
            var turtleVariable = new SessionStateVariableEntry("$turtle", turtle, "A tasty base for soup.");

            var iss = InitialSessionState.Create();
            iss.Variables.Add(turtleVariable);
            iss.LanguageMode = PSLanguageMode.FullLanguage;

            using (var myRunSpace = RunspaceFactory.CreateRunspace(iss))
            {
                myRunSpace.Open();
                using (var powershell = PowerShell.Create())
                {
                    powershell.Runspace = myRunSpace;

                    foreach(var line in UserScriptBox.Text.Split('\n'))
                    {
                        powershell.AddStatement().AddScript(line, true);
                    }

                    powershell.Invoke(new[] { turtle });
                }
            }

            var path = new Polyline();

            foreach (var point in turtle.Path)
            {
                path.Points.Add(new Point(point.X, point.Y));
            }
            path.StrokeThickness = 2;
            path.Stroke = Brushes.Black;
            LogoCanvas.Children.Add(path);
        }
    }
}
