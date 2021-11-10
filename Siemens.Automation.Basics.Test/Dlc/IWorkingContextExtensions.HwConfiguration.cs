using Siemens.Automation.Basics;
using Siemens.Simatic.HwConfiguration.Basics.Basics;
using Siemens.Simatic.HwConfiguration.Basics.Meta;
using Siemens.Simatic.HwConfiguration.Basics.SystemData;

namespace YZX.Tia.Dlc
{
  partial class IWorkingContextExtensions
  {
    public static TargetValidation GetTargetValidation(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<TargetValidation>("Siemens.Simatic.HwConfiguration.Basics.SystemData.TargetValidation");
    }

    public static HwcnBasicsFacade GetHwcnBasicsFacade(this IWorkingContext workingContext)
    {
      var hwcnBasicsFacade = workingContext.GetRequiredDlc<HwcnBasicsFacade>("Siemens.Simatic.HwConfiguration.Basics.Basics.HwcnBasicsFacade");
      return hwcnBasicsFacade;
    }

    public static IHwcnFileProvider GetHwcnFileProvider(this IWorkingContext workingContext)
    {
      var IHwcnFileProvider = workingContext.GetRequiredDlc<IHwcnFileProvider>("Siemens.Simatic.HwConfiguration.Basics.Meta.HwcnFileProvider");
      return IHwcnFileProvider;
    }

    public static IHwcnMetaService GetIHwcnMetaService(this IWorkingContext workingContext)
    {
      var IHwcnFileProvider = workingContext.GetRequiredDlc<IHwcnMetaService>("Siemens.Simatic.HwConfiguration.Basics.Meta.HwcnMetaService");
      return IHwcnFileProvider;
    }

  }
}
