using Siemens.Automation.FrameApplication;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.Basics;

namespace YZX.Tia.Proxies.FrameApplication
{
  public static class WorkingContextAccessProxy
  {
    public static IWorkingContext GetWorkingContext(this ICoreContext coreContext)
    {
      return WorkingContextAccess.GetWorkingContext(coreContext);
    }

    public static IWorkingContext GetWorkingContext(this ICorePersistence corePersistence)
    {
      return WorkingContextAccess.GetWorkingContext(corePersistence);
    }
  }
}
