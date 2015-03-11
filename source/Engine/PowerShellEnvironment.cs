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

            script = "param([Engine.Turtle]$turtle)\n" + script;

            using (var powershell = PowerShell.Create())
            {
                powershell.AddScript(script);
                powershell.AddParameter("turtle", turtle);

                powershell.Invoke();
            }
            return turtle;
        }
    }
}
