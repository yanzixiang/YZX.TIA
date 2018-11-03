using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;

using Siemens.Simatic.PlcLanguages.Utilities;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static ICommandProcessor GetCommandProcessor([NotNull] this IWorkingContext workingContext)
    {
      ICommandProcessor commandProcessor = DlcIdExtensions.LoadByDlcId(workingContext.DlcManager, DlcIds.Platform.CommonServices.CommandProcessor);
      return commandProcessor;
    }
  }
}
