using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.GraphBlockLogic;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static GraphOnlineService GetGraphOnlineService([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<GraphOnlineService>("GraphBlockLogic.GraphOnlineService<");
    }
  }
}
