using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices.Internal.OemCustomization;

using YZX.Tia.Proxies.OEM;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    internal static UIOemCustomizationServiceProxy GetUIOemCustomizationServiceDlcProxy([NotNull] this IWorkingContext workingContext)
    {
      UIOemCustomizationServiceDlc dlc = workingContext.GetRequiredDlc<UIOemCustomizationServiceDlc>("Siemens.Automation.CommonServices.UIOemCustomizationService");
      return new UIOemCustomizationServiceProxy(dlc);
    }
  }
}
