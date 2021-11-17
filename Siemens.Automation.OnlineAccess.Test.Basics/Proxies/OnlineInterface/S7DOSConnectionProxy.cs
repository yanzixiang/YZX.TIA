using System.Collections.Generic;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class S7DOSConnectionProxy : OamConnectionProxy
  {
    S7DOSConnection S7DOSConnection;
    public S7DOSConnectionProxy(OamConnectionBase connection)
      : base(connection)
    {
      {
        S7DOSConnection = connection as S7DOSConnection;
      }
    }

    List<OamAsynchronousCommand> ActiveAsynchronousComands
    {
      get
      {
        return S7DOSConnection.ActiveAsynchronousComands;
      }
    }

    public bool DisconnectByBackgroundControl
    {
      get
      {
        return S7DOSConnection.DisconnectByBackgroundControl;
      }
    }

    public IOamAddress Address
    {
      get
      {
        return S7DOSConnection.Address;
      }
    }

    public OamJobControl JobControlInt
    {
      get
      {
        return S7DOSConnection.JobControlInt;
      }
    }

    public string LogDevice
    {
      get
      {
        return S7DOSConnection.LogDevice;
      }
    }

    public OamConnectionOpenModes Openmode
    {
      get
      {
        return S7DOSConnection.Openmode;
      }
      set
      {
        S7DOSConnection.Openmode = value;
      }
    }

    public bool SynchronousDisconnected
    {
      get
      {
        return S7DOSConnection.SynchronousDisconnected;
      }
      set
      {
        S7DOSConnection.SynchronousDisconnected = value;
      }
    }

    public bool AreAllJobsStoppedForThisConnection
    {
      get
      {
        return S7DOSConnection.AreAllJobsStoppedForThisConnection;
      }
      set
      {
        S7DOSConnection.AreAllJobsStoppedForThisConnection = value;
      }
    }

    public bool IsConnectionEstablishedByJob
    {
      get
      {
        return S7DOSConnection.IsConnectionEstablishedByJob;
      }
      set
      {
        S7DOSConnection.IsConnectionEstablishedByJob = value;
      }
    }
  }
}
