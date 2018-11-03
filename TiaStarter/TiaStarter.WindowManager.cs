using Siemens.Automation.FrameApplication;

using YZX.Tia.Extensions;
using YZX.Tia.Proxies;
using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public IWindowManager WindowManager
    {
      get
      {
        return m_ViewApplicationContext.GetWindowManager() as IWindowManager;
      }
    }

    public WindowManagerProxy WindowManagerProxy
    {
      get
      {
        return m_ViewApplicationContext.GetWindowManagerProxy();
      }
    }
  }
}
