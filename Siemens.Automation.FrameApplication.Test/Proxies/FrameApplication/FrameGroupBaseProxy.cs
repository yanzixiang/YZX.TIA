using System.Collections.Generic;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.ViewManager;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class FrameGroupBaseProxy
  {
    FrameGroupBase FrameGroupBase;

    public FrameGroupBaseProxy(IFrameGroup group)
    {
      FrameGroupBase = group as FrameGroupBase;
    }

    public List<IViewFrame> ViewFrameList
    {
      get
      {
        return Reflector.GetInstanceFieldByName(FrameGroupBase,
          "m_ViewFrameList",
          ReflectionWays.SystemReflection) as List<IViewFrame>;
      }
    }

    public List<IFrame> NonViewFrameList
    {
      get
      {
        return Reflector.GetInstanceFieldByName(FrameGroupBase,
          "m_NonViewFrameList",
          ReflectionWays.SystemReflection) as List<IFrame>;
      }
    }

    public IFrame ActiveFrame
    {
      get
      {
        return Reflector.GetInstancePropertyByName(FrameGroupBase,
          "ActiveFrame",
          ReflectionWays.SystemReflection) as IFrame;
      }
    }

    public bool IsClosing
    {
      get
      {
        return FrameGroupBase.IsClosing;
      }
    }

    public bool IsClosed
    {
      get
      {
        return FrameGroupBase.IsClosed;
      }
    }

    public bool PendingRestoreActivate
    {
      get
      {
        return FrameGroupBase.PendingRestoreActivate;
      }
    }
  }
}
