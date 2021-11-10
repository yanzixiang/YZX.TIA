using System;

using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.UI.OnlineCommon;
using Siemens.Automation.DomainServices.OnlineService;

namespace YZX.Tia.Dlc
{
  partial class IWorkingContextExtensions
  {
    public static LifelistActivator GetLifelistActivator(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.LifelistActivator") as LifelistActivator;
    }
    

    public static ILifelistService GetLifelist(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.LifelistService") as ILifelistService;
    }

    public static LifeListView GetLifeListView(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.UI.OnlineCommon.LifeListView") as LifeListView;
    }

    public static LifeListEmbeddedPortalView GetLifeListEmbeddedPortalView(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.UI.OnlineCommon.LifeListEmbeddedPortalView") as LifeListEmbeddedPortalView;
    }

    public static LifelistBrowserExtension GetLifelistBrowserExtension(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<LifelistBrowserExtension>("Siemens.Automation.DomainServices.LifelistBrowserExtension");
    }

    public static LifelistPNVBrowserExtension GetLifelistPNVBrowserExtension(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<LifelistPNVBrowserExtension>("Siemens.Automation.DomainServices.LifelistPNVBrowserExtension");
    }
  }
}
