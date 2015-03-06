using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class PowerShellEnvironment
    {
        public static Turtle ExecuteTurtleScript(double x, double y, double direction, string script)
        {
            var turtle = new Turtle(x, y, direction);

            var iss = InitialSessionState.Create();             //We need to add the PowerShell dll (System.Managememt.Automation) - Project -> Manage Nuget Packages -> Search for your dll, after that, right click "InitialSessionState" and resolve
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
