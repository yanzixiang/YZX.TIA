using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;
using Siemens.Automation.ObjectFrame;

namespace YZX.Tia.Dlc
{
  partial class IWorkingContextExtensions
  {
    public static ICoreContextHandler GetCoreContextHandler(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<ICoreContextHandler>("Siemens.Automation.CommonServices.CoreContextHandler");
    }

    public static ICoreContext GetCoreContext(this IWorkingContext workingContext)
    {
      return workingContext.GetCoreContextHandler().CoreContext;
    }
  }
}
