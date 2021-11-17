using System;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.Navigation.Library.GlobalLibrary;
using Siemens.Automation.FrameApplication.Navigation.Project.Main;

using YZX.Tia.Proxies;
using YZX.Tia.Proxies.FrameApplication;
using YZX.Tia.Dlc;

namespace YZX.Tia.Extensions.FrameApplication
{
  partial class FrameApplicationExtensions
  {
    public static ProjectNavigationViewProxy ProjectNavigationView(this IWorkingContext workingContext)
    {
      ProjectNavigationView dlc = workingContext.GetRequiredDlc<ProjectNavigationView>("Siemens.Automation.FrameApplication.ProjectNavigatorView");
      return new ProjectNavigationViewProxy(dlc);
    }
  }
}
