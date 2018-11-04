using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics.Browsing;
using Siemens.Automation.FrameApplication.Navigation.Project.Main;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class ProjectNavigationViewProxy
  {
    internal ProjectNavigationView ProjectNavigationView;

    internal ProjectNavigationViewProxy(ProjectNavigationView view)
    {
      ProjectNavigationView = view;
    }

    public IBrowsableCollection RootObjects
    {
      get
      {
        return ProjectNavigationView.RootObjects;
      }
    }

  }
}
