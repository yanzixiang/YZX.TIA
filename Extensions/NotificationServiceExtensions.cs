using System.Collections.Generic;

using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services.Common;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class NotificationServiceExtensions
  {
    public static Dictionary<ICoreObject, IDiagNotification> GetDeviceHostObserverManagers(this NotificationService service)
    {
      return Reflector.GetInstanceFieldByName(service,
        "m_DeviceHostObserverManagers",
        ReflectionWays.SystemReflection) as Dictionary<ICoreObject, IDiagNotification>;
    }
  }
}
