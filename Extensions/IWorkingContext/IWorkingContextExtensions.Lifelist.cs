using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.UI.OnlineCommon;
using Siemens.Automation.DomainServices.OnlineService;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static LifelistActivator GetLifelistActivator([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.LifelistActivator") as LifelistActivator;
    }
    

    public static ILifelistService GetLifelist([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.LifelistService") as ILifelistService;
    }

    public static LifeListView GetLifeListView([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.UI.OnlineCommon.LifeListView") as LifeListView;
    }

    public static LifeListEmbeddedPortalView GetLifeListEmbeddedPortalView([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.UI.OnlineCommon.LifeListEmbeddedPortalView") as LifeListEmbeddedPortalView;
    }

    public static LifelistBrowserExtension GetLifelistBrowserExtension([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<LifelistBrowserExtension>("Siemens.Automation.DomainServices.LifelistBrowserExtension");
    }

    public static LifelistPNVBrowserExtension GetLifelistPNVBrowserExtension([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<LifelistPNVBrowserExtension>("Siemens.Automation.DomainServices.LifelistPNVBrowserExtension");
    }
  }
}
