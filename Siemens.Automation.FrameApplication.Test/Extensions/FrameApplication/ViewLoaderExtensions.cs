using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.ViewManager;

namespace YZX.Tia.Extensions.FrameApplication
{
  public static class ViewLoaderExtensions
  {
    public static IView LoadViewFromDLCManager(this IWorkingContext workingContext,string viewID)
    {
      return ViewLoader.LoadViewFromDLCManager(viewID, workingContext);
    }
    public static IViewDomainLogic LoadViewDomainLogicFromDLCManager(this IWorkingContext workingContext, string domainLogicID)
    {
      return ViewLoader.LoadViewDomainLogicFromDLCManager(domainLogicID, workingContext);
    }
  }
}
