using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.PlcLanguages.BlockLogic.Compiler.Util.Extensions;

namespace YZX.Tia.Proxies.BlockLogic
{
  public static class ICoreObjectExtensionProxy
  {
    public static bool IsLittle(this ICoreObject m_target)
    {
      return ICoreObjectExtension.IsLittle(m_target);
    }
  }
}
