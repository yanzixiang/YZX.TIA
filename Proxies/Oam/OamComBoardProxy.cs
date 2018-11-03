using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamComBoardProxy:OamLocalBoardBaseProxy
  {
    OamComBoard OamLocalBoard;
    public OamComBoardProxy(IOamLocalBoard localBoard):base(localBoard)
    {
      OamLocalBoard = localBoard as OamComBoard;
    }
  }
}
