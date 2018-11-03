using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;
using Siemens.Automation.ObjectFrame;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static ICoreContextHandler GetCoreContextHandler([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<ICoreContextHandler>("Siemens.Automation.CommonServices.CoreContextHandler");
    }

    public static ICoreContext GetCoreContext([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetCoreContextHandler().CoreContext;
    }
  }
}
