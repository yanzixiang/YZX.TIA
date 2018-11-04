using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.Menu;

using Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class MenuServiceImplementationProxy
  {
    internal MenuService MenuService;
    internal MenuServiceImplementation MenuServiceImplementation;

    public MenuServiceImplementationProxy(IDlc dlc)
    {
      MenuService = dlc as MenuService;
      if(MenuService != null)
      {
        MenuServiceImplementation = Reflector.GetInstanceFieldByName(MenuService,
          "m_MenuServiceImplementation", 
          ReflectionWays.SystemReflection) 
          as MenuServiceImplementation;
      }
    }
  }
}
