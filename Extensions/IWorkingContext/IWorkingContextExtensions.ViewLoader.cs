using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.ViewManager;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static IView LoadViewFromDLCManager([NotNull] this IWorkingContext workingContext,string viewID)
    {
      return ViewLoader.LoadViewFromDLCManager(viewID, workingContext);
    }
    public static IViewDomainLogic LoadViewDomainLogicFromDLCManager([NotNull] this IWorkingContext workingContext, string domainLogicID)
    {
      return ViewLoader.LoadViewDomainLogicFromDLCManager(domainLogicID, workingContext);
    }

  }
}
