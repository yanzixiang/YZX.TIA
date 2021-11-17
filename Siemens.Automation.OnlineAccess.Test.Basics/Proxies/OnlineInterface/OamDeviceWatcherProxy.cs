using System;

using Siemens.Automation.OnlineAccess;

namespace YZX.Tia.Proxies
{
  public class OamDeviceWatcherProxy
  {
    OamDeviceWatcher OamDeviceWatcher;

    public OamDeviceWatcherProxy(IDisposable d)
    {
      OamDeviceWatcher = d as OamDeviceWatcher;
    }
  }
}
