using System.Collections.Generic;

using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services.Common;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Extensions.Diagnostic
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
