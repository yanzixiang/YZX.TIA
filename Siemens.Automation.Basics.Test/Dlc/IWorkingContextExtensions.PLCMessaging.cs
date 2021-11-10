using Siemens.Automation.Basics;

using Siemens.Simatic.PLCMessaging.GUI;
#if TIAV13
#else
using Siemens.Simatic.PLCMessaging.UI;
#endif

namespace YZX.Tia.Dlc
{
  partial class IWorkingContextExtensions
  {
    public static PLCMessagingWindow GetPLCMessagingWindow(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<PLCMessagingWindow>("Siemens.Simatic.PLCMessaging.GUI.PLCMessagingWindow");
    }

    public static ArchiveGridService GetArchiveGridService(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<ArchiveGridService>("Siemens.Simatic.PLCMessaging.GUI.ArchiveGridService");
    }

    public static AlarmGridService GetAlarmGridService(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<AlarmGridService>("Siemens.Simatic.PLCMessaging.GUI.AlarmGridService");
    }

    #if TIAV13
    #else
    public static PlcMessagingView GetPlcMessagingView(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<PlcMessagingView>("Siemens.Simatic.PLCMessaging.GUI.PlcMessagingView");
    }
    #endif

  }
}
