using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.Navigation.Project.Main;

using YZX.Tia.Proxies;
using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static RootObjectHostServiceProxy GetRootObjectHostService([NotNull] this IWorkingContext workingContext)
    {
      RootObjectHostService dlc = workingContext.GetRequiredDlc<RootObjectHostService>("Siemens.Automation.FrameApplication.RootObjectHostService");
      return new RootObjectHostServiceProxy(dlc);
    }

    public static ProjectNavigatorLoaderProxy GetProjectNavigatorLoader([NotNull] this IWorkingContext workingContext)
    {
      ProjectNavigatorLoader dlc = workingContext.GetRequiredDlc<ProjectNavigatorLoader>("Siemens.Automation.FrameApplication.ProjectNavigatorLoader");
      return new ProjectNavigatorLoaderProxy(dlc);
    }

    
  }
}
