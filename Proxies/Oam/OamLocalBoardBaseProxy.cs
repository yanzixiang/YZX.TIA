using System.Collections.Generic;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamLocalBoardBaseProxy
  {
    OamLocalBoardBase OamLocalBoardBase;
    public OamLocalBoardBaseProxy(IOamLocalBoard localBoardBase)
    {
      OamLocalBoardBase = localBoardBase as OamLocalBoardBase;
    }

    public bool BoardPlcRedirected
    {
      get
      {
        return OamLocalBoardBase.BoardPlcRedirected;
      }
    }

    public bool HasOpenConnections()
    {
      return OamLocalBoardBase.HasOpenConnections();
    }

    public OamNetType NetType
    {
      get
      {
        return OamLocalBoardBase.NetType;
      }
    }

    public IEnumerable<OamNetType> SupportedNetTypes
    {
      get
      {
        return OamLocalBoardBase.SupportedNetTypes;
      }
    }

    public string BoardType
    {
      get
      {
        return OamLocalBoardBase.BoardType;
      }
    }

    public OamLocalBoardState State
    {
      get
      {
        return OamLocalBoardBase.State;
      }
    }

    public void ChangeSimulated(bool simulated, bool plcsim)
    {
      OamLocalBoardBase.ChangeSimulated(simulated, plcsim);
    }

    public void UpdateBoardState()
    {
      OamLocalBoardBase.UpdateBoardState();
    }

    public IEnumerable<IOamConfiguration> SearchActiveConfigurations()
    {
      return OamLocalBoardBase.SearchActiveConfigurations();
    }

    public int CanSaveParameters()
    {
      return OamLocalBoardBase.CanSaveParameters();
    }

    public int StartParamServer()
    {
      return OamLocalBoardBase.StartParamServer();
    }

    public int StopParamServer()
    {
      return OamLocalBoardBase.StopParamServer();
    }

    public override string ToString()
    {
      return OamLocalBoardBase.ToString() + "-" + State;
    }

  }
}
