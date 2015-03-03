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

            var turtle = RunPowerShellScript(UserScriptBox.Text);

            var path = new Polyline();

            
            foreach (var point in turtle.Path)
            {
                //translate Turtle coordinate system to Canvas coordinates
                //Turtle(0,0) == Canvas(width/2, height/2)
                var canvasX = (width / 2) + point.X;
                var canvasY = (height / 2) - point.Y;

                //path.Points.Add(new Point(point.X, point.Y));
                path.Points.Add(new Point(canvasX, canvasY));
            }
            path.StrokeThickness = 2;
            path.Stroke = Brushes.Black;

            LogoCanvas.Children.Clear(); //remove all previous drawings
            LogoCanvas.Children.Add(path); //add new drawing
        }

        private Turtle RunPowerShellScript(string script)
        {
            var turtle = new Turtle();

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
    }
}
