using System.Collections.Generic;
using System.Collections;

using System.Windows.Forms;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public partial class WindowManagerProxy
  {
    IWindowManagerInternal WindowManager;
    public IWindowManager IWindowManager
    {
      get
      {
        return WindowManager as IWindowManager;
      }
    }

    DlcWindowManager DlcWindowManager
    {
      get
      {
        return WindowManager as DlcWindowManager;
      }
    }

    internal WindowManagerProxy(IWindowManagerInternal manager)
    {
      WindowManager = manager;
    }

    public Control ApplicationFrameWindow
    {
      get
      {
        return IWindowManager.ApplicationFrameWindow;
      }
    }

    public IApplicationFrame ApplicationFrame
    {
      get
      {
        return WindowManager.ApplicationFrame;
      }
    }

    public ApplicationFrameProxy ApplicationFrameProxy
    {
      get
      {
        return new ApplicationFrameProxy(ApplicationFrame);
      }
    }

    public void ShowViewMode(ApplicationViewMode mode)
    {
      WindowManager.ShowViewMode(mode);
    }

    public void ShowViewMode(string mode)
    {
      switch (mode)
      {
        case "Compact":
          WindowManager.ShowViewMode(ApplicationViewMode.Compact);
          break;
        case "Portal":
          WindowManager.ShowViewMode(ApplicationViewMode.Portal);
          break;
        case "Project":
          WindowManager.ShowViewMode(ApplicationViewMode.Project);
          break;
        case "Library":
          WindowManager.ShowViewMode(ApplicationViewMode.Library);
          break;
      }
    }

    internal IApplicationViewModeManager ApplicationViewModeManager
    {
      get
      {
        return WindowManager.ApplicationViewModeManager;
      }
    }

    public List<IFrame> Frames
    {
      get
      {
        return Reflector.GetInstanceFieldByName(WindowManager,
          "m_FrameInstanceList",
          ReflectionWays.SystemReflection)
          as List<IFrame>;
      }
    }

    public List<FrameBaseProxy> SingletonFrames
    {
      get
      {
        Hashtable hashTable =  Reflector.GetInstanceFieldByName(WindowManager,
          "m_SingletonFrames",
          ReflectionWays.SystemReflection)
          as Hashtable;
        List<FrameBaseProxy> frames = new List<FrameBaseProxy>();
        foreach(IFrame frame in hashTable.Values)
        {
          FrameBaseProxy proxy = FrameBaseProxy.ToProxy(frame);
          frames.Add(proxy);
        }
        return frames;
      }
    }

    public bool CompactMode
    {
      get
      {
        return ApplicationViewModeManager.CurrentView == ApplicationViewMode.Compact;
      }
    }

    public IFrame Show(IView view, string viewFrameId, IFrameGroup existingFrames)
    {
      return WindowManager.Show(view, viewFrameId, existingFrames);
    }

    public IFrame Show(string frameId, IFrameGroup existingFrames)
    {
      return WindowManager.Show(frameId, existingFrames);
    }

    public IFrame GetSingletonFrame(string frameId)
    {
      return WindowManager.GetSingletonFrame(frameId);
    }

    public IFrame GetFrame(string frameId)
    {
      return WindowManager.GetFrame(frameId);
    }

    public IFrame GetFrame(string frameId, IFrameGroup frameGroup)
    {
      return WindowManager.GetFrame(frameId, frameGroup);
    }

    public IFrame CreateFrame(string frameId, IWorkingContext workingContext)
    {
      return DlcWindowManager.CreateFrame(frameId, workingContext);
    }

    FrameBaseMeta GetMetaData(string frameId)
    {
      return WindowManager.GetMetaData(frameId);
    }

    public FrameBaseMetaProxy GetMetaDataProxy(string frameId)
    {
      FrameBaseMeta meta = WindowManager.GetMetaData(frameId);
      var proxy = FrameBaseMetaProxy.ToProxy(meta);
      return proxy;
    }
  }
}
