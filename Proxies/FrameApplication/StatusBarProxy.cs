using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics;
using Siemens.Automation.UI.Controls;
using Siemens.Automation.FrameApplication.StatusBar;

using Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class StatusBarProxy
  {
    internal StatusBarDlc StatusBarDlc;
    internal StatusBarControl StatusBarControl;
    public UserControl UserControl
    {
      get
      {
        return StatusBarControl;
      }
    }


    public StatusBarProxy(IDlc dlc)
    {
      StatusBarDlc = dlc as StatusBarDlc;
      if(StatusBarDlc != null)
      {
        StatusBarControl = Reflector.GetInstanceFieldByName(StatusBarDlc,
          "m_StatusBarControl",
          ReflectionWays.SystemReflection) as StatusBarControl;
      }
    }
  }
}
