using System;
using System.Collections.Generic;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

using Reflection;

namespace YZX.Tia.Proxies
{
  public class OMSConnectionProxy
  {
    OMSConnection OMSConnection;

    IOMSConnection IOMSConnection
    {
      get
      {
        return OMSConnection;
      }
    }

    public OMSConnectionProxy(IOMSConnection connection)
    {
      OMSConnection = connection as OMSConnection;
    }

    internal OamTrace Trace
    {
      get
      {
        return Reflector.GetInstanceFieldByName(OMSConnection,
          "m_Trace", ReflectionWays.SystemReflection) as OamTrace;
      }
    }

    public OamConnectionState State
    {
      get
      {
        return (OamConnectionState)Reflector.GetInstanceFieldByName(OMSConnection,
          "m_State",
          ReflectionWays.SystemReflection);
      }
    }

    public IOmsNodeControl NodeControl
    {
      get
      {
        return OMSConnection.NodeControl;
      }
    }

    public OmsNodeControlProxy NodeControlProxy
    {
      get
      {
        return new OmsNodeControlProxy(NodeControl);
      }
    }

    public int RegisterWatchdogHandler()
    {
      return OMSConnection.RegisterWatchdogHandler();
    }

    public void ConnectInternal()
    {
      Reflector.RunInstanceMethodByName(OMSConnection,
        "ConnectInternal", ReflectionWays.SystemReflection);
    }

    public void CreateStartWorkerThread()
    {
      Reflector.RunInstanceMethodByName(OMSConnection,
        "CreateStartWorkerThread", ReflectionWays.SystemReflection);
    }

    public void StopWorkerThread()
    {
      Reflector.RunInstanceMethodByName(OMSConnection,
        "StopWorkerThread", ReflectionWays.SystemReflection);
    }

  }
}
