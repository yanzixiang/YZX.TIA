using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Automation.Basics.Browsing;
using Siemens.Automation.ObjectFrame;

using Reflection;

namespace YZX.Tia.Extensions.Lifelist
{
  public static class LifelistPNVBrowserExtensionExtensions
  {
    public static IBrowsableCollection GetNodesFromBoard(this LifelistPNVBrowserExtension browser,
      ICoreObject board)
    {
      IBrowsableCollection collection = Reflector.RunInstanceMethodByName(browser, "GetNodesFromBoard", 
        ReflectionWays.SystemReflection,
        board,
        "LifelistNodes" 
        ) as IBrowsableCollection;
      return collection;
    }

    public static ICoreContext GetLifelistProject(this LifelistPNVBrowserExtension browser)
    {
      ICoreContext context = Reflector.GetInstancePropertyByName(browser, "LifelistProject", 
        ReflectionWays.SystemReflection) as ICoreContext;

      return context;
    }
  }
}
