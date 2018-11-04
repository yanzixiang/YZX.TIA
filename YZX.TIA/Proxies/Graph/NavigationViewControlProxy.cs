using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.UI.Controls;

using Siemens.Simatic.PlcLanguages.GraphEditor.Frame;

namespace YZX.Tia.Proxies.Graph
{
  public class NavigationViewControlProxy
  {
    private NavigationViewControl navigationViewControl;

    public NavigationViewControlProxy(UserControl navigationViewControl)
    {
      this.navigationViewControl = navigationViewControl as NavigationViewControl;
    }
  }
}
