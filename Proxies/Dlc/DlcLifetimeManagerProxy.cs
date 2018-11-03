using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics;

namespace YZX.Tia.Proxies.Dlc
{
  public class DlcLifetimeManagerProxy
  {
    internal DlcLifetimeManager DlcLifetimeManager;
    public DlcLifetimeManagerProxy(IDlcLifetimeManager manager)
    {
      DlcLifetimeManager = manager as DlcLifetimeManager;
    }
  }
}
