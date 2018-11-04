using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.Basics;

namespace YZX.Tia.Proxies.Dlc
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
