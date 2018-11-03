using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.Portal.Views;

using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static OpenProjectViewDlcProxy GetOpenProjectViewDlc([NotNull] this IWorkingContext workingContext)
    {
      OpenProjectViewDlc dlc = workingContext.GetRequiredDlc<OpenProjectViewDlc>("Siemens.Automation.FrameApplication.Portal.Views.OpenProjectViewDlc");
      return new OpenProjectViewDlcProxy(dlc);
    }
  }
}
