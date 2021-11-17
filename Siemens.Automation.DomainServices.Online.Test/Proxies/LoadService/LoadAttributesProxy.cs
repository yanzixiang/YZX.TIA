using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices.LoadService;
using Siemens.Automation.CommonServices.SettingsService;

namespace YZX.Tia.Proxies.LoadService
{
  public static class LoadAttributesProxy
  {
    public static void SetAddressChanged(IWorkingContext workingContext, ISettingsService settingsService, ICoreObject device)
    {
      LoadAttributes.SetAddressChanged(workingContext, settingsService, device);
    }

    public static void SetDisplayDeviceAsStation(ICoreObject device, bool displayDeviceAsStation)
    {
      LoadAttributes.SetDisplayDeviceAsStation(device, displayDeviceAsStation);
    }

    public static bool GetDisplayDeviceAsStation(ICoreObject device)
    {
      return LoadAttributes.GetDisplayDeviceAsStation(device);
    }

    public static void SetLoadPosition(ICoreObject deviceOrTarget, int position)
    {
      LoadAttributes.SetLoadPosition(deviceOrTarget, position);
    }

    public static int GetLoadPosition(ICoreObject deviceOrTarget)
    {
      return LoadAttributes.GetLoadPosition(deviceOrTarget);
    }

    public static void SetHwSwDownloadRequired(ICoreObject target)
    {
      LoadAttributes.SetHwSwDownloadRequired(target);
    }

    public static void SetHwDownloadRequired(ICoreObject target)
    {
      LoadAttributes.SetHwDownloadRequired(target);
    }

    public static void SetSwDownloadRequired(ICoreObject target)
    {
      LoadAttributes.SetSwDownloadRequired(target);
    }

    public static void ResetAllAttributesHwAndOrSwDownloadRequired(ICoreObject target)
    {
      LoadAttributes.ResetAllAttributesHwAndOrSwDownloadRequired(target);
    }

    public static bool IsAttributeSetHwSwDownloadRequired(ICoreObject target)
    {
      return LoadAttributes.IsAttributeSetHwSwDownloadRequired(target);
    }

    public static bool IsAttributeSetHwDownloadRequired(ICoreObject target)
    {
      return LoadAttributes.IsAttributeSetHwDownloadRequired(target);
    }

    public static bool IsAttributeSetSwDownloadRequired(ICoreObject target)
    {
      return LoadAttributes.IsAttributeSetSwDownloadRequired(target);
    }

    public static bool SetDisplaySubHeadlineForDownloadTarget(ICoreObject device)
    {
      return LoadAttributes.SetDisplaySubHeadlineForDownloadTarget(device);
    }

    public static bool ResetDisplaySubHeadlineForDownloadTarget(ICoreObject device)
    {
      return LoadAttributes.ResetDisplaySubHeadlineForDownloadTarget(device);
    }

    public static bool DisplaySubHeadlineForDownloadTarget(ICoreObject device)
    {
      return LoadAttributes.DisplaySubHeadlineForDownloadTarget(device);
    }

    public static bool SetPrimaryDownloadTarget(ICoreObject target)
    {
      return LoadAttributes.SetPrimaryDownloadTarget(target);
    }

    public static bool ResetPrimaryDownloadTarget(ICoreObject target)
    {
      return LoadAttributes.ResetPrimaryDownloadTarget(target);
    }

    public static bool IsPrimaryDownloadTarget(ICoreObject target)
    {
      return LoadAttributes.IsPrimaryDownloadTarget(target);
    }

    public static bool SetCreateSnapshotOnCompile(ICoreObject target)
    {
      return LoadAttributes.IsSetCreateSnapshotOnCompile(target);
    }

    public static bool ResetCreateSnapshotOnCompile(ICoreObject target)
    {
      return LoadAttributes.ResetCreateSnapshotOnCompile(target);
    }

    public static bool IsSetCreateSnapshotOnCompile(ICoreObject target)
    {
      return LoadAttributes.IsSetCreateSnapshotOnCompile(target);
    }
  }
}
