using System;

using Siemens.Automation.Basics;

using Siemens.Simatic.HwConfiguration.Basics.Basics;
using Siemens.Simatic.HwConfiguration.Diagnostic.Basics;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services.Common;
using Siemens.Simatic.HwConfiguration.Diagnostic.OnlineFunctions.Services;
using Siemens.Simatic.HwConfiguration.Diagnostic.OnlineFunctions.DataSetServices.Server;
using Siemens.Simatic.HwConfiguration.EditorSupport.EditorSupport.Editor;
using Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics;
using Siemens.Simatic.HwConfiguration.Basics.Basics.Actions;

using YZX.Tia.Dlc;

namespace YZX.Tia.Extensions.Diagnostic
{
  public static class HwcnExtensions
  {
    public static EditorController GetHwcnEditorController(this IWorkingContext workingContext)
    {
      var EditorController = workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.EditorSupport.EditorController")
        as EditorController;
      return EditorController;
    }

    public static FunctionProvider GetOnlineFunctionProvider(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.FunctionProvider") as FunctionProvider;
    }

    public static OnlineObjectService GetOnlineObjectService(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineObjectService") as OnlineObjectService;
    }


    public static OnlineFunctionServer GetOnlineFunctionServer(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineFunctions.Server.OnlineFunctionServer") as OnlineFunctionServer;
    }

    public static IIconServer GetIconServer(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.IconServer") as IIconServer;
    }

    public static HwcnBasicsFacade GetHwcnBasicFacade(this IWorkingContext workingContext)
    {
      IHwcnBasicsFacade facade = workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Basics.Basics.HwcnBasicsFacade") as IHwcnBasicsFacade;
      return facade as HwcnBasicsFacade;
    }

    public static IModuleDetection GetModuleDetection(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineFunctions.Services.ModuleDetection") as IModuleDetection;
    }

    public static OnlineHostObserverProxy GetOnlineHostObserverProxy(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineHostObserver") as OnlineHostObserverProxy;
    }

    public static NotificationService GetNotificationService(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.NotificationService") as NotificationService;
    }
    public static OnlineScope GetOnlineScope(this IWorkingContext wc)
    {
      return Siemens.Simatic.HwConfiguration.Diagnostic.Common.Helper.GetOnlineScope(wc);
    }

    public static IOnlineObjectService GetDiagOnlineObjectService(IWorkingContext wc)
    {
      if (wc == null)
        throw new ArgumentNullException("wc");
      return wc.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineObjectService") as IOnlineObjectService;
    }

    public static FrameGroupManager GetHwcnFrameGroupManager(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<FrameGroupManager>("Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics.FrameGroupManager");
    }

    public static IUserControlFactory GetHwcnUserControlFactory(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<IUserControlFactory>("Siemens.Simatic.HwConfiguration.Diagnostic.Viewer.DoeUserControlFactory");
    }


  }
}
