using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamVariableContainerProxy
  {
    OamVariableContainer OamVariableContainer;
    public OamVariableContainerProxy(IOamVariableContainer container)
    {
      OamVariableContainer = container as OamVariableContainer;
    }
  }
}
