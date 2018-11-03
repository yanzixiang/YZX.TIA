using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static IDlc GetMonitorLoop([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.Lang.Code.MonitorLoopFactory");
    }
  }
}
