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

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static EditorController GetHwcnEditorController([NotNull] this IWorkingContext workingContext)
    {
      EditorController EditorController = workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.EditorSupport.EditorController")
        as EditorController;
      return EditorController;
    }

    public static FunctionProvider GetOnlineFunctionProvider([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.FunctionProvider") as FunctionProvider;
    }

    public static OnlineObjectService GetOnlineObjectService([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineObjectService") as OnlineObjectService;
    }


    public static OnlineFunctionServer GetOnlineFunctionServer([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineFunctions.Server.OnlineFunctionServer") as OnlineFunctionServer;
    }

    public static IIconServer GetIconServer([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.IconServer") as IIconServer;
    }

    public static HwcnBasicsFacade GetHwcnBasicFacade([NotNull] this IWorkingContext workingContext)
    {
      IHwcnBasicsFacade facade = workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Basics.Basics.HwcnBasicsFacade") as IHwcnBasicsFacade;
      return facade as HwcnBasicsFacade;
    }

    public static IModuleDetection GetModuleDetection([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineFunctions.Services.ModuleDetection") as IModuleDetection;
    }

    public static OnlineHostObserverProxy GetOnlineHostObserverProxy([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineHostObserver") as OnlineHostObserverProxy;
    }

    public static NotificationService GetNotificationService([NotNull] this IWorkingContext workingContext)
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

    public static FrameGroupManager GetHwcnFrameGroupManager([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<FrameGroupManager>("Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics.FrameGroupManager");
    }

    public static IUserControlFactory GetHwcnUserControlFactory([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<IUserControlFactory>("Siemens.Simatic.HwConfiguration.Diagnostic.Viewer.DoeUserControlFactory");
    }


  }
}
