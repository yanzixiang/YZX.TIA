using System;
using System.Collections.Generic;

using Siemens.Automation.ObjectFrame;
using Siemens.Automation.CommonServices;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Simatic.PlcLanguages.BlockLogic.PLDebug;
using Siemens.Simatic.PlcLanguages.PLInterface.PLDebug;
using Siemens.Simatic.PlcLanguages.TisServer;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

using YZX.Tia.Extensions.OnlineService;

namespace YZX.Tia.Proxies
{
  public class DebugDeviceProxy
  {
    public DebugDevice DebugDevice;

    public DebugDeviceProxy(DebugDevice dd)
    {
      DebugDevice = dd;
    }

    public ILegitimationService LegitimationService
    {
      get
      {
        return Reflector.GetInstanceFieldByName(DebugDevice, "m_LegitimationService", ReflectionWays.SystemReflection) 
          as ILegitimationService;
      }
      set
      {
        Reflector.SetInstanceFieldByName(DebugDevice, "m_LegitimationService", value, ReflectionWays.SystemReflection);
      }
    }

    public List<DebugJob> JobList
    {
      get
      {
        return DebugDevice.JobList;
      }
    }

    public ICoreObject Controller
    {
      get
      {
        return (ICoreObject)Reflector.GetInstanceFieldByName(
          DebugDevice, 
          "m_Controller", 
          ReflectionWays.SystemReflection);
      }
    }
    public IConnection Connection
    {
      get
      {
        return DebugDevice.Connection;
      }
      set
      {
        Reflector.SetInstanceFieldByName(
          DebugDevice,
          "m_Connection",
          value,
          ReflectionWays.SystemReflection);
      }
    }

    public ConnectionState ConnectionState
    {
      get
      {
        return (ConnectionState)Reflector.GetInstanceFieldByName(
          DebugDevice, 
          "m_ConnectionState", 
          ReflectionWays.SystemReflection);
      }
      set
      {
        Reflector.SetInstanceFieldByName(
          DebugDevice,
          "m_ConnectionState",
          value,
          ReflectionWays.SystemReflection);
      }
    }

    public IOnlineService OnlineService
    {
      get
      {
        return Reflector.GetInstanceFieldByName(DebugDevice, 
          "m_OnlineService", 
          ReflectionWays.SystemReflection)
          as IOnlineService;
      }
    }

    public ConnectionServiceProvider ConnectionService
    {
      get
      {
        IConnectionService ics = Reflector.GetInstanceFieldByName(DebugDevice,
          "m_ConnectionService",
          ReflectionWays.SystemReflection)
          as IConnectionService;
        return ics.ToConnectionServiceProvider();
      }
    }

    public DebugService DebugService
    {
      get
      {
        return DebugDevice.DebugService;
      }
    }

    private void OnConnectionStateChange(
      OamCallbackMessage message, 
      int Flags, 
      int referenceCount, 
      byte[] buffer, 
      DateTime timeStamp, 
      TimeSpan elapsedTime, 
      object oamSource, 
      object ClientSource)
    {
      Reflector.RunInstanceMethodByName(DebugDevice, "OnConnectionStateChange",
        ReflectionWays.SystemReflection,
        message,
        Flags,
        referenceCount,
        buffer,
        timeStamp,
        elapsedTime,
        oamSource,
        ClientSource);
    }

    public bool IsPlusDevice
    {
      get
      {
        return DebugDevice.IsPlusDevice;
      }
    }

    public event AfterConnectedHandler AfterConnected;

    public int NumberOfClients
    {
      get
      {
        return (int)Reflector.GetInstanceFieldByName(DebugDevice, "m_NumberOfClients", ReflectionWays.SystemReflection);
      }
      set
      {
        Reflector.SetInstanceFieldByName(DebugDevice, "m_NumberOfClients", value, ReflectionWays.SystemReflection);
      }
    }

    public ITisDevice TisDevice
    {
      get
      {
        object o = Reflector.GetInstanceFieldByName(DebugDevice, "m_TisDevice", ReflectionWays.SystemReflection);
        ITisDevice itd = o as ITisDevice;
        return itd;
      }
      set
      {
        Reflector.SetInstanceFieldByName(DebugDevice, "m_TisDevice", value, ReflectionWays.SystemReflection);
      }
    }

    public void FireAfterConnected(IAsyncResult ar)
    {
      AsyncConnectRequest arc = ar as AsyncConnectRequest;
      AfterConnectedEventArgs args = new AfterConnectedEventArgs();
      args.AsyncConnectRequest = arc;
      AfterConnected(this, args);
    }

    public void OnConnectToOnline(IAsyncResult iar)
    {

      Reflector.RunInstanceMethodByName(
        DebugDevice,
        "OnConnectToOnline",
        ReflectionWays.SystemReflection,
        iar);

      ConnectionState = ConnectionState.Online;

      FireAfterConnected(iar);
    }

    public delegate void AfterConnectedHandler(object sender, AfterConnectedEventArgs args);

    public class AfterConnectedEventArgs : EventArgs
    {
      public AsyncConnectRequest AsyncConnectRequest;
    }

    

    public IDebugDeviceOnlinePermission DebugDeviceOnlinePermission
    {
      get
      {
        return DebugDevice;
      }
    }

    public IMessageCell GetPermissionForOnlineSession(JobType jobType)
    {
      return DebugDeviceOnlinePermission.GetPermissionForOnlineSession(jobType);
    }

    public static bool AllowStatusForLivelist
    {
      get
      {
        return DebugDevice.AllowStatusForLivelist;
      }
      set
      {
        DebugDevice.AllowStatusForLivelist = value;
      }
    }
  }
}
