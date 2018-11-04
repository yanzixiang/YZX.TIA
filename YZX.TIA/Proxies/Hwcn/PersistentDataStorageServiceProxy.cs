using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.HwConfiguration.Application.UserInterface.Basics.Controller;

using Reflection;

namespace YZX.Tia.Proxies.Hwcn
{
  public class PersistentDataStorageServiceProxy
  {
    internal PersistentDataStorageService PersistentDataStorageService;

    internal PersistentDataStorageServiceProxy(PersistentDataStorageService dlc)
    {
      this.PersistentDataStorageService = dlc;
    }

    public OnlineDeviceServiceProxy OnlineDeviceService
    {
      get
      {
        var service = Reflector.GetInstanceFieldByName(PersistentDataStorageService,
          "m_OnlineDeviceService", ReflectionWays.SystemReflection) 
          as OnlineDeviceService;
        return new OnlineDeviceServiceProxy(service);
      }
    }
  }
}
