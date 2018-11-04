using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.VATViewer;
using Siemens.Simatic.PlcLanguages.VatService;
using Siemens.Simatic.PlcLanguages.VatService.Businesslogic;
using Siemens.Simatic.PlcLanguages.BlockLogic.PLDebug;
using Siemens.Simatic.PlcLanguages.PLInterface.PLDebug;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class VatDeviceExtensions
  {
    public static IDebugDevice GetDebugDevice(this IVatDevice vd)
    {
      return Reflector.GetInstanceFieldByName(vd, "m_DebugDevice", 
        ReflectionWays.SystemReflection) 
        as IDebugDevice;
    }

    public static void SetDebugDevice(this IVatDevice vd,IDebugDevice DebugDevice)
    {
      Reflector.SetInstanceFieldByName(vd, "m_DebugDevice", 
        DebugDevice, 
        ReflectionWays.SystemReflection);
    }

    /// <summary>
    /// 加载 DebugDevice
    /// </summary>
    public static void LoadDebugDevice(this IVatDevice vd,bool force = false)
    {
      IDebugDevice m_DebugDevice = vd.GetDebugDevice();

      if (!force)
      {
        if (vd.ControllerTarget == null || vd.GetDebugDevice() != null)
          return;
      }
      m_DebugDevice = vd.Service.DebugService.GetDevice(vd.ControllerTarget);
      vd.SetDebugDevice(m_DebugDevice);
      //DeviceResultHandler m_ConnectionStateChangedCallback = 
      //  Reflector.GetInstanceFieldByName(vd, "m_ConnectionStateChangedCallback")
      //  as DeviceResultHandler;
      //m_DebugDevice.ConnectionStateChanged += m_ConnectionStateChangedCallback;
      if (ConnectionState.Online != m_DebugDevice.ConnectionState)
        return;

      //Reflector.RunInstanceMethodByName(vd, "StartReadingStatusInformation");
      //Reflector.RunInstanceMethodByName(vd, "StartMarkJob");
      Reflector.RunInstanceMethodByName(vd, "FireClientNotificationConnectionStateChange", new DeviceResultArgs()
      {
        ConnectionState = ConnectionState.Online
      });
    }
  }
}
