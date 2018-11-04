using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamCustomBoardProxy : OamLocalBoardBaseProxy
  {
    OamCustomBoard OamLocalBoard;
    public OamCustomBoardProxy(IOamLocalBoard localBoard):base(localBoard)
    {
      OamLocalBoard = localBoard as OamCustomBoard;
    }
  }
}
