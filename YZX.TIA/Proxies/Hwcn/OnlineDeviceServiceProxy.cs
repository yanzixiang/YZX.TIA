using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.HwConfiguration.Application.UserInterface.Basics.Controller;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services;

namespace YZX.Tia.Proxies.Hwcn
{
  public class OnlineDeviceServiceProxy
  {
    internal OnlineDeviceService OnlineDeviceService;

    internal OnlineDeviceServiceProxy(OnlineDeviceService service)
    {
      OnlineDeviceService = service;
    }

    public ICollection<ICoreObject> OnlineDevices
    {
      get
      {
        return OnlineDeviceService.OnlineDevices;
      }
    }

    public IOnlineObjectService OnlineObjectService
    {
      get
      {
        return OnlineDeviceService.OnlineObjectService;
      }
    }


  }
}
