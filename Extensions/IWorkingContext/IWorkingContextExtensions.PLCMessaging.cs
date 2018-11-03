using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;

using Siemens.Simatic.PLCMessaging;
using Siemens.Simatic.PLCMessaging.GUI;
using Siemens.Simatic.PLCMessaging.UI;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static PLCMsgConnector GetPlcmService([NotNull] this IWorkingContext workingContext)
    {
      ICoreContext coreContext = workingContext.GetCoreContext();
      return coreContext.GetPlcmService();
    }

    public static PLCMessagingWindow GetPLCMessagingWindow([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<PLCMessagingWindow>("Siemens.Simatic.PLCMessaging.GUI.PLCMessagingWindow");
    }

    public static ArchiveGridService GetArchiveGridService([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<ArchiveGridService>("Siemens.Simatic.PLCMessaging.GUI.ArchiveGridService");
    }

    public static AlarmGridService GetAlarmGridService([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<AlarmGridService>("Siemens.Simatic.PLCMessaging.GUI.AlarmGridService");
    }

    public static PlcMessagingView GetPlcMessagingView([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<PlcMessagingView>("Siemens.Simatic.PLCMessaging.GUI.PlcMessagingView");
    }

  }
}
