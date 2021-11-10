using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;

using Siemens.Simatic.PlcLanguages.Utilities;

namespace YZX.Tia.Dlc
{
  partial class IWorkingContextExtensions
  {
    public static ICommandProcessor GetCommandProcessor(this IWorkingContext workingContext)
    {
      ICommandProcessor commandProcessor = DlcIdExtensions.LoadByDlcId(workingContext.DlcManager, DlcIds.Platform.CommonServices.CommandProcessor);
      return commandProcessor;
    }
  }
}
