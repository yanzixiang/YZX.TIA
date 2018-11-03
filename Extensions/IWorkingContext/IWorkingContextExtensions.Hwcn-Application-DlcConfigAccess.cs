using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.Navigation.Library.GlobalLibrary;
using Siemens.Simatic.HwConfiguration.Application.UserInterface.Basics.Controller;

using YZX.Tia.Proxies.Hwcn;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static PersistentDataStorageServiceProxy GetPersistentDataStorageService([NotNull] this IWorkingContext workingContext)
    {
      PersistentDataStorageService dlc = workingContext.GetRequiredDlc<PersistentDataStorageService>("Siemens.Simatic.HwConfiguration.Application.UserInterface.Basics.Controller.PersistentDataStorageService");
      return new PersistentDataStorageServiceProxy(dlc);
    }
  }
}
