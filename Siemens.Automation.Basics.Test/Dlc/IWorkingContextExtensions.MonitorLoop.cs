using System;

using Siemens.Automation.Basics;

namespace YZX.Tia.Dlc
{
  partial class IWorkingContextExtensions
  {
    public static IDlc GetMonitorLoop(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.Lang.Code.MonitorLoopFactory");
    }
  }
}
