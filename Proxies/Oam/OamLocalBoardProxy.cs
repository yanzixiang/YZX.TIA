using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamLocalBoardProxy:OamLocalBoardBaseProxy
  {
    OamLocalBoard OamLocalBoard;
    public OamLocalBoardProxy(IOamLocalBoard localBoard):base(localBoard)
    {
      OamLocalBoard = localBoard as OamLocalBoard;
    }

    public string HardwareID
    {
      get
      {
        return OamLocalBoard.HardwareID;
      }
    }

    public string Unit
    {
      get
      {
        return OamLocalBoard.Unit;
      }
    }

    public string HwInstanceId
    {
      get
      {
        return OamLocalBoard.HwInstanceId;
      }
    }

    public string NdisLinkage
    {
      get
      {
        return OamLocalBoard.NdisLinkage;
      }
      set
      {
        OamLocalBoard.NdisLinkage = value;
      }
    }

    public string ServiceInstance
    {
      get
      {
        return OamLocalBoard.ServiceInstance;
      }
    }

    public void SetStatus(OamLocalBoardState state)
    {
      OamLocalBoard.SetStatus(state);
    }

    public void SetInitialState()
    {
      OamLocalBoard.SetInitialState();
    }
  }
}
