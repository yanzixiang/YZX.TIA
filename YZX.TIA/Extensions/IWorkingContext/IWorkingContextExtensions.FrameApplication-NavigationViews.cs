using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.Navigation.Library.GlobalLibrary;
using Siemens.Automation.FrameApplication.Navigation.Project.Main;

using YZX.Tia.Proxies;
using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static ProjectNavigationViewProxy ProjectNavigationView([NotNull] this IWorkingContext workingContext)
    {
      ProjectNavigationView dlc = workingContext.GetRequiredDlc<ProjectNavigationView>("Siemens.Automation.FrameApplication.ProjectNavigatorView");
      return new ProjectNavigationViewProxy(dlc);
    }
  }
}
