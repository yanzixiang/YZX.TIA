using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.FrameApplication.WindowManager;
using Siemens.Automation.FrameApplication;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class ProjectNavigatorFrameProxy
  {
    ProjectNavigatorFrame ProjectNavigatorFrame;

    public ProjectNavigatorFrameProxy([NotNull]IFrame frame)
    {
      ProjectNavigatorFrame = frame as ProjectNavigatorFrame;
    }

    public bool Sliding
    {
      get
      {
        return ProjectNavigatorFrame.Sliding;
      }
      set
      {
        ProjectNavigatorFrame.Sliding = value;
      }
    }

    internal ProjectNavigatorStateManager GetProjectNavigatorStateManager()
    {
      return ProjectNavigatorFrame.GetService(typeof(ProjectNavigatorStateManager)) as ProjectNavigatorStateManager;
    }

    public ProjectNavigatorStateManagerProxy GetProjectNavigatorStateManagerProxy()
    {
      var manager = GetProjectNavigatorStateManager();
      var proxy = new ProjectNavigatorStateManagerProxy(manager);
      return proxy;
    }
  }
}
