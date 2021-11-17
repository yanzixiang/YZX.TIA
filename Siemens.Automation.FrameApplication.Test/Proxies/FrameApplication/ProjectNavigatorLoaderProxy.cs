using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;
using Siemens.Automation.FrameApplication.Navigation.Project.Main;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class ProjectNavigatorLoaderProxy
  {
    internal ProjectNavigatorLoader ProjectNavigatorLoader;

    internal ProjectNavigatorLoaderProxy(ProjectNavigatorLoader loader)
    {
      ProjectNavigatorLoader = loader;
    }

    public IFrameGroup PnvPlaceHolderGroup
    {
      get
      {
        FrameGroup m_PnvPlaceHolderGroup = Reflector.GetInstanceFieldByName(ProjectNavigatorLoader,
          "m_PnvPlaceHolderGroup",
          ReflectionWays.SystemReflection) as FrameGroup;
        return m_PnvPlaceHolderGroup;
      }
    }

    public IViewFrame ProjectNavigatorViewFrame
    {
      get
      {
        IViewFrame m_ProjectNavigatorViewFrame = Reflector.GetInstanceFieldByName(ProjectNavigatorLoader,
          "m_ProjectNavigatorViewFrame",
          ReflectionWays.SystemReflection) as IViewFrame;
        return m_ProjectNavigatorViewFrame;
      }
    }

    public ProjectNavigationViewProxy NavigationView
    {
      get
      {
        ProjectNavigationView NavigationView = Reflector.GetInstancePropertyByName(ProjectNavigatorLoader,
          "NavigationView",
          ReflectionWays.SystemReflection) as ProjectNavigationView;
        ProjectNavigationViewProxy proxy = new ProjectNavigationViewProxy(NavigationView);
        return proxy;
      }
    }


  }
}
