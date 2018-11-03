using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.Menu;
using Siemens.Automation.FrameApplication.StatusBar;

using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static StatusBarProxy GetStatusBar([NotNull] this IWorkingContext workingContext)
    {
      StatusBarDlc dlc = workingContext.GetRequiredDlc<StatusBarDlc>("Siemens.Automation.FrameApplication.StatusBar");
      return new StatusBarProxy(dlc);
    }

    public static MenuServiceImplementationProxy GetStatusBar([NotNull] this IWorkingContext workingContext)
    {
      MenuService dlc = workingContext.GetRequiredDlc<MenuService>("Siemens.Automation.FrameApplication.Menu.MenuService");
      return new MenuServiceImplementationProxy(dlc);
    }


  }
}
