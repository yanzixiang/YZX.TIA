using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamVariableControlProxy
  {
    OamVariableControl OamVariableControl;
    public OamVariableControlProxy(IOamVariableControl control)
    {
      OamVariableControl = control as OamVariableControl;
    }


  }
}
