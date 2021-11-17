using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamConnectionProxy
  {
    OamConnection OamConnection;
    public OamConnectionProxy(OamConnectionBase connection)
    {
      OamConnection = connection as OamConnection;
    }

    public int LastResult
    {
      get
      {
        return OamConnection.LastResult;
      }
      set
      {
        OamConnection.LastResult = value;
      }
    }

    public OamConnectionType ConnType
    {
      get
      {
        return OamConnection.ConnType;
      }
      set
      {
        OamConnection.ConnType = value;
      }
    }

    OamConnectionStatemachine StateMachine
    {
      get
      {
        return OamConnection.StateMachine;
      }
    }

    OamSharedConnectionServer ShareServer
    {
      get
      {
        return OamConnection.ShareServer;
      }
    }

    public int NoUserCallbackCounter
    {
      get
      {
        return OamConnection.NoUserCallbackCounter;
      }
    }
  }
}
