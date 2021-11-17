using System;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.Navigation.Project.Main;

using YZX.Tia.Proxies.FrameApplication;
using YZX.Tia.Dlc;

namespace YZX.Tia.Extensions.FrameApplication
{
  partial class FrameApplicationExtensions
  {
    public static RootObjectHostServiceProxy GetRootObjectHostService(this IWorkingContext workingContext)
    {
      RootObjectHostService dlc = workingContext.GetRequiredDlc<RootObjectHostService>("Siemens.Automation.FrameApplication.RootObjectHostService");
      return new RootObjectHostServiceProxy(dlc);
    }

    public static ProjectNavigatorLoaderProxy GetProjectNavigatorLoader(this IWorkingContext workingContext)
    {
      ProjectNavigatorLoader dlc = workingContext.GetRequiredDlc<ProjectNavigatorLoader>("Siemens.Automation.FrameApplication.ProjectNavigatorLoader");
      return new ProjectNavigatorLoaderProxy(dlc);
    }
  }
}
