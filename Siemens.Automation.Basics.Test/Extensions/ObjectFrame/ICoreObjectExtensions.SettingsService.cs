
using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.CommonServices.SettingsService;
using Siemens.Simatic.HwConfiguration.Basics.Basics;

namespace YZX.Tia.Extensions.ObjectFrame
{
  public static partial class ICoreObjectExtensions
  {
    public static ISettingsService GetSettingsService(ICoreObject device)
    {
      ISettingsService settingsService = null;
      if (device != null)
      {
        IDlc dlc = device.Context as IDlc;
        IHwcnBasicsFacade hwcnBasicsFacade = null;
        if (dlc != null && dlc.WorkingContext != null)
          hwcnBasicsFacade = dlc.WorkingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Basics.Basics.HwcnBasicsFacade") as IHwcnBasicsFacade;
        settingsService = hwcnBasicsFacade != null ? hwcnBasicsFacade.SettingsServiceV11 : (ISettingsService)null;
      }
      return settingsService;
    }
  }
}
