using System;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.Menu;
using Siemens.Automation.FrameApplication.StatusBar;

using YZX.Tia.Proxies.FrameApplication;
using YZX.Tia.Dlc;

namespace YZX.Tia.Extensions.FrameApplication
{
  public static partial class FrameApplicationExtensions
  {
    public static StatusBarProxy GetStatusBar(this IWorkingContext workingContext)
    {
      StatusBarDlc dlc = workingContext.GetRequiredDlc<StatusBarDlc>("Siemens.Automation.FrameApplication.StatusBar");
      return new StatusBarProxy(dlc);
    }

    public static MenuServiceImplementationProxy GetMenuService(this IWorkingContext workingContext)
    {
      MenuService dlc = workingContext.GetRequiredDlc<MenuService>("Siemens.Automation.FrameApplication.Menu.MenuService");
      return new MenuServiceImplementationProxy(dlc);
    }


  }
}
