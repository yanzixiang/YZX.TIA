using System.Windows.Forms;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;

using Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class FrameBaseProxy
  {
    FrameBase FrameBase;
    public IFrame Frame
    {
      get
      {
        return FrameBase;
      }
    }
    IFrameInternal IFrameInternal
    {
      get
      {
        return FrameBase as IFrameInternal;
      }
    }

    public static FrameBaseProxy ToProxy(IFrame frame)
    {
      if(frame is HierarchyFrame)
      {
        return HierarchyFrameProxy.ToProxy(frame);
      }
      if(frame is ViewFrame)
      {
        return ViewFrameProxy.ToProxy(frame);
      }
      return new FrameBaseProxy(frame);
    }
    public FrameBaseProxy(IFrame frame)
    {
      FrameBase = frame as FrameBase;
    }

    public bool IsClosing
    {
      get
      {
        return FrameBase.IsClosing;
      }
    }

    public FrameBackground Background
    {
      get
      {
        return FrameBase.Background;
      }
    }

    public DockStyle Dock
    {
      get
      {
        return IFrameInternal.Dock;
      }
      set
      {
        IFrameInternal.Dock = value;
      }
    }

    public WindowManagerProxy WindowManagerProxy
    {
      get
      {
        var manager = Reflector.GetInstancePropertyByName(FrameBase,
          "",
          ReflectionWays.SystemReflection)
          as IWindowManagerInternal;
        WindowManagerProxy proxy = new WindowManagerProxy(manager);
        return proxy;
      }
    }

    public override string ToString()
    {
      return string.Format("{0} : {1}", FrameBase.GetType(), FrameBase.InstanceName);
    }
  }
}
