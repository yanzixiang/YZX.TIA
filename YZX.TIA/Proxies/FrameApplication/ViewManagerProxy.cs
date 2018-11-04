using System;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.ViewManager;
using Siemens.Automation.FrameApplication.WindowManager;

using Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class ViewManagerProxy
  {
    ViewManager ViewManager;

    public IViewManager IViewManager
    {
      get
      {
        return ViewManager as IViewManager;
      }
    }

    IViewManagerInternal IViewManagerInternal
    {
      get
      {
        return ViewManager as IViewManagerInternal;
      }
    }

    public IFrameCreator IFrameCreator
    {
      get
      {
        return ViewManager as IFrameCreator;
      }
    }
    IViewManagerTestSupport ViewManagerTestSupport
    {
      get
      {
        return ViewManager as IViewManagerTestSupport;
      }
    }

    public IWorkingContext WorkingContext
    {
      get
      {
        return Reflector.GetInstanceFieldByName(ViewManager,
          "m_WorkingContext",
          ReflectionWays.SystemReflection) as IWorkingContext;
      }
    }
    public ViewManagerProxy(IViewManager manager)
    {
      ViewManager = manager as ViewManager;
    }

    public IFrame Show(string viewId, object payload=null)
    {
      return IFrameCreator.Show(viewId, payload);
    }

    public IFrameGroup CreateFrameGroup(IFrame commonParent)
    {
      return new FrameGroup(WorkingContext, commonParent);
    }

    public bool CanCreateEditorFrameGroup()
    {
      return IViewManager.CanCreateEditorFrameGroup();
    }

    public IEditorFrameGroup CreateEditorFrameGroup()
    {
      return IViewManager.CreateEditorFrameGroup();
    }

    public IView CreateView(string viewId, object payload=null)
    {
      return IViewManager.CreateView(viewId, payload);
    }

    public bool IsAvailableViewId(string viewId)
    {
      return IViewManagerInternal.IsAvailableViewId(viewId);
    }

    public string GetViewFrameId(string viewId)
    {
      return IViewManagerInternal.GetViewFrameId(viewId);
    }


  }
}
